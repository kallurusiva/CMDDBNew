using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

public partial class EBAd_Dashboard : System.Web.UI.Page 
{

    DataSet ds;
    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

    int vUserID = 0;
    int vMerchantID = 0;
    String vMobileLoginID = string.Empty;
    String vEStoreID = string.Empty; 


    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check 

        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 


       

        if (!IsPostBack)
        {

             vUserID = Convert.ToInt32(Session["UserID"].ToString());
             vMerchantID = 0;
             vMobileLoginID = "";

             if (Session["MERID"] != null)
                 vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
             else
                 vMerchantID = 0;


             if (Session["MobileLoginID"] != null)
                 vMobileLoginID = Session["MobileLoginID"].ToString();
             else
                 vMobileLoginID = ""; 

            
             LoadDashBoard(); 
             CheckEStoreID(vUserID);
             LoadKeywordDetails(vUserID); 

        }

        tblMessageBar.Visible = false;
        
    }

    protected void CheckEStoreID(int vUserID)
    {

        ds = objEbook.Ebook_GeteStoreID(vUserID); 

        if(ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            vEStoreID = dr["eStoreID"].ToString();


            if (vEStoreID == "NOTCREATED")
            {
                Response.Redirect("EbAd_CreateStoreID.aspx"); 
            }
            else
            {
                lblEstoreID.Text = vEStoreID;
                ViewState["eStoreID"] = vEStoreID;
            }


        }


    }

    protected void LoadDashBoard()
    {


      

        ds = objEbook.Ebook_DashBoard(vUserID, vMerchantID, vMobileLoginID);

        DataTable dt = ds.Tables[0]; 

        if(dt.Rows.Count > 0)
        {

            DataRow dr = dt.Rows[0];

            lblAdmCatCount.Text = dr["Adm_CatCount"].ToString(); 
            lblUser_CatCount.Text = dr["Usr_CatCount"].ToString();

            lblAdm_EbookCnt.Text = dr["AdmFullCount"].ToString();
            //lblAdm_FBCount.Text = dr["Adm_FB_Fullcount"].ToString();
            //lblAdm_BSCount.Text = dr["Adm_BS_Fullcount"].ToString();
            //lblAdm_VBCount.Text = "0";


            lblUser_EBCount.Text = dr["UsrFullcount"].ToString();
            //lblUser_FBCount.Text = dr["Usr_FB_Fullcount"].ToString();
            //lblUser_BSCount.Text = dr["Usr_BS_Fullcount"].ToString();
            //lblUser_VBCount.Text = "0";

            //lblSmsCreditBalance.Text = dr["SmsCreditBalance"].ToString(); 

            lblAdmMainCount.Text = dr["Adm_main_CatCount"].ToString();
            lblUser_Maincount.Text = dr["Usr_main_Catcount"].ToString();

            String tmpBalance = dr["SmsCreditBalance"].ToString();
            Session["SmsCreditBalance"] = tmpBalance; 

            lblSmsCreditBalance.Text = String.Format("{0:n2}", Convert.ToDecimal(tmpBalance));


        }


    }

    protected void LoadKeywordDetails(int vUserId)
    {

        DataSet ds2;
        ds2 = objEbook.Ebook_KeywordDetails_ByUserID(vUserId);

        if (ds2.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds2.Tables[0].Rows[0];

            Session["EbUserKeyword"] = krow["VendorCode"].ToString();
            Session["EbUserPackageType"] = Convert.ToInt32(krow["PackageType"].ToString());
            Session["EbUserType"] = krow["ebUserType"].ToString();
            Session["EbookPrice"] = krow["Price"].ToString();

        }
        else
        {
            Session["EbUserKeyword"] = "";
            Session["EbUserPackageType"] = "";
            Session["EbUserType"] = "";
            Session["EbookPrice"] = "";
        }

    }

   

}
