using System.Data;
using Microsoft.Data.SqlClient;//SqlParameter
public interface IUsersRepository
{
    DataTable ValidateUser(string account, string password);
}
public class UsersRepository : IUsersRepository
{
    private readonly IDatabaseRepository _dBRepository;
    public UsersRepository(IDatabaseRepository dBRepository)
    {
        _dBRepository = dBRepository;
    }

    public DataTable ValidateUser(string account, string password)
    {
        string sql = "  SELECT TOP (1) [name] FROM [users] where   [enable]=1  AND [account]=@account AND [password]=@password ";
        // 建立 SqlParameter 集合
        var param = new List<SqlParameter>
    {
        new SqlParameter("@account", SqlDbType.NVarChar, 50) { Value = account },
        new SqlParameter("@password", SqlDbType.NVarChar, 50) { Value = password }
    };
        return _dBRepository.SelectToDatatable(sql, param);
    }


}