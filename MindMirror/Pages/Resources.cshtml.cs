using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MindMirror.Data;
using MindMirror.Models;

namespace MindMirror.Pages;

public class ResourcesModel : PageModel
{
    private readonly AppDbContext _db;
    public ResourcesModel(AppDbContext db) { _db = db; }

    [BindProperty(SupportsGet = true)] public string? Type { get; set; }
    [BindProperty(SupportsGet = true)] public string? City { get; set; }

    public List<Resource> Items { get; set; } = new();
    public List<string> Cities { get; set; } = new();

    public async Task OnGetAsync()
    {
        Cities = await _db.Resources
            .Where(r => r.City != null && r.City != "")
            .Select(r => r.City!)
            .Distinct()
            .OrderBy(c => c)
            .ToListAsync();

        var query = _db.Resources.AsQueryable();
        if (!string.IsNullOrWhiteSpace(Type)) query = query.Where(r => r.Type == Type);
        if (!string.IsNullOrWhiteSpace(City)) query = query.Where(r => r.City == City);

        Items = await query.OrderBy(r => r.Type).ThenBy(r => r.Name).ToListAsync();
    }
}