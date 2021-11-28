using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;

public partial class Admin_EbAd_RegDashboardFreet : BasePage
{
    string strSQL = string.Empty;



    String vWelcomePageText = string.Empty;
    String vPhotoURL = string.Empty;
    String vFBpageURL = string.Empty;
    string vSubDomainStatus = string.Empty;


    //long MaxImageSize = 1024000;   // 1MB




    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();

    CMSv3.BAL.User objUser = new CMSv3.BAL.User();

    protected void Page_Load(object sender, EventArgs e)
    {


        #region  // SessionCheck
        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion



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



        if ((Session.SessionID != null) && (Session["UserID"] != null))
            lblSessionValues.Text = Session.SessionID + " | " + Session["UserID"].ToString();

        if (!IsPostBack)
        {

            // LoadTemplateInfo();
            LoadRegStatus();




        }

    }



    protected void LoadRegStatus()
    {


        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        DataSet ds = objEbook.EBook_RegProcess_GetDetails(vUserID);

        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataRow tRow = ds.Tables[0].Rows[0];

                bool vDomain = Convert.ToBoolean(tRow["Domain"].ToString());
                bool vStoreID = Convert.ToBoolean(tRow["StoreID"].ToString());
                bool vProfile = Convert.ToBoolean(tRow["Profile"].ToString());
                bool vPhyBook = Convert.ToBoolean(tRow["PhyBook"].ToString());
                bool vVendorCode = Convert.ToBoolean(tRow["VendorCode"].ToString());
                vSubDomainStatus = tRow["subdomain"].ToString();
                string subdomainVal = tRow["subdomainVal"].ToString();
                string storeidVal = tRow["storeidVal"].ToString();
                string domainVal = tRow["domainVal"].ToString();

                //if (mlmStat == "1")
                //{
                //    Server.Transfer("EbAd_ModifySubDomain.aspx");
                //}


                if (vSubDomainStatus=="1")
                {
                    lblStepDomain.Text = subdomainVal + "";
                    lblStepDomain.CssClass = "fontRegCompleted";

                }

                if (vStoreID)
                {
                    lblStepStoreID.Text = storeidVal + "";
                    lblStepStoreID.CssClass = "fontRegCompleted";
                }


                if (vProfile)
                {
                    //lblStepProfile.Text = "Completed";
                    //lblStepProfile.CssClass = "fontRegCompleted";
                }

                if (vPhyBook)
                {
                    //lblStepPhysicalBook.Text = "Completed";
                    //lblStepPhysicalBook.CssClass = "fontRegCompleted";
                }



                if (Session["EbUserPackageType"] != null)
                {
                    int PkgType = Convert.ToInt32(Session["EbUserPackageType"].ToString());

                    //.. if PkgType = 1 ... AV user. 

                    if (PkgType == 1)
                    {
                        //lblStepVendorCode.Text = "Only for PV user";

                        //trStep4.Visible = false;
                        //trStep5.Visible = false; 


                    }
                    else
                    {
                        if (vVendorCode)
                        {
                            //lblStepVendorCode.Text = "Completed";
                            //lblStepVendorCode.CssClass = "fontRegCompleted";
                        }

                        //trStep4.Visible = false;
                        ////trStep5.Visible = true;
                        //trStep5.Visible = false; 
                    }



                }
                else
                {
                    if (vVendorCode)
                    {
                        //lblStepVendorCode.Text = "Completed";
                        //lblStepVendorCode.CssClass = "fontRegCompleted";
                    }
                }



            }

        }


    }





}
