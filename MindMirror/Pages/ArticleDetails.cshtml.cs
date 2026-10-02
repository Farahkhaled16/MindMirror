using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MindMirror.Data;
using MindMirror.Models;

namespace MindMirror.Pages;

public class ArticleDetailsModel : PageModel
{
    private readonly AppDbContext _db;

    public ArticleDetailsModel(AppDbContext db)
    {
        _db = db;
    }

    public Article Article { get; set; } = null!;
    public List<Article> Related { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var article = await _db.Articles.FindAsync(id);
        if (article == null) return NotFound();

        Article = article;
        Related = await _db.Articles
            .Where(a => a.Category == article.Category && a.Id != article.Id)
            .OrderByDescending(a => a.PublishedAt)
            .Take(3)
            .ToListAsync();

        return Page();
    }
}