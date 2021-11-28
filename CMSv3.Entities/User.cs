using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CMSv3.Entities
{
    public class User
    {
        private int _UserId;
        private string _LoginID;
        private string _LoginPwd;
        private string _UserType;
        private int _isActive;
        private DateTime _CreatedDateTime;


        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        public string LoginID
        {
            get
            {
                return _LoginID;
            }
            set
            {
                _LoginID = value;
            }
        }


        public string LoginPwd
        {
            get
            {
                return _LoginPwd;
            }
            set
            {
                _LoginPwd = value;
            }
        }

        public string UserType
        {
            get
            {
                return _UserType;
            }
            set
            {
                _UserType = value;
            }
        }


        public int isActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

        public DateTime CreatedDateTime
        {
            get
            {
                return _CreatedDateTime;
            }
            set
            {
                _CreatedDateTime = value;
            }
        }



    }
}
