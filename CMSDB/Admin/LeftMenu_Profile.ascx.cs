using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_LeftMenu_Profile : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ltrAboutUs.Text = Resources.LangResources.AboutUs;
        HypAboutUsAdd.Text = Resources.LangResources.Add + " " + Resources.LangResources.AboutUs + " " + Resources.LangResources.Page;
        HypAboutUsAddListing.Text = Resources.LangResources.AboutUs + " " + Resources.LangResources.Listing;

        ltrWelcomePage.Text = Resources.LangResources.WelcomePage;
        HypWelcomePageAdd.Text = Resources.LangResources.Add + " " + Resources.LangResources.Welcome + " " + Resources.LangResources.Page;
        HypWelcomePageListing.Text = Resources.LangResources.Welcome + " " + Resources.LangResources.Page + " " + Resources.LangResources.Listing;
        
        
        string tmpCurrPageName = Path.GetFileNameWithoutExtension(Request.PhysicalPath);
        tmpCurrPageName = tmpCurrPageName.ToLower();


        if (Session["UserDomainType"] != null)
        {
            if ((Session["UserDomainType"].ToString() == "SME") || (Session["UserDomainType"].ToString() == "EBOOK"))
            {
                HypAboutUsAdd.NavigateUrl = "Ad_AboutUsPageCreateWES.aspx";
                HypWelcomePageAdd.NavigateUrl = "Ad_WelComePageSettingsWES.aspx";
                HypChangePassword.Visible = true; 
            }

            if (Session["UserDomainType"].ToString() == "EBOOK")
            {
                hrdAboutUs.Visible = false; 
                HypAboutUsAdd.Visible = false;
                HypAboutUsAddListing.Visible = false;

                HypWelcomePageListing.Visible = false; 
                HypWelcomePageAdd.NavigateUrl = "Ad_WelComePageSettingsEBOOK.aspx";
                HypChangePassword.Visible = true;
                HypChangePassword.NavigateUrl = "Ad_ChangePassword.aspx"; 


            }

            else
            {
                HypChangePassword.Visible = false;
            }
            
        }
       
    
    }
}
