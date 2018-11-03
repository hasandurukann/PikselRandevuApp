namespace Facade
{
    using System;
    using System.Data.SqlClient;

    public class islem
    {
        public static string ConnectionString = "Data Source=185.95.2.202;Initial Catalog=unam_db;Persist Security Info=True;User ID=unamlog;Password=1q2w3e4r!!!";
        //public static string ConnectionString = "Data Source=139.179.64.9;Initial Catalog=unam_db;Persist Security Info=True;User ID=unamlog_yeni;Password=unm2210!!";
        //public static string ConnectionString = "Data Source=192.168.252.141;Initial Catalog=unam_db;Persist Security Info=True;User ID=unamlog_yeni;Password=unm2210!!";
        public static int yurut(SqlCommand cmd)
        {
            int num = -1;
            try
            {
                cmd.Connection.Open();
                num = cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return num;
        }
    }
}
