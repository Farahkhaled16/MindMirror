using System.ComponentModel.DataAnnotations;

namespace MindMirror.Models;

public static class ArticleCategories
{
    public static readonly string[] All =
        { "Anxiety", "Depression", "Sleep", "Stress", "Self-care", "General" };
}

public class Article
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    public string Title { get; set; } = "";

    [Required, StringLength(300)]
    public string Summary { get; set; } = "";

    [Required]
    public string Content { get; set; } = "";

    // Arabic versions (optional)
    [StringLength(150)]
    public string? TitleAr { get; set; }

    [StringLength(300)]
    public string? SummaryAr { get; set; }

    public string? ContentAr { get; set; }

    [Required, StringLength(40)]
    public string Category { get; set; } = "General";

    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

    // Pick the Arabic text if it exists, otherwise fall back to English
    public string TitleIn(bool ar) => ar && !string.IsNullOrWhiteSpace(TitleAr) ? TitleAr! : Title;
    public string SummaryIn(bool ar) => ar && !string.IsNullOrWhiteSpace(SummaryAr) ? SummaryAr! : Summary;
    public string ContentIn(bool ar) => ar && !string.IsNullOrWhiteSpace(ContentAr) ? ContentAr! : Content;

    public int ReadingMinutesIn(bool ar) =>
        Math.Max(1, ContentIn(ar).Split(' ', StringSplitOptions.RemoveEmptyEntries).Length / 200);
}