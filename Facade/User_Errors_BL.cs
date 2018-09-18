namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class User_Errors_BL
    {
        public static user User(int userid)
        {
            user user2;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_One", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", userid);
                SqlDataReader reader = command.ExecuteReader();
                user user = new user();
                if (reader.Read())
                {
                    user._uid = Convert.ToInt32(reader["uid"]);
                    user._fullname = reader["user_fullname"].ToString();
                    user._user_active = Convert.ToInt32(reader["user_active"]);
                    user._user_level = Convert.ToInt32(reader["user_level"]);
                    user._department = reader["user_department"].ToString();
                    user._email = reader["user_email"].ToString();
                }
                command.Dispose();
                connection.Close();
                user2 = user;
            }
            catch (Exception)
            {
                throw;
            }
            return user2;
        }

        public static int User_Error_Create(User_Errors error)
        {
            int num = 0;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_User_Error_Create", connection);
                command.Parameters.AddWithValue("@device_id", error.device_id);
                command.Parameters.AddWithValue("@error_content", error.error_content);
                command.Parameters.AddWithValue("@error_status", error.error_status);
                command.Parameters.AddWithValue("@status_type", error.status_type);
                command.Parameters.AddWithValue("@user_id", error.user_id);
                command.Parameters.AddWithValue("@error_date", error.error_date);
                command.Parameters.AddWithValue("@punperiod", error.pun_period);
                command.Parameters.AddWithValue("@puntype", error.pun_type);
                command.CommandType = CommandType.StoredProcedure;
                num = command.ExecuteNonQuery();
                connection.Close();
                command.Dispose();
                return num;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int User_Error_Delete(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Error_Delete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                int num = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return num;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static List<User_Errors> User_Error_List()
        {
            List<User_Errors> list2;
            try
            {
                List<User_Errors> list = new List<User_Errors>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Error_List", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User_Errors item = new User_Errors
                    {
                        id = (int)reader["id"],
                        device_id = (int)reader["device_id"],
                        user_id = (int)reader["user_id"],
                        error_content = reader["error_content"].ToString(),
                        status_type = (int)reader["status_type"],
                        error_status = (int)reader["error_status"],
                        error_date = (DateTime?)reader["error_date"],
                        pun_period = (int)reader["punperiod"],
                        pun_type = (bool)reader["puntype"],
                        devammi = int.Parse(reader["devamdurum"].ToString())
                    };
                    item.User = User(item.user_id);
                    item.Resource = Trainings_BL.Resources_One(item.device_id);
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

        public static List<User_Errors> User_Error_ListArama(int uid)
        {
            List<User_Errors> list2;
            try
            {
                List<User_Errors> list = new List<User_Errors>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Error_ListByUserID", connection);
                command.Parameters.AddWithValue("@uid", uid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User_Errors item = new User_Errors
                    {
                        id = (int)reader["id"],
                        device_id = (int)reader["device_id"],
                        user_id = (int)reader["user_id"],
                        error_content = reader["error_content"].ToString(),
                        status_type = (int)reader["status_type"],
                        error_status = (int)reader["error_status"],
                        error_date = (DateTime?)reader["error_date"],
                        pun_period = (int)reader["punperiod"],
                        pun_type = (bool)reader["puntype"],
                        devammi = int.Parse(reader["devamdurum"].ToString())
                    };
                    item.User = User(item.user_id);
                    item.Resource = Trainings_BL.Resources_One(item.device_id);
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

        public static User_Errors User_Error_One(int id)
        {
            User_Errors errors2;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Error_One", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                User_Errors errors = new User_Errors();
                if (reader.Read())
                {
                    errors.id = (int)reader["id"];
                    errors.device_id = (int)reader["device_id"];
                    errors.user_id = (int)reader["user_id"];
                    errors.error_content = reader["error_content"].ToString();
                    errors.status_type = (int)reader["status_type"];
                    errors.error_status = (int)reader["error_status"];
                    errors.error_date = (DateTime?)reader["error_date"];
                    errors.pun_period = (int)reader["punperiod"];
                    errors.pun_type = (bool)reader["puntype"];
                    errors.User = User(errors.user_id);
                    errors.Resource = Trainings_BL.Resources_One(errors.device_id);
                }
                command.Dispose();
                connection.Close();
                errors2 = errors;
            }
            catch (Exception)
            {
                throw;
            }
            return errors2;
        }

        public static int User_Error_Status(int id, int status)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Error_Status", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@error_status", status);
                command.Parameters.AddWithValue("@id", id);
                int num = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return num;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static int User_Error_Update(User_Errors error)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Error_Update", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@device_id", error.device_id);
                command.Parameters.AddWithValue("@error_content", error.error_content);
                command.Parameters.AddWithValue("@status_type", error.status_type);
                command.Parameters.AddWithValue("@user_id", error.user_id);
                command.Parameters.AddWithValue("@error_date", error.error_date);
                command.Parameters.AddWithValue("@id", error.id);
                command.Parameters.AddWithValue("@punperiod", error.pun_period);
                command.Parameters.AddWithValue("@puntype", error.pun_type);
                int num = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return num;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static bool UserPenaltyCheck(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_UserPenaltyCheck", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                bool flag = (bool)command.ExecuteScalar();
                command.Dispose();
                connection.Close();
                return flag;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UserResourcePenaltyCheck(int id, int cihazid)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_UserPenaltyResourceCheck", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@cihazid", cihazid);
                bool flag = (bool)command.ExecuteScalar();
                command.Dispose();
                connection.Close();
                return flag;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
