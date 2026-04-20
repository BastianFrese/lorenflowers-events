using System.Diagnostics;
using LorenFlowers.Events.Models;
using Microsoft.AspNetCore.Mvc;

namespace LorenFlowers.Events.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(EventCatalog.All);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
