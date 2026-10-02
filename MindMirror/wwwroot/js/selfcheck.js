(function () {
    var form = document.getElementById('check-form');
    var out = document.getElementById('result');
    if (!form || !out) return;

    var test = form.dataset.test;
    var total = parseInt(form.dataset.total, 10);

    // [max score, key]
    var bands = {
        phq9: [[4, 'minimal'], [9, 'mild'], [14, 'moderate'], [19, 'modsevere'], [27, 'severe']],
        gad7: [[4, 'minimal'], [9, 'mild'], [14, 'moderate'], [21, 'severe']]
    };

    function levelName(key) {
        switch (key) {
            case 'minimal': return t('Minimal symptoms', 'أعراض ضئيلة');
            case 'mild': return t('Mild symptoms', 'أعراض خفيفة');
            case 'moderate': return t('Moderate symptoms', 'أعراض متوسطة');
            case 'modsevere': return t('Moderately severe symptoms', 'أعراض متوسطة إلى شديدة');
            default: return t('Severe symptoms', 'أعراض شديدة');
        }
    }

    function advice(key) {
        if (key === 'minimal') {
            return t('Your answers suggest few symptoms right now. Keep looking after your sleep, routine, and relationships.',
                'تشير إجاباتك إلى أعراض قليلة حالياً. واصل الاهتمام بنومك وروتينك وعلاقاتك.');
        }
        if (key === 'mild') {
            return t('Your answers suggest mild symptoms. Self-care can help, and if this continues or gets worse, consider talking to someone you trust or a professional.',
                'تشير إجاباتك إلى أعراض خفيفة. قد تساعدك العناية بالنفس، وإذا استمر ذلك أو ازداد سوءاً ففكّر في التحدث إلى شخص تثق به أو إلى مختص.');
        }
        return t('Your answers suggest symptoms that are worth taking seriously. It would be a good idea to talk with a doctor or a licensed mental health professional.',
            'تشير إجاباتك إلى أعراض تستحق الاهتمام الجاد. من الجيد أن تتحدث مع طبيب أو مختص مرخّص في الصحة النفسية.');
    }

    function el(tag, text, cls) {
        var node = document.createElement(tag);
        node.textContent = text;
        if (cls) node.className = cls;
        return node;
    }

    function show(children) {
        out.hidden = false;
        out.replaceChildren.apply(out, children);
        out.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }

    form.addEventListener('submit', function (e) {
        e.preventDefault();

        var answers = [];
        for (var i = 0; i < total; i++) {
            var picked = form.querySelector('input[name="q' + i + '"]:checked');
            if (!picked) {
                show([el('p', t('Please answer every question to see your result.', 'يرجى الإجابة عن كل الأسئلة لعرض النتيجة.'), 'result-error')]);
                return;
            }
            answers.push(parseInt(picked.value, 10));
        }

        var score = answers.reduce(function (a, b) { return a + b; }, 0);
        var max = total * 3;
        var key = bands[test].find(function (b) { return score <= b[0]; })[1];

        var nodes = [
            el('h2', levelName(key)),
            el('p', t('Your score: ' + score + ' out of ' + max, 'نتيجتك: ' + score + ' من ' + max), 'score'),
            el('p', advice(key)),
            el('p', t('Remember: this is not a diagnosis. Only a qualified professional can assess what you are going through.',
                'تذكّر: هذه ليست تشخيصاً. وحده المختص المؤهل يستطيع تقييم ما تمرّ به.'), 'small')
        ];

        if (test === 'phq9' && answers[8] > 0) {
            nodes.unshift(el('p',
                t('You said you have had thoughts of death or of hurting yourself. You deserve support right now. Please contact your local emergency number or someone you trust today, and see the Get Help page.',
                    'ذكرتَ أنك راودتك أفكار عن الموت أو إيذاء نفسك. أنت تستحق الدعم الآن. يرجى الاتصال برقم الطوارئ أو بشخص تثق به اليوم، وزيارة صفحة «اطلب المساعدة».'),
                'crisis-note'));
        }

        show(nodes);
    });
})();