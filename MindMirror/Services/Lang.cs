using System.Globalization;

namespace MindMirror.Services;

public class Lang
{
    public const string CookieName = "mm_lang";
    public static readonly string[] Supported = { "en", "ar" };

    private static readonly Dictionary<string, (string En, string Ar)>[] Sources =
        { Strings.Map, StringsPages.Map, StringsTools.Map };

    public string Code { get; }
    public bool IsRtl => Code == "ar";
    public string Dir => IsRtl ? "rtl" : "ltr";
    public CultureInfo Culture => CultureInfo.GetCultureInfo(IsRtl ? "ar-EG" : "en-US");

    // Arrows that point the right way in each direction
    public string Next => IsRtl ? "←" : "→";
    public string Back => IsRtl ? "→" : "←";

    public Lang(IHttpContextAccessor accessor)
    {
        var ctx = accessor.HttpContext;
        var fromCookie = ctx?.Request.Cookies[CookieName];

        if (fromCookie != null && Supported.Contains(fromCookie))
        {
            Code = fromCookie;
        }
        else
        {
            var header = ctx?.Request.Headers["Accept-Language"].ToString() ?? "";
            Code = header.TrimStart().StartsWith("ar", StringComparison.OrdinalIgnoreCase) ? "ar" : "en";
        }
    }

    public string T(string key)
    {
        foreach (var s in Sources)
            if (s.TryGetValue(key, out var v))
                return IsRtl ? v.Ar : v.En;
        return key; // missing key shows the key itself, so it's easy to spot
    }

    // Translate if the key exists, otherwise return the fallback (used for admin-added data)
    public string Tx(string key, string fallback)
    {
        foreach (var s in Sources)
            if (s.TryGetValue(key, out var v))
                return IsRtl ? v.Ar : v.En;
        return fallback;
    }
}