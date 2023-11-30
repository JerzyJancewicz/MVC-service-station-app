using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.MVC.Models;

namespace ServiceStation.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult NoAccess()
    {
        return View();
    }

    public IActionResult About() 
    {
        var model = new About()
        {
            Title = "Cos",
            Description = "COS2"
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // Activity.Current?.Id means that can be nullable
        // Activity.Current!.Id null-forgiving operator. Means that I'am shoure that this value is not returning null
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
