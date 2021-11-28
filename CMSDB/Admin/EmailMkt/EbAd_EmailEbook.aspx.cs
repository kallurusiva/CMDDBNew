using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;


public partial class Admin_EmailMkt_EbAd_EmailEbook : System.Web.UI.Page
{
    DataSet ds;

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    CMSv3.BAL.AccountSettings objBAL_ActSettings = new CMSv3.BAL.AccountSettings();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        if (!IsPostBack)
        {
            ViewState["isValueBook"] = "0";

            int tmpStatus = objBALebook.Check_EmailSystem(Session["UserID"].ToString());
          
            if (tmpStatus == -1)
            {
                CommonFunctions.AlertMessageAndRedirect("Please Register Your Own Domain before able to use this facility", @"../Ad_DomainRegEbook.aspx");
            }
            else if (tmpStatus == -2)
            {
                CommonFunctions.AlertMessageAndRedirect("You must have Your Own Email System before able to use this facility", @"../Ads_EmailPageEbook.aspx");
            }
            else
            {
                UserDetails();
                
            }
        }
    }
    protected void UserDetails()
    {
        ds = objBAL_ActSettings.RetrieveALL_Settings_HomePageData(Convert.ToInt32(Session["UserId"]));
       
        if (ds.Tables[0].Rows.Count > 0)
        {            
            TextBoxYourName.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        String tmpBookID = txtBookID.Text;

        ds = objBALebook.Ebook_RetrieveDetails(tmpBookID, Convert.ToInt32(Session["UserID"].ToString()), Session["MobileLoginID"].ToString().Replace("EB", ""));

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow1 = ds.Tables[0].Rows[0];
            Server.Transfer(@"EbAd_SendEBookbyEmailNow.aspx");
        }
        else
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "No Book found with this BookID. Please enter another BookID.";
        }
    }   
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}