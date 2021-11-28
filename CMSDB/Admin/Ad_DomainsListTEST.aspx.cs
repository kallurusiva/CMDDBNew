using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using System.Web.Mail;
using System.Net.Mail;
using System.Net;
using System.Xml;
using System.IO;
using System.Text;



public partial class Ad_DomainsListTEST : BasePage 
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    string strSQL = string.Empty;
    



    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        #region // rendering language resources
        
        #endregion

        if (Request.QueryString["DmRequest"] == "YES")
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Thank you for registering your domain. We will notify you once you domain name request is authenticated.";
            lblErrMessage.CssClass = "font_12Msg_Success";
        }

        if(!IsPostBack)
        {

            LoadDomainDetails();
        }


    }




    protected void LoadDomainDetails()
    {

       

        try
        {
            dbConn.Open();
            strSQL = "EXEC [usp_Retreive_DomainDetails] " + Convert.ToInt32(Session["UserID"]);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {

                    string tmpDomainType = dbReader["UserDomainType"].ToString();
                    string tmpSubDomainLink = dbReader["SubDomain"].ToString() + "." + GlobalVar.GetAnchorDomainName;
                    

                    if (tmpDomainType == "WEB10")
                    {
                        lblSubDomain.Text = dbReader["SubDomain"].ToString();
                        lblSubDomainLink.Text = "<a target='_blank' href='" + tmpSubDomainLink + "'>" + tmpSubDomainLink + "</a>";

                        trWEB10Section.Visible = true;
                        trWEB30Section.Visible = false;

                    }
                    else
                    {

                        lblSubDomain.Text = dbReader["SubDomain"].ToString();
                        lblSubDomainLink.Text = "<a target='_blank' href='" + tmpSubDomainLink + "'>" + tmpSubDomainLink +  "</a>";

                        string tmpRegisteredStatus = dbReader["RegisteredStatus"].ToString();
                        string tmpDomainRegNotice = string.Empty;

                        if (tmpRegisteredStatus == "")
                        {
                            trWEB30_DomainRegistered.Visible = false;
                            trWEB30Section.Visible = true;

                        }
                        else if (tmpRegisteredStatus.ToLower() == "0")
                        {

                            if (dbReader["DomainName"].ToString() != "")
                            {
                                //if (tmpRegisteredStatus == "True")
                                //    ltrDomainRegStatus.Text = " has been registered on " + Convert.ToDateTime(dbReader["RegisteredDate"].ToString()).ToLongDateString();
                                //else
                                    ltrDomainRegStatus.Text = " is pending for authorization.";
                            }

                            trWEB30_DomainRegistered.Visible = true;
                            trWEB30Section.Visible = false;

                        }

                        else if (tmpRegisteredStatus.ToLower() == "2")
                        {

                            if (dbReader["DomainName"].ToString() != "")
                            {
                                //if (tmpRegisteredStatus == "True")
                                //    ltrDomainRegStatus.Text = " has been registered on " + Convert.ToDateTime(dbReader["RegisteredDate"].ToString()).ToLongDateString();
                                //else
                                ltrDomainRegStatus.Text = " domain name failed to register.  The reason could be domain name already exists. Please try another domain name.";
                            }

                            trWEB30_DomainRegistered.Visible = true;
                            trWEB30Section.Visible = true;

                        }

                        else
                        {

                            if ((dbReader["DomainName"].ToString() != "") && (dbReader["RegisteredDate"].ToString() != ""))
                            {
                               
                                ltrDomainRegStatus.Text = " has been registered on " + Convert.ToDateTime(dbReader["RegisteredDate"].ToString()).ToLongDateString();
                                //else
                                //ltrDomainRegStatus.Text = " is pending for authorization.";
                            }

                            trWEB30_DomainRegistered.Visible = true;
                            trWEB30Section.Visible = false;
                        }

                        


                        
                        lblDomainName.Text = "<u>" + dbReader["DomainName"].ToString() + "</u>"; 

                        trWEB10Section.Visible = false;
                        

                    }

                }

            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }



    }


    //protected void btnSave_Click(object sender, EventArgs e)
    //{

    //    //get the entere values. 

    //    string mCurrentPassword = txtCurrentPassword.Text;
    //    string newPassword = txtNewPassword.Text;
    //    //[usp_Password_Update_ByUserID] userid, currentPassword, NewPassword 
    //    strSQL = "EXEC [usp_Password_Update_ByUserID] " + Convert.ToInt32(Session["UserID"]) + ",'" + mCurrentPassword + "','" +
    //                    newPassword + "'";

    //    int rowCount = 0;
        
    //    try
    //    {
    //        dbConn.Open();
           
    //        dbCmd = new SqlCommand(strSQL, dbConn);
    //        rowCount = dbCmd.ExecuteNonQuery();

           
    //   if (rowCount >= 1)
    //    {
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Sucess.gif";
    //        lblErrMessage.Text = "Password changed successfully. Your next login would be with new password.";
    //        lblErrMessage.CssClass = "font_12Msg_Success";

            

    //    }
    //    else
    //    {
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";
    //        lblErrMessage.Text = "Unable to complete the operation. Please contant Administrator";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //    }



    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        dbConn.Close();
    //    }




    //    if (rowCount >= 1)
    //    {
    //    LoadPassword();
    //    txtNewPassword.Text = "";
    //    txtRetypePassword.Text = "";
    //    }




    //}

    protected void btnDomainCheckNow_Click(object sender, EventArgs e)
    {
        string tmpDomain2check = txtOwnDmChoice1.Text;

        string tmpNameCheapLink = string.Empty;
        lblDomainReq.Text = string.Empty;

        tmpNameCheapLink = "https://api.namecheap.com/xml.response?" +
                            "ApiUser=samvoon" +
                            "&ApiKey=a75db07a1e43441db02c920eebe43d41" +
                            "&UserName=samvoon" +
                            "&Command=namecheap.domains.check" +
                            "&ClientIp=98.130.0.139" +
                            //"&ClientIp=" + Request.UserHostAddress +
                            "&DomainList=" + tmpDomain2check;
        //98.130.102.54 
        //118.100.36.111
        Uri tmpUri = new Uri(tmpNameCheapLink);

        #region // Sending Request for Domain Name availability to NameCheap.com 

        ASCIIEncoding encoding = new ASCIIEncoding();
        string postData = "ApiUser=samvoon";
        postData += ("&ApiKey=a75db07a1e43441db02c920eebe43d41");
        postData += ("&UserName=samvoon");
        postData += ("&Command=namecheap.domains.check");
        //postData += ("&ClientIp=192.168.1.4" + Request.UserHostAddress);
        postData += ("&ClientIp=122.174.136.47");
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

        tmplabel.Text = tmpUri.ToString();

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
                btnRegister.Visible = true;
            }
            else
            {
                lblDomainReq.Text = "Domain Name is NOT available";
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

        CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

        bool upStatus = objBAL_CommonFunc.Update_DomainNameRegistration(txtOwnDmChoice1.Text, Convert.ToInt32(Session["UserID"]));

       if (upStatus)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Thank you for registering your domain. We will notify you once you domain name request is authenticated.";
            lblErrMessage.CssClass = "font_12Msg_Success";

            trWEB30Section.Visible = false;
            trWEB30_DomainRegistered.Visible = true;
            ltrDomainRegStatus.Text = "";


           //Send Email -- informing user of the domain request. 
            SendEmail_DomainRequestPending();

        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Domain name request could be processed. Due to a technical error. Please contant Administrator";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }

       CommonFunctions.AlertMessage("Domain Name Request has been submitted to the Technicla team.");
       Response.Redirect("Ad_DomainsList.aspx?DmRequest=YES");
        

    }

    protected void SendEmail_DomainRequestPending()
    {

        //Get Admin Email Address and Name.
        string mFullName = string.Empty;
        string mEmailAddress = string.Empty;
        string mEmailSubject = "Domain Name Registration - " + GlobalVar.GetAnchorDomainName;
        string mEmailFrom = "SupportTeam@" + GlobalVar.GetAnchorDomainName ; 
        string mEmailBody = "We have received your request for new Domain Name registration.<br/><br/> " +
                            "Your request has been assigned to our technical team. Please note that domain <br/>" +
                            "registration may take <b>up to 3 working days</b> to be processed.<br/><br/>" +
                            "You will be notified via email once the process is completed.";
                     
                            

        try
        {
            dbConn.Open();
            strSQL = "EXEC [usp_Retreive_EmailDetails_ByUserID] " + Convert.ToInt32(Session["UserID"]);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    mFullName = dbReader["FullName"].ToString();
                    mEmailAddress = dbReader["Email"].ToString();
                }

            }

            CommonFunctions.GenericSendEmail(mEmailAddress, mEmailFrom, mEmailBody, mEmailSubject, mFullName, "", "");

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }



    }

}
