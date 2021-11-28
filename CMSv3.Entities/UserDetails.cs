using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class UserDetails
    {
        private int _UserID;
        private string _FullName;
        private string _NickName;
        private string _Email;
        private long _Homephone;
        private long _Handphone;
        private long _FaxNo;
        private string _Address;
        private string _City;
        private string _Postcode;
        private int _CountryCode;
        private string _CompanyName;
        private string _CompanyInfo;

        private bool _CompanyNameChecked;
        private bool _NickNameChecked;
        private bool _EmailChecked;
        private bool _HandPhoneChecked;
        private bool _HomePhoneChecked;
        private bool _FaxNoChecked;
        private bool _UserPhotoChecked;
        private bool _AddressChecked;

        
        public int UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }


        public string FullName
        {
            get{
                return _FullName;
            }
            set{
                _FullName = value;
            }
        }

        public string NickName
        {
            get
            {
                return _NickName;
            }
            set
            {
                _NickName = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }



        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }

        public string Postcode
        {
            get
            {
                return _Postcode;
            }
            set
            {
                _Postcode = value;
            }
        }


        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                _CompanyName = value;
            }
        }

        public string CompanyInfo
        {
            get
            {
                return _CompanyInfo;
            }
            set
            {
                _CompanyInfo = value;
            }
        }



        public int CountryCode
        {
            get
            {
                return _CountryCode;
            }
            set
            {
                _CountryCode = value;
            }
        }


        public long Handphone
        {
            get
            {
                return _Handphone;
            }
            set
            {
                _Handphone = value;
            }
        }

        public long  Homephone
        {
            get
            {
                return _Homephone;
            }
            set
            {
                _Homephone = value;
            }
        }


        public long FaxNo
        {
            get
            {
                return _FaxNo;
            }
            set
            {
                _FaxNo = value;
            }
        }




        public bool CompanyNameChecked
        {
            get { return _CompanyNameChecked; }
            set { _CompanyNameChecked = value; }
        }

        public bool NickNameChecked
        {
            get { return _NickNameChecked; }
            set { _NickNameChecked = value;}
        }

        public bool EmailChecked
        {
            get { return _EmailChecked; }
            set { _EmailChecked = value; }
        }

        public bool HandPhoneChecked
        {
            get { return _HandPhoneChecked; }
            set { _HandPhoneChecked = value; }
        }

        public bool HomePhoneChecked
        {
            get { return _HomePhoneChecked; }
            set { _HomePhoneChecked = value; }
        }

        public bool FaxNoChecked
        {
            get { return _FaxNoChecked; }
            set { _FaxNoChecked = value; }
        }

        public bool UserPhotoChecked
        {
            get { return _UserPhotoChecked; }
            set { _UserPhotoChecked = value; }
        }

        public bool AddressChecked
        {
            get { return _AddressChecked; }
            set { _AddressChecked = value; }
        }


        
    }
}
