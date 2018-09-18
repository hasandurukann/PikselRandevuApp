namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class project
    {
        public static bool BalanceCheckWithProjectID(int pid)
        {
            try
            {
                int num = 0;
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_BalanceCheckWithProjectID", connection);
                command.Parameters.AddWithValue("@pid", pid);
                command.CommandType = CommandType.StoredProcedure;
                num = (int)command.ExecuteScalar();
                connection.Close();
                command.Dispose();
                return (num > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DataTable BalanceRepDetay(int utype, int btype)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_BalanceRepDetay", connection);
                selectCommand.Parameters.AddWithValue("@utype", utype);
                selectCommand.Parameters.AddWithValue("@btype", btype);
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

        public static List<Entity.project> PIProjectListForPayment(int uid)
        {
            List<Entity.project> list = new List<Entity.project>();
            Entity.project item = null;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("SP_PIProjeGetir", connection);
            command.Parameters.AddWithValue("@piuid", uid);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                item = new Entity.project
                {
                    _project_title = reader.IsDBNull(1) ? "None" : reader.GetString(1),
                    _pid = reader.IsDBNull(0) ? 0 : reader.GetInt32(0)
                };
                list.Add(item);
            }
            connection.Close();
            command.Dispose();
            return list;
        }

        public static double[] PiBalanceDetayGetir(int project_creator)
        {
            double[] numArray = new double[2];
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SP_PiMevcutBalanceGetir", connection);
            command.Parameters.AddWithValue("@pid", project_creator);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                numArray[0] = reader.IsDBNull(0) ? 0.0 : reader.GetDouble(0);
                numArray[1] = reader.IsDBNull(1) ? 0.0 : reader.GetDouble(1);
            }
            connection.Close();
            command.Dispose();
            return numArray;
        }

        public static decimal PiBalanceMevcutDetayGetir(int project_creator)
        {
            decimal num = new decimal();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("SP_PiMevcutBalanceGetir", connection);
            command.Parameters.AddWithValue("@pid", project_creator);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                num = reader.IsDBNull(1) ? decimal.Zero : reader.GetDecimal(1);
            }
            connection.Close();
            command.Dispose();
            return num;
        }

        public static DataRow PiPaymentGetirByID(int id)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_OdemeGetirByID", connection);
                selectCommand.Parameters.AddWithValue("@id", id);
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
            return dataTable.Rows[0];
        }

        public static bool PiPaymentInsert(int piuid, int pid, int mtip, string adres, string aciklama, string vdaire, string vno, string kurum, string tckimlik, string dekont,decimal bedel)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_OdemeEkle", connection);
                command.Parameters.AddWithValue("@piuid", piuid);
                command.Parameters.AddWithValue("@pid", pid);
                command.Parameters.AddWithValue("@mtip", mtip != 0);
                command.Parameters.AddWithValue("@adres", adres);
                command.Parameters.AddWithValue("@aciklama", aciklama);
                command.Parameters.AddWithValue("@dekont_path", dekont);
                command.Parameters.AddWithValue("@kurumadi", kurum);
                command.Parameters.AddWithValue("@vergidairesi", vdaire);
                command.Parameters.AddWithValue("@vergino", vno);
                command.Parameters.AddWithValue("@tckimlik", tckimlik);
                command.Parameters.AddWithValue("@bedel", bedel);
                command.CommandType = CommandType.StoredProcedure;
                flag = command.ExecuteNonQuery() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public static DataTable PiPaymentListeFiltresiz(string tarih, string piuid)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SP_OdemeListe", connection);
                if (!string.IsNullOrEmpty(piuid))
                {
                    selectCommand.Parameters.AddWithValue("@piuid", int.Parse(piuid));
                }
                if (!string.IsNullOrEmpty(tarih))
                {
                    selectCommand.Parameters.AddWithValue("@tarih", Convert.ToDateTime(tarih));
                }
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

        public static int Project_Ekle(Entity.project mdl)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("PROJE_EKLE", connection);
            command.Parameters.AddWithValue("@PROJECT_CODE", mdl._project_code);
            command.Parameters.AddWithValue("@PROJECT_CREATOR", mdl._project_creator);
            command.Parameters.AddWithValue("@PROJECT_STATUS", mdl._project_status);
            command.Parameters.AddWithValue("@PROJECT_KEY", 0);
            command.Parameters.AddWithValue("@PROJECT_JOINABLE", mdl._project_joinable);
            command.Parameters.AddWithValue("@PROJECT_TITLE", mdl._project_title);
            command.Parameters.AddWithValue("@PROJECT_SUMMARY", mdl._project_summary);
            command.Parameters.AddWithValue("@PROJECT_FUNDING", mdl._project_fundings);
            command.Parameters.AddWithValue("@PROJECT_UNAM_FUNDING", mdl._project_unamfunding);
            command.Parameters.AddWithValue("@PROJECT_START_DATE", mdl._project_startdate);
            command.Parameters.AddWithValue("@PROJECT_END_DATE", mdl._project_enddate);
            command.Parameters.AddWithValue("@PROJECT_DATEOF_CREATE", mdl._project_dateof_create);
            command.Parameters.AddWithValue("@PROJECT_COMMENTS", mdl._project_comments);
            command.Parameters.AddWithValue("@PROJECT_COMPLETED", mdl._project_completed);
            command.Parameters.AddWithValue("@PROJECT_CREATOR_FULLNAME", mdl._project_creatorfullname);
            command.Parameters.AddWithValue("@PROJECT_ACTIVE", mdl._project_active);
            command.Parameters.AddWithValue("@PROJECT_REJECTED_EXPLANATION", mdl._project_rejected_explanation);
            command.Parameters.AddWithValue("@PROJECT_SUSPEND", mdl._project_suspend);
            command.CommandType = CommandType.StoredProcedure;
            num = command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            return num;
        }

        public static DataRow Project_ID_Listele(Entity.project mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("PROJECT_ID_LISTELE", connection);
            selectCommand.Parameters.AddWithValue("@PID", mdl._pid);
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
            connection.Close();
            selectCommand.Dispose();
            return dataTable.Rows[0];
        }

        public static DataTable Project_Resource_Listele(Entity.project mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("PROJECT_RESOURCE_LIST", connection);
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

        public static DataTable Project_Resource_Listele_ALL(Entity.project mdl)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("PROJECT_RESOURCE_LIST_ALL", connection);
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

        public static int Project_Status_Update(Entity.project mdl)
        {
            int num = 0;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("PROJECT_STATUS_UPDATE", connection);
            command.Parameters.AddWithValue("@PID", mdl._pid);
            command.Parameters.AddWithValue("@PROJECT_STATUS", mdl._project_status);
            command.CommandType = CommandType.StoredProcedure;
            num = command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            return num;
        }

        public static decimal ProjeKullanimToplami(int pid)
        {
            decimal num = new decimal();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("SP_PiProjectKullanimSum", connection);
            command.Parameters.AddWithValue("@projeid", pid);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                num = reader.IsDBNull(1) ? decimal.Zero : reader.GetDecimal(1);
            }
            connection.Close();
            command.Dispose();
            return num;
        }

        public static bool ProjeRes_Permission(int uid, int perm)
        {
            try
            {
                int num = 0;
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ResPermission", connection);
                command.Parameters.AddWithValue("@pi_id", uid);
                command.Parameters.AddWithValue("@perm", perm);
                command.CommandType = CommandType.StoredProcedure;
                num = command.ExecuteNonQuery();
                connection.Close();
                command.Dispose();
                return (num > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int ProjeRes_PermissionGET(int pid, int uid)
        {
            int num3;
            try
            {
                int num = 0;
                int num2 = 0;
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ProjectResPermissionSelect", connection);
                command.Parameters.AddWithValue("@pid", pid);
                command.Parameters.AddWithValue("@uid", uid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    num = (reader.GetInt32(0) == 0) ? 0 : reader.GetInt32(0);
                    num2 = reader.GetInt32(1);
                }
                if ((num == 0) && (num2 == -10))
                {
                    return -10;
                }
                connection.Close();
                command.Dispose();
                num3 = num;
            }
            catch (Exception)
            {
                throw;
            }
            return num3;
        }

        public static List<user> ProjeUserListeleByPiuid(int piuid)
        {
            List<user> list = new List<user>();
            user item = null;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("SP_ProjeUserListeleByPiuid", connection);
            command.Parameters.AddWithValue("@piuid", piuid);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                item = new user
                {
                    _fullname = reader.IsDBNull(0) ? "None" : reader.GetString(0),
                    _uid = reader.IsDBNull(1) ? 0 : reader.GetInt32(1)
                };
                list.Add(item);
            }
            connection.Close();
            command.Dispose();
            return list;
        }
    }
}
