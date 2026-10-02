using MindMirror.Models;

namespace MindMirror.Data;

public static class SeedArticles
{
    public static void Run(AppDbContext db)
    {
        foreach (var a in All)
        {
            var existing = db.Articles.FirstOrDefault(x => x.Title == a.Title);
            if (existing == null)
            {
                db.Articles.Add(a);
            }
            else
            {
                // Fill in Arabic only if it's empty (never overwrites admin edits)
                existing.TitleAr ??= a.TitleAr;
                existing.SummaryAr ??= a.SummaryAr;
                existing.ContentAr ??= a.ContentAr;
            }
        }
        db.SaveChanges();
    }

    private static readonly List<Article> All = new()
    {
        new Article
        {
            Title = "What Is Anxiety?", Category = "Anxiety",
            Summary = "The difference between normal worry and an anxiety disorder.",
            Content = "Feeling anxious before an exam or a big decision is normal. It becomes a concern when the worry is constant, hard to control, and starts affecting your sleep, work, or relationships.\n\nIf this sounds familiar, talking to a licensed professional can help. Anxiety is common and treatable.",
            TitleAr = "ما هو القلق؟",
            SummaryAr = "الفرق بين القلق الطبيعي واضطراب القلق.",
            ContentAr = "الشعور بالقلق قبل امتحان أو قرار كبير أمر طبيعي. ويصبح مصدر قلق عندما يكون الهمّ مستمراً ويصعب التحكم فيه ويبدأ بالتأثير على نومك أو عملك أو علاقاتك.\n\nإذا بدا هذا مألوفاً، فقد يساعدك الحديث مع مختص مرخّص. القلق شائع وقابل للعلاج."
        },
        new Article
        {
            Title = "Sleep and Mental Health", Category = "Sleep",
            Summary = "How lack of sleep affects your mood.",
            Content = "Sleep and mood are closely connected. Poor sleep can make stress feel heavier, and high stress can make it harder to sleep.\n\nSmall habits can help: a regular sleep schedule, less screen time before bed, and avoiding caffeine late in the day. If sleep problems last for weeks, consider speaking with a doctor.",
            TitleAr = "النوم والصحة النفسية",
            SummaryAr = "كيف يؤثر قلة النوم على مزاجك.",
            ContentAr = "ترتبط جودة النوم بالمزاج ارتباطاً وثيقاً. فقلة النوم قد تجعل التوتر أثقل، والتوتر الشديد قد يصعّب النوم.\n\nعادات صغيرة قد تساعد: موعد نوم منتظم، وتقليل استخدام الشاشات قبل النوم، وتجنّب الكافيين في آخر النهار. وإذا استمرت مشكلات النوم أسابيع، ففكّر في استشارة طبيب."
        },
        new Article
        {
            Title = "When Should I Ask for Help?", Category = "General",
            Summary = "Signs that it may be time to talk to a professional.",
            Content = "You don't need to wait for a crisis. Consider reaching out if sadness, worry, or numbness lasts for more than a couple of weeks, if it gets in the way of daily life, or if you feel you can't cope on your own.\n\nIf you ever feel you might hurt yourself, contact the emergency line or someone you trust right away.",
            TitleAr = "متى أطلب المساعدة؟",
            SummaryAr = "علامات تدل على أن الوقت قد حان للتحدث إلى مختص.",
            ContentAr = "لا يلزمك انتظار الأزمة. فكّر في طلب المساعدة إذا استمر الحزن أو القلق أو التبلّد أكثر من أسبوعين، أو إذا أعاق حياتك اليومية، أو شعرت أنك لا تستطيع التأقلم وحدك.\n\nوإذا شعرت يوماً أنك قد تؤذي نفسك، فاتصل بالطوارئ أو بشخص تثق به فوراً."
        },
        new Article
        {
            Title = "Understanding Low Mood", Category = "Depression",
            Summary = "Feeling down is common, but when does it become something more?",
            Content = "Everyone has days when they feel low. Depression is different: the low mood or loss of interest lasts most of the day, nearly every day, for two weeks or more, and it affects how you function.\n\nDepression is a medical condition, not a weakness, and it responds well to treatment such as therapy and, when needed, medication. A doctor or licensed therapist can help you decide what fits you.",
            TitleAr = "فهم المزاج المنخفض",
            SummaryAr = "الشعور بالإحباط شائع، ولكن متى يصبح شيئاً أكبر؟",
            ContentAr = "يمرّ الجميع بأيام ينخفض فيها مزاجهم. الاكتئاب مختلف: ينخفض المزاج أو يفقد الاهتمام معظم اليوم تقريباً كل يوم لمدة أسبوعين أو أكثر، ويؤثر على أدائك.\n\nالاكتئاب حالة طبية وليس ضعفاً، ويستجيب جيداً للعلاج مثل العلاج النفسي، وعند الحاجة الدواء. يمكن للطبيب أو المعالج المرخّص مساعدتك في اختيار ما يناسبك."
        },
        new Article
        {
            Title = "Small Ways to Manage Stress", Category = "Stress",
            Summary = "Simple, realistic habits that can take the edge off a hard week.",
            Content = "Stress is the body's response to pressure. A little can motivate you, but too much for too long wears you down.\n\nHelpful basics include moving your body, taking short breaks, talking to someone you trust, and breaking big tasks into small steps. Try the breathing exercise on this site for a quick reset. If stress feels unmanageable, a professional can help.",
            TitleAr = "طرق صغيرة لإدارة التوتر",
            SummaryAr = "عادات بسيطة وواقعية تخفف حدة أسبوع صعب.",
            ContentAr = "التوتر هو استجابة الجسم للضغط. القليل منه قد يحفّزك، لكن الكثير لفترة طويلة يستنزفك.\n\nمن الأساسيات المفيدة: تحريك جسمك، وأخذ استراحات قصيرة، والتحدث إلى شخص تثق به، وتقسيم المهام الكبيرة إلى خطوات صغيرة. جرّب تمرين التنفس في هذا الموقع لإعادة ضبط سريعة. وإذا بدا التوتر فوق الاحتمال، فيمكن لمختص مساعدتك."
        },
        new Article
        {
            Title = "Self-Care Is Not Selfish", Category = "Self-care",
            Summary = "Why looking after yourself helps you show up for others.",
            Content = "Self-care isn't only bubble baths. It means meeting your basic needs: sleep, food, movement, rest, and connection with people who care about you.\n\nStart small. Pick one habit you can keep, like a short daily walk or a fixed bedtime, and build from there.",
            TitleAr = "العناية بالنفس ليست أنانية",
            SummaryAr = "لماذا تساعدك العناية بنفسك على الحضور للآخرين.",
            ContentAr = "العناية بالنفس ليست حمّاماً دافئاً فقط. إنها تلبية احتياجاتك الأساسية: النوم والطعام والحركة والراحة والتواصل مع من يهتمون بك.\n\nابدأ صغيراً. اختر عادة واحدة تستطيع الالتزام بها، مثل مشي يومي قصير أو موعد نوم ثابت، ثم ابنِ عليها."
        },
    };
}