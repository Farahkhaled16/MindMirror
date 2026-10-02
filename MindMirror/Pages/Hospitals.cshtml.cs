using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MindMirror.Data;
using MindMirror.Models;

namespace MindMirror.Pages;

public class HospitalsModel : PageModel
{
    private readonly AppDbContext _db;
    public HospitalsModel(AppDbContext db) { _db = db; }

    [BindProperty(SupportsGet = true)] public string? Q { get; set; }
    [BindProperty(SupportsGet = true)] public string? City { get; set; }

    public List<Resource> Hotlines { get; set; } = new();
    public List<Resource> Hospitals { get; set; } = new();
    public List<string> Cities { get; set; } = new();

    public async Task OnGetAsync()
    {
        Hotlines = await _db.Resources
            .Where(r => r.Type == "Hotline")
            .OrderBy(r => r.Name)
            .ToListAsync();

        Cities = await _db.Resources
            .Where(r => r.Type == "Hospital" && r.City != null && r.City != "")
            .Select(r => r.City!)
            .Distinct()
            .OrderBy(c => c)
            .ToListAsync();

        var query = _db.Resources.Where(r => r.Type == "Hospital");

        if (!string.IsNullOrWhiteSpace(City))
            query = query.Where(r => r.City == City);

        if (!string.IsNullOrWhiteSpace(Q))
        {
            var term = $"%{Q.Trim()}%";
            query = query.Where(r =>
                EF.Functions.Like(r.Name, term) ||
                (r.NameAr != null && EF.Functions.Like(r.NameAr, term)) ||
                (r.Address != null && EF.Functions.Like(r.Address, term)) ||
                (r.AddressAr != null && EF.Functions.Like(r.AddressAr, term)));
        }

        Hospitals = await query.OrderBy(r => r.City).ThenBy(r => r.Name).ToListAsync();
    }
}