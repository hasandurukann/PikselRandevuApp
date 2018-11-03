using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Facade
{
    public class RentalStore
    {
        public static List<Entity.RentalStore> RentalStoreList()
        {
            List<Entity.RentalStore> list = new List<Entity.RentalStore>();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SP_RentalStoreGET", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Entity.RentalStore item = new Entity.RentalStore
                        {
                            ID = reader.GetInt32(0),
                            Userid = reader.GetInt32(1),
                            Piname = reader.GetString(2),
                            Ad = reader.GetString(3),
                            Tarih = reader.GetDateTime(4),
                            Bedel = reader.GetDecimal(5),
                            Aciklama = reader.GetString(6),
                            Type = reader.GetBoolean(7)
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
        public static Entity.RentalStore RentalStoreGetOne(Entity.RentalStore secim)
        {
            Entity.RentalStore harcama = new Entity.RentalStore();
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SP_RentalStoreGET", connection);
                    command.Parameters.AddWithValue("@id", secim.ID);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        harcama.ID = reader.GetInt32(0);
                        harcama.Userid = reader.GetInt32(1);
                        harcama.Piname = reader.GetString(2);
                        harcama.Ad = reader.GetString(3);
                        harcama.Tarih = reader.GetDateTime(4);
                        harcama.Bedel = reader.GetDecimal(5);
                        harcama.Aciklama = reader.GetString(6);
                        harcama.Type = reader.GetBoolean(7);
                    }
                    return harcama;
                }
            }
            catch
            {
                throw;
            }
            return null;
        }
        public static bool RentalStoreSET(Entity.RentalStore secim)
        {
            bool flag;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = null;
                command = new SqlCommand("SP_RentalStoreSET", connection);
                command.Parameters.AddWithValue("@id", secim.ID);
                command.Parameters.AddWithValue("@userid", secim.Userid);
                command.Parameters.AddWithValue("@ad", secim.Ad);
                command.Parameters.AddWithValue("@tarih", secim.Tarih);
                command.Parameters.AddWithValue("@bedel", secim.Bedel);
                command.Parameters.AddWithValue("@aciklama", secim.Aciklama);
                command.Parameters.AddWithValue("@tip", secim.Type);
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
        public static bool RentalStoreDELETE(Entity.RentalStore secim)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                SqlCommand command = new SqlCommand("SP_RentalStoreDELETE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", secim.ID);
                connection.Open();
                bool sonuc = (command.ExecuteNonQuery() > 0);
                return sonuc;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
