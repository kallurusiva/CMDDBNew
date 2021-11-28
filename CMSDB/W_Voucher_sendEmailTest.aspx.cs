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
using AjaxControlToolkit.HTMLEditor;
using System.IO;
using FredCK.FCKeditorV2;
using RestSharp;
using RestSharp.Authenticators;

public partial class wassap_W_Voucher_sendEmailTest : System.Web.UI.Page
{
    DataSet ds;
    DataSet dst;

    string emailCount = string.Empty;
    string unitcharge = string.Empty;
    string totalCharge = string.Empty;
    string LID = string.Empty;

    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireWMDP.aspx");
        }
        #endregion

        LID = Request.QueryString["LID"].ToString();
        if (!IsPostBack)
        {
            ViewState["LID"] = LID;
            emailCount = "0.00";
            unitcharge = "0.00";
            totalCharge = "0.00";
            ViewState["emailCount"] = "0.00";
            ViewState["totalCharge"] = "0.00";
            ViewState["smsBalance"] = "0.00";

            TextBoxMobileList.Text = "";
            newDBS ndbs = new newDBS();
            dst = ndbs.Voucher_CreateList_BookCode_sendEMAIL_getList(Session["UserID"].ToString(), ViewState["LID"].ToString());
            if (dst.Tables[0].Rows.Count > 0)
            {
                DataRow utRow1 = dst.Tables[0].Rows[0];
                TextBoxMobileList.Text = utRow1["Txt"].ToString();
            }

            if (dst.Tables[1].Rows.Count > 0)
            {
                DataRow utRow2 = dst.Tables[1].Rows[0];
                emailCount = utRow2["emailCount"].ToString();
                unitcharge = utRow2["unitcharge"].ToString();
                ViewState["totalCharge"] = utRow2["totalCharge"].ToString();
                ViewState["emailCount"] = emailCount;

                LabelEmailcount.Text = emailCount.ToString();
                LabelUnitPrice.Text = unitcharge.ToString();
                LabelTotalCharges.Text = ViewState["totalCharge"].ToString();
            }

            ds = objMalaysia.Retrieve_AccountDetails(Session["MERID"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow utRow = ds.Tables[0].Rows[0];
                LabelSMSBalanceVal.Text = String.Format("{0:0.00}", utRow["BalanceCredit"]);
                ViewState["smsBalance"] = utRow["BalanceCredit"].ToString();
            }

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (TextBoxMobileList.Text.ToString() == "")
        {
            CommonFunctions.AlertMessage("No valid emails in the list.");
        }
        else if (TextBoxSubject.Text.ToString() == "")
        {
            CommonFunctions.AlertMessage("Please enter subject to send email.");
        }
        else if (myEditor.Value.ToString() == "")
        {
            CommonFunctions.AlertMessage("Please enter message to send email.");
        }
        else if (Convert.ToDecimal(ViewState["totalCharge"].ToString()) > Convert.ToDecimal(ViewState["smsBalance"].ToString()))
        {
            CommonFunctions.AlertMessage("InSufficient SMS Credit Balance. Please Topup to Proceed.");
        }
        else
        {
            newDBS ndbs1 = new newDBS();
            dst = ndbs1.bigdata_sendEmail(Session["MERID"].ToString(), ViewState["emailCount"].ToString(), "BigData-Voucher-Email", TextBoxSubject.Text.ToString(), myEditor.Value.ToString().Replace("/OtherUtils", "http://183.81.165.117/OtherUtils"), TextBoxMobileList.Text.ToString());

            String ImgFileUrl1 = "";
            String fileName = "";
            String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
            if (FU_Photo1.HasFile)
            {
                fileName = FU_Photo1.FileName;
                String FileExtension = System.IO.Path.GetExtension(FU_Photo1.FileName);
                ImgFileUrl1 = Server.MapPath("~") + "/DocumentRepository/";
                FU_Photo1.SaveAs(ImgFileUrl1 + fileName);
                FU_Photo1.Dispose();
            }

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "key-0ad485da45bb169cabfea074c9e87e2d");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "maildly.ebdvy.com", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Voucher Delivery <me@maildly.ebdvy.com>");
            request.AddParameter("to", "admin@evenchise.com");
            //request.AddParameter("bcc", TextBoxMobileList.Text.Replace(",", ":").ToString());
            request.AddParameter("to", TextBoxMobileList.Text.ToString());
            request.AddParameter("subject", TextBoxSubject.Text.ToString());
            //request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.AddParameter("html", myEditor.Value.ToString() + "<br><br>Click below to unsubscribe:<br><br>http://183.81.165.117/emailunsubscribe.aspx");

            if (ImgFileUrl1 != "")
            {
                if (File.Exists(Server.MapPath("/DocumentRepository/" + fileName)))
                {
                    request.AddFile("attachment", Path.Combine(HttpContext.Current.Server.MapPath("/DocumentRepository/"), fileName), "");
                }
            }
            request.Method = Method.POST;
            client.Execute(request);

            CommonFunctions.AlertMessageAndRedirect("Email sent successfully.", "W_Voucherdb.aspx");
        }
    }

}
