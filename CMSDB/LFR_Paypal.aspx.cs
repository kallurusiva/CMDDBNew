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
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using RestSharp;
using RestSharp.Authenticators;
using System.IO;
using System.Globalization;

public partial class LFR_Paypal : System.Web.UI.Page
{

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string VideoID = "nQJACVmankY";
            //LabelShowYouTubeVideo.Text = "<object width='425' height='355'><param name='movie' value='http://www.youtube.com/v/" + VideoID + "'></param><param name='wmode' value='transparent'></param><embed src='http://www.youtube.com/v/" + VideoID + "' type='application/x-shockwave-flash' wmode='transparent' width='425' height='355'></embed></object>";
             


        }        
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string userCurrency = string.Empty;
        userCurrency = "$";

        //String vCallingPage = "http://happysamebooks.com/";
        
        String vBuyerName = txtcName.Text.Trim();
        String vBuyerEmail = txtcEmail.Text.Trim();
        String vBuyerMobile = txtcMobile.Text.Trim();
        String vDOB = txtDOB.Text.Trim();

        String vBusiness = String.Empty;
        String vMemberName = string.Empty;
        String vMobileID = String.Empty;
        String vWebsiteName = String.Empty;
        String veStoreID = String.Empty;
        String vCustomText = String.Empty;

        //String vTotalItems = "1";
        //String vTotalAmount = "5";
        //String vCurrency = "USD";

        vBusiness = "kodur_siva@yahoo.com";
        vMemberName = "KAI";
        vMobileID = "6591834183";
        vWebsiteName = "sui-book.com";
        veStoreID = "KAI";

        DateTime dt;
        bool valid = DateTime.TryParseExact(vDOB, "ddMMyyyy", null, DateTimeStyles.None, out dt);

        //int vClientId = 8036;
        long tmpCartID = objBALebook.ShoppingCart_PreInsert(7661, "LFR-" + vDOB, 1, 1);

        //if (valid)
        //{
        //    vCustomText = vClientId + "#" + tmpCartID + "#" + vTotalItems + "#" + vTotalAmount + "#" + vCurrency + "#" + veStoreID + "#" + vBusiness + "#" + vBuyerMobile;
        //    CommonFunctions.ProceedToPalBuyMerchant(vBusiness, vBuyerName, vBuyerMobile, vBuyerEmail, vTotalAmount, vCurrency, "LFR" + vDOB, tmpCartID.ToString(), vCustomText, vWebsiteName, vClientId.ToString(), vCallingPage);
        //}
        //else
        //{
        //    CommonFunctions.AlertMessage("Invalid Date. Please provide valid date with format DDMMYYYY");
        //}
        
    }
}