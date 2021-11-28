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

public partial class EbAd_CurrentDesign : BasePage
{
    string strSQL=string.Empty;
    


    String vWelcomePageText = string.Empty;
    String vPhotoURL = string.Empty;
    String vFBpageURL = string.Empty; 


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

      

        if((Session.SessionID != null) && (Session["UserID"] != null))
        lblSessionValues.Text = Session.SessionID + " | " + Session["UserID"].ToString();

        if (!IsPostBack)
        {
            
           // LoadTemplateInfo();
            LoadCurrentTemplate();
            DesginFrame.Attributes.Add("src", Session["UserDomainURL"].ToString());

          
           
        }

    }


    
    protected void LoadCurrentTemplate()
    {
        CMSv3.BAL.User objUser = new CMSv3.BAL.User(); 

        //GetSavedTemplateDetails
        DataSet ds = objUser.GetSavedTemplateDetails(Convert.ToInt32(Session["UserID"].ToString()));

        if (ds.Tables[0].Rows.Count > 0)
        {

            DataRow tRow = ds.Tables[0].Rows[0];

            String tmpMasterfile = tRow["MasterPageName"].ToString();
            String tmpMasterCss = tRow["MasterCSS"].ToString();


            switch (tmpMasterfile)
            {

                case "TmpMasterGen1.master": ltrHeader.Text = "Your current Web Design Template : Web Design 1";
                    break;

                case "TmpMasterGen2.master": ltrHeader.Text = "Your current Web Design Template : Web Design 2";
                    break;

                case "TmpMasterGen3.master": ltrHeader.Text = "Your current Web Design Template : Web Design 3";
                    break;

            }
        }

    }
   



     
}
