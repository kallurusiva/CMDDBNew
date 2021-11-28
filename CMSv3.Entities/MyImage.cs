using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class MyImage
    {
        private int _ImgID;
        private int _ImgType;
        private string _ImgName;
        private string _ImgPath;
        private DateTime _ImgDate;
        private string _ActualImgName;


        public int ImgID
        {
            get
            {
                return _ImgID;
            }
            set
            {
                _ImgID = value;
            }
        }



        public int ImgType
        {
            get
            {
                return _ImgType;
            }
            set
            {
                _ImgType = value;
            }
        }

        public string ImgName
        {
            get
            {
                return _ImgName;
            }
            set
            {
                _ImgName = value;
            }
        }

        public string ImgPath
        {
            get
            {
                return _ImgPath;
            }
            set
            {
                _ImgPath = value;
            }
        }

        public DateTime ImgDate
        {
            get
            {
                return _ImgDate;
            }
            set
            {
                _ImgDate = value;
            }
        }



        public string ActualImgName
        {
            get
            {
                return _ActualImgName;
            }
            set
            {
                _ActualImgName = value;
            }
        }


    }
}
