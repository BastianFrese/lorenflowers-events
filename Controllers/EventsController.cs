using LorenFlowers.Events.Models;
using Microsoft.AspNetCore.Mvc;

namespace LorenFlowers.Events.Controllers;

public class EventsController : Controller
{
    public IActionResult Index()
    {
        return View(EventCatalog.All);
    }

    public IActionResult Detail(string slug)
    {
        var info = EventCatalog.Find(slug);
        if (info == null) return NotFound();
        return View(info);
    }

    public IActionResult Hochzeit() => RedirectToAction(nameof(Detail), new { slug = "hochzeit" });
    public IActionResult Trauerfeier() => RedirectToAction(nameof(Detail), new { slug = "trauerfeier" });
    public IActionResult Kommunion() => RedirectToAction(nameof(Detail), new { slug = "kommunion" });
    public IActionResult Konfirmation() => RedirectToAction(nameof(Detail), new { slug = "konfirmation" });
    public IActionResult Workshop() => RedirectToAction(nameof(Detail), new { slug = "workshop" });
    public IActionResult Maerkte() => RedirectToAction(nameof(Detail), new { slug = "maerkte" });
}
