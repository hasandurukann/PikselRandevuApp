﻿
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GlobalClass
/// </summary>
public class GlobalClass
{
    public GlobalClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static SqlConnection OpenConnection(out string message)
    {
        SqlConnection connection;
        message = string.Empty;

        var con = HttpContext.Current.Session["con"];
        if (con != null && con.GetType() == typeof(SqlConnection))
        {
            connection = con as SqlConnection;
        }
        else
        {
            string constring = ConfigurationManager.ConnectionStrings["unam"].ConnectionString;//Take connection string from web.config in encrypted form
            //string decryptcs = Security.Decrypt(encryptcs);//decrypt connectionstring
            connection = new SqlConnection(constring);
            HttpContext.Current.Session["con"] = connection;
        }

        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }

        return connection;
    }

    public static void CloseConnection(out string message)
    {
        message = string.Empty;
        try
        {
            var con = HttpContext.Current.Session["con"];
            if (con != null && con.GetType() == typeof(SqlConnection))
            {
                SqlConnection connection = con as SqlConnection;
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
    }
}
