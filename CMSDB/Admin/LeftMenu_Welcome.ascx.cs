using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Threading;
using System.Globalization;


public partial class Admin_LeftMenu_Welcome : System.Web.UI.UserControl
{

        string tmpDomainType = string.Empty;
    string tmpSubDomainLink = string.Empty;
    string tmpOwnDomainName = string.Empty;
    string tmpSubDomainName = string.Empty;
    string tmpAnchorDomain = string.Empty;
    String tmpAdminLanguageCode = string.Empty; 


    protected void Page_Load(object sender, EventArgs e)
    {

       

        //HypAdminEvents.Text = "Admin " + Resources.LangResources.Events;
        //HypShowALL.Text = Resources.LangResources.Showall;

        if (!IsPostBack)
        {

            //RenderDomainButton();

           // LoadWelcomePageDetails();
            
            //LoadMobileWebStats();

        }


    }


    //protected void LoadWelcomePageDetails()
    //{


    //    CMSv3.BAL.User objUser = new CMSv3.BAL.User();

    //    DataSet ds = objUser.WelcomePage_Details(Convert.ToInt32(Session["UserID"]));
    //    DataTable dtUserInfo = ds.Tables[0];


    //    if (dtUserInfo.Rows.Count > 0)
    //    {

    //        DataRow uRow = (DataRow)dtUserInfo.Rows[0];

    //        lblLoginID.Text = uRow["LoginID"].ToString();

    //        DateTime dtCreatedDate = Convert.ToDateTime(uRow["CreatedDate"].ToString());
    //        lblCreatedDate.Text = String.Format("{0:MMM d, yyyy h:mm tt}", dtCreatedDate);



    //        //lblUserType.Text = uRow["UserType"].ToString();
    //        lblMobileNo.Text = uRow["HandPhone"].ToString();
    //        lblActivatedPinNo.Text = uRow["RegisteredPin"].ToString();


    //         //..rendering Domain Names. 
    //                tmpOwnDomainName = uRow["OwnDomain"].ToString();
    //                tmpSubDomainName = uRow["SubDomain"].ToString();
    //                tmpAnchorDomain = uRow["AnchorDomain"].ToString();



    //                tmpAdminLanguageCode = uRow["AdminLanguage"].ToString();

    //                String selectedLanguage = string.Empty;
    //                String mLangCulture = string.Empty;

    //                switch (tmpAdminLanguageCode)
    //                {
    //                    case "1": mLangCulture = GlobalVar.Lang_English; break;
    //                    case "2": mLangCulture = GlobalVar.Lang_BahasaMalay; break;
    //                    case "3": mLangCulture = GlobalVar.Lang_SimplifedChinese; break;

    //                }


    //                Session["ADMdefLanguage"] = mLangCulture;
    //                //lblErrMessage.Text = "User Sucessfully Logged IN ";
    //                selectedLanguage = Session["ADMdefLanguage"].ToString();
    //                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
    //                Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

    //                //...Own Domain 
    //                if (tmpOwnDomainName != "")
    //                {
    //                    dvOwnDomain.Visible = true;
    //                    tmpOwnDomainName = "www." + tmpOwnDomainName;
    //                    lblOwnDomainName.Text = @"<a target='_blank' class='links_DomainName' href='http://" + tmpOwnDomainName + "'>" + tmpOwnDomainName + "</a>" + " <br />";

    //                    DateTime dtExpiryDate = Convert.ToDateTime(uRow["DomainExpiryDate"].ToString());
    //                    lblOwnDomainExpiryDate.Text = String.Format("{0:MMM d, yyyy h:mm tt}", dtExpiryDate);
    //                }
    //                else
    //                {
    //                    dvOwnDomain.Visible = false;
    //                }

                    
    //                 String UrlSubDomainName1 = string.Empty;

    //                if (tmpAnchorDomain != "")
    //                {
    //                    UrlSubDomainName1 = tmpSubDomainName + "." + tmpAnchorDomain;
    //                }
    //                else
    //                {
    //                    UrlSubDomainName1 = tmpSubDomainName + "." + GlobalVar.GetAnchorDomainName;
    //                }


    //                lblSubDomainName1.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + UrlSubDomainName1 + "'>" + UrlSubDomainName1 + "</a>" + " <br />";

                    

    //                ImgContact.ImageUrl = uRow["FullImgPath"].ToString();

    //                //DateTime tmpLastLogin = Convert.ToDateTime(dbReader["LastLogin"].ToString());
    //                //lblLastLogin.Text = "You have last logged in on <b>" + tmpLastLogin.ToLongDateString().ToString() + "</b> at <b>" + tmpLastLogin.ToShortTimeString() + "</b";
    //              //  lblLastLogin.Text = "<b>" + uRow["LastLogin"].ToString() + "</b";

    //                if ((Session["UserDomainType"] == null) || (Session["UserDomainType"].ToString() == ""))
    //                {
    //                    Session["UserDomainType"] = uRow["UserDomainType"].ToString();
    //                }


    //    }


     

    //}

}
