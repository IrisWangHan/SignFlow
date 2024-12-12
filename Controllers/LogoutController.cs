using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignFlow.Models;

namespace SignFlow.Controllers;

public class LogoutController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public LogoutController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // 在這裡處理登出邏輯
        // 例如清除 session 或 cookies

        // 重定向到 Login 頁面（假設 Login 頁面是 /Login/Index）
        return Redirect("/Login/Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
