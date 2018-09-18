namespace Facade
{
    using Entity;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Reservation
    {
        public static DataTable ExternalRequestsList(int uid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_ReqListByUid", connection);
                selectCommand.Parameters.AddWithValue("@uid", uid);
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

        public static DataTable GunlukResGetirAdmin(DateTime start,DateTime finish,int aranantip)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_GunlukResGetirAdmin", connection);
                selectCommand.Parameters.AddWithValue("@basla", start);
                selectCommand.Parameters.AddWithValue("@bitir", finish);
                selectCommand.Parameters.AddWithValue("@aranantip", aranantip);
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

        public static DataTable GunlukResGetirEng(DateTime basla,DateTime bitir, int aranantip, int euid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_GunlukResGetirEng", connection);
                selectCommand.Parameters.AddWithValue("@basla", basla);
                selectCommand.Parameters.AddWithValue("@bitir", bitir);
                selectCommand.Parameters.AddWithValue("@aranantip", aranantip);
                selectCommand.Parameters.AddWithValue("@euid", euid);
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

        public static DataTable Reservation_Admin_Listele()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATION_ADMIN_LIST", connection)
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

        public static DataTable Reservation_Date_Listele(reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATION_DATE_LIST", connection);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
                selectCommand.Parameters.AddWithValue("@tarih", mdl.Res_start.Date);
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

        public static int Reservation_Ekle(reservation mdl)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("RESERVATION_INSERT", connection);
                command.Parameters.AddWithValue("@RID", mdl._rid);
                command.Parameters.AddWithValue("@UID", mdl._uid);
                command.Parameters.AddWithValue("@PID", mdl._pid);
                command.Parameters.AddWithValue("@RESERVATION_START", mdl.Res_start);
                command.Parameters.AddWithValue("@RESERVATION_END", mdl.Res_end);
                command.Parameters.AddWithValue("@RESERVATION_SUMMARY", mdl._reservation_summary);
                command.Parameters.AddWithValue("@RESERVATION_TIME", mdl._reservation_time);
                command.Parameters.AddWithValue("@RESERVATION_IP", mdl._reservation_ip);
                command.Parameters.AddWithValue("@RESERVATION_STATUS", mdl._reservation_status);
                command.Parameters.AddWithValue("@RESERVATION_STARTTEXT", mdl._reservation_starttext);
                command.Parameters.AddWithValue("@RESERVATION_ENDTEXT", mdl._reservation_endtext);
                if (mdl.Req_id > 0)
                {
                    command.Parameters.AddWithValue("@REQUEST_ID", mdl.Req_id);
                }
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

        public static string Reservation_End_Time(reservation mdl, DateTime gelent)
        {
            string str = null;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("RESERVATION_END_TIME", connection);
                command.Parameters.AddWithValue("@RID", mdl._rid);
                command.Parameters.AddWithValue("@rtarih", gelent.Date);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    str = reader[0].ToString();
                }
            }
            catch
            {
                str = null;
            }
            finally
            {
                connection.Close();
            }
            return str;
        }

        public static DataTable Reservation_Id_Listele(reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATION_ID_LIST", connection);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
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

        public static DataTable Reservation_Id_Listele2(reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATIONS_ID_LIST", connection);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
                selectCommand.Parameters.AddWithValue("@PID", mdl._pid);
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

        public static DataTable Reservation_Id_ListeleFuture(reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATION_ID_LIST_FUTURE", connection);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
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

        public static DataTable Reservation_Id_ListelePast(reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATION_ID_LIST_PAST", connection);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
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

        public static DataTable Reservation_Listele(reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATIONS_LIST", connection);
                selectCommand.Parameters.AddWithValue("@ZAMAN", mdl._reservation_start);
                selectCommand.Parameters.AddWithValue("@RESERVATION_DATE", mdl.Res_start.Date);
                selectCommand.Parameters.AddWithValue("@RID", mdl._rid);
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

        public static DataTable Reservation_Listele(bool statu)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                DateTime time = new DateTime(year, month, day);
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATIONS_LISTS", connection);
                selectCommand.Parameters.AddWithValue("@status", statu ? 1 : 0);
                selectCommand.Parameters.AddWithValue("@tarih", time.Date);
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

        public static DataTable Reservation_Rid_Listele(reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATIONS_RID_LIST", connection);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
                selectCommand.Parameters.AddWithValue("@RID", mdl._rid);
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

        public static DataTable Reservation_Start_Time(reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATION_START_TIME", connection);
                selectCommand.Parameters.AddWithValue("@RID", mdl._rid);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
                selectCommand.Parameters.AddWithValue("@RESERVATION_DATE", mdl.Res_start.Date);
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
        public static DataTable Reservation_Start_Time(int rid,int uid,DateTime resdate)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATION_START_TIME", connection);
                selectCommand.Parameters.AddWithValue("@RID", rid);
                selectCommand.Parameters.AddWithValue("@UID", uid);
                selectCommand.Parameters.AddWithValue("@RESERVATION_DATE", resdate);
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

        public static DataTable Reservations_Listele(reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATIONS_GETIR", connection);
                selectCommand.Parameters.AddWithValue("@rid", mdl._rid);
                selectCommand.Parameters.AddWithValue("@tarih", mdl.Res_start.Date);
                selectCommand.Parameters.AddWithValue("@reservation_time", mdl.Res_start);
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

        public static DataTable Reservations_User_Listele(reservation mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATION_USER_LIST", connection);
                selectCommand.Parameters.AddWithValue("@rid", mdl._rid);
                selectCommand.Parameters.AddWithValue("@day", mdl._reservation_day);
                selectCommand.Parameters.AddWithValue("@month", mdl._reservation_month);
                selectCommand.Parameters.AddWithValue("@year", mdl._reservation_year);
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

        public static bool Reservation_End_Time_Uygunluk(int rid,DateTime bitis,DateTime basla)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ResBitisUygunluk", connection);
                command.Parameters.AddWithValue("@basla", basla);
                command.Parameters.AddWithValue("@bitis", bitis);
                command.Parameters.AddWithValue("@rid", rid);
                command.CommandType = CommandType.StoredProcedure;
                num = int.Parse(command.ExecuteScalar().ToString());
            }
            catch
            {
                num = 1;
            }
            finally
            {
                connection.Close();
            }
            return num==0?true:false;
        }

        public static DataTable RezListeSaatIcın(int rid,int day,int month,int year)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_RezListeSaatIcın", connection);
                selectCommand.Parameters.AddWithValue("@rid", rid);
                selectCommand.Parameters.AddWithValue("@day", day);
                selectCommand.Parameters.AddWithValue("@month", month);
                selectCommand.Parameters.AddWithValue("@year", year);
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

        public static DataTable GunlukResTakvimGET(int rid, DateTime tarih)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_GunlukResTakvimGET", connection);
                selectCommand.Parameters.AddWithValue("@rid", rid);
                selectCommand.Parameters.AddWithValue("@tarih", tarih);
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

        public static bool ResPermissionCheck(int uid,int pid)
        {
            int num = -1;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ProjectResPermissionGET", connection);
                command.Parameters.AddWithValue("@uid", uid);
                command.Parameters.AddWithValue("@pid", pid);
                command.CommandType = CommandType.StoredProcedure;
                num = int.Parse(command.ExecuteScalar().ToString());
            }
            catch
            {
                num = -1;
            }
            finally
            {
                connection.Close();
            }
            return num >0 ? true : false;
        }

        public static DataRow AraYazilimReservationGETOneByUid(int uid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("Aray_SP_ReservationGETOneByUid", connection);
                selectCommand.Parameters.AddWithValue("@uid", uid);
                selectCommand.CommandType = CommandType.StoredProcedure;
                new SqlDataAdapter(selectCommand).Fill(dataTable);
                if (dataTable!=null&& dataTable.Rows.Count>0)
                {
                    return dataTable.Rows[0];
                }
                else
                {
                    return null;
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
    }
}
