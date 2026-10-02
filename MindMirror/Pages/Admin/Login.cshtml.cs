using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MindMirror.Pages.Admin;

public class LoginModel : PageModel
{
    private readonly IConfiguration _config;

    public LoginModel(IConfiguration config)
    {
        _config = config;
    }

    [BindProperty, Required]
    public string Username { get; set; } = "";

    [BindProperty, Required, DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var adminUser = _config["Admin:Username"];
        var adminPass = _config["Admin:Password"];

        if (string.IsNullOrEmpty(adminUser) || string.IsNullOrEmpty(adminPass))
        {
            ModelState.AddModelError("", "Admin account is not configured.");
            return Page();
        }

        var valid = SafeEquals(Username, adminUser) & SafeEquals(Password, adminPass);
        if (!valid)
        {
            await Task.Delay(700); // slows down guessing
            ModelState.AddModelError("", "Invalid username or password.");
            return Page();
        }

        var identity = new ClaimsIdentity(
            new[] { new Claim(ClaimTypes.Name, adminUser), new Claim(ClaimTypes.Role, "Admin") },
            CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));

        if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
            return LocalRedirect(ReturnUrl);

        return RedirectToPage("/Admin/Index");
    }

    private static bool SafeEquals(string a, string b)
    {
        var ha = SHA256.HashData(Encoding.UTF8.GetBytes(a));
        var hb = SHA256.HashData(Encoding.UTF8.GetBytes(b));
        return CryptographicOperations.FixedTimeEquals(ha, hb);
    }
}