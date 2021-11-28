using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CMSv3.Entities;

namespace CMSv3.DAL
{
    public class MbOwnButtons
    {
        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataReader dbReader;
        protected SqlDataAdapter dbAdap;


        DataSet ds;



        String dbConnString = ConfigurationSettings.AppSettings["CMSdb"].ToString();
        string strSQL = string.Empty;


        public MbOwnButtons()
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



        public DataSet Retrieve_OwnButtonContent(int vButtonNo, int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                
                dbCmd = new SqlCommand("usp_mb_OwnBtn_Retrieve", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vButtonNo", SqlDbType.Int).Value = vButtonNo;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;

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



        public int Save_OwnButtonContent(int vUserBtnNo, int vUserId, string vBtnName, string vBtnContent, int vBtnIconImgID, string vBtnVideoLink, CMSv3.Entities.AdminSettings objImageData)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_mb_OwnBtn_Save]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserBtnNo", SqlDbType.Int).Value = vUserBtnNo;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
               // dbCmd.Parameters.Add("@vActive", SqlDbType.Bit).Value = vActive;
                dbCmd.Parameters.Add("@vBtnName", SqlDbType.NVarChar).Value = vBtnName;
                dbCmd.Parameters.Add("@vBtnContent", SqlDbType.NVarChar).Value = vBtnContent;
                dbCmd.Parameters.Add("@vBtnVideoLink", SqlDbType.VarChar).Value = vBtnVideoLink;

                dbCmd.Parameters.Add("@vBtnIconImgID", SqlDbType.Int).Value = objImageData.Logo_ImgID;
                dbCmd.Parameters.Add("@Icon_ImgType", SqlDbType.Int).Value = objImageData.Logo_ImgType;
                dbCmd.Parameters.Add("@Icon_ImgPath", SqlDbType.VarChar).Value = objImageData.Logo_ImgPath;
                dbCmd.Parameters.Add("@Icon_ImgName", SqlDbType.VarChar).Value = objImageData.Logo_ImgName;
                dbCmd.Parameters.Add("@Icon_ImgActualName", SqlDbType.VarChar).Value = objImageData.Logo_ImgActualName;
                dbCmd.Parameters.Add("@User_LogoTicked", SqlDbType.Bit).Value = objImageData.User_LogoTicked;


                dbCmd.Parameters.Add("@Picture_ImgID", SqlDbType.Int).Value = objImageData.Banner_ImgID;
                dbCmd.Parameters.Add("@Picture_ImgType", SqlDbType.Int).Value = objImageData.Banner_ImgType;
                dbCmd.Parameters.Add("@Picture_ImgPath", SqlDbType.VarChar).Value = objImageData.Banner_ImgPath;
                dbCmd.Parameters.Add("@Picture_ImgName", SqlDbType.VarChar).Value = objImageData.Banner_ImgName;
                dbCmd.Parameters.Add("@Picture_ImgActualName", SqlDbType.VarChar).Value = objImageData.Banner_ImgActualName;




                int status = dbCmd.ExecuteNonQuery();
                return status;
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


        public DataSet Retrieve_OwnButtonIcons(int vUserId)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_mb_OwnBtn_RetrieveIcons]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;

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


        public int Delete_UserIcon(int vImageID)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_mb_DeleteUserIcon", dbConn);
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


        public int Delete_UserImage(int vUserID,int vButtonNo)
        {


            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_mb_DeleteUserImage]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vButtonNo", SqlDbType.Int).Value = vButtonNo;

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


        public int Save_AnchorImage(int vUserId, CMSv3.Entities.AdminSettings objImageData)
        {

            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_mb_AnchorImg_Save]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserId;
                
                dbCmd.Parameters.Add("@vImgID", SqlDbType.Int).Value = objImageData.Logo_ImgID;
                dbCmd.Parameters.Add("@ImgType", SqlDbType.Int).Value = objImageData.Logo_ImgType;
                dbCmd.Parameters.Add("@ImgPath", SqlDbType.VarChar).Value = objImageData.Logo_ImgPath;
                dbCmd.Parameters.Add("@ImgName", SqlDbType.VarChar).Value = objImageData.Logo_ImgName;
                dbCmd.Parameters.Add("@ImgActualName", SqlDbType.VarChar).Value = objImageData.Logo_ImgActualName;
                

                int status = dbCmd.ExecuteNonQuery();
                return status;
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

    }
}
