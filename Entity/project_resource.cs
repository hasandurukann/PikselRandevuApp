namespace Entity
{
    using System;

    public class project_resource
    {
        private int id;
        private int pid;
        private int rid;

        public int _id
        {
            get { return  
                this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int _pid
        {
            get { return  
                this.pid;
            }
            set
            {
                this.pid = value;
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
    }
}
