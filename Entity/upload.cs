namespace Entity
{
    using System;

    public class upload
    {
        private string file_date;
        private string file_name;
        private string file_path;
        private int id;
        private int pid;
        private int uid;

        public string _file_date
        {
            get { return  
                this.file_date;
            }
            set
            {
                this.file_date = value;
            }
        }

        public string _file_name
        {
            get { return  
                this.file_name;
            }
            set
            {
                this.file_name = value;
            }
        }

        public string _file_path
        {
            get { return  
                this.file_path;
            }
            set
            {
                this.file_path = value;
            }
        }

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
