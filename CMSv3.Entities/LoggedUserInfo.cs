using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    [Serializable]
    public class LoggedUserInfo
    {

        private ArrayList _urlViews;
        private string _userAgent;
        private string _urlReferrer;
        private string _hostAddress;
        private string _hostName;
        private int _LoginUserID;
        private string _MobileLoginID;
        private DateTime _SessionStartTime;
        private DateTime _SessionEndTime;



       


        public LoggedUserInfo()
		{
			this.urlViews = new ArrayList();
		}


        public ArrayList urlViews
        {
            get { return _urlViews; }
            set { _urlViews = value;}
        }

        public string userAgent
        {
            get { return _userAgent; }
            set { _userAgent = value; }
        }

        public string urlReferrer
        {
            get { return _urlReferrer; }
            set { _urlReferrer = value; }
        }

        public string hostAddress
        {
            get { return _hostAddress; }
            set { _hostAddress = value; }
        }

        public string hostName
        {
            get { return _hostName; }
            set { _hostName = value; }
        }


        public int LoginUserID
        {
            get { return _LoginUserID; }
            set { _LoginUserID = value; }
        }

        public string MobileLoginID
        {
            get { return _MobileLoginID; }
            set { _MobileLoginID = value; }
        }

        

        public DateTime SessionStartTime
        {
            get { return _SessionStartTime; }
            set { _SessionStartTime = value; }
        }

        public DateTime SessionEndTime
        {
            get { return _SessionEndTime; }
            set { _SessionEndTime = value; }
        }

    }
}
