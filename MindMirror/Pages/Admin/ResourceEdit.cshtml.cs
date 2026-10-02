using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MindMirror.Data;
using MindMirror.Models;

namespace MindMirror.Pages.Admin;

public class ResourceEditModel : PageModel
{
    private readonly AppDbContext _db;
    public ResourceEditModel(AppDbContext db) { _db = db; }

    [BindProperty]
    public Resource Item { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return Page();
        var existing = await _db.Resources.FindAsync(id);
        if (existing == null) return NotFound();
        Item = existing;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        if (Item.Id == 0)
        {
            _db.Resources.Add(Item);
        }
        else
        {
            var existing = await _db.Resources.FindAsync(Item.Id);
            if (existing == null) return NotFound();
            _db.Entry(existing).CurrentValues.SetValues(Item);
        }

        await _db.SaveChangesAsync();
        return RedirectToPage("ResourceList");
    }
}