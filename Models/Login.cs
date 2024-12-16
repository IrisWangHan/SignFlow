using System.ComponentModel;
using System.ComponentModel.DataAnnotations;//Required

[Description("登入")]
public class LoginRequest
{
    [Required(ErrorMessage = "帳號是必填項")]
    public string 帳號 { get; set; }
    [Required(ErrorMessage = "密碼是必填項")]
    public string 密碼 { get; set; }
}