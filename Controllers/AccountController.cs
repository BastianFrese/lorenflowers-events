using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LorenFlowers.Events.Controllers;

public class AccountController : Controller
{
    private readonly IConfiguration _configuration;

    public AccountController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToAction("Index", "Admin");

        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string email, string password, bool rememberMe, string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;

        var adminEmail = _configuration["AdminSettings:Email"] ?? "loren@loren-flowers.de";
        var adminPassword = _configuration["AdminSettings:Password"] ?? "";

        if (string.IsNullOrEmpty(adminPassword))
        {
            ModelState.AddModelError("", "Admin-Passwort ist nicht konfiguriert.");
            return View();
        }

        if (string.Equals(email, adminEmail, StringComparison.OrdinalIgnoreCase) && password == adminPassword)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, "Loren"),
                new(ClaimTypes.Email, adminEmail),
                new(ClaimTypes.Role, "Admin")
            };

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("CookieAuth", principal, new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = rememberMe ? DateTimeOffset.UtcNow.AddDays(30) : null
            });

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Admin");
        }

        ModelState.AddModelError("", "Ungültige E-Mail oder Passwort.");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("CookieAuth");
        return RedirectToAction("Index", "Home");
    }
}
