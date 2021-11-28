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
using System.Configuration;

public partial class O_dtPaypalConfirm : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    //DataTable dt;
    int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }
        //if ((Session["cLogin"] == null) || (Session["cLogin"] == ""))
        //{
        //    CommonFunctions.AlertMessageAndRedirect("Please Signin for Returning Customer  OR  Create a New Buyer Account", "O_dt_User_Login.aspx");
        //    //Response.Redirect("O_dt_User_Login.aspx");
        //}
        //else
        //{
            if (!IsPostBack)
            {
                ViewState["TotalAmount"] = "00.00";
                if (Request.QueryString["CpUri"] != null)
                    ViewState["CallingPage"] = Request.QueryString["CpUri"].ToString();
                else
                    ViewState["CallingPage"] = "";

                LoadCartItems();
            }
        //}
    }

    protected void LoadCartItems()
    {
        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.getUserCurrency(Convert.ToInt32(Session["ClientID"]).ToString());
        string userCurrency = string.Empty;
        userCurrency = "$";
        if (dst.Tables[0].Rows.Count > 0)
        {
            userCurrency = dst.Tables[0].Rows[0]["Currency"].ToString();
        }

        DataSet dstUser = ndbs.user_getProfile(Session["cLogin"].ToString());
        if (dstUser.Tables[0].Rows.Count > 0)
        {
            txtBuyerName.Text = dstUser.Tables[0].Rows[0]["FullName"].ToString();
            txtBuyerEmail.Text = dstUser.Tables[0].Rows[0]["email"].ToString();
            txtBuyerMobile.Text = dstUser.Tables[0].Rows[0]["Mobile"].ToString();
        }

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
                foreach (DataRow cRow in CartDataTable.Rows)
                {
                    vBookIds += cRow["id"].ToString() + ",";
                    vBookIds2Show += cRow["id"].ToString() + ";&nbsp;&nbsp;&nbsp;";
                    vTotalAmt += Convert.ToDecimal(cRow["price"].ToString());
                    String tmpID = cRow["id"].ToString();
                    String tmpImgUrl = cRow["ImageUrl"].ToString();
                    String tmpCurrency = cRow["currency"].ToString();
                    String tmpPrice = cRow["price"].ToString();
                    String tmpTitle = cRow["name"].ToString() + "\n" + tmpCurrency + ' ' + tmpPrice;
                    tmpImgUrl = tmpImgUrl.Substring(1);
                    VbookImgs += "<div style='float: left; margin-left: 6px; padding: 2px;'> " + tmpID + "<br/>" + "<img alt='bkimg' height='60' src='" + tmpImgUrl + "' title='" + tmpTitle + "'> </div>";
                }
                String vCurrency = string.Empty;
                if (Session["UserCurrency"] != null)
                    vCurrency = Session["UserCurrency"].ToString();
                else
                    vCurrency = userCurrency.ToString();
                
                lblBookID.Text = "<div>" + VbookImgs + "</div>";
                lblTotalItems.Text = tmpRowCount.ToString();
                lblAmtCurrency.Text = vCurrency;
                lbltotalAmount.Text = vTotalAmt.ToString();
                ViewState["ItemsString"] = vBookIds;
            }
        }
        if (Session["navcheckout"].ToString() == "1")
        {
            lnkBuyNow_Click(new object(), new EventArgs());
        }
    }

    protected void lnkBuyNow_Click(object sender, EventArgs e)
    {
        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.getUserCurrency(Convert.ToInt32(Session["ClientID"]).ToString());
        string userCurrency = string.Empty;
        userCurrency = "$";
        if (dst.Tables[0].Rows.Count > 0)
        {
            userCurrency = dst.Tables[0].Rows[0]["Currency"].ToString();
        }

        int vClientId = Convert.ToInt32(Session["ClientID"].ToString());
        long tmpCartID = objBALebook.ShoppingCart_PreInsert(vClientId, ViewState["ItemsString"].ToString(), Convert.ToInt32(lblTotalItems.Text), Convert.ToDecimal(lbltotalAmount.Text));
        //DataSet ds2;
        newDBS clsObjNewDbs = new newDBS();
        string cLoginuser = string.Empty;
        if ((cLoginuser == null) || (cLoginuser == ""))
        {
            cLoginuser = "siva";
        }
        if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
        {
            cLoginuser = "siva";
        }
        else
        {
            cLoginuser = Session["cLogin"].ToString();
        }

        string isAdminBook = "0";
        DataSet ds3;
        ds3 = clsObjNewDbs.user_TransctionHistory(cLoginuser, tmpCartID.ToString(), "2");
        if (ds3.Tables[0].Rows.Count > 0)
        {
            isAdminBook = ds3.Tables[0].Rows[0]["isAdminBook"].ToString();
        }
        Thread.Sleep(3000);

        //dvRightContent.Visible = false;
        //dv2PayPalSite.Visible = true;

        //String vCallingPage = ViewState["CallingPage"].ToString();
        String vCallingPage = "";
        String veStoreID = String.Empty;
        String vCustomText = String.Empty;
        String vBuyerName = txtBuyerName.Text.Trim();
        String vBuyerEmail = txtBuyerEmail.Text.Trim();
        String vBuyerMobile = txtBuyerMobile.Text.Trim();

        String vBusiness = String.Empty;
        String vMemberName = string.Empty;
        String vMobileID = String.Empty;
        String vWebsiteName = String.Empty;
        string pWebsiteName = string.Empty;

        String vTotalItems = lblTotalItems.Text;
        String vTotalAmount = lbltotalAmount.Text;
        //String vCurrency = lblAmtCurrency.Text;
        String vCurrency = userCurrency.ToString();

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
            pWebsiteName = Urow["paypalwebsite"].ToString();
        }

        //if (isAdminBook == "1")
        //{
        //vBusiness = "happysam88@yahoo.com";
        vBusiness = "kallurusiva@gmail.com";
        //}

        vCustomText = vClientId + "#" + tmpCartID + "#" + vTotalItems + "#" + vTotalAmount + "#" + vCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile;
        String vBookName = ViewState["ItemsString"].ToString();
        Session.Remove("basket");
        CommonFunctions.ProceedToPalBuyMerchant(vBusiness, vBuyerName, vBuyerMobile, vBuyerEmail, vTotalAmount, vCurrency, vBookName, tmpCartID.ToString(), vCustomText, pWebsiteName, vClientId.ToString(), vCallingPage);
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