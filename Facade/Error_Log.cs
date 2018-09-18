namespace Facade
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Error_Log
    {
        public static void Error_LogSet(Exception ex, bool whichapp, int uid)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ErrorLogSet", connection);
                command.Parameters.AddWithValue("@msg", (ex.Message == null) ? "" : ex.Message);
                command.Parameters.AddWithValue("@src", (ex.Source == null) ? "" : ex.Source);
                command.Parameters.AddWithValue("@stack", (ex.StackTrace == null) ? "" : ex.StackTrace);
                command.Parameters.AddWithValue("@helplnk", (ex.HelpLink == null) ? "" : ex.HelpLink);
                command.Parameters.AddWithValue("@target", (ex.TargetSite == null) ? "" : ex.TargetSite.ToString());
                command.Parameters.AddWithValue("@webapperr", whichapp);
                command.Parameters.AddWithValue("@uid", uid);
                command.CommandType = CommandType.StoredProcedure;
                int num = command.ExecuteNonQuery();
                connection.Close();
                command.Dispose();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static DataTable ErrorWin_LogGet()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_ErrorLogGetAdmin", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                new SqlDataAdapter(selectCommand).Fill(dataTable);
            }
            catch
            {
                dataTable = null;
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public static string ResourceLogGetLatest()
        {
            string str2;
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ResourceLogGetLatest", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                string str = "";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    str = reader.GetString(2) + reader.GetString(1) + reader.GetString(0);
                }
                str2 = str;
            }
            catch
            {
                str2 = string.Empty;
            }
            finally
            {
                connection.Close();
            }
            return str2;
        }

        public static DataTable ResourceWin_LogGet()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_ResourceLogGetAdmin", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                new SqlDataAdapter(selectCommand).Fill(dataTable);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }
    }
}
