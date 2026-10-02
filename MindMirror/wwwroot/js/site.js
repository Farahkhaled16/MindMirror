document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('form[data-confirm]').forEach(function (form) {
        form.addEventListener('submit', function (e) {
            if (!confirm(form.dataset.confirm)) {
                e.preventDefault();
            }
        });
    });

    document.querySelectorAll('[data-print]').forEach(function (b) {
        b.addEventListener('click', function () { window.print(); });
    });
    document.querySelectorAll('select[data-autosubmit]').forEach(function (s) {
        s.addEventListener('change', function () { s.form.submit(); });
    });

    var toggle = document.getElementById('theme-toggle');
    if (toggle) {
        toggle.addEventListener('click', function () {
            var root = document.documentElement;
            var next = root.getAttribute('data-theme') === 'dark' ? 'light' : 'dark';
            root.setAttribute('data-theme', next);
            try { localStorage.setItem('theme', next); } catch (e) { }
        });
    }
});