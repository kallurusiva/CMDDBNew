using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CMSv3.DAL
{
    public class AccountSettings
    {

        #region variables

            protected SqlConnection dbConn;
            protected SqlCommand dbCmd;
            protected SqlDataAdapter dbAdap;
            protected SqlDataReader dbReader;
            DataSet ds;

            string dbString = ConfigurationSettings.AppSettings["CMSdb"].ToString();

        #endregion

        #region SqlConstants

            
            private const string SP_RetrieveAll_Settings_HomePage = "usp_Settings_Retrieve_AccountPage";  //renamed [usp_Settings_Retrieve_HomePageData]  
            private const string SP_Settings_HomePage_InsertUpdate = "usp_Settings_InsertUpdate_HomePageData";
            
            // This SP is used to retrieve all the data for MyHomePageSettings Web PAge
            private const string SP_Retrieve_Settings_HomePage_Defaults = "usp_Settings_Retrieve_MenuLogoBanner_Defaults";
            private const string SP_Retrieve_Settings_Banners = "usp_Settings_Retrieve_Banners";
        
        // This SP is used to retrieve all the data for Default Home Web PAge  is [usp_RetrieveAll_HomePageSettings]
            private const string SP_Settings_Update_HomePage_Defaults = "usp_Settings_Update_HomePageData";
            //private const string SP_Settings_Update_HomePage_Defaults = "usp_Settings_Update_HomePageData2";
            private const string SP_Settings_Delete_UserImage = "usp_Settings_DeleteUserImage";

            private const string SP_SA_Upload_BannerLogo = "usp_SAUpload_BannerLogo";
            
        

        #endregion



        #region Functionality


        // Constructor to open the dbConnection 
            public AccountSettings()
        {
         try
            {
                dbConn = new SqlConnection(dbString);
                //dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataSet RetrieveALL_Settings_HomePageData(int vUserId)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_RetrieveAll_Settings_HomePage, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;

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


        public int DeleteAnchorImage(int vImageID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_AnchorImage_Delete]", dbConn);
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


       public int Settings_DeleteUserImage(int vImageID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Settings_Delete_UserImage, dbConn);
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


        public DataSet RetrieveALL_Settings_HomePage_Defaults(int vUserId)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Retrieve_Settings_HomePage_Defaults, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;

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


        public int InsertUpdate_Settings_HomePageData(CMSv3.Entities.UserDetails objUser, CMSv3.Entities.CommApps objCommApps, CMSv3.Entities.MyImage objImage)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Settings_HomePage_InsertUpdate, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = objUser.UserID;
                dbCmd.Parameters.Add("@vFullName", SqlDbType.NVarChar).Value = objUser.FullName;
                dbCmd.Parameters.Add("@vNickname", SqlDbType.NVarChar).Value = objUser.NickName;
                dbCmd.Parameters.Add("@vEmail", SqlDbType.NVarChar).Value = objUser.Email;
                dbCmd.Parameters.Add("@vHomePhone", SqlDbType.BigInt).Value = objUser.Homephone;
                dbCmd.Parameters.Add("@vHandPhone", SqlDbType.BigInt).Value = objUser.Handphone;
                dbCmd.Parameters.Add("@vFaxNo", SqlDbType.BigInt).Value = objUser.FaxNo;
                dbCmd.Parameters.Add("@vCompanyName", SqlDbType.NVarChar).Value = objUser.CompanyName;
                //dbCmd.Parameters.Add("@vCompanyInfo", SqlDbType.NVarChar).Value = objUser.CompanyInfo;
                dbCmd.Parameters.Add("@vAddress", SqlDbType.NVarChar).Value = objUser.Address;

                    //.. checkboxes UserDetails
                    dbCmd.Parameters.Add("@ckCompanyName", SqlDbType.Bit).Value = objUser.CompanyNameChecked;   
                    dbCmd.Parameters.Add("@ckNickName", SqlDbType.Bit).Value = objUser.NickNameChecked;
                    dbCmd.Parameters.Add("@ckEmail", SqlDbType.Bit).Value = objUser.EmailChecked;
                    dbCmd.Parameters.Add("@ckHandPhone", SqlDbType.Bit).Value = objUser.HandPhoneChecked;
                    dbCmd.Parameters.Add("@ckHomePhone", SqlDbType.Bit).Value = objUser.HomePhoneChecked;
                    dbCmd.Parameters.Add("@ckFaxNo", SqlDbType.Bit).Value = objUser.FaxNoChecked;
                    dbCmd.Parameters.Add("@ckUserPhoto", SqlDbType.Bit).Value = objUser.UserPhotoChecked;
                    dbCmd.Parameters.Add("@ckAddress", SqlDbType.Bit).Value = objUser.AddressChecked;
                

                //..CommApp Details

                dbCmd.Parameters.Add("@vYahooId", SqlDbType.VarChar).Value = objCommApps.yahooid;
                dbCmd.Parameters.Add("@vHotmailId", SqlDbType.VarChar).Value = objCommApps.Hotmailid;
                //dbCmd.Parameters.Add("@vGoogleId", SqlDbType.VarChar).Value = objCommApps.Googleid;
                dbCmd.Parameters.Add("@vSkypeId", SqlDbType.VarChar).Value = objCommApps.Skypeid;
                dbCmd.Parameters.Add("@vTwitterId", SqlDbType.VarChar).Value = objCommApps.Twitterid;
                dbCmd.Parameters.Add("@vBlogSpotId", SqlDbType.VarChar).Value = objCommApps.BlogSpotid;
                dbCmd.Parameters.Add("@vFacebookId", SqlDbType.VarChar).Value = objCommApps.Facebookid;
                dbCmd.Parameters.Add("@vFacebookGroupLink", SqlDbType.VarChar).Value = objCommApps.FaceBookGroupLink;
                
                    //.. checkboxes Comm Apps
                    dbCmd.Parameters.Add("@vYahooChecked", SqlDbType.Bit).Value = objCommApps.yahooChecked;
                    dbCmd.Parameters.Add("@vHotmailChecked", SqlDbType.Bit).Value = objCommApps.HotmailChecked;
                    //dbCmd.Parameters.Add("@vGoogleChecked", SqlDbType.Bit).Value = objCommApps.GoogleChecked;
                    dbCmd.Parameters.Add("@vSkypeChecked", SqlDbType.Bit).Value = objCommApps.SkypeChecked;
                    dbCmd.Parameters.Add("@vTwitterChecked", SqlDbType.Bit).Value = objCommApps.TwitterChecked;
                    dbCmd.Parameters.Add("@vBlogSpotChecked", SqlDbType.Bit).Value = objCommApps.BlogSpotChecked;
                    dbCmd.Parameters.Add("@vFaceBookChecked", SqlDbType.Bit).Value = objCommApps.FacebookChecked;
                    dbCmd.Parameters.Add("@vFaceBookGroupLinkChecked", SqlDbType.Bit).Value = objCommApps.FaceBookGroupLinkChecked;
                

                //.. Image Details

                dbCmd.Parameters.Add("@vImgName", SqlDbType.VarChar).Value = objImage.ImgName;
                dbCmd.Parameters.Add("@vImgActualName", SqlDbType.VarChar).Value = objImage.ActualImgName;
                dbCmd.Parameters.Add("@vImgPath", SqlDbType.VarChar).Value = objImage.ImgPath;
                dbCmd.Parameters.Add("@vImgType", SqlDbType.VarChar).Value = objImage.ImgType;

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



        public DataSet Retrieve_Banners(int vUserID, string vCalledBy)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Retrieve_Settings_Banners, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vCalledBy", SqlDbType.VarChar).Value = vCalledBy;

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

        public DataSet Retrieve_Banners_ByIndustry(int vUserID, string vCategoryID, string vCalledBy)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Settings_Retrieve_BannersByCategoryID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vCategoryID", SqlDbType.Int).Value = Convert.ToInt16(vCategoryID);
                dbCmd.Parameters.Add("@vCalledBy", SqlDbType.VarChar).Value = vCalledBy;


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

        public DataSet Retrieve_AnchorImages(int vUserID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_AnchorImage_Retrieve]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

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



        public DataSet WP_Retrieve_Images(int vUserID,string vWpImageType, string vCalledBy)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_WP_Retrieve_Images]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vWp_ImageType", SqlDbType.VarChar).Value = vWpImageType;
                dbCmd.Parameters.Add("@vCalledBy", SqlDbType.VarChar).Value = vCalledBy;

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


        public DataSet WP_Retrieve_Images_ByIndustry(int vUserID, string vCategoryID, string vWpImageType, string vCalledBy)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_WP_Retrieve_ImagesByCategoryID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vCategoryID", SqlDbType.Int).Value = Convert.ToInt16(vCategoryID);
                dbCmd.Parameters.Add("@vWp_ImageType", SqlDbType.VarChar).Value = vWpImageType;
                dbCmd.Parameters.Add("@vCalledBy", SqlDbType.VarChar).Value = vCalledBy;


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


        public int WP_Save_Images(CMSv3.Entities.AdminSettings objImageUser, int vUserID, int vCategoryID, string vWpImageType)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_WP_InsertUpdate_WebPictures]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vImgID", SqlDbType.Int).Value = objImageUser.Banner_ImgID;
                dbCmd.Parameters.Add("@vImgType", SqlDbType.Int).Value = objImageUser.Banner_ImgType;
                dbCmd.Parameters.Add("@vImgPath", SqlDbType.VarChar).Value = objImageUser.Banner_ImgPath;
                dbCmd.Parameters.Add("@vImgName", SqlDbType.VarChar).Value = objImageUser.Banner_ImgName;
                dbCmd.Parameters.Add("@vImgActualName", SqlDbType.VarChar).Value = objImageUser.Banner_ImgActualName;
                dbCmd.Parameters.Add("@vWPType", SqlDbType.VarChar).Value = vWpImageType;
                dbCmd.Parameters.Add("@vIsSelected", SqlDbType.Bit).Value = objImageUser.User_BannerTicked;
                dbCmd.Parameters.Add("@vCategoryId", SqlDbType.Int).Value = vCategoryID;

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



        public int Save_NewBanner(CMSv3.Entities.AdminSettings objUser, int vUserID,int vCategoryID,bool vActive)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Settings_Update_BannerBySA]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@Banner_ImgType", SqlDbType.Int).Value = objUser.Banner_ImgType;
                dbCmd.Parameters.Add("@Banner_ImgPath", SqlDbType.VarChar).Value = objUser.Banner_ImgPath;
                dbCmd.Parameters.Add("@Banner_ImgName", SqlDbType.VarChar).Value = objUser.Banner_ImgName;
                dbCmd.Parameters.Add("@Banner_ImgActualName", SqlDbType.VarChar).Value = objUser.Banner_ImgActualName;
                dbCmd.Parameters.Add("@Active", SqlDbType.Bit).Value = vActive;
                dbCmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = vCategoryID;

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



        public int Save_NewLogo(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Settings_Update_LogoBySA]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@Logo_ImgType", SqlDbType.Int).Value = objUser.Logo_ImgType;
                dbCmd.Parameters.Add("@Logo_ImgPath", SqlDbType.VarChar).Value = objUser.Logo_ImgPath;
                dbCmd.Parameters.Add("@Logo_ImgName", SqlDbType.VarChar).Value = objUser.Logo_ImgName;
                dbCmd.Parameters.Add("@Logo_ImgActualName", SqlDbType.VarChar).Value = objUser.Logo_ImgActualName;
              
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

        public int Update_Settings_HomePageDefaults(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_Settings_Update_HomePage_Defaults, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                //dbCmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = objUser.CompanyName;
                //dbCmd.Parameters.Add("@CompanyInfo", SqlDbType.NVarChar).Value = objUser.CompanyInfo;
                dbCmd.Parameters.Add("@CopyRightInfo", SqlDbType.NVarChar).Value = objUser.CopyRightInfo;

                dbCmd.Parameters.Add("@TopMenuLinks", SqlDbType.VarChar).Value = objUser.TopMenuLinks;
                //dbCmd.Parameters.Add("@TopRowLinks", SqlDbType.VarChar).Value = objUser.TopRowLinks;

                dbCmd.Parameters.Add("@Logo_ImgID", SqlDbType.Int).Value = objUser.Logo_ImgID;
                //dbCmd.Parameters.Add("@Banner_ImgID", SqlDbType.Int).Value = objUser.Banner_ImgID;
               // dbCmd.Parameters.Add("@DefLanguague", SqlDbType.Char).Value = objUser.DefLanguage;
                dbCmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objUser.ModifiedBy;

                dbCmd.Parameters.Add("@Logo_ImgType", SqlDbType.Int).Value = objUser.Logo_ImgType;
                dbCmd.Parameters.Add("@Logo_ImgPath", SqlDbType.VarChar).Value = objUser.Logo_ImgPath;
                dbCmd.Parameters.Add("@Logo_ImgName", SqlDbType.VarChar).Value = objUser.Logo_ImgName;
                dbCmd.Parameters.Add("@Logo_ImgActualName", SqlDbType.VarChar).Value = objUser.Logo_ImgActualName;

                //dbCmd.Parameters.Add("@Banner_ImgType", SqlDbType.Int).Value = objUser.Banner_ImgType;
                //dbCmd.Parameters.Add("@Banner_ImgPath", SqlDbType.VarChar).Value = objUser.Banner_ImgPath;
                //dbCmd.Parameters.Add("@Banner_ImgName", SqlDbType.VarChar).Value = objUser.Banner_ImgName;
                //dbCmd.Parameters.Add("@Banner_ImgActualName", SqlDbType.VarChar).Value = objUser.Banner_ImgActualName;

                dbCmd.Parameters.Add("@User_LogoTicked", SqlDbType.Bit).Value = objUser.User_LogoTicked;
                //dbCmd.Parameters.Add("@USer_BannerTicked", SqlDbType.Bit).Value = objUser.User_BannerTicked;



                
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




        public int Update_Settings_HomePageDefaults22(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_Settings_Update_HomePageData22", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                //dbCmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = objUser.CompanyName;
                //dbCmd.Parameters.Add("@CompanyInfo", SqlDbType.NVarChar).Value = objUser.CompanyInfo;
                dbCmd.Parameters.Add("@CopyRightInfo", SqlDbType.NVarChar).Value = objUser.CopyRightInfo;

                dbCmd.Parameters.Add("@TopMenuLinks", SqlDbType.VarChar).Value = objUser.TopMenuLinks;
                dbCmd.Parameters.Add("@TopRowLinks", SqlDbType.VarChar).Value = objUser.TopRowLinks;

                dbCmd.Parameters.Add("@Logo_ImgID", SqlDbType.Int).Value = objUser.Logo_ImgID;
                //dbCmd.Parameters.Add("@Banner_ImgID", SqlDbType.Int).Value = objUser.Banner_ImgID;
                // dbCmd.Parameters.Add("@DefLanguague", SqlDbType.Char).Value = objUser.DefLanguage;
                dbCmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objUser.ModifiedBy;

                dbCmd.Parameters.Add("@Logo_ImgType", SqlDbType.Int).Value = objUser.Logo_ImgType;
                dbCmd.Parameters.Add("@Logo_ImgPath", SqlDbType.VarChar).Value = objUser.Logo_ImgPath;
                dbCmd.Parameters.Add("@Logo_ImgName", SqlDbType.VarChar).Value = objUser.Logo_ImgName;
                dbCmd.Parameters.Add("@Logo_ImgActualName", SqlDbType.VarChar).Value = objUser.Logo_ImgActualName;

                //dbCmd.Parameters.Add("@Banner_ImgType", SqlDbType.Int).Value = objUser.Banner_ImgType;
                //dbCmd.Parameters.Add("@Banner_ImgPath", SqlDbType.VarChar).Value = objUser.Banner_ImgPath;
                //dbCmd.Parameters.Add("@Banner_ImgName", SqlDbType.VarChar).Value = objUser.Banner_ImgName;
                //dbCmd.Parameters.Add("@Banner_ImgActualName", SqlDbType.VarChar).Value = objUser.Banner_ImgActualName;

                dbCmd.Parameters.Add("@User_LogoTicked", SqlDbType.Bit).Value = objUser.User_LogoTicked;
                //dbCmd.Parameters.Add("@USer_BannerTicked", SqlDbType.Bit).Value = objUser.User_BannerTicked;




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

        public int Update_WebSettings(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_WebSettings_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@CopyRightInfo", SqlDbType.NVarChar).Value = objUser.CopyRightInfo;

                dbCmd.Parameters.Add("@TopMenuLinks", SqlDbType.VarChar).Value = objUser.TopMenuLinks;
                dbCmd.Parameters.Add("@TopRowLinks", SqlDbType.VarChar).Value = objUser.TopRowLinks;
                dbCmd.Parameters.Add("@LanguagueCode", SqlDbType.TinyInt).Value = objUser.DefLanguage;
                dbCmd.Parameters.Add("@LanguagueDropDown", SqlDbType.VarChar).Value = objUser.LanguagesDp;
                dbCmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objUser.ModifiedBy;

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


        public int Update_LogoSettings(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_LogoSettings_Update", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
               
                dbCmd.Parameters.Add("@Logo_ImgID", SqlDbType.Int).Value = objUser.Logo_ImgID;
                dbCmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objUser.ModifiedBy;

                dbCmd.Parameters.Add("@Logo_ImgType", SqlDbType.Int).Value = objUser.Logo_ImgType;
                dbCmd.Parameters.Add("@Logo_ImgPath", SqlDbType.VarChar).Value = objUser.Logo_ImgPath;
                dbCmd.Parameters.Add("@Logo_ImgName", SqlDbType.VarChar).Value = objUser.Logo_ImgName;
                dbCmd.Parameters.Add("@Logo_ImgActualName", SqlDbType.VarChar).Value = objUser.Logo_ImgActualName;

                dbCmd.Parameters.Add("@User_LogoTicked", SqlDbType.Bit).Value = objUser.User_LogoTicked;
               
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

        
        public int Upload_BannerLogo_BySA(CMSv3.Entities.AdminSettings objUser, int vUserID,int vCategoryID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand(SP_SA_Upload_BannerLogo, dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                
                dbCmd.Parameters.Add("@Logo_ImgType", SqlDbType.Int).Value = objUser.Logo_ImgType;
                dbCmd.Parameters.Add("@Logo_ImgPath", SqlDbType.VarChar).Value = objUser.Logo_ImgPath;
                dbCmd.Parameters.Add("@Logo_ImgName", SqlDbType.VarChar).Value = objUser.Logo_ImgName;
                dbCmd.Parameters.Add("@Logo_ImgActualName", SqlDbType.VarChar).Value = objUser.Logo_ImgActualName;

                dbCmd.Parameters.Add("@Banner_ImgType", SqlDbType.Int).Value = objUser.Banner_ImgType;
                dbCmd.Parameters.Add("@Banner_ImgPath", SqlDbType.VarChar).Value = objUser.Banner_ImgPath;
                dbCmd.Parameters.Add("@Banner_ImgName", SqlDbType.VarChar).Value = objUser.Banner_ImgName;
                dbCmd.Parameters.Add("@Banner_ImgActualName", SqlDbType.VarChar).Value = objUser.Banner_ImgActualName;
                dbCmd.Parameters.Add("@Banner_CategoryID", SqlDbType.Int).Value = vCategoryID;
                

                
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


        public int Update_AnchorImageSettings(CMSv3.Entities.AdminSettings objUser, int vUserID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_AnchorImageSettings_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;

                //..UserDetails
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;

                dbCmd.Parameters.Add("@Anchor_ImgID", SqlDbType.Int).Value = objUser.Logo_ImgID;
                dbCmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = objUser.ModifiedBy;

                dbCmd.Parameters.Add("@Anchor_ImgType", SqlDbType.Int).Value = objUser.Logo_ImgType;
                dbCmd.Parameters.Add("@Anchor_ImgPath", SqlDbType.VarChar).Value = objUser.Logo_ImgPath;
                dbCmd.Parameters.Add("@Anchor_ImgName", SqlDbType.VarChar).Value = objUser.Logo_ImgName;
                dbCmd.Parameters.Add("@Anchor_ImgActualName", SqlDbType.VarChar).Value = objUser.Logo_ImgActualName;

                dbCmd.Parameters.Add("@User_AnchorTicked", SqlDbType.Bit).Value = objUser.User_LogoTicked;

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


       

        public DataSet Retrieve_Settings_TopRowLinks(int vUserId)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Settings_Retrieve_TopRowLinks_ByUserID]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserId", SqlDbType.Int).Value = vUserId;

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


