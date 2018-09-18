namespace Entity
{
    using System;

    public class teammembers
    {
        private int id;
        private int tid;
        private bool tleader;
        private int uid;

        public int Id
        {
            get { return  
                this.id;
            }
            set
            {
                this.id = value;
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

        public bool Tleader
        {
            get { return  
                this.tleader;
            }
            set
            {
                this.tleader = value;
            }
        }

        public int Uid
        {
            get { return  
                this.uid;
            }
            set
            {
                this.uid = value;
            }
        }
    }
}
