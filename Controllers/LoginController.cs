using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignFlow.Models;

namespace SignFlow.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public LoginController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    // 一個接受 POST 請求並處理帳號和密碼的動作方法。
    // 你可以使用 FromForm 或 FromBody 特性來獲取從前端發送的資料。因為你在前端是以 
    // application/x-www-form-urlencoded 這種方式發送資料，所以可以使用 FromForm。
    // [FromForm]: 告訴 MVC 從表單資料中提取 帳號 和 密碼。
    // 因為你在前端使用的是 application/x-www-form-urlencoded，所以 FromForm 是處理表單提交的正確方式。

    // 返回 JSON: 在這個範例中，當登入成功或失敗時，我們都返回 JSON 格式的響應。
    // 這樣，前端可以根據返回的結果進行相應的處理。
    // public IActionResult Login()
    // {
    //     return View();
    // }
    // 用來接收 POST 請求
    [HttpPost]
    // public IActionResult Login([FromForm] string 帳號, [FromForm] string 密碼)
    // {
    //     // 處理帳號和密碼
    //     // 比如可以檢查帳號和密碼是否正確
    //     if (string.IsNullOrEmpty(帳號) || string.IsNullOrEmpty(密碼))
    //     {
    //         return Json(new { success = false, message = "帳號或密碼不可為空" });
    //     }

    //     // 模擬一個成功的登入邏輯
    //     // 在實際情況下，你應該會查詢資料庫來驗證帳號和密碼
    //     if (帳號 == "test" && 密碼 == "password")
    //     {
    //         return Json(new { success = true, message = "登入成功" });
    //     }
    //     else
    //     {
    //         return Json(new { success = false, message = "帳號或密碼錯誤" });
    //     }
    // }
    [HttpPost]
    public IActionResult checkUser([FromBody] LoginRequest loginRequest)
    {
        LoginRequest request = new LoginRequest();
        if (string.IsNullOrEmpty(loginRequest.帳號) || string.IsNullOrEmpty(loginRequest.密碼))
        {
            return Json(new { success = false, message = "帳號或密碼不可為空" });
        }

        // 假設驗證成功
        return Json(new { success = true, message = "登入成功" });
    }

    // 用來接收 JSON 的 Model
    public class LoginRequest
    {
        [Required(ErrorMessage = "帳號是必填項")]
        public string 帳號 { get; set; }
        [Required(ErrorMessage = "密碼是必填項")]
        public string 密碼 { get; set; }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
