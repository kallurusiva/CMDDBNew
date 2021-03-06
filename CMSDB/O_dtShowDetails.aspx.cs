using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using CMSv3.BAL;
using System.Net;
using System.Configuration;

public partial class O_dtShowDetails : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    //DataSet ds;
    //DataTable dt;
    String qBookID = "0";
    string ctryVal = string.Empty;
    bool ShowSMSpurchase = false;
    string appendMessageMY = string.Empty;

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
                if (Request.QueryString["qBookID"] != null)
                {
                    qBookID = Request.QueryString["qBookID"].ToString();
                }
            }
            ViewState["qBookID"] = qBookID;
            //Session["ipCtry"] = "VN";
            if (Session["ipCtry"] == null)
            {
                Session["ipCtry"] = "";
            }
            if (Session["ipCtry"].ToString() == "")
            {
                Session["ipCtry"] = MyGeoLocation.GetCountryCodeFromIP();
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
            
            //ShowSMSpurchase = true;
            if (ctryVal == "MY")
            {
                ShowSMSpurchase = MyGeoLocation.isSMSPurchaseOpenForCountry("MY");  //Malaysia : MY
            }
            if (ctryVal != "MY")
            {
                ShowSMSpurchase = true;  //USA : US
            }
            //hyperlink1.NavigateUrl = "O_dtShowCountryFormat.aspx?qBookID=" + ViewState["qBookID"].ToString();

            //HtmlMeta meta = new HtmlMeta();

            //meta = new HtmlMeta();
            //meta.Attributes.Add("property", "og:title");
            //meta.Attributes.Add("content", "Welcome to ebook");
            //Page.Header.Controls.Add(meta);

            //meta = new HtmlMeta();
            //meta.Attributes.Add("property", "og:description");
            //meta.Attributes.Add("content", "Welcome to ebook");
            //Page.Header.Controls.Add(meta);

            //meta = new HtmlMeta();
            //meta.Attributes.Add("property", "og:url");
            //meta.Attributes.Add("content", "Welcome to ebook");
            //Page.Header.Controls.Add(meta);

            //meta = new HtmlMeta();
            //meta.Attributes.Add("property", "og:site_name");
            //meta.Attributes.Add("content", "http://www.happysamebooks.com");
            //Page.Header.Controls.Add(meta);

            //meta = new HtmlMeta();
            //meta.Attributes.Add("property", "og:url");
            //meta.Attributes.Add("content", "http://www.happysamebooks.com/O_dtShowDetails.aspx?qBookID=" + qBookID.ToString());
            //Page.Header.Controls.Add(meta);

            //meta = new HtmlMeta();
            //meta.Attributes.Add("property", "og:image");
            //meta.Attributes.Add("content", "http://www.happysamebooks.com/DocumentRepository/eBookImages/6507_Execellent-Magazine-47.png");
            //Page.Header.Controls.Add(meta);

            //meta = new HtmlMeta();
            //meta.Attributes.Add("property", "image:width");
            //meta.Attributes.Add("content", "500");
            //Page.Header.Controls.Add(meta);

            //meta = new HtmlMeta();
            //meta.Attributes.Add("property", "image:height");
            //meta.Attributes.Add("content", "500");
            //Page.Header.Controls.Add(meta);



            LoadEbook(qBookID, vUserId);
        }
    }

    protected void LoadEbook(string qBookID, int vUserID)
    {
        string url = HttpContext.Current.Request.Url.AbsoluteUri;

        HtmlMeta metaTitle = Master.FindControl("metaTitle") as HtmlMeta;
        HtmlMeta metaDescription = Master.FindControl("metaDescription") as HtmlMeta;

        HtmlMeta metaogtitle = Master.FindControl("metaogtitle") as HtmlMeta;
        HtmlMeta metaogimage = Master.FindControl("metaogimage") as HtmlMeta;
                
        hfFaceBook.HRef = "https://facebook.com/sharer.php?u=" + url;        
        hfTwitter.HRef = "https://twitter.com/intent/tweet?url=" + url;
        //hfGooglePlus.HRef = "https://plus.google.com/share?url=" + url;
        hfLinkedIn.HRef = "http://www.linkedin.com/shareArticle?mini=true&url=" + Server.UrlEncode(url.ToString());
        
        //hfInstagram.HRef = "https://pinterest.com/pin/create/bookmarklet/?url" + url;

        string tmpKeyword = string.Empty;
        int tmpPKGtype = 0;
        String tmpUserType = string.Empty;
        String tmpBookPrice = string.Empty;
        String tmpUserCurrency = string.Empty;
        String tmpEstoreID = string.Empty;

        DataSet ds2;
        //vUserId = 7702;

        //ds2 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserID);
        newDBS ndb = new newDBS();
        ds2 = ndb.Ebook_KeywordDetails_ByUserIDNew(vUserID, ctryVal.ToString());

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

        if (flagMalaysiaStatus.ToString() == "0") { flgMalaysia.Visible = false; }
        if (flagSingaporeStatus.ToString() == "0") { flgSingapore.Visible = false; }
        if (flagIndonesiaStatus.ToString() == "0") { flgIndonesia.Visible = false; }
        if (flagThilandStatus.ToString() == "0") { flgThailand.Visible = false; }
        if (flagPhilippinesStatus.ToString() == "0") { flgPhilippines.Visible = false; }
        if (flagVietnamStatus.ToString() == "0") { flgVietnam.Visible = false; }

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
        string tmpDomain = string.Empty;

        DataSet ds;
        ds = objBALebook.Ebook_GetBookDetails(qBookID, vUserID);

        if (ds.Tables[1].Rows.Count > 0)
        {
            DataTable dt1 = ds.Tables[1];
            DataRow dr1 = dt1.Rows[0];
            tmpDomain = dr1["Domain"].ToString();
            string fbhrefVal = "http://www.facebook.com/sharer/sharer.php?s=100&p[url]=" + url + "/#Register&p[images][0]=" + dr1["bookFullImage"] + "&p[title]=" + dr1["domain"] + "&p[summary]=" + dr1["description"];
        }        

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];

            lblBookID.Text = dr["BookID"].ToString();
            lblBookName.Text = dr["BookNAme"].ToString();
            lblCategory.Text = dr["CategoryName"].ToString();
            lblStarRating.Text = dr["starRatingDisp"].ToString();

            DateTime dNewDate = Convert.ToDateTime(dr["DateCreated"].ToString());
            String strNewDate = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dNewDate);
            lblDateAdded.Text = strNewDate;
            lblTitle.Text = dr["Title"].ToString();           
            lblOrgPrice.Text = dr["UserCurrency"].ToString() + " " + String.Format("{0:n2}", Convert.ToDecimal(dr["Price"].ToString()));
            lblAfterDiscount.Text = dr["UserCurrency"].ToString() + " " + String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString()));
            //lblPrepaidValue.Text = dr["PrepaidPrice"].ToString();
            ImgEbook.ImageUrl = dr["ImageFileFullURL"].ToString();

            String tmpDescription = dr["Description"].ToString();
            tmpDescription = tmpDescription.Replace(Environment.NewLine, "<br/>");
            dvBookDescription.InnerHtml = "<p>" + tmpDescription + "</p>";

            metaTitle.Content = dr["BookNAme"].ToString();
            if (tmpDescription.Length > 100)
            {
                metaDescription.Content = tmpDescription.Substring(0, 100).Replace("<br/>","");
            }
            else
            {
                metaDescription.Content = tmpDescription.ToString().Replace("<br/>", "");
            }

            //HtmlMeta meta = new HtmlMeta();
            //meta = new HtmlMeta();
            //meta.Attributes.Add("property", "og:image");
            //meta.Attributes.Add("content", "http://183.81.165.117" + ImgEbook.ImageUrl.ToString());
            //Page.Header.Controls.Add(meta);

            metaogimage.Content = ImgEbook.ImageUrl.ToString();
            //metaogimage.Content = "http://siva.evenchise.com/DocumentRepository/eBookImages/395_test_cigars.jpg";
            metaogtitle.Content = url.ToString();
            hfPinterest.HRef = "http://pinterest.com/pin/create/button/?url=" + url + "&media=" + tmpDomain + ImgEbook.ImageUrl.ToString();

            int vLaunchStatus = Convert.ToInt16(dr["LaunchStatus"].ToString());
            int isFreeBook = Convert.ToInt16(dr["isFreeBook"].ToString());
            int preview = Convert.ToInt16(dr["PreviewStatus"].ToString());
            String BookAllowSmsBuy = dr["AllowSMSbuy"].ToString();
            String BookAllowPayPalBuy = dr["AllowPaypalBuy"].ToString();
            if (BookAllowSmsBuy.ToUpper() == "FALSE")
                tmpAllowSmsPurchase = "FALSE";

            LnkPreview.Visible = false;
            if (preview == 1)
            {
                LnkPreview.Visible = true;
            }

            //if (isFreeBook==1)
            //{
            //    dvPriceDetails.Visible = false;
            //}
            //tmpDescription = "<p class='BkfontDescription'>" + tmpDescription + "</p>";


            string tmpImagePath = Page.ResolveUrl(ImgEbook.ImageUrl);
            LnkPayPalBuy.CommandArgument = lblBookID.Text + "#" + lblBookName.Text + "#" + String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString())) + "#" + tmpImagePath;
            lnkAddtoCart.CommandArgument = lblBookID.Text + "#" + lblBookName.Text + "#" + String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString())) + "#" + tmpImagePath;
            
            //lblHeader.Text = lblBookName.Text;

            if (tmpKeyword != "")
            {
                dvglobalpurchaseLink.Visible = true;
                dvGlobalPurchase.Visible = true;
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
                            newDBS ndbs1 = new newDBS();
                            DataSet dst1 = ndbs1.ebook_getKeywordDetails_AllCountries(Session["ClientID"].ToString(), qBookID);
                            pBookID.Text = dr["BookID"].ToString();
                            pBookName.Text = dr["BookNAme"].ToString();
                            pBookCategory.Text = dr["CategoryName"].ToString();
                            pBookDate.Text = strNewDate;
                            pBookOrgPrice.Text = dr["UserCurrency"].ToString() + " " + String.Format("{0:n2}", Convert.ToDecimal(dr["Price"].ToString()));
                            pBookDiscountPrice.Text = dr["UserCurrency"].ToString() + " " + String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString()));
                            //pBookPrepaidPrice.Text = dr["PrepaidPrice"].ToString();
                            pBookImage.ImageUrl = dr["ImageFileFullURL"].ToString();



                                if (dst1.Tables[0].Rows.Count > 0)
                                {
                                    DataRow nrow = dst1.Tables[0].Rows[0];
                                    if (nrow["countryName"].ToString() != null)
                                    {
                                        dvPBookFormat.Visible = true;
                                        string ctryName = nrow["countryName"].ToString();
                                        string ctryCurrency = nrow["currencyName"].ToString();
                                        string ctryPriceTag = nrow["PriceTag"].ToString();
                                        string ctryShortcode = nrow["shortcode"].ToString();
                                        string ctryNote = nrow["displayNote"].ToString();
                                        string ctryKeyword = nrow["Keyword"].ToString();
                                        string ctrySendTo = nrow["SendTo"].ToString();

                                        //imgOne.ImageUrl = "~/Images/flag_indonesia_small1.jpg";
                                        //Literal101.Text = ctryName;
                                        //Literal10.Text = ctryName + " Mobile Purchase Format";
                                        pBookSendTo.Text = ctrySendTo;
                                        pPFormat.Text = ctryKeyword + " &nbsp;" + tmpEstoreID + " &nbsp;" + lblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                                        pBookDFormat.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                                    }
                                    else
                                    {
                                        dvPBookFormat.Visible = false;
                                    }

                                    DataRow nrow1 = dst1.Tables[0].Rows[1];
                                    if (nrow["countryName"].ToString() != null)
                                    {
                                        dvPBookFormat1.Visible = true;
                                        string ctryName = nrow1["countryName"].ToString();
                                        string ctryCurrency = nrow1["currencyName"].ToString();
                                        string ctryPriceTag = nrow1["PriceTag"].ToString();
                                        string ctryShortcode = nrow1["shortcode"].ToString();
                                        string ctryNote = nrow1["displayNote"].ToString();
                                        string ctryKeyword = nrow1["Keyword"].ToString();
                                        string ctrySendTo = nrow1["SendTo"].ToString();

                                        //imgTwo.ImageUrl = "~/Images/Flag_sing_small.jpg";
                                        //Literal102.Text = ctryName;
                                        //Literal20.Text = ctryName + " Mobile Purchase Format";
                                        pBookSendTo1.Text = ctrySendTo;
                                        pPFormat1.Text = ctryKeyword + " &nbsp;" + tmpEstoreID + " &nbsp;" + lblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                                        pBookDFormat1.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                                    }
                                    else
                                    {
                                        dvPBookFormat1.Visible = false;
                                    }

                                    DataRow nrow2 = dst1.Tables[0].Rows[2];
                                    if (nrow2["countryName"].ToString() != null)
                                    {
                                        dvPBookFormat2.Visible = true;
                                        string ctryName = nrow2["countryName"].ToString();
                                        string ctryCurrency = nrow2["currencyName"].ToString();
                                        string ctryPriceTag = nrow2["PriceTag"].ToString();
                                        string ctryShortcode = nrow2["shortcode"].ToString();
                                        string ctryNote = nrow2["displayNote"].ToString();
                                        string ctryKeyword = nrow2["Keyword"].ToString();
                                        string ctrySendTo = nrow2["SendTo"].ToString();

                                        //imgThree.ImageUrl = "~/Images/flag_mas_small.jpg";
                                        //Literal103.Text = ctryName;
                                        //Literal30.Text = ctryName + " Mobile Purchase Format";
                                        pBookSendTo2.Text = ctrySendTo;
                                        if (tmpKeyword == "ZZ" && ctryVal == "MY")
                                        {
                                            pPFormat2.Text = "CENT5&nbsp; ZZ" + " &nbsp;" + tmpEstoreID + " &nbsp;" + lblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                                            pBookDFormat2.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + "CENT5 ZZ" + " " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                                        }
                                        else
                                        {
                                            pPFormat2.Text = tmpEstoreID + " &nbsp;" + lblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                                            pBookDFormat2.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                                        }                                        
                                        
                                    }
                                    else
                                    {
                                        dvPBookFormat2.Visible = false;
                                    }
                                }       



                        tblFreeEbooksPurchase.Visible = false;
                        //tblComingSoon.Visible = false;
                        if (tmpKeyword == "ZZ" && ctryVal == "MY")
                        {
                            if (tmpEstoreID != "")
                            {
                                tblPurchase.Visible = true;
                                Literal10.Text = "Malaysia";
                                lblPurFormat.Text = "CENT5&nbsp; ZZ &nbsp;" + tmpEstoreID + " &nbsp;" + lblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                                Literal12.Text = "sendTo &nbsp; 36247";
                                lblPurchaseNote.Text = Resources.LangResources.Note + ":- " + string.Format("{0:0.00}", tmpBookPrice) + Resources.LangResources.persmsreceived + ". Eg. CENT5 ZZ " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo" + " " + appendMessageMY;

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
                                Literal10.Text = "Malaysia";
                                lblPurFormat.Text = tmpKeyword + " &nbsp;" + lblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                                Literal12.Text = "sendTo &nbsp; 36247";
                                lblPurchaseNote.Text = Resources.LangResources.Note + ":- " + string.Format("{0:0.00}", tmpBookPrice) + Resources.LangResources.persmsreceived + ". Eg. " + tmpKeyword + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo" + " " + appendMessageMY;
                            }
                            else
                            {
                                tblPurchase.Visible = false;
                                dvBookPurchaseFormat.Visible = false;
                            }
                        }
                                     
                        if (ctryVal != "MY")
                        {
                            dvBookPurchaseFormat.Visible = true;
                            tblPurchase.Visible = true;
                            newDBS ndbs = new newDBS();
                            DataSet dst = ndbs.ebook_getKeywordDetails_CountryWise(ctryVal);
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

                                    Literal10.Text = ctryName + " Mobile Purchase";
                                    Literal12.Text = ctrySendTo;
                                    lblPurFormat.Text = ctryKeyword + " &nbsp;" + tmpEstoreID + " &nbsp;" + lblBookID.Text + " &nbsp;YourEmail &nbsp;YourName";
                                    lblPurchaseNote.Text = Resources.LangResources.Note + ":- " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
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

                        if (tmpAllowPayPal.ToUpper() == "TRUE")
                        {
                            LnkPayPalBuy.Visible = true;
                            lnkAddtoCart.Visible = true;
                        }
                    }

                }
                else
                {
                    dvglobalpurchaseLink.Visible = false;
                    dvGlobalPurchase.Visible = false;
                    tblFreeEbooksPurchase.Visible = true;
                    tblComingSoon.Visible = false;
                    tblPurchase.Visible = false;
                    LnkPayPalBuy.Visible = false;
                    lnkAddtoCart.Visible = false;
                    String vStoreID = tmpEstoreID;
                    Literal13.Text = "Step3 - Request Free EBook<br>" + "FREE " + vStoreID + " " + lblBookID.Text + " YourEmail YourName";
                    lblPurFormat2.Text = "FREE " + vStoreID + " " + lblBookID.Text + " YourEmail YourName";
                    Literal14.Text = "SendTo<br>1)+447860041399<br>2)+6582400216";
                    if (lblPurchaseNote2 != null)
                        lblPurchaseNote2.Text = "Eg. FREE " + vStoreID + " " + lblBookID.Text + " JohnWoo@yahoo.com John Woo";
                    String strPrice = "0.00";
                    decimal vPrice = Convert.ToDecimal(strPrice);
                    tmpBookPrice = String.Format("{0:n2}", vPrice.ToString());
                    lblAfterDiscount.Text = tmpBookPrice;
                    //ImgFreeBook.Visible = true;
                    dvCtryFlags.Visible = false;
                }

                //hyperlink1.NavigateUrl = "javascript:window.open('eBookShowcountriesformatnew.aspx?qBookID=" + ViewState["qBookID"].ToString() + "',null,'resizable=no,toolbar=no,scrollbars=no,menubar=no,status=no,width=1100,height=780');";
                //if (isFreeBook == 0)
                //{ }
                //else
                //{
                //    hyperlink1.Visible = false;
                //}
            }

            if (vLaunchStatus == 2)
            {
                dvglobalpurchaseLink.Visible = false;
                dvGlobalPurchase.Visible = false;
                dvBookPurchaseFormat.Visible = true;
                //dvBookPurchaseFormat.Attributes.Add("class", "dvBookPurchase_ComingCss");

                tblFreeEbooksPurchase.Visible = false;
                tblComingSoon.Visible = true;

                tblPurchase.Visible = false;
                LnkPayPalBuy.Visible = false;
                lnkAddtoCart.Visible = false;

                //ImgFreeBook.Visible = true;
                //ImgFreeBook.ImageUrl = "~/Images/ebImages/ComingSoonSmall1.jpg";
            }

        }
        else
        {

        }

        Session["ipCtry"] = MyGeoLocation.GetCountryCodeFromIP();
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
        CommonFunctions.AddItemtoCartNew(vCustomString, Request.Url.AbsoluteUri);
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
            Server.Transfer("O_dtShowDetails.aspx");
        }
    }

    protected void LnkPreview_Command(object sender, CommandEventArgs e)
    {
        //Server.Transfer("/previewbook.aspx?qBookID=" + ViewState["qBookID"].ToString());
        //string pURL = "/previewbook.aspx?qBookID=" + ViewState["qBookID"].ToString();
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + pURL + "','_newtab');", true);
        Response.Redirect("/previewbook.aspx?qBookID=" + ViewState["qBookID"].ToString());
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

    protected void flgMalaysia_Click(object sender, ImageClickEventArgs e)
    {
        Session["ipCtry"] = "MY";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + Request.QueryString["qBookID"].ToString());
    }

    protected void flgSingapore_Click(object sender, ImageClickEventArgs e)
    {
        Session["ipCtry"] = "SG";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + Request.QueryString["qBookID"].ToString());
    }

    protected void flgIndonesia_Click(object sender, ImageClickEventArgs e)
    {
        Session["ipCtry"] = "ID";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + Request.QueryString["qBookID"].ToString());
    }

    protected void flgThailand_Click(object sender, ImageClickEventArgs e)
    {
        Session["ipCtry"] = "TH";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + Request.QueryString["qBookID"].ToString());
    }

    protected void flgVietnam_Click(object sender, ImageClickEventArgs e)
    {
        Session["ipCtry"] = "VN";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + Request.QueryString["qBookID"].ToString());
    }

    protected void flgPhilippines_Click(object sender, ImageClickEventArgs e)
    {
        Session["ipCtry"] = "PH";
        Response.Redirect("O_dtShowDetails.aspx?qBookID=" + Request.QueryString["qBookID"].ToString());
    }

}