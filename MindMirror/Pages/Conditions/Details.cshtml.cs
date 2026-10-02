using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MindMirror.Models;
using MindMirror.Services;

namespace MindMirror.Pages.Conditions;

public class DetailsModel : PageModel
{
    private readonly Lang _lang;
    public DetailsModel(Lang lang) { _lang = lang; }

    public Condition Item { get; set; } = null!;

    public IActionResult OnGet(string slug)
    {
        var item = ConditionDataAr.Find(slug, _lang.IsRtl);
        if (item == null) return NotFound();

        Item = item;
        return Page();
    }
}