namespace Facade
{
    using Entity;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Upload
    {
        public static void File_Upload(upload mdl)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("FILE_UPLOAD", connection);
                command.Parameters.AddWithValue("@UID", mdl._uid);
                command.Parameters.AddWithValue("@PID", mdl._pid);
                command.Parameters.AddWithValue("@FILE_NAME", mdl._file_name);
                command.Parameters.AddWithValue("@FILE_DATE", mdl._file_date);
                command.Parameters.AddWithValue("@FILE_PATH", mdl._file_path);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool ResourceManuel_Upload(int rid, string filen)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ResourceManuelSET", connection);
                command.Parameters.AddWithValue("@rid", rid);
                command.Parameters.AddWithValue("@filename", filen);
                command.CommandType = CommandType.StoredProcedure;
                flag = command.ExecuteNonQuery() > 0;
            }
            catch
            {
                flag = false;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }
    }
}
