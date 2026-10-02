using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MindMirror.Services;

namespace MindMirror.Pages;

public class SelfCheckModel : PageModel
{
    private readonly Lang _lang;
    public SelfCheckModel(Lang lang) { _lang = lang; }

    [BindProperty(SupportsGet = true)]
    public string Test { get; set; } = "phq9";

    public string[] Questions { get; set; } = Array.Empty<string>();

    private static readonly string[] Phq9 =
    {
        "Little interest or pleasure in doing things",
        "Feeling down, depressed, or hopeless",
        "Trouble falling or staying asleep, or sleeping too much",
        "Feeling tired or having little energy",
        "Poor appetite or overeating",
        "Feeling bad about yourself, or that you are a failure or have let yourself or your family down",
        "Trouble concentrating on things, such as reading or watching television",
        "Moving or speaking so slowly that other people could have noticed, or being so restless that you have been moving around a lot more than usual",
        "Thoughts that you would be better off dead, or of hurting yourself in some way"
    };

    private static readonly string[] Phq9Ar =
    {
        "قلة الاهتمام أو الاستمتاع بالقيام بالأشياء",
        "الشعور بالحزن أو الاكتئاب أو اليأس",
        "صعوبة في النوم أو في البقاء نائماً، أو النوم أكثر من اللازم",
        "الشعور بالتعب أو قلة الطاقة",
        "ضعف الشهية أو الإفراط في الأكل",
        "الشعور بالسوء تجاه نفسك، أو أنك فاشل، أو أنك خذلت نفسك أو أسرتك",
        "صعوبة التركيز على أشياء مثل القراءة أو مشاهدة التلفاز",
        "التحرك أو الكلام ببطء شديد لدرجة قد يلاحظها الآخرون، أو العكس: أن تكون شديد التوتر والحركة أكثر من المعتاد",
        "أفكار بأنك ستكون أفضل حالاً لو كنت ميتاً، أو أفكار بإيذاء نفسك بطريقة ما"
    };

    private static readonly string[] Gad7 =
    {
        "Feeling nervous, anxious, or on edge",
        "Not being able to stop or control worrying",
        "Worrying too much about different things",
        "Trouble relaxing",
        "Being so restless that it is hard to sit still",
        "Becoming easily annoyed or irritable",
        "Feeling afraid, as if something awful might happen"
    };

    private static readonly string[] Gad7Ar =
    {
        "الشعور بالعصبية أو القلق أو التوتر",
        "عدم القدرة على التوقف عن القلق أو السيطرة عليه",
        "الإفراط في القلق بشأن أمور مختلفة",
        "صعوبة في الاسترخاء",
        "التململ لدرجة يصعب معها الجلوس بهدوء",
        "الانزعاج أو الغضب بسهولة",
        "الشعور بالخوف كأن شيئاً فظيعاً قد يحدث"
    };

    public void OnGet()
    {
        if (Test == "gad7")
        {
            Questions = _lang.IsRtl ? Gad7Ar : Gad7;
        }
        else
        {
            Test = "phq9";
            Questions = _lang.IsRtl ? Phq9Ar : Phq9;
        }
    }
}