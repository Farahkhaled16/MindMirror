(function () {
    var input = document.getElementById('cond-search');
    var none = document.getElementById('no-match');
    if (!input) return;
    var cards = Array.prototype.slice.call(document.querySelectorAll('.card[data-search]'));

    input.addEventListener('input', function () {
        var q = input.value.trim().toLowerCase();
        var shown = 0;
        cards.forEach(function (c) {
            var match = c.dataset.search.toLowerCase().indexOf(q) !== -1;
            c.hidden = !match;
            if (match) shown++;
        });
        none.hidden = shown !== 0;
    });
})();