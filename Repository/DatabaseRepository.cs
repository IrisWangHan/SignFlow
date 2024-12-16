using System.Data; //IDatabaseRepository DataTable
using Microsoft.Data.SqlClient; //SqlConnection SqlCommand
using System.Data.Common; //DbDataReader

public interface IDatabaseRepository
{
    DataTable SelectToDatatable(string sql, List<SqlParameter>param);
}



public class DatabaseRepository : IDatabaseRepository
{
    private readonly string _connectionString;

    public DatabaseRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DBContext");
    }


    public DataTable SelectToDatatable(string sql,  List<SqlParameter> param)
    {
        // 建立 DataTable 來儲存查詢結果
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(_connectionString))//初始化SQLConnection物件(連資料庫用)
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            conn.Open(); // 開啟來源連接
            foreach (var p in param)
            {
                cmd.Parameters.Add(p);
            }
            // 讀取資料
            using (DbDataReader dr = cmd.ExecuteReader())//執行並回傳DataReader
            {
                if (dr.HasRows)//檢查是否有資料列
                {
                    dt.Load(dr);
                }
            }
            return dt;
        }
    }


}