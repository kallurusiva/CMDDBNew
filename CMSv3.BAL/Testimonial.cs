using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMSv3.DAL;
using CMSv3.Entities;


namespace CMSv3.BAL
{

    public class Testimonial
    {
        CMSv3.DAL.Testimonial objDAL_Testimonial = new CMSv3.DAL.Testimonial();

        public int InsertTestimonial(CMSv3.Entities.Testimonial vObjTestimonial, int vUserId, CMSv3.Entities.MyImage vImage, int vSelLanguage)
        {
            return objDAL_Testimonial.InsertTestimonial(vObjTestimonial, vUserId, vImage, vSelLanguage);
        }

        public DataSet RetrieveAllTestimonials_ByUserID(int vUserId, string mRetreiveType, int vSelLanguage)
        {
            return objDAL_Testimonial.RetrieveAllTestimonials_ByUserID(vUserId,mRetreiveType, vSelLanguage);
        }

        public int UpdateTestimonialsData(CMSv3.Entities.Testimonial vObjTestimonial, int vUserId, CMSv3.Entities.MyImage vImage, bool vActive)
        {
            return objDAL_Testimonial.UpdateTestimonialsData(vObjTestimonial, vUserId, vImage, vActive);
        }

        public bool DeleteTestimonialsData(int vUserId, int vTestID)
        {
            return objDAL_Testimonial.DeleteTestimonialsData(vUserId, vTestID);
        }

        public bool DeleteTestimonialsData_Multiple(int vUserId, string vTesttIds)
        {
            return objDAL_Testimonial.DeleteTestimonialsData_Multiple(vUserId, vTesttIds);
        }

        public DataTable RetrieveAllTestimonials_ByTestimonialID(int vUserId, int vTestimonialID)
        {
            return objDAL_Testimonial.RetrieveAllTestimonials_ByTestimonialID(vUserId, vTestimonialID);
        }


        public DataSet User_GETAll_Testimonials_ByUserID(int mUserId)
        {
            return objDAL_Testimonial.User_GETAll_Testimonials_ByUserID(mUserId);
        }

        public bool UpdateTestimonialsActiveStatus(int vTestimonialID, int vUserId, bool vActive)
        {
            return objDAL_Testimonial.UpdateTestimonialsActiveStatus(vTestimonialID, vUserId, vActive);
        }

    }
}
