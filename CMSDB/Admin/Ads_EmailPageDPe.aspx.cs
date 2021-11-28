using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Admin_Ads_EmailPageDPe : System.Web.UI.Page
{
    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //string strSQL;
    DataSet ds; 


    string tmpWpDescription = string.Empty;
    //int qLgType = 1;
    //int mLanguage = 1;
    //String mAccountType = "";
    //int isPurchased = 0;
    //int isSMEPurchased = 0; 

    CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
    CMSv3.BAL.GemailSystem objBAL_Gems = new CMSv3.BAL.GemailSystem();
    CMSv3.BAL.MalaysiaSMS objBAL_MasUser = new CMSv3.BAL.MalaysiaSMS(); 

    protected void Page_Load(object sender, EventArgs e)
    {


        #region

        if (Session["UserID"] == null)
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        else
        {
            if(Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 





        if (!IsPostBack)
        {

           


           // LoadUserDetails((Session["UserID"].ToString()));





            #region Code to Hide Left ContentHolder

            //HtmlGenericControl myDivLeftBar;
            //myDivLeftBar = (HtmlGenericControl)Page.Master.FindControl("divLeftBar");

            //myDivLeftBar.Style.Clear();
            //myDivLeftBar.Style.Value = "width:0px;";


            //HtmlGenericControl myDivRightBar;
            //myDivRightBar = (HtmlGenericControl)Page.Master.FindControl("divRightBar");

            //myDivRightBar.Style.Clear();
            //myDivRightBar.Style.Value = " width: 96%; padding-left:20px;";

            #endregion

            String vUserID = Session["UserID"].ToString(); 

            String vMobileID = Session["MobileLoginID"].ToString();

            vMobileID = vMobileID.Replace("DPE", "");

            ViewState["vMobileLoginID"] = vMobileID;
           
                String vtrMessage = string.Empty;
                trPlatinum.Visible = true; 
                LoadEMSDetails(vUserID);
              //  trNotPurchased.Visible = false;


                   

        }

     }

    protected void LoadUserDetails(string vUserID)
    {

        string SearchStr = "Where U.UserID = " + vUserID;
        ds = objBAL_User.Retrieve_AllUserData(SearchStr, "");

        DataTable dtUserDetails;
        dtUserDetails = ds.Tables[0];

        foreach (DataRow URow in dtUserDetails.Rows)
        {
            ViewState["vMobileLoginID"] = URow["MobileLoginID"].ToString();
            ViewState["vOwnDomain"] = URow["OwnDomain"].ToString();
            ViewState["vDomainType"] = URow["UserDomainType"].ToString();


            //if (ViewState["vDomainType"].ToString() == "SME")
            //{
            //    ImgEmailLogo.ImageUrl = @"~/Images/zoho-mail.png";
            //    ltrPoweredBy.Text = " Zoho ";
            //}
            //else
            //{
            //    ImgEmailLogo.ImageUrl = @"~/Images/gmail-logo.png";
            //    ltrPoweredBy.Text = " Google ";
            //}
        }



    }

    protected void LoadEMSDetails(string vMobileLoginID)
    {
        string SearchStr = string.Empty;

        //SearchStr = " MobileLoginID = (Select MobileLoginID from tblUsers where UserID = " + vUserID + ")";
        //SearchStr = " and MobileLoginID = '" + vMobileLoginID + "'";
        //ds = objBAL_Gems.Retrieve_EMSContent(SearchStr);


        CMSv3.BAL.DPE objDPE = new CMSv3.BAL.DPE();

        ds = objDPE.DPE_Retrieve_EMSContent(vMobileLoginID, ""); 

        DataTable dtUserDetails;
        dtUserDetails = ds.Tables[0];

        if (dtUserDetails.Rows.Count > 0)
        {

            foreach (DataRow URow in dtUserDetails.Rows)
            {
                txtAdEmailID.Text = URow["AdminID"].ToString();
                txtEmailPwd.Text = URow["AdminPwd"].ToString();

                txtEnquiryID.Text = URow["EnquiryID"].ToString();
                txtEnquiryPwd.Text = URow["EnquiryPwd"].ToString();
                //txtHttpUrlLink.Text = URow["HttpURLLink"].ToString();
                HypGmailLink.Text = URow["HttpURLLink"].ToString();
                HypGmailLink.NavigateUrl = URow["HttpURLLink"].ToString();

               // HypAdminLoginID.Text = txtAdEmailID.Text;
                
            }
        }
        else
        {
           // trPlatinum.Visible = false;
            //trAlertEmailSystem.Visible = true;
        }
        


    }



}
