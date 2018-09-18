namespace Entity
{
    using System;

    public class kullanim
    {
        private DateTime basla;
        private DateTime bitis;
        private int cihaz_id;
        private int kullanim_id;
        private int pid;
        private string tarihveresid;
        private int user_id;
        private int wcon;
        private int weng;

        public DateTime _basla
        {
            get { return  
                this.basla;
            }
            set
            {
                this.basla = value;
            }
        }

        public DateTime _bitis
        {
            get { return  
                this.bitis;
            }
            set
            {
                this.bitis = value;
            }
        }

        public int _cihaz_id
        {
            get { return  
                this.cihaz_id;
            }
            set
            {
                this.cihaz_id = value;
            }
        }
        public int _kullanim_id
        {
            get { return  
                this.kullanim_id;
            }
            set
            {
                this.kullanim_id = value;
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

        public int _user_id
        {
            get { return  
                this.user_id;
            }
            set
            {
                this.user_id = value;
            }
        }

        public string Tarihveresid
        {
            get { return  
                this.tarihveresid;
            }
            set
            {
                this.tarihveresid = value;
            }
        }

        public int Wcon
        {
            get { return  
                this.wcon;
            }
            set
            {
                this.wcon = value;
            }
        }

        public int Weng
        {
            get { return  
                this.weng;
            }
            set
            {
                this.weng = value;
            }
        }
    }
}
