namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class Trainings_BL
    {
        public static List<teams> Team_List()
        {
            List<teams> list2;
            try
            {
                List<teams> list = new List<teams>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_TrainingTeamList", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teams item = new teams
                    {
                        Teamname = reader["name"].ToString(),
                        Tid = int.Parse(reader["tid"].ToString())
                    };
                    list.Add(item);
                }
                command.Dispose();
                connection.Close();
                list2 = list;
            }
            catch
            {
                throw;
            }
            return list2;
        }

        public static List<resources> EngineerResources_List(int euid)
        {
            List<resources> list2;
            try
            {
                List<resources> list = new List<resources>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_EngineerResourceList", connection);
                command.Parameters.AddWithValue("@uid", euid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    resources item = new resources
                    {
                        _resource_id = Convert.ToInt32(reader["rid"]),
                        _resource_name = reader["resource_name"].ToString()
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

        public static List<Trainings> EngineerTraining_List(int euid)
        {
            List<Trainings> list2;
            try
            {
                List<Trainings> list = new List<Trainings>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_EngineerTraining_List", connection);
                command.Parameters.AddWithValue("@uid", euid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Trainings item = new Trainings
                    {
                        Device_Id = (int)reader["Device_Id"],
                        id = (int)reader["id"],
                        Training_content = reader["Training_content"].ToString(),
                        Training_name = reader["Training_name"].ToString(),
                        Training_status = (int)reader["Training_status"],
                        Price = (decimal)reader["price"]
                    };
                    item.Resorces = Resources_One(item.Device_Id);
                    list.Add(item);
                }
                command.Dispose();
                connection.Close();
                list2 = list;
            }
            catch
            {
                throw;
            }
            return list2;
        }

        public static List<Trainings> EngResTrainingReq_List(int eid)
        {
            List<Trainings> list2;
            try
            {
                List<Trainings> list = new List<Trainings>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_EngResTrainingReqListGet", connection);
                command.Parameters.AddWithValue("@eid", eid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Trainings item = new Trainings
                    {
                        Resorces = new resources(),
                        Training_content = reader["adsoyad"].ToString(),
                        id = (int)reader["id"]
                    };
                    item.Resorces._resource_id = int.Parse(reader["rid"].ToString());
                    item.Resorces._resource_name = reader["resource_name"].ToString();
                    item.Training_name = reader["Training_name"].ToString();
                    item.Price = (decimal)reader["price"];
                    item.Training_date = (DateTime)reader["reqdate"];
                    item.User_Training_Mail = reader["email"].ToString();
                    item.UserTraReqUserID = int.Parse(reader["requid"].ToString());
                    item.UserTraReqTraID = int.Parse(reader["reqtid"].ToString());
                    item.TraReqSonuc = int.Parse(reader["reqsonuc"].ToString());
                    list.Add(item);
                }
                command.Dispose();
                connection.Close();
                list2 = list;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return list2;
        }

        public static Trainings EngResTrainingReq_One(int tid)
        {
            Trainings trainings2;
            try
            {
                Trainings trainings = new Trainings();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_EngTraReqGetOne", connection);
                command.Parameters.AddWithValue("@utid", tid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    trainings.Resorces = new resources();
                    trainings.Training_content = reader["adsoyad"].ToString();
                    trainings.Training_name = reader["traname"].ToString();
                    trainings.UserTraReqTraID = int.Parse(reader["reqtid"].ToString());
                    trainings.UserTraReqUserID = int.Parse(reader["requid"].ToString());
                }
                command.Dispose();
                connection.Close();
                trainings2 = trainings;
            }
            catch (Exception)
            {
                throw;
            }
            return trainings2;
        }

        public static bool EngResTrainingReqSonucUpdate(int trid, int sonuc)
        {
            try
            {
                Trainings trainings = new Trainings();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_TrainingReqSonucUpdate", connection);
                command.Parameters.AddWithValue("@tid", trid);
                command.Parameters.AddWithValue("@sonuc", sonuc);
                command.CommandType = CommandType.StoredProcedure;
                int num = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return (num > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static int MakeTraining_Req(int tid, int uid, int piuid)
        {
            int num = 0;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_MakeTrainingReq", connection);
                command.Parameters.AddWithValue("@uid", uid);
                command.Parameters.AddWithValue("@tid", tid);
                command.Parameters.AddWithValue("@piuid", piuid);
                command.CommandType = CommandType.StoredProcedure;
                num = command.ExecuteNonQuery();
                connection.Close();
                command.Dispose();
                return num;
            }
            catch
            {
                return -1;
            }
        }

        public static List<Trainings> PITraining_List(int pid)
        {
            List<Trainings> list2;
            try
            {
                List<Trainings> list = new List<Trainings>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_PITrainingListGet", connection);
                command.Parameters.AddWithValue("@pid", pid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Trainings item = new Trainings
                    {
                        Resorces = new resources(),
                        Training_content = reader["adsoyad"].ToString(),
                        id = (int)reader["id"]
                    };
                    item.Resorces._resource_id = int.Parse(reader["rid"].ToString());
                    item.Resorces._resource_name = reader["resource_name"].ToString();
                    item.Training_name = reader["Training_name"].ToString();
                    item.Price = (decimal)reader["price"];
                    item.Training_status = reader.IsDBNull(6) ? -2 : ((int)reader["kalanegitimsure"]);
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
        public static List<Trainings> PITraining_ListByUser(int pid, int uid)
        {
            List<Trainings> list2;
            try
            {
                List<Trainings> list = new List<Trainings>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_PITrainingListGetByUser", connection);
                command.Parameters.AddWithValue("@pid", pid);
                command.Parameters.AddWithValue("@uid", uid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Trainings item = new Trainings
                    {
                        Resorces = new resources(),
                        Training_content = reader["adsoyad"].ToString(),
                        id = (int)reader["id"]
                    };
                    item.Resorces._resource_id = int.Parse(reader["rid"].ToString());
                    item.Resorces._resource_name = reader["resource_name"].ToString();
                    item.Training_name = reader["Training_name"].ToString();
                    item.Price = (decimal)reader["price"];
                    item.Training_status = reader.IsDBNull(6) ? -2 : ((int)reader["kalanegitimsure"]);
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
        public static List<Trainings> PITrainingReq_List(int pid)
        {
            List<Trainings> list2;
            try
            {
                List<Trainings> list = new List<Trainings>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_PITrainingReqListGet", connection);
                command.Parameters.AddWithValue("@pid", pid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Trainings item = new Trainings
                    {
                        Resorces = new resources(),
                        Training_content = reader["adsoyad"].ToString(),
                        id = (int)reader["id"]
                    };
                    item.Resorces._resource_id = int.Parse(reader["rid"].ToString());
                    item.Resorces._resource_name = reader["resource_name"].ToString();
                    item.Training_name = reader["Training_name"].ToString();
                    item.Price = (decimal)reader["price"];
                    item.Training_date = (DateTime)reader["reqdate"];
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
        public static List<Trainings> PITrainingReq_ListByUser(int pid, int uid)
        {
            List<Trainings> list2;
            try
            {
                List<Trainings> list = new List<Trainings>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_PITrainingReqListGetByUser", connection);
                command.Parameters.AddWithValue("@pid", pid);
                command.Parameters.AddWithValue("@uid", uid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Trainings item = new Trainings
                    {
                        Resorces = new resources(),
                        Training_content = reader["adsoyad"].ToString(),
                        id = (int)reader["id"]
                    };
                    item.Resorces._resource_id = int.Parse(reader["rid"].ToString());
                    item.Resorces._resource_name = reader["resource_name"].ToString();
                    item.Training_name = reader["Training_name"].ToString();
                    item.Price = (decimal)reader["price"];
                    item.Training_date = reader["reqdate"].ToString()!=""? (DateTime?)reader["reqdate"]:null;
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

        //public static List<Engineer_Mail> Resource_Engineer_Mail_List(int resource_id)
        //{
        //    List<Engineer_Mail> list2;
        //    try
        //    {
        //        SqlConnection connection = new SqlConnection(islem.ConnectionString);
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("Sp_Resource_Engineer_Mail_List", connection)
        //        {
        //            CommandType = CommandType.StoredProcedure
        //        };
        //        command.Parameters.AddWithValue("@rid", resource_id);
        //        SqlDataReader reader = command.ExecuteReader();
        //        List<Engineer_Mail> list = new List<Engineer_Mail>();
        //        while (reader.Read())
        //        {
        //            Engineer_Mail item = new Engineer_Mail
        //            {
        //                EngineerName = reader["user_fullname"].ToString(),
        //                MailAdress = reader["user_email"].ToString()
        //            };
        //            list.Add(item);
        //        }
        //        command.Dispose();
        //        connection.Close();
        //        list2 = list;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return list2;
        //}

        public static List<resources> Resources_List()
        {
            List<resources> list2;
            try
            {
                List<resources> list = new List<resources>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_ResourceListele", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    resources item = new resources
                    {
                        _resource_id = Convert.ToInt32(reader["rid"]),
                        _resource_name = reader["resource_name"].ToString()
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

        public static resources Resources_One(int device_id)
        {
            resources resources2;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_Resource_One", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@resource_id", device_id);
                SqlDataReader reader = command.ExecuteReader();
                resources resources = new resources();
                if (reader.Read())
                {
                    resources._resource_id = Convert.ToInt32(reader["rid"]);
                    resources._resource_name = reader["resource_name"].ToString();
                    //resources.MailList = Resource_Engineer_Mail_List(resources._resource_id);
                }
                command.Dispose();
                connection.Close();
                resources2 = resources;
            }
            catch (Exception)
            {
                throw;
            }
            return resources2;
        }

        public static int Training_Create(Trainings training)
        {
            int num = 0;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_Training_Create", connection);
                command.Parameters.AddWithValue("@Device_Id", training.Device_Id);
                command.Parameters.AddWithValue("@Training_content", training.Training_content);
                command.Parameters.AddWithValue("@Training_name", training.Training_name);
                command.Parameters.AddWithValue("@Training_status", training.Training_status);
                command.Parameters.AddWithValue("@price", training.Price);
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

        public static int Training_Delete(int training_id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Training_Delete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@training_id", training_id);
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

        public static List<Trainings> Training_List()
        {
            List<Trainings> list2;
            try
            {
                List<Trainings> list = new List<Trainings>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Training_List", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Trainings item = new Trainings
                    {
                        Device_Id = (int)reader["Device_Id"],
                        id = (int)reader["id"],
                        Training_content = reader["Training_content"].ToString(),
                        Training_name = reader["Training_name"].ToString(),
                        Training_status = (int)reader["Training_status"],
                        Price = (decimal)reader["price"]
                    };
                    item.Resorces = Resources_One(item.Device_Id);
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

        public static Trainings Training_One(int training_id)
        {
            Trainings trainings2;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Training_One", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@training_id", training_id);
                SqlDataReader reader = command.ExecuteReader();
                Trainings trainings = new Trainings();
                if (reader.Read())
                {
                    trainings.Device_Id = (int)reader["Device_Id"];
                    trainings.id = (int)reader["id"];
                    trainings.Training_content = reader["Training_content"].ToString();
                    trainings.Training_name = reader["Training_name"].ToString();
                    trainings.Training_status = (int)reader["Training_status"];
                    trainings.Price = (decimal)reader["price"];
                    trainings.Resorces = Resources_One(trainings.Device_Id);
                }
                command.Dispose();
                connection.Close();
                trainings2 = trainings;
            }
            catch (Exception)
            {
                throw;
            }
            return trainings2;
        }

        public static int Training_Status(int id, int status)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Training_Status", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Training_status", status);
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

        public static int Training_Update(Trainings training)
        {
            int num2;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Training_Update", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Device_Id", training.Device_Id);
                command.Parameters.AddWithValue("@Training_content", training.Training_content);
                command.Parameters.AddWithValue("@Training_name", training.Training_name);
                command.Parameters.AddWithValue("@Training_status", training.Training_status);
                command.Parameters.AddWithValue("@price", training.Price);
                command.Parameters.AddWithValue("@id", training.id);
                int num = command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                num2 = num;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num2;
        }

        public static List<Trainings> TrainingReq_List(int user_id)
        {
            List<Trainings> list2;
            try
            {
                List<Trainings> list = new List<Trainings>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_TrainingReqListGet", connection);
                command.Parameters.AddWithValue("@uid", user_id);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Trainings item = new Trainings
                    {
                        Resorces = new resources(),
                        Training_content = reader["sira"].ToString(),
                        id = (int)reader["id"]
                    };
                    item.Resorces._resource_id = int.Parse(reader["rid"].ToString());
                    item.Resorces._resource_name = reader["resource_name"].ToString();
                    item.Training_name = reader["Training_name"].ToString();
                    item.Price = (decimal)reader["price"];
                    item.TraReqSonuc = reader.IsDBNull(8) ? -1 : int.Parse(reader["TraReqSonuc"].ToString());
                    item.Training_status = reader.IsDBNull(6) ? -2 : ((int)reader["kalanegitimsure"]);
                    item.PiListe = users.UserProjePIListe(user_id);
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

        public static List<Engineer_Mail> TrainingRequestEngineerMail_List(int tid)
        {
            List<Engineer_Mail> list2;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_TrainingResourceEngineer", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@tid", tid);
                SqlDataReader reader = command.ExecuteReader();
                List<Engineer_Mail> list = new List<Engineer_Mail>();
                while (reader.Read())
                {
                    Engineer_Mail item = new Engineer_Mail
                    {
                        EngineerName = reader["user_fullname"].ToString(),
                        MailAdress = reader["user_email"].ToString()
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

        public static List<user> User_List()
        {
            List<user> list2;
            try
            {
                List<user> list = new List<user>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Training_User_List", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user item = new user
                    {
                        _uid = Convert.ToInt32(reader["uid"]),
                        _fullname = reader["user_fullname"].ToString(),
                        _user_active = Convert.ToInt32(reader["user_active"]),
                        _user_level = Convert.ToInt32(reader["user_level"]),
                        _department = reader["user_department"].ToString(),
                        _email = reader["user_email"].ToString()
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

        public static int User_Training_Create(User_Training training)
        {
            int num2;
            int num = 0;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_User_Training_Create", connection);
                command.Parameters.AddWithValue("@training_id", training.training_id);
                command.Parameters.AddWithValue("@engineer_id", training.team_id);
                command.Parameters.AddWithValue("@user_id", training.user_id);
                command.Parameters.AddWithValue("@training_date", training.training_date);
                command.Parameters.AddWithValue("@training_periot", training.training_periot);
                command.Parameters.AddWithValue("@training_content", training.training_content);
                command.Parameters.AddWithValue("@training_status", training.training_status);
                command.Parameters.AddWithValue("@pi_id", training.pi_id);
                command.CommandType = CommandType.StoredProcedure;
                num = command.ExecuteNonQuery();
                connection.Close();
                command.Dispose();
                num2 = num;
            }
            catch (Exception)
            {
                throw;
            }
            return num2;
        }

        public static int User_Training_Delete(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Training_Delete", connection)
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

        public static List<User_Training> User_Training_List()
        {
            List<User_Training> list2;
            try
            {
                List<User_Training> list = new List<User_Training>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Training_List", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User_Training tra = new User_Training
                    {
                        id = (int)reader["id"],
                        team_id = (int)reader["engineer_id"],
                        training_content = reader["training_content"].ToString(),
                        training_date = new DateTime?((DateTime)reader["training_date"]),
                        training_id = (int)reader["training_id"],
                        training_periot = (int)reader["training_periot"],
                        training_status = (int)reader["training_status"],
                        training_res = reader["training_res"].ToString(),
                        user_id = (int)reader["user_id"],
                        
                    };
                    tra.Training = Training_One(tra.training_id);
                    tra.User = (from x in User_List()
                                where x._uid == tra.user_id
                                select x).FirstOrDefault<user>();
                    tra.Team = (from x in Team_List()
                                    where x.Tid == tra.team_id
                                    select x).FirstOrDefault<teams>();
                    list.Add(tra);
                }
                command.Dispose();
                connection.Close();
                list2 = list;
            }
            catch (Exception x)
            {
                throw x;
            }
            return list2;
        }

        public static List<User_Training> User_Training_ListByDevice(int rid)
        {
            List<User_Training> list2;
            try
            {
                List<User_Training> list = new List<User_Training>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Training_ListByRid", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@rid", rid);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User_Training tra = new User_Training
                    {
                        id = (int)reader["id"],
                        team_id = (int)reader["engineer_id"],
                        training_content = reader["training_content"].ToString(),
                        training_date = new DateTime?((DateTime)reader["training_date"]),
                        training_id = (int)reader["training_id"],
                        training_periot = (int)reader["training_periot"],
                        training_status = (int)reader["training_status"],
                        training_res = reader["training_res"].ToString(),
                        user_id = (int)reader["user_id"]
                    };
                    tra.Training = Training_One(tra.training_id);
                    tra.User = (from x in User_List()
                                where x._uid == tra.user_id
                                select x).FirstOrDefault<user>();
                    tra.Team = (from x in Team_List()
                                where x.Tid == tra.team_id
                                select x).FirstOrDefault<teams>();
                    list.Add(tra);
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

        public static List<User_Training> User_Training_ListByUser(int uid)
        {
            List<User_Training> list2;
            try
            {
                List<User_Training> list = new List<User_Training>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Training_ListByUser", connection);
                command.Parameters.AddWithValue("@uid", uid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User_Training tra = new User_Training
                    {
                        id = (int)reader["id"],
                        team_id = (int)reader["engineer_id"],
                        training_content = reader["training_content"].ToString(),
                        training_date = new DateTime?((DateTime)reader["training_date"]),
                        training_id = (int)reader["training_id"],
                        training_periot = (int)reader["training_periot"],
                        training_status = (int)reader["training_status"],
                        training_res = reader["training_res"].ToString(),
                        user_id = (int)reader["user_id"]
                    };
                    tra.Training = Training_One(tra.training_id);
                    tra.User = (from x in User_List()
                                where x._uid == tra.user_id
                                select x).FirstOrDefault<user>();
                    tra.Team = (from x in Team_List()
                                where x.Tid == tra.team_id
                                select x).FirstOrDefault<teams>();
                    list.Add(tra);
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

        public static List<User_Training> User_Training_ListFiltre(int uid, int rid)
        {
            List<User_Training> list2;
            try
            {
                List<User_Training> list = new List<User_Training>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Training_ListFiltre", connection);
                command.Parameters.AddWithValue("@uid", uid);
                command.Parameters.AddWithValue("@rid", rid);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User_Training tra = new User_Training
                    {
                        id = (int)reader["id"],
                        team_id = (int)reader["engineer_id"],
                        training_content = reader["training_content"].ToString(),
                        training_date = new DateTime?((DateTime)reader["training_date"]),
                        training_id = (int)reader["training_id"],
                        training_periot = (int)reader["training_periot"],
                        training_status = (int)reader["training_status"],
                        training_res = reader["training_res"].ToString(),
                        user_id = (int)reader["user_id"]
                    };
                    tra.Training = Training_One(tra.training_id);
                    tra.User = (from x in User_List()
                                where x._uid == tra.user_id
                                select x).FirstOrDefault<user>();
                    tra.Team = (from x in Team_List()
                                where x.Tid == tra.team_id
                                select x).FirstOrDefault<teams>();
                    list.Add(tra);
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

        public static User_Training User_Training_One(int id)
        {
            User_Training training;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Training_One", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                User_Training tra = new User_Training();
                if (reader.Read())
                {
                    tra.id = (int)reader["id"];
                    tra.team_id = (int)reader["engineer_id"];
                    tra.training_content = reader["training_content"].ToString();
                    tra.training_date = new DateTime?((DateTime)reader["training_date"]);
                    tra.training_id = (int)reader["training_id"];
                    tra.training_periot = (int)reader["training_periot"];
                    tra.training_status = (int)reader["training_status"];
                    tra.user_id = (int)reader["user_id"];
                    tra.Training = Training_One(tra.training_id);
                    tra.User = (from x in User_List()
                                where x._uid == tra.user_id
                                select x).FirstOrDefault<user>();
                    tra.Team = (from x in Team_List()
                                where x.Tid == tra.team_id
                                select x).FirstOrDefault<teams>();
                }
                command.Dispose();
                connection.Close();
                training = tra;
            }
            catch (Exception)
            {
                throw;
            }
            return training;
        }

        public static int User_Training_Status(int id, int status)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_User_Training_Status", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@training_status", status);
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

        public static int User_Training_Update(User_Training training)
        {
            int num = 0;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_User_Training_Update", connection);
                command.Parameters.AddWithValue("@training_id", training.training_id);
                command.Parameters.AddWithValue("@engineer_id", training.team_id);
                command.Parameters.AddWithValue("@user_id", training.user_id);
                command.Parameters.AddWithValue("@training_date", training.training_date);
                command.Parameters.AddWithValue("@training_periot", training.training_periot);
                command.Parameters.AddWithValue("@training_content", training.training_content);
                command.Parameters.AddWithValue("@id", training.id);
                command.Parameters.AddWithValue("@pi_id", training.pi_id);
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
    }
}
