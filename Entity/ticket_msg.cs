namespace Entity
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class ticket_msg
    {

        public int active { get; set; }

        public DateTime mdate { get; set; }

        public string Message { get; set; }

        public int Ownerid { get; set; }

        public user Owners { get; set; }

        public int Replystatu { get; set; }

        public int Sid { get; set; }

        public int Smid { get; set; }

        public int statu { get; set; }

        public string subject { get; set; }

        public tickets Subject_Mesaj { get; set; }
    }
}
