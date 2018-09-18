namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class project_user
    {
        public static int Join_Project(Entity.project_user mdl)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("JOINPROJECT", connection);
            command.Parameters.AddWithValue("@PID", mdl._pid);
            command.Parameters.AddWithValue("@UID", mdl._uid);
            command.Parameters.AddWithValue("@PROJECT_USER_STATUS", mdl._project_user_status);
            command.Parameters.AddWithValue("@JOIN_DATE", mdl._join_date);
            command.Parameters.AddWithValue("@PROJECT_CREATOR", mdl._project_creator);
            command.CommandType = CommandType.StoredProcedure;
            num = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return num;
        }

        public static DataTable Project_Reservation(Entity.project_user mdl, Entity.project mdl2)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("RESERVATION_PROJECT", connection);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
                selectCommand.Parameters.AddWithValue("@PROJECT_STATUS", mdl2._project_status);
                selectCommand.Parameters.AddWithValue("@PROJECT_USER_STATUS", mdl._project_user_status);
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

        public static List<Entity.project_user> Project_User_List(int projid, int pid)
        {
            List<Entity.project_user> list2;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            List<Entity.project_user> list = new List<Entity.project_user>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_Proj_User_List", connection);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@piuid", projid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Entity.project_user item = new Entity.project_user
                    {
                        _uid = Convert.ToInt32(reader["uid"].ToString()),
                        _user_fullname = reader["user_fullname"].ToString()
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
            return list2;
        }

        public static DataTable ProjectUser_ID_Listele(Entity.project_user mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("PROJECTUSER_ID_LIST", connection);
                selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
                selectCommand.Parameters.AddWithValue("@STATUS", mdl._project_user_status);
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

        public static DataTable ProjectUser_Listele(user mdl, Entity.project_user mdl2)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("PROJECTUSER_LISTELE", connection);
            selectCommand.Parameters.AddWithValue("@UID", mdl._uid);
            selectCommand.Parameters.AddWithValue("@STATUS", mdl2._project_user_status);
            selectCommand.Parameters.AddWithValue("@PID", mdl2._pid);
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
            connection.Close();
            return dataTable;
        }

        public static int ProjectUser_Update(Entity.project_user mdl)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("PROJECTUSER_UPDATE", connection);
            command.Parameters.AddWithValue("@PUID", mdl._puid);
            command.Parameters.AddWithValue("@STATUS", mdl._project_user_status);
            command.CommandType = CommandType.StoredProcedure;
            num = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return num;
        }

        public static Entity.SystemMail UsersFromProject(int pid)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Close();
                SqlCommand command = new SqlCommand("SP_UserFromProjectMail", connection);
                connection.Open();
                command.Parameters.AddWithValue("@pid", pid);
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
    }
}
