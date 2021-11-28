using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMSv3.DAL;
using CMSv3.Entities;


namespace CMSv3.BAL
{
    public class enquiry
    {
        CMSv3.Entities.Enquiry objEnquiry = new CMSv3.Entities.Enquiry();
        CMSv3.DAL.enquiry objDAL_Enquiry = new CMSv3.DAL.enquiry();

        public int InsertEnquiryData(CMSv3.Entities.Enquiry objEnquiry, int vUserId)
        {

            return objDAL_Enquiry.InsertEnquiryData(objEnquiry, vUserId);
        }
    }
}
