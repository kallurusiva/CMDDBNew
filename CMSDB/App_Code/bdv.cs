using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for bdv
/// </summary>
public class bdv
{

    #region Variables

    protected SqlConnection dbConn;
    protected SqlCommand dbCmd;
    protected SqlDataReader dbReader;
    protected SqlDataAdapter dbAdap;

    DataSet ts;
    String dbConnString = String.Empty;
    String strSQL = String.Empty;

    #endregion

	public bdv()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet admin_login(string wAdminID, string wAdminPassword)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_adminLogin", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@adminID", SqlDbType.VarChar).Value = wAdminID;
            dbCmd.Parameters.Add("@adminPassword", SqlDbType.VarChar).Value = wAdminPassword;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_getPassword(string wAdminID)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_getPasswordAdmin", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vMobile", SqlDbType.VarChar).Value = wAdminID;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_updatePassword(string wAdminPassword)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_UpdatePasswordAdmin", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vPassword", SqlDbType.VarChar).Value = wAdminPassword;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_getCountryList(string wCountrycode)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_getCountryList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ccode", SqlDbType.VarChar).Value = wCountrycode;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_categoryAdd(string wCountrycode, string wCategory)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_CategoryAdd", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ccode", SqlDbType.VarChar).Value = wCountrycode;
            dbCmd.Parameters.Add("@category", SqlDbType.VarChar).Value = wCategory;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_getCategoriesList(string wCountrycode)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_getCategoriesList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ccode", SqlDbType.VarChar).Value = wCountrycode;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_getSubCategoriesList(string wCountrycode)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_getSubCategoriesList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@ccode", SqlDbType.VarChar).Value = wCountrycode;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_subcategoryAdd(string wCatID, string wSubCategory)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_subCategoryAdd", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@catid", SqlDbType.VarChar).Value = wCatID;
            dbCmd.Parameters.Add("@subcategory", SqlDbType.VarChar).Value = wSubCategory;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_categoriesList(string wCCode, string wPageNo, string wSearchStr)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_categoriesList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vCCode", SqlDbType.VarChar).Value = wCCode;
            dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = wPageNo;
            dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = wSearchStr;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_categoryUpdate(string wUID, string wCategory)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_CategoryUpdate", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@uid", SqlDbType.VarChar).Value = wUID;
            dbCmd.Parameters.Add("@category", SqlDbType.VarChar).Value = wCategory;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_subcategoriesList(string wCatID, string wPageNo, string wSearchStr)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_subcategoriesList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vCatID", SqlDbType.VarChar).Value = wCatID;
            dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = wPageNo;
            dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = wSearchStr;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_subcategoryUpdate(string wUID, string wsubCategory)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_subCategoryUpdate", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@uid", SqlDbType.VarChar).Value = wUID;
            dbCmd.Parameters.Add("@subcategory", SqlDbType.VarChar).Value = wsubCategory;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_UploadVoucher(string vUserID, string vName, string vDesc, string vImage, string vsubCatID, string vQuantity, string fDate, string tDate)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_VoucherCode_Insert", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vUserID", SqlDbType.VarChar).Value = vUserID;
            dbCmd.Parameters.Add("@vName", SqlDbType.VarChar).Value = vName;
            dbCmd.Parameters.Add("@vDescription", SqlDbType.VarChar).Value = vDesc;
            dbCmd.Parameters.Add("@vImage", SqlDbType.VarChar).Value = vImage;
            dbCmd.Parameters.Add("@vsubCatID", SqlDbType.VarChar).Value = vsubCatID;
            dbCmd.Parameters.Add("@vQuantity", SqlDbType.SmallInt).Value = vQuantity;
            dbCmd.Parameters.Add("@fDate", SqlDbType.VarChar).Value = fDate;
            dbCmd.Parameters.Add("@tDate", SqlDbType.VarChar).Value = tDate;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);

            return ts;
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

    public DataSet admin_VoucherList(string wPageNo, string wSearchStr)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_VoucherList", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vPageNo", SqlDbType.Int).Value = wPageNo;
            dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = wSearchStr;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet admin_VoucherSuspend(string vCode)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_VoucherDelete", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vcode", SqlDbType.VarChar).Value = vCode;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet main_getCategoriesCount(string cCode)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_getCategoriesCount", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@cCode", SqlDbType.VarChar).Value = cCode;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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

    public DataSet main_VoucherList(string cCode, string wSearchStr)
    {
        try
        {
            dbConnString = ConfigurationManager.AppSettings["CMSdb"].ToString();
            dbConn = new SqlConnection(dbConnString);

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("esms.dbo.USPT_BV_getVouchersDiaplay", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@cCode", SqlDbType.VarChar).Value = cCode;
            dbCmd.Parameters.Add("@vSearchStr", SqlDbType.VarChar).Value = wSearchStr;

            dbAdap = new SqlDataAdapter(dbCmd);
            ts = new DataSet();
            dbAdap.Fill(ts);
            return ts;
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