namespace Facade
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI.WebControls;

    public class fonksiyon
    {
        public SqlConnection baglan() => new SqlConnection(islem.ConnectionString);

        public int cmd(string sqlcumle)
        {
            SqlConnection connection = this.baglan();
            connection.Open();
            SqlCommand command = new SqlCommand(sqlcumle, connection);
            int num = 0;
            try
            {
                num = command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                throw new Exception(exception.Message + " (" + sqlcumle + ")");
            }
            command.Dispose();
            connection.Close();
            connection.Dispose();
            return num;
        }

        public string DocumentEkle(FileUpload fufile, TextBox adi, string dosyayolu)
        {
            int num = new Random().Next(0x186a0, 0xf423f);
            string str = "";
            string str2 = null;
            if (fufile.HasFile)
            {
                str = fufile.PostedFile.FileName.Substring(fufile.PostedFile.FileName.LastIndexOf(".") + 1);
                if (fufile.PostedFile.ContentLength <= 0xf4240)
                {
                    switch (str)
                    {
                        case "doc":
                        case "docx":
                        case "xls":
                        case "xlsx":
                        case "pdf":
                        case "PDF":
                        case "ppt":
                        case "pptx":
                            {
                                object[] objArray1 = new object[] { LinkUrl(adi.Text), "-", num, ".", str };
                                str2 = string.Concat(objArray1);
                                fufile.SaveAs(HttpContext.Current.Server.MapPath(dosyayolu + str2));
                                return str2;
                            }
                    }
                    return "1";
                }
                return "2";
            }
            return "3";
        }

        public DataRow GetDataRow(string sql)
        {
            DataTable table = this.GetDataTable2(sql);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            return table.Rows[0];
        }

        public DataSet GetDataSet(string sql)
        {
            SqlConnection selectConnection = this.baglan();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, selectConnection);
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
            }
            catch (SqlException exception)
            {
                throw new Exception(exception.Message + " (" + sql + ")");
            }
            adapter.Dispose();
            selectConnection.Close();
            selectConnection.Dispose();
            return dataSet;
        }

        public DataTable GetDataTable(string stored_procedure)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = this.baglan();
            connection.Open();
            SqlCommand selectCommand = new SqlCommand(stored_procedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
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
            return dataTable;
        }

        public DataTable GetDataTable2(string sql)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = this.baglan();
            connection.Open();
            SqlCommand selectCommand = new SqlCommand(sql, connection);
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
            return dataTable;
        }

        public static string LinkUrl(string Metin)
        {
            string str = Metin;
            return str.Replace("'", "").Replace("\"", "").Replace("/", "-").Replace("_", "-").Replace(" ", "-").Replace("<", "").Replace(">", "").Replace("&", "").Replace("[", "").Replace("]", "").Replace("ı", "i").Replace("\x00f6", "o").Replace("\x00fc", "u").Replace("ş", "s").Replace("\x00e7", "c").Replace("ğ", "g").Replace("İ", "i").Replace("\x00d6", "o").Replace("\x00dc", "u").Replace("Ş", "s").Replace("\x00c7", "c").Replace("Ğ", "g").Replace("?", "").Replace("%", "").Replace("I", "i").Replace("!", "").Replace("?", "").Replace("%", "").Replace("^", "").Replace("--", "-").Replace("---", "-").Replace(".", "").Replace(":", "").Replace(";", "").Replace("\"", "").Replace("`", "").Replace("+", "").Replace("(", "").Replace(")", "").Replace(",", "").ToLower();
        }

        public string sqlinjeksiyon(string data_text)
        {
            data_text = data_text.Replace("<", "&lt;");
            data_text = data_text.Replace(">", "&gt;");
            data_text = data_text.Replace("[", "&#091;");
            data_text = data_text.Replace("]", "&#093;");
            data_text = data_text.Replace("'", "&#39;");
            data_text = data_text.Replace("ı", "&#305;");
            data_text = data_text.Replace("select", "sel&#101;ct");
            data_text = data_text.Replace("join", "jo&#105;n");
            data_text = data_text.Replace("union", "un&#105;on");
            data_text = data_text.Replace("where", "wh&#101;re");
            data_text = data_text.Replace("insert", "ins&#101;rt");
            data_text = data_text.Replace("delete", "del&#101;te");
            data_text = data_text.Replace("update", "up&#100;ate");
            data_text = data_text.Replace("like", "lik&#101;");
            data_text = data_text.Replace("drop", "dro&#112;");
            data_text = data_text.Replace("create", "cr&#101;ate");
            data_text = data_text.Replace("modify", "mod&#105;fy");
            data_text = data_text.Replace("rename", "ren&#097;me");
            data_text = data_text.Replace("alter", "alt&#101;r");
            data_text = data_text.Replace("cast", "ca&#115;t");
            data_text = data_text.Replace("SELECT", "sel&#101;ct");
            data_text = data_text.Replace("JOIN", "jo&#105;n");
            data_text = data_text.Replace("UNION", "un&#105;on");
            data_text = data_text.Replace("WHERE", "wh&#101;re");
            data_text = data_text.Replace("INSERT", "ins&#101;rt");
            data_text = data_text.Replace("DELETE", "del&#101;te");
            data_text = data_text.Replace("UPDATE", "up&#100;ate");
            data_text = data_text.Replace("LIKE", "lik&#101;");
            data_text = data_text.Replace("DROP", "dro&#112;");
            data_text = data_text.Replace("CREATE", "cr&#101;ate");
            data_text = data_text.Replace("MODIFY", "mod&#105;fy");
            data_text = data_text.Replace("RENAME", "ren&#097;me");
            data_text = data_text.Replace("ALTER", "alt&#101;r");
            data_text = data_text.Replace("CAST", "ca&#115;t");
            data_text = data_text.Replace(" AND", "A&#78;D");
            data_text = data_text.Replace(" and", "a&#110;d");
            data_text = data_text.Replace("</", "");
            data_text = data_text.Replace("\r", "");
            data_text = data_text.Replace("\n", "");
            data_text = data_text.Replace("--", "");
            data_text = data_text.Replace("SHUTDOWN", "SHUTDOW&#77;");
            data_text = data_text.Replace("shutdown", "shutdow&#110;");
            data_text = data_text.Replace("xp_", "xp_&#95;");
            data_text = data_text.Replace("XP_", "XP&#95;");
            data_text = data_text.Replace("EXEC", "&#69;X&#69;C");
            data_text = data_text.Replace("exec", "&#101;x&#101;c");
            data_text = data_text.Replace(" *", " &#42;");
            data_text = data_text.Replace(" SET", " SE&#84;");
            data_text = data_text.Replace(" set", " se&#116;");
            data_text = data_text.Replace("NULL", "NUL&#76;");
            data_text = data_text.Replace(" CG", "");
            data_text = data_text.Replace("$", "&#36;");
            data_text = data_text.Replace("@@", "");
            data_text = data_text.Replace("!", "&#33;");
            data_text = data_text.Replace("text", "t&#101;xt");
            data_text = data_text.Replace("TEXT", "T&#69;XT");
            data_text = data_text.Replace("nvarchar", "nvarcha&#114;");
            data_text = data_text.Replace("NVARCHAR", "NVAR&#67;HAR");
            data_text = data_text.Replace("kill", "ki&#108;l");
            data_text = data_text.Replace("begin", "b&#101;gin");
            data_text = data_text.Replace("BEGIN", "B&#69;GIN");
            data_text = data_text.Replace("TABLE", "T&#65;BLE");
            data_text = data_text.Replace("table", "t&#97;ble");
            data_text = data_text.Replace("Uptade", "&#85;Uptade");
            return data_text;
        }

        public static string sqlinjeksiyon2(string data_text)
        {
            data_text = data_text.Replace("&lt;", "<");
            data_text = data_text.Replace("&gt;", ">");
            data_text = data_text.Replace("&#091;", "[");
            data_text = data_text.Replace("&#093;", "]");
            data_text = data_text.Replace("&#39;", "'");
            data_text = data_text.Replace("&#305;", "ı");
            data_text = data_text.Replace(" A&#78;D", "AND");
            data_text = data_text.Replace(" a&#110;d", "and");
            data_text = data_text.Replace("ı", "i");
            data_text = data_text.Replace("ş", "s");
            data_text = data_text.Replace("Ş", "S");
            data_text = data_text.Replace("İ", "I");
            data_text = data_text.Replace("\x00e7", "c");
            data_text = data_text.Replace("\x00c7", "C");
            data_text = data_text.Replace("ğ", "g");
            data_text = data_text.Replace("Ğ", "G");
            data_text = data_text.Replace("\x00fc", "u");
            data_text = data_text.Replace("\x00dc", "U");
            data_text = data_text.Replace("\x00f6", "o");
            data_text = data_text.Replace("\x00d6", "O");
            return data_text;
        }

        public static string sqlinjeksiyonwebmetod(string data_text)
        {
            data_text = data_text.Replace("<", "&lt;");
            data_text = data_text.Replace(">", "&gt;");
            data_text = data_text.Replace("[", "&#091;");
            data_text = data_text.Replace("]", "&#093;");
            data_text = data_text.Replace("'", "&#39;");
            data_text = data_text.Replace("select", "sel&#101;ct");
            data_text = data_text.Replace("join", "jo&#105;n");
            data_text = data_text.Replace("union", "un&#105;on");
            data_text = data_text.Replace("where", "wh&#101;re");
            data_text = data_text.Replace("insert", "ins&#101;rt");
            data_text = data_text.Replace("delete", "del&#101;te");
            data_text = data_text.Replace("update", "up&#100;ate");
            data_text = data_text.Replace("like", "lik&#101;");
            data_text = data_text.Replace("drop", "dro&#112;");
            data_text = data_text.Replace("create", "cr&#101;ate");
            data_text = data_text.Replace("modify", "mod&#105;fy");
            data_text = data_text.Replace("rename", "ren&#097;me");
            data_text = data_text.Replace("alter", "alt&#101;r");
            data_text = data_text.Replace("cast", "ca&#115;t");
            data_text = data_text.Replace("SELECT", "sel&#101;ct");
            data_text = data_text.Replace("JOIN", "jo&#105;n");
            data_text = data_text.Replace("UNION", "un&#105;on");
            data_text = data_text.Replace("WHERE", "wh&#101;re");
            data_text = data_text.Replace("INSERT", "ins&#101;rt");
            data_text = data_text.Replace("DELETE", "del&#101;te");
            data_text = data_text.Replace("UPDATE", "up&#100;ate");
            data_text = data_text.Replace("LIKE", "lik&#101;");
            data_text = data_text.Replace("DROP", "dro&#112;");
            data_text = data_text.Replace("CREATE", "cr&#101;ate");
            data_text = data_text.Replace("MODIFY", "mod&#105;fy");
            data_text = data_text.Replace("RENAME", "ren&#097;me");
            data_text = data_text.Replace("ALTER", "alt&#101;r");
            data_text = data_text.Replace("CAST", "ca&#115;t");
            data_text = data_text.Replace(" AND", "A&#78;D");
            data_text = data_text.Replace(" and", "a&#110;d");
            data_text = data_text.Replace("</", "");
            data_text = data_text.Replace("\r", "");
            data_text = data_text.Replace("\n", "");
            data_text = data_text.Replace("--", "");
            data_text = data_text.Replace("SHUTDOWN", "SHUTDOW&#77;");
            data_text = data_text.Replace("shutdown", "shutdow&#110;");
            data_text = data_text.Replace("xp_", "xp_&#95;");
            data_text = data_text.Replace("XP_", "XP&#95;");
            data_text = data_text.Replace("EXEC", "&#69;X&#69;C");
            data_text = data_text.Replace("exec", "&#101;x&#101;c");
            data_text = data_text.Replace(" *", " &#42;");
            data_text = data_text.Replace(" SET", " SE&#84;");
            data_text = data_text.Replace(" set", " se&#116;");
            data_text = data_text.Replace("NULL", "NUL&#76;");
            data_text = data_text.Replace(" CG", "");
            data_text = data_text.Replace("$", "&#36;");
            data_text = data_text.Replace("@@", "");
            data_text = data_text.Replace("!", "&#33;");
            data_text = data_text.Replace("text", "t&#101;xt");
            data_text = data_text.Replace("TEXT", "T&#69;XT");
            data_text = data_text.Replace("nvarchar", "nvarcha&#114;");
            data_text = data_text.Replace("NVARCHAR", "NVAR&#67;HAR");
            data_text = data_text.Replace("kill", "ki&#108;l");
            data_text = data_text.Replace("begin", "b&#101;gin");
            data_text = data_text.Replace("BEGIN", "B&#69;GIN");
            data_text = data_text.Replace("TABLE", "T&#65;BLE");
            data_text = data_text.Replace("table", "t&#97;ble");
            data_text = data_text.Replace("Uptade", "&#85;Uptade");
            return data_text;
        }

        public static string verigetir(string tabloismi, string keysutun, string satirid, string verialani)
        {
            SqlConnection selectConnection = new SqlConnection(islem.ConnectionString);
            string[] textArray1 = new string[] { "SELECT ", verialani, " FROM ", tabloismi, " Where  ", keysutun, "='", satirid, "'" };
            SqlDataAdapter adapter = new SqlDataAdapter(string.Concat(textArray1), selectConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count.ToString() == "0")
            {
                return "";
            }
            return dataSet.Tables[0].Rows[0][verialani].ToString();
        }

        public static string verigetir(string tabloismi, string keysutun, string satirid, string verialani, string tip)
        {
            SqlConnection selectConnection = new SqlConnection(islem.ConnectionString);
            string[] textArray1 = new string[] { "SELECT ", verialani, " FROM ", tabloismi, " Where  ", keysutun, " like '", satirid, "' " };
            SqlDataAdapter adapter = new SqlDataAdapter(string.Concat(textArray1), selectConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count.ToString() == "0")
            {
                return "";
            }
            return dataSet.Tables[0].Rows[0][verialani].ToString();
        }

        public static DateTime SistemSTGetir()
        {
            DateTime num;
            SqlConnection connection = new SqlConnection(islem.ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_TarihSaatCek", connection);
                command.CommandType = CommandType.StoredProcedure;
                num = Convert.ToDateTime(command.ExecuteScalar().ToString());
            }
            catch
            {
                return DateTime.Now;
            }
            finally
            {
                connection.Close();
            }
            return num;
        }
    }
}
