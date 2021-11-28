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


public partial class eBooksvCartConfirm : UserWeb
{

    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 
    DataSet ds;
    //DataTable dt;
    int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0; 


    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = "~/UserEbookMaster.master";
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
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

            if(Request.QueryString["CpUri"] != null)
                ViewState["CallingPage"] = Request.QueryString["CpUri"].ToString(); 
            else
                ViewState["CallingPage"] = ""; 

            LoadCartItems(); 


        }


    }


    protected void LoadCartItems()
    {

        ViewState["ItemsString"] = ""; 
        DataTable CartDataTable = null;

        if (HttpContext.Current.Session["basket"] != null)
        {
            CartDataTable = (DataTable)HttpContext.Current.Session["basket"];
           
        }

        if (CartDataTable != null)
        {
            if (CartDataTable.Rows.Count > 0)
            {
                tmpRowCount = CartDataTable.Rows.Count;
                ViewState["ItemsCount"] = tmpRowCount;

                String vBookIds = string.Empty;
                String vBookIds2Show = string.Empty;
                String VbookImgs = String.Empty; 

                decimal vTotalAmt = 0; 

                foreach(DataRow cRow in CartDataTable.Rows)
                {

                    vBookIds += cRow["id"].ToString() + ",";
                    vBookIds2Show += cRow["id"].ToString() + ";&nbsp;&nbsp;&nbsp;"; 
                    vTotalAmt += Convert.ToDecimal(cRow["price"].ToString()); 


                    String tmpID =  cRow["id"].ToString();
                    String tmpImgUrl = cRow["ImageUrl"].ToString();
                    String tmpCurrency = cRow["currency"].ToString(); 
                    String tmpPrice = cRow["price"].ToString();
                    String tmpTitle = cRow["name"].ToString() + "\n" + tmpCurrency + ' ' + tmpPrice;
                    

                    tmpImgUrl = tmpImgUrl.Substring(1);

                    VbookImgs += "<div style='float: left; margin-left: 6px; padding: 2px;'> " + tmpID + "<br/>" + "<img alt='bkimg' class='cartBookBox CartBookImgCss' src='" + tmpImgUrl + "' title='" + tmpTitle + "'> </div>"; 
                        
                }

                String vCurrency = string.Empty;

                if (Session["UserCurrency"] != null)
                    vCurrency = Session["UserCurrency"].ToString();
                else
                    vCurrency = "";

                lblTotalItems.Text = tmpRowCount.ToString();
                //lblBookID.Text = vBookIds2Show;
                lblBookID.Text = "<div>" +  VbookImgs + "</div>"; 

                //lbluCurrency.Text = tmpCurrency;
                lblAmtCurrency.Text = vCurrency; 
                lbltotalAmount.Text = vTotalAmt.ToString();

                ViewState["ItemsString"] = vBookIds; 


            }
        }

    }



  
    protected void LnkBtnContinueShopping_Click(object sender, EventArgs e)
    {
        String tmpURI =  ViewState["CallingPage"] .ToString();
        Response.Redirect(tmpURI);
    }

    protected void lnkBuyNow_Click(object sender, EventArgs e)
    {


      //Store all the items in a table and before paypal transaction. 

        int vClientId = Convert.ToInt32(Session["ClientID"].ToString());

        long tmpCartID = objBALebook.ShoppingCart_PreInsert(vClientId, ViewState["ItemsString"].ToString(), Convert.ToInt32(lblTotalItems.Text), Convert.ToDecimal(lbltotalAmount.Text)); 

        
        
        Thread.Sleep(3000);

        dvRightContent.Visible = false;
        dv2PayPalSite.Visible = true;


        String vCallingPage = ViewState["CallingPage"].ToString();


        String veStoreID = String.Empty;
        String vCustomText = String.Empty;
        String vBuyerName = txtBuyerName.Text.Trim();
        String vBuyerEmail = txtBuyerEmail.Text.Trim();
        String vBuyerMobile = txtBuyerMobile.Text.Trim(); 


        String vBusiness = String.Empty;
        String vMemberName = string.Empty;
        String vMobileID = String.Empty;
        String vWebsiteName = String.Empty;


        String vTotalItems = lblTotalItems.Text;
        String vTotalAmount = lbltotalAmount.Text;
        String vCurrency = lblAmtCurrency.Text;


        ds = objBALebook.Eb_WEB_GetMerchantInfo(Convert.ToInt32(vClientId));

        DataTable dtMerchant = ds.Tables[0];

        if (dtMerchant.Rows.Count > 0)
        {
            DataRow Urow = dtMerchant.Rows[0];

            vBusiness = Urow["PayPalAccount"].ToString();

            // vBusiness = "hari_Biz@globalsurf.com.my"; 


            vMemberName = Urow["MemberName"].ToString();
            vMobileID = Urow["MobileLoginID"].ToString();
            vWebsiteName = Urow["OwnDomain"].ToString();
            veStoreID = Urow["eStoreID"].ToString();
        }

        vCustomText = vClientId + "#" + tmpCartID + "#" + vTotalItems + "#" + vTotalAmount + "#" + vCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile;


        String vBookName = ViewState["ItemsString"].ToString();

        if (vBusiness == "lohchuenleong@gmail.com")
        {
            vTotalAmount = "5.50"; 
        }
        
        CommonFunctions.ProceedToPalBuyMerchant(vBusiness, vBuyerName, vBuyerMobile, vBuyerEmail, vTotalAmount, vCurrency, vBookName, tmpCartID.ToString(), vCustomText, vWebsiteName, vClientId.ToString(), vCallingPage); 
       

    }
    protected void buttonCancel_Click(object sender, EventArgs e)
    {

        Response.Redirect("eBooksViewCart.aspx");

    }
}




