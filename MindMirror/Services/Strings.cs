namespace MindMirror.Services;

public static class Strings
{
    // key = (English, Arabic)
    public static readonly Dictionary<string, (string En, string Ar)> Map = new()
    {
        // Layout
        ["site.description"] = ("MindMirror is a calm space to learn about mental health, check in with yourself, and find support.",
                                "MindMirror مساحة هادئة للتعرّف على الصحة النفسية، ومراجعة مشاعرك، وإيجاد الدعم."),
        ["nav.home"] = ("Home", "الرئيسية"),
        ["nav.articles"] = ("Articles", "المقالات"),
        ["nav.conditions"] = ("Conditions", "الحالات النفسية"),
        ["nav.selfcheck"] = ("Self-Check", "اختبار ذاتي"),
        ["nav.toolkit"] = ("Toolkit", "أدوات المساعدة"),
        ["nav.directory"] = ("Directory", "الدليل"),
        ["nav.hospitals"] = ("Hospitals", "المستشفيات"),
        ["nav.help"] = ("Get Help", "اطلب المساعدة"),
        ["nav.theme"] = ("Toggle dark mode", "تبديل الوضع الداكن"),
        ["crisis.text"] = ("If you are in immediate danger, call emergency services:", "إذا كنت في خطر فوري، اتصل بالطوارئ:"),
        ["crisis.more"] = ("More support", "مزيد من الدعم"),
        ["footer.disclaimer"] = ("This website is for awareness only and is not a substitute for a doctor or licensed therapist.",
                                 "هذا الموقع للتوعية فقط، وليس بديلاً عن الطبيب أو المعالج النفسي المرخّص."),
        ["footer.privacy"] = ("Privacy", "الخصوصية"),
        ["footer.admin"] = ("Admin", "الإدارة"),
        ["footer.adminpanel"] = ("Admin panel", "لوحة الإدارة"),

        // Home
        ["home.eyebrow"] = ("Mental wellness space", "مساحة للعافية النفسية"),
        ["home.title1"] = ("See yourself", "اعرف نفسك"),
        ["home.title2"] = ("clearly.", "بوضوح."),
        ["home.subtitle"] = ("A calm place to understand your feelings, learn about mental health, and know how to ask for help.",
                             "مكان هادئ لتفهم مشاعرك، وتتعرّف على الصحة النفسية، وتعرف كيف تطلب المساعدة."),
        ["home.needhelp"] = ("Need help?", "تحتاج مساعدة؟"),
        ["home.readarticles"] = ("Read articles", "اقرأ المقالات"),
        ["tip.label"] = ("Tip of the day", "نصيحة اليوم"),

        ["card.articles.title"] = ("Articles", "المقالات"),
        ["card.articles.text"] = ("About anxiety, depression, sleep, and stress.", "عن القلق والاكتئاب والنوم والتوتر."),
        ["card.articles.link"] = ("Read articles", "اقرأ المقالات"),

        ["card.conditions.title"] = ("Conditions", "الحالات النفسية"),
        ["card.conditions.text"] = ("Plain-language guides to anxiety, depression, OCD, PTSD, and more.",
                                    "شروحات مبسّطة عن القلق والاكتئاب والوسواس القهري واضطراب ما بعد الصدمة وغيرها."),
        ["card.conditions.link"] = ("Explore conditions", "استكشف الحالات"),

        ["card.selfcheck.title"] = ("Self-Check", "اختبار ذاتي"),
        ["card.selfcheck.text"] = ("Short, private questionnaires to help you notice how you've been feeling.",
                                   "استبيانات قصيرة وخاصة تساعدك على ملاحظة مشاعرك في الفترة الأخيرة."),
        ["card.selfcheck.link"] = ("Take a check", "ابدأ الاختبار"),

        ["card.journal.title"] = ("Mood Journal", "مفكرة المزاج"),
        ["card.journal.text"] = ("Track how you feel day by day. Saved privately in your browser.",
                                 "تابع مزاجك يوماً بيوم. تُحفظ بشكل خاص في متصفحك فقط."),
        ["card.journal.link"] = ("Open journal", "افتح المفكرة"),

        ["card.breathe.title"] = ("Breathing Exercise", "تمرين التنفس"),
        ["card.breathe.text"] = ("A guided one-minute reset when things feel like too much.",
                                 "دقيقة إرشادية لاستعادة هدوئك عندما تشعر أن الأمور أكبر من طاقتك."),
        ["card.breathe.link"] = ("Start breathing", "ابدأ التنفس"),

        ["card.hospitals.title"] = ("Hospitals & Hotlines", "المستشفيات والخطوط الساخنة"),
        ["card.hospitals.text"] = ("Call mental health hospitals and hotlines directly.",
                                   "اتصل مباشرة بمستشفيات الصحة النفسية والخطوط الساخنة."),
        ["card.hospitals.link"] = ("See hospitals", "شاهد المستشفيات"),

        ["card.help.title"] = ("Where to Get Help", "أين تجد المساعدة"),
        ["card.help.text"] = ("Phone numbers and clinics you can contact.", "أرقام وعيادات يمكنك التواصل معها."),
        ["card.help.link"] = ("See options", "شاهد الخيارات"),

        // Tips of the day
        ["tip.1"] = ("Drink a glass of water and take three slow breaths.", "اشرب كوب ماء وخذ ثلاثة أنفاس بطيئة."),
        ["tip.2"] = ("Step outside for five minutes, even if it's just to the doorstep.", "اخرج لخمس دقائق، حتى لو كان ذلك إلى عتبة الباب فقط."),
        ["tip.3"] = ("Send a short message to someone you care about.", "أرسل رسالة قصيرة لشخص تهتم به."),
        ["tip.4"] = ("Name what you're feeling. Putting it into words can make it lighter.", "سمِّ ما تشعر به. التعبير عنه بالكلمات قد يخفف وطأته."),
        ["tip.5"] = ("Do one small task you've been avoiding. Just the first two minutes.", "أنجز مهمة صغيرة كنت تتجنبها. أول دقيقتين فقط."),
        ["tip.6"] = ("Put your phone down for 15 minutes before bed tonight.", "ضع هاتفك جانباً لخمس عشرة دقيقة قبل النوم الليلة."),
        ["tip.7"] = ("Stretch your shoulders and neck for one minute.", "مدّ كتفيك ورقبتك لمدة دقيقة."),
        ["tip.8"] = ("Being kind to yourself counts as progress today.", "أن تكون لطيفاً مع نفسك يُعدّ تقدماً اليوم."),
    };
}