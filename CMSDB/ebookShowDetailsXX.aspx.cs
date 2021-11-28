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
using System.Net;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

public partial class ebookShowDetailsXX : UserWeb
{


    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    DataTable dt;
    String qBookID = "0";
    string ctryVal = string.Empty;
    bool ShowSMSpurchase = false;
    string appendMessageMY = string.Empty;

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = "~/UserEbookMaster.master";
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["ClientID"].ToString() == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL();
            getMasterCss();
            this.Page.MasterPageFile = "~/UserEbookMaster.master";
            HtmlGenericControl myDivObject;
            myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");
        }
        #endregion
       
        //#region  // SessionCheck
        //if ((Session["ClientID"].ToString() == null) || (Session["ClientID"].ToString() == ""))
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        //#endregion        

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

            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["qBookID"] != null)
                {
                    qBookID = Request.QueryString["qBookID"].ToString();

                }
                if (Request.QueryString["cid"] != null)
                {
                    ctryVal = Request.QueryString["cid"].ToString();
                }
            }
            ViewState["qBookID"] = qBookID;

            if (Session["ipCtry"] == null)
            {
                Session["ipCtry"] = "";
            }
            if (Session["ipCtry"].ToString() == "")
            {
                Session["ipCtry"] = MyGeoLocation.GetCountryCodeFromIP(); ;
            }
            ctryVal = Session["ipCtry"].ToString();
           
            if (ctryVal == null)
            {
                ctryVal = "";
            }
            //if (ctryVal == "")
            //{
            //    ctryVal = "MY";
            //}
            //ctryVal = MyGeoLocation.GetCountryCodeFromIP();
            if (ctryVal == "MY")
            {
                ShowSMSpurchase = MyGeoLocation.isSMSPurchaseOpenForCountry("MY");  //Malaysia : MY
            }
            if (ctryVal != "MY")
            {
                ShowSMSpurchase = true;  //USA : US
            }

            int vUserId = Convert.ToInt32(Session["ClientID"]);
            //hyperlink1.NavigateUrl = "ebookshowDetails.aspx?qBookID=" + ViewState["qBookID"].ToString();
            hyperlink1.NavigateUrl = "javascript:window.open('eBookShowcountriesformatnew.aspx?qBookID=" + ViewState["qBookID"].ToString() + "',null,'resizable=no,toolbar=no,scrollbars=no,menubar=no,status=no,width=1100,height=780');";
            // LoadCategories(vUserId);

            //string ipVal = MyGeoLocation.GetUserIP();
            //string ctryVal = MyGeoLocation.GetCountryCodeFromIP();
            //Response.Write(ipVal + "-" + ctryVal + "-" + vUserId);
            LoadEbook(qBookID, vUserId);
           
        }        
    }

    protected void LoadEbook(string qBookID, int vUserID)
    {
        string tmpKeyword = string.Empty;
        int tmpPKGtype = 0;
        String tmpUserType = string.Empty;
        String tmpBookPrice = string.Empty;
        String tmpUserCurrency = string.Empty;
        String tmpEstoreID = string.Empty;

        DataSet ds2;
        //vUserId = 7702;
        ds2 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserID);       

        if (ds2.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds2.Tables[0].Rows[0];

            tmpKeyword = krow["VendorCode"].ToString();
            tmpPKGtype = Convert.ToInt32(krow["PackageType"].ToString());
            tmpUserType = krow["ebUserType"].ToString();
            tmpBookPrice = krow["Price"].ToString();
            tmpUserCurrency = krow["UserCurrency"].ToString();

            tmpEstoreID = krow["eStoreID"].ToString();


            if (tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice) / 100;
                tmpBookPrice = "RM " + String.Format("{0:n2}", vPrice.ToString()) + "(Excl.GST)";

            }
        }        
       
        ViewState["vAllowPayPalBuy"] = "";
        ViewState["vAllowSMSBuy"] = "";
        DataTable dtAllowSettings = ds2.Tables[1];
        if (dtAllowSettings.Rows.Count > 0)
        {
            DataRow Srow = dtAllowSettings.Rows[0];

            ViewState["vAllowPayPalBuy"] = Srow["AllowPayPalBuy"].ToString();
            ViewState["vAllowSMSBuy"] = Srow["AllowSMSBuy"].ToString();
        }


        String tmpAllowSmsPurchase = ViewState["vAllowSMSBuy"].ToString().ToUpper();
        if (!ShowSMSpurchase)
            tmpAllowSmsPurchase = "FALSE";

        string tmpstr = string.Empty;

        DataSet ds;
        ds = objBALebook.Ebook_GetBookDetails(qBookID, vUserID);        

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];

            DataRow dr = dt.Rows[0];

            lblBookID.Text = dr["BookID"].ToString();
            lblBookName.Text = dr["BookNAme"].ToString();
            lblCategory.Text = dr["CategoryName"].ToString();
            // lblDateAdded.Text = String.Format("{0:MMMM d, yyyy}", Convert.ToDecimal(dr["DateCreated"].ToString())); ; // dr["DateCreated"].ToString();

            DateTime dNewDate = Convert.ToDateTime(dr["DateCreated"].ToString());
            String strNewDate = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dNewDate);
            lblDateAdded.Text = strNewDate;

            lbluCurrency1.Text = dr["UserCurrency"].ToString(); ;
            lbluCurrency2.Text = dr["UserCurrency"].ToString(); ;
            lblPrepaidValue.Text = dr["PrepaidPrice"].ToString();


            lblOrgPrice.Text = String.Format("{0:n2}", Convert.ToDecimal(dr["Price"].ToString()));
            lblAfterDiscount.Text = String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString()));


            //String.Format("{0:n2}", Convert.ToDecimal(tBookPriceCancel))
            ImgEbook.ImageUrl = dr["ImageFileFullURL"].ToString();


            String tmpTitle = dr["Title"].ToString();
            String tmpDescription = dr["Description"].ToString();

            int vLaunchStatus = Convert.ToInt16(dr["LaunchStatus"].ToString());
            int isFreeBook = Convert.ToInt16(dr["isFreeBook"].ToString());

            Response.Write(isFreeBook);


            String BookAllowSmsBuy = dr["AllowSMSbuy"].ToString();
            String BookAllowPayPalBuy = dr["AllowPaypalBuy"].ToString();


            if (BookAllowSmsBuy.ToUpper() == "FALSE")
                tmpAllowSmsPurchase = "FALSE";


            tmpDescription = tmpDescription.Replace(Environment.NewLine, "<br/>");
            tmpDescription = "<p class='BkfontDescription'>" + tmpDescription + "</p>";

            if (tmpTitle == "")
                tmpTitle = "";
            else
                tmpTitle = "<p class='BkfontTitle'>" + tmpTitle + "</p>";


            string tmpImagePath = Page.ResolveUrl(ImgEbook.ImageUrl);

            LnkPayPalBuy.CommandArgument = lblBookID.Text + "#" + lblBookName.Text + "#" + lblAfterDiscount.Text + "#" + tmpImagePath;

            lnkAddtoCart.CommandArgument = lblBookID.Text + "#" + lblBookName.Text + "#" + lblAfterDiscount.Text + "#" + tmpImagePath;


            //lblDescription.Text = dr["Description"].ToString(); 

            dvBookDescription.InnerHtml = tmpTitle + tmpDescription;

            lblHeader.Text = lblBookName.Text;

            newDBS ndbsMY = new newDBS();
            DataSet dstMY = ndbsMY.ebook_getKeywordDetails_CountryWise(ctryVal);            

            if (dstMY.Tables[0].Rows.Count > 0)
            {
                DataRow nrow = dstMY.Tables[0].Rows[0];

                appendMessageMY = nrow["displayNote"].ToString();
            }
            else
            {
                appendMessageMY="";
            }

            Response.Write(ctryVal);
           
            //if (1 ==1)
            if ((tmpKeyword != ""))
            {
                dvBookPurchaseFormat.Visible = true;

                if (isFreeBook == 0)
                {
                    String tmpAllowPayPal = ViewState["vAllowPayPalBuy"].ToString();                   

                    if (tmpAllowSmsPurchase == "FALSE")
                    {
                        dvBookPurchaseFormat.Visible = false;
                        if (tmpAllowPayPal.ToUpper() == "TRUE")
                        {
                            LnkPayPalBuy.Visible = true;
                            lnkAddtoCart.Visible = true;
                        }
                    }
                    else
                    {
                        tblFreeEbooksPurchase.Visible = false;
                        tblComingSoon.Visible = false;                        

                        if (tmpKeyword == "ZZ" && ctryVal == "MY")
                        {
                            if (tmpEstoreID != "")
                            {
                                tblPurchase.Visible = true;
                                lblPurFormat.Text = "ZZ " + tmpEstoreID + "  " + lblBookID.Text + "  YourEmail  YourName";
                                Literal12.Text = "send To 36247";
                                lblPurchaseNote.Text = "<b>" + Resources.LangResources.Note + ":- </b> <span class='PriceFont'>" + string.Format("{0:0.00}", tmpBookPrice) + " </span> " + Resources.LangResources.persmsreceived + ". Eg. ZZ " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo" + " "  + appendMessageMY;

                            }
                            else
                            {
                                tblPurchase.Visible = false;
                                dvBookPurchaseFormat.Visible = false;
                            }

                        }
                        else
                        {                            
                            if (ctryVal == "MY")
                            {
                                tblPurchase.Visible = true;
                                lblPurFormat.Text = tmpKeyword + "  " + lblBookID.Text + "  YourEmail  YourName";
                                Literal12.Text = "send To 36247";
                                lblPurchaseNote.Text = "<b>" + Resources.LangResources.Note + ":- </b> <span class='PriceFont'>" + string.Format("{0:0.00}", tmpBookPrice) + " </span> " + Resources.LangResources.persmsreceived + ". Eg. " + tmpKeyword + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo" + " " + appendMessageMY;
                            }
                            else
                            {                                
                                tblPurchase.Visible = false;
                                dvBookPurchaseFormat.Visible = false;
                            }
                        }
                        //for other countries
                        if (ctryVal != "MY")
                        {                            
                            newDBS ndbs = new newDBS();
                            DataSet dst = ndbs.ebook_getKeywordDetails_CountryWise(ctryVal);

                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                DataRow nrow = dst.Tables[0].Rows[0];
                                if (nrow["countryName"].ToString() != null)
                                {
                                    
                                    string ctryName = nrow["countryName"].ToString();
                                    string ctryCurrency = nrow["currencyName"].ToString();
                                    string ctryPriceTag = nrow["PriceTag"].ToString();
                                    string ctryShortcode = nrow["shortcode"].ToString();
                                    string ctryNote = nrow["displayNote"].ToString();
                                    string ctryKeyword = nrow["Keyword"].ToString();
                                    string ctrySendTo = nrow["SendTo"].ToString();

                                    Literal10.Text = ctryName + " Mobile Purchase";
                                    Literal12.Text = ctrySendTo;
                                    lblPurFormat.Text = ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  YourEmail  YourName";
                                    lblPurchaseNote.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                                }
                                else
                                {                                    
                                    dvBookPurchaseFormat.Visible = false;
                                }
                                
                            }
                            else
                            {
                                dvBookPurchaseFormat.Visible = false;
                            }
                        }
                        //end for other countries
                        if (tmpAllowPayPal.ToUpper() == "TRUE")
                        {
                            LnkPayPalBuy.Visible = true;
                            lnkAddtoCart.Visible = true;
                        }
                    }

                }
                else
                        {
                            // if it is a free ebook then..... 
                            dvBookPurchaseFormat.Attributes.Add("class", "dvBookPurchase_FreeBookCss");

                            tblFreeEbooksPurchase.Visible = true;
                            tblComingSoon.Visible = false;
                            tblPurchase.Visible = false;
                            LnkPayPalBuy.Visible = false;
                            lnkAddtoCart.Visible = false;



                            String vStoreID = tmpEstoreID;
                            lblPurFormat2.Text = "FREE " + vStoreID + "  " + lblBookID.Text + "  YourEmail  YourName";

                            if (lblPurchaseNote2 != null)
                                lblPurchaseNote2.Text = "<b>Eg. FREE " + vStoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo";


                            String strPrice = "0.00";
                            decimal vPrice = Convert.ToDecimal(strPrice);
                            tmpBookPrice = String.Format("{0:n2}", vPrice.ToString());

                            //decimal vPrice = Convert.ToDecimal(tmpBookPrice);
                            //tmpBookPrice = tmpBookCurrency + " " + String.Format("{0:n2}", vPrice);

                            lblAfterDiscount.Text = tmpBookPrice;

                            ImgFreeBook.Visible = true;
                        }


            }            

                            if (vLaunchStatus == 2)
                            {

                                dvBookPurchaseFormat.Visible = true;
                                dvBookPurchaseFormat.Attributes.Add("class", "dvBookPurchase_ComingCss");

                                tblFreeEbooksPurchase.Visible = false;
                                tblComingSoon.Visible = true;

                                tblPurchase.Visible = false;
                                LnkPayPalBuy.Visible = false;
                                lnkAddtoCart.Visible = false;

                                ImgFreeBook.Visible = true;
                                ImgFreeBook.ImageUrl = "~/Images/ebImages/ComingSoonSmall1.jpg";
                            }            
        }
        else
        {
           
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

            sbCats.AppendLine("<h2>" + Resources.LangResources.MyCategory + "</h2>");
            sbCats.AppendLine("<div class='menu_simple'>");
            sbCats.AppendLine("<br/>");
            sbCats.AppendLine("<ul>");

            foreach (DataRow cRow in dtUserCats.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                // qCatID = Convert.ToInt32(ViewState["qCatID"].ToString()); 

                tmpCatItem = "<li><a href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";

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
            sbCats.AppendLine("<h2>" + Resources.LangResources.Categories + "</h2>");
            sbCats.AppendLine("<br/>");
            sbCats.AppendLine("<ul>");

            DataRow tRows = (DataRow)dtAdminCats.Rows[0];

            foreach (DataRow cRow in dtAdminCats.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                // qCatID = Convert.ToInt32(ViewState["qCatID"].ToString()); 

                tmpCatItem = "<li><a href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";

                sbCats.AppendLine(tmpCatItem);
            }

            sbCats.AppendLine("</ul>");
            sbCats.AppendLine("</div>");

        }
        dvLeftContent.InnerHtml = sbCats.ToString();

    }


    protected void LoadCategories22(int vUserId)
    {


        ds = objBALebook.Category_Listing_ByUserID(vUserId, "");
        dt = ds.Tables[0];

        string tmpstr = string.Empty;

        StringBuilder sbCats = new StringBuilder();

        sbCats.AppendLine("<h2>Categories</h2>");
        sbCats.AppendLine("<div class='menu_simple'>");
        //sbCats.AppendLine("<span class='eb_head2'>Categories</span>");

        sbCats.AppendLine("<br/>");
        sbCats.AppendLine("<ul>");

        string tmpCatItem = string.Empty;
        int tmpCatID = 0;

        if (dt.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dt.Rows[0];

            //foreach(DataRow cRow in dt.Rows)
            //{

            //    tmpCatItem = "<li><a ref='#'>" + cRow["CatBooks"].ToString() + "</a></li>";
            //    sbCats.AppendLine(tmpCatItem);
            //}

            foreach (DataRow cRow in dt.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                // qBookID = Convert.ToInt32(ViewState["qBookID"].ToString()); 

                //if (tmpCatID == qBookID)
                //{
                //    tmpCatItem = "<li><a class='current' href='eBooksList.aspx?qBookID=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                //}
                //else
                //{
                tmpCatItem = "<li><a href='eBooksList.aspx?qBookID=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                //}
                sbCats.AppendLine(tmpCatItem);
            }


        }


        sbCats.AppendLine("</ul>");
        sbCats.AppendLine("</div>");

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

            //if (tmpPKGtype == "2")
            if (tmpKeyword != "")
            {

                objDvPurchase.Visible = true;
                objlblPurFormat.Text = ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  YourEmail  YourName";

                Label objlblPurchaseNote = (Label)e.Item.FindControl("lblPurchaseNote");

                if (objlblPurchaseNote != null)
                    objlblPurchaseNote.Text = "<b>NOTE:- </b> RM 5.00 per sms received. Eg. " + ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";

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
        String vImageUrl = string.Empty;
        String CallingPageUri = Request.Url.AbsoluteUri;



        foreach (string part in BookInfo)
        {

            vBookID = BookInfo[0].ToString();
            vBookName = BookInfo[1].ToString();
            vBookPrice = BookInfo[2].ToString();
            vImageUrl = BookInfo[3].ToString();
        }


        String vUserID = Session["ClientID"].ToString();
        String vCustomText = "EBOOK" + "#" + vUserID + "#" + vBookID + "#" + vBookPrice;
        String vCustomString = vBookID + "#" + vBookName + "#" + vBookPrice + "#" + vImageUrl;

        Random rand = new Random((int)DateTime.Now.Ticks);
        int vUnique = 0;
        vUnique = rand.Next(1, 500000);

        String vUniqueID = vUnique.ToString();

        //... Buy Now adds the item to the Cart instead of directly sending to BuyNow page. 
        //CommonFunctions.ConfirmPayPalBuy(vBookID, vUserID, CallingPageUri);

        CommonFunctions.AddItemtoCart(vCustomString, Request.Url.AbsoluteUri);



        //CommonFunctions.ProceedToPalBuy("", vBookPrice, "USD", "", vBookName, vBookID, vCustomText, vUniqueID, "worldDigitalBiz.com", vUserID, CallingPageUri);

        //CommonFunctions.ProceedToPalBuy(); 
        // ( cpFullName,  cpAmount,  cpCurrencyCode,  cpMobileNo,  cpItemName,  cpItemNumber,  cpCustomText,  cpUniqueID,  cpWebSiteName,  cpUserID)



    }


    protected void lnkAddtoCart_Command(object sender, CommandEventArgs e)
    {
        String vBookDetails = e.CommandArgument.ToString().Trim();

        string[] BookInfo = vBookDetails.Split('#');

        String vBookID = string.Empty;
        String vBookName = string.Empty;
        String vBookPrice = string.Empty;
        String vImageURL = string.Empty;
        String CallingPageUri = Request.Url.AbsoluteUri;

        CMSv3.Entities.CartItems objItems = new CMSv3.Entities.CartItems();

        foreach (string part in BookInfo)
        {

            vBookID = BookInfo[0].ToString();
            vBookName = BookInfo[1].ToString();
            vBookPrice = BookInfo[2].ToString();
            vImageURL = BookInfo[3].ToString();

            objItems.BookID = vBookID;
            objItems.BookName = vBookName;
            objItems.Price = Convert.ToDecimal(vBookPrice);
            objItems.ImageURL = vImageURL;


            ShoppingCart.AddCartItem(objItems);
            System.Threading.Thread.Sleep(500);
            // UpdatePanel1.Update(); 

            Server.Transfer("eBookShowDetails.aspx");

            //Response.Redirect("eBooksShowDetails.aspx");
        }

    }

 public int GetUserIdfromURL()
    {        
        int newUserID = 0;
        string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();
        //string tmpMainURL = Request.Url.OriginalString;
        string tmpMainURL =  HttpContext.Current.Request.Url.Host; ;        
        string OrgURL = Request.Url.OriginalString;        
        //tmpMainURL = "http://happysamebooks.com";
        tmpMainURL = tmpMainURL.Replace("http://", "");  // removing the http://
        
        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();

        if (tmpMainURL.Contains(OurWebSiteName))
        {
            //subdomain
            string tmpSubDomainURL = tmpMainURL;
            string[] MainURLArr = tmpMainURL.Split('.');
            string userSubDomainName = string.Empty;

            // see if user has typed in www
            if (MainURLArr[0].ToString() == "www")
            {
                userSubDomainName = MainURLArr[1].ToString();
            }
            else
            {
                userSubDomainName = MainURLArr[0].ToString();
            }
            

            if (userSubDomainName == OurWebSiteName)
            {
                //..user comes to direct website setting the userid to demo as default
                newUserID = 105; 
            }
            else
            {
                //..user comes to his sub domain
                newUserID = objBAL_User.GetUserID_BySubDomainName(userSubDomainName);

                //if (newUserID == 0)
                //{

                //check if the User is from/a 1MalaysiaSMS user. 
                CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();

                //..function get all the details of 1malaysia user into MasUser entity 
                MasFunc.Get_1MalaysiaUser_Details(userSubDomainName, ref objMasUser);

                //if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
                Session["MasUSER"] = objMasUser;
                //.................................................................
                if (objMasUser.MID != "NONE")
                {
                    //Response.Redirect("Mas1UserWebRegistration.aspx");                    
                }
                //}
            }

        }
        else
        {           
            //owndomain  or subDomain ??
            //string ownDomain = tmpMainURL;
            string[] OwnURLArr = tmpMainURL.Split('.');
            string userOwnDomainName = string.Empty;
            int DomainType = -1; 
            
            // see if user has typed in www
            if (OwnURLArr[0].ToString() == "www")
            {                
                userOwnDomainName = OwnURLArr[1].ToString();
                if (OwnURLArr.Count() > 4)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain               
            }
            else
            {
                userOwnDomainName = OwnURLArr[0].ToString();
                if (OwnURLArr.Count() > 3)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain
            }

            //..user comes to his sub domain
            newUserID = objBAL_User.GetUserID_BySubDomainName2(userOwnDomainName, DomainType);
            //if (newUserID == 0)
            //{

            //check if the User is from/a 1MalaysiaSMS user. 
            CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
            CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();

            //..function get all the details of 1malaysia user into MasUser entity 
            MasFunc.Get_1MalaysiaUser_Details(userOwnDomainName, ref objMasUser);

               // if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
                Session["MasUSER"] = objMasUser;
            //    //.................................................................

                if (objMasUser.MID != "NONE")
                {
                   // Response.Redirect("Mas1UserWebRegistration.aspx");
                     //String WebRegURL = "Mas1UserWebRegistration.aspx";                  
                }
            //}

        }

        //string tmpDname = "pencil";
        //newUserID = objBAL_User.GetUserID_BySubDomainName(tmpDname);
        if (newUserID == 0)
        {          
            Response.Redirect("PartnerWebRegistrationNew.aspx");
            //Response.Redirect("InValidDomain.aspx");            
        }
        return newUserID;

    }



    public void getMasterCss()
 {
     #region // find out the Users MasterPage settings
     //if (Session["MasterPageFile"] == null)
     string tmpMasterfile = string.Empty;
     string tmpMasterCss = string.Empty;

     //{
     //string strSQL = "Select MasterPageName, Case WHEN MasterCSS is NULL Then 'CommonStyleSheet.css' Else MasterCSS END as MasterCss" + 
     //                "from tblUserMasterPage = " + Convert.ToInt32(Session["ClientID"]);


     string strSQL = "Select UserID, MasterPageName, " +
                 "Case WHEN MasterPageName = 'UserMaster.master' and MasterCSS is NULL Then 'CommonStyleSheet.css' " +
                 "WHEN MasterPageName = 'TmpMaster1.master' and MasterCSS is NULL Then 'TmpStyleSheet2.css' " +
                 "Else MasterCSS END as MasterCss from tblUserMasterPage where UserId = " + Convert.ToInt32(Session["ClientID"]);

     SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
     dbConn.Open();
     SqlCommand dbCmd = new SqlCommand("usp_Retreive_UserMasterPageAndCss", dbConn);
     dbCmd.CommandType = CommandType.StoredProcedure;
     dbCmd.Parameters.Add("@vUserID", SqlDbType.BigInt).Value = Convert.ToInt32(Session["ClientID"]);
     SqlDataReader dbReader;
     dbReader = dbCmd.ExecuteReader();

     if (dbReader.HasRows)
     {
         while (dbReader.Read())
         {
             tmpMasterfile = dbReader["MasterPageName"].ToString();
             tmpMasterCss = dbReader["MasterCSS"].ToString();

             WebClient client = new WebClient();
             Stream data = client.OpenRead("dtGen1.aspx");
             StreamReader reader = new StreamReader(data);
             string s = reader.ReadToEnd();
             data.Close();
             s = reader.ReadToEnd();
             reader.Close();
         }
     }

     dbConn.Close();

     if (!tmpMasterfile.Equals(string.Empty))
     {
         Session["MasterPageFile"] = tmpMasterfile;
         Session["MasterPageCss"] = tmpMasterCss;
     }
     
     #endregion
 }


    }






