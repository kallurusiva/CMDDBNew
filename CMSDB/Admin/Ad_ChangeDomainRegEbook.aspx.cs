using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Configuration;

public partial class Admin_Ad_ChangeDomainRegEbook : BasePage
{
    SqlConnection dbConn;
    SqlConnection EBdbConn;
    SqlConnection IFM32_dbConn;
    string strSQL = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        String dbcString = ConfigurationManager.AppSettings["eBookDB"].ToString();

        EBdbConn = new SqlConnection(dbcString);
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        IFM32_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);
    }

    protected void btnDomainCheckNow_Click(object sender, EventArgs e)
    {
        string tmpDomain2check = txtOwnDmChoice1.Text;
        string tmpDomainExt = ddlExtension.SelectedValue;


        tmpDomain2check = tmpDomain2check + tmpDomainExt;

        string tmpNameCheapLink = string.Empty;
        lblDomainReq.Text = string.Empty;

        tmpNameCheapLink = "https://api.namecheap.com/xml.response?" +
                            "ApIUser=sivaprasadreddy" +
                            "&ApiKey=83193680ec934ee5b7b49ad8c0da828e" +
                            "&UserName=sivaprasadreddy" +
                            "&Command=namecheap.domains.check" +
                            "&ClientIp=14.102.146.116" +
            //"&ClientIp=118.100.36.111" +
            //"&ClientIp=98.130.0.139" +
                            "&DomainList=" + tmpDomain2check;
        //98.130.102.54 
        //118.100.36.111
        Uri tmpUri = new Uri(tmpNameCheapLink);

        #region // Sending Request for Domain Name availability to NameCheap.com

        ASCIIEncoding encoding = new ASCIIEncoding();
        string postData = "ApIUser=sivaprasadreddy";
        postData += ("&ApiKey=83193680ec934ee5b7b49ad8c0da828e");
        postData += ("&UserName=sivaprasadreddy");
        postData += ("&Command=namecheap.domains.check");
        //postData += ("&ClientIp=192.168.1.4" + Request.UserHostAddress);
        postData += ("&ClientIp=14.102.146.116");
        //postData += ("&ClientIp=122.174.136.47");
        postData += ("&DomainList=" + tmpDomain2check);
        byte[] data = encoding.GetBytes(postData);


        // Prepare web request...
        HttpWebRequest http_DomainNameCheckRequest = (HttpWebRequest)WebRequest.Create(tmpUri);
        http_DomainNameCheckRequest.Method = WebRequestMethods.Http.Get;
        // http_DomainNameCheckRequest.ContentType = "application/x-www-form-urlencoded";
        //http_DomainNameCheckRequest.ContentLength = data.Length;
        //Stream newStream = http_DomainNameCheckRequest.GetRequestStream();
        //// Send the data.
        //newStream.Write(data, 0, data.Length);
        //newStream.Close();

        //  tmplabel.Text = tmpUri.ToString();

        // *** Retrieve request info headers
        try
        {
            HttpWebResponse http_DomainCheckResponse = (HttpWebResponse)http_DomainNameCheckRequest.GetResponse();
            Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page
            StreamReader loResponseStream = new StreamReader(http_DomainCheckResponse.GetResponseStream(), enc);



            XmlReaderSettings readSettings = new XmlReaderSettings();
            readSettings.ConformanceLevel = ConformanceLevel.Fragment;
            readSettings.IgnoreWhitespace = true;
            readSettings.IgnoreComments = true;

            //XmlTextReader readXml = new XmlTextReader(loResponseStream,readSettings);
            XmlReader readXml = XmlReader.Create(loResponseStream, readSettings);

            string allXMLdata = string.Empty;

            string result = string.Empty;
            while (readXml.Read())
            {

                //Console.WriteLine("{0}: {1}", readXml.NodeType.ToString(), readXml.Name);
                // allXMLdata = allXMLdata + string.Format("{0} : {1}", readXml.NodeType.ToString(), readXml.Name) + "<br/>";
                //Process only the elements
                if (readXml.NodeType == XmlNodeType.Element)
                {

                    if (readXml.Name == "ApiResponse")
                    {
                        if (readXml.HasAttributes)
                        {
                            readXml.MoveToAttribute("Status");
                            if (readXml.Value != "OK")
                            {
                                result = readXml.Value;
                                // break;
                            }

                        }
                    }

                    if (readXml.Name == "Error")
                    {

                        if (readXml.HasAttributes)
                        {
                            readXml.MoveToAttribute("Number");
                            result = readXml.Value;
                            break;

                        }

                    }
                    if (readXml.Name == "DomainCheckResult")
                    {
                        if (readXml.HasAttributes)
                        {
                            readXml.MoveToAttribute("Available");
                            if (readXml.Value.ToLower() == "false")
                            {
                                result = readXml.Value;
                                break;
                            }
                            else
                            {
                                result = "TRUE";
                                break;
                            }
                        }

                    }

                }


            } //end of while 

            // lblDomainReq.Text = allXMLdata;

            if (result == "TRUE")
            {
                lblDomainReq.Text = "Domain Name is available";
                lblDomainReq.CssClass = "font_12Msg_Success";
                btnRegister.Visible = true;
                txtOwnDmChoice1.Enabled = false;
            }
            else
            {
                lblDomainReq.Text = "Domain Name is NOT available. Please choose again.";
                //lblDomainReq.Text = "val :" + result;
                lblDomainReq.CssClass = "font_12Msg_Error";
                btnRegister.Visible = false;
            }


            //HttpWebResponse http_DomainCheckResponse2 = (HttpWebResponse)http_DomainNameCheckRequest.GetResponse();
            //Encoding enc2 = Encoding.GetEncoding(1252);  // Windows default Code Page
            //StreamReader AC_ResponseStream = new StreamReader(http_DomainCheckResponse2.GetResponseStream(), enc2);
            //string Html_AC_PinResponse = AC_ResponseStream.ReadToEnd();

            //lblDomainReq2.Text = Html_AC_PinResponse;
            //http_DomainCheckResponse2.Close();
            //AC_ResponseStream.Close();



        }
        catch (WebException wbEx)
        {
            if (wbEx.Status == WebExceptionStatus.Timeout)
                lblDomainReq.Text = "Domain Name check failed due to TimeOut Error. This could happen due to Slow Internet Speed. Please try again.";
        }
        catch (Exception ex)
        {

            throw ex;
        }



        //string Html_DomainNameCheckResponse = loResponseStream.ReadToEnd();


        //Response.Write(Html_DomainNameCheckResponse);
        //lblResult.Text = Html_DomainNameCheckResponse;




        //readXml.Read();


        #endregion

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (Regex.IsMatch(txtOwnDmChoice1.Text.ToString(), @"^[a-zA-Z0-9\-]+$"))
        {
            RegisterDomain();
        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Invalid Domain Name Request. Only [Aa-Zz] Alphabhets, [0-9] numerals and  [ - ] hyphen is allowed.";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }
    }

    protected void RegisterDomain()
    {
        newDBS objPS = new newDBS();
        string tmpDomainNameExt = txtOwnDmChoice1.Text + ddlExtension.SelectedValue;
        DataSet ds;
        string upStatus = "";
        string msg = "";
        ds = objPS.ebook_RequestDomainChange(tmpDomainNameExt, Session["UserID"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            upStatus = ds.Tables[0].Rows[0]["upStatus"].ToString();
            msg = ds.Tables[0].Rows[0]["msg"].ToString();
        }

        if (upStatus.ToString() == "1")
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Thank you for registering your domain. We will notify you once you domain name request is authenticated.";
            lblErrMessage.CssClass = "font_12Msg_Success";

            trWEB30Section.Visible = false;
            trWEB30_DomainRegistered.Visible = true;
            ltrDomainRegStatus.Text = "";


            HttpWebRequest WebReq = null;
            HttpWebResponse WebResp;

            String strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=306615026&message=" + Server.UrlEncode("Change Domain request by " + Session["LoginID"].ToString() + " for " + tmpDomainNameExt.ToString());

            WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);

            //WebReq.ClientCertificates.Add(Cert);
            WebReq.Method = "GET";
            WebResp = (HttpWebResponse)WebReq.GetResponse();
            if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
            {
                Stream _Answer = WebResp.GetResponseStream();
                StreamReader Answer = new StreamReader(_Answer);
                String strTemp = Answer.ReadToEnd();
            }

            //strSMSvalue = "https://api.telegram.org/bot364356589:AAGhOab_5vuTD__0l-fGRxMEX-9c__ZFHFc/sendmessage?chat_id=49061723&text=Domain request by " + Session["LoginID"].ToString() + " for " + tmpDomainNameExt.ToString();
            strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=49061723&message=" + Server.UrlEncode("Change Domain request by " + Session["LoginID"].ToString() + " for " + tmpDomainNameExt.ToString());

            WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);

            //WebReq.ClientCertificates.Add(Cert);
            WebReq.Method = "GET";
            WebResp = (HttpWebResponse)WebReq.GetResponse();
            if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
            {
                Stream _Answer = WebResp.GetResponseStream();
                StreamReader Answer = new StreamReader(_Answer);
                String strTemp = Answer.ReadToEnd();
            }
            Response.Redirect("Ad_ChangeDomainRegEbookMsg.aspx?t=1");
        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = msg.ToString();
            lblErrMessage.CssClass = "font_12Msg_Error";

            Response.Redirect("Ad_ChangeDomainRegEbookMsg.aspx?t=2");
        }

        CommonFunctions.AlertMessage("Domain Name Request has been submitted to the Technical team.");
        Response.Redirect("Ad_ChangeDomainRegEbook.aspx");
    }

}
