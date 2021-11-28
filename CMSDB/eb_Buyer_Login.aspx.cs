using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using CMSv3.BAL;
using System.Threading;


public partial class eb_Buyer_Login : UserWeb
{


    CMSv3.BAL.Buyer objBuyer = new CMSv3.BAL.Buyer(); 
    //DataSet ds;
    //DataTable dt;
    //int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0; 


    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = "~/UserEbookMaster.master";
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["ClientID"].ToString() == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        #region //rendering top left panel 

        if (!Session["MasterPageCss"].ToString().Contains("TmpStyleSheet")) 
        {

            HtmlGenericControl myDivObject;
            myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

            //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
            sb.Append("<tr>");
            sb.Append("<td align='left' valign='top'>");
            sb.Append("<img src='Images/table_top_Leftarc.gif' />");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            myDivObject.InnerHtml = sb.ToString();

            //myDivObject.InnerHtml = "<table border='0' class='dvBannerLeftPanel'><tr><td><img alt='imbnLeftimg' src='Images/faq_head.jpg' /> </td></tr></table>";
        }
        #endregion 


          
        if (!IsPostBack)
        {
            ViewState["TotalAmount"] = "00.00";

            if (Request.QueryString["CpUri"] != null)
            {
                ViewState["CallingPage"] = Request.QueryString["CpUri"].ToString();
            }
            else
            {
                ViewState["CallingPage"] = "eBooksList.aspx"; 
            }
            

          
        }


    }






    protected void LnkBtnContinueShopping_Click(object sender, EventArgs e)
    {
        String tmpURI =  ViewState["CallingPage"] .ToString();
        Response.Redirect(tmpURI);
    }


    protected void lnkCheckOut2PayPal_Click(object sender, EventArgs e)
    {


        String tmpURI = ViewState["CallingPage"].ToString();

        String vURL = "eBooksvCartConfirm.aspx?CpUri=" + tmpURI; 

        Response.Redirect(vURL); 
    }



    protected void LnkDirectBankIn_Click(object sender, EventArgs e)
    {

        String tmpURI = ViewState["CallingPage"].ToString();

        String vURL = "eBooksBankInPre.aspx?CpUri=" + tmpURI;
      //  String vURL = "eBooksBankInSubmit.aspx?CpUri=" + tmpURI;

        Response.Redirect(vURL); 
    }

    protected void BtnSignin_Click(object sender, EventArgs e)
    {

        String vEmailID = txtEmailID.Text.Trim();
        String vPassowrd = txtPassword.Text.Trim();


        DataSet ds = objBuyer.Validate_UserLogin(vEmailID, vPassowrd); 




    }
}




