using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class webDomain
    {

        private string _PinNo;
        private string _DomainName;
        private string _DomainType;
        private string _DomainPassword;
        private string _FullName;
        private string _MobileNo;
        private string _Email;
        private int _CountryCode;
        private int _LanguageCode;
        private string _PurchasedBy;
        private string _PurchasedTo;
        private string _Company;
        private string _Street;
        private string _City;
        private string _State;
        private string _PostCode;


        public string PinNo
        {
            get {return _PinNo;}
            set {_PinNo = value;}
        }

        public string DomainName
        {
            get { return _DomainName; }
            set { _DomainName = value; }
        }

        public string DomainType
        {
            get { return _DomainType; }
            set { _DomainType = value; }
        }

        public string DomainPassword
        {
            get { return _DomainPassword; }
            set { _DomainPassword = value; }
        }

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }


        public string MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public int CountryCode
        {
            get { return _CountryCode; }
            set { _CountryCode = value; }
        }

        public int LanguageCode
        {
            get { return _LanguageCode; }
            set { _LanguageCode = value; }
        }

        public string PurchasedBy
        {
            get { return _PurchasedBy; }
            set { _PurchasedBy = value; }
        }

        public string PurchasedTo
        {
            get { return _PurchasedTo; }
            set { _PurchasedTo = value; }
        }

        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }


         

        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string PostCode
        {
            get { return _PostCode; }
            set { _PostCode = value; }
        }

    }
}
