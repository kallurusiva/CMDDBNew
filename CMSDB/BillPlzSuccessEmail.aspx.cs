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
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;

public partial class BillPlzSuccessEmail : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    //DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Server.ScriptTimeout = 600;

        string BillID = Request.QueryString["billid"].ToString();

        CMSv3.BAL.PayPal objPayPal = new CMSv3.BAL.PayPal();
        newDBS objDBS = new newDBS();
        ds = objDBS.BillPlz_getEmailDetails(BillID.ToString());
        DataTable dtTx = ds.Tables[0];

        if (dtTx.Rows.Count > 0)
        {
            DataRow Drow = dtTx.Rows[0];

            String vUserName = Drow["UserName"].ToString();
            String vMobileNo = Drow["MobileNo"].ToString();
            String vBuyerEmail = Drow["BuyerEmail"].ToString();
            String vBookID = Drow["ItemName"].ToString();
            string vUserId1 = Drow["UserId"].ToString();
            string vTranID = Drow["UID"].ToString();
            string bPassword = Drow["bookpassword"].ToString();

            //string bPassword = vMobileNo + vUserName;
            //bPassword = bPassword.Replace(" ", "");
            //if (bPassword.Length > 19) { bPassword = bPassword.Substring(0, 20).ToLower(); }

            string QKeyword = string.Empty;
            DataSet ds3 = objBALebook.Ebook_KeywordDetails_ByUserID(Convert.ToInt32(vUserId1));
            if (ds3.Tables[0].Rows.Count > 0)
            {
                DataRow krow = ds3.Tables[0].Rows[0];
                QKeyword = krow["VendorCode"].ToString();
            }

            objDBS.SMSEbook_getDetails(vTranID.ToString(), "2");
            MgMail.sndMailgunLinks(vTranID.ToString(), "2", vBuyerEmail.ToString());            
            //EBookEmailCentral.getTransactionDetails(vBuyerEmail, "", QKeyword, "", "", vBookID, bPassword);
        }
    }
}