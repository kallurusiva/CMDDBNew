using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSv3.Entities
{
    public class ClientData
    {
        private int _UserID;
        private string _CopyRightsInfo;

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


    }
}
