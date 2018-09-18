namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class tickets
    {

        public int active { get; set; }

        public DateTime mdate { get; set; }

        public string Mesaj { get; set; }

        public user Owner { get; set; }

        public int Sid { get; set; }

        public int statu { get; set; }

        public string Subject { get; set; }

        public ticket_msg Ticket_Mesaj_Tek { get; set; }

        public List<ticket_msg> TicketMessages { get; set; }

        public int Uid { get; set; }
    }
}
