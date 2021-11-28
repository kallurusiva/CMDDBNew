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
using System.Collections;
using System.Xml;
using System.IO;
using System.Net;
using System.Configuration;

public partial class O_dtFree : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    DataTable dt;
    bool ShowSMSpurchase = false;
    int qCatID = 0;
    String vCatSearch = string.Empty;
    string ctryVal = string.Empty;

    //int vEbUserPackageType = 0;
    string vEbUserKeyword = string.Empty;
    String vEbUserType = string.Empty;
    string flagMalaysiaStatus = string.Empty;
    string flagSingaporeStatus = string.Empty;
    string flagIndonesiaStatus = string.Empty;
    string flagThilandStatus = string.Empty;
    string flagPhilippinesStatus = string.Empty;
    string flagVietnamStatus = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }  
        if (!IsPostBack)
        {
            int vUserId = Convert.ToInt32(Session["ClientID"]);
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["qCatID"] != null)
                {
                    qCatID = Convert.ToInt32(Request.QueryString["qCatID"].ToString());
                }
            }
            ViewState["qCatID"] = qCatID;

            //Session["ipCtry"] = "MY";
            if (Session["ipCtry"] == null)
            {
                Session["ipCtry"] = "";
            }
            if (Session["ipCtry"].ToString() == "")
            {
                Session["ipCtry"] = MyGeoLocation.GetCountryCodeFromIP(); ;
            }
            string IPValDisp = Session["ipCtry"].ToString();

            if (Session["ipCtry"].ToString() == "MY")
            {
                ShowSMSpurchase = true;
            }
            else
            {
                ShowSMSpurchase = false;
            }
            LoadEbooks(Convert.ToInt32(Session["ClientID"]), Convert.ToInt32(ViewState["qCatID"].ToString()));
        }
    }

    protected void LoadEbooks(int vUserId, int vCatId)
    {
        //.. Get User & Keyword Details

        HtmlMeta metaTitle = Master.FindControl("metaTitle") as HtmlMeta;
        HtmlMeta metaDescription = Master.FindControl("metaDescription") as HtmlMeta;

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

        if (ds2.Tables[3].Rows.Count > 0)
        {
            DataRow srow = ds2.Tables[3].Rows[0];
            flagMalaysiaStatus = srow["MalaysiaFlag"].ToString();
            flagSingaporeStatus = srow["SingaporeFlag"].ToString();
            flagIndonesiaStatus = srow["IndonesiaFlag"].ToString();
            flagThilandStatus = srow["ThailandFlag"].ToString();
            flagPhilippinesStatus = srow["PhilippionesFlag"].ToString();
            flagVietnamStatus = srow["VietnaemFlag"].ToString();
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

        if (vCatId != 0)
            vCatSearch = " AND BK.CATID = " + vCatId;

        ViewState["catSearch"] = vCatSearch;

        ds = objBALebook.Ebook_FreeListing_ByUserID(vUserId, "");
        dt = ds.Tables[0];

        string tmpstr = string.Empty;
        int totalPages = 0;

        if (dt.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dt.Rows[0];

            PagedDataSource ObjPds = new PagedDataSource();
            DataView dv = new DataView(dt);
            ObjPds.DataSource = dv;
            ObjPds.AllowPaging = true;

            ObjPds.PageSize = 20;
            ObjPds.CurrentPageIndex = PageNumber;
            totalPages = ObjPds.PageCount - 1;

            ViewState["CurrentPage"] = ObjPds.CurrentPageIndex;

            if (ObjPds.PageCount > 1)
            {
                rptPages.Visible = true;
                rptPages1.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i < ObjPds.PageCount; i++)
                    pages.Add((i + 1).ToString());
                rptPages.DataSource = pages;
                rptPages.DataBind();
                rptPages1.DataSource = pages;
                rptPages1.DataBind();
            }
            else
            {
                rptPages1.Visible = false;
            }

            RepBooks.DataSource = ObjPds;
            RepBooks.DataBind();
        }

    }

    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
        }
    }

    protected void RepBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            string strPurchaseFormat = string.Empty;
            StringBuilder sp = new StringBuilder();
            Literal objhdIsFreeBook = (Literal)e.Item.FindControl("hdIsFreeBook");
            int isFreeBook = Convert.ToInt32(objhdIsFreeBook.Text.ToString());
            HtmlGenericControl objDvPurchase = (HtmlGenericControl)e.Item.FindControl("dvBookPurchaseFormat");
            Literal objlblPurFormat = (Literal)e.Item.FindControl("lblPurFormat");
            Label objlblBookID = (Label)e.Item.FindControl("lblBookID");
            string tmpPKGtype = ViewState["vEbUserPackageType"].ToString();
            string tmpKeyword = ViewState["vEbUserKeyword"].ToString();
            string tmpBookPrice = ViewState["vEbookPrice"].ToString();
            if (tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice) / 100;
                tmpBookPrice = "RM " + String.Format("{0:n2}", vPrice.ToString()) + "(Excl.GST)";
            }
            //... Getting individual Book Limitations for SMS and PayPal Purchases. 

            Literal objhdAllowSMsBuy = (Literal)e.Item.FindControl("hdAllowSMsBuy");
            Literal objhdAllowPayPalBuy = (Literal)e.Item.FindControl("hdAllowPayPalBuy");
            String BookAllowSmsBuy = objhdAllowSMsBuy.Text.ToString();
            String BookAllowPayPalBuy = objhdAllowPayPalBuy.Text.ToString();
            LinkButton objLnkPayPal = (LinkButton)e.Item.FindControl("LnkPayPalBuy");
            LinkButton objLnkAddtoCart = (LinkButton)e.Item.FindControl("lnkAddtoCart");
            String tmpAllowPayPal = ViewState["vAllowPayPalBuy"].ToString();

            HyperLink hfFaceBook = (HyperLink)e.Item.FindControl("hfFaceBook");
            HyperLink hfTwitter = (HyperLink)e.Item.FindControl("hfTwitter");
            //HyperLink hfGooglePlus = (HyperLink)e.Item.FindControl("hfGooglePlus");
            HyperLink hfLinkedIn = (HyperLink)e.Item.FindControl("hfLinkedIn");
            HyperLink hfPinterest = (HyperLink)e.Item.FindControl("hfPinterest");

            ImageButton flgMalaysia = (ImageButton)e.Item.FindControl("flgMalaysia");
            ImageButton flgSingapore = (ImageButton)e.Item.FindControl("flgSingapore");
            ImageButton flgIndonesia = (ImageButton)e.Item.FindControl("flgIndonesia");
            ImageButton flgThailand = (ImageButton)e.Item.FindControl("flgThailand");
            ImageButton flgVietnam = (ImageButton)e.Item.FindControl("flgVietnam");
            ImageButton flgPhilippines = (ImageButton)e.Item.FindControl("flgPhilippines");

            if (flagMalaysiaStatus.ToString() == "0") { flgMalaysia.Visible = false; }
            if (flagSingaporeStatus.ToString() == "0") { flgSingapore.Visible = false; }
            if (flagIndonesiaStatus.ToString() == "0") { flgIndonesia.Visible = false; }
            if (flagThilandStatus.ToString() == "0") { flgThailand.Visible = false; }
            if (flagPhilippinesStatus.ToString() == "0") { flgVietnam.Visible = false; }
            if (flagVietnamStatus.ToString() == "0") { flgPhilippines.Visible = false; }

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            url = url.Replace("O_dtFree.aspx", "O_dtShowDetails.aspx?qBookID=" + objlblBookID.Text.ToString());
            hfFaceBook.NavigateUrl = "https://facebook.com/sharer.php?u=" + url;
            hfTwitter.NavigateUrl = "https://twitter.com/intent/tweet?url=" + url;
            //hfGooglePlus.NavigateUrl = "https://plus.google.com/share?url=" + url;
            hfLinkedIn.NavigateUrl = "http://www.linkedin.com/shareArticle?mini=true&url=" + Server.UrlEncode(url.ToString());
            hfPinterest.NavigateUrl = "http://pinterest.com/pin/create/button/?url=" + url;
            //hfInstagram.HRef = "https://pinterest.com/pin/create/bookmarklet/?url" + url;

            HtmlMeta metaogtitle = Master.FindControl("metaogtitle") as HtmlMeta;
            HtmlMeta metaogimage = Master.FindControl("metaogimage") as HtmlMeta;

            Image oImgEbook = (Image)e.Item.FindControl("ImgEbook");

            metaogtitle.Content = url.ToString();
            metaogimage.Content = oImgEbook.ImageUrl.ToString();

            hfPinterest.NavigateUrl = "http://pinterest.com/pin/create/button/?url=" + url + "&media=http://14.102.146.116" + oImgEbook.ImageUrl.Replace("~", "").ToString();

            if (BookAllowPayPalBuy.ToUpper() == "FALSE")
                tmpAllowPayPal = "FALSE";
            if (tmpAllowPayPal.ToUpper() == "TRUE")
            {
                if (objLnkPayPal != null)
                {
                    objLnkPayPal.Visible = true;
                    objLnkAddtoCart.Visible = true;
                }
            }

            Literal obhdLaunchStatus = (Literal)e.Item.FindControl("hdLaunchStatus");
            int vLaunchStatus = Convert.ToInt16(obhdLaunchStatus.Text.ToString());
            String tmpAllowSmsPurchase = ViewState["vAllowSMSBuy"].ToString().ToUpper();
            if (BookAllowSmsBuy.ToUpper() == "FALSE")
                tmpAllowSmsPurchase = "FALSE";
            if (!ShowSMSpurchase)  ///to show only for Malaysia. 
                tmpAllowSmsPurchase = "FALSE";

            HtmlGenericControl objtablFree = (HtmlGenericControl)e.Item.FindControl("tblFreeEbooksPurchase");
            HtmlGenericControl objtablBook = (HtmlGenericControl)e.Item.FindControl("tblPurchase");
            HtmlGenericControl objtblComingSoon = (HtmlGenericControl)e.Item.FindControl("tblComingSoon");
            Literal objLit10 = (Literal)e.Item.FindControl("Literal10");
            //ctryVal = "MY";
            ctryVal = MyGeoLocation.GetCountryCodeFromIP();
            if (ctryVal != "MY")
            {
                ShowSMSpurchase = true;  //USA : US
            }
            if (tmpKeyword != "")
            {
                objDvPurchase.Visible = true;
                if (isFreeBook == 0)
                {
                    if (tmpAllowSmsPurchase == "FALSE")
                    {
                        objDvPurchase.Visible = false;
                    }
                    else
                    {
                        Literal objlblPurchaseNote = (Literal)e.Item.FindControl("lblPurchaseNote");
                        objtablFree.Visible = false;
                        objtblComingSoon.Visible = false;
                        Literal objLit12_1 = (Literal)e.Item.FindControl("Literal12");
                        if (tmpKeyword == "ZZ" && ctryVal == "MY")
                        {
                            String vStoreID = ViewState["vEbStoreID"].ToString();
                            if (vStoreID != "")
                            {
                                objtablBook.Visible = true;
                                objLit10.Text = "Malaysia";
                                objlblPurFormat.Text = "CENT5&nbsp; ZZ &nbsp;" + vStoreID + " &nbsp;" + objlblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                                objLit12_1.Text = "sendTo &nbsp; 36247";
                                if (objlblPurchaseNote != null)
                                    objlblPurchaseNote.Text = Resources.LangResources.Note + ":- " + string.Format("{0:0.00}", tmpBookPrice) + Resources.LangResources.persmsreceived + ".<br> Eg. CENT5 ZZ " + ViewState["vEbStoreID"] + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
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
                                objtablBook.Visible = true;
                                objlblPurFormat.Text = ViewState["vEbUserKeyword"] + " &nbsp;" + objlblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                                objLit10.Text = "Malaysia";
                                objLit12_1.Text = "sendTo &nbsp; 36247";
                                if (objlblPurchaseNote != null)
                                    objlblPurchaseNote.Text = Resources.LangResources.Note + ":- " + string.Format("{0:0.00}", tmpBookPrice) + Resources.LangResources.persmsreceived + ".<br> Eg. " + ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                            }
                            else
                            {
                                objDvPurchase.Visible = false;
                            }
                        }
                        if (ctryVal != "MY")
                        {
                            objDvPurchase.Visible = true;
                            objtablBook.Visible = true;
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


                                    Literal objLit11 = (Literal)e.Item.FindControl("Literal11");
                                    Literal objLit12 = (Literal)e.Item.FindControl("Literal12");
                                    Label lblPNote = (Label)e.Item.FindControl("lblPurchaseNote");

                                    objLit10.Text = ctryName;
                                    objLit12.Text = ctrySendTo;
                                    objlblPurFormat.Text = ctryKeyword + " &nbsp;" + vStoreID1 + " &nbsp;" + objlblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                                    lblPNote.Text = Resources.LangResources.Note + ":- " + ctryNote + ".<br> Eg. " + ctryKeyword + " " + vStoreID1 + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
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
                    }
                }
                else
                {
                    Literal objlblPurchaseNote2 = (Literal)e.Item.FindControl("lblPurchaseNote2");
                    Literal objlblPurFormat2 = (Literal)e.Item.FindControl("lblPurFormat2");
                    Literal objLit14_1 = (Literal)e.Item.FindControl("Literal14");
                    Literal Literal13_1 = (Literal)e.Item.FindControl("Literal13");
                    objtablFree.Visible = true;
                    objtablBook.Visible = false;
                    objtblComingSoon.Visible = false;
                    String vStoreID = ViewState["vEbStoreID"].ToString();
                    Literal13_1.Text = "Step3 - Request Free EBook<br>" + "FREE " + vStoreID + " " + objlblBookID.Text + " YourEmail YourName";
                    objlblPurFormat2.Text = "FREE " + vStoreID + " " + objlblBookID.Text + " YourEmail YourName";
                    //objLit14_1.Text = "SendTo &nbsp;&nbsp; 1)+60146367111 &nbsp; 2)+6584200138 &nbsp; 3)+628989111995 &nbsp; 4)+447860041399";
                    objLit14_1.Text = "SendTo<br>1)+447860041399<br>2)+6582400216";
                    if (objlblPurchaseNote2 != null)
                        objlblPurchaseNote2.Text = "Eg. FREE " + vStoreID + " " + objlblBookID.Text + " JohnWoo@yahoo.com John Woo";
                    Label objlblAfterDiscount = (Label)e.Item.FindControl("lblAfterDiscount");
                    String strPrice = "0.00";
                    decimal vPrice = Convert.ToDecimal(strPrice);
                    tmpBookPrice = String.Format("{0:n2}", vPrice.ToString());
                    objlblAfterDiscount.Text = tmpBookPrice;
                    Image objFreebookImg = (Image)e.Item.FindControl("ImgFreeBook");
                    HtmlGenericControl dvCtryFlags1 = (HtmlGenericControl)e.Item.FindControl("dvCtryFlags");
                    dvCtryFlags1.Visible = false;

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

            if (vLaunchStatus == 2)
            {
                objDvPurchase.Visible = true;
                objtablFree.Visible = false;
                objtablBook.Visible = false;
                objtblComingSoon.Visible = true;
                //Image objFreebookImg = (Image)e.Item.FindControl("ImgFreeBook");
                //if (objFreebookImg != null)
                //{
                //    objFreebookImg.Visible = true;
                //    objFreebookImg.ImageUrl = "~/Images/ebImages/ComingSoonSmall1.jpg";
                //}
                if (objLnkPayPal != null)
                {
                    objLnkPayPal.Visible = false;
                    objLnkAddtoCart.Visible = false;
                }
            }

        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptPages.ItemCommand +=
           new RepeaterCommandEventHandler(rptPages_ItemCommand);
    }

    protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        LoadEbooks(Convert.ToInt32(Session["ClientID"]), Convert.ToInt32(ViewState["qCatID"].ToString()));
    }

    protected void rptPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            int vCurrentPage = Convert.ToInt32(ViewState["CurrentPage"].ToString());
            vCurrentPage = vCurrentPage + 1;
            if (vCurrentPage <= 0)
                vCurrentPage = 1;
            //LinkButton objItem = (LinkButton)e.Item.FindControl("btnPage");
            //if (objItem != null)
            //{
            //    if (objItem.Text == vCurrentPage.ToString())
            //        objItem.CssClass = "Pag_Item_current";
            //}
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
        // CommonFunctions.ProceedToPalBuy("", vBookPrice, "USD", "", vBookName, vBookID, vCustomText, vUniqueID, "worldDigitalBiz.com", vUserID, CallingPageUri);
        //CommonFunctions.ProceedToPalBuy(); 
        // ( cpFullName,  cpAmount,  cpCurrencyCode,  cpMobileNo,  cpItemName,  cpItemNumber,  cpCustomText,  cpUniqueID,  cpWebSiteName,  cpUserID)
    }

    protected void LnkPayPalBuy_Click(object sender, CommandEventArgs e)
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
    }

    protected void lnkAddtoCart_Command(object sender, CommandEventArgs e)
    {
        String vBookDetails = e.CommandArgument.ToString().Trim();
        string[] BookInfo = vBookDetails.Split('#');
        String vBookID = string.Empty;
        String vBookName = string.Empty;
        String vBookPrice = string.Empty;
        String vImageUrl = string.Empty;
        String CallingPageUri = Request.Url.AbsoluteUri;
        CMSv3.Entities.CartItems objItems = new CMSv3.Entities.CartItems();
        foreach (string part in BookInfo)
        {
            vBookID = BookInfo[0].ToString();
            vBookName = BookInfo[1].ToString();
            vBookPrice = BookInfo[2].ToString();
            vImageUrl = BookInfo[3].ToString();

            objItems.BookID = vBookID;
            objItems.BookName = vBookName;
            objItems.Price = Convert.ToDecimal(vBookPrice);
            objItems.ImageURL = vImageUrl;

            ShoppingCart.AddCartItem(objItems);
            System.Threading.Thread.Sleep(500);
            // UpdatePanel1.Update(); 
            Server.Transfer("O_dtList.aspx");
        }
    }

    public int GetUserIdfromURL()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;
        //string OurWebSiteName = "1argentinasms";
        string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();
        string tmpMainURL = Request.Url.OriginalString;
        string OrgURL = Request.Url.OriginalString;
        //tmpMainURL = "www.testhari88.com";
        //tmpMainURL = "eb60123238595.1smsbusiness.com";
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
                //StringBuilder sburl = new StringBuilder();
                //sburl.Append("<script>");
                //sburl.Append("window.open('page.html','_blank')");
                //sburl.Append("</script>");
                //Response.Write(sburl.ToString());
                //Response.End();
                //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", WebRegURL));
            }
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

    protected void RepBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void flgMalaysia_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "MY";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
    protected void flgSingapore_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "SG";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
    protected void flgIndonesia_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "ID";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
    protected void flgThailand_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "TH";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
    protected void flgVietnam_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "VN";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
    protected void flgPhilippines_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "PH";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
}