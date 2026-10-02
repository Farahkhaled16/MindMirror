(function () {
    var KEY = 'mindmirror.journal';
    var faces = { 1: '😞', 2: '😕', 3: '😐', 4: '🙂', 5: '😄' };
    var locale = document.documentElement.lang === 'ar' ? 'ar-EG' : undefined;

    var form = document.getElementById('journal-form');
    var list = document.getElementById('entries');
    var summary = document.getElementById('summary');
    var clearBtn = document.getElementById('clear-all');
    var errorBox = document.getElementById('journal-error');
    if (!form) return;

    function load() {
        try { return JSON.parse(localStorage.getItem(KEY) || '[]'); }
        catch (e) { return []; }
    }
    function save(items) {
        try { localStorage.setItem(KEY, JSON.stringify(items)); } catch (e) { }
    }

    function render() {
        document.dispatchEvent(new Event('journal:changed'));
        var items = load();
        list.replaceChildren();

        items.slice().reverse().forEach(function (item, idx) {
            var realIndex = items.length - 1 - idx;
            var li = document.createElement('li');
            li.className = 'entry';

            var face = document.createElement('span');
            face.className = 'entry-face';
            face.textContent = faces[item.mood] || '';

            var body = document.createElement('div');
            body.className = 'entry-body';
            var date = document.createElement('strong');
            date.textContent = new Date(item.date).toLocaleString(locale);
            body.appendChild(date);
            if (item.note) {
                var note = document.createElement('p');
                note.textContent = item.note;
                body.appendChild(note);
            }

            var del = document.createElement('button');
            del.type = 'button';
            del.className = 'link-danger';
            del.textContent = t('Delete', 'حذف');
            del.addEventListener('click', function () {
                if (!confirm(t('Delete this entry?', 'هل تريد حذف هذا الإدخال؟'))) return;
                var all = load();
                all.splice(realIndex, 1);
                save(all);
                render();
            });

            li.append(face, body, del);
            list.appendChild(li);
        });

        clearBtn.hidden = items.length === 0;

        var recent = items.slice(-7);
        if (recent.length === 0) {
            summary.hidden = true;
            return;
        }
        var avg = recent.reduce(function (s, i) { return s + i.mood; }, 0) / recent.length;
        var text = t(
            'Average mood over your last ' + recent.length + ' entries: ' + avg.toFixed(1) + ' out of 5.',
            'متوسط مزاجك في آخر ' + recent.length + ' إدخالات: ' + avg.toFixed(1) + ' من 5.'
        );
        if (recent.length >= 5 && avg <= 2) {
            text += t(
                ' It looks like things have been hard lately. Consider talking to someone you trust or a professional. See the Get Help page.',
                ' يبدو أن الأمور كانت صعبة مؤخراً. فكّر في التحدث إلى شخص تثق به أو إلى مختص. زر صفحة «اطلب المساعدة».'
            );
        }
        summary.textContent = text;
        summary.hidden = false;
    }

    form.addEventListener('submit', function (e) {
        e.preventDefault();
        var picked = form.querySelector('input[name="mood"]:checked');
        if (!picked) {
            errorBox.textContent = t('Please pick how you feel.', 'يرجى اختيار ما تشعر به.');
            errorBox.hidden = false;
            return;
        }
        errorBox.hidden = true;

        var items = load();
        items.push({
            date: new Date().toISOString(),
            mood: parseInt(picked.value, 10),
            note: document.getElementById('note').value.trim().slice(0, 500)
        });
        save(items.slice(-365));
        form.reset();
        render();
    });

    clearBtn.addEventListener('click', function () {
        if (confirm(t('Delete all journal entries from this browser? This cannot be undone.',
            'هل تريد حذف كل إدخالات المفكرة من هذا المتصفح؟ لا يمكن التراجع عن ذلك.'))) {
            save([]);
            render();
        }
    });

    render();
})();