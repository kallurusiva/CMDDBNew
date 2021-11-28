using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PhyBook
/// </summary>
public class PhyBook
{


    #region variables

    protected static SqlConnection dbConn;
    protected static SqlCommand dbCmd;
    protected static SqlDataAdapter dbAdap;
    protected static SqlDataReader dbReader;
    static DataSet ds;
    //DataTable dt;

    static string eBookdbConnString = ConfigurationManager.AppSettings["eBookDB"].ToString();



    #endregion


	static PhyBook()
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
    /// <param name="ebook">EBook</param>
    /// <returns>Int</returns>
    /// <remarks>Validate user login</remarks> 

    public static DataSet PhyBook_GetTemplates_ByBookID(int vPhyBookID)
    {
        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();
            dbCmd = new SqlCommand("USP_Phy_AD_GetTemplates_ByBookID", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vPhyBookID", SqlDbType.Int).Value = vPhyBookID;
            
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


    public static int PhyBook_Template_ADD(int vPhyBookID, string vTemplateName, String vImgFileName)
    {

        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("[usp_Phy_AD_TemplateADD]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vPhyBookID", SqlDbType.Int).Value = vPhyBookID;
            dbCmd.Parameters.Add("@vTemplateName", SqlDbType.NVarChar).Value = vTemplateName;
            dbCmd.Parameters.Add("@vImageFileName", SqlDbType.NVarChar).Value = vImgFileName;
            
            dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

            int status = dbCmd.ExecuteNonQuery();
            //return status;

            int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


    public static DataSet PhyBook_Listing(string vSearchStr)
    {
        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("[usp_Phy_AD_ebookListing]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


    public static int PhyBook_Update(int vPhyBookID, string vPhyBookName)
    {

        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("[usp_Phy_AD_Update]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vPhyBookID", SqlDbType.Int).Value = vPhyBookID;
            dbCmd.Parameters.Add("@vPhyBookName", SqlDbType.NVarChar).Value = vPhyBookName;
            dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

            int status = dbCmd.ExecuteNonQuery();
            //return status;

            int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


    public static int PhyBook_Delete(int vPhyBookID)
    {

        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("[usp_Phy_AD_Delete]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vPhyBookID", SqlDbType.Int).Value = vPhyBookID;
            
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


    public static int PhyBook_Template_Delete(int vTemplateID)
    {

        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("[usp_Phy_AD_Tempalte_Delete]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vTemplateID", SqlDbType.Int).Value = vTemplateID;

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


    public static DataSet PhyBook_Requests(string vSearchStr)
    {
        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("[usp_Phy_AD_ViewRequests]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = vSearchStr;

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


    public static DataSet PhyBook_Requests_ByID(int vPhyReqID)
    {
        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("[usp_Phy_AD_ViewRequests_ByID]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vPhyReqID", SqlDbType.Int).Value = vPhyReqID;

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


    public static int PhyBook_Request_ChangeStatus(int vRequestID, String vStatus, String vRemarks )
    {

        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("[usp_Phy_AD_ChangeReqStatus]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vRequestID", SqlDbType.Int).Value = vRequestID;
            dbCmd.Parameters.Add("@vStatus", SqlDbType.VarChar).Value = vStatus;
            dbCmd.Parameters.Add("@vRemarks", SqlDbType.VarChar).Value = vRemarks;

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

    public static DataSet PhyBook_BizCard_GetTemplates()
    {
        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();
            dbCmd = new SqlCommand("USP_Phy_AD_BizCards_GetTemplates", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
          
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


    public static int PhyBook_BizCard_ADD(string vBizCardName, String vImgFileName)
    {

        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("[usp_Phy_AD_BizCardADD]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vBizCardName", SqlDbType.NVarChar).Value = vBizCardName;
            dbCmd.Parameters.Add("@vImageFileName", SqlDbType.NVarChar).Value = vImgFileName;

            dbCmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;

            int status = dbCmd.ExecuteNonQuery();
            //return status;

            int MyResult = (int)dbCmd.Parameters["@result"].Value;
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


    public static int PhyBook_BizCard_Delete(int vBizCardID)
    {

        try
        {
            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("[usp_Phy_AD_BizCard_Delete]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vBizCardID", SqlDbType.Int).Value = vBizCardID;

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