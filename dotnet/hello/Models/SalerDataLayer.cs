using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace BootstrapAdmin.Models
{
    public class SalerDataLayer
    {
        string connectionString = "Data Source=(local);Initial Catalog=Saler;"
            + "Integrated Security=true";

        public IEnumerable<Saler> GetSalers()
        {
            List<Saler> lstsaler = new List<Saler>();

            // 使用占位符查询语句
            string queryString = "SELECT salerid,nickname,real_name,tx_cash,time_reg,time_login FROM dbo.t_saler "
                + "ORDER BY time_login DESC";

            // 使用using块创建并打开数据库连接，确保资源释放
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 创建命令和参数对象
                SqlCommand command = new SqlCommand(queryString, connection);

                // 打开连接
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                            reader["salerid"], reader["real_name"], reader["tx_cash"], reader["time_reg"], reader["time_login"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return lstsaler;
        }
    }
}
