namespace Entity
{
    using System;
    using System.Collections.Generic;

    public class SystemMail
    {
        private string adreslist;
        private string attchpath;
        private bool bodyHtml;
        private bool credentials;
        private string mailAddress;
        private string mailBody;
        private string mailHeader;
        private string password;
        private int port;
        private string smtp;
        private bool ssl;
        private string user_email;

        public bool _bodyHtml
        {
            get { return  
                this.bodyHtml;
            }
            set
            {
                this.bodyHtml = value;
            }
        }

        public bool _credentials
        {
            get { return  
                this.credentials;
            }
            set
            {
                this.credentials = value;
            }
        }

        public string _mailAddress
        {
            get { return  
                this.MailAddress;
            }
            set
            {
                this.MailAddress = value;
            }
        }

        public string _mailBody
        {
            get { return  
                this.MailBody;
            }
            set
            {
                this.MailBody = value;
            }
        }

        public string _mailHeader
        {
            get { return  
                this.MailHeader;
            }
            set
            {
                this.MailHeader = value;
            }
        }

        public string _password
        {
            get { return  
                this.Password;
            }
            set
            {
                this.Password = value;
            }
        }

        public int _port
        {
            get { return  
                this.port;
            }
            set
            {
                this.port = value;
            }
        }

        public string _smtp
        {
            get { return  
                this.Smtp;
            }
            set
            {
                this.Smtp = value;
            }
        }

        public bool _ssl
        {
            get { return  
                this.ssl;
            }
            set
            {
                this.ssl = value;
            }
        }

        public string _user_email
        {
            get { return  
                this.User_email;
            }
            set
            {
                this.User_email = value;
            }
        }

        public string Adreslist
        {
            get { return  
                this.adreslist;
            }
            set
            {
                this.adreslist = value;
            }
        }

        public string Attchpath
        {
            get { return  
                this.attchpath;
            }
            set
            {
                this.attchpath = value;
            }
        }

        public string MailAddress
        {
            get { return  
                this.mailAddress;
            }
            set
            {
                this.mailAddress = value;
            }
        }

        public string MailBody
        {
            get { return  
                this.mailBody;
            }
            set
            {
                this.mailBody = value;
            }
        }

        public string MailHeader
        {
            get { return  
                this.mailHeader;
            }
            set
            {
                this.mailHeader = value;
            }
        }

        public string Password
        {
            get { return  
                this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string Smtp
        {
            get { return  
                this.smtp;
            }
            set
            {
                this.smtp = value;
            }
        }

        public string User_email
        {
            get { return  
                this.user_email;
            }
            set
            {
                this.user_email = value;
            }
        }
    }
}
