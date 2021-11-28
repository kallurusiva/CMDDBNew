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
using System.Collections;

using System.Configuration;

public partial class Admin_Ad_ModifySubDomain : BasePage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    SqlConnection EBdbConn;
    SqlCommand EBdbCmd;
    SqlDataReader EBdbReader;


    SqlConnection IFM32_dbConn;
    //SqlCommand IFM32_dbCmd;
    //SqlDataReader IFM32_dbReader;


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

        if (!IsPostBack)
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
            //.. get the eBook Pacakage Type PV(2) or AV(1) and PAID status. 
            //.. Own Domain facility is available Only to PV  and PAID users. 

            EBdbConn.Open();
            strSQL = "EXEC [USP_EBOOK_GetDetailsbyMID] " + Convert.ToInt32(Session["MERID"]);

            EBdbCmd = new SqlCommand(strSQL, EBdbConn);
            EBdbReader = EBdbCmd.ExecuteReader();

            String tmpPackageType = String.Empty;
            String tmpPremiumStatus = String.Empty;
            if (EBdbReader.HasRows)
            {
                while (EBdbReader.Read())
                {
                    //.... Handphone is reffered to mobileloginID... 
                    tmpPackageType = EBdbReader["PackageType"].ToString();
                    tmpPremiumStatus = EBdbReader["PremiumStatus"].ToString();
                }
            }

            EBdbConn.Close();
            EBdbReader.Close();



            dbConn.Open();
            strSQL = "EXEC [usp_Retreive_DomainDetails] " + Convert.ToInt32(Session["UserID"]);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {

                    string tmpDomainType = dbReader["UserDomainType"].ToString().Trim();
                    string ADomain = dbReader["ADomain"].ToString().Trim();
                    string tmpSubDomainLink = "";

                    if (ADomain != "")
                    {
                        tmpSubDomainLink = dbReader["SubDomain"].ToString() + "." + ADomain.ToString();
                    }
                    else
                    {
                        tmpSubDomainLink = dbReader["SubDomain"].ToString() + "." + GlobalVar.GetAnchorDomainName;
                    }
                    
                    string subdomaincheckStatus = dbReader["subdomaincheckStatus"].ToString().Trim();

                   //to check subdomain modified or not
                    if (subdomaincheckStatus=="1")
                    {
                        txtOwnDmChoice1.Visible = false;
                        btnDomainCheckNow0.Visible = false;
                        lblentersubdomain.Visible = false;
                        lblColon.Visible = false;
                        lblColon1.Visible=false;
                        lblNote.Visible = false;
                        lblNoteDisp.Visible = false;
                    }

                    //if (tmpPackageType == "1")
                    //{
                    //   trWEB10Section.Visible = true;
                    //   trWEB30Section.Visible = false;
                    //}
                    //else
                    //{
                    //,,Check if DomainType is WEB30 or PLATINUM 


                    //lblSubDomain.Text = dbReader["SubDomain"].ToString();
                    //lblSubDomainLink.Text = "<a target='_blank' href='" + "http://" + tmpSubDomainLink + "'>" + tmpSubDomainLink + "</a>";

                    string tmpRegisteredStatus = dbReader["RegisteredStatus"].ToString();
                    string tmpDomainRegNotice = string.Empty;

                    //lblDomainName.Text = "<u>" + dbReader["DomainName"].ToString() + "</u>";
                    lblDomainName.Text = "<a target='_blank' href='" + "http://" + tmpSubDomainLink + "'>http://" + tmpSubDomainLink + "</a>";

                    trWEB10Section.Visible = false;


                    // if ((tmpDomainType == "WEB30") || (tmpDomainType == "PLATINUM"))   //PLATINUM ,  DIAMOND
                    ////if ((tmpDomainType == "EBOOK") || (tmpDomainType == "SME") || (tmpUserAccountType == "PLATINUM"))   //PLATINUM ,  DIAMOND
                    ////{

                    ////    if ((tmpRegisteredStatus == "") || (tmpRegisteredStatus == null))
                    ////    {
                    ////        trWEB30Section.Visible = true;
                    ////    }
                    ////    else if (tmpRegisteredStatus == "0")
                    ////    {
                    ////        if (dbReader["DomainName"].ToString() != "")
                    ////        {
                    ////            //if (tmpRegisteredStatus == "True")
                    ////            //    ltrDomainRegStatus.Text = " has been registered on " + Convert.ToDateTime(dbReader["RegisteredDate"].ToString()).ToLongDateString();
                    ////            //else
                    ////            ltrDomainRegStatus.Text = " is pending for authorization.";
                    ////        }

                    ////        trWEB30_DomainRegistered.Visible = true;
                    ////        trWEB30Section.Visible = false;

                    ////    }
                    ////    else if (tmpRegisteredStatus == "2")
                    ////    {
                    ////        if (dbReader["DomainName"].ToString() != "")
                    ////        {
                    ////            //if (tmpRegisteredStatus == "True")
                    ////            //    ltrDomainRegStatus.Text = " has been registered on " + Convert.ToDateTime(dbReader["RegisteredDate"].ToString()).ToLongDateString();
                    ////            //else
                    ////            ltrDomainRegStatus.Text = " domain name failed to register.  The reason could be domain name already exists. Please try another domain name.";
                    ////        }

                    ////        trWEB30_DomainRegistered.Visible = true;
                    ////        trWEB30Section.Visible = true;
                    ////    }
                    ////    else
                    ////    {

                    ////        if ((dbReader["DomainName"].ToString() != "") && (dbReader["RegisteredDate"].ToString() != ""))
                    ////        {

                    ////            ltrDomainRegStatus.Text = " has been registered on " + Convert.ToDateTime(dbReader["RegisteredDate"].ToString()).ToLongDateString();
                    ////            //else
                    ////            //ltrDomainRegStatus.Text = " is pending for authorization.";
                    ////        }

                    ////        trWEB30_DomainRegistered.Visible = true;
                    ////        trWEB30Section.Visible = false;
                    ////    }


                    ////}

                    ////else
                    ////{

                    ////    trWEB10Section.Visible = true;
                    ////    trWEB30Section.Visible = false;
                    ////}

                    trWEB30_DomainRegistered.Visible = true;

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


                    //  }

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
        int MyResult;
        // check for subdomain availability --  table cmsdb.dbo.tblUsers
        try
        {

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("cmsdb.dbo.usp_SubDomain_IsExists", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vSubDomainName", SqlDbType.VarChar).Value = tmpDomain2check;
            dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

            int status = dbCmd.ExecuteNonQuery();

             MyResult = (int)dbCmd.Parameters["@Result"].Value;         


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }

        if (MyResult==0)
        {
            lblDomainReq.Text = "SubDomain Name is available";
            lblDomainReq.CssClass = "font_12Msg_Success";
            btnRegister.Visible = true;
        }
        else
        {
            lblDomainReq.Text = "SubDomain Name is NOT available. Please choose again.";
            //lblDomainReq.Text = "val :" + result;
            lblDomainReq.CssClass = "font_12Msg_Error";
            btnRegister.Visible = false;
        }
    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string tmpDomain2check = txtOwnDmChoice1.Text;
        int MyResult;
        // check for subdomain availability --  table cmsdb.dbo.tblUsers
        try
        {

            if (dbConn.State == ConnectionState.Closed)
                dbConn.Open();

            dbCmd = new SqlCommand("cmsdb.dbo.uspT_ModifySubDomain", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vuserid", SqlDbType.VarChar).Value = Session["userid"].ToString();
            dbCmd.Parameters.Add("@vsubdomain", SqlDbType.VarChar).Value = tmpDomain2check;
            dbCmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

            int status = dbCmd.ExecuteNonQuery();

            MyResult = (int)dbCmd.Parameters["@Result"].Value;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }

        //CommonFunctions.AlertMessageAndRedirect("SubDomain Registered successfuly.", "Ad_ModifySubDomain.aspx");

        lblDomainReq.Text = "SubDomain Registered successfuly.";
        lblDomainReq.CssClass = "font_12Msg_Success";
        btnRegister.Visible = false;
        btnDomainCheckNow0.Visible = false;
        txtOwnDmChoice1.Visible = false;
        lblentersubdomain.Visible = false;
        lblColon.Visible = false;
    }


    public Boolean fn_AutoDomainNameRegistration(string vDomainName)
    {

        return true;
    }

    protected void SendEmail_DomainRequestPending()
    {

    }


    //protected void sendsms_Click(object sender, EventArgs e)
    //{

    //    string mSmsRecipients = GlobalVar.GetSMSRecipientList;
    //    string mSmsMessage = "A new Domain Name Registration Request has been raised from " + Environment.NewLine  + GlobalVar.GetAnchorDomainName + ".";

    //    CommonFunctions.MySendSMS(mSmsMessage, mSmsRecipients, GlobalVar.GetAnchorDomainName);

    //}
}
