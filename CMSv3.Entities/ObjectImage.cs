using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class ObjectImage
    {
        
        private int _objImageID;
        private int _ObjImageType;
        private string _ObjImagePath;
        private string _ObjImageName;
        private string _ObjImageActualName;

      

        public int objImageID
        {
            set { _objImageID = value;}
            get{return _objImageID;}
        }

        public int ObjImageType
        {
            set
            {
                _ObjImageType = value;
            }
            get
            {
                return _ObjImageType;
            }
        }

        public string ObjImagePath
        {
            set
            {
                _ObjImagePath = value;
            }
            get
            {
                return _ObjImagePath;
            }
        }

        public string ObjImageName
        {
            set
            {
                _ObjImageName = value;
            }
            get
            {
                return _ObjImageName;
            }
        }

        public string ObjImageActualName
        {
            set
            {
                _ObjImageActualName = value;
            }
            get
            {
                return _ObjImageActualName;
            }
        }




    }
}
