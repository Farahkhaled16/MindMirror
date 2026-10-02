using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MindMirror.Data;
using MindMirror.Models;

namespace MindMirror.Pages;

public class ArticlesModel : PageModel
{
    private const int PageSize = 6;
    private readonly AppDbContext _db;

    public ArticlesModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty(SupportsGet = true)] public string? Q { get; set; }
    [BindProperty(SupportsGet = true)] public string? Category { get; set; }
    [BindProperty(SupportsGet = true)] public int P { get; set; } = 1;

    public List<Article> Articles { get; set; } = new();
    public int TotalPages { get; set; }

    public async Task OnGetAsync()
    {
        var query = _db.Articles.AsQueryable();

        if (!string.IsNullOrWhiteSpace(Q))
        {
            var term = $"%{Q.Trim()}%";
            query = query.Where(a =>
                EF.Functions.Like(a.Title, term) ||
                EF.Functions.Like(a.Summary, term) ||
                EF.Functions.Like(a.Content, term) ||
                (a.TitleAr != null && EF.Functions.Like(a.TitleAr, term)) ||
                (a.SummaryAr != null && EF.Functions.Like(a.SummaryAr, term)) ||
                (a.ContentAr != null && EF.Functions.Like(a.ContentAr, term)));
        }

        if (!string.IsNullOrWhiteSpace(Category))
        {
            query = query.Where(a => a.Category == Category);
        }

        var total = await query.CountAsync();
        TotalPages = Math.Max(1, (int)Math.Ceiling(total / (double)PageSize));
        P = Math.Clamp(P, 1, TotalPages);

        Articles = await query
            .OrderByDescending(a => a.PublishedAt)
            .Skip((P - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
    }
}