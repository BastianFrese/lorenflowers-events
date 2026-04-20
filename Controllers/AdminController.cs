using LorenFlowers.Events.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LorenFlowers.Events.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        var allEvents = EventCatalog.All;

        ViewBag.Stats = new
        {
            TotalEvents = allEvents.Count,
            TotalPackages = allEvents.Sum(e => e.Packages.Count),
            TotalHighlights = allEvents.Sum(e => e.Highlights.Count),
            EventsWithPackages = allEvents.Count(e => e.Packages.Any())
        };

        ViewBag.Events = allEvents;

        return View();
    }
}
