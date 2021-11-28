using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security;
using System.Security.Cryptography;
using CMSv3.BAL;

public partial class SuperAdmin_SA_EMSUploadGhtml : System.Web.UI.Page 
{
    //DataSet ds;
    //DataView dv;

    
    CMSv3.BAL.MalaysiaSMS objBAL_MasUser = new CMSv3.BAL.MalaysiaSMS();
    CMSv3.BAL.GemailSystem objBAL_Gems = new CMSv3.BAL.GemailSystem(); 

    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;

    //int qLgType = 0;

    string qMobileLoginID = string.Empty;
    string qFullName = string.Empty;




    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        //ltrAllUsersListing.Text = Resources.LangResources.All + " " +  Resources.LangResources.User + " " + Resources.LangResources.Listing;


        if (Request.QueryString["qMobileLoginID"].ToString() != null)
        {
            if (Request.QueryString["qMobileLoginID"].ToString() != "")
                qMobileLoginID = Request.QueryString["qMobileLoginID"].ToString();
        }

        if (Request.QueryString["qFullName"].ToString() != null)
        {
            if (Request.QueryString["qFullName"].ToString() != "")
                qFullName = Request.QueryString["qFullName"].ToString();
        }



        if (!IsPostBack)
        {

            ViewState["qMobileLoginID"] = qMobileLoginID;
            ViewState["qFullName"] = qFullName;

            lblMobileNo.Text = qMobileLoginID; 
            lblFullName.Text = qFullName;


        }


    }






    protected void btnUploadHTML_Click(object sender, EventArgs e)
    {


        if (FU_HtmlFile.HasFile)
        {
            string htmlFilePathtoStore = Server.MapPath("~") + @"\zohoverify\";

            FU_HtmlFile.SaveAs(htmlFilePathtoStore +  FU_HtmlFile.FileName);
            
            //lblUpMessage.Text = "Image to be uploaded : " + FU_HtmlFile.FileName + "<br/>";
        }

        CommonFunctions.AlertMessageAndRedirect("Html File as been Uploaded.", "SA_EMSUserListing.aspx"); 
       // Response.Redirect("SA_EMSUserListing.aspx"); 

    }
}