(function () {
    var circle = document.getElementById('circle');
    var label = document.getElementById('phase');
    var btn = document.getElementById('breath-btn');
    if (!circle) return;

    var phases = [
        { name: t('Breathe in', 'شهيق'), cls: 'inhale', sec: 4 },
        { name: t('Hold', 'احبس النَّفَس'), cls: 'hold', sec: 4 },
        { name: t('Breathe out', 'زفير'), cls: 'exhale', sec: 6 }
    ];
    var running = false, i = 0, timer = null;

    function step() {
        var p = phases[i];
        label.textContent = p.name;
        circle.className = 'circle ' + p.cls;
        timer = setTimeout(function () {
            i = (i + 1) % phases.length;
            step();
        }, p.sec * 1000);
    }

    btn.addEventListener('click', function () {
        if (running) {
            clearTimeout(timer);
            running = false;
            circle.className = 'circle';
            label.textContent = t('Ready', 'جاهز');
            btn.textContent = t('Start', 'ابدأ');
        } else {
            running = true;
            i = 0;
            btn.textContent = t('Stop', 'إيقاف');
            step();
        }
    });
})();