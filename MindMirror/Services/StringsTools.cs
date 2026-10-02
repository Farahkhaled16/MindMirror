namespace MindMirror.Services;

public static class StringsTools
{
    public static readonly Dictionary<string, (string En, string Ar)> Map = new()
    {
        ["common.start"] = ("Start", "ابدأ"),
        ["common.stop"] = ("Stop", "إيقاف"),
        ["common.ready"] = ("Ready", "جاهز"),

        // Toolkit hub
        ["tools.lead"] = ("Simple tools you can use right now. Nothing here is saved on our servers.",
                          "أدوات بسيطة يمكنك استخدامها الآن. لا يُحفظ أي شيء هنا على خوادمنا."),
        ["tools.open"] = ("Open", "افتح"),
        ["tools.breathe.t"] = ("Breathing", "التنفس"),
        ["tools.breathe.d"] = ("A guided breathing circle.", "دائرة إرشادية للتنفس."),
        ["tools.ground.t"] = ("Grounding 5-4-3-2-1", "التأريض 5-4-3-2-1"),
        ["tools.ground.d"] = ("Use your senses to come back to the present.", "استخدم حواسك للعودة إلى اللحظة الحاضرة."),
        ["tools.relax.t"] = ("Muscle relaxation", "استرخاء العضلات"),
        ["tools.relax.d"] = ("Release tension step by step.", "تخلّص من التوتر خطوة بخطوة."),
        ["tools.timer.t"] = ("Quiet timer", "مؤقت الهدوء"),
        ["tools.timer.d"] = ("A few minutes of stillness.", "بضع دقائق من السكون."),
        ["tools.journal.t"] = ("Mood journal", "مفكرة المزاج"),
        ["tools.journal.d"] = ("Track your mood and see a chart.", "تابع مزاجك وشاهد الرسم البياني."),
        ["tools.plan.t"] = ("Safety plan", "خطة الأمان"),
        ["tools.plan.d"] = ("Write a plan for hard moments.", "اكتب خطة للّحظات الصعبة."),

        // Breathe
        ["breathe.title"] = ("Breathe", "تنفّس"),
        ["breathe.lead"] = ("Follow the circle: breathe in for 4 seconds, hold for 4, and breathe out for 6. Repeat for a few minutes.",
                            "تابع الدائرة: شهيق لمدة 4 ثوانٍ، ثم احبس النَّفَس 4 ثوانٍ، ثم زفير لمدة 6 ثوانٍ. كرّر ذلك لبضع دقائق."),
        ["breathe.notice"] = ("Slow breathing can help you feel calmer in the moment. If you feel dizzy, stop and breathe normally. It's not a treatment for mental health conditions.",
                              "قد يساعدك التنفس البطيء على الشعور بهدوء أكبر في اللحظة. إذا شعرت بدوخة فتوقف وتنفّس بشكل طبيعي. وهو ليس علاجاً للحالات النفسية."),

        // Grounding / Relax shared
        ["guide.back"] = ("Back", "السابق"),
        ["guide.next"] = ("Next", "التالي"),
        ["guide.safe1"] = ("If you feel unsafe or the feeling doesn't ease, reach out to someone you trust or see",
                           "إذا شعرت بعدم الأمان أو لم يخف الشعور، فتواصل مع شخص تثق به أو انتقل إلى صفحة"),
        ["ground.title"] = ("5-4-3-2-1 Grounding", "التأريض 5-4-3-2-1"),
        ["ground.lead"] = ("When you feel overwhelmed or anxious, this brings your attention back to the present. Take your time with each step.",
                           "عندما تشعر بالإرهاق أو القلق، يعيد هذا التمرين انتباهك إلى اللحظة الحاضرة. خذ وقتك مع كل خطوة."),
        ["relax.title"] = ("Muscle Relaxation", "استرخاء العضلات"),
        ["relax.lead"] = ("For each part of the body: tighten gently for about 5 seconds, then let go for about 10 seconds and notice the difference.",
                          "لكل جزء من الجسم: شُدّه برفق لنحو 5 ثوانٍ، ثم أرخِه لنحو 10 ثوانٍ ولاحظ الفرق."),
        ["relax.notice"] = ("Skip any area where you have pain or an injury, and never tense to the point of pain.",
                            "تجاوز أي منطقة فيها ألم أو إصابة، ولا تشدّ العضلات إلى حد الألم أبداً."),

        // Timer
        ["timer.title"] = ("Quiet Timer", "مؤقت الهدوء"),
        ["timer.lead"] = ("Sit comfortably, breathe naturally, and let your thoughts come and go.",
                          "اجلس بارتياح، وتنفّس بشكل طبيعي، ودع أفكارك تأتي وتذهب."),
        ["timer.1"] = ("1 minute", "دقيقة واحدة"),
        ["timer.3"] = ("3 minutes", "3 دقائق"),
        ["timer.5"] = ("5 minutes", "5 دقائق"),
        ["timer.10"] = ("10 minutes", "10 دقائق"),
        ["timer.done"] = ("Well done. Take a moment before you continue.", "أحسنت. خذ لحظة قبل أن تتابع."),

        // Journal
        ["journal.title"] = ("Mood Journal", "مفكرة المزاج"),
        ["journal.how"] = ("How are you feeling today?", "كيف تشعر اليوم؟"),
        ["journal.note"] = ("Note (optional)", "ملاحظة (اختياري)"),
        ["journal.note.ph"] = ("What's on your mind?", "ما الذي يشغل بالك؟"),
        ["journal.save"] = ("Save entry", "حفظ الإدخال"),
        ["journal.clearall"] = ("Delete all entries", "حذف كل الإدخالات"),

        // Safety plan
        ["plan.title"] = ("My Safety Plan", "خطة الأمان الخاصة بي"),
        ["plan.lead"] = ("A safety plan is a short guide you write when you feel okay, to use when things get hard. Fill in what feels right for you.",
                         "خطة الأمان دليل قصير تكتبه وأنت بخير لتستخدمه عندما تصبح الأمور صعبة. املأ ما تراه مناسباً لك."),
        ["plan.1"] = ("1. My warning signs (thoughts, feelings, situations)", "1. علامات الإنذار عندي (أفكار، مشاعر، مواقف)"),
        ["plan.2"] = ("2. Things I can do on my own to feel safer", "2. أشياء أستطيع فعلها بنفسي لأشعر بأمان أكبر"),
        ["plan.3"] = ("3. People and places that help me feel better", "3. أشخاص وأماكن تساعدني على الشعور بتحسّن"),
        ["plan.4"] = ("4. People I can ask for help (names and numbers)", "4. أشخاص يمكنني طلب المساعدة منهم (الأسماء والأرقام)"),
        ["plan.5"] = ("5. Professionals I can contact (names and numbers)", "5. مختصون يمكنني التواصل معهم (الأسماء والأرقام)"),
        ["plan.6"] = ("6. Ways to make my surroundings safer (ask someone to help if needed)", "6. طرق لجعل محيطي أكثر أماناً (اطلب مساعدة أحد عند الحاجة)"),
        ["plan.7"] = ("7. What matters most to me", "7. ما هو الأهم بالنسبة لي"),
        ["plan.emergency"] = ("Emergency services:", "الطوارئ:"),
        ["plan.print"] = ("Print", "طباعة"),
        ["plan.clear"] = ("Clear", "مسح"),
        ["plan.saved"] = ("Saved on this device.", "تم الحفظ على هذا الجهاز."),

        // Self-check
        ["sc.phq9"] = ("Mood (PHQ-9)", "المزاج (PHQ-9)"),
        ["sc.gad7"] = ("Anxiety (GAD-7)", "القلق (GAD-7)"),
        ["sc.notice1"] = ("This is a screening questionnaire,", "هذا استبيان فحص أولي،"),
        ["sc.notice.bold"] = ("not a diagnosis.", "وليس تشخيصاً."),
        ["sc.notice2"] = ("Your answers stay in your browser. They are never sent to us or saved.",
                          "تبقى إجاباتك في متصفحك ولا تُرسل إلينا ولا تُحفظ."),
        ["sc.lead"] = ("Over the last 2 weeks, how often have you been bothered by the following problems?",
                       "خلال الأسبوعين الماضيين، كم مرة أزعجتك المشكلات التالية؟"),
        ["sc.o0"] = ("Not at all", "أبداً"),
        ["sc.o1"] = ("Several days", "عدة أيام"),
        ["sc.o2"] = ("More than half the days", "أكثر من نصف الأيام"),
        ["sc.o3"] = ("Nearly every day", "تقريباً كل يوم"),
        ["sc.submit"] = ("See my result", "اعرض نتيجتي"),
    };
}