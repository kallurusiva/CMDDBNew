using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CMSv3.Entities;
using System.Data;
using System.Data.SqlClient;

namespace CMSv3.DAL
{
    public class Gallery
    {

        #region variables

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
        DataSet ds;
        //DataTable dt;

        string dbString = ConfigurationSettings.AppSettings["CMSdb"].ToString();



        #endregion


         #region Functionality

      // Constructor to open the dbConnection 
        public Gallery()
        {

            try
            {
                dbConn = new SqlConnection(dbString);
               // dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// Function to Retrieves an image from Gallery 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>Dataset </returns>
        /// <remarks>This function retrieves an images based on ImageId </remarks> 
        /// 
        public DataSet Retrieve_GImagesByImageID(int vImageID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_GalleryImages_RetrieveBYID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vImageID", SqlDbType.Int).Value = vImageID;
               
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
        /// Function to Retrieves an video from Gallery 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>Dataset </returns>
        /// <remarks>This function retrieves an video based on videoID </remarks> 
        /// 
        public DataSet Retrieve_GImagesByvideoID(int videoID)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_GalleryVideos_RetrieveBYID", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@videoID", SqlDbType.Int).Value = videoID;

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
        /// Function to Retrieves All the images from Gallery 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>Dataset </returns>
        /// <remarks>This function retrieves all the images from Gallery </remarks> 
        /// 
        public DataSet RetrieveAll_GImagesByCategory(int vCategoryID, int vPageNo,int vItemsPerPage, String vCalledFrom)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_GalleryImage_Retreive", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@ImgCategoryID", SqlDbType.Int).Value = vCategoryID;
                dbCmd.Parameters.Add("@PageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@ItemsPerPage", SqlDbType.Int).Value = vItemsPerPage;
                dbCmd.Parameters.Add("@CalledFrom", SqlDbType.VarChar).Value = vCalledFrom;
                
                dbCmd.Parameters.Add("@TotalRows", SqlDbType.Int).Direction = ParameterDirection.Output;

               
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
        /// Function to Upload new Videos 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>UpdateStatus </returns>
        /// <remarks>This function uploads new vidoe links to db</remarks> 
        /// 

        public int Save_VideoLinkInfo(string vVideoLink, string vVideoTitle, int vCategoryID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_GalleryVideo_Upload]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails

                dbCmd.Parameters.Add("@VideoLink", SqlDbType.VarChar).Value = vVideoLink; 
                dbCmd.Parameters.Add("@VideoTitle", SqlDbType.VarChar).Value = vVideoTitle;
                dbCmd.Parameters.Add("@vCategoryID", SqlDbType.Int).Value = vCategoryID;
                
                int rowCount = dbCmd.ExecuteNonQuery();
                return rowCount;


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
        /// Function to Upload new Videos 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>UpdateStatus </returns>
        /// <remarks>This function uploads new vidoe links to db</remarks> 
        /// 

        public int Update_VideoLinkInfo(int VideoID, string vVideoLink, string vVideoTitle, int vCategoryID, bool vActive)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_GalleryVideo_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@VideoId", SqlDbType.Int).Value = VideoID;
                dbCmd.Parameters.Add("@VideoLink", SqlDbType.VarChar).Value = vVideoLink;
                dbCmd.Parameters.Add("@VideoTitle", SqlDbType.VarChar).Value = vVideoTitle;
                dbCmd.Parameters.Add("@vCategoryID", SqlDbType.Int).Value = vCategoryID;
                dbCmd.Parameters.Add("@chkActive", SqlDbType.Bit).Value = vActive;

                int rowCount = dbCmd.ExecuteNonQuery();
                return rowCount;


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
        /// Function to Retrieves All the Videos from Gallery 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>Dataset </returns>
        /// <remarks>This function retrieves all the Videos from Gallery </remarks> 
        /// 
        public DataSet RetrieveAll_GIVideosByCategory(int vCategoryID, int vPageNo, int vItemsPerPage, string vCalledFrom)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_GalleryVideos_Retreive", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = vCategoryID;
                dbCmd.Parameters.Add("@PageNo", SqlDbType.Int).Value = vPageNo;
                dbCmd.Parameters.Add("@ItemsPerPage", SqlDbType.Int).Value = vItemsPerPage;
                dbCmd.Parameters.Add("@CalledFrom", SqlDbType.VarChar).Value = vCalledFrom;


                dbCmd.Parameters.Add("@TotalRows", SqlDbType.Int).Direction = ParameterDirection.Output;


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




        public int DeleteGiImage(int vImageID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_GalleryImages_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vImageID", SqlDbType.Int).Value = vImageID;

                int rowCount = dbCmd.ExecuteNonQuery();
                return rowCount;

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


        public int DeleteGiVideo(int vVideoID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_GalleryVideos_Delete", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vVideoID", SqlDbType.Int).Value = vVideoID;

                int rowCount = dbCmd.ExecuteNonQuery();
                return rowCount;

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


        public int Update_GalleryImageByID(CMSv3.Entities.ObjectImage objImage, bool vActive)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_GalleryImage_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@ImgID", SqlDbType.Int).Value = objImage.objImageID;
                dbCmd.Parameters.Add("@ImgCategory", SqlDbType.Int).Value = objImage.ObjImageType;
                dbCmd.Parameters.Add("@ImgPath", SqlDbType.VarChar).Value = objImage.ObjImagePath;
                dbCmd.Parameters.Add("@ImgTitle", SqlDbType.VarChar).Value = objImage.ObjImageName;
                dbCmd.Parameters.Add("@ImgActualName", SqlDbType.VarChar).Value = objImage.ObjImageActualName;
                dbCmd.Parameters.Add("@chkActive", SqlDbType.Bit).Value = vActive;

                int rowCount = dbCmd.ExecuteNonQuery();
                return rowCount;



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


        public int Update_GalleryImageSettings(CMSv3.Entities.ObjectImage objImage, int vUserID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_GalleryImage_Upload]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

                dbCmd.Parameters.Add("@ImgID", SqlDbType.Int).Value = objImage.objImageID;
                dbCmd.Parameters.Add("@ImgCategory", SqlDbType.Int).Value = objImage.ObjImageType;
                dbCmd.Parameters.Add("@ImgPath", SqlDbType.VarChar).Value = objImage.ObjImagePath;
                dbCmd.Parameters.Add("@ImgName", SqlDbType.VarChar).Value = objImage.ObjImageName;
                dbCmd.Parameters.Add("@ImgActualName", SqlDbType.VarChar).Value = objImage.ObjImageActualName;

                int rowCount = dbCmd.ExecuteNonQuery();
                return rowCount;



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



        public int UpLoad_AnchorImages(CMSv3.Entities.ObjectImage objImage, int vUserID, int vCategoryID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_AncImages_Upload]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

                dbCmd.Parameters.Add("@ImgID", SqlDbType.Int).Value = objImage.objImageID;
                dbCmd.Parameters.Add("@ImgCategory", SqlDbType.Int).Value = vCategoryID;
                dbCmd.Parameters.Add("@ImgType", SqlDbType.TinyInt).Value = objImage.ObjImageType;
                dbCmd.Parameters.Add("@ImgPath", SqlDbType.VarChar).Value = objImage.ObjImagePath;
                dbCmd.Parameters.Add("@ImgName", SqlDbType.VarChar).Value = objImage.ObjImageName;
                dbCmd.Parameters.Add("@ImgActualName", SqlDbType.VarChar).Value = objImage.ObjImageActualName;

                int rowCount = dbCmd.ExecuteNonQuery();
                return rowCount;



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
        /// Function to Upload new Videos 
        /// </summary>
        /// <param name="sc">CMSV3</param>
        /// <returns>UpdateStatus </returns>
        /// <remarks>This function uploads new vidoe links to db</remarks> 
        /// 

        public int Update_ImageInfo(string vVideoLink, string vVideoTitle, int vCategoryID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_GalleryVideo_Upload]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails

                dbCmd.Parameters.Add("@VideoLink", SqlDbType.VarChar).Value = vVideoLink;
                dbCmd.Parameters.Add("@VideoTitle", SqlDbType.VarChar).Value = vVideoTitle;
                dbCmd.Parameters.Add("@vCategoryID", SqlDbType.Int).Value = vCategoryID;

                int rowCount = dbCmd.ExecuteNonQuery();
                return rowCount;


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
