namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class teamall
    {
        public static List<teams> TeamList()
        {
            List<teams> list;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                list = new List<teams>();
                connection.Open();
                SqlCommand command = new SqlCommand("SP_TeamsSELECT", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teams item = new teams
                    {
                        Tid = Convert.ToInt32(reader["tid"]),
                        Teamname = reader["name"].ToString(),
                    };
                    list.Add(item);
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
           
        }

        public static bool TeamSET(teams team)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("SP_TeamSET", connection);
                command.Parameters.AddWithValue("@tid", team.Tid);
                command.Parameters.AddWithValue("@name", team.Teamname);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool TeamDEL(teams team)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("SP_TeamDEL", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tid", team.Tid);
                connection.Open();
                return (command.ExecuteNonQuery() > 0);
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static DataTable TeamMemberList(int tid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_TeamMembersSELECT", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@tid", tid);
                new SqlDataAdapter(command).Fill(dataTable);
            }
            catch (Exception)
            {
                dataTable = null;
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public static bool TeamMemberDEL(teammembers teamm)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("SP_TeamMemberDEL", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", teamm.Id);
                connection.Open();
                bool sonuc = (command.ExecuteNonQuery() > 0);
                return sonuc;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static int TeamMemberSET(teammembers teamm)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("SP_TeamMemberSET", connection);
                command.Parameters.AddWithValue("@tid", teamm.Tid);
                command.Parameters.AddWithValue("@uid", teamm.Uid);
                command.Parameters.AddWithValue("@tleader", teamm.Tleader);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                int sonuc = int.Parse(command.ExecuteScalar().ToString());
                return sonuc;
            }
            catch
            {
                return -2;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool TeamLeaderSET(teammembers teamm)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("SP_TeamLeaderSET", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tid", teamm.Tid);
                command.Parameters.AddWithValue("@uid", teamm.Uid);
                connection.Open();
                int sonuc = command.ExecuteNonQuery();
                return sonuc>1?true:false;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool TeamResourceAtama(int tid,int rid)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("SP_ResourceTeamAtama", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@teamid", tid);
                command.Parameters.AddWithValue("@rid", rid);
                connection.Open();
                int sonuc = command.ExecuteNonQuery();
                return sonuc > 0 ? true : false;
            }
            catch
            {
                
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static int ResourceTeamGET(int rid)
        {
            int tid = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ResourceTeamGET", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@rid", rid);
                tid = (int)command.ExecuteScalar();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
            return tid;
        }
    }
}
