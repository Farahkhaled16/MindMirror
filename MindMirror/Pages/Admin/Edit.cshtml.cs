using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MindMirror.Data;
using MindMirror.Models;

namespace MindMirror.Pages.Admin;

public class EditModel : PageModel
{
    private readonly AppDbContext _db;

    public EditModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public Article Article { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return Page();

        var article = await _db.Articles.FindAsync(id);
        if (article == null) return NotFound();

        Article = article;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        if (Article.Id == 0)
        {
            Article.PublishedAt = DateTime.UtcNow;
            _db.Articles.Add(Article);
        }
        else
        {
            var existing = await _db.Articles.FindAsync(Article.Id);
            if (existing == null) return NotFound();

            existing.Title = Article.Title;
            existing.Summary = Article.Summary;
            existing.Content = Article.Content;
            existing.TitleAr = Article.TitleAr;
            existing.SummaryAr = Article.SummaryAr;
            existing.ContentAr = Article.ContentAr;
            existing.Category = Article.Category;
        }

        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}