namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class resources
    {
        private string CssClass;
        private string explanation;
        private int maxrespi;
        private int maxresuser;
        private int maxsamplenumber;
        private string res_manuel;
        private bool reservation_control;
        private string resource_code;
        private int resource_id;
        private int resource_maxrestime;
        private string resource_name;
        private decimal resource_price;
        private int resource_pricestatus;
        private bool resource_recycle;
        private int resource_status;
        private string resource_url;
        private float resource_withconsumable;
        private float resource_withengineer;
        private DateTime? schfinish;
        private DateTime? schstart;
        private string statu_reason;
        private string workingfinish;
        private string workingstart;
        public decimal discount { get; set; }

        public string _CssClass
        {
            get { return  
                this.CssClass;
            }
            set
            {
                this.CssClass = value;
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

        public string _resource_code
        {
            get { return  
                this.resource_code;
            }
            set
            {
                this.resource_code = value;
            }
        }

        public int _resource_id
        {
            get { return  
                this.resource_id;
            }
            set
            {
                this.resource_id = value;
            }
        }

        public int _resource_maxrestime
        {
            get { return  
                this.resource_maxrestime;
            }
            set
            {
                this.resource_maxrestime = value;
            }
        }

        public string _resource_name
        {
            get { return  
                this.resource_name;
            }
            set
            {
                this.resource_name = value;
            }
        }

        public decimal _resource_price
        {
            get { return  
                this.resource_price;
            }
            set
            {
                this.resource_price = value;
            }
        }

        public int _resource_pricestatus
        {
            get { return  
                this.resource_pricestatus;
            }
            set
            {
                this.resource_pricestatus = value;
            }
        }

        public bool _resource_recycle
        {
            get { return  
                this.resource_recycle;
            }
            set
            {
                this.resource_recycle = value;
            }
        }

        public int _resource_status
        {
            get { return  
                this.resource_status;
            }
            set
            {
                this.resource_status = value;
            }
        }

        public string _resource_url
        {
            get { return  
                this.resource_url;
            }
            set
            {
                this.resource_url = value;
            }
        }

        public float _resource_withconsumable
        {
            get { return  
                this.resource_withconsumable;
            }
            set
            {
                this.resource_withconsumable = value;
            }
        }

        public float _resource_withengineer
        {
            get { return  
                this.resource_withengineer;
            }
            set
            {
                this.resource_withengineer = value;
            }
        }

        public List<Engineer_Mail> MailList { get; set; }

        public int Maxrespi
        {
            get { return  
                this.maxrespi;
            }
            set
            {
                this.maxrespi = value;
            }
        }

        public int Maxresuser
        {
            get { return  
                this.maxresuser;
            }
            set
            {
                this.maxresuser = value;
            }
        }

        public int Maxsamplenumber
        {
            get { return  
                this.maxsamplenumber;
            }
            set
            {
                this.maxsamplenumber = value;
            }
        }

        public string Res_manuel
        {
            get { return  
                this.res_manuel;
            }
            set
            {
                this.res_manuel = value;
            }
        }

        public bool Reservation_control
        {
            get { return  
                this.reservation_control;
            }
            set
            {
                this.reservation_control = value;
            }
        }

        public DateTime? Schfinish
        {
            get { return  
                this.schfinish;
            }
            set
            {
                this.schfinish = value;
            }
        }

        public DateTime? Schstart
        {
            get { return  
                this.schstart;
            }
            set
            {
                this.schstart = value;
            }
        }

        public string Statu_reason
        {
            get { return  
                this.statu_reason;
            }
            set
            {
                this.statu_reason = value;
            }
        }

        public string Workingfinish
        {
            get { return  
                this.workingfinish;
            }
            set
            {
                this.workingfinish = value;
            }
        }

        public string Workingstart
        {
            get { return  
                this.workingstart;
            }
            set
            {
                this.workingstart = value;
            }
        }
    }
}
