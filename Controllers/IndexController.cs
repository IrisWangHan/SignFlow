using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignFlow.Models;

namespace SignFlow.Controllers;

public class IndexController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public IndexController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
