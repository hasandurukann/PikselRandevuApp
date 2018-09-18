namespace Facade
{
    using Entity;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class External_reservation
    {
        public static int ExternalRequestSET(external_reservation mdl)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ExternalRequestSet", connection);
                command.Parameters.AddWithValue("@UID", mdl._uid);
                command.Parameters.AddWithValue("@PID", mdl._pid);
                command.Parameters.AddWithValue("@RID", mdl._rid);
                command.Parameters.AddWithValue("@ADDITIONAL_REQUEST", mdl._additional_request);
                command.Parameters.AddWithValue("@PROVIDE", mdl._provide);
                command.Parameters.AddWithValue("@SAMPLES", mdl._samples);
                command.Parameters.AddWithValue("@BIOLOGICAL", mdl._biological);
                command.Parameters.AddWithValue("@CHEMICAL", mdl._chemical);
                command.Parameters.AddWithValue("@ENVIROMENT", mdl._enviroment);
                command.Parameters.AddWithValue("@DAMAGE", mdl._damage);
                command.Parameters.AddWithValue("@STATU", mdl._statu);
                command.Parameters.AddWithValue("@EXDATE", mdl.exdate);
                command.Parameters.AddWithValue("@WENG", mdl.W_eng);
                command.Parameters.AddWithValue("@WCONS", mdl.W_cons);
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

        public static DataRow ExternalRequestGETOne(external_reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_ExternalRequestGetOne", connection);
                selectCommand.Parameters.AddWithValue("@ID", mdl._id);
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
            return dataTable.Rows[0];
        }

        public static DataTable ExternalRequestLIST(int status)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_ExternalRequestList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                   
                };
                selectCommand.Parameters.Clear();
                selectCommand.Parameters.AddWithValue("@status", status);
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

        public static DataTable ExternalRequestBasicLIST()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_ExternalRequestBasicList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
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
