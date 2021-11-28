using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    [Serializable]
    public class MobiData
    {
        private int _UserID;
        private string _CopyRightsInfo;
        private int _LogoImgID;
        private string _LogoImgName;
        private string _CompanyName;
        private string _UserFullName;
        private string _UserHandPhone;
        private string _UserEmail;
        private string _ReferringURL;
        private string _TitleRow1;
        private string _TitelRow2;

        private string _MobileLoginID;


      

        public int UserID
        {
            set { _UserID = value; }
            get { return _UserID; }

        }

        public string CopyRightsInfo
        {
            set { _CopyRightsInfo = value; }
            get { return _CopyRightsInfo; }

        }

        public int LogoImgID
        {
            set { _LogoImgID = value; }
            get { return _LogoImgID; }

        }

        public string LogoImgName
        {
            set { _LogoImgName = value; }
            get { return _LogoImgName; }

        }

        public string ReferringURL
        {
            set { _ReferringURL = value; }
            get { return _ReferringURL; }

        }

        public string CompanyName
        {
            set { _CompanyName = value; }
            get { return _CompanyName; }

        }

        public string UserFullName
        {
            set { _UserFullName = value; }
            get { return _UserFullName; }

        }

        public string UserHandPhone
        {
            set { _UserHandPhone = value; }
            get { return _UserHandPhone; }

        }

        public string UserEmail
        {
            set { _UserEmail = value; }
            get { return _UserEmail; }

        }

        public string TitleRow1
        {
            set { _TitleRow1 = value; }
            get { return _TitleRow1; }

        }

        public string TitleRow2
        {
            set { _TitelRow2 = value; }
            get { return _TitelRow2; }

        }

        public string MobileLoginID
        {
            set { _MobileLoginID = value; }
            get { return _MobileLoginID; }

        }

        


    }
}
