namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class Kullanim
    {
        public static DataTable AddedBalanceGoster(kullanim mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = null;
                selectCommand = new SqlCommand("SP_AddedBalanceGoster", connection);
                selectCommand.Parameters.AddWithValue("@uid", mdl._user_id);
                selectCommand.CommandType = CommandType.StoredProcedure;
                new SqlDataAdapter(selectCommand).Fill(dataTable);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public static bool AddUsage(int mypid, int myuid, int myrid, DateTime mybasla, DateTime mybitis, int mywe, int mywc)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = null;
                command = new SqlCommand("SP_AddUsage", connection);
                command.Parameters.AddWithValue("@uid", myuid);
                command.Parameters.AddWithValue("@rid", myrid);
                command.Parameters.AddWithValue("@pid", mypid);
                command.Parameters.AddWithValue("@basla", mybasla);
                command.Parameters.AddWithValue("@bitis", mybitis);
                command.Parameters.AddWithValue("@we", mywe);
                command.Parameters.AddWithValue("@wc", mywc);
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

        public static bool EditUsage(DateTime mybitis, int kid, int mywe, int mywc, DateTime mybasla)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = null;
                command = new SqlCommand("SP_EditUsageSet", connection);
                command.Parameters.AddWithValue("@kid", kid);
                command.Parameters.AddWithValue("@weng", mywe);
                command.Parameters.AddWithValue("@wcon", mywc);
                command.Parameters.AddWithValue("@basla", mybasla);
                command.Parameters.AddWithValue("@bitis", mybitis);
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

        public static DataTable Equipment_Usage(kullanim mdl, reservation mdl2)
        {
            return null;
            //DataTable dataTable = new DataTable();
            //SqlConnection connection = new SqlConnection(islem.ConnectionString);
            //try
            //{
            //    connection.Open();
            //    SqlCommand selectCommand = new SqlCommand("EQUIPMENT_USAGE_REPORT", connection);
            //    selectCommand.Parameters.AddWithValue("@day", mdl._day);
            //    selectCommand.Parameters.AddWithValue("@month", mdl._month);
            //    selectCommand.Parameters.AddWithValue("@year", mdl._year);
            //    selectCommand.Parameters.AddWithValue("@r_day", mdl2._reservation_day);
            //    selectCommand.Parameters.AddWithValue("@r_month", mdl2._reservation_month);
            //    selectCommand.Parameters.AddWithValue("@r_year", mdl2._reservation_year);
            //    selectCommand.CommandType = CommandType.StoredProcedure;
            //    new SqlDataAdapter(selectCommand).Fill(dataTable);
            //}
            //catch
            //{
            //    dataTable.Rows.Clear();
            //}
            //finally
            //{
            //    connection.Close();
            //}
            //return dataTable;
        }

        public static decimal GetRecentBalanceOnePI(int pid)
        {
            decimal @decimal = new decimal();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SP_GetRecentBalanceOnePI", connection);
                    command.Parameters.AddWithValue("@pid", pid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        @decimal = reader.GetDecimal(0);
                    }
                }
            }
            catch (Exception)
            {
                return decimal.Zero;
            }
            return @decimal;
        }

        public static DataRow Kullanim_Id_Listele(kullanim mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("KULLANIM_ID_LISTELE", connection);
                selectCommand.Parameters.AddWithValue("@kid", mdl._kullanim_id);
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

        public static DataTable Kullanim_Listele(kullanim mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("KULLANIM_PIID_LIST", connection);
                selectCommand.Parameters.AddWithValue("@project_creator", mdl._user_id);
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

        public static DataTable Kullanim_Lists(user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("KULLANIM_LISTS", connection);
                selectCommand.Parameters.AddWithValue("@user_level", mdl._user_level);
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

        public static DataTable Kullanim_Rid_Listele(kullanim mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("KULLANIM_RID_LISTELE", connection);
                selectCommand.Parameters.AddWithValue("@rid", mdl._cihaz_id);
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

        public static DataTable Kullanim_Uid_Listele(kullanim mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("KULLANIM_UID_LISTELE", connection);
                selectCommand.Parameters.AddWithValue("@uid", mdl._user_id);
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

        public static List<kullanim> Usage_ListForEdit(int uid, int pid, int resid)
        {
            List<kullanim> list = new List<kullanim>();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SP_UsageGetirProjeUserRes", connection);
                    command.Parameters.AddWithValue("@pid", pid);
                    command.Parameters.AddWithValue("@userid", uid);
                    command.Parameters.AddWithValue("@resid", resid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        kullanim item = new kullanim
                        {
                            _kullanim_id = reader.GetInt32(0),
                            Tarihveresid = reader.GetString(1),
                            _basla = reader.GetDateTime(2),
                            _bitis = reader.GetDateTime(3),
                            Weng = reader.GetInt32(4),
                            Wcon = reader.GetInt32(5)
                        };
                        list.Add(item);
                    }
                    return list;
                }
            }
            catch
            {
                throw;
            }
            return null;
        }

        public static kullanim Usage_OneForEdit(int kid)
        {
            List<kullanim> list = new List<kullanim>();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SP_KullanimGetOne", connection);
                    command.Parameters.AddWithValue("@kid", kid);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    kullanim kullanim = new kullanim();
                    if (reader.Read())
                    {
                        kullanim._kullanim_id = reader.GetInt32(0);
                        kullanim._basla = reader.GetDateTime(1);
                        kullanim._bitis = reader.GetDateTime(2);
                        kullanim.Weng = reader.GetInt32(3);
                        kullanim.Wcon = reader.GetInt32(4);
                    }
                    return kullanim;
                }
            }
            catch
            {
                throw;
            }
            return null;
        }

        public static bool ArayYeniKullanimEkle(int pid, int uid, int rid, int resid)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = null;
                command = new SqlCommand("SP_YeniKullanimEkle", connection);
                command.Parameters.AddWithValue("@uid", uid);
                command.Parameters.AddWithValue("@cihaz_id", rid);
                command.Parameters.AddWithValue("@pid", pid);
                command.Parameters.AddWithValue("@we", 1);
                command.Parameters.AddWithValue("@wc", 1);
                command.Parameters.AddWithValue("@ranid", resid);
                command.CommandType = CommandType.StoredProcedure;
                flag = command.ExecuteNonQuery() > 0;
            }
            catch(Exception x)
            {
                flag = false;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public static DataRow ArayGetCurrentUsage(int uid,string rids)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_GetCurrentUsage", connection);
                selectCommand.Parameters.AddWithValue("@uid", uid);
                selectCommand.Parameters.AddWithValue("@rids", rids);
                selectCommand.CommandType = CommandType.StoredProcedure;
                new SqlDataAdapter(selectCommand).Fill(dataTable);
                if (dataTable.Rows.Count>0)
                {
                    return dataTable.Rows[0];
                }
            }
            catch
            {
                dataTable.Rows.Clear();
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public static bool ArayKullanimBitir(int uid,int kulid)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = null;
                command = new SqlCommand("SP_EndCurrentUsage", connection);
                command.Parameters.AddWithValue("@uid", uid);
                command.Parameters.AddWithValue("@kulid", kulid);
                command.CommandType = CommandType.StoredProcedure;
                flag = command.ExecuteNonQuery() > 0;
            }
            catch (Exception x)
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
