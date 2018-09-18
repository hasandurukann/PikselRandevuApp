namespace Entity
{
    using System;

    public class external_reservation
    {
        private DateTime _exdate;
        private string additional_request;
        private string biological;
        private string chemical;
        private string damage;
        private string enviroment;
        private int id;
        private int pid;
        private string provide;
        private int reservation_day;
        private string reservation_end;
        private int reservation_month;
        private string reservation_start;
        private int reservation_year;
        private int rid;
        private int samples;
        private int statu;
        private int uid;
        private bool w_eng, w_cons;

        public string _additional_request
        {
            get { return  
                this.additional_request;
            }
            set
            {
                this.additional_request = value;
            }
        }

        public string _biological
        {
            get { return  
                this.biological;
            }
            set
            {
                this.biological = value;
            }
        }

        public string _chemical
        {
            get { return  
                this.chemical;
            }
            set
            {
                this.chemical = value;
            }
        }

        public string _damage
        {
            get { return  
                this.damage;
            }
            set
            {
                this.damage = value;
            }
        }

        public string _enviroment
        {
            get { return  
                this.enviroment;
            }
            set
            {
                this.enviroment = value;
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

        public string _provide
        {
            get { return  
                this.provide;
            }
            set
            {
                this.provide = value;
            }
        }

        public int _reservation_day
        {
            get { return  
                this.reservation_day;
            }
            set
            {
                this.reservation_day = value;
            }
        }

        public string _reservation_end
        {
            get { return  
                this.reservation_end;
            }
            set
            {
                this.reservation_end = value;
            }
        }

        public int _reservation_month
        {
            get { return  
                this.reservation_month;
            }
            set
            {
                this.reservation_month = value;
            }
        }

        public string _reservation_start
        {
            get { return  
                this.reservation_start;
            }
            set
            {
                this.reservation_start = value;
            }
        }

        public int _reservation_year
        {
            get { return  
                this.reservation_year;
            }
            set
            {
                this.reservation_year = value;
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

        public int _samples
        {
            get { return  
                this.samples;
            }
            set
            {
                this.samples = value;
            }
        }

        public int _statu
        {
            get { return  
                this.statu;
            }
            set
            {
                this.statu = value;
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

        public DateTime exdate
        {
            get { return  
                this._exdate;
            }
            set
            {
                this._exdate = value;
            }
        }

        public bool W_eng
        {
            get
            {
                return w_eng;
            }

            set
            {
                w_eng = value;
            }
        }

        public bool W_cons
        {
            get
            {
                return w_cons;
            }

            set
            {
                w_cons = value;
            }
        }
    }
}
