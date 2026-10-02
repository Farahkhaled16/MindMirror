(function () {
    var sel = document.getElementById('minutes');
    var clock = document.getElementById('clock');
    var btn = document.getElementById('timer-btn');
    var msg = document.getElementById('timer-msg');
    if (!sel) return;

    var end = 0, tick_ = null;

    function fmt(s) {
        var m = Math.floor(s / 60), r = s % 60;
        return (m < 10 ? '0' : '') + m + ':' + (r < 10 ? '0' : '') + r;
    }
    function reset() {
        clearInterval(tick_); tick_ = null;
        sel.disabled = false;
        btn.textContent = t('Start', 'ابدأ');
        clock.textContent = fmt(parseInt(sel.value, 10) * 60);
    }
    function tick() {
        var left = Math.max(0, Math.round((end - Date.now()) / 1000));
        clock.textContent = fmt(left);
        if (left === 0) { reset(); msg.hidden = false; }
    }

    sel.addEventListener('change', reset);
    btn.addEventListener('click', function () {
        if (tick_) { reset(); return; }
        msg.hidden = true;
        end = Date.now() + parseInt(sel.value, 10) * 60000;
        sel.disabled = true;
        btn.textContent = t('Stop', 'إيقاف');
        tick();
        tick_ = setInterval(tick, 500);
    });
    reset();
})();