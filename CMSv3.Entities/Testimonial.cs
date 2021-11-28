using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class Testimonial
    {

        private int _TstID;
        private string _TstContent;
        private string _ByName;
        private string _ByCompany;
        private string _ByDesignation;
        private int _CountryCode;
        private bool _Active;



        public int TstID
        {
            get
            {
                return _TstID;
            }
            set
            {
                _TstID = value;
            }
        }

        public string TstContent
        {
            get
            {
                return _TstContent;
            }
            set
            {
                _TstContent = value;
            }
        }

        public string ByName
        {
            get
            {
                return _ByName;
            }
            set
            {
                _ByName = value;
            }
        }


        public string ByCompany
        {
            get
            {
                return _ByCompany;
            }
            set
            {
                _ByCompany = value;
            }
        }

        public string ByDesignation
        {
            get
            {
                return _ByDesignation;
            }
            set
            {
                _ByDesignation = value;
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

        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
    }
}
