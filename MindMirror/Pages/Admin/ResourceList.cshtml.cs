using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MindMirror.Data;
using MindMirror.Models;

namespace MindMirror.Pages.Admin;

public class ResourceListModel : PageModel
{
    private readonly AppDbContext _db;
    public ResourceListModel(AppDbContext db) { _db = db; }

    public List<Resource> Items { get; set; } = new();

    public async Task OnGetAsync()
    {
        Items = await _db.Resources.OrderBy(r => r.Type).ThenBy(r => r.Name).ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var item = await _db.Resources.FindAsync(id);
        if (item != null)
        {
            _db.Resources.Remove(item);
            await _db.SaveChangesAsync();
        }
        return RedirectToPage();
    }
}