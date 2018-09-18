namespace Entity
{
    using System;

    public class settings
    {
        private int id;
        private int usageper;

        public int Id
        {
            get { return  
                this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Usageper
        {
            get { return  
                this.usageper;
            }
            set
            {
                this.usageper = value;
            }
        }
    }
}
