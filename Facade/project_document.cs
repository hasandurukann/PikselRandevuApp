namespace Facade
{
    using Entity;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class project_document
    {
        public static int Ekle(FileUploads mdl)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            SqlCommand cmd = new SqlCommand("PROJECT_DOCUMENT_EKLE", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@project_documet_yolu", mdl._file_name);
            return islem.yurut(cmd);
        }
    }
}
