using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.Threading;
using CMSv3.Entities;
using CMSv3.BAL;
using System.Data;
using System.Data.SqlClient;
using System.Resources;
using System.Collections;


public partial class O_dtNew : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    //DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ClientID"] = GetUserIdfromURL().ToString();
        //Session["ClientID"] = "7661";
        Session["css"] = "RED";
        LoadHomePageItems(Convert.ToInt32(Session["ClientID"].ToString()));
    }

    protected void LoadHomePageItems(int vUserId)
    {
        string FBProduct = string.Empty;
        string BSProduct = string.Empty;
        string NRProduct = string.Empty;
        string VBProduct = string.Empty;
        string FreeProduct = string.Empty;

        FBProduct = "1";
        BSProduct = "1";
        NRProduct = "1";
        VBProduct = "1";
        FreeProduct = "1";

        ds = objBALebook.HomePageItems_ByUserID(vUserId, "");

        newDBS nds = new newDBS();
        DataSet dsH = nds.design_homePageProducts(Convert.ToInt32(vUserId.ToString()), 11);
        DataTable dsHSettings = dsH.Tables[0];
        DataTable dispSettings = dsH.Tables[1];
        if (dsHSettings.Rows.Count > 0)
        {
            DataRow drh = dsHSettings.Rows[0];
            FBProduct = drh["FeatureBuy"].ToString();
            BSProduct = drh["BestSeller"].ToString();
            NRProduct = drh["NewReleases"].ToString();
            VBProduct = drh["ValueBuy"].ToString();
            FreeProduct = drh["free"].ToString();
        }

        DataTable dtFeatureBuy = ds.Tables[0];
        DataTable dtBestSeller = ds.Tables[1];
        DataTable dtValueBuy = ds.Tables[2];
        DataTable dtHomePictures = ds.Tables[5];
        DataTable dtNewReleases = ds.Tables[6];
        DataTable dtFree = ds.Tables[7];

        String tBookImageURL = string.Empty;
        String tBookID = string.Empty;
        String tBookName = string.Empty;
        String tBookPrice = String.Empty;
        String tBookPriceCancel = string.Empty;
        string tmpBookURL = string.Empty;
        String tmpUsercurrency = string.Empty;
        String tmpIsFreeBook = string.Empty;
        int tmpRowNo = 0;
        string vECode1 = string.Empty;
        string vECode2 = string.Empty;
        string vECode3 = string.Empty;
        string vECode4 = string.Empty;
        string vECode5 = string.Empty;

        StringBuilder sb = new StringBuilder();
        String dvContent_FeatureBuy = String.Empty;
        String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();

        if (dtHomePictures.Rows.Count > 0)
        {
            foreach (DataRow pRow in dtHomePictures.Rows)
            {
                string imgPicture1 = pRow["Picture1"].ToString();
                string imgPicture2 = pRow["Picture2"].ToString();
                string imgPicture3 = pRow["Picture3"].ToString();
                string imgPicture4 = pRow["Picture4"].ToString();
                string imgPicture5 = pRow["Picture5"].ToString();

                vECode1 = pRow["ECode1"].ToString();
                vECode2 = pRow["ECode2"].ToString();
                vECode3 = pRow["ECode3"].ToString();
                vECode4 = pRow["ECode4"].ToString();
                vECode5 = pRow["ECode5"].ToString();

               
            }
        }
        else
        {
            
        }

       

        //..Feature Buy 
        #region ...Feature Buy
        int counter = 0;
        if (dtFeatureBuy.Rows.Count > 0 && Convert.ToInt32(FBProduct) > 0)
        {
            foreach (DataRow fRow in dtFeatureBuy.Rows)
            {
                tBookID = fRow["BookID"].ToString();
                tBookName = fRow["BookName"].ToString();
                tBookPrice = fRow["DiscountedPrice"].ToString();
                tBookPriceCancel = fRow["Price"].ToString();
                tBookImageURL = fRow["ImageFileFullURL"].ToString();
                tmpUsercurrency = fRow["UserCurrency"].ToString();
                tmpIsFreeBook = fRow["isFreeBook"].ToString();
                tmpBookURL = @"O_dtShowDetails.aspx?qBookID=" + tBookID;
                tmpRowNo = Convert.ToInt32(fRow["RowNo"].ToString());
                if (counter < 3)
                {
                    sb.AppendLine("<div class='product-column'>");
                    sb.AppendLine("<div class='product product5'>");
                    sb.AppendLine("<div class='product-top'>");
                    sb.AppendLine("<figure>");
                    sb.AppendLine("<a href='" + tmpBookURL + "'><img src='" + tBookImageURL + "' class='img-responsive' alt='Product Image'></a>");
                    sb.AppendLine("</figure>");
                    sb.AppendLine("<a href='" + tmpBookURL + "' class='btn-quickview icon' title='View'><span class='sr-only'>View</span></a>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("<div class='product-meta'>");
                    sb.AppendLine("<div class='product-brand'><a href=" + tmpBookURL + "'>" + tBookName + "</a></div>");
                    sb.AppendLine("</div>");
                    //sb.AppendLine("<h3 class='product-title'><a href='product_detail.html'>Thanks in everything - Book from U.S</a></h3>");
                    //if (tmpIsFreeBook == "1")
                    //{
                    //    sb.AppendLine("<div class='product-price-container'><span class='product-price'>" + "FREE" + "</span></div>");
                    //}
                    //else
                    //{
                    //    sb.AppendLine("<div class='product-price-container'><span class='product-price'>" + tmpUsercurrency + " " + String.Format("{0:n2}", Convert.ToDecimal(tBookPrice)) + "</span></div>");
                    //}
                    //sb.AppendLine("<div class='product-action'><a href='cart.html' class='btn-add-cart' title='Add to Cart'><i class='icon icon-cart'></i> <span>Add To Cart</span></a>");
                    //sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</div>");
                    counter = counter + 1;
                }
            }
            dvProduct.InnerHtml = sb.ToString();
        }
        else
        {
            dvProduct.InnerHtml = " ";
            dvFeatureProduct.Visible = false;
        }

        #endregion

        #region ...Best Seller
        StringBuilder sb2 = new StringBuilder();
        counter = 0;
        if (dtBestSeller.Rows.Count > 0 && Convert.ToInt32(BSProduct) > 0)
        {
            foreach (DataRow sRow in dtBestSeller.Rows)
            {
                tBookID = sRow["BookID"].ToString();
                tBookName = sRow["BookName"].ToString();
                tBookPrice = sRow["DiscountedPrice"].ToString();
                tBookPriceCancel = sRow["Price"].ToString();
                tBookImageURL = sRow["ImageFileFullURL"].ToString();
                tmpUsercurrency = sRow["UserCurrency"].ToString();
                tmpIsFreeBook = sRow["isFreeBook"].ToString();
                tmpBookURL = @"O_dtShowDetails.aspx?qBookID=" + tBookID;
                tmpRowNo = Convert.ToInt32(sRow["RowNo"].ToString());
                if (counter < 3)
                {
                    sb2.AppendLine("<div class='product-column'>");
                    sb2.AppendLine("<div class='product product5'>");
                    sb2.AppendLine("<div class='product-top'>");
                    sb2.AppendLine("<figure>");
                    sb2.AppendLine("<a href='" + tmpBookURL + "'><img src='" + tBookImageURL + "' class='img-responsive' height='300' width='300' alt='Product Image'></a>");
                    sb2.AppendLine("</figure>");
                    sb2.AppendLine("<a href='" + tmpBookURL + "' class='btn-quickview icon' title='View'><span class='sr-only'>View</span></a>");
                    sb2.AppendLine("</div>");
                    sb2.AppendLine("<div class='product-meta'>");
                    sb2.AppendLine("<div class='product-brand'><a href='" + tmpBookURL + "'>" + tBookName + "</a></div>");
                    sb2.AppendLine("</div>");
                    //sb.AppendLine("<h3 class='product-title'><a href='product_detail.html'>Thanks in everything - Book from U.S</a></h3>");
                    ////if (tmpIsFreeBook == "1")
                    ////{
                    ////    sb2.AppendLine("<div class='product-price-container'><span class='product-price'>" + "FREE" + "</span></div>");
                    ////}
                    ////else
                    ////{
                    ////    sb2.AppendLine("<div class='product-price-container'><span class='product-price'>" + tmpUsercurrency + " " + String.Format("{0:n2}", Convert.ToDecimal(tBookPrice)) + "</span></div>");
                    ////}
                    //sb2.AppendLine("<div class='product-action'><a href='cart.html' class='btn-add-cart' title='Add to Cart'><i class='icon icon-cart'></i> <span>Add To Cart</span></a>");
                    //sb2.AppendLine("</div>");
                    sb2.AppendLine("</div>");
                    sb2.AppendLine("</div>");
                    counter = counter + 1;
                }
            }
            dvBestSeller.InnerHtml = sb2.ToString();
        }
        else
        {
            dvBestSeller.InnerHtml = " ";
            dvBestSellerProduct.Visible = false;
        }

        #endregion

        #region ...New Releases
        counter = 0;
        StringBuilder sb4 = new StringBuilder();
        if (dtNewReleases.Rows.Count > 0 && Convert.ToInt32(NRProduct) > 0)
        {
            foreach (DataRow nRow in dtNewReleases.Rows)
            {
                tBookID = nRow["BookID"].ToString();
                tBookName = nRow["BookName"].ToString();
                tBookPrice = nRow["DiscountedPrice"].ToString();
                tBookPriceCancel = nRow["Price"].ToString();
                tBookImageURL = nRow["ImageFileFullURL"].ToString();
                tmpUsercurrency = nRow["UserCurrency"].ToString();
                tmpIsFreeBook = nRow["isFreeBook"].ToString();
                tmpBookURL = @"O_dtShowDetails.aspx?qBookID=" + tBookID;
                tmpRowNo = Convert.ToInt32(nRow["RowNo"].ToString());
                if (counter < 3)
                {
                    sb4.AppendLine("<div class='product-column'>");
                    sb4.AppendLine("<div class='product product5'>");
                    sb4.AppendLine("<div class='product-top'>");
                    sb4.AppendLine("<figure>");
                    sb4.AppendLine("<a href='" + tmpBookURL + "'><img src='" + tBookImageURL + "' class='img-responsive' alt='Product Image'></a>");
                    sb4.AppendLine("</figure>");
                    sb4.AppendLine("<a href='" + tmpBookURL + "' class='btn-quickview icon' title='View'><span class='sr-only'>View</span></a>");
                    sb4.AppendLine("</div>");
                    sb4.AppendLine("<div class='product-meta'>");
                    sb4.AppendLine("<div class='product-brand'><a href=" + tmpBookURL + "'>" + tBookName + "</a></div>");
                    sb4.AppendLine("</div>");
                    //sb4.AppendLine("<h3 class='product-title'><a href='product_detail.html'>Thanks in everything - Book from U.S</a></h3>");
                    //if (tmpIsFreeBook == "1")
                    //{
                    //    sb4.AppendLine("<div class='product-price-container'><span class='product-price'>" + "FREE" + "</span></div>");
                    //}
                    //else
                    //{
                    //    sb4.AppendLine("<div class='product-price-container'><span class='product-price'>" + tmpUsercurrency + " " + String.Format("{0:n2}", Convert.ToDecimal(tBookPrice)) + "</span></div>");
                    //}
                    //sb4.AppendLine("<div class='product-action'><a href='cart.html' class='btn-add-cart' title='Add to Cart'><i class='icon icon-cart'></i> <span>Add To Cart</span></a>");
                    //sb4.AppendLine("</div>");
                    sb4.AppendLine("</div>");
                    sb4.AppendLine("</div>");
                    counter = counter + 1;
                }
            }
            dvNewRelease.InnerHtml = sb4.ToString();
        }
        else
        {
            dvNewRelease.InnerHtml = " ";
            dvNewReleaseProduct.Visible = false;
        }

        #endregion

        #region ...Value Buy

        StringBuilder sb3 = new StringBuilder();
        if (dtValueBuy.Rows.Count > 0 && Convert.ToInt32(VBProduct) > 0)
        {
            foreach (DataRow sRow in dtValueBuy.Rows)
            {
                tBookID = sRow["BookID"].ToString();
                tBookName = sRow["BookName"].ToString();
                tBookPrice = sRow["DiscountedPrice"].ToString();
                tBookPriceCancel = sRow["Price"].ToString();
                tmpUsercurrency = sRow["UserCurrency"].ToString();
                //tBookImageURL = sRow["ImageFileFullURL"].ToString();

                String MainBookShowURL = @"eBookShowValueBuyDetails.aspx?qBookID=" + tBookID;


                String tBookID1 = sRow["BookID1"].ToString();
                String tBookName1 = sRow["BookName1"].ToString();
                String tBookImageURL1 = sRow["ImageFileURL1"].ToString();
                String tmpShowBookURL1 = @"O_dtShowDetails.aspx?qBookID=" + tBookID1;


                String tBookID2 = sRow["BookID2"].ToString();
                String tBookName2 = sRow["BookName2"].ToString();
                String tBookImageURL2 = sRow["ImageFileURL2"].ToString();
                String tmpShowBookURL2 = @"O_dtShowDetails.aspx?qBookID=" + tBookID2;


                String tBookID3 = sRow["BookID3"].ToString();
                String tBookName3 = sRow["BookName3"].ToString();
                String tBookImageURL3 = sRow["ImageFileURL3"].ToString();
                String tmpShowBookURL3 = @"O_dtShowDetails.aspx?qBookID=" + tBookID3;


                String tBookID4 = sRow["BookID4"].ToString();
                String tBookName4 = sRow["BookName4"].ToString();
                String tBookImageURL4 = sRow["ImageFileURL4"].ToString();
                String tmpShowBookURL4 = @"O_dtShowDetails.aspx?qBookID=" + tBookID4;


                String tBookID5 = sRow["BookID5"].ToString();
                String tBookName5 = sRow["BookName5"].ToString();
                String tBookImageURL5 = sRow["ImageFileURL5"].ToString();
                String tmpShowBookURL5 = @"O_dtShowDetails.aspx?qBookID=" + tBookID5;




                int tBookScount = Convert.ToInt16(sRow["BooksCount"].ToString());
                int i = 0;




                //  sb3.AppendLine(" <div id='dvValueBuyBOOK' class='VB_ebookShowBox_Main ebValueBuyBOXCss' runat='server'>");
                //..Header

                hValueBuy.InnerHtml = "<h2 class='product-brand'>" + tBookID + " " + tBookName + "</h2>";

                //..Value Buy Books 
                //..Book 1

                sb3.AppendLine("<div class='product-column'>");
                sb3.AppendLine("<div class='product product5'>");
                sb3.AppendLine("<div class='product-top'>");
                sb3.AppendLine("<figure>");
                sb3.AppendLine("<a href='" + MainBookShowURL + "'><img src='" + tBookImageURL1 + "' class='img-responsive' height='300' width='300' alt='Product Image'></a>");
                sb3.AppendLine("</figure>");
                sb3.AppendLine("</div>");
                sb3.AppendLine("<div class='product-meta'>");
                sb3.AppendLine("<div class='product-brand'><a href='" + MainBookShowURL + "'>" + tBookName1 + "</a></div>");
                sb3.AppendLine("</div>");
                sb3.AppendLine("</div>");
                sb3.AppendLine("</div>");

                i++;

                //..Book 2                
                sb3.AppendLine("<div class='product-column'>");
                sb3.AppendLine("<div class='product product5'>");
                sb3.AppendLine("<div class='product-top'>");
                sb3.AppendLine("<figure>");
                sb3.AppendLine("<a href='" + MainBookShowURL + "'><img src='" + tBookImageURL2 + "' class='img-responsive' height='300' width='300' alt='Product Image'></a>");
                sb3.AppendLine("</figure>");
                sb3.AppendLine("</div>");
                sb3.AppendLine("<div class='product-meta'>");
                sb3.AppendLine("<div class='product-brand'><a href='" + MainBookShowURL + "'>" + tBookName2 + "</a></div>");
                sb3.AppendLine("</div>");
                sb3.AppendLine("</div>");
                sb3.AppendLine("</div>");

                i++;

                if (i < tBookScount)
                {
                    //..Book 3                    
                    sb3.AppendLine("<div class='product-column'>");
                    sb3.AppendLine("<div class='product product5'>");
                    sb3.AppendLine("<div class='product-top'>");
                    sb3.AppendLine("<figure>");
                    sb3.AppendLine("<a href='" + MainBookShowURL + "'><img src='" + tBookImageURL3 + "' class='img-responsive' height='300' width='300' alt='Product Image'></a>");
                    sb3.AppendLine("</figure>");
                    sb3.AppendLine("</div>");
                    sb3.AppendLine("<div class='product-meta'>");
                    sb3.AppendLine("<div class='product-brand'><a href='" + MainBookShowURL + "'>" + tBookName3 + "</a></div>");
                    sb3.AppendLine("</div>");
                    sb3.AppendLine("</div>");
                    sb3.AppendLine("</div>");

                    i++;
                }

                if (i < tBookScount)
                {
                    //..Book 4
                    sb3.AppendLine("<div class='product-column'>");
                    sb3.AppendLine("<div class='product product5'>");
                    sb3.AppendLine("<div class='product-top'>");
                    sb3.AppendLine("<figure>");
                    sb3.AppendLine("<a href='" + MainBookShowURL + "'><img src='" + tBookImageURL4 + "' class='img-responsive' height='300' width='300' alt='Product Image'></a>");
                    sb3.AppendLine("</figure>");
                    sb3.AppendLine("</div>");
                    sb3.AppendLine("<div class='product-meta'>");
                    sb3.AppendLine("<div class='product-brand'><a href='" + MainBookShowURL + "'>" + tBookName4 + "</a></div>");
                    sb3.AppendLine("</div>");
                    sb3.AppendLine("</div>");
                    sb3.AppendLine("</div>");

                    i++;
                }

                if (i < tBookScount)
                {
                    //..Book 5
                    sb3.AppendLine("<div class='product-column'>");
                    sb3.AppendLine("<div class='product product5'>");
                    sb3.AppendLine("<div class='product-top'>");
                    sb3.AppendLine("<figure>");
                    sb3.AppendLine("<a href='" + MainBookShowURL + "'><img src='" + tBookImageURL5 + "' class='img-responsive' height='300' width='300' alt='Product Image'></a>");
                    sb3.AppendLine("</figure>");
                    sb3.AppendLine("</div>");
                    sb3.AppendLine("<div class='product-meta'>");
                    sb3.AppendLine("<div class='product-brand'><a href='" + MainBookShowURL + "'>" + tBookName5 + "</a></div>");
                    sb3.AppendLine("</div>");
                    sb3.AppendLine("</div>");
                    sb3.AppendLine("</div>");

                    i++;
                }
            }
            dvBalueBuy.InnerHtml = sb3.ToString();
        }
        else
        {
            dvBalueBuy.InnerHtml = " ";
            dvValueBuyProduct.Visible = false;
        }

        #endregion

        #region ...Free
        StringBuilder sb5 = new StringBuilder();
        counter = 0;
        if (dtFree.Rows.Count > 0 && Convert.ToInt32(FreeProduct) > 0)
        {
            foreach (DataRow frRow in dtFree.Rows)
            {
                tBookID = frRow["BookID"].ToString();
                tBookName = frRow["BookName"].ToString();
                tBookPrice = frRow["DiscountedPrice"].ToString();
                tBookPriceCancel = frRow["Price"].ToString();
                tBookImageURL = frRow["ImageFileFullURL"].ToString();
                tmpUsercurrency = frRow["UserCurrency"].ToString();
                tmpIsFreeBook = frRow["isFreeBook"].ToString();
                tmpBookURL = @"O_dtShowDetails.aspx?qBookID=" + tBookID;
                tmpRowNo = Convert.ToInt32(frRow["RowNo"].ToString());
                if (counter < 3)
                {
                    sb5.AppendLine("<div class='product-column'>");
                    sb5.AppendLine("<div class='product product5'>");
                    sb5.AppendLine("<div class='product-top'>");
                    sb5.AppendLine("<figure>");
                    sb5.AppendLine("<a href='" + tmpBookURL + "'><img src='" + tBookImageURL + "' class='img-responsive' alt='Product Image'></a>");
                    sb5.AppendLine("</figure>");
                    sb5.AppendLine("<a href='" + tmpBookURL + "' class='btn-quickview icon' title='View'><span class='sr-only'>View</span></a>");
                    sb5.AppendLine("</div>");
                    sb5.AppendLine("<div class='product-meta'>");
                    sb5.AppendLine("<div class='product-brand'><a href=" + tmpBookURL + "'>" + tBookName + "</a></div>");
                    sb5.AppendLine("</div>");
                    //sb5.AppendLine("<h3 class='product-title'><a href='product_detail.html'>Thanks in everything - Book from U.S</a></h3>");
                    //if (tmpIsFreeBook == "1")
                    //{
                    //    sb5.AppendLine("<div class='product-price-container'><span class='product-price'>" + "FREE" + "</span></div>");
                    //}
                    //else
                    //{
                    //    sb5.AppendLine("<div class='product-price-container'><span class='product-price'>" + tmpUsercurrency + " " + String.Format("{0:n2}", Convert.ToDecimal(tBookPrice)) + "</span></div>");
                    //}
                    //sb5.AppendLine("<div class='product-action'><a href='cart.html' class='btn-add-cart' title='Add to Cart'><i class='icon icon-cart'></i> <span>Add To Cart</span></a>");
                    //sb5.AppendLine("</div>");
                    sb5.AppendLine("</div>");
                    sb5.AppendLine("</div>");
                    counter = counter + 1;
                }
            }
            dvFree.InnerHtml = sb5.ToString();
        }
        else
        {
            dvFree.InnerHtml = " ";
            dvFreeProduct.Visible = false;
        }

        #endregion



        if (dispSettings.Rows.Count > 0)
        {
            DataRow drS = dispSettings.Rows[0];
            if (drS["FeatureBuy"].ToString() == "0")
            {
                dvFeatureProduct.Visible = false;
            }
            if (drS["BestSeller"].ToString() == "0")
            {
                dvBestSellerProduct.Visible = false;
            }
            if (drS["NewReleases"].ToString() == "0")
            {
                dvNewReleaseProduct.Visible = false;
            }
            //if (drS["ValueBuy"].ToString() == "0")
            //{
            //    dvValueBuyProduct.Visible = false;
            //}
            if (drS["free"].ToString() == "0")
            {
                dvFreeProduct.Visible = false;
            }
            dvValueBuyProduct.Visible = false;
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
}