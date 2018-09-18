namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class internal_group_uses
    {
        public static List<Entity.internal_group_uses> Internal_group_Uses_Query(int projid, float balance, DateTime? start, DateTime? end, int piid)
        {
            List<Entity.internal_group_uses> list2;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            List<Entity.internal_group_uses> list = new List<Entity.internal_group_uses>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_internal_group_Uses_Query", connection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@projid", projid);
                command.Parameters.AddWithValue("@balance", balance);
                command.Parameters.AddWithValue("@start", start);
                command.Parameters.AddWithValue("@end", end);
                command.Parameters.AddWithValue("@piid", piid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Entity.internal_group_uses item = new Entity.internal_group_uses
                    {
                        userfullname = reader["user_fullname"].ToString(),
                        day = Convert.ToInt32(reader["day"].ToString()),
                        uses = new decimal?((reader["usage"].ToString() != "") ? Convert.ToDecimal(reader["usage"].ToString()) : decimal.Zero),
                        discusage = new decimal?((reader["usage"].ToString() != "") ? (Convert.ToDecimal(reader["usage"].ToString()) * Convert.ToDecimal((float)(balance / 100f))) : decimal.Zero),
                        mfee = new decimal?((reader["mfee"].ToString() != "") ? Convert.ToDecimal(reader["mfee"].ToString()) : decimal.Zero),
                        start = (reader["start"].ToString() != "") ? new DateTime?(Convert.ToDateTime(reader["start"])) : (null),
                        end = (reader["end"].ToString() != "") ? new DateTime?(Convert.ToDateTime(reader["end"])) : (null)
                    };
                    list.Add(item);
                }
                list2 = list;
            }
            catch (Exception exception)
            {
                Console.Write(exception.InnerException);
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return list2;
        }

        public static int internal_group_Uses_AllDelete(int pid, int projid)
        {
            int num2;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_internal_group_Uses_All_Delete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@pid", pid);
                command.Parameters.AddWithValue("@projid", projid);
                num2 = command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return num2;
        }

        public static int internal_group_Uses_Create(List<Entity.internal_group_uses> internal_group_uses)
        {
            int num2;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            int num = 0;
            try
            {
                connection.Open();
                foreach (Entity.internal_group_uses _uses in internal_group_uses)
                {
                    SqlCommand command = new SqlCommand("SP_internal_group_Uses_Create", connection);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@start", _uses.start);
                    command.Parameters.AddWithValue("@end", _uses.end);
                    command.Parameters.AddWithValue("@piuserid", _uses.piuserid);
                    command.Parameters.AddWithValue("@piprojid", _uses.piprojid);
                    command.Parameters.AddWithValue("@projuserid", _uses.projuserid);
                    command.CommandType = CommandType.StoredProcedure;
                    num = command.ExecuteNonQuery();
                }
                num2 = num;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return num2;
        }

        public static List<Entity.internal_group_uses> Project_User_List(int projid, int? pid = new int?())
        {
            List<Entity.internal_group_uses> list2;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            List<Entity.internal_group_uses> list = new List<Entity.internal_group_uses>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_Proj_User_List", connection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@piuid", projid);
                command.Parameters.AddWithValue("@pid", pid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Entity.internal_group_uses item = new Entity.internal_group_uses
                    {
                        _uid = Convert.ToInt32(reader["uid"].ToString()),
                        userfullname = reader["user_fullname"].ToString(),
                        start = (reader["start"].ToString() != "") ? new DateTime?(Convert.ToDateTime(reader["start"])) : (null),
                        end = (reader["end"].ToString() != "") ? new DateTime?(Convert.ToDateTime(reader["end"])) : (null),
                    };
                    list.Add(item);
                }
                list2 = list;
            }
            catch (Exception exception)
            {
                Console.Write(exception.InnerException);
                throw;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return list2;
        }
    }
}
