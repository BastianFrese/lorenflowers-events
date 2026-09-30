using System.Security.Claims;
using System.Security.Cryptography;
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
        var adminPasswordHash = _configuration["AdminSettings:PasswordHash"] ?? "";

        if (string.IsNullOrEmpty(adminPasswordHash))
        {
            ModelState.AddModelError("", "Admin-Passwort ist nicht konfiguriert.");
            return View();
        }

        if (string.Equals(email, adminEmail, StringComparison.OrdinalIgnoreCase) && VerifyPassword(password, adminPasswordHash))
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

    /// <summary>
    /// Prüft das eingegebene Passwort gegen den konfigurierten PBKDF2-Hash
    /// (Format: iterationen.saltBase64.hashBase64). Der Vergleich läuft über
    /// <see cref="CryptographicOperations.FixedTimeEquals"/> und ist damit
    /// unabhängig von der Laufzeit.
    /// </summary>
    private static bool VerifyPassword(string password, string storedHash)
    {
        var parts = storedHash.Split('.', 3);
        if (parts.Length != 3 || !int.TryParse(parts[0], out var iterations) || iterations < 1000)
        {
            return false;
        }

        try
        {
            var salt = Convert.FromBase64String(parts[1]);
            var expected = Convert.FromBase64String(parts[2]);
            var actual = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expected.Length);
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
