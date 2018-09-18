namespace Entity
{
    using System;

    public class project_user
    {
        private int join_date;
        private int pid;
        private int project_creator;
        private int project_user_status;
        private int puid;
        private int uid;
        private string user_fullname;

        public int _join_date
        {
            get { return  
                this.join_date;
            }
            set
            {
                this.join_date = value;
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

        public int _project_creator
        {
            get { return  
                this.project_creator;
            }
            set
            {
                this.project_creator = value;
            }
        }

        public int _project_user_status
        {
            get { return  
                this.project_user_status;
            }
            set
            {
                this.project_user_status = value;
            }
        }

        public int _puid
        {
            get { return  
                this.puid;
            }
            set
            {
                this.puid = value;
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

        public string _user_fullname
        {
            get { return  
                this.user_fullname;
            }
            set
            {
                this.user_fullname = value;
            }
        }
    }
}
