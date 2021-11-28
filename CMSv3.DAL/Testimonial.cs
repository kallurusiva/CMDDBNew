using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CMSv3.Entities;


namespace CMSv3.DAL
{
    public class Testimonial
    {


        #region variables

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
        DataSet ds;
        DataTable dt;

        string dbConnString = ConfigurationSettings.AppSettings["CMSdb"].ToString();



        #endregion


        #region SqlConstants

        private const string SP_InsertTestimonialData = "usp_Testimonial_InsertData";
        private const string SP_UpdateTestimonial_ByUserId = "usp_Testimonial_Update_ByUserID";
        private const string SP_UpdateTestimonial_ActiveStatus = "usp_Testimonial_Update_ActiveStatus";

        private const string SP_DeleteTestimonial_ByUserId = "usp_Testimonial_Delete_ByUserID";
        private const string SP_DeleteTestimonial_ByUserId_Multiple = "usp_Testimonial_Delete_ByUserID_Multiple";
        private const string SP_RetrieveAll_Testimonial_ByUserID = "usp_Testimonials_Retrieve_ByUserID";
        private const string SP_Retrieve_Testimonial_ByTestimonialID = "usp_Testimonial_Retrieve_ByTestimonialID";


        private const string SP_USER_GET_Testimonials_ByUserID = "usp_USER_GET_Testimonials_ByUserID";

        
        

        #endregion


        #region Functionality


        public Testimonial()
        {
            try
            {
                dbConn = new SqlConnection(dbConnString);
               // dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


        /// <summary>
        /// Function to insert record into tblTestimonials table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>integer</returns>
        /// <remarks>This function inserts and returns 1 if inserted else 0</remarks> 
        /// 
        public int InsertTestimonial(CMSv3.Entities.Testimonial vObjTestimonial,int vUserId, CMSv3.Entities.MyImage vImage,int vSelLanguage)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_InsertTestimonialData, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@ByName", SqlDbType.NVarChar).Value = vObjTestimonial.ByName;
                dbCmd.Parameters.Add("@ByDesignation", SqlDbType.NVarChar).Value = vObjTestimonial.ByDesignation;
                dbCmd.Parameters.Add("@ByCompany", SqlDbType.NVarChar).Value = vObjTestimonial.ByCompany;
                dbCmd.Parameters.Add("@TstContent", SqlDbType.NVarChar).Value = vObjTestimonial.TstContent;
                dbCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@ImageName", SqlDbType.VarChar).Value = vImage.ImgName;
                dbCmd.Parameters.Add("@ImageType", SqlDbType.TinyInt).Value = vImage.ImgType;
                dbCmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = vImage.ImgPath;
                dbCmd.Parameters.Add("@ImageActName", SqlDbType.VarChar).Value = vImage.ActualImgName;
                dbCmd.Parameters.Add("@CountryCode", SqlDbType.SmallInt).Value = vObjTestimonial.CountryCode;
                dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = vSelLanguage;
                dbCmd.Parameters.Add("@vActive", SqlDbType.Bit).Value = vObjTestimonial.Active;

                

                int rowcount = dbCmd.ExecuteNonQuery();
                return rowcount;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }


        }


         /// <summary>
        /// Function to Retrieves records from the tblTestimonials table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>Dataset </returns>
        /// <remarks>This function retrieves all the records based on UserId and returns a Dataset</remarks> 
        /// 


        public DataSet RetrieveAllTestimonials_ByUserID(int vUserId, string mRetreiveType, int vSelLanguage)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_RetrieveAll_Testimonial_ByUserID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tstUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@RtrType", SqlDbType.VarChar).Value = mRetreiveType;
                dbCmd.Parameters.Add("@LgType", SqlDbType.TinyInt).Value = vSelLanguage;

                dbAdap = new SqlDataAdapter(dbCmd);
                ds = new DataSet();
                dbAdap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }



        }




        /// <summary>
        /// Function to Retrieves a specific record from the tblTestimonials table based on Testimonial id 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>Dataset </returns>
        /// <remarks>This function retrieves one record based on Testimonial ID  and returns a dataset</remarks> 
        /// 
        public DataTable RetrieveAllTestimonials_ByTestimonialID(int vUserId, int vTestimonialID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Retrieve_Testimonial_ByTestimonialID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@tstUserID", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@testimonialID", SqlDbType.Int).Value = vTestimonialID;

                dbAdap = new SqlDataAdapter(dbCmd);
                //ds = new DataSet();
                dt = new DataTable();

                //dbAdap.Fill(ds);
                dbAdap.Fill(dt);

                //return ds;
                return dt;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }



        }


        //protected CMSv3.Entities.Testimonial BindData(SqlDataReader dbreader)
        //{

        //    CMSv3.Entities.Testimonial objTestimonial = new CMSv3.Entities.Testimonial();

        //    while (dbReader.Read())
        //    {
        //        if (dbReader["tstID"] != DBNull.Value)
        //            objTestimonial.TstContent = Convert.ToInt32(dbreader["UserID"]);

        //        if (dbReader["tstContent"] != DBNull.Value)
        //            objTestimonial.TstContent = Convert.ToString(dbreader["tstContent"]);

        //        if (dbReader["tstByName"] != DBNull.Value)
        //            objTestimonial.UserType = Convert.ToString(dbreader["UserType"]);

        //        if (dbReader["tstByDesignation"] != DBNull.Value)
        //            objTestimonial.CreatedDateTime = Convert.ToDateTime(dbreader["CreatedDate"]);

        //        if (dbReader["tstContent"] != DBNull.Value)
        //            objTestimonial.TstContent = Convert.ToString(dbreader["tstContent"]);


        //        if (dbReader["tstByCompany"] != DBNull.Value)
        //            objTestimonial.TstContent = Convert.ToString(dbreader["tstByCompany"]);


        //        if (dbReader["UserID"] != DBNull.Value)
        //            objTestimonial.TstContent = Convert.ToString(dbreader["UserID"]);

        //        if (dbReader["tstCreatedDate"] != DBNull.Value)
        //            objTestimonial.TstContent = Convert.ToString(dbreader["tstCreatedDate"]);

        //        if (dbReader["ImageID"] != DBNull.Value)
        //            objTestimonial.TstContent = Convert.ToString(dbreader["ImageID"]);

        //        if (dbReader["tstContent"] != DBNull.Value)
        //            objTestimonial.TstContent = Convert.ToString(dbreader["tstContent"]);

        //        if (dbReader["tstContent"] != DBNull.Value)
        //            objTestimonial.TstContent = Convert.ToString(dbreader["tstContent"]);


        //    }

        //    dbreader.Dispose();
        //    return objTestimonial;

        //}



        /// <summary>
        /// Function to update Active Status  into tblTestimonials table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>bool</returns>
        /// <remarks>This function updates the active status  returns number of records updated</remarks> 
        /// 
        public bool UpdateTestimonialsActiveStatus(int vTestimonialID, int vUserId, bool vActive)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_UpdateTestimonial_ActiveStatus, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@TstID", SqlDbType.Int).Value = vTestimonialID;
                dbCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = vActive;

                int rowCount = dbCmd.ExecuteNonQuery();
                //return rowcount;
                if (rowCount > 0)
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }




        /// <summary>
        /// Function to update record into tblTestimonials table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>bool</returns>
        /// <remarks>This function updates and returns number of records updated</remarks> 
        /// 
        public int UpdateTestimonialsData(CMSv3.Entities.Testimonial vObjTestimonial, int vUserId, CMSv3.Entities.MyImage vImage, bool vActive)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_UpdateTestimonial_ByUserId, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@ByName", SqlDbType.NVarChar).Value = vObjTestimonial.ByName;
                dbCmd.Parameters.Add("@ByDesignation", SqlDbType.NVarChar).Value = vObjTestimonial.ByDesignation;
                dbCmd.Parameters.Add("@ByCompany", SqlDbType.NVarChar).Value = vObjTestimonial.ByCompany;
                dbCmd.Parameters.Add("@TstID", SqlDbType.Int).Value = vObjTestimonial.TstID;
                dbCmd.Parameters.Add("@TstContent", SqlDbType.NVarChar).Value = vObjTestimonial.TstContent;
                dbCmd.Parameters.Add("@UserId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@ImageID", SqlDbType.Int).Value = vImage.ImgID;
                dbCmd.Parameters.Add("@ImageName", SqlDbType.VarChar).Value = vImage.ImgName;
                dbCmd.Parameters.Add("@ImageType", SqlDbType.TinyInt).Value = vImage.ImgType;
                dbCmd.Parameters.Add("@ImagePath", SqlDbType.VarChar).Value = vImage.ImgPath;
                dbCmd.Parameters.Add("@ImageActName", SqlDbType.VarChar).Value = vImage.ActualImgName;
                dbCmd.Parameters.Add("@CountryCode", SqlDbType.SmallInt).Value = vObjTestimonial.CountryCode;
                dbCmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = vActive;


                int rowcount = dbCmd.ExecuteNonQuery();
                return rowcount;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }



        /// <summary>
        /// Function to insert record into tblTestimonials table
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>integer</returns>
        /// <remarks>This function inserts and returns 1 if inserted else 0</remarks> 
        /// 
        public bool DeleteTestimonialsData(int vUserId, int vTestID)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_DeleteTestimonial_ByUserId, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@TestId", SqlDbType.Int).Value = vTestID;

                int rowCount = dbCmd.ExecuteNonQuery();

                if (rowCount > 0)
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }


        public bool DeleteTestimonialsData_Multiple(int vUserId, string vTestIdsStr)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();


                dbCmd = new SqlCommand(SP_DeleteTestimonial_ByUserId_Multiple, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@userId", SqlDbType.Int).Value = vUserId;
                dbCmd.Parameters.Add("@TestIds", SqlDbType.VarChar).Value = vTestIdsStr;

                int rowCount = dbCmd.ExecuteNonQuery();

                if (rowCount > 0)
                    return true;
                else
                    return false;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
        }

      
 
        #endregion





        #region  USER related functionality


        /// <summary>
        /// Function to retrive all the Testimonials on the home page. 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>bool</returns>
        /// <remarks>This function updates and returns 1 if inserted else 0</remarks> 
        /// 
        public DataSet User_GETAll_Testimonials_ByUserID(int mUserId)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_USER_GET_Testimonials_ByUserID, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = mUserId;

                dbAdap = new SqlDataAdapter(dbCmd);
                ds = new DataSet();
                dbAdap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }

        }


        #endregion


    }

       
    
    
    }


