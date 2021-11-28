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
    public class Buyer
    {


        #region variables

        protected SqlConnection dbConn;
        protected SqlCommand dbCmd;
        protected SqlDataAdapter dbAdap;
        protected SqlDataReader dbReader;
        DataSet ds;
       // DataTable dt;

        string eBookdbConnString = ConfigurationSettings.AppSettings["eBookDB"].ToString();



        #endregion




        #region Functionality


        public Buyer()
        {
            try
            {
                dbConn = new SqlConnection(eBookdbConnString);
               // dbConn.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }


        /// Function to User : Validate User Login
        /// </summary>
        /// <param name="Buyer">Buyer</param>
        /// <returns>DataSet</returns>
        /// <remarks>Validate user login for Buyer </remarks> 

        public DataSet Validate_UserLogin(String vLoginID, String vPassword)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();
                dbCmd = new SqlCommand("USP_Byr_ValidateLogin", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vLoginID", SqlDbType.VarChar).Value = vLoginID;
                dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = vPassword;

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




        
        public int ChangePassword_PreCheck(String vMobileLoginID, String vCurrPassword)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("usp_Byr_ChangePwdCheck", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;
                dbCmd.Parameters.Add("@vCurrentPassword", SqlDbType.VarChar).Value = vCurrPassword;
                dbCmd.Parameters.Add("@vResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                int status = dbCmd.ExecuteNonQuery();
                int MyResult = (int)dbCmd.Parameters["@vResult"].Value;
                return MyResult;

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


        public int ChangePassword(int vUserID,String vMobileLoginID,  String vCurrPassword, String vNewPassword)
        {
            try
            {
                if (dbConn.State == ConnectionState.Closed)
                    dbConn.Open();

                dbCmd = new SqlCommand("[usp_Byr_ChangePassword_Update]", dbConn);
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add("@vUserID", SqlDbType.Int).Value = vUserID;
                dbCmd.Parameters.Add("@vMobileLoginID", SqlDbType.VarChar).Value = vMobileLoginID;
                dbCmd.Parameters.Add("@CurrPassword", SqlDbType.VarChar).Value = vCurrPassword;
                dbCmd.Parameters.Add("@NewPassword", SqlDbType.VarChar).Value = vNewPassword;
                

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


     
       
        


        #endregion








    }

       
    
    
    }


