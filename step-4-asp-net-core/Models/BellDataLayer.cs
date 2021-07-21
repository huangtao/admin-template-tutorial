using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace BootstrapAdmin.Models
{
    public class BellDataLayer
    {
        string connectionString = "Data Source=(local);Initial Catalog=bell;"
            + "Integrated Security=true";

        public IEnumerable<FkPay> GetFkPays()
        {
            List<FkPay> lstpay = new List<FkPay>();

            // 使用占位符查询语句
            string sql = "SELECT TOP 100 TradeNo,UserId,PayPrice,LogDate FROM dbo.log_pay "
                + "ORDER BY LogDate DESC";

            // 使用using块创建并打开数据库连接，确保资源释放
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // 创建命令和参数对象
                SqlCommand cmd = new SqlCommand(sql, conn);

                // 打开连接
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FkPay pay = new FkPay();
                        pay.TradeNo = reader["TradeNo"].ToString();
                        pay.UserId = reader["UserId"].ToString();
                        pay.PayPrice = Convert.ToInt32(reader["PayPrice"]);
                        pay.CreateDate = Convert.ToDateTime(reader["LogDate"]);
                        lstpay.Add(pay);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return lstpay;
        }

        public IEnumerable<FkDayPay> GetFkDayPays(int day)
        {
            List<FkDayPay> lstpay = new List<FkDayPay>();

            string sql = "SELECT TOP @day CONVERT(varchar(100), logdate, 23) as rq, SUM(Payprice) as sr from dbo.log_pay "
                + "group by CONVERT(varchar(100), logdate, 23) "
                + "order by CONVERT(varchar(100), logdate, 23) desc";

            // 使用using块创建并打开数据库连接，确保资源释放
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // 创建命令和参数对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@day", System.Data.SqlDbType.Int);
                cmd.Parameters["@day"].Value = day;

                // 打开连接
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FkDayPay pay = new FkDayPay();
                        pay.SumPrice = Convert.ToInt32(reader["sr"]);
                        pay.CreateDate = Convert.ToDateTime(reader["rq"]);
                        lstpay.Add(pay);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return lstpay;
        }

        public IEnumerable<Table> GetTodayTable()
        {
            List<Table> lsttable = new List<Table>();

            string sql = "select tableid,creatorid,jsondata,createdate,clubid from dbo.fk_table "
                //+ "where DATEDIFF(DAY,CreateDate,GETDATE())=0 "
                + "order by createdate desc";

            // 使用using块创建并打开数据库连接，确保资源释放
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // 创建命令和参数对象
                SqlCommand cmd = new SqlCommand(sql, conn);

                // 打开连接
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Table table = new Table();
                        table.Id = reader["tableid"].ToString();
                        table.CreateUserId = reader["creatorid"].ToString();
                        table.JsonData = reader["jsondata"].ToString();
                        table.CreateDate = Convert.ToDateTime(reader["createdate"]);
                        table.ClubId = Convert.ToInt32(reader["clubid"].ToString());
                        lsttable.Add(table);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return lsttable;
        }
    }
}
