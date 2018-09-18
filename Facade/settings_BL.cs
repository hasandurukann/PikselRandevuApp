namespace Facade
{
    using Entity;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class settings_BL
    {
        public static settings UsagePerGet()
        {
            settings settings = null;
            settings settings2;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlDataReader reader = new SqlCommand("SP_ResNameListe", connection) { CommandType = CommandType.StoredProcedure }.ExecuteReader();
                if (reader.Read())
                {
                    settings = new settings
                    {
                        Id = reader.GetInt32(0),
                        Usageper = reader.GetInt32(1)
                    };
                }
                settings2 = settings;
            }
            catch (Exception)
            {
                settings2 = null;
            }
            finally
            {
                connection.Close();
            }
            return settings2;
        }

        public static bool UsagePerSet(int per)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_SettingsUsagePerSet", connection);
                command.Parameters.AddWithValue("@per", per);
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
