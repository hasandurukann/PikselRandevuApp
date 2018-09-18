namespace Entity
{
    using System;

    public class survey
    {
        private int _sid;
        private string _survey_analysis;
        private string _survey_comment;
        private DateTime _survey_date;
        private string _survey_improve;
        private string _survey_provided;
        private string _survey_quality;
        private bool _survey_status;
        private string _survey_superuser;
        private int _uid;

        public int sid
        {
            get { return  
                this._sid;
            }
            set
            {
                this._sid = value;
            }
        }

        public string survey_analysis
        {
            get { return  
                this._survey_analysis;
            }
            set
            {
                this._survey_analysis = value;
            }
        }

        public string survey_comment
        {
            get { return  
                this._survey_comment;
            }
            set
            {
                this._survey_comment = value;
            }
        }

        public DateTime survey_date
        {
            get { return  
                this._survey_date;
            }
            set
            {
                this._survey_date = value;
            }
        }

        public string survey_improve
        {
            get { return  
                this._survey_improve;
            }
            set
            {
                this._survey_improve = value;
            }
        }

        public string survey_provided
        {
            get { return  
                this._survey_provided;
            }
            set
            {
                this._survey_provided = value;
            }
        }

        public string survey_quality
        {
            get { return  
                this._survey_quality;
            }
            set
            {
                this._survey_quality = value;
            }
        }

        public bool survey_status
        {
            get { return  
                this._survey_status;
            }
            set
            {
                this._survey_status = value;
            }
        }

        public string survey_superuser
        {
            get { return  
                this._survey_superuser;
            }
            set
            {
                this._survey_superuser = value;
            }
        }

        public int uid
        {
            get { return  
                this._uid;
            }
            set
            {
                this._uid = value;
            }
        }
    }
}
