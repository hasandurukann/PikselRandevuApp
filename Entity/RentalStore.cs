using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RentalStore
    {
        int iD, userid;
        bool type;
        string ad, aciklama;
        string piname;
        decimal bedel;
        DateTime tarih;

        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public int Userid
        {
            get
            {
                return userid;
            }

            set
            {
                userid = value;
            }
        }

        public bool Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Ad
        {
            get
            {
                return ad;
            }

            set
            {
                ad = value;
            }
        }

        public string Aciklama
        {
            get
            {
                return aciklama;
            }

            set
            {
                aciklama = value;
            }
        }

        public decimal Bedel
        {
            get
            {
                return bedel;
            }

            set
            {
                bedel = value;
            }
        }

        public DateTime Tarih
        {
            get
            {
                return tarih;
            }

            set
            {
                tarih = value;
            }
        }

        public string Piname
        {
            get
            {
                return piname;
            }

            set
            {
                piname = value;
            }
        }
    }
}
