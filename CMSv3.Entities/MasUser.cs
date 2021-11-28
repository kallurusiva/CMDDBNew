using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    [Serializable]
    public class MasUser
    {

        private string _LoginID;
        private string _Password;
        private string _MID;
        private string _MemberName;
        private string _Phone;
        private string _Email;
        private string _AccountType;
        private double _SMSBalance;
        private string _Company;



       

        public string LoginID
        {
            get { return _LoginID; }
            set { _LoginID = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string MID
        {
            get { return _MID; }
            set { _MID = value; }
        }


        public string MemberName
        {
            get { return _MemberName; }
            set { _MemberName = value; }
        }


        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }


        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string AccountType
        {
            get { return _AccountType; }
            set { _AccountType = value; }
        }


        public double SMSBalance
        {
            get { return _SMSBalance; }
            set { _SMSBalance = value; }
        }

        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        


        
    }
}
