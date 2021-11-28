using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class PgCentralLogin4mASP : System.Web.UI.Page
{

    String ValidCheckStr = string.Empty;
    String rtrSubDomain = string.Empty;
    String pgLink;

    protected void Page_Load(object sender, EventArgs e)
    {


                                 //http://sms.1smsbusiness.com/PgCentralLogin4mASP.aspx?jroY1tv0VQ=JDEKFEMJIDH&jroy1tv0c9q=EFGHIJ&ersr44v0theY=u662://5z5.E5z5o75v0r55.p1z
        //string inComingURL1 = "http://sms.1smsbusiness.com/PgCentralLogin4mASP.aspx?5cn4z=jroY1tv0VQ=JDEKFEMJIDH&jroy1tv0c9q=EFGHIJ&ersr44v0theY=u662://5z5.E5z5o75v0r55.p1z";
        //string inComingURL2 = "jroY1tv0VQ=JDEKFEMJIDH&jroy1tv0c9q=EFGHIJ&ersr44v0theY=u662://5z5.E5z5o75v0r55.p1z";
        ////string inComingURL3 = "JDEKFEMJIDH&jroy1tv0c9q=EFGHIJ&ersr44v0theY=u662://5z5.E5z5o75v0r55.p1z";

        // //sField = Decode(request.querystring(encode("sParm")))
        //String decField1 = Decode(inComingURL1); 
        // String decField2 = Decode(inComingURL2);



         String inQueryString = Request.QueryString.ToString();
         //String inQueryString = decField2;
         String decQuerysting = Decode(inQueryString);
         String[] QParams = decQuerysting.Split('&');
         String QwebLoginID  = QParams[0];
         String QwebPassword = QParams[1];
         String QwebReferURL = QParams[2];

         String ValWebLogin = QwebLoginID.Substring(QwebLoginID.IndexOf('=')+1);
         String ValWebPassword = QwebPassword.Substring(QwebPassword.IndexOf('=')+1);
         String ValwebReferURL = QwebReferURL.Substring(QwebReferURL.IndexOf('=') + 1);
         //Response.Write("id=" + ValWebLogin + " and pwd=" + ValWebPassword + " and referul = "+ ValwebReferURL);
         //Response.End(); 

         string qRefferringURL = string.Empty;
         string qLoginID = string.Empty;
         string qPasswordID = string.Empty;

         //if((Request.Form["WebLoginID"] != null) && (Request.Form["WebLoginID"].ToString() != ""))
         //qLoginID = Request.Form["WebLoginID"].ToString();

         //if ((Request.Form["WebloginPwd"] != null) && (Request.Form["WebloginPwd"].ToString() != ""))
         //qPasswordID = Request.Form["WebloginPwd"].ToString();

         //if ((Request.Form["ReferringURL"] != null) && (Request.Form["ReferringURL"].ToString() != ""))
         //qRefferringURL = Request.Form["ReferringURL"].ToString();


         qLoginID = ValWebLogin;
         qPasswordID = ValWebPassword;
         qRefferringURL = ValwebReferURL; 

         if ((qLoginID != string.Empty) && (qPasswordID != string.Empty))
         {
             //Boolean isValidLogin = ValidateLoginByDomain(qLoginID, qPasswordID);

             CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
             string tmpMID = objBAL_MalaysiaSMS.ValidateUserLoing_1MAS_1Sing(qLoginID, qPasswordID);


             if (tmpMID == "0")
             {
                 // invalid login 
                 ValidCheckStr = "Invalid Password ...";
                 Page.ClientScript.RegisterClientScriptBlock(GetType(), "InValidPwd", "ShowPopup('" + ValidCheckStr + "');", true);
             }
             else if (tmpMID == "1")
             {
                 //LtrErrMessage.Text = "Not Subscribed to SMSBIZ.";

                 StringBuilder sbm = new StringBuilder();

                 sbm.Append(@"\n This M-Commerce Partner Login is strictly for SMS Entrepreneur Only.");
                 sbm.Append(@"\n ");
                 sbm.Append(@"\n Please consult your referral for explaination on ");
                 sbm.Append(@"\n SMS Business Requirement and ask for instructions ");
                 sbm.Append(@"\n on how to set SMS Business Status to YES.  ");
                 sbm.Append(@"\n\n ");
                 sbm.Append(@"\n Thank you.");

                 CommonFunctions.AlertMessage(Server.HtmlEncode(sbm.ToString()));
                 // CommonFunctions.AlertMessage(Server.HtmlEncode(@"Not Subscribed \n Thank you")); 


             }
             else 
             {
                 CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
                 Boolean chkStatus = ValidateByMobileLoginID(qLoginID); 
                 //int upStatus = objBAL_User.Update_User_LastLoginDetails(Convert.ToInt32(Session["UserID"]));
                 //CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), Session["LoginID"].ToString());
                 CommonFunctions.LogUserWebInfo(tmpMID, qLoginID);
                 //Response.Write("-----------"); 
                 //if (Session["UserID"] != null)
                 //    Response.Write("Session-Userid=" + Session["UserID"].ToString());
                 //Response.End(); 

                 //String StrLink = "http://" + rtrSubDomain + "." + GlobalVar.GetAnchorDomainName + "/Admin/Ad_Welcome.aspx";
                 // Response.Redirect(StrLink);

                 if (chkStatus)
                     Response.Redirect("~/Admin/Ad_Welcome.aspx");
                     //Response.Redirect(pgLink); 
                
                 //Server.Transfer("~/Admin/Welcome.aspx");

             }
             //else
             //{
                 
             //    Page.ClientScript.RegisterClientScriptBlock(GetType(), "SessionEx", "ShowPopup('" + ValidCheckStr + "');", true);
             //}


         }

       
        //Session["UserID"] = qUserID;
        //Session["LoginID"] = qLoginID;
        //Session["UserDomainType"] = qUserDomainType;
        //Session["MobileLoginID"] = qMobileLoginID;
        //Session["referringURL"] = qRefferringURL;
       
        //Response.Redirect("~/Admin/Ad_Welcome.aspx");


    }

    protected string Decode(string sIn) {
        int x;
        int y;
        //string abfrom="";
        string abto="";
        string retDecode = "";
        string ABFrom = "";

        for (x = 0; (x <= 25); x++) {
            ABFrom = (ABFrom + ((char)((65 + x))));
        }
        for (x = 0; (x <= 25); x++) {
            ABFrom = (ABFrom + ((char)((97 + x))));
        }
        for (x = 0; (x <= 9); x++) {
            ABFrom = (ABFrom + x.ToString());
        }

        abto = (ABFrom.Substring(13, (ABFrom.Length - 13)) + ABFrom.Substring(0, 13));

        for (x = 1; (x <= sIn.Length); x++)
        {
            y = (abto.IndexOf(sIn.Substring((x - 1), 1)) + 1);
            if ((y == 0)) {
                retDecode = (retDecode + sIn.Substring((x - 1), 1));
            }
            else {
                retDecode = (retDecode + ABFrom.Substring((y - 1), 1));
            }
        }

        return retDecode; 
    }

    protected Boolean ValidateByMobileLoginID(string vUserID)
    {


        SqlConnection dbConn;
        //SqlCommand dbCmd;
        //SqlDataReader dbReader;
        //SqlDataAdapter dbAdap;
        DataSet dsCheck;
        string strSQL = string.Empty;
        DataTable dtUserRecord = new DataTable();
        DataTable dtUserStatus = new DataTable();

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

        bool LoginStatus = false;

        //string selectedLanguage;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);


        try
        {
            //strSQL = "Select UserID,LoginID,UserType,UserDomainType,isActive from tblUsers where LoginID='" + CommonFunctions.SafeSql(mUserName) + "' and LoginPassword='" + CommonFunctions.SafeSql(mPassword) + "' and SubDomain = '" + CommonFunctions.SafeSql(mUserName) + "'";

            //strSQL = "Exec [usp_User_CheckLogin] " + "'" + CommonFunctions.SafeSql(mUserName) + "' , '" + CommonFunctions.SafeSql(mPassword) + "'";

            //dsCheck = objUser.CheckUser_LoginStatus(CommonFunctions.SafeSql(vUserID), CommonFunctions.SafeSql(vPassword));
            dsCheck = objUser.CheckUser_ValidateByMobileLogin(CommonFunctions.SafeSql(vUserID)); 
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
                rtrSubDomain = UserRecord_Row["subDomain"].ToString();
                Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
                Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
                ValidCheckStr = "SUCCESSFUL";

                String tmpReferrringURL = "";
                pgLink = "PgFromAsp.aspx?qUserID=" + Session["UserID"].ToString() + "&qLoginID=" + Session["LoginID"].ToString() + "&qUserDomainType=" + Session["UserDomainType"].ToString() + "&qMobileLoginID=" + UserRecord_Row["MobileLoginID"].ToString() + "&qRefferringURL=" + tmpReferrringURL;
            
                LoginStatus = true;
            }
            else if (UserStatus_Value == "EXPIRED")
            {
                //LtrErrMessage.Text = "Account Expired ...";
                ValidCheckStr = "Your account has Expired. Please contact Administrator.";
                LoginStatus = false;
            }
            else
            {
                //LtrErrMessage.Text = "Invalid Password ...";
                ValidCheckStr = "Invalid Password Entered. Please try again.";
                LoginStatus = false;
            }



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {

        }

        return LoginStatus;

    }

}
