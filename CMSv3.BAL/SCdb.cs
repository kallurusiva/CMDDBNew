using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CMSv3.BAL
{
    public class SCdb
    {

        //HitechSMS_DAL.m1_UserSC objUserSc = new HitechSMS_DAL.m1_UserSC();
        CMSv3.DAL.SCdb objUserSC = new CMSv3.DAL.SCdb(); 

        public DataSet Check_KeywordAvailability(String vKeyword, String vShortcode)
        {
            return objUserSC.Check_KeywordAvailability(vKeyword, vShortcode);
        }

        public int ebook_KeywordRequest(String vKeyword, String vShortcode)
        {
            return objUserSC.ebook_KeywordRequest(vKeyword, vShortcode);
        }
    }
}
