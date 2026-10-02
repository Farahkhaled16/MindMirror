using MindMirror.Models;

namespace MindMirror.Data;

public static class SeedResources
{
    // Adds anything missing (matched by name). Fills Arabic only where it is empty.
    public static void Run(AppDbContext db)
    {
        foreach (var r in All)
        {
            var existing = db.Resources.FirstOrDefault(x => x.Name == r.Name);
            if (existing == null)
            {
                db.Resources.Add(r);
            }
            else
            {
                existing.NameAr ??= r.NameAr;
                existing.AddressAr ??= r.AddressAr;
                existing.DescriptionAr ??= r.DescriptionAr;
            }
        }
        db.SaveChanges();
    }

    private const string HospDesc = "Government mental health hospital under the General Secretariat of Mental Health and Addiction Treatment.";
    private const string HospDescAr = "مستشفى حكومي للصحة النفسية تابع للأمانة العامة للصحة النفسية وعلاج الإدمان.";

    private static Resource Hospital(string name, string nameAr, string gov, string address, string addressAr, string? phone) => new()
    {
        Name = name,
        NameAr = nameAr,
        Type = "Hospital",
        City = gov,
        Address = address,
        AddressAr = addressAr,
        Phone = phone,
        IsFree = true,
        Description = HospDesc,
        DescriptionAr = HospDescAr
    };

    private static Resource Hotline(string name, string nameAr, string phone, string desc, string descAr) => new()
    {
        Name = name,
        NameAr = nameAr,
        Type = "Hotline",
        Phone = phone,
        Description = desc,
        DescriptionAr = descAr,
        Is24Hours = true
    };

    private static readonly List<Resource> All = new()
    {
        // Hotlines
        Hotline("Mental Health Hotline (General Secretariat of Mental Health)", "الخط الساخن للصحة النفسية (الأمانة العامة للصحة النفسية)", "16328",
            "National psychological support line run by the Ministry of Health and Population.",
            "خط وطني للدعم النفسي تديره وزارة الصحة والسكان."),
        Hotline("Addiction Treatment Hotline", "الخط الساخن لعلاج الإدمان", "16023",
            "Confidential help and referral for addiction, run by the Fund for Drug Control and Treatment of Addiction.",
            "مساعدة وإحالة سرّية لعلاج الإدمان، يديرها صندوق مكافحة وعلاج الإدمان والتعاطي."),
        Hotline("Ambulance", "الإسعاف", "123", "Emergency medical services.", "خدمات الطوارئ الطبية."),
        Hotline("Police", "الشرطة", "122", "Police emergency line.", "خط الطوارئ للشرطة."),
        Hotline("Child Helpline", "خط نجدة الطفل", "16000",
            "Support line for children and concerns about child safety.",
            "خط دعم للأطفال وللإبلاغ عن مخاوف تتعلق بسلامتهم."),

        // Cairo
        Hospital("Abbasia Mental Health Hospital", "مستشفى العباسية للصحة النفسية", "Cairo",
            "1 Salah Salem St., next to the exhibition grounds, Nasr City",
            "1 شارع صلاح سالم، بجوار أرض المعارض، مدينة نصر", null),
        Hospital("Heliopolis (Airport) Mental Health Hospital", "مستشفى مصر الجديدة (المطار) للصحة النفسية", "Cairo",
            "Airport Road, next to the EgyptAir administrative complex",
            "طريق المطار، بجوار المجمع الإداري لمصر للطيران", "0224196276"),
        Hospital("Helwan (Behman) Mental Health Hospital", "مستشفى حلوان (بهمن) للصحة النفسية", "Cairo",
            "Mansour St. extension, between El-Azbatein, Helwan",
            "امتداد شارع منصور، بين العزبتين، حلوان", "0225547368"),

        // Qalyubia
        Hospital("Khanka Mental Health Hospital", "مستشفى الخانكة للصحة النفسية", "Qalyubia",
            "Khanka city", "مدينة الخانكة", null),
        Hospital("Benha Mental Health Hospital", "مستشفى بنها للصحة النفسية", "Qalyubia",
            "Faculty of Science St., behind Benha Chest Hospital",
            "شارع كلية العلوم، خلف مستشفى صدر بنها", "0133232506"),

        // Delta
        Hospital("El-Azazi Mental Health Hospital", "مستشفى العزازي للصحة النفسية", "Sharqia",
            "Midway between Kafr El-Azazi and El-Qurein, Abu Hammad",
            "منتصف الطريق بين قرية كفر العزازي ومدينة القرين، أبو حماد", "0553443777"),
        Hospital("Shebin El-Kom Mental Health Hospital", "مستشفى شبين الكوم للصحة النفسية", "Monufia",
            "Hospitals complex, Mit Khalaf village",
            "مجمع المستشفيات، قرية ميت خلف", "0482170182"),
        Hospital("Demira Mental Health Hospital", "مستشفى الدميرة للصحة النفسية", "Dakahlia",
            "Demira village, El-Saraya, Talkha", "قرية الدميرة، السرايا، مركز طلخا", null),
        Hospital("Tanta Mental Health Hospital", "مستشفى طنطا للصحة النفسية", "Gharbia",
            "Abdel Hay Mashhour St., off El-Geish St., next to Tanta University Hospital",
            "شارع عبد الحي مشهور، متفرع من شارع الجيش، بجوار مستشفى طنطا الجامعي", "0403405651"),
        Hospital("Shubra Qass Mental Health Hospital", "مستشفى شبرا قاص للصحة النفسية", "Gharbia",
            "Shubra Qass village, El-Santa", "قرية شبرا قاص، مدينة السنطة", "0405305739"),

        // Alexandria and Canal
        Hospital("Maamoura Mental Health Hospital", "مستشفى المعمورة للصحة النفسية", "Alexandria",
            "El-Nabawi El-Mohandes St., El-Mallaha, El-Montaza",
            "شارع النبوي المهندس، الملاحة، المنتزه", "033256823"),
        Hospital("Abbas Helmy Mental Health Center", "مركز عباس حلمي للصحة النفسية", "Alexandria",
            "18 Alexandria-Matrouh Road, next to El-Aila Towers, El-Bitash, El-Agamy",
            "18 طريق إسكندرية مطروح، بجوار أبراج العائلة، البيطاش، العجمي", "033019340"),
        Hospital("Port Said Mental Health Hospital", "مستشفى بورسعيد للصحة النفسية", "Port Said",
            "23 December St. extension, opposite Marwa housing, El-Zohour district",
            "امتداد شارع 23 ديسمبر، أمام مساكن المروة، حي الزهور", "0663670454"),

        // Upper Egypt
        Hospital("Beni Suef Mental Health Hospital", "مستشفى بني سويف للصحة النفسية", "Beni Suef",
            "Nile Corniche, behind Beni Suef General Hospital",
            "كورنيش النيل، خلف مستشفى بني سويف العام", "0822352323"),
        Hospital("Minya Mental Health Hospital", "مستشفى المنيا للصحة النفسية", "Minya",
            "Behind New Minya City Authority", "خلف جهاز مدينة المنيا الجديدة", "0862294071"),
        Hospital("Assiut Mental Health Hospital", "مستشفى أسيوط للصحة النفسية", "Assiut",
            "4 El-Malek Faisal St., next to the Health Directorate and Chest Hospital",
            "4 شارع الملك فيصل، بجوار مديرية الشئون الصحية ومستشفى الصدر", "0882148164"),
        Hospital("Sohag Mental Health Hospital", "مستشفى سوهاج للصحة النفسية", "Sohag",
            "El-Tahrir St., next to the Fever Hospital",
            "شارع التحرير، بجوار مستشفى الحميات", "0932584365"),
        Hospital("Aswan Mental Health Hospital", "مستشفى أسوان للصحة النفسية", "Aswan",
            "High Dam East, next to the Quarantine",
            "السد العالي شرق، بجوار الحجر الصحي", "0973480652"),
    };
}