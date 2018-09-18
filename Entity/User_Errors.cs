namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class User_Errors
    {

        public int devammi { get; set; }

        public int device_id { get; set; }

        public string error_content { get; set; }

        public DateTime? error_date { get; set; }

        public int error_status { get; set; }

        public int id { get; set; }

        public int pun_period { get; set; }

        public bool pun_type { get; set; }

        public resources Resource { get; set; }

        public List<resources> Resources { get; set; }

        public int status_type { get; set; }

        public user User { get; set; }

        public int user_id { get; set; }
    }
}
