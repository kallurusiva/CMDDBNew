using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
//using System.Web.Mail;
using System.Net.Mail;
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;




public partial class Ad_DomainsList : BasePage 
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;


    SqlConnection IFM32_dbConn;
    SqlCommand IFM32_dbCmd;
    SqlDataReader IFM32_dbReader;


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
        IFM32_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);

        #region // rendering language resources
        
        #endregion


        //if (Session["UserDomainType"] != null)
        //{
        //    string tmpUserType = Session["UserDomainType"].ToString();

        //    if (tmpUserType == "EBOOK")
        //    {
        //        ContentPlaceHolder cphLeftMenu = (ContentPlaceHolder)Page.Master.FindControl("ContentLeftMenu");
        //        UserControl ucSteps = (UserControl)Page.LoadControl("~/Admin/EBLeftMenu_RegSTEPS.ascx");
        //        cphLeftMenu.Controls.Clear();
        //        cphLeftMenu.Controls.Add(ucSteps); 
        //    }
        //}


        ////..getting users ipaddress. 
        ////Response.Write(Request.ServerVariables["REMOTE_ADDR"]);
        //string tmpIpAdr = Request.ServerVariables["REMOTE_ADDR"];
        //HtmlInputHidden objHdIpadr = (HtmlInputHidden)Page.FindControl("hdIpAddress");
        //if (objHdIpadr != null)
        //    objHdIpadr.Value = tmpIpAdr;


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



        String tmpUserMobileNo = string.Empty;
        String tmpUserAccountType = string.Empty;
        String isBizLicenseExpired = string.Empty;


       

        try
        {
            //.. get the Current User Mobile No 

            dbConn.Open();
            strSQL = "EXEC [usp_User_Get_UserContactDetails] " + Convert.ToInt32(Session["UserID"]);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();


            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    //.... Handphone is reffered to mobileloginID... 
                    tmpUserMobileNo = dbReader["Handphone"].ToString(); 
                }
            }

            dbConn.Close();
            dbReader.Close();
            

            IFM32_dbConn.Open();
            strSQL = "EXEC [USP_Domain_ValidateOwnDomainEligibility] " + tmpUserMobileNo;

            IFM32_dbCmd = new SqlCommand(strSQL, IFM32_dbConn);
            IFM32_dbReader = IFM32_dbCmd.ExecuteReader();

            if (IFM32_dbReader.HasRows)
            {
                while (IFM32_dbReader.Read())
                {
                    tmpUserAccountType = IFM32_dbReader["AccountType"].ToString().Trim();
                    isBizLicenseExpired = IFM32_dbReader["LicenseExpirydate"].ToString().Trim(); 
                }
            }

            IFM32_dbConn.Close();
            IFM32_dbReader.Close(); 
            



            dbConn.Open();
            strSQL = "EXEC [usp_Retreive_DomainDetails] " + Convert.ToInt32(Session["UserID"]);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {

                    string tmpDomainType = dbReader["UserDomainType"].ToString().Trim();
                    string tmpSubDomainLink = dbReader["SubDomain"].ToString() + "." + GlobalVar.GetAnchorDomainName;
                    

                    if (tmpDomainType == "WEB10")
                    {
                        //lblSubDomain.Text = dbReader["SubDomain"].ToString();
                        //lblSubDomainLink.Text = "<a target='_blank' href='" + "http://" + tmpSubDomainLink + "'>" + tmpSubDomainLink + "</a>";

                        trWEB10Section.Visible = true;
                        trWEB30Section.Visible = false;

                    }
                    else if (isBizLicenseExpired == "EXPIRED")
                    {
                        lblExpiry.Text = " Your Business License has expired. Please renew your License to register Own domain.";
                        trWEB30_DomainRegistered.Visible = true;
                        trWEB30Section.Visible = false;
                        trWEB10Section.Visible = false;
                    }
                    else
                    {
                        //,,Check if DomainType is WEB30 or PLATINUM 

                       
                        //lblSubDomain.Text = dbReader["SubDomain"].ToString();
                        //lblSubDomainLink.Text = "<a target='_blank' href='" + "http://" + tmpSubDomainLink + "'>" + tmpSubDomainLink + "</a>";

                        string tmpRegisteredStatus = dbReader["RegisteredStatus"].ToString();
                        string tmpDomainRegNotice = string.Empty;

                        lblDomainName.Text = "<u>" + dbReader["DomainName"].ToString() + "</u>";

                        trWEB10Section.Visible = false;


                       // if ((tmpDomainType == "WEB30") || (tmpDomainType == "PLATINUM"))   //PLATINUM ,  DIAMOND
                        if ((tmpDomainType == "WEB30") || (tmpDomainType == "SME") || (tmpUserAccountType == "PLATINUM") || (tmpUserAccountType == "TITANIUM") || (tmpUserAccountType == "GOLD"))   //PLATINUM ,  DIAMOND
                        {

                            if ((tmpRegisteredStatus == "") || (tmpRegisteredStatus == null))
                            {
                                trWEB30Section.Visible = true;
                            }
                            else if (tmpRegisteredStatus == "0")
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
                            else if (tmpRegisteredStatus == "2")
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


                        }
                       
                        else
                        {

                            trWEB10Section.Visible = true;
                            trWEB30Section.Visible = false;
                        }



                        ////.. if the User is NOT registered and not from 1Malaysia
                        //if ((tmpRegisteredStatus == "") && (tmpUserAccountType.ToUpper() == "NONE")) 
                        //{
                        //    trWEB30_DomainRegistered.Visible = false;
                        //    trWEB30Section.Visible = true;

                        //}
                        //else  if ((tmpRegisteredStatus == "") && (tmpUserAccountType.ToUpper() == "PLATINUM")){

                        //    trWEB30_DomainRegistered.Visible = false;
                        //    trWEB30Section.Visible = true;
                        //}
                        //else if (tmpRegisteredStatus.ToLower() == "0")
                        //{

                        //    if (dbReader["DomainName"].ToString() != "")
                        //    {
                        //        //if (tmpRegisteredStatus == "True")
                        //        //    ltrDomainRegStatus.Text = " has been registered on " + Convert.ToDateTime(dbReader["RegisteredDate"].ToString()).ToLongDateString();
                        //        //else
                        //            ltrDomainRegStatus.Text = " is pending for authorization.";
                        //    }

                        //    trWEB30_DomainRegistered.Visible = true;
                        //    trWEB30Section.Visible = false;

                        //}

                        //else if (tmpRegisteredStatus.ToLower() == "2")
                        //{

                        //    if (dbReader["DomainName"].ToString() != "")
                        //    {
                        //        //if (tmpRegisteredStatus == "True")
                        //        //    ltrDomainRegStatus.Text = " has been registered on " + Convert.ToDateTime(dbReader["RegisteredDate"].ToString()).ToLongDateString();
                        //        //else
                        //        ltrDomainRegStatus.Text = " domain name failed to register.  The reason could be domain name already exists. Please try another domain name.";
                        //    }

                        //    trWEB30_DomainRegistered.Visible = true;
                        //    trWEB30Section.Visible = true;

                        //}

                        //else
                        //{

                        //    if ((dbReader["DomainName"].ToString() != "") && (dbReader["RegisteredDate"].ToString() != ""))
                        //    {
                               
                        //        ltrDomainRegStatus.Text = " has been registered on " + Convert.ToDateTime(dbReader["RegisteredDate"].ToString()).ToLongDateString();
                        //        //else
                        //        //ltrDomainRegStatus.Text = " is pending for authorization.";
                        //    }

                        //    trWEB30_DomainRegistered.Visible = true;
                        //    trWEB30Section.Visible = false;
                        //}

                        


                        
                        
                        

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
        string tmpDomainExt = ddlExtension.SelectedValue;


        tmpDomain2check = tmpDomain2check + tmpDomainExt;

        string tmpNameCheapLink = string.Empty;
        lblDomainReq.Text = string.Empty;

        tmpNameCheapLink = "https://api.namecheap.com/xml.response?" +
                            "ApIUser=samvoon" +
                            "&ApiKey=a75db07a1e43441db02c920eebe43d41" +
                            "&UserName=samvoon" +
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
        string postData = "ApIUser=samvoon";
        postData += ("&ApiKey=a75db07a1e43441db02c920eebe43d41");
        postData += ("&UserName=samvoon");
        postData += ("&Command=namecheap.domains.check");
        //postData += ("&ClientIp=192.168.1.4" + Request.UserHostAddress);
        postData += ("&ClientIp=14.102.146.116");
        //postData += ("&ClientIp=210.5.45.8");
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

        CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();

        string tmpDomainNameExt = txtOwnDmChoice1.Text + ddlExtension.SelectedValue;

        //commented for testing the AutoDomain
        bool upStatus = objBAL_CommonFunc.Update_DomainNameRegistration(tmpDomainNameExt, Convert.ToInt32(Session["UserID"]));


       // bool DomainReg_Status = fn_AutoDomainNameRegistration(tmpDomainNameExt);
      //  bool upStatus = fn_AutoDomainNameRegistration(tmpDomainNameExt);


       if (upStatus)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Thank you for registering your domain. We will notify you once you domain name request is authenticated.";
            lblErrMessage.CssClass = "font_12Msg_Success";

            trWEB30Section.Visible = false;
            trWEB30_DomainRegistered.Visible = true;
            ltrDomainRegStatus.Text = "";


           //Send Email -- informing user of the Domain Request. 
            //commented for testing the AutoDomain
           SendEmail_DomainRequestPending();


        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Domain name request could be processed. Due to a technical error. Please contant Administrator";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }

       CommonFunctions.AlertMessage("Domain Name Request has been submitted to the Technical team.");
       Response.Redirect("Ad_DomainsList.aspx?DmRequest=YES");
        

    }


    public Boolean fn_AutoDomainNameRegistration(string vDomainName)
    {


        string strSQL = "Select DomainName,Years,PromotionCode,RegistrantOrganizationName,RegistrantJobTitle,RegistrantFirstName,RegistrantLastName,RegistrantAddress1,RegistrantAddress2,RegistrantCity,RegistrantStateProvince,RegistrantStateProvinceChoice,RegistrantPostalCode,RegistrantCountry,RegistrantPhone,RegistrantPhoneExt,RegistrantFax,RegistrantEmailAddress,TechOrganizationName,TechJobTitle,TechFirstName,TechLastName,TechAddress1,TechAddress2,TechCity,TechStateProvince,TechStateProvinceChoice,TechPostalCode,TechCountry,TechPhone,TechPhoneExt,TechFax,TechEmailAddress,AdminOrganizationName,AdminJobTitle,AdminFirstName,AdminLastName,AdminAddress1,AdminAddress2,AdminCity,AdminStateProvince,AdminStateProvinceChoice,AdminPostalCode,AdminCountry,AdminPhone,AdminPhoneExt,AdminFax,AdminEmailAddress,AuxBillingOrganizationName,AuxBillingJobTitle,AuxBillingFirstName,AuxBillingLastName,AuxBillingAddress1,AuxBillingAddress2,AuxBillingCity,AuxBillingStateProvince,AuxBillingStateProvinceChoice,AuxBillingPostalCode,AuxBillingCountry,AuxBillingPhone,AuxBillingPhoneExt,AuxBillingFax,AuxBillingEmailAddress,BillingFirstName,BillingLastName,BillingAddress1,BillingAddress2,BillingCity,BillingStateProvince,BillingStateProvinceChoice,BillingPostalCode,BillingCountry,BillingPhone,BillingPhoneExt,BillingFax,BillingEmailAddress,Nameservers,Nameservers2,AddFreeWhoisguard,WGEnabled,AddFreePositiveSSL from tblDomainParams";

        string strURL = string.Empty;
        ArrayList rowList = new ArrayList();

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);


        try
        {
            dbConn.Open();

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if(dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    //strURL = dbReader["DomainName"].ToString();
                    object[] values = new object[dbReader.FieldCount];
                    dbReader.GetValues(values);
                    rowList.Add(values);

                    int fcount = dbReader.FieldCount;

                    for (int i = 0; i < fcount; i++)
                    {

                        if (dbReader.GetName(i).Contains("Nameservers"))
                        {
                            strURL = strURL + dbReader.GetName(i) + "=" + dbReader.GetValue(i) + "," + dbReader.GetValue(i+1) + "&";
                            i++;
                        }
                        else
                        {
                            strURL = strURL + dbReader.GetName(i) + "=" + dbReader.GetValue(i) + "&";
                        }
                    }

                } 
            }

            //Response.Write("<br/>" + strURL);
            lblTest.Text = strURL;


        string strURL_NameCheap = string.Empty;

        strURL_NameCheap = "https://api.sandbox.namecheap.com/xml.response?" +
                            "ApiUser=globalsurf" +
                            "&ApiKey=818dd87bceb74555914d6ebd3f1bc962" +
                            "&UserName=globalsurf" +
                            "&Command=namecheap.domains.create" +
                            "&ClientIp=118.100.36.111" + "&" + strURL;

                            



   Uri tmpUri = new Uri(strURL_NameCheap);

        #region // Sending Request for Domain Name availability to NameCheap.com 

        //ASCIIEncoding encoding = new ASCIIEncoding();
        //string postData = "ApIUser=samvoon";
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

                Console.WriteLine("{0}: {1}", readXml.NodeType.ToString(), readXml.Name);
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
                lblDomainReq.Text = "Domain Name is NOT available. Please choose again.";
                //lblDomainReq.Text = "val :" + result;
                lblDomainReq.CssClass = "font_12Msg_Error";
                btnRegister.Visible = false;
            }


         


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
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }





        return true;
    }

    protected void SendEmail_DomainRequestPending()
    {

        //Get Admin Email Address and Name.
        string mFullName = string.Empty;
        string mEmailAddress = string.Empty;
        string mUserWebDomainName = string.Empty;
        string mEmailSubject = "Domain Name Registration - " + GlobalVar.GetAnchorDomainName;
        string mEmailFrom = "SupportTeam@" + GlobalVar.GetAnchorDomainName ; 
        string mEmailBody = "We have received your request for new Domain Name registration.<br/><br/> " +
                            "Your request has been assigned to our technical team. Please note that domain <br/>" +
                            "registration may take <b>up to 5 working days</b> to be processed.<br/><br/>" +
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
                    mUserWebDomainName = dbReader["WebSiteName"].ToString();
                }

            }

            CommonFunctions.GenericSendEmail(mEmailAddress, mEmailFrom, mEmailBody, mEmailSubject, mFullName, "", "");



            //Send Email to SuperAdmin / Administrator informing the new Domain Name Registration Approval. 

            mEmailBody = "Received a request for new Domain Name registration.<br/><br/> " +
                         "Requested By :<br/>" +
                         "-------------------------------------<br/>" +
                         "FullName : <b>" + mFullName + "</b><br/>" +
                         "-------------------------------------<br/>" +
                         "<br/>";

            mEmailAddress = GlobalVar.GetEmailRecipientList1;
            CommonFunctions.GenericSendEmail(mEmailAddress, mEmailFrom, mEmailBody, mEmailSubject, mFullName, "", "");


            mEmailAddress = GlobalVar.GetEmailRecipientList2;
            CommonFunctions.GenericSendEmail(mEmailAddress, mEmailFrom, mEmailBody, mEmailSubject, mFullName, "", "");


            string mSmsRecipients = GlobalVar.GetSMSRecipientList;
            string mSmsMessage = Environment.NewLine + "A new Domain Name Registration Request has been raised from " + Environment.NewLine + mUserWebDomainName + ".";

            CommonFunctions.MySendSMS(mSmsMessage,mSmsRecipients,GlobalVar.GetAnchorDomainName);


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


    //protected void sendsms_Click(object sender, EventArgs e)
    //{

    //    string mSmsRecipients = GlobalVar.GetSMSRecipientList;
    //    string mSmsMessage = "A new Domain Name Registration Request has been raised from " + Environment.NewLine  + GlobalVar.GetAnchorDomainName + ".";

    //    CommonFunctions.MySendSMS(mSmsMessage, mSmsRecipients, GlobalVar.GetAnchorDomainName);

    //}
}
