namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    public class Resources
    {
        public static bool CheckEngTLeader(int uid)
        {
            bool boolean = false;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_CheckEngTLeader", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@uid", uid);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                boolean = reader.GetBoolean(0);
            }
            command.Dispose();
            connection.Close();
            return boolean;
        }

        public static DataTable DailyResourceEditList(DateTime? tarih=null, int? hrid=null, int? htuid=null)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_EngDailyEditListeGetir", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                selectCommand.Parameters.AddWithValue("@tarih", tarih);
                selectCommand.Parameters.AddWithValue("@rid", hrid);
                selectCommand.Parameters.AddWithValue("@tid", htuid);
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

        public static DataTable DailyResourceEngList(int uid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_EngDailyListeHazirla", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                selectCommand.Parameters.AddWithValue("@uid", uid);
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

        public static bool DailyResourceInsert(int rid, int uid, int status, string content, DateTime tarih)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_EngDailyInsert", connection);
                command.Parameters.AddWithValue("@rid", rid);
                command.Parameters.AddWithValue("@uid", uid);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@content", content);
                command.Parameters.AddWithValue("@tarih", tarih);
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

        public static DataTable DailyResourcePast(DateTime? tarih=null, int? uid=null,int? tid=null)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_EngDailyPast", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                selectCommand.Parameters.AddWithValue("@tarih", tarih);
                selectCommand.Parameters.AddWithValue("@teamid", tid);
                selectCommand.Parameters.AddWithValue("@uid", uid);
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

        public static bool DeleteDailyToday(int uid)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_EngResDailyGunSil", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@uid", uid);
            int num = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return (num > 0);
        }

        public static List<user> EngListForDaily()
        {
            List<user> list = new List<user>();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_EngListForDaily", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user item = new user
                {
                    _fullname = reader["user_fullname"].ToString(),
                    _uid = Convert.ToInt32(reader["uid"].ToString())
                };
                list.Add(item);
            }
            command.Dispose();
            connection.Close();
            return list;
        }

        public static bool EngResGunlukLimitCheck(int uid)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_EngResGunlukLimitCheck", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@uid", uid);
            int num = int.Parse(command.ExecuteScalar().ToString());
            command.Dispose();
            connection.Close();
            return (num > 0);
        }

        public static bool MakeTeamLeader(int uid)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_MakeTeamLeader", connection);
                command.Parameters.AddWithValue("@uid", uid);
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

        public static bool MaxResCheck(int rid, int pid)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_MaxResCheck", connection);
                command.Parameters.AddWithValue("@rid", rid);
                command.Parameters.AddWithValue("@pid", pid);
                command.CommandType = CommandType.StoredProcedure;
                flag = command.ExecuteScalar().ToString() == "OK";
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

        public static List<performance> PerformanceGet(DateTime? start, DateTime? end)
        {
            List<performance> list = new List<performance>();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_PerformansRepBos", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@start", start);
            command.Parameters.AddWithValue("@finish", end);
            SqlDataReader reader = command.ExecuteReader();
            double num = 0.0;
            double num2 = 0.0;
            while (reader.Read())
            {
                performance item = new performance
                {
                    Resname = reader["resource_name"].ToString(),
                    Resid = int.Parse(reader["rid"].ToString()),
                    Cgs = int.Parse((reader["cgs"] != null) ? reader["cgs"].ToString() : "0"),
                    Kd = int.Parse((reader["cds"] != null) ? reader["cds"].ToString() : "0"),
                    Ks = int.Parse((reader["ks"] != null) ? reader["ks"].ToString() : "0"),
                    Skp = double.Parse((reader["skp"] != null) ? reader["skp"].ToString() : "0"),
                    Csp = double.Parse((reader["csp"] != null) ? reader["csp"].ToString() : "0"),
                    Rkat = double.Parse((reader["reskatsayi"] != null) ? reader["reskatsayi"].ToString() : "0")
                };
                num += item.Kd;
                num2 += item.Ks;
                list.Add(item);
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Ksp = list[i].Cgs * (((double)list[i].Kd) / num);
                list[i].Frekans = list[i].Cgs * (((double)list[i].Ks) / num2);
            }
            command.Dispose();
            connection.Close();
            return list;
        }

        public static bool ResKatsayiUpdate(int rid, double rkatsayi)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_ResourceKatSayiUpdate", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@rid", rid);
            command.Parameters.AddWithValue("@rkatsayi", rkatsayi);
            int num = int.Parse(command.ExecuteNonQuery().ToString());
            command.Dispose();
            connection.Close();
            return (num > 0);
        }

        public static List<resources> ResNameListe()
        {
            List<resources> list2;
            List<resources> list = new List<resources>();
            resources item = null;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlDataReader reader = new SqlCommand("SP_ResNameListe", connection) { CommandType = CommandType.StoredProcedure }.ExecuteReader();
                while (reader.Read())
                {
                    item = new resources
                    {
                        _resource_name = reader.GetString(0),
                        _resource_id = reader.GetInt32(1)
                    };
                    list.Add(item);
                }
                list2 = list;
            }
            catch (Exception)
            {
                list2 = null;
            }
            finally
            {
                connection.Close();
            }
            return list2;
        }

        public static List<resources> ResNameListeEng(int eid)
        {
            List<resources> list2;
            List<resources> list = new List<resources>();
            resources item = null;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ResNameListeEng", connection);
                command.Parameters.AddWithValue("@eid", eid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item = new resources
                    {
                        _resource_name = reader.GetString(0),
                        _resource_id = reader.GetInt32(1)
                    };
                    list.Add(item);
                }
                list2 = list;
            }
            catch (Exception)
            {
                list2 = null;
            }
            finally
            {
                connection.Close();
            }
            return list2;
        }

        public static int Resource_Ekle(resources mdl)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("RESOURCE_EKLE", connection);
            command.Parameters.AddWithValue("@RESOURCE_NAME", mdl._resource_name);
            command.Parameters.AddWithValue("@RESOURCE_STATUS", mdl._resource_status);
            command.Parameters.AddWithValue("@RESOURCE_MAXRESTIME", mdl._resource_maxrestime);
            command.Parameters.AddWithValue("@RESOURCE_PRICE", mdl._resource_price);
            command.Parameters.AddWithValue("@RESOURCE_PRICESTATUS", mdl._resource_status);
            command.Parameters.AddWithValue("@RESOURCE_CODE", mdl._resource_code);
            command.Parameters.AddWithValue("@RECYCLE", mdl._resource_recycle);
            command.Parameters.AddWithValue("@RESOURCE_URL", mdl._resource_url);
            command.Parameters.AddWithValue("@CSSCLASS", mdl._CssClass);
            command.Parameters.AddWithValue("@EXPLANATION", mdl._explanation);
            command.Parameters.AddWithValue("@ENGINEER", mdl._resource_withengineer);
            command.Parameters.AddWithValue("@CONSUMABLE", mdl._resource_withconsumable);
            command.Parameters.AddWithValue("@WORKSTART", mdl.Workingstart);
            command.Parameters.AddWithValue("@WORKFINISH", mdl.Workingfinish);
            command.Parameters.AddWithValue("@MAX_RES_PI", mdl.Maxrespi);
            command.Parameters.AddWithValue("@MAX_RES_USER", mdl.Maxresuser);
            command.Parameters.AddWithValue("@MAX_SAMPLE_NUMBER", mdl.Maxsamplenumber);
            command.Parameters.AddWithValue("@RESCONTROL", mdl.Reservation_control);
            command.Parameters.AddWithValue("@TEAMID", 0);
            command.CommandType = CommandType.StoredProcedure;
            num = int.Parse(command.ExecuteScalar().ToString());
            connection.Close();
            return num;
        }

        public static DataTable Resource_Get_WorkingHours(int rid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_ResourceWorkingHoursGET", connection);
                selectCommand.Parameters.AddWithValue("@rid", rid);
                selectCommand.CommandType = CommandType.StoredProcedure;
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

        public static int Resource_Guncelle(resources mdl)
        {
            int num2;
            int num = 0;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Close();
                SqlCommand command = new SqlCommand("RESOURCE_UPDATE", connection);
                connection.Open();
                command.Parameters.AddWithValue("@RESOURCE_ID", mdl._resource_id);
                command.Parameters.AddWithValue("@RESOURCE_NAME", mdl._resource_name);
                command.Parameters.AddWithValue("@RESOURCE_PRICE", mdl._resource_price);
                command.Parameters.AddWithValue("@RESOURCE_DISCOUNT", mdl.discount);
                command.Parameters.AddWithValue("@RESOURCE_MAXRESTIME", mdl._resource_maxrestime);
                command.Parameters.AddWithValue("@EXPLANATION", mdl._explanation);
                command.Parameters.AddWithValue("@URL", mdl._resource_url);
                command.Parameters.AddWithValue("@ENGINEER", mdl._resource_withengineer);
                command.Parameters.AddWithValue("@CONSUMABLE", mdl._resource_withconsumable);
                command.Parameters.AddWithValue("@WORKSTART", mdl.Workingstart);
                command.Parameters.AddWithValue("@WORKFINISH", mdl.Workingfinish);
                command.Parameters.AddWithValue("@SCHSTART", mdl.Schstart);
                command.Parameters.AddWithValue("@SCHFINISH", mdl.Schfinish);
                command.Parameters.AddWithValue("@MAX_RES_USER", mdl.Maxresuser);
                command.Parameters.AddWithValue("@MAX_SAMPLE_NUMBER", mdl.Maxsamplenumber);
                command.Parameters.AddWithValue("@RESCONTROL", mdl.Reservation_control);
                command.CommandType = CommandType.StoredProcedure;
                num = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                num2 = num;
            }
            catch (SqlException)
            {
                throw;
            }
            return num2;
        }

        public static DataTable ResourceCountForStatu()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_GetCountForResourceStatu", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
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

        public static bool ResourceDisableSchedulerRun()
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_DisableScheduler_Check", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
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

        public static bool ResourceMaxResPICheck(int rid, int uid)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ProjectReservationNumberCheck", connection);
                command.Parameters.AddWithValue("@rid", rid);
                command.Parameters.AddWithValue("@uid", uid);
                command.CommandType = CommandType.StoredProcedure;
                flag = int.Parse(command.ExecuteScalar().ToString()) == 1;
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

        public static bool ResourceMaxResUserCheck(int rid, int uid)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_UserReservationNumberGET", connection);
                command.Parameters.AddWithValue("@rid", rid);
                command.Parameters.AddWithValue("@uid", uid);
                command.CommandType = CommandType.StoredProcedure;
                flag = int.Parse(command.ExecuteScalar().ToString()) == 1;
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

        public static int ResourceRecyle(resources mdl)
        {
            int num2;
            int num = 0;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Close();
                SqlCommand command = new SqlCommand("SP_ResourceRecyle", connection);
                connection.Open();
                command.Parameters.AddWithValue("@rid", mdl._resource_id);
                command.Parameters.AddWithValue("@recycle", mdl._resource_recycle);
                command.CommandType = CommandType.StoredProcedure;
                num = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                num2 = num;
            }
            catch (SqlException)
            {
                throw;
            }
            return num2;
        }

        public static DataTable ResourceReportDateDetay(DateTime? start, DateTime? end)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_ResRepDateDetay", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                selectCommand.Parameters.AddWithValue("@start", start);
                selectCommand.Parameters.AddWithValue("@end", end);
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

        public static bool ResourceReservationControl(int rid)
        {
            bool flag3;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ResourceReservationControlCheck", connection);
                command.Parameters.AddWithValue("@rid", rid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                bool boolean = false;
                try
                {
                    if (reader.Read())
                    {
                        boolean = reader.GetBoolean(0);
                    }
                }
                catch (Exception)
                {
                    boolean = false;
                }
                flag3 = !boolean;
            }
            catch
            {
                flag3 = false;
            }
            finally
            {
                connection.Close();
            }
            return flag3;
        }

        public static bool ResourceStatuAndSchedulerSet(resources mdl)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ResourceStatuAndSchSET", connection);
                command.Parameters.AddWithValue("@rid", mdl._resource_id);
                command.Parameters.AddWithValue("@rstatu", mdl._resource_status);
                command.Parameters.AddWithValue("@reasonstatu", mdl.Statu_reason);
                command.Parameters.AddWithValue("@schstart", mdl.Schstart);
                command.Parameters.AddWithValue("@schfinish", mdl.Schfinish);
                command.CommandType = CommandType.StoredProcedure;
                int num = command.ExecuteNonQuery();
                connection.Close();
                flag = num > 0;
            }
            catch
            {
                flag = false;
            }
            finally
            {
                if (connection.State > ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return flag;
        }

        public static bool ResourceStatuCheck(int rid)
        {
            bool flag2;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ResourceStatucCheck", connection);
                command.Parameters.AddWithValue("@rid", rid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                int num = 0;
                try
                {
                    if (reader.Read())
                    {
                        num = reader.GetInt32(0);
                    }
                }
                catch (Exception)
                {
                    num = 0;
                }
                flag2 = num != 0;
            }
            catch
            {
                flag2 = false;
            }
            finally
            {
                connection.Close();
            }
            return flag2;
        }

        public static bool ResourceTrainingCheck(int rid, int uid)
        {
            bool flag;
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_CihazEgitimKontrol", connection);
                command.Parameters.AddWithValue("@rid", rid);
                command.Parameters.AddWithValue("@uid", uid);
                command.CommandType = CommandType.StoredProcedure;
                flag = command.ExecuteScalar().ToString() == "Pass";
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

        public static bool SP_MakeEngFromTeamLeader(int uid)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_MakeEngFromTeamLeader", connection);
                command.Parameters.AddWithValue("@uid", uid);
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

        public static List<user> TeamLeaderList()
        {
            List<user> list = new List<user>();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_EngTeamLeaderList", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user item = new user
                {
                    _fullname = reader["user_fullname"].ToString(),
                    _uid = Convert.ToInt32(reader["uid"].ToString())
                };
                list.Add(item);
            }
            command.Dispose();
            connection.Close();
            return list;
        }

        public static Entity.SystemMail UsersfromResource(resources mdl)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Close();
                SqlCommand command = new SqlCommand("SP_ResourceProjeUser", connection);
                connection.Open();
                command.Parameters.AddWithValue("@rid", mdl._resource_id);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                Entity.SystemMail mail = new Entity.SystemMail();
                while (reader.Read())
                {
                    if (Regex.IsMatch(reader.GetString(0), "^([A-Za-z0-9-.@])$"))
                    {
                        mail.Adreslist = mail.Adreslist + reader.GetString(0) + ",";
                    }
                }
                command.Dispose();
                connection.Close();
                if (mail != null)
                {
                    mail.Adreslist = mail.Adreslist.Remove(mail.Adreslist.Length - 1, 1);
                    return mail;
                }
                return null;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public static int ResourceMaxResTimeGET(int rid)
        {
            int num = 0;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Close();
                SqlCommand command = new SqlCommand("SP_ResourceMaxResTimeGET", connection);
                connection.Open();
                command.Parameters.AddWithValue("@rid", rid);
                command.CommandType = CommandType.StoredProcedure;
                num = int.Parse(command.ExecuteScalar().ToString());
                command.Dispose();
                connection.Close();
            }
            catch
            {
                return 0;
            }
            return num;
        }

        public static List<resources> ResNameByRids(string rids)
        {
            List<resources> reslst = new List<resources>();
            try
            {
                resources res;
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Close();
                SqlCommand command = new SqlCommand("SP_ResNameByRids", connection);
                command.Parameters.AddWithValue("@rids", rids);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    res = new resources();
                    res._resource_id = dr.GetInt32(0);
                    res._resource_name = dr.GetString(1);
                    reslst.Add(res);
                }
                command.Dispose();
                connection.Close();
            }
            catch(Exception x)
            {
                return null;
            }
            return reslst;
        }
    }
}
