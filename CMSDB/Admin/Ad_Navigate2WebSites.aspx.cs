using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;


public partial class Admin_Ad_Navigate2WebSites : System.Web.UI.Page
{

    string go2Page = string.Empty;
    string tmpMobileLoginID = string.Empty;
    string tmpCountryPrefix = string.Empty;
    string tmpMuserName = string.Empty;
    string tmpMPassword = string.Empty;
    String tmpMID = string.Empty;




    protected void Page_Load(object sender, EventArgs e)
    {

        String tmpLoggedInFrom = String.Empty;

        if (Session["LoggedInFrom"] != null)
        {
            tmpLoggedInFrom = Session["LoggedInFrom"].ToString();
           
        }


        go2Page = Request.QueryString["go2Page"];

        String ValidStatusText = string.Empty;
        int ValidStatus = 0;


        if (go2Page != "")
        {
            if (Session["MobileLoginID"] != null)
                tmpMobileLoginID = Session["MobileLoginID"].ToString();
           // tmpMobileLoginID = "60162531066";
            //get username and password 

            string strReferringURL = string.Empty;

            if(Session["referringURL"] != null)
                strReferringURL = Session["referringURL"].ToString();

            

           


            if (tmpMobileLoginID != string.Empty)
            {
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();


                DataSet dsCheck;
                DataTable dtUserRecord = new DataTable();
                DataTable dtUserStatus = new DataTable();

                dsCheck = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing_ByMobileLoginID(tmpMobileLoginID);

                if (dsCheck.Tables[0].Rows.Count > 0)
                {

                    DataRow UserStatus_Row = dsCheck.Tables[0].Rows[0];

                    tmpMID = UserStatus_Row["MID"].ToString();
                    tmpMuserName = UserStatus_Row["Login_ID"].ToString();
                    tmpMPassword = UserStatus_Row["Password"].ToString();

                    tmpCountryPrefix = tmpMuserName.Substring(0, 2);

                    string tmpForBruneiPrefix = tmpMuserName.Substring(0, 3);
                    if (tmpForBruneiPrefix == "673")
                        tmpCountryPrefix = "673";



                }


                //OnlyForBrunei using Sam number 
                //String TestingMobileNumber = ConfigurationManager.AppSettings["testMobileNumber"].ToString();
                //if (tmpMuserName == TestingMobileNumber)
                //    tmpCountryPrefix = "673";


                //String strReferringURL = HttpContext.Current.Request.Url.OriginalString;
                //strReferringURL = strReferringURL.Replace("http://", "");
                //int GetFirstSlashidx = strReferringURL.IndexOf(@":");
                //if (GetFirstSlashidx > 0)
                //    strReferringURL = strReferringURL.Substring(0, GetFirstSlashidx); 

                string strURL = string.Empty;

                if (go2Page == "1MACC")
                {
                    //strURL = "http://210.5.45.47/hitechdigitalbiz/1SmsWebSite_BizMemberCheck.aspx";
                    strURL = ConfigurationManager.AppSettings["BizLoginCheckURL"].ToString();



                    ValidStatus = 0;
                    ValidStatusText = CommonFunctions.ValidateLoginStatusNEW(tmpMuserName, tmpMPassword, "PARTNER", ref ValidStatus);

                    //ValidStatusText = CommonFunctions.ValidateLoginStatusTEXT(tmpMuserName, tmpMPassword, "PARTNER");

                    //switch (tmpCountryPrefix)
                    //{
                    //    //case "60":  /* Malaysia  */ strURL = "http://64.78.18.32/Hitech/1SmsWebSite_BizMemberCheck_Hitech.asp"; break;
                    //    case "60":  /* Malaysia  */ strURL = "http://210.5.45.47/hitechdigitalbiz/1SmsWebSite_BizMemberCheck.aspx"; break;


                    //    case "65":  /* Singapore */ strURL = "http://64.78.18.32/singapore/1SMSWebSite_BizMemberCheckSGD_NEW.asp"; break;
                    //    case "673": /* Brunei    */ strURL = "http://64.78.18.32/Hitech/PartnerLogin_Brunei.asp"; break;

                    //}


                }
                else if (go2Page == "SMSSYSTEM")
                {

                    //strURL = "http://210.5.45.47/hitechsms/ValidateUserLogin_FromMyHitechSMS.aspx";
                    strURL = ConfigurationManager.AppSettings["HitechALLURL"].ToString();

                    if(Session["LoggedInFrom"] != null)
                    {
                        if(Session["LoggedInFrom"].ToString() == "SMSSYSTEM_WPY")
                            strURL = ConfigurationManager.AppSettings["HitechSMSURL"].ToString();

                        lblDebug.Text = Session["LoggedInFrom"].ToString() + "#" + tmpMobileLoginID + "#" + tmpMuserName + "#" + tmpMPassword  +"#" + tmpMID; 
                    }


                    ValidStatus = 0;
                    ValidStatusText = CommonFunctions.ValidateLoginStatusNEW(tmpMuserName, tmpMPassword, "SMSSYSTEM", ref ValidStatus);
                   // ValidStatusText = CommonFunctions.ValidateLoginStatusTEXT(tmpMuserName, tmpMPassword, "SMSSYSTEM");

                    //HttpContext.Current.Response.Clear();
                    //StringBuilder sbs = new StringBuilder();
                    //sbs.Append("<html>");
                    //sbs.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                    //sbs.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
                    ////sbs.AppendFormat("<input type='hidden' name='tmpMID' value='{0}'>", tmpMID);
                    ////sbs.AppendFormat("<input type='hidden' name='tmpUsrType' value='{0}'>", 0);
                    ////sbs.AppendFormat("<input type='hidden' name='tmpLoginFrom' value='{0}'>", "SMSLOGIN");

                    //sbs.AppendFormat("<input type='hidden' name='Muser' value='{0}'>", tmpMuserName);
                    //sbs.AppendFormat("<input type='hidden' name='Mpwd' value='{0}'>", tmpMPassword);
                    //sbs.AppendFormat("<input type='hidden' name='MloginFrom' value='{0}'>", "SMSLOGIN");
                    //sbs.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
                    //// Other params go here
                    //sbs.Append("</form>");
                    //sbs.Append("</body>");
                    //sbs.Append("</html>");

                    //HttpContext.Current.Response.Write(sbs.ToString());
                    //HttpContext.Current.ApplicationInstance.CompleteRequest();
                    //HttpContext.Current.Response.End();

                  
                }
               

                String tmpLoginFrom = string.Empty;
                tmpLoginFrom = "WEBPORTAL";

                if (Session["LoggedInFrom"] != null)
                {
                    
                    //if ((Session["LoggedInFrom"].ToString() == "SMSSYSTEM_WPN") || (Session["LoggedInFrom"].ToString() == "SMSSYSTEM_WPN"))
                    if (Session["LoggedInFrom"].ToString() == "SMSSYSTEM_WPY")
                    {
                        tmpLoginFrom = "SMSLOGIN";
                    }
                }



                //if (ValidStatusText == "VALID")
                if ((ValidStatus == 0) || (ValidStatus == 3))
                {
                    if (ValidStatus == 3)
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


        }
    }


    protected void fnValidateDPELogin(string vMobileLoginID)
    {


        int DPE_ValidStatus = 0;
        String DPe_ValidStatusText = CommonFunctions.ValidateLoginStatus_DPE(vMobileLoginID, ref DPE_ValidStatus);

       String strURL = ConfigurationManager.AppSettings["DPE_SMSURL"].ToString();
       String tmpLoginFrom = "DPE";

       DataSet dsDPE = new DataSet();

        CMSv3.BAL.DPE objDPE = new CMSv3.BAL.DPE();

        dsDPE = objDPE.DPE_GetDetails(vMobileLoginID);

        if (dsDPE.Tables[0].Rows.Count > 0)
       {

           DataRow UserStatus_Row = dsDPE.Tables[0].Rows[0];


           tmpMuserName = UserStatus_Row["LoginMobile"].ToString();
           tmpMPassword = UserStatus_Row["LoginPwd"].ToString();


       }


        if (Session["LoggedInFrom"] != null)
        {
            tmpLoginFrom = Session["LoggedInFrom"].ToString();
            hdDebug.Value = tmpLoginFrom;
        }


       String strReferringURL = string.Empty; 


       if (Session["referringURL"] != null)
           strReferringURL = Session["referringURL"].ToString();



        if ((DPE_ValidStatus == 0) || (DPE_ValidStatus == 3))
        {
            if (DPE_ValidStatus == 3)
            {
                CommonFunctions.AlertMessage(DPe_ValidStatusText);

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
            CommonFunctions.AlertMessage(DPe_ValidStatusText);
            LblNotice.Text = DPe_ValidStatusText;
            ModalPopUpExtender1.Show();
        }


    }
}
