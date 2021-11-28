using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class AdminSettings
    {
        private string _CompanyName;
        private string _CompanyInfo;
        private string _CopyRightInfo;
        private bool _ShowEvents;
        private bool _ShowNews;
        private string _TopMenuLinks;
        private string _TopRowLinks;
        private string _LanguagesDp;

        private string _CommAppsToShow;
        private string _LayoutType;
        private string _ThemeType;
        private string _DefLanguage;
        private int _ModifiedBy;
        private DateTime _ModifedDate;

        private int _Logo_ImgID;
        private int _Logo_ImgType;
        private string _Logo_ImgPath;
        private string _Logo_ImgName;
        private string _Logo_ImgActualName;

        private int _Banner_ImgID;
        private int _Banner_ImgType;
        private string _Banner_ImgPath;
        private string _Banner_ImgName;
        private string _Banner_ImgActualName;

        private bool _User_LogoTicked;
        private bool _User_BannerTicked;


      

        public int Logo_ImgID
        {
            set
            {
                _Logo_ImgID = value;
            }
            get
            {
                return _Logo_ImgID;
            }
        }

        public int Banner_ImgID
        {
            set
            {
                _Banner_ImgID = value;
            }
            get
            {
                return _Banner_ImgID;
            }
        }

        public string CompanyName
        {
            set {
                _CompanyName = value;
            }
            get {
                return _CompanyName;
            }
        }

        public string CompanyInfo
        {
            set
            {
                _CompanyInfo = value;
            }
            get
            {
                return _CompanyInfo;
            }
        }

        public string CopyRightInfo
        {
            set
            {
                _CopyRightInfo = value;
            }
            get
            {
                return _CopyRightInfo;
            }
        }


        public bool ShowEvents
        {
            set
            {
                _ShowEvents = value;
            }
            get
            {
                return _ShowEvents;
            }
        }

        public bool ShowNews
        {
            set
            {
                _ShowNews = value;
            }
            get
            {
                return _ShowNews;
            }
        }



        public bool User_LogoTicked
        {
            set
            { _User_LogoTicked = value; }
            get
            { return _User_LogoTicked; }
        }

        public bool User_BannerTicked
        {
            set
            { _User_BannerTicked = value; }
            get
            { return _User_BannerTicked; }
        }



        public string TopMenuLinks
        {
            set
            {
                _TopMenuLinks = value;
            }
            get
            {
                return _TopMenuLinks;
            }
        }

        public string TopRowLinks
        {
            set{   _TopRowLinks = value;}
            get{   return _TopRowLinks;}
        }

        public string LanguagesDp
        {
            set { _LanguagesDp = value; }
            get { return _LanguagesDp; }
        }

        


         public string CommAppsToShow
        {
            set
            {
                _CommAppsToShow = value;
            }
            get
            {
                return _CommAppsToShow;
            }
        }

        public string LayoutType
        {
            set
            {
                _LayoutType = value;
            }
            get
            {
                return _LayoutType;
            }
        }


        public string ThemeType
        {
            set
            {
                _ThemeType = value;
            }
            get
            {
                return _ThemeType;
            }
        }


        public string DefLanguage
        {
            set
            {
                _DefLanguage = value;
            }
            get
            {
                return _DefLanguage;
            }
        }


       public int ModifiedBy
        {
            set
            {
                _ModifiedBy = value;
            }
            get
            {
                return _ModifiedBy;
            }
        }

        public DateTime ModifedDate
        {
            set
            {
                _ModifedDate = value;
            }
            get
            {
                return _ModifedDate;
            }
        }



        public int Logo_ImgType
        {
            set
            {
                _Logo_ImgType = value;
            }
            get
            {
                return _Logo_ImgType;
            }
        }

        public string Logo_ImgPath
        {
            set
            {
                _Logo_ImgPath = value;
            }
            get
            {
                return _Logo_ImgPath;
            }
        }

        public string Logo_ImgName
        {
            set
            {
                _Logo_ImgName = value;
            }
            get
            {
                return _Logo_ImgName;
            }
        }

        public string Logo_ImgActualName
        {
            set
            {
                _Logo_ImgActualName = value;
            }
            get
            {
                return _Logo_ImgActualName;
            }
        }


        public int Banner_ImgType
        {
            set
            {
                _Banner_ImgType = value;
            }
            get
            {
                return _Banner_ImgType;
            }
        }

        public string Banner_ImgPath
        {
            set
            {
                _Banner_ImgPath = value;
            }
            get
            {
                return _Banner_ImgPath;
            }
        }

        public string Banner_ImgName
        {
            set
            {
                _Banner_ImgName = value;
            }
            get
            {
                return _Banner_ImgName;
            }
        }

        public string Banner_ImgActualName
        {
            set
            {
                _Banner_ImgActualName = value;
            }
            get
            {
                return _Banner_ImgActualName;
            }
        }

     
        //public Byte[] LogoImage_BinaryData
        //{
        //    set
        //    {
        //        _LogoImage_BinaryData = value;
        //    }
        //    get
        //    {
        //        return _LogoImage_BinaryData;
        //    }
        //}


        //public string LogoImage_Name
        //{
        //    set
        //    {
        //        _LogoImage_Name = value;
        //    }
        //    get
        //    {
        //        return _LogoImage_Name;
        //    }
        //}

        //public string LogoImage_ContentType
        //{
        //    set
        //    {
        //        _LogoImage_ContentType = value;
        //    }
        //    get
        //    {
        //        return _LogoImage_ContentType;
        //    }
        //}



        //public Byte[] BannerImage_BinaryData
        //{
        //    set
        //    {
        //        _BannerImage_BinaryData = value;
        //    }
        //    get
        //    {
        //        return _BannerImage_BinaryData;
        //    }
        //}


        //public string BannerImage_Name
        //{
        //    set
        //    {
        //        _BannerImage_Name = value;
        //    }
        //    get
        //    {
        //        return _BannerImage_Name;
        //    }
        //}

        //public string BannerImage_ContentType
        //{
        //    set
        //    {
        //        _BannerImage_ContentType = value;
        //    }
        //    get
        //    {
        //        return _BannerImage_ContentType;
        //    }
        //}




    }
}
