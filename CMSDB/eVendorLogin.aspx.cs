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


public partial class eVendorLogin : UserWeb
{
    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    DataSet ds;
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


        int tmpStatus = 0;
        int tmpMerchantID = 0;

        String ValidStatusText = string.Empty;

        ValidStatusText = CommonFunctions.ValidateLoginStatusTEXT(mUserName, mPassword, "EBOOK");
        ValidStatusText = "VALID";
        if (ValidStatusText == "VALID")
        {

            ds = objeBook.Validate_UserLogin(mUserName, mPassword);


            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow uRow1 = (DataRow)ds.Tables[0].Rows[0];

                // tmpStatus = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                tmpStatus = Convert.ToInt32(uRow1["Result"].ToString());
            }


            if (tmpStatus == 1)
            {


                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow uRow2 = (DataRow)ds.Tables[1].Rows[0];

                    tmpMerchantID = Convert.ToInt32(uRow2["Merid"].ToString());

                }


                string qLoginID = mUserName;

                if (!qLoginID.Contains("EB"))
                    qLoginID = "EB" + qLoginID; 


                #region posting to ebook login validation URL

                DataSet dsCheck;
                string strSQL = string.Empty;
                DataTable dtUserRecord = new DataTable();
                DataTable dtUserStatus = new DataTable();

                CMSv3.BAL.User objUser = new CMSv3.BAL.User();

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

                string qLoginFrom = "PG4MeBook1975";
                String qRefferringURL = "LocalHost"; 




                if (UserStatus_Value == "MATCHED")
                {
                    DataRow UserRecord_Row = dtUserRecord.Rows[0];

                    Session["UserID"] = UserRecord_Row["UserID"].ToString();
                    Session["LoginID"] = UserRecord_Row["LoginID"].ToString();
                    Session["MobileLoginID"] = UserRecord_Row["MobileLoginID"].ToString();
                    Session["UserDomainType"] = UserRecord_Row["UserDomainType"].ToString();
                    Session["defLanguage"] = "en-US";
                    Session["LoggedInFrom"] = qLoginFrom;
                    Session["referringURL"] = qRefferringURL;
                    Session["MERID"] = tmpMerchantID;
                    Session["PackageType"] = "2";




                    String usrSubDomain = UserRecord_Row["SubDomain"].ToString();
                    String usrOwnDomain = UserRecord_Row["OwnDomain"].ToString();
                    String yourSampleURL = string.Empty;

                    if ((usrOwnDomain != null) && (usrOwnDomain != ""))
                    {
                        yourSampleURL = "http://www." + usrOwnDomain;
                    }
                    else
                    {
                        yourSampleURL = "http://" + usrSubDomain + ".eVenchise.com";
                    }

                    Session["UserDomainURL"] = yourSampleURL;


                    CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), qLoginID);


                    String vComingFrom = string.Empty;


                    if (qLoginFrom == "PG4MeBook1975")
                    {
                        //Response.Redirect("~/Admin/EbAd_DashBoard.aspx");
                        Response.Redirect("~/Admin/Ad_WelcomeEbook.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Admin/Ad_WelcomeEbook.aspx");
                    }


                }
                else
                {
                    CommonFunctions.AlertMessage(Server.HtmlEncode("Login Failed"));
                }



                #endregion
            }
            else
            {
                ClientScriptManager cs = Page.ClientScript;
                Type myType = this.GetType();
                //Check to see if the startup script is already registered.

                if (!cs.IsStartupScriptRegistered(myType, "AlertScript"))
                {
                    String script = "alert('Invalid Login ID and Password');";
                    cs.RegisterStartupScript(myType, "AlertScript", script, true);
                }
            }

        }
        else
        {
            LblNotice.Text = ValidStatusText;
            ModalPopUpExtender1.Show(); 
            //objLblNotice.Text = ValidStatusText; 
            //ModalPopUpExtender1.Show();

        }
    }


   

    public static Boolean IsNumeric(string stringToTest)
    {
        int result;
        return int.TryParse(stringToTest, out result);
    }



    
}

