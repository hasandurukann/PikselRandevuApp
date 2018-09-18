namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class users
    {
        public static List<user> AllExternalList()
        {
            List<user> list2;
            try
            {
                List<user> list = new List<user>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ExternalUserList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user item = new user
                    {
                        _fullname = reader["userinfo"].ToString(),
                        _uid = Convert.ToInt32(reader["uid"].ToString())
                    };
                    list.Add(item);
                }
                command.Dispose();
                connection.Close();
                list2 = list;
            }
            catch (Exception)
            {
                throw;
            }
            return list2;
        }

        public static List<user> AllPiList()
        {
            List<user> list2;
            try
            {
                List<user> list = new List<user>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_AllPIList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user item = new user
                    {
                        _fullname = reader["user_fullname"].ToString(),
                        _uid = Convert.ToInt32(reader["uid"].ToString()),
                        _username = reader["user_name"].ToString(),
                        _user_type = Convert.ToInt32(reader["user_type"].ToString())
                    };
                    list.Add(item);
                }
                command.Dispose();
                connection.Close();
                list2 = list;
            }
            catch (Exception)
            {
                throw;
            }
            return list2;
        }

        public static List<user> AllUserForDropDown()
        {
            List<user> list = new List<user>();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_UserListele", connection)
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

        public static Entity.SystemMail GetAllUsersMail()
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Close();
                SqlCommand command = new SqlCommand("SP_GetUserMailAll", connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                Entity.SystemMail mail = new Entity.SystemMail();
                while (reader.Read())
                {
                    mail.Adreslist = mail.Adreslist + reader.GetString(0) + ",";
                }
                command.Dispose();
                connection.Close();
                if (mail != null)
                {
                    mail.Adreslist.Remove(mail.Adreslist.Length - 1, 1);
                    return mail;
                }
                return null;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public static Entity.SystemMail GetEngUsersMail()
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Close();
                SqlCommand command = new SqlCommand("SP_GetEngUserMailAll", connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                Entity.SystemMail mail = new Entity.SystemMail();
                while (reader.Read())
                {
                    mail.Adreslist = mail.Adreslist + reader.GetString(0) + ",";
                }
                command.Dispose();
                connection.Close();
                if (mail!= null)
                {
                    mail.Adreslist.Remove(mail.Adreslist.Length - 1, 1);
                    return mail;
                }
                return null;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public static Entity.SystemMail GetExternalUsersMail()
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Close();
                SqlCommand command = new SqlCommand("SP_GetExternalUserMailAll", connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                Entity.SystemMail mail = new Entity.SystemMail();
                while (reader.Read())
                {
                    mail.Adreslist = mail.Adreslist + reader.GetString(0) + ",";
                }
                command.Dispose();
                connection.Close();
                if (mail != null)
                {
                    mail.Adreslist.Remove(mail.Adreslist.Length - 1, 1);
                    return mail;
                }
                return null;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public static Entity.SystemMail GetInternalUsersMail()
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Close();
                SqlCommand command = new SqlCommand("SP_GetInternalUserMailAll", connection);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                Entity.SystemMail mail = new Entity.SystemMail();
                while (reader.Read())
                {
                    mail.Adreslist = mail.Adreslist + reader.GetString(0) + ",";
                }
                command.Dispose();
                connection.Close();
                if (mail != null)
                {
                    mail.Adreslist.Remove(mail.Adreslist.Length - 1, 1);
                    return mail;
                }
                return null;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public static DataTable Kullanici_Arama(user mdl)
        {
            SqlCommand command;
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            if (mdl._user_level == 0)
            {
                string[] textArray1 = new string[] { "select uid,user_username,user_name,user_surname,user_email,user_institution,user_lastlogin,CssClass,recycle, CASE user_level WHEN 1 THEN 'User' WHEN 2 THEN 'PI' WHEN 3 THEN 'Engineer' ELSE 'Admin' END as user_level,'None' as user_PI,case hourlyinternal when 1 then 'Exclusive Mode' else 'Default' end as user_type from users where (user_fullname like '%", mdl._name, "%' or user_username like '%", mdl._name, "%') order by uid desc" };
                command = new SqlCommand(string.Concat(textArray1), connection);
            }
            else
            {
                command = new SqlCommand("SP_UserAramaWithLevel", connection);
                command.Parameters.AddWithValue("@name", mdl._name);
                command.Parameters.AddWithValue("@u_level", mdl._user_level);
                command.CommandType = CommandType.StoredProcedure;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException)
            {
                throw;
            }
            return dataTable;
        }

        public static DataTable Kullanici_AramaENG(user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            SqlCommand selectCommand = new SqlCommand("USER_ARAMA_ENG", connection);
            selectCommand.Parameters.AddWithValue("@arama", mdl._name);
            selectCommand.Parameters.AddWithValue("@USERENG_ID", mdl._uid);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException)
            {
                throw;
            }
            return dataTable;
        }

        public static DataTable Kullanici_Discipline_Listele()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            SqlCommand selectCommand = new SqlCommand("SP_KaraListeGetir", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException)
            {
            }
            return dataTable;
        }

        public static DataTable Kullanici_Discipline_ListeleENG(int engid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            SqlCommand selectCommand = new SqlCommand("SP_KaraListeGetirENG", connection);
            selectCommand.Parameters.AddWithValue("@USERENG_ID", engid);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException)
            {
            }
            return dataTable;
        }

        public static DataRow Kullanici_Email_Sorgula(user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("KULLANICI_EMAIL_SORGULA", connection);
            selectCommand.Parameters.AddWithValue("@EMAIL", mdl._email);
            selectCommand.Parameters.AddWithValue("@USERNAME", mdl._username);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                throw new Exception(exception.Message);
            }
            connection.Close();
            selectCommand.Dispose();
            adapter.Dispose();
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            return dataTable.Rows[0];
        }

        public static int Kullanici_Guncelle(user mdl)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("USER_UPDATE", connection);
            command.Parameters.AddWithValue("@UID", mdl._uid);
            command.Parameters.AddWithValue("@USERNAME", mdl._username);
            command.Parameters.AddWithValue("@USER_NAME", mdl._name);
            command.Parameters.AddWithValue("@USERSURNAME", mdl._surname);
            command.Parameters.AddWithValue("@USER_PHONE", mdl._phone);
            command.Parameters.AddWithValue("@USER_ADDRESS", mdl._address);
            command.Parameters.AddWithValue("@USER_INSTITUTION", mdl._institution);
            command.Parameters.AddWithValue("@USER_EMAIL", mdl._email);
            command.Parameters.AddWithValue("@USER_FULLNAME", mdl._fullname);
            command.Parameters.AddWithValue("@USER_CITY", mdl._city);
            command.Parameters.AddWithValue("@USER_DEPARTMENT", mdl._department);
            command.CommandType = CommandType.StoredProcedure;
            num = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return num;
        }

        public static DataRow Kullanici_ID_Listele(user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("USER_ID_LISTELE", connection);
            selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch
            {
                throw;
            }
            selectCommand.Dispose();
            adapter.Dispose();
            connection.Close();
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            return dataTable.Rows[0];
        }

        public static DataRow Kullanici_ID_Sorgula(user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("USER_ID_LISTELE", connection);
            selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
            selectCommand.Parameters.AddWithValue("@UNIQUECODE", mdl._user_unique_code);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException)
            {
                throw;
            }
            selectCommand.Dispose();
            adapter.Dispose();
            connection.Close();
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            return dataTable.Rows[0];
        }

        public static DataTable Kullanici_Listele(user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            SqlCommand selectCommand = new SqlCommand("USER_LISTELE", connection);
            selectCommand.Parameters.AddWithValue("@USER_ACTIVE", mdl._user_active);
            selectCommand.Parameters.AddWithValue("@USER_LEVEL", mdl._user_level);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException)
            {
                throw;
            }
            return dataTable;
        }

        public static DataTable Kullanici_ListeleENG(user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            SqlCommand selectCommand = new SqlCommand("USER_LISTELE_ENG", connection);
            selectCommand.Parameters.AddWithValue("@USERENG_ID", mdl._uid);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException)
            {
                throw;
            }
            return dataTable;
        }

        public static DataTable Kullanici_ListeleENGRES(user mdl, int rid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            SqlCommand selectCommand = new SqlCommand("USER_LISTELE_ENGRES", connection);
            selectCommand.Parameters.AddWithValue("@USERENG_ID", mdl._uid);
            selectCommand.Parameters.AddWithValue("@RES_ID", rid);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            return dataTable;
        }

        public static DataRow Kullanici_Sorgula(user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("KULLANICI", connection);
            selectCommand.Parameters.AddWithValue("@k_adi", mdl._username);
            selectCommand.Parameters.AddWithValue("@sifre", mdl._password);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                throw new Exception(exception.Message);
            }
            connection.Close();
            selectCommand.Dispose();
            adapter.Dispose();
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            return dataTable.Rows[0];
        }

        public static DataRow Kullanici_UID_Sorgula(user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("USER_UID_LISTELE", connection);
            selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
            selectCommand.Parameters.AddWithValue("@UNIQUECODE", mdl._user_unique_code);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException)
            {
                throw;
            }
            selectCommand.Dispose();
            adapter.Dispose();
            connection.Close();
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            return dataTable.Rows[0];
        }

        public static DataRow KullaniciForgot(user mdl, string cevap)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("SP_KullaniciForgot", connection);
            selectCommand.Parameters.AddWithValue("@email", mdl._email);
            selectCommand.Parameters.AddWithValue("@answer", cevap);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                throw new Exception(exception.Message);
            }
            connection.Close();
            selectCommand.Dispose();
            adapter.Dispose();
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            return dataTable.Rows[0];
        }

        public static DataRow KullaniciForgotControl(user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("SP_KullaniciForgotControl", connection);
            selectCommand.Parameters.AddWithValue("@email", mdl._email);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch (SqlException exception)
            {
                throw new Exception(exception.Message);
            }
            connection.Close();
            selectCommand.Dispose();
            adapter.Dispose();
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            return dataTable.Rows[0];
        }

        public static void last_Login_Update(user mdl)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("LASTLOGINUPDATE", connection);
                command.Parameters.AddWithValue("@lastlogin", mdl._lastlogin);
                command.Parameters.AddWithValue("@userId", mdl._uid);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SqlException exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void UniqueCode_Guncelle(user mdl)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("USER_UNIQUECODE_UPDATE", connection);
                command.Parameters.AddWithValue("@UNIQUECODE", mdl._user_unique_code);
                command.Parameters.AddWithValue("@EMAIL", mdl._email);
                command.Parameters.AddWithValue("@USERNAME", mdl._username);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool User_ApproveTextControl(user mdl)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_ApprovingTextControl", connection);
            command.Parameters.AddWithValue("@uid", mdl._uid);
            command.CommandType = CommandType.StoredProcedure;
            bool flag = Convert.ToBoolean(int.Parse(command.ExecuteScalar().ToString()));
            connection.Close();
            command.Dispose();
            return flag;
        }

        public static bool User_ApproveTextSet(user mdl)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_ApprovingTextSET", connection);
            command.Parameters.AddWithValue("@uid", mdl._uid);
            command.CommandType = CommandType.StoredProcedure;
            int num = command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            return (num > 0);
        }

        public static int User_Ekle(user mdl)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SITE_USEREKLE", connection);
            command.Parameters.AddWithValue("@FULLNAME", mdl._fullname);
            command.Parameters.AddWithValue("@ADDRESS", mdl._address);
            command.Parameters.AddWithValue("@CITY", mdl._city);
            command.Parameters.AddWithValue("@DEPARTMENT", mdl._department);
            command.Parameters.AddWithValue("@EMAIL", mdl._email);
            command.Parameters.AddWithValue("@INSTITUTION", mdl._institution);
            command.Parameters.AddWithValue("@LASTLOGIN", mdl._lastlogin);
            command.Parameters.AddWithValue("@NAME", mdl._name);
            command.Parameters.AddWithValue("@PASSWORD", mdl._password);
            command.Parameters.AddWithValue("@PHONE", mdl._phone);
            command.Parameters.AddWithValue("@SURNAME", mdl._surname);
            command.Parameters.AddWithValue("@USER_LEVEL", mdl._user_level);
            command.Parameters.AddWithValue("@USERNAME", mdl._username);
            command.Parameters.AddWithValue("@USER_ACTIVE", mdl._user_active);
            command.Parameters.AddWithValue("@ABSENCE_NOTE", mdl._absence_note);
            command.Parameters.AddWithValue("@USER_ABSENCE", mdl._user_absence);
            command.Parameters.AddWithValue("@USER_ABSENCE_EXP", mdl._user_absence_exp);
            command.Parameters.AddWithValue("@USER_INUNAM", mdl._user_inunam);
            //command.Parameters.AddWithValue("@USER_PI", mdl._user_pi);
            command.Parameters.AddWithValue("@USER_POSITION", mdl._user_position);
            command.Parameters.AddWithValue("@USER_REG_DATE", mdl._user_reg_date);
            command.Parameters.AddWithValue("@USER_STATUS", mdl._user_status);
            command.Parameters.AddWithValue("@USER_TYPE", mdl._user_type);
            command.Parameters.AddWithValue("@USER_RECYCLE", mdl._user_recycle);
            command.Parameters.AddWithValue("@CSSCLASS", mdl._CssClass);
            command.Parameters.AddWithValue("@SECQUESTION", mdl.Secquestion);
            command.Parameters.AddWithValue("@SECANSWER", mdl.Secanswer);
            command.Parameters.AddWithValue("@HOURLYINT", mdl.Hourlyint);
            command.CommandType = CommandType.StoredProcedure;
            int num = command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            return num;
        }

        public static bool User_HourlyInternal(user mdl, int hourlyint)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_HourlyInternalSET", connection);
            command.Parameters.AddWithValue("@uid", mdl._uid);
            command.Parameters.AddWithValue("@statu", hourlyint);
            command.CommandType = CommandType.StoredProcedure;
            int num = command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            return (num > 0);
        }

        public static DataTable UserDataForChartLevel()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("SP_GetCountForUserLevel", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch
            {
                throw;
            }
            selectCommand.Dispose();
            adapter.Dispose();
            connection.Close();
            return dataTable;
        }

        public static DataRow UserDataForChartType()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("SP_GetCountForUserTypes", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch
            {
                throw;
            }
            selectCommand.Dispose();
            adapter.Dispose();
            connection.Close();
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            return dataTable.Rows[0];
        }

        public static DataTable UserDataForChartUsage()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("SP_UserUsageStats", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            try
            {
                adapter.Fill(dataTable);
            }
            catch
            {
                throw;
            }
            selectCommand.Dispose();
            adapter.Dispose();
            connection.Close();
            return dataTable;
        }

        public static List<user> UserProjePIListe(int uid)
        {
            try
            {
                List<user> list = new List<user>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_UserProjePIListe", connection);
                command.Parameters.AddWithValue("@uid", uid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user item = new user
                    {
                        _fullname = reader["project_creator_fullname"].ToString(),
                        _uid = Convert.ToInt32(reader["project_creator"].ToString())
                    };
                    list.Add(item);
                }
                command.Dispose();
                connection.Close();
                return list;
            }
            catch
            {
                return null;
            }
        }

        public static bool UserPISet(int uid, int piid)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_SetUserPIatHome", connection);
            command.Parameters.AddWithValue("@uid",uid);
            command.Parameters.AddWithValue("@piid", piid);
            command.CommandType = CommandType.StoredProcedure;
            int num = command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            return (num > 0);
        }
    }
}
