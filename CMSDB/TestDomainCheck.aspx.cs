using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;


public partial class TestDomainCheck : System.Web.UI.Page
{

    String TmpClientIpAddress = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        TmpClientIpAddress = Request.ServerVariables["LOCAL_ADDR"];
        Response.Write("Client IPAddress: " + TmpClientIpAddress); 
    }


    protected void btnDomainCheckNow_Click(object sender, EventArgs e)
    {

        string tmpDomain2check = txtOwnDmChoice1.Text;
        string tmpDomainExt = ddlExtension.SelectedValue;


        tmpDomain2check = tmpDomain2check + tmpDomainExt;

        string tmpNameCheapLink = string.Empty;
        lblDomainReq.Text = string.Empty;

        

       

        tmpNameCheapLink = "https://api.namecheap.com/xml.response?" +
                            "ApiUser=samvoon" +
                            "&ApiKey=a75db07a1e43441db02c920eebe43d41" +
                            "&UserName=samvoon" +
                            "&Command=namecheap.domains.check" +
                            //"&ClientIp=" + TmpClientIpAddress +
                            "&ClientIp=210.5.45.8" +
                            
                            //"&ClientIp=118.100.36.111" +
            //"&ClientIp=98.130.0.139" +
                            "&DomainList=" + tmpDomain2check;
        //98.130.102.54 
        //118.100.36.111
        Uri tmpUri = new Uri(tmpNameCheapLink);

        #region // Sending Request for Domain Name availability to NameCheap.com

        //ASCIIEncoding encoding = new ASCIIEncoding();
        //string postData = "ApiUser=samvoon";
        //postData += ("&ApiKey=a75db07a1e43441db02c920eebe43d41");
        //postData += ("&UserName=samvoon");
        //postData += ("&Command=namecheap.domains.check");
        ////postData += ("&ClientIp=192.168.1.4" + Request.UserHostAddress);
        //postData += ("&ClientIp=122.174.136.47");
        //postData += ("&DomainList=" + tmpDomain2check);
        //byte[] data = encoding.GetBytes(postData);


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
                            if (readXml.Value == "false")
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
                //btnRegister.Visible = true;
            }
            else
            {
                lblDomainReq.Text = "Domain Name is NOT available. Please choose again.";
                //lblDomainReq.Text = "val :" + result;
                lblDomainReq.CssClass = "font_12Msg_Error";
               // btnRegister.Visible = false;
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
}
