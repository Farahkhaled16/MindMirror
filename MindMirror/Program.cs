using System.Text;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using MindMirror.Data;
using MindMirror.Models;
using MindMirror.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Admin");
    options.Conventions.AllowAnonymousToPage("/Admin/Login");
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<Lang>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=mindmirror.db"));

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/Login";
        options.AccessDeniedPath = "/Admin/Login";
        options.Cookie.Name = "MindMirror.Admin";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.SecurePolicy = builder.Environment.IsDevelopment()
            ? CookieSecurePolicy.SameAsRequest
            : CookieSecurePolicy.Always;
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();
builder.Services.AddHealthChecks();

// Needed when the site runs behind a hosting proxy (Azure, Railway, ...)
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Limits login attempts (per IP) to slow down password guessing
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.AddPolicy("login", httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 10,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 0
            }));
});

var app = builder.Build();

app.UseForwardedHeaders();

// Apply migrations and add starter data if empty
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    SeedArticles.Run(db);
    SeedResources.Run(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/{0}");
app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    var headers = context.Response.Headers;
    headers["X-Content-Type-Options"] = "nosniff";
    headers["X-Frame-Options"] = "DENY";
    headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
    headers["Permissions-Policy"] = "camera=(), microphone=(), geolocation=()";
    headers["Content-Security-Policy"] =
        "default-src 'self'; " +
        "style-src 'self' https://fonts.googleapis.com; " +
        "font-src https://fonts.gstatic.com; " +
        "img-src 'self' data:; " +
        "script-src 'self'; " +
        "frame-ancestors 'none'";
    await next();
});

app.UseStaticFiles();
app.UseRouting();
app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();
app.MapHealthChecks("/health");
app.MapRazorPages();

app.MapGet("/set-language", (HttpContext ctx, string? lang, string? returnUrl) =>
{
    if (lang != null && Lang.Supported.Contains(lang))
    {
        ctx.Response.Cookies.Append(Lang.CookieName, lang, new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddYears(1),
            HttpOnly = true,
            IsEssential = true,
            SameSite = SameSiteMode.Lax,
            Secure = ctx.Request.IsHttps
        });
    }

    // Only allow redirects inside our own site
    var target = "/";
    if (!string.IsNullOrEmpty(returnUrl) && returnUrl.StartsWith('/')
        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
    {
        target = returnUrl;
    }
    return Results.LocalRedirect(target);
});

app.MapGet("/robots.txt", (HttpContext ctx) =>
{
    var baseUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}";
    return Results.Text($"User-agent: *\nDisallow: /Admin\nDisallow: /set-language\nSitemap: {baseUrl}/sitemap.xml\n", "text/plain");
});

app.MapGet("/sitemap.xml", async (HttpContext ctx, AppDbContext db) =>
{
    var baseUrl = $"{ctx.Request.Scheme}://{ctx.Request.Host}";
    var urls = new List<string>
    {
        "/", "/Articles", "/Conditions", "/SelfCheck", "/Tools",
        "/Resources", "/Hospitals", "/Help", "/Privacy"
    };

    urls.AddRange(ConditionData.All.Select(c => $"/conditions/{c.Slug}"));
    urls.AddRange((await db.Articles.Select(a => a.Id).ToListAsync()).Select(id => $"/ArticleDetails/{id}"));

    var sb = new StringBuilder();
    sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
    sb.Append("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");
    foreach (var u in urls)
        sb.Append($"<url><loc>{baseUrl}{u}</loc></url>");
    sb.Append("</urlset>");

    return Results.Content(sb.ToString(), "application/xml");
});

app.Run();