namespace Entity
{
    using System;

    public class engineers
    {
        private int eid;
        private int rid;
        private int uid;

        public int _eid
        {
            get { return  
                this.eid;
            }
            set
            {
                this.eid = value;
            }
        }

        public int _rid
        {
            get { return  
                this.rid;
            }
            set
            {
                this.rid = value;
            }
        }

        public int _uid
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
