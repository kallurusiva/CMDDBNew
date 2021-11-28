using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class Events
    {
        
        private int _EventID;
        private string _EventTitle;
        private string _EventContent;
        private int _UserID;
        private DateTime _EventDateFROM;
        private DateTime _EventDateTO;
        private DateTime _ModifiedDate;
        private int _Deleted;


        public int EventID
        {
            get { return _EventID; }
            set { _EventID = value; }
        }

        public string EventTitle
        {
            get { return _EventTitle; }
            set { _EventTitle = value; }
        }

        public string EventContent
        {
            get { return _EventContent; }
            set { _EventContent = value; }
        }

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public DateTime EventDateFROM
        {
            get { return _EventDateFROM; }
            set { _EventDateFROM = value; }
        }

        public DateTime EventDateTO
        {
            get { return _EventDateTO; }
            set { _EventDateTO = value; }
        }

        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }


        public int Deleted
        {
            get { return _Deleted; }
            set { _Deleted = value; }
        }


    }


}
