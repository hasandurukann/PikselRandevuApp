namespace Facade
{
    using Entity;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Survey
    {
        public static void Survey_Ekle(survey mdl)
        {
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SURVEY_INSERT", connection);
                command.Parameters.AddWithValue("@uid", mdl.uid);
                command.Parameters.AddWithValue("@analysis", mdl.survey_analysis);
                command.Parameters.AddWithValue("@superuser", mdl.survey_superuser);
                command.Parameters.AddWithValue("@provided", mdl.survey_provided);
                command.Parameters.AddWithValue("@comment", mdl.survey_comment);
                command.Parameters.AddWithValue("@quality", mdl.survey_quality);
                command.Parameters.AddWithValue("@improve", mdl.survey_improve);
                command.Parameters.AddWithValue("@date", mdl.survey_date);
                command.Parameters.AddWithValue("@status", mdl.survey_status);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
