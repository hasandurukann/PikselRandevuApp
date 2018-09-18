namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class Engineers
    {
        public static bool EngReservationCancel(engineers mdl, int resid)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_EngResDel", connection);
            command.Parameters.AddWithValue("@resid", resid);
            command.Parameters.AddWithValue("@uid", mdl._uid);
            command.CommandType = CommandType.StoredProcedure;
            num = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return (num > 0);
        }

        public static DataTable EngReservationList(engineers mdl, int durum)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_EngReservationList", connection);
                selectCommand.Parameters.AddWithValue("@uid", mdl._uid);
                selectCommand.Parameters.AddWithValue("@durum",durum);
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

        public static List<user> EngineerListDD()
        {
            List<user> list;
            try
            {
                list = new List<user>();
                list.Clear();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_EngineerListForDD", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                user item;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item = new user();
                    item._uid = int.Parse(reader["uid"].ToString());
                    item._fullname = reader["user_fullname"].ToString();
                    list.Add(item);
                }
                command.Dispose();
                connection.Close();
            }
            catch
            {
                return null;
            }
            return list;
        }
    }
}
