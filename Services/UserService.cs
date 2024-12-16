using System.ComponentModel;
using System.Data;
public interface IUserService
{
    bool AuthenticateUser(string username, string password);
}
public class UserService : IUserService
{
    private readonly IUsersRepository _userRepository;

    public UserService(IUsersRepository userRepository)
    {
        _userRepository = userRepository;
    }


    [DescriptionAttribute("驗證用戶的登入邏輯")]
    public bool AuthenticateUser(string username, string password)
    {
        // 檢查使用者是否存在並且密碼是否正確
        bool isValid = false;
        DataTable dt = _userRepository.ValidateUser(username, password);
        if (dt.Rows.Count > 0)
        {
            isValid = true;
        }
        return isValid;
    }
}