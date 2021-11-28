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

public partial class N_Main3 : System.Web.UI.Page
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
        DataTable dtDesign2 = ds.Tables[3];

        if (dtDesign2.Rows.Count > 0)
        {
            DataRow DRow = dtDesign2.Rows[0];
            String WelcomePageTxt = DRow["WelcomePageText"].ToString();
            lblWp_WelcomePageText.Text = WelcomePageTxt.Replace(Environment.NewLine, "<br/>");
        }

        newDBS nds = new newDBS();
        DataSet dsH = nds.design_homePageProducts(Convert.ToInt32(vUserId.ToString()), 11);
        DataTable dsHSettings = dsH.Tables[0];
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

        #region ...Best Seller
        StringBuilder sb2 = new StringBuilder();

        int counter = 0;
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
                tmpBookURL = @"N_ShowDetails.aspx?qBookID=" + tBookID;
                tmpRowNo = Convert.ToInt32(sRow["RowNo"].ToString());
                if (counter < 3)
                {
                    sb2.AppendLine("<div class='col-xs-4'>");
                    sb2.AppendLine("<div class='product'>");
                    sb2.AppendLine("<div class='product-image'>");
                    sb2.AppendLine("<a href='" + tmpBookURL + "'><img src='" + tBookImageURL + "' height='180' width='140' alt='book'></a>");
                    sb2.AppendLine("</div></br>");
                    sb2.AppendLine("<h3 class='product-title text-center'>");
                    sb2.AppendLine(tBookName);
                    sb2.AppendLine("</h3>");
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


        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.getUserCurrency(Convert.ToInt32(Session["ClientID"]).ToString());
        string userCurrency = string.Empty;
        userCurrency = "$";
        if (dst.Tables[0].Rows.Count > 0)
        {
            userCurrency = dst.Tables[0].Rows[0]["Currency"].ToString();
        }
        DataTable CartDataTable = null;
        int tmpRowCount = 0;
        decimal tmpPrice = 0;
        StringBuilder sbP = new StringBuilder();
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
                for (int i = 0; i < CartDataTable.Rows.Count; i++)
                {
                    tmpPrice = tmpPrice + Convert.ToDecimal(String.Format("{0:0.00}", CartDataTable.Rows[i][2].ToString()));
                }
                cartItems.Text = ViewState["ItemsCount"].ToString();
                cartPrice.Text = tmpPrice.ToString();
                cartCurrency.Text = userCurrency.ToString();
            }
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