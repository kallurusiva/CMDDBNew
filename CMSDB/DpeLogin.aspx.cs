using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Globalization;
using System.Threading;


public partial class DpeLogin : UserWeb
{
    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //DataSet ds;
    //string strSQL;

    CMSv3.BAL.eBook objeBook = new CMSv3.BAL.eBook(); 


    protected void Page_Load(object sender, EventArgs e)
    {

        //MasterPage objMaster = (MasterPage)this.Master;
        //Literal ltrTest = (Literal) objMaster.FindControl("LtrTest");
        //ltrTest.Text = "Testing";
        
      

        HtmlGenericControl myDivObject;
        myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

        //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";
        if(myDivObject != null)
        myDivObject.InnerHtml = "<img alt='imbnLeftimg' src='Images/login_sidehead.jpg' />";


        ContentPlaceHolder cphLEFT = Page.Master.FindControl("ContentPlaceHolderLEFT") as ContentPlaceHolder;
        cphLEFT.Visible = false;

        ContentPlaceHolder cphRIGHT = Page.Master.FindControl("ContentPlaceHolderRight") as ContentPlaceHolder;
        




     
        //txtLogin_SMS.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
    


    }





    protected void btnSignIn_eVendor_Click(object sender, EventArgs e)
    {

        string mUserName = txtLogin_SMS.Text;
        string mPassword = txtPassword_SMS.Text;
        string mMID = string.Empty;
        string mReturnedMobileNo = string.Empty;


        String tmpMuserName = string.Empty;
        String tmpMPassword = string.Empty; 


        //int tmpStatus = 0;
        //int tmpMerchantID = 0;

        int DPE_ValidStatus = 0;
        String ValidStatusText = CommonFunctions.ValidateLoginStatus_DPE(mUserName, ref DPE_ValidStatus);




        String strURL = ConfigurationManager.AppSettings["DPE_SMSURL"].ToString();
        String tmpLoginFrom = "DPE";

        DataSet dsDPE = new DataSet();

        CMSv3.BAL.DPE objDPE = new CMSv3.BAL.DPE();

        dsDPE = objDPE.DPE_GetDetails(mUserName);

        if (dsDPE.Tables[0].Rows.Count > 0)
        {

            DataRow UserStatus_Row = dsDPE.Tables[0].Rows[0];


            tmpMuserName = UserStatus_Row["LoginMobile"].ToString();
            tmpMPassword = UserStatus_Row["LoginPwd"].ToString();


        }


        Session["MobileLoginID"] = tmpMuserName;
        Response.Redirect("~/Admin/Ad_Navigate4WebDPE.aspx"); 

        

        String strReferringURL = string.Empty;


        if (Session["referringURL"] != null)
            strReferringURL = Session["referringURL"].ToString();



        if ((DPE_ValidStatus == 0) || (DPE_ValidStatus == 3))
        {
            if (DPE_ValidStatus == 3)
            {
                CommonFunctions.AlertMessage(ValidStatusText);

            }

            HttpContext.Current.Response.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
            sb.AppendFormat("<input type='hidden' name='Muser' value='{0}'>", tmpMuserName);
            sb.AppendFormat("<input type='hidden' name='Mpwd' value='{0}'>", tmpMPassword);
            sb.AppendFormat("<input type='hidden' name='MLoginFrom' value='{0}'>", tmpLoginFrom);
            sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
            // Other params go here
            sb.Append("</form>");
            sb.Append("</body>");
            sb.Append("</html>");

            HttpContext.Current.Response.Write(sb.ToString());
            //HttpContext.Current.Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();



        }
        else
        {
            CommonFunctions.AlertMessage(ValidStatusText);
            LblNotice.Text = ValidStatusText;
            ModalPopUpExtender1.Show();
        }


   
    }


   

    public static Boolean IsNumeric(string stringToTest)
    {
        int result;
        return int.TryParse(stringToTest, out result);
    }




    protected void btnSignIn_Product_Click(object sender, EventArgs e)
    {

        String qLoginID = pLoginID.Text;
        String qPassword = pPassword.Text; 

        //.. Before Redirecting Check if the User has registered a SubDomain. if NOT prompt message. 
        DataSet dsCheck;
        string strSQL = string.Empty;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

        if (!qLoginID.Contains("DPE"))
            qLoginID = "DPE" + qLoginID;

        dsCheck = objUser.CheckUser_ValidateByMobileLogin(CommonFunctions.SafeSql(qLoginID));


        if (dsCheck.Tables.Count == 2)
        {
            dtUserStatus = dsCheck.Tables[0];
            dtUserRecord = dsCheck.Tables[1];

        }
        else
        {
            dtUserStatus = dsCheck.Tables[0];
        }

        DataRow UserStatus_Row = dtUserStatus.Rows[0];
        string UserStatus_Value = UserStatus_Row["userStatus"].ToString();


        if (UserStatus_Value == "MATCHED")
        {
            DataRow UserRecord_Row = dtUserRecord.Rows[0];

            Session["UserID"] = UserRecord_Row["UserID"].ToString();
            Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
            Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
            Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
            Session["defLanguage"] = UserRecord_Row["LanguageCode"].ToString();
            Session["LoggedInFrom"] = "DPE";
            Session["referringURL"] = "dpeProductLogin.com";


            String usrSubDomain = UserRecord_Row["SubDomain"].ToString();
            String usrOwnDomain = UserRecord_Row["OwnDomain"].ToString();
            String yourSampleURL = string.Empty;

            if ((usrOwnDomain != null) && (usrOwnDomain != ""))
            {
                yourSampleURL = "http://www." + usrOwnDomain;
            }
            else
            {
                yourSampleURL = "http://" + usrSubDomain + ".1mybusiness.com";
            }

            Session["UserDomainURL"] = yourSampleURL;


            CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), qLoginID);
            Response.Redirect("~/Admin/Ad_WelcomeDPE.aspx");
        }
        else
        {
            CommonFunctions.AlertMessage(Server.HtmlEncode("Login Failed"));
        }




    }
}

