using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MindMirror.Data;
using MindMirror.Models;

namespace MindMirror.Pages.Admin;

public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db)
    {
        _db = db;
    }

    public List<Article> Articles { get; set; } = new();

    public async Task OnGetAsync()
    {
        Articles = await _db.Articles
            .OrderByDescending(a => a.PublishedAt)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var article = await _db.Articles.FindAsync(id);
        if (article != null)
        {
            _db.Articles.Remove(article);
            await _db.SaveChangesAsync();
        }
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostLogoutAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToPage("/Index");
    }
}