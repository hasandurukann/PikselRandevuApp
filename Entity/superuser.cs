namespace Entity
{
    using System;

    public class superuser
    {
        private bool cop;
        private string explanation;
        private int rid;
        private int sid;
        private int uid;

        public bool _cop
        {
            get { return  
                this.cop;
            }
            set
            {
                this.cop = value;
            }
        }

        public string _explanation
        {
            get { return  
                this.explanation;
            }
            set
            {
                this.explanation = value;
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

        public int _sid
        {
            get { return  
                this.sid;
            }
            set
            {
                this.sid = value;
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
