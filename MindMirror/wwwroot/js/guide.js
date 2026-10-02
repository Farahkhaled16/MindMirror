(function () {
    document.querySelectorAll('[data-guide]').forEach(function (root) {
        var steps = Array.prototype.slice.call(root.querySelectorAll('.guide-steps > li'));
        var prev = root.querySelector('[data-guide-prev]');
        var next = root.querySelector('[data-guide-next]');
        var progress = root.querySelector('[data-guide-progress]');
        var i = 0;

        function show() {
            steps.forEach(function (s, idx) { s.hidden = idx !== i; });
            progress.textContent = t('Step ' + (i + 1) + ' of ' + steps.length,
                'الخطوة ' + (i + 1) + ' من ' + steps.length);
            prev.disabled = i === 0;
            next.textContent = i === steps.length - 1 ? t('Start again', 'ابدأ من جديد') : t('Next', 'التالي');
        }

        prev.addEventListener('click', function () { if (i > 0) { i--; show(); } });
        next.addEventListener('click', function () { i = (i + 1) % steps.length; show(); });
        show();
    });
})();