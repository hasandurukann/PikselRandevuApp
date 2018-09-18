namespace Facade
{
    using Entity;
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Text;

    public class SystemMail
    {
        public static string ResetPassword(user mdl, Entity.SystemMail mdl2)
        {
            try
            {
                string userName = "facility@unam.bilkent.edu.tr";
                string password = "z89t36b";
                StringBuilder builder = new StringBuilder();
                builder.Append("<h4>Your username : </h4>" + mdl._username + " </br> Your password : " + mdl._password);
                NetworkCredential credential = new NetworkCredential(userName, password);
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient("asmtp.bilkent.edu.tr", 0x19);
                message.From = new MailAddress("facility@unam.bilkent.edu.tr");
                message.To.Add(new MailAddress(mdl._email));
                message.Subject = mdl2._mailHeader;
                message.Body = builder.ToString();
                message.IsBodyHtml = mdl2._bodyHtml;
                client.EnableSsl = mdl2._ssl;
                client.UseDefaultCredentials = mdl2._credentials;
                client.Credentials = credential;
                client.Send(message);
                return "Reset password link has been sent to your email address";
            }
            catch (Exception exception)
            {
                return ("Error Occured:" + exception.Message.ToString());
            }
        }

        public static void SendMail(Entity.SystemMail mdl)
        {
        }

        public static void SendMail2(Entity.SystemMail mdl)
        {
        }

        public static void SendMailToplu(Entity.SystemMail mdl)
        {
        }
    }
}
