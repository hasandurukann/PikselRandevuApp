namespace Entity
{
    using System;

    public class teams
    {
        private string teamname;
        private int tid;

        public string Teamname
        {
            get { return  
                this.teamname;
            }
            set
            {
                this.teamname = value;
            }
        }

        public int Tid
        {
            get { return  
                this.tid;
            }
            set
            {
                this.tid = value;
            }
        }
    }
}
