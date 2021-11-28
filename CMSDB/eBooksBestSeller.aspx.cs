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


public partial class eBooksBestSeller : UserWeb
{

    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 
    DataSet ds;
    DataTable dt;
    int qCatID = 0;
    string vCurrency = string.Empty;
    string ctryVal = string.Empty;
    string appendMessageMY = string.Empty;
    bool ShowSMSpurchase = false; 

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


            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["qCatID"] != null)
                {
                    qCatID = Convert.ToInt32(Request.QueryString["qCatID"].ToString());

                }
            }
            ViewState["qCatID"] = qCatID;

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
            DataSet dstMY = ndbsMY.ebook_getKeywordDetails_CountryWise(Session["ipCtry"].ToString());

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
            //LoadCategories(vUserId);
            LoadEbooks(vUserId);

        }


    }


    private string GetUserIP()
    {
        string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipList))
        {
            return ipList.Split(',')[0];
        }

        return Request.ServerVariables["REMOTE_ADDR"];
    }


    protected void LoadEbooks(int vUserId)
    {



        DataSet ds2;
        //vUserId = 7702;
        ds2 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserId);

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


       // ds = objBALebook.Ebook_Listing_ByUserID(vUserId, " AND isBestSeller = 1"); 
        ds = objBALebook.Ebook_BestSellerListing_ByUserID(vUserId, ""); 
        dt = ds.Tables[0];
        
        string tmpstr = string.Empty;

        if (dt.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dt.Rows[0];

            RepBooks.DataSource = ds;
            RepBooks.DataBind(); 

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
            sbCats.AppendLine("<h2>" + Resources.LangResources.Categories + "</h2>");
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

            HiddenField objhdIsFreeBook = (HiddenField)e.Item.FindControl("hdIsFreeBook");
            int isFreeBook = Convert.ToInt32(objhdIsFreeBook.Value);


            LinkButton objLnkPayPal = (LinkButton)e.Item.FindControl("LnkPayPalBuy2");
            LinkButton objLnkAddtoCart = (LinkButton)e.Item.FindControl("lnkAddtoCart");

            HtmlTable objtablFree = (HtmlTable)e.Item.FindControl("tblFreeEbooksPurchase");
            HtmlTable objtablBook = (HtmlTable)e.Item.FindControl("tblPurchase");


            Label objlblPurFormat = (Label)e.Item.FindControl("lblPurFormat");
            Label objlblBookID = (Label)e.Item.FindControl("lblBookID");

            string tmpPKGtype = ViewState["vEbUserPackageType"].ToString();

            string tmpKeyword = ViewState["vEbUserKeyword"].ToString();
            string tmpBookPrice = ViewState["vEbookPrice"].ToString();

            Literal objLit12_1 = (Literal)e.Item.FindControl("Literal12");

           
            ctryVal = Session["ipCtry"].ToString();


            //ctryVal = MyGeoLocation.GetCountryCodeFromIP();
            if (ctryVal != "MY")
            {
                ShowSMSpurchase = true;  //USA : US
            }

            if (tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice) / 100;
                tmpBookPrice = "RM " + String.Format("{0:n2}", vPrice.ToString());
                
            }

           // if (1 == 1)

            String tmpAllowSmsPurchase = ViewState["vAllowSMSBuy"].ToString().ToUpper();

            if (!ShowSMSpurchase)
                tmpAllowSmsPurchase = "FALSE"; 


            if(tmpKeyword != "")
            {

                if (isFreeBook == 0)
                {

                    if (tmpAllowSmsPurchase == "FALSE")
                    {
                        objDvPurchase.Visible = false;
                    }
                    else
                    {
                        Label objlblPurchaseNote = (Label)e.Item.FindControl("lblPurchaseNote");

                        if (tmpKeyword == "ZZ" && ctryVal == "MY")
                        {

                            String vStoreID = ViewState["vEbStoreID"].ToString();

                            if (vStoreID != "")
                            {
                                objDvPurchase.Visible = true;
                                objlblPurFormat.Text = "ZZ " + vStoreID + "  " + objlblBookID.Text + "  YourEmail  YourName";
                                objLit12_1.Text = "send To 36247";
                                if (objlblPurchaseNote != null)
                                    objlblPurchaseNote.Text = "<b>" + Resources.LangResources.Note + ":- </b> <span class='PriceFont'>" + string.Format("{0:0.00}", tmpBookPrice) + " </span> " + Resources.LangResources.persmsreceived + ". Eg. ZZ " + ViewState["vEbStoreID"] + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo" + " " + appendMessageMY;
                            }
                            else
                            {
                                objDvPurchase.Visible = false;
                            }

                        }
                        else
                        {
                            if (ctryVal == "MY")
                            {
                                objDvPurchase.Visible = true;
                                objlblPurFormat.Text = ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  YourEmail  YourName";
                                objLit12_1.Text = "send To 36247";
                                if (objlblPurchaseNote != null)
                                    objlblPurchaseNote.Text = "<b>" + Resources.LangResources.Note + ":- </b> <span class='PriceFont'>" + string.Format("{0:0.00}", tmpBookPrice) + " </span> " + Resources.LangResources.persmsreceived + ". Eg. " + ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  JohnW@yahoo.com  John Woo" + " " + appendMessageMY;
                            }
                            else
                            {
                                objDvPurchase.Visible = false;
                            }
                           
                        }

                        if (ctryVal != "MY")
                        {
                            objDvPurchase.Visible = true;
                            newDBS ndbs = new newDBS();
                            DataSet dst = ndbs.ebook_getKeywordDetails_CountryWise(ctryVal);
                            String vStoreID1 = ViewState["vEbStoreID"].ToString();
                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                DataRow nrow = dst.Tables[0].Rows[0];
                                if ((nrow["countryName"].ToString() != null) && (nrow["countryName"].ToString() != ""))
                                {
                                    string ctryName = nrow["countryName"].ToString();
                                    string ctryCurrency = nrow["currencyName"].ToString();
                                    string ctryPriceTag = nrow["PriceTag"].ToString();
                                    string ctryShortcode = nrow["shortcode"].ToString();
                                    string ctryNote = nrow["displayNote"].ToString();
                                    string ctryKeyword = nrow["Keyword"].ToString();
                                    string ctrySendTo = nrow["SendTo"].ToString();

                                    Literal objLit10 = (Literal)e.Item.FindControl("Literal10");
                                    Literal objLit11 = (Literal)e.Item.FindControl("Literal11");
                                    Literal objLit12 = (Literal)e.Item.FindControl("Literal12");
                                    Label lblPNote = (Label)e.Item.FindControl("lblPurchaseNote");

                                    objLit10.Text = ctryName + " Mobile Purchase";
                                    objLit12.Text = ctrySendTo;
                                    objlblPurFormat.Text = ctryKeyword + " " + vStoreID1 + "  " + objlblBookID.Text + "  YourEmail  YourName";
                                    lblPNote.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + vStoreID1 + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
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




                        String tmpAllowPayPal = ViewState["vAllowPayPalBuy"].ToString();
                        if (tmpAllowPayPal.ToUpper() == "TRUE")
                        {
                            //LinkButton objLnkPayPal = (LinkButton)e.Item.FindControl("LnkPayPalBuy");
                            //LinkButton objLnkAddtoCart = (LinkButton)e.Item.FindControl("lnkAddtoCart");

                            if (objLnkPayPal != null)
                            {
                                objLnkPayPal.Visible = true;
                                objLnkAddtoCart.Visible = true;
                            }


                        }


                    }
                }
                else
                {
                    objDvPurchase.Attributes.Add("class", "dvBookPurchase_FreeBookCss");
                    Label objlblPurchaseNote2 = (Label)e.Item.FindControl("lblPurchaseNote2");
                    Label objlblPurFormat2 = (Label)e.Item.FindControl("lblPurFormat2");

                    objDvPurchase.Visible = true;
                    objtablFree.Visible = true;
                    objtablBook.Visible = false;

                    String vStoreID = ViewState["vEbStoreID"].ToString();
                    objlblPurFormat2.Text = "FREE " + vStoreID + "  " + objlblBookID.Text + "  YourEmail  YourName";

                    if (objlblPurchaseNote2 != null)
                        objlblPurchaseNote2.Text = "<b>Eg. FREE " + vStoreID + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";


                    Label objlblAfterDiscount = (Label)e.Item.FindControl("lblAfterDiscount");


                    String strPrice = "0.00";
                    decimal vPrice = Convert.ToDecimal(strPrice);
                    tmpBookPrice = String.Format("{0:n2}", vPrice.ToString());

                    //decimal vPrice = Convert.ToDecimal(tmpBookPrice);
                    //tmpBookPrice = tmpBookCurrency + " " + String.Format("{0:n2}", vPrice);


                    objlblAfterDiscount.Text = tmpBookPrice;

                    Image objFreebookImg = (Image)e.Item.FindControl("ImgFreeBook");

                    if (objFreebookImg != null)
                    {
                        objFreebookImg.Visible = true;
                    }





                    if (objLnkPayPal != null)
                    {
                        objLnkPayPal.Visible = false;
                        objLnkAddtoCart.Visible = false;
                    }


                }
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

        Random rand = new Random((int)DateTime.Now.Ticks);
        int vUnique = 0;
        vUnique = rand.Next(1, 500000);

        String vUniqueID = vUnique.ToString();

        //CommonFunctions.ConfirmPayPalBuy(vBookID, vUserID, CallingPageUri);

        //... Buy Now adds the item to the Cart instead of directly sending to BuyNow page. 
        String vCustomString = vBookID + "#" + vBookName + "#" + vBookPrice + "#" + vImageUrl;
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

            Server.Transfer("eBooksBestSeller.aspx");



        }




    }


}




