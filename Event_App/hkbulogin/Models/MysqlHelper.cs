using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace hkbulogin.Controllers
{
    internal class MysqlHelper
    {
        private static String connStr_local = System.Configuration.ConfigurationManager.AppSettings["Conntction"];
        

        internal object GetDetail(string id, string password)
        {
            string sql = string.Format("select * from login where student_id='{0}' and password='{1}'", id,password);

            //string sql = "select * from login";
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr_local);
            try
            {
                conn.Open();
                // 创建一个适配器
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                // 创建DataSet，用于存储数据.
                testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
            }
            // 关闭数据库连接.
            catch (Exception e)
            {
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
                Console.WriteLine(e.Message);
                return -2;
                //Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null && testDataSet.Tables["result_data"].Rows.Count>0)
            {

                return 1;

            }
            else
            {
                return -1;
            }

        }

        internal object SignUp(string id, string password)
        {
            if (SignName(id) == false)
            {
                return "the name had been signed";
            }
            else
            {
                string sql = string.Format("insert into login set student_id='{0}',password='{1}'", id, password);
                string error = null;
                MySqlConnection conn = new MySqlConnection(connStr_local);
                try
                {
                    conn = new MySqlConnection(connStr_local);
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    // 创建DataSet，用于存储数据.
                    DataSet testDataSet = new DataSet();
                    // 执行查询，并将数据导入DataSet.
                    adapter.Fill(testDataSet, "result_data");
                    conn.Close();
                }
                catch (Exception e)
                {
                    conn.Close();
                    error = e.Message;
                    Console.WriteLine("insert station error------>{0}", error);
                    return error;
                }
                return "1";
            }
        }

        private bool SignName(string id)
        {
            string sql = string.Format("select * from login where student_id='{0}'", id);
            DataSet testDataSet = null;
            MySqlConnection conn = new MySqlConnection(connStr_local);
            try
            {
                conn.Open();
                // 创建一个适配器
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                // 创建DataSet，用于存储数据.
                testDataSet = new DataSet();
                // 执行查询，并将数据导入DataSet.
                adapter.Fill(testDataSet, "result_data");
            }
            // 关闭数据库连接.
            catch (Exception e)
            {
                //log4net.ILog log = log4net.LogManager.GetLogger("MyLogger");
                //log.Debug(e.Message);
                Console.WriteLine(e.Message);
                //Console.ReadLine();

            }
            finally
            {
                conn.Close();
            }
            if (testDataSet != null && testDataSet.Tables["result_data"] != null && testDataSet.Tables["result_data"].Rows != null && testDataSet.Tables["result_data"].Rows.Count>0)
            {

                return false;

            }
            else
            {
                return true;
            }

        }

    }
}