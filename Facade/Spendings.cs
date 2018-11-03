using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Facade
{
    public class Spendings
    {
        public static DataTable SpendingsGET(int type, int uid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_SpendingsGET", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                selectCommand.Parameters.AddWithValue("@uid", uid);
                selectCommand.Parameters.AddWithValue("@type", type);
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
        public static DataTable SpendingsAddedGET(int uid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand2 = new SqlCommand("SP_SpendingsAddedGET", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                selectCommand2.Parameters.Clear();
                selectCommand2.Parameters.AddWithValue("@uid", uid);
                new SqlDataAdapter(selectCommand2).Fill(dataTable);
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
        public static object SpendingsTotalBalanceGET(int uid,int type)
        {
            object snc;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_SpendingsTotalBalanceGET", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                selectCommand.Parameters.AddWithValue("@uid", uid);
                selectCommand.Parameters.AddWithValue("@type", type);
                snc = selectCommand.ExecuteScalar();
                return snc;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return snc;
        }
    }
}
