(function () {
    var input = document.getElementById('password');
    var btn = document.getElementById('toggle-password');
    if (!input || !btn) return;

    btn.addEventListener('click', function () {
        var show = input.type === 'password';
        input.type = show ? 'text' : 'password';
        btn.textContent = show ? 'Hide' : 'Show';
        btn.setAttribute('aria-label', show ? 'Hide password' : 'Show password');
    });
})();