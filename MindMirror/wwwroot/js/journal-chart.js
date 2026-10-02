(function () {
    var KEY = 'mindmirror.journal';
    var box = document.getElementById('chart');
    if (!box) return;
    var NS = 'http://www.w3.org/2000/svg';

    function load() {
        try { return JSON.parse(localStorage.getItem(KEY) || '[]'); }
        catch (e) { return []; }
    }
    function mk(tag, attrs) {
        var n = document.createElementNS(NS, tag);
        for (var k in attrs) n.setAttribute(k, attrs[k]);
        return n;
    }

    function draw() {
        var items = load().slice(-14);
        box.replaceChildren();
        if (items.length < 2) { box.hidden = true; return; }
        box.hidden = false;

        var W = 320, H = 150, pl = 22, pr = 10, pt = 10, pb = 12;
        var svg = mk('svg', {
            viewBox: '0 0 ' + W + ' ' + H, role: 'img',
            'aria-label': t('Your mood over your recent entries', 'مزاجك خلال إدخالاتك الأخيرة')
        });
        svg.setAttribute('dir', 'ltr'); // time always runs left to right in the chart

        function yOf(v) { return pt + (5 - v) * (H - pt - pb) / 4; }

        for (var v = 1; v <= 5; v++) {
            svg.appendChild(mk('line', { x1: pl, x2: W - pr, y1: yOf(v), y2: yOf(v), 'class': 'chart-grid' }));
            var label = mk('text', { x: 4, y: yOf(v) + 3, 'class': 'chart-label' });
            label.textContent = v;
            svg.appendChild(label);
        }

        var pts = items.map(function (it, i) {
            return { x: pl + i * (W - pl - pr) / (items.length - 1), y: yOf(it.mood) };
        });
        svg.appendChild(mk('polyline', {
            points: pts.map(function (p) { return p.x + ',' + p.y; }).join(' '),
            'class': 'chart-line'
        }));
        pts.forEach(function (p) {
            svg.appendChild(mk('circle', { cx: p.x, cy: p.y, r: 3.5, 'class': 'chart-dot' }));
        });

        var title = document.createElement('h3');
        title.textContent = t('Your mood over the last ' + items.length + ' entries',
            'مزاجك خلال آخر ' + items.length + ' إدخالات');
        box.append(title, svg);
    }

    document.addEventListener('journal:changed', draw);
    draw();
})();