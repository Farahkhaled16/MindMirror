(function () {
    var KEY = 'mindmirror.safetyplan';
    var fields = Array.prototype.slice.call(document.querySelectorAll('[data-plan]'));
    if (!fields.length) return;
    var saved = document.getElementById('plan-saved');

    var data = {};
    try { data = JSON.parse(localStorage.getItem(KEY) || '{}'); } catch (e) { data = {}; }
    fields.forEach(function (f) { if (typeof data[f.id] === 'string') f.value = data[f.id]; });

    var timer = null;
    fields.forEach(function (f) {
        f.addEventListener('input', function () {
            data[f.id] = f.value.slice(0, 1000);
            try { localStorage.setItem(KEY, JSON.stringify(data)); } catch (e) { }
            saved.hidden = false;
            clearTimeout(timer);
            timer = setTimeout(function () { saved.hidden = true; }, 1500);
        });
    });

    document.getElementById('plan-print').addEventListener('click', function () { window.print(); });
    document.getElementById('plan-clear').addEventListener('click', function () {
        if (!confirm(t('Clear your safety plan from this browser?', 'هل تريد مسح خطة الأمان من هذا المتصفح؟'))) return;
        try { localStorage.removeItem(KEY); } catch (e) { }
        fields.forEach(function (f) { f.value = ''; });
        data = {};
    });
})();