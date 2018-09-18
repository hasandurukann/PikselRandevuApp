namespace Entity
{
    using System;

    public class FileUploads
    {
        private string file_date;
        private string file_name;
        private string file_original_name;
        private string file_size;
        private int id;
        private int pid;
        private int uid;

        public void projectUpload(int upload_id, int user_id, int pid, string upload_name, string upload_size, string upload_date, string upload_original_name)
        {
            this.id = upload_id;
            this.uid = user_id;
            this.pid = pid;
            this.file_name = upload_name;
            this.file_size = upload_size;
            this.file_date = upload_date;
            this.file_original_name = upload_original_name;
        }

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

        public string _file_original_name
        {
            get { return  
                this.file_original_name;
            }
            set
            {
                this.file_original_name = value;
            }
        }

        public string _file_size
        {
            get { return  
                this.file_size;
            }
            set
            {
                this.file_size = value;
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
