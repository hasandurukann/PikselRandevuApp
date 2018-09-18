namespace Facade
{
    using Entity;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Project_resource
    {
        public static DataTable Project_Resource(project_resource mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("PROJECT_ID_RESOURCE", connection);
                selectCommand.Parameters.AddWithValue("@PID", mdl._pid);
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

        public static int Project_Resource_Ekle(project_resource mdl)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PROJECT_RESOURCE_INSERT", connection);
                command.Parameters.AddWithValue("@RID", mdl._rid);
                command.Parameters.AddWithValue("@PID", mdl._pid);
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

        public static DataTable Project_Resource_Listele(project_resource mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("PROJECT_ID_RESOURCE_LIST", connection);
                selectCommand.Parameters.AddWithValue("@PID", mdl._pid);
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
