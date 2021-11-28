using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class News
    {
        private int _NewsID;
        private string _NewsTitle ;
        private string _NewsContent;
        private int _NewsUserID;


        public int NewsID
        {
            get { return _NewsID; }
            set { _NewsID = value; }
        }


        public string NewsTitle
        {
            get { return _NewsTitle; }
            set { _NewsTitle = value; }
        }

        public string NewsContent
        {
            get { return _NewsContent; }
            set { _NewsContent = value; }
        }


        public int NewsUserID
        {
            get { return _NewsUserID; }
            set { _NewsUserID = value; }
        }


    }
}
