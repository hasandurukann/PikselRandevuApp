namespace Facade
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class ticket
    {
        public static List<tickets> Admin_Mesaj_Listesi()
        {
            List<tickets> list2;
            try
            {
                List<tickets> list = new List<tickets>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Admin_Mesaj_Liste", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tickets item = new tickets
                    {
                        Sid = (int)reader["sid"],
                        Uid = (int)reader["uid"],
                        Subject = reader["subject"].ToString(),
                        mdate = (DateTime)reader["mdate"],
                        statu = (int)reader["statu"]
                    };
                    item.Owner = Owners(item.Uid);
                    item.active = (int)reader["active"];
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

        public static int CreateTicket(tickets newt)
        {
            int num = 0;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_CreateTicket", connection);
                command.Parameters.AddWithValue("@uid", newt.Uid);
                command.Parameters.AddWithValue("@sub", newt.Subject);
                command.Parameters.AddWithValue("@mesg", newt.Mesaj);
                command.Parameters.AddWithValue("@mdate", newt.mdate);
                command.Parameters.AddWithValue("@active", newt.active);
                command.CommandType = CommandType.StoredProcedure;
                num = command.ExecuteNonQuery();
                connection.Close();
                command.Dispose();
                return num;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int CreateTicketMessage(ticket_msg newtm)
        {
            int num = 0;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SP_CreateTicketMessage", connection);
                command.Parameters.AddWithValue("@uid", newtm.Ownerid);
                command.Parameters.AddWithValue("@sid", newtm.Sid);
                command.Parameters.AddWithValue("@mesg", newtm.Message);
                command.Parameters.AddWithValue("@rstatu", newtm.Replystatu);
                command.Parameters.AddWithValue("@mdate", newtm.mdate);
                command.CommandType = CommandType.StoredProcedure;
                num = command.ExecuteNonQuery();
                connection.Close();
                command.Dispose();
                return num;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static List<ticket_msg> Mesaj_Listesi(int ownerid)
        {
            List<ticket_msg> list2;
            try
            {
                List<ticket_msg> list = new List<ticket_msg>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Mesaj_Liste", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@oid", ownerid);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ticket_msg item = new ticket_msg
                    {
                        Message = reader["Message"].ToString(),
                        Ownerid = (int)reader["Ownerid"],
                        Replystatu = (int)reader["Replystatu"],
                        Sid = (int)reader["Sid"],
                        Smid = (int)reader["Smid"],
                        subject = reader["subject"].ToString(),
                        mdate = (DateTime)reader["mdate"],
                        statu = (int)reader["statu"],
                        active = (int)reader["active"]
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

        public static List<ticket_msg> Mesaj_Soru_cevap_Listesi(int ticketid)
        {
            List<ticket_msg> list2;
            try
            {
                List<ticket_msg> list = new List<ticket_msg>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Mesaj_Soru_cevap_Listesi", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ticketid", ticketid);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ticket_msg item = new ticket_msg
                    {
                        Message = reader["Message"].ToString(),
                        Ownerid = (int)reader["Ownerid"],
                        Replystatu = (int)reader["Replystatu"],
                        Sid = (int)reader["Sid"],
                        Smid = (int)reader["Smid"],
                        subject = reader["subject"].ToString(),
                        mdate = (DateTime)reader["mdate"]
                    };
                    item.Owners = Owners(item.Ownerid);
                    item.active = (int)reader["active"];
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

        public static user Owners(int ownerid)
        {
            user user2;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Owners_tek", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ownerid", ownerid);
                SqlDataReader reader = command.ExecuteReader();
                user user = new user();
                if (reader.Read())
                {
                    user._fullname = reader["user_fullname"].ToString();
                    user._department = reader["user_department"].ToString();
                    user._uid = Convert.ToInt32(reader["uid"].ToString());
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

        public static tickets Subject_Mesaj(int mesajid)
        {
            tickets tickets2;
            try
            {
                List<ticket_msg> list = new List<ticket_msg>();
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Mesaj_Subject_tek", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@mesajid", mesajid);
                SqlDataReader reader = command.ExecuteReader();
                tickets tickets = new tickets();
                if (reader.Read())
                {
                    tickets.Sid = (int)reader["Sid"];
                    tickets.mdate = (DateTime)reader["mdate"];
                    tickets.Subject = reader["Subject"].ToString();
                    tickets.Uid = (int)reader["Uid"];
                    tickets.statu = (int)reader["statu"];
                    tickets.Mesaj = reader["message"].ToString();
                    tickets.Owner = Owners(tickets.Uid);
                    tickets.active = (int)reader["active"];
                }
                command.Dispose();
                connection.Close();
                tickets2 = tickets;
            }
            catch (Exception)
            {
                throw;
            }
            return tickets2;
        }

        public static int Ticket_Kapat(int sid, int active)
        {
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Ticket_Kapat", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@active", active);
                command.Parameters.AddWithValue("@sid", sid);
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

        public static tickets Ticket_Tek(int ticketid)
        {
            tickets tickets2;
            try
            {
                SqlConnection connection = new SqlConnection(islem.ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Sp_Ticket_tek", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@ticketid", ticketid);
                SqlDataReader reader = command.ExecuteReader();
                tickets tickets = new tickets();
                if (reader.Read())
                {
                    tickets.Sid = (int)reader["sid"];
                    tickets.Subject = reader["Subject"].ToString();
                    tickets.Uid = (int)reader["uid"];
                    tickets.statu = (int)reader["statu"];
                    tickets.Owner = Owners(tickets.Uid);
                    tickets.active = (int)reader["active"];
                }
                command.Dispose();
                connection.Close();
                tickets2 = tickets;
            }
            catch (Exception)
            {
                throw;
            }
            return tickets2;
        }
    }
}
