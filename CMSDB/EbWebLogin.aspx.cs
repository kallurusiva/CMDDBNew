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


public partial class EbWebLogin : UserWeb
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

                tmpMerchantID =  Convert.ToInt32(uRow2["Merid"].ToString());
            
             }


            #region posting to ebook login validation URL 

             CMSv3.BAL.User objUser = new CMSv3.BAL.User();

                DataSet dsCheck;
                string strSQL = string.Empty;
                DataTable dtUserRecord = new DataTable();
                DataTable dtUserStatus = new DataTable();
                mUserName = "EB" + mUserName; 
                dsCheck = objUser.CheckUser_ValidateByMobileLogin(CommonFunctions.SafeSql(mUserName));

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
                    // Session["LoggedInFrom"] = "WEBPORTAL";
                   // Session["MERID"] = "131158";
                    Session["LoggedInFrom"] = "PG4MeBook1975";


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




                    CommonFunctions.LogUserWebInfo(Session["UserID"].ToString(), mUserName);
                    CommonFunctions.LogUserLoginData(mUserName, mPassword, Convert.ToInt16(GlobalVar.UserLoginFrom.CustWeblogin), 1);
                    Response.Redirect("~/Admin/Ad_Welcome.aspx");
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


   

    public static Boolean IsNumeric(string stringToTest)
    {
        int result;
        return int.TryParse(stringToTest, out result);
    }



    
}

