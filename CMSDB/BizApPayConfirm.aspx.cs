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

public partial class BizApPayConfirm : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    //DataTable dt;
    int tmpRowCount = 0;
    //decimal tmpTotalAmount = 0;

    string txtBuyerName = string.Empty;
    string txtBuyerEmail = string.Empty;
    string txtBuyerMobile = string.Empty;
    string userCurrency = string.Empty;
    string vBookIds = string.Empty;
    string tmpTitle = string.Empty;
    string pWebsiteName = string.Empty;
    decimal vTotalAmt = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }

        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.getUserCurrency(Convert.ToInt32(Session["ClientID"]).ToString());

        userCurrency = "$";
        if (dst.Tables[0].Rows.Count > 0)
        {
            userCurrency = dst.Tables[0].Rows[0]["Currency"].ToString();
        }

        DataSet dstUser = ndbs.user_getProfile(Session["cLogin"].ToString());
        if (dstUser.Tables[0].Rows.Count > 0)
        {
            txtBuyerName = dstUser.Tables[0].Rows[0]["FullName"].ToString();
            txtBuyerEmail = dstUser.Tables[0].Rows[0]["email"].ToString();
            txtBuyerMobile = dstUser.Tables[0].Rows[0]["Mobile"].ToString();
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

                foreach (DataRow cRow in CartDataTable.Rows)
                {
                    vBookIds += cRow["id"].ToString() + ",";
                    vTotalAmt += Convert.ToDecimal(cRow["price"].ToString());
                    tmpTitle = cRow["name"].ToString();
                }

                ViewState["ItemsString"] = vBookIds;
            }
        }

        DataSet dstC = ndbs.BillPlz_currencyConvert(userCurrency.ToString(), vTotalAmt.ToString());
        if (dstC.Tables[0].Rows.Count > 0)
        {
            vTotalAmt = Convert.ToDecimal(dstC.Tables[0].Rows[0]["repAmount"].ToString());
        }

        int vClientId = Convert.ToInt32(Session["ClientID"].ToString());
        ds = objBALebook.Eb_WEB_GetMerchantInfo(Convert.ToInt32(vClientId));
        DataTable dtMerchant = ds.Tables[0];
        if (dtMerchant.Rows.Count > 0)
        {
            DataRow Urow = dtMerchant.Rows[0];
            pWebsiteName = Urow["paypalwebsite"].ToString();
        }

        string redirectURL = pWebsiteName + "/BizApPayReturn.aspx";

        string BillPlzURL = "http://gt.evenchise.com/BizApPayCreateBill.aspx?denomination=" + userCurrency.ToString() + "&pDesc=" + tmpTitle.ToString();
        BillPlzURL = BillPlzURL + "&pCode=" + ViewState["ItemsString"].ToString() + "&rURL=" + redirectURL + "&email=" + txtBuyerEmail + "&phone=" + txtBuyerMobile;
        BillPlzURL = BillPlzURL + "&name=" + txtBuyerName + "&amount=" + Convert.ToInt32((vTotalAmt * 100)).ToString() + "&userid=" + Session["ClientID"].ToString() + "&userlogin=" + Session["cLogin"].ToString();

        Response.Redirect(BillPlzURL.ToString());
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
                //String WebRegURL = "Mas1UserWebRegistration.aspx";
            }
        }

        if (newUserID == 0)
        {
            Response.Redirect("PartnerWebRegistrationNew.aspx");
        }
        return newUserID;
    }

}