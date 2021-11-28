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
using System.Configuration;

public partial class O_dtValuebuy : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    DataTable dt;
    int qCatID = 0;
    bool ShowSMSpurchase = false;
    string ctryVal = string.Empty;
    string appendMessageMY = string.Empty;
    string flagMalaysiaStatus = string.Empty;
    string flagSingaporeStatus = string.Empty;
    string flagIndonesiaStatus = string.Empty;
    string flagThilandStatus = string.Empty;
    string flagPhilippinesStatus = string.Empty;
    string flagVietnamStatus = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"].ToString() == null) || (Session["ClientID"].ToString() == ""))
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
            //ShowSMSpurchase = true;
            if (Session["ipCtry"] == null)
            {
                Session["ipCtry"] = "";
            }
            if (Session["ipCtry"].ToString() == "")
            {
                Session["ipCtry"] = MyGeoLocation.GetCountryCodeFromIP(); ;
            }
            if (Session["ipCtry"].ToString() == "MY")
            {
                ShowSMSpurchase = true;
            }
            else
            {
                ShowSMSpurchase = false;
            }
            ctryVal = Session["ipCtry"].ToString();
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
            LoadEbooks(vUserId);
        }
    }

    protected void LoadEbooks(int vUserId)
    {
        HtmlMeta metaTitle = Master.FindControl("metaTitle") as HtmlMeta;
        HtmlMeta metaDescription = Master.FindControl("metaDescription") as HtmlMeta;

        DataSet ds2;
        ds2 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserId);

        ViewState["vEbUserKeyword"] = "";
        ViewState["vEbUserPackageType"] = "";
        ViewState["vEbUserType"] = "";
        ViewState["vEbStoreID"] = "";
        ViewState["Price"] = "";

        if (ds2.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds2.Tables[0].Rows[0];

            ViewState["vEbUserKeyword"] = krow["VendorCode"].ToString();
            ViewState["vEbUserPackageType"] = Convert.ToInt32(krow["PackageType"].ToString());
            ViewState["vEbUserType"] = krow["ebUserType"].ToString();
            ViewState["vEbStoreID"] = krow["eStoreID"].ToString();
            ViewState["Price"] = krow["Price"].ToString();
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

        ds = objBALebook.Ebook_ValueBuyListing_ByUserID(vUserId, "");
        dt = ds.Tables[0];
        string tmpstr = string.Empty;

        if (dt.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dt.Rows[0];
            RepBooks.DataSource = ds;
            RepBooks.DataBind();
        }
    }

    protected void RepBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            string strPurchaseFormat = string.Empty;
            StringBuilder sp = new StringBuilder();
            HtmlGenericControl objDvPurchase = (HtmlGenericControl)e.Item.FindControl("DivPurchaseFooter");
            Literal objlblPurFormat = (Literal)e.Item.FindControl("lblPurchaseText");
            Label objlblBookID = (Label)e.Item.FindControl("lblBookID");
            string tmpPKGtype = ViewState["vEbUserPackageType"].ToString();
            string tmpKeyword = ViewState["vEbUserKeyword"].ToString();
            String tmpAllowSmsPurchase = ViewState["vAllowSMSBuy"].ToString().ToUpper();
            if (!ShowSMSpurchase)
                tmpAllowSmsPurchase = "FALSE";
            //..Checking for individual Book Limitations. 
            HiddenField objhdnBookAllowSmsBuy = (HiddenField)e.Item.FindControl("hdnBookAllowSmsBuy");
            HiddenField objhdnBookAllowPayPalBuy = (HiddenField)e.Item.FindControl("hdnBookAllowPayPalBuy");

            String BookAllowSmsBuy = objhdnBookAllowSmsBuy.Value;
            String BookAllowPayPalBuy = objhdnBookAllowPayPalBuy.Value;

            HyperLink hfFaceBook = (HyperLink)e.Item.FindControl("hfFaceBook");
            HyperLink hfTwitter = (HyperLink)e.Item.FindControl("hfTwitter");
            HyperLink hfGooglePlus = (HyperLink)e.Item.FindControl("hfGooglePlus");
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
            url = url.Replace("O_dtValueBuy.aspx", "O_dtValueBuyShowDetails.aspx?qBookID=" + objlblBookID.Text.ToString());
            hfFaceBook.NavigateUrl = "https://facebook.com/sharer.php?u=" + url;
            hfTwitter.NavigateUrl = "https://twitter.com/intent/tweet?url=" + url;
            hfGooglePlus.NavigateUrl = "https://plus.google.com/share?url=" + url;
            hfLinkedIn.NavigateUrl = "http://www.linkedin.com/shareArticle?mini=true&url=" + url;
            hfPinterest.NavigateUrl = "http://pinterest.com/pin/create/button/?url=" + url;
            //hfInstagram.HRef = "https://pinterest.com/pin/create/bookmarklet/?url" + url;

            if (BookAllowSmsBuy.ToUpper() == "FALSE")
                tmpAllowSmsPurchase = "FALSE";

            string tmpBookPrice = ViewState["Price"].ToString();

            if (tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice) / 100;
                tmpBookPrice = "RM " + String.Format("{0:n2}", vPrice.ToString());
            }

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
                            objlblPurFormat.Text = "'CENT5&nbsp; ZZ &nbsp;" + vStoreID + " &nbsp;" + objlblBookID.Text + " &nbsp;YourEmail &nbsp;YourName '";
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
                            objlblPurFormat.Text = "'" + ViewState["vEbUserKeyword"] + " &nbsp;" + objlblBookID.Text + " &nbsp;YourEmail &nbsp;YourName '";
                        }
                        else
                        {
                            objDvPurchase.Visible = false;
                        }
                        if (ctryVal == "MY")
                        {
                            objDvPurchase.Visible = true;                            
                            Literal lblPurchaseText = (Literal)e.Item.FindControl("lblPurchaseText");
                            Literal lblPurchaseNote = (Literal)e.Item.FindControl("lblPurchaseNote");
                            Literal lblLiteral12 = (Literal)e.Item.FindControl("Literal12");
                            lblPurchaseText.Text = tmpKeyword + " &nbsp;" + objlblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                            lblLiteral12.Text = "sendTo &nbsp;36247";
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
                        if (nrow["checker"].ToString().Trim() != "")
                        {
                            objDvPurchase.Visible = true;

                            string ctryName = nrow["countryName"].ToString();
                            string ctryCurrency = nrow["currencyName"].ToString();
                            string ctryPriceTag = nrow["PriceTag"].ToString();
                            string ctryShortcode = nrow["shortcode"].ToString();
                            string ctryNote = nrow["displayNote"].ToString();
                            string ctryKeyword = nrow["Keyword"].ToString();
                            string ctrySendTo = nrow["SendTo"].ToString();

                            Literal lblPurFormat = (Literal)e.Item.FindControl("lblPurFormat");
                            Literal lblPurchaseText = (Literal)e.Item.FindControl("lblPurchaseText");
                            Literal lblPurchaseNote = (Literal)e.Item.FindControl("lblPurchaseNote");
                            Literal lblLiteral12 = (Literal)e.Item.FindControl("Literal12");

                            lblPurFormat.Text = ctryName + " Mobile Purchase";
                            lblLiteral12.Text = "sendTo &nbsp;" + ctryShortcode;
                            lblPurchaseText.Text = ctryKeyword + " &nbsp;" + vStoreID1 + " &nbsp;" + objlblBookID.Text + " &nbsp;YourEmail &nbsp;YourName" + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ctrySendTo;
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
            }
            Image objImg3 = (Image)e.Item.FindControl("ImgEbook3");

            if (objImg3 != null)
            {
                if (objImg3.ImageUrl == "")
                {
                    HtmlGenericControl objDV = (HtmlGenericControl)e.Item.FindControl("divVB3");
                    if (objDV != null)
                        objDV.Visible = false;
                }

            }
            Image objImg4 = (Image)e.Item.FindControl("ImgEbook4");

            if (objImg4 != null)
            {
                if (objImg4.ImageUrl == "")
                {
                    HtmlGenericControl objDV = (HtmlGenericControl)e.Item.FindControl("divVB4");
                    if (objDV != null)
                        objDV.Visible = false;
                }

            }
            Image objImg5 = (Image)e.Item.FindControl("ImgEbook5");

            if (objImg5 != null)
            {
                if (objImg5.ImageUrl == "")
                {
                    HtmlGenericControl objDV = (HtmlGenericControl)e.Item.FindControl("divVB5");
                    if (objDV != null)
                        objDV.Visible = false;
                }

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

        Random rand = new Random((int)DateTime.Now.Ticks);
        int vUnique = 0;
        vUnique = rand.Next(1, 500000);
        String vUniqueID = vUnique.ToString();
 
        String vCustomString = vBookID + "#" + vBookName + "#" + vBookPrice + "#" + vImageUrl;
        CommonFunctions.AddItemtoCartNew(vCustomString, Request.Url.AbsoluteUri);
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
            vImageUrl = "/Images/ebImages/ValueBuyDummy.png";

            objItems.BookID = vBookID;
            objItems.BookName = vBookName;
            objItems.Price = Convert.ToDecimal(vBookPrice);
            objItems.ImageURL = vImageUrl;

            ShoppingCart.AddCartItem(objItems);
            System.Threading.Thread.Sleep(500);

            Server.Transfer("O_dtValueBuy.aspx");
        }
    }

    protected void RepBooks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

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

    protected void flgMalaysia_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "MY";
        Response.Redirect("O_dtValueBuyShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
    protected void flgSingapore_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "SG";
        Response.Redirect("O_dtValueBuyShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
    protected void flgIndonesia_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "ID";
        Response.Redirect("O_dtValueBuyShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
    protected void flgThailand_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "TH";
        Response.Redirect("O_dtValueBuyShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
    protected void flgVietnam_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "VN";
        Response.Redirect("O_dtValueBuyShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }
    protected void flgPhilippines_Click(object sender, CommandEventArgs e)
    {
        Session["ipCtry"] = "PH";
        Response.Redirect("O_dtValueBuyShowDetails.aspx?qBookID=" + e.CommandArgument.ToString());
    }

    
}