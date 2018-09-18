namespace Entity
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class User_Training
    {

        public teams Team { get; set; }

        public int team_id { get; set; }

        public int id { get; set; }

        public Trainings Training { get; set; }

        public string training_content { get; set; }

        public DateTime? training_date { get; set; }

        public int training_id { get; set; }

        public int training_periot { get; set; }

        public string training_res { get; set; }

        public int training_status { get; set; }

        public user User { get; set; }

        public int user_id { get; set; }

        public int pi_id { get; set; }
    }
}
