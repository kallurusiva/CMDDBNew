using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class Enquiry
    {

        private string _Name;
        private string _ContactNo;
        private string _Email;
        private string _Subject;
        private string _Message;
        private int _enquiryType;
        private int _Countrycode;


        public string Name
        {
            get { return _Name; }
            set { _Name = value;}
        }

        public string ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        public int enquiryType
        {
            get { return _enquiryType; }
            set { _enquiryType = value; }
        }

        public int Countrycode
        {
            get { return _Countrycode; }
            set { _Countrycode = value; }
        }

        

    }
}
