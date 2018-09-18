namespace Facade
{
    using Entity;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Superuser
    {
        public static int Superuser_Ekle(superuser mdl)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SUPERUSER_INSERT", connection);
                command.Parameters.AddWithValue("@UID", mdl._uid);
                command.Parameters.AddWithValue("@RID", mdl._rid);
                command.Parameters.AddWithValue("@EXPLANATION", mdl._explanation);
                command.Parameters.AddWithValue("@COP", mdl._cop);
                command.CommandType = CommandType.StoredProcedure;
                num = command.ExecuteNonQuery();
            }
            catch
            {
                num = -1;
            }
            finally
            {
                connection.Close();
            }
            return num;
        }

        public static DataTable Superuser_ID_Resource(superuser mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SUPERUSER_RESOURCE", connection);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
                selectCommand.CommandType = CommandType.StoredProcedure;
                new SqlDataAdapter(selectCommand).Fill(dataTable);
            }
            catch
            {
                dataTable.Rows.Clear();
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public static DataTable Superuser_Listele(superuser mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SUPERUSER_LIST", connection);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
                selectCommand.Parameters.AddWithValue("@COP", mdl._cop);
                selectCommand.CommandType = CommandType.StoredProcedure;
                new SqlDataAdapter(selectCommand).Fill(dataTable);
            }
            catch
            {
                dataTable.Rows.Clear();
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }
    }
}
