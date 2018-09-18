namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class Trainings
    {

        public int Device_Id { get; set; }

        public int id { get; set; }

        public List<user> PiListe { get; set; }

        public decimal Price { get; set; }

        public resources Resorces { get; set; }

        public string Training_content { get; set; }

        public DateTime? Training_date { get; set; }

        public string Training_name { get; set; }

        public int Training_status { get; set; }

        public int TraPeriod { get; set; }

        public int TraReqSonuc { get; set; }

        public string User_Training_Mail { get; set; }

        public int UserTraReqTraID { get; set; }

        public int UserTraReqUserID { get; set; }
    }
}
