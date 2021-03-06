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


public partial class eBooksBuyPP : UserWeb
{

    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    //DataTable dt;
    int qCatID = 0;
    string vCurrency = string.Empty;

    String vBookID = String.Empty;
    int vClientID = 0;
    String vCallingPage = String.Empty;



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

            ViewState["BookId"] = "";
            ViewState["ClientID"] = "";
            ViewState["CallingPageURi"] = ""; 


            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["qCatID"] != null)
                {
                    qCatID = Convert.ToInt32(Request.QueryString["qCatID"].ToString());

                }
                
                vBookID = Request.QueryString["qBookID"];
                String tmpclientID =Request.QueryString["qUserID"].ToString();

                vClientID = Convert.ToInt32(tmpclientID); 
                vCallingPage = Server.UrlDecode(Request.QueryString["qCallingPage"]);
                LoadBookDetails(vBookID, vClientID); 

            }


            if(Request.Form.Count > 0)
            {
                //get the posted values for the Book Buy 

                vBookID = Request.Form["qBookID"];
                vClientID = Convert.ToInt32(Request.Form["qUserID"]);
                vCallingPage = Request.Form["qCallingPage"];


                ViewState["BookId"] = vBookID;
                ViewState["ClientID"] = vClientID; 
                ViewState["CallingPageURi"] = vCallingPage; 

                LoadBookDetails(vBookID, vClientID); 



            }


            ViewState["qCatID"] = qCatID; 


            int vUserId = Convert.ToInt32(Session["ClientID"]);
            LoadCategories(vUserId);
            

        }


    }


    protected void LoadBookDetails(String vBookID, int vUserID)
    {
        ds = objBALebook.Eb_WEB_BuyBook(vBookID, vUserID);
        DataTable dtBook = ds.Tables[0];



        if (dtBook.Rows.Count > 0)
        {
            DataRow krow = dtBook.Rows[0];


            lblBookID.Text = krow["BookID"].ToString();
            lblBookName.Text = krow["BookName"].ToString();
            lblCategory.Text = krow["CategoryName"].ToString();

            String tmpBookPrice = krow["NetPrice"].ToString();
            String tmpBookCurrency = krow["UserCurrency"].ToString();

            ImgEbook.ImageUrl = krow["ImageFileFullURL"].ToString();


            if (tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice);
                tmpBookPrice = tmpBookCurrency + " " + String.Format("{0:n2}", vPrice);

            }

            //
            //String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString()));
            lblNetPrice.Text = tmpBookPrice;
            lbluCurrency.Text = tmpBookCurrency; 
            
            
            
        }



    }
   
    protected void LoadCategories(int vUserId)
    {


        ds = objBALebook.Category_Listing_ByUserID(vUserId, "");
        DataTable dtUserCats = ds.Tables[0];
        DataTable dtAdminCats = ds.Tables[1];


        string tmpstr = string.Empty;

        StringBuilder sbCats = new StringBuilder();




        string tmpCatItem = string.Empty;
        int tmpCatID = 0;

        if (dtUserCats.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dtUserCats.Rows[0];

            sbCats.AppendLine("<h2>My Categories</h2>");
            sbCats.AppendLine("<div class='menu_simple'>");
            sbCats.AppendLine("<br/>");
            sbCats.AppendLine("<ul>");


            foreach (DataRow cRow in dtUserCats.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                // qCatID = Convert.ToInt32(ViewState["qCatID"].ToString()); 

                if (tmpCatID == qCatID)
                {
                    tmpCatItem = "<li><a class='current' href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                else
                {
                    tmpCatItem = "<li><a href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                sbCats.AppendLine(tmpCatItem);
            }

            sbCats.AppendLine("</ul>");
            sbCats.AppendLine("</div>");


        }
        else
        {


        }


        if (dtAdminCats.Rows.Count > 0)
        {

            sbCats.AppendLine("<div class='menu_simple'>");
            // sbCats.AppendLine("<span class='eb_head2'>Categories</span>");
            sbCats.AppendLine("<h2>Categories</h2>");
            sbCats.AppendLine("<br/>");
            sbCats.AppendLine("<ul>");

            DataRow tRows = (DataRow)dtAdminCats.Rows[0];

            foreach (DataRow cRow in dtAdminCats.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                // qCatID = Convert.ToInt32(ViewState["qCatID"].ToString()); 

                if (tmpCatID == qCatID)
                {
                    tmpCatItem = "<li><a class='current' href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                else
                {
                    tmpCatItem = "<li><a href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                sbCats.AppendLine(tmpCatItem);
            }

            sbCats.AppendLine("</ul>");
            sbCats.AppendLine("</div>");

        }






        dvLeftContent.InnerHtml = sbCats.ToString();


    }


 

    protected void RepBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            string strPurchaseFormat = string.Empty;

            StringBuilder sp = new StringBuilder();


            HtmlGenericControl objDvPurchase = (HtmlGenericControl)e.Item.FindControl("dvBookPurchaseFormat");


            Label objlblPurFormat = (Label)e.Item.FindControl("lblPurFormat");
            Label objlblBookID = (Label)e.Item.FindControl("lblBookID");

            string tmpPKGtype = ViewState["vEbUserPackageType"].ToString();

            string tmpKeyword = ViewState["vEbUserKeyword"].ToString();
            string tmpBookPrice = ViewState["vEbookPrice"].ToString();

            if (tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice) / 100;
                tmpBookPrice = "RM " + String.Format("{0:n2}", vPrice.ToString());
                
            }

           // if (1 == 1)
            if(tmpKeyword != "")
            {

                objDvPurchase.Visible = true;
                objlblPurFormat.Text = ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  YourEmail  YourName";

                Label objlblPurchaseNote = (Label)e.Item.FindControl("lblPurchaseNote"); 

                if (objlblPurchaseNote != null)
                    objlblPurchaseNote.Text = "<b>NOTE:- </b> <span class='PriceFont'>" + string.Format("{0:0.00}", tmpBookPrice) + " </span> per sms received. Eg. " + ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";

            }




        }


    }



    protected void LnkPayPalBuy_Command(object sender, CommandEventArgs e)
    {

        String vBookDetails = e.CommandArgument.ToString().Trim();

        string[] BookInfo = vBookDetails.Split('#');

        String vBookID = string.Empty;
        String vBookName = string.Empty;
        String vBookPrice = string.Empty;
        String CallingPageUri = Request.Url.AbsoluteUri;



        foreach (string part in BookInfo)
        {

            vBookID = BookInfo[0].ToString();
            vBookName = BookInfo[1].ToString();
            vBookPrice = BookInfo[2].ToString();
        }


        String vUserID = Session["ClientID"].ToString();
        String vCustomText = "EBOOK" + "#" + vUserID + "#" + vBookID + "#" + vBookPrice;

        Random rand = new Random((int)DateTime.Now.Ticks);
        int vUnique = 0;
        vUnique = rand.Next(1, 500000);

        String vUniqueID = vUnique.ToString();

        CommonFunctions.ProceedToPalBuy("", vBookPrice, "USD", "", vBookName, vBookID, vCustomText, vUniqueID, "worldDigitalBiz.com", vUserID, CallingPageUri);

        //CommonFunctions.ProceedToPalBuy(); 
        // ( cpFullName,  cpAmount,  cpCurrencyCode,  cpMobileNo,  cpItemName,  cpItemNumber,  cpCustomText,  cpUniqueID,  cpWebSiteName,  cpUserID)



    }


    protected void buttonBuy_Click(object sender, EventArgs e)
    {


        
      
        
        String vBookName = string.Empty;
        String vWebsiteName = String.Empty;
        String vCustomText = String.Empty;
        String vBookPrice = string.Empty;
        String vBookCurrency = String.Empty;

        String vBusiness = String.Empty;
        String vMemberName = string.Empty;
        String vMobileID = String.Empty;

        String vUserID = String.Empty;
        String veStoreID = String.Empty;

        String vBuyerName = txtBuyerName.Text.Trim();
        String vBuyerEmail = txtBuyerEmail.Text.Trim();
        String vBuyerMobile = txtBuyerMobile.Text.Trim(); 

        
       vBookID =  ViewState["BookId"].ToString();
       vUserID = ViewState["ClientID"].ToString();
       vCallingPage = ViewState["CallingPageURi"].ToString();



       ds = objBALebook.Eb_WEB_BuyBookMerchantInfo(vBookID, Convert.ToInt32(vUserID));
        DataTable dtBook = ds.Tables[0];
        DataTable dtUser = ds.Tables[1];

        if (dtBook.Rows.Count > 0)
        {
            DataRow Brow = dtBook.Rows[0];
            vBookName = Brow["BookName"].ToString();
            //vBookPrice = Brow["NetPrice"].ToString();
            vBookPrice = String.Format("{0:n2}", Convert.ToDecimal(Brow["NetPrice"].ToString()));
            vBookCurrency = Brow["UserCurrency"].ToString();
            
        }

       
        if (dtUser.Rows.Count > 0)
        {
            DataRow Urow = dtUser.Rows[0];
            
            vBusiness = Urow["AdminID"].ToString();

           // vBusiness = "hari_Biz@globalsurf.com.my"; 


            vMemberName = Urow["MemberName"].ToString(); 
            vMobileID = Urow["MobileLoginID"].ToString(); 
            vWebsiteName = Urow["OwnDomain"].ToString();
            veStoreID = Urow["eStoreID"].ToString(); 
        }

        vCustomText = vUserID + "#" + vBookID + "#" + vBookPrice + "#" + vBookCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile;



       // AddLockScreenScript(); 

        Thread.Sleep(3000);
        
        dvRightContent.Visible = false;
        dvLeftContent.Visible = false;
        dv2PayPalSite.Visible = true;
        
      
        CommonFunctions.ProceedToPalBuyMerchant(vBusiness, vBuyerName, vBuyerMobile, vBuyerEmail, vBookPrice, vBookCurrency, vBookName, vBookID, vCustomText, vWebsiteName, vUserID, vCallingPage); 

       // CommonFunctions.ProceedToPalBuy("", vBookPrice, "USD", "", vBookName, vBookID, vCustomText, vUniqueID, "worldDigitalBiz.com", vUserID, CallingPageUri);

    }
    protected void buttonCancel_Click(object sender, EventArgs e)
    {

        String PgURL = ViewState["CallingPageURi"].ToString();

        Response.Redirect(PgURL); 
    }

    protected void AddLockScreenScript()
    {
        //Add the JavaScript and <div> elements for freezing the screen
        if (!ClientScript.IsClientScriptIncludeRegistered("skm_LockScreen"))
        {
            //Register the JavaScript Include
            ClientScript.RegisterClientScriptInclude("skm_LockScreen", Page.ResolveUrl("~/Scripts/LockScreen.js?version=1.0"));

            //Add the <div> elements
            ClientScript.RegisterClientScriptBlock(this.GetType(), "skm_LockScreen_divs", "<div id=\"skm_LockBackground\" class=\"LockOff\"></div><div id=\"skm_LockPane\" class=\"LockOff\"><div id=\"skm_LockPaneText\">&nbsp;</div></div>", false);
        }
    }

}




