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

public partial class Admin_SMS_EbAd_CreateList_email : System.Web.UI.Page
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
            Response.Redirect("~/SessionExpire.aspx");
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

            TextBoxMobileList.Text = "";
            newDBS ndbs = new newDBS();
            dst = ndbs.Ebook_CreateList_sendEmail_getList(Session["MERID"].ToString(), ViewState["LID"].ToString());
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
                totalCharge = utRow2["totalCharge"].ToString();
                ViewState["emailCount"] = emailCount;

                LabelEmailcount.Text = emailCount.ToString();
                LabelUnitPrice.Text = unitcharge.ToString();
                LabelTotalCharges.Text = totalCharge.ToString();
            }

            ds = objMalaysia.Retrieve_AccountDetails(Session["MERID"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow utRow = ds.Tables[0].Rows[0];
                LabelSMSBalanceVal.Text = String.Format("{0:0.00}", utRow["BalanceCredit"]);
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
        else
        {

            String ImgFileUrl1 = "";
            String fileName = "";
            String tmpEbfileFolder = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
            if (FU_Photo1.HasFile)
            {
                //if (FU_Photo1.FileBytes.Length < 11145728)
                //{
                    //Get the name of the file
                    fileName = FU_Photo1.FileName;
                    
                    String FileExtension = System.IO.Path.GetExtension(FU_Photo1.FileName);

                    //instead of server.mapPath set the path in web.config file and use that path.
                    ImgFileUrl1 = Server.MapPath("~") + "/DocumentRepository/";
                    
                    FU_Photo1.SaveAs(ImgFileUrl1 + fileName);
                    FU_Photo1.Dispose();
                //}
            }
            
            SmtpClient smtpClient = new SmtpClient();
            MailMessage objMessage = new MailMessage();
            string m_fromName = string.Empty;
            try
            {
                m_fromName = "EBookAdmin";
                MailAddress m_fromAddress = new MailAddress("noreply@ebooksmsdelivery.com", m_fromName);
                smtpClient.Host = "localhost";
                smtpClient.Port = 25;
                objMessage.From = m_fromAddress;

                //objMessage.To.Add(TextBoxMobileList.Text.ToString());
                objMessage.Subject = TextBoxSubject.Text.ToString();

                objMessage.Bcc.Add(TextBoxMobileList.Text.ToString());

                objMessage.IsBodyHtml = true;
                if (ImgFileUrl1 != "")
                {
                    if (File.Exists(Server.MapPath("/DocumentRepository/" + fileName)))
                    {
                        Attachment objAtt1 = new Attachment(Server.MapPath("/DocumentRepository/" + fileName));
                        objMessage.Attachments.Add(objAtt1);
                    }
                }
                objMessage.Body = myEditor.Value.ToString();

                NetworkCredential authinfo = new NetworkCredential("help@evenchise.com", "gsurf123");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = authinfo;
                smtpClient.Send(objMessage);

                newDBS ndbs1 = new newDBS();
                DataSet dst1 = ndbs1.Insert_SEKEmailInfo(Session["MERID"].ToString(), "EB-CList", "1", "0", ViewState["emailCount"].ToString(), "0", "EBOOK LIST EMAIL", TextBoxSubject.Text, myEditor.Value, fileName.ToString(), TextBoxMobileList.Text.ToString());
                CommonFunctions.AlertMessage("Email Sent.");
                
            }
            catch
            {
            }

        }
    }
    
}
