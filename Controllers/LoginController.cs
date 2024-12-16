using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignFlow.Models;//Description

namespace SignFlow.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;

    public LoginController(ILogger<HomeController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;

    }


    [Description("登入首頁")]
    // [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    [Description("驗證使用者")]
    [HttpPost]
    public IActionResult checkUser([FromBody] LoginRequest loginRequest)
    {
        bool success = false;

        // 判斷參數
        // 檢查模型是否有效
        if (!ModelState.IsValid)
        {
            //檢查所有應用於 LoginRequest 類別的驗證屬性，這樣當 帳號 或 密碼 欄位為 null 或空字符串時，模型驗證會自動失敗，並且不需要手動檢查它們。
            // 如果模型驗證失敗，回傳錯誤訊息
            return Json(new { success = false, message = "帳號或密碼不可為空" });
        }

        //取得驗證成功或失敗結果
        success = _userService.AuthenticateUser(loginRequest.帳號, loginRequest.密碼);
        if (success)
        {
            return Json(new { success = true, message = "登入成功", redirectUrl = Url.Action("Index", "Index") });
        }
        return Json(new { success = false, message = "登入失敗" });

    }



}
