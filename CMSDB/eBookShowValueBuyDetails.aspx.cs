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


public partial class eBookShowValueBuyDetails : UserWeb
{

    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 
    DataSet ds;
    DataTable dt;
    String qBookID = "0";
    bool ShowSMSpurchase = false;
    string ctryVal = string.Empty;
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


            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["qBookID"] != null)
                {
                    qBookID = Request.QueryString["qBookID"].ToString();

                }
            }
            ViewState["qBookID"] = qBookID;

            ViewState["vEbUserPackageType"] = "";
            ViewState["vEbUserKeyword"] = "";

            if (Session["ipCtry"] == null)
            {
                Session["ipCtry"] = "";
            }
            if (Session["ipCtry"].ToString() == "")
            {
                Session["ipCtry"] = MyGeoLocation.GetCountryCodeFromIP(); ;
            }
            ctryVal = Session["ipCtry"].ToString();

            //ctryVal = MyGeoLocation.GetCountryCodeFromIP();
            if (ctryVal == "MY")
            {
                ShowSMSpurchase = MyGeoLocation.isSMSPurchaseOpenForCountry("MY");  //Malaysia : MY
            }
            if (ctryVal != "MY")
            {
                ShowSMSpurchase = true;  //USA : US
            }

            newDBS ndbsMY = new newDBS();
            DataSet dstMY = ndbsMY.ebook_getKeywordDetails_CountryWise(ctryVal);

            if (dstMY.Tables[0].Rows.Count > 0)
            {
                DataRow nrow = dstMY.Tables[0].Rows[0];

                appendMessageMY = nrow["displayNote"].ToString();
            }
            else
            {
                appendMessageMY = "";
            }

            //ShowSMSpurchase = MyGeoLocation.isSMSPurchaseOpenForCountry("MY");  //Malaysia : MY  

            int vUserId = Convert.ToInt32(Session["ClientID"]);
           // LoadCategories(vUserId);
            LoadEbook(qBookID, vUserId);

        }


    }


    protected void LoadEbook(string qBookID , int vUserID)
    {

        string tmpKeyword = string.Empty;
        //int tmpPKGtype = 0;
        String tmpUserType = string.Empty;

        DataSet ds2;
        //vUserId = 7702;
        ds2 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserID);

        ViewState["vEbUserKeyword"] = "";
        ViewState["vEbUserPackageType"] = "";
        ViewState["vEbUserType"] = "";
        ViewState["vEbookPrice"] = "";
        ViewState["vEbStoreID"] = ""; 

        if (ds2.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds2.Tables[0].Rows[0];

            ViewState["vEbUserKeyword"] = krow["VendorCode"].ToString();
            ViewState["vEbUserPackageType"] = Convert.ToInt32(krow["PackageType"].ToString());
            ViewState["vEbUserType"] = krow["ebUserType"].ToString();
            ViewState["vEbookPrice"] = krow["Price"].ToString();
            ViewState["vEbStoreID"] = krow["eStoreID"].ToString(); 

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


        string tmpstr = string.Empty;

        DataSet ds;
        //ds = objBALebook.Ebook_GetBookDetails(qBookID);

        int vUserId = Convert.ToInt32(Session["ClientID"].ToString());
       // ds = objBALebook.Ebook_ValueBuyListing_ByUserID(vUserId, " AND BK.BOOKID = '" + qBookID + "'"); 
        ds = objBALebook.Ebook_ValueBuyListing_ByBookID(vUserId, qBookID);

        dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dt.Rows[0];

            RepBooks.DataSource = ds;
            RepBooks.DataBind();

      
        //String tBookImageURL = string.Empty;
        //String tBookID = string.Empty;
        //String tBookName = string.Empty;
        //String tBookPrice = String.Empty;
        //String tBookPriceCancel = string.Empty;
        //string tmpBookURL = string.Empty;

        //StringBuilder sb = new StringBuilder();

        //DataRow sRow = dt.Rows[0];

        //tBookID = sRow["BookID"].ToString();
        //tBookName = sRow["BookName"].ToString();
        //tBookPrice = sRow["DiscountedPrice"].ToString();
        //tBookPriceCancel = sRow["Price"].ToString();
        ////tBookImageURL = sRow["ImageFileFullURL"].ToString();

        //String MainBookShowURL = @"eBookShowValueBuyDetails.aspx?qBookID=" + tBookID;


        //String tBookID1 = sRow["BookID1"].ToString();
        //String tBookName1 = sRow["BookName1"].ToString();
        //String tBookImageURL1 = sRow["ImageFileURL1"].ToString();
        //String tmpShowBookURL1 = @"eBookShowDetails.aspx?qBookID=" + tBookID1;


        //String tBookID2 = sRow["BookID2"].ToString();
        //String tBookName2 = sRow["BookName2"].ToString();
        //String tBookImageURL2 = sRow["ImageFileURL2"].ToString();
        //String tmpShowBookURL2 = @"eBookShowDetails.aspx?qBookID=" + tBookID2;


        //String tBookID3 = sRow["BookID3"].ToString();
        //String tBookName3 = sRow["BookName3"].ToString();
        //String tBookImageURL3 = sRow["ImageFileURL3"].ToString();
        //String tmpShowBookURL3 = @"eBookShowDetails.aspx?qBookID=" + tBookID3;


        //String tBookID4 = sRow["BookID4"].ToString();
        //String tBookName4 = sRow["BookName4"].ToString();
        //String tBookImageURL4 = sRow["ImageFileURL4"].ToString();
        //String tmpShowBookURL4 = @"eBookShowDetails.aspx?qBookID=" + tBookID4;


        //String tBookID5 = sRow["BookID5"].ToString();
        //String tBookName5 = sRow["BookName5"].ToString();
        //String tBookImageURL5 = sRow["ImageFileURL5"].ToString();
        //String tmpShowBookURL5 = @"eBookShowDetails.aspx?qBookID=" + tBookID5;

        //int tBookScount = Convert.ToInt16(sRow["BooksCount"].ToString());





        }
        else
        {
        }

       


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


    protected void RepBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            string strPurchaseFormat = string.Empty;

            StringBuilder sp = new StringBuilder();


            HtmlGenericControl objDvPurchase = (HtmlGenericControl)e.Item.FindControl("DivPurchaseFooter");


            Label objlblPurFormat = (Label)e.Item.FindControl("lblPurchaseText");
            Label objlblBookID = (Label)e.Item.FindControl("lblBookID");

            string tmpPKGtype = ViewState["vEbUserPackageType"].ToString();
            string tmpKeyword = ViewState["vEbUserKeyword"].ToString();
            string tmpBookPrice = ViewState["vEbookPrice"].ToString();

            HiddenField objhdnBookAllowSmsBuy = (HiddenField)e.Item.FindControl("hdnBookAllowSmsBuy");
            HiddenField objhdnBookAllowPayPalBuy = (HiddenField)e.Item.FindControl("hdnBookAllowPayPalBuy");

            String BookAllowSmsBuy = objhdnBookAllowSmsBuy.Value;
            String BookAllowPayPalBuy = objhdnBookAllowPayPalBuy.Value;


           


            if (tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice) / 100;
                tmpBookPrice = "RM " + String.Format("{0:n2}", vPrice.ToString());
            }

            String tmpAllowSmsPurchase = ViewState["vAllowSMSBuy"].ToString().ToUpper();
            if (!ShowSMSpurchase)
                tmpAllowSmsPurchase = "FALSE";

            if (BookAllowSmsBuy.ToUpper() == "FALSE")
                tmpAllowSmsPurchase = "FALSE";

            ctryVal = Session["ipCtry"].ToString();            

            if (ctryVal != "MY")
            {
                ShowSMSpurchase = true;  //USA : US
            }

            //if (1 == 1)
            if (tmpKeyword != "")
            {

                if (tmpAllowSmsPurchase == "FALSE")
                {
                    objDvPurchase.Visible = false;
                }
                else
                {

                    if (tmpKeyword == "ZZ" && ctryVal == "MY")
                    {
                         String vStoreID = ViewState["vEbStoreID"].ToString();

                         if (vStoreID != "")
                         {
                             objDvPurchase.Visible = true;
                             objlblPurFormat.Text = "'ZZ " + vStoreID + "  " + objlblBookID.Text + "  YourEmail  YourName '";

                         }
                         else
                         {
                             objDvPurchase.Visible = false;
                         }
                    }
                    else
                    {                        
                        if (ctryVal != "MY")
                        {
                            objDvPurchase.Visible = true;
                            objlblPurFormat.Text = "'" + ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  YourEmail  YourName '";
                        }
                        else
                        {
                            objDvPurchase.Visible = false;
                        }

                        if (ctryVal == "MY")
                        {
                            objDvPurchase.Visible = true;
                            Label lblPurFormat = (Label)e.Item.FindControl("lblPurFormat");
                            Label lblPurchaseText = (Label)e.Item.FindControl("lblPurchaseText");
                            Label lblPurchaseNote = (Label)e.Item.FindControl("lblPurchaseNote");
                            objlblPurFormat.Text = tmpKeyword + "  " + objlblBookID.Text + "  YourEmail  YourName";
                            lblPurchaseText.Text = "send To 36247";                           
                            lblPurchaseNote.Text = "<b>" + Resources.LangResources.Note + ":- </b> <span class='PriceFont'>" + string.Format("{0:0.00}", tmpBookPrice) + " </span> " + Resources.LangResources.persmsreceived + ". Eg. " + tmpKeyword + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo" + " " + appendMessageMY;
                        }
                        else
                        {                           
                            objDvPurchase.Visible = false;
                        }


                    }
                }
                
                if (ctryVal != "MY")
                {
                    newDBS ndbs = new newDBS();
                    DataSet dst = ndbs.ebook_getKeywordDetails_CountryWise(ctryVal);
                    String vStoreID1 = ViewState["vEbStoreID"].ToString();
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        DataRow nrow = dst.Tables[0].Rows[0];
                        if ((nrow["countryName"].ToString() != null) && (nrow["countryName"].ToString() != ""))
                        {
                            objDvPurchase.Visible = true;

                            string ctryName = nrow["countryName"].ToString();
                            string ctryCurrency = nrow["currencyName"].ToString();
                            string ctryPriceTag = nrow["PriceTag"].ToString();
                            string ctryShortcode = nrow["shortcode"].ToString();
                            string ctryNote = nrow["displayNote"].ToString();
                            string ctryKeyword = nrow["Keyword"].ToString();
                            string ctrySendTo = nrow["SendTo"].ToString();

                            Label lblPurFormat = (Label)e.Item.FindControl("lblPurFormat");
                            Label lblPurchaseText = (Label)e.Item.FindControl("lblPurchaseText");
                            Label lblPurchaseNote = (Label)e.Item.FindControl("lblPurchaseNote");

                            lblPurFormat.Text = ctryName + " Mobile Purchase"; ;
                            lblPurchaseText.Text = ctryKeyword + " " + vStoreID1 + "  " + objlblBookID.Text + "  YourEmail  YourName" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ctrySendTo;
                            lblPurchaseNote.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + vStoreID1 + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                        }
                        else
                        {
                            objDvPurchase.Visible = false;
                        }

                    }
                    else
                    {
                        HtmlGenericControl objDvPurchase1 = (HtmlGenericControl)e.Item.FindControl("dvBookPurchaseFormat");
                        objDvPurchase1.Visible = false;
                    }
                }



             //   Label objlblPurchaseNote = (Label)e.Item.FindControl("lblPurchaseNote"); 

                //if(objlblPurchaseNote != null)
                //    objlblPurchaseNote.Text = "<b>NOTE:- </b> RM 5.00 per sms received. Eg. " + ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";

            }

            String tmpAllowPayPal = ViewState["vAllowPayPalBuy"].ToString();
            if (tmpAllowPayPal.ToUpper() == "TRUE")
            {
                LinkButton objLnkPayPal = (LinkButton)e.Item.FindControl("LnkPayPalBuy");
                LinkButton objLnkAddtoCart = (LinkButton)e.Item.FindControl("lnkAddtoCart");

                if (objLnkPayPal != null)
                {
                    objLnkPayPal.Visible = true;
                    objLnkAddtoCart.Visible = true; 
                }
            }


            Image BookImg3 = (Image)e.Item.FindControl("ImgDescBook3"); 
            HtmlTableRow Tr3 = (HtmlTableRow)e.Item.FindControl("trBook3"); 
            if(BookImg3 != null)
            {
                if (BookImg3.ImageUrl == "")
                    Tr3.Visible = false; 
            }


            Image BookImg4 = (Image)e.Item.FindControl("ImgDescBook4");
            HtmlTableRow Tr4 = (HtmlTableRow)e.Item.FindControl("trBook4");
            if (BookImg4 != null)
            {
                if (BookImg4.ImageUrl == "")
                    Tr4.Visible = false;
            }

            Image BookImg5 = (Image)e.Item.FindControl("ImgDescBook5");
            HtmlTableRow Tr5 = (HtmlTableRow)e.Item.FindControl("trBook5");
            if (BookImg5 != null)
            {
                if (BookImg5.ImageUrl == "")
                    Tr5.Visible = false;
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
            vImageUrl = "/Images/ebImages/ValueBuyDummy.png";  
        }


        String vUserID = Session["ClientID"].ToString();
        String vCustomText = "EBOOK" + "#" + vUserID + "#" + vBookID + "#" + vBookPrice;
        String vCustomString = vBookID + "#" + vBookName + "#" + vBookPrice + "#" + vImageUrl;  

        Random rand = new Random((int)DateTime.Now.Ticks);
        int vUnique = 0;
        vUnique = rand.Next(1, 500000);

        String vUniqueID = vUnique.ToString();
        //... Buy Now adds the item to the Cart instead of directly sending to BuyNow page. 
        //....CommonFunctions.ConfirmPayPalBuy(vBookID, vUserID, CallingPageUri);

        CommonFunctions.AddItemtoCart(vCustomString, Request.Url.AbsoluteUri); 


       // CommonFunctions.ProceedToPalBuy("", vBookPrice, "USD", "", vBookName, vBookID, vCustomText, vUniqueID, "worldDigitalBiz.com", vUserID, CallingPageUri);

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
            vImageURL = "/Images/ebImages/ValueBuyDummy.png"; 

            objItems.BookID = vBookID;
            objItems.BookName = vBookName;
            objItems.Price = Convert.ToDecimal(vBookPrice);
            objItems.ImageURL = vImageURL;


            ShoppingCart.AddCartItem(objItems);
            System.Threading.Thread.Sleep(1000);
            // UpdatePanel1.Update(); 

            Server.Transfer("eBookShowValueBuyDetails.aspx");



        }




    }

}




