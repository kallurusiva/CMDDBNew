using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_AdminSideMenu_PgSettings : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrAboutusList.Text = Resources.LangResources.AboutUs + " " + Resources.LangResources.Listing;
        ltrAddAboutUsPage.Text = Resources.LangResources.Add + " " + Resources.LangResources.AboutUs + Resources.LangResources.Page;

        ltrAddWelComepage.Text = Resources.LangResources.Add + " " + Resources.LangResources.Welcome + Resources.LangResources.Page;
        ltrWelcomepageList.Text = Resources.LangResources.Welcome + Resources.LangResources.Page + " " + Resources.LangResources.Listing;

        ltrWebSetting.Text = Resources.LangResources.WebSettings;



         string tmpCurrPageName = Path.GetFileNameWithoutExtension(Request.PhysicalPath);
         tmpCurrPageName = tmpCurrPageName.ToLower();

         vWebSettings.Visible = false;
         vWebTemplate.Visible = false;
         vBanners.Visible = false;
         vLogo.Visible = false;
        
         vWelcomePageAdd.Visible = false;
         vWelcomePageList.Visible = false;
         vAboutUsPageAdd.Visible = false;
         vAboutUsPageList.Visible = false;
         


         if (tmpCurrPageName.Contains("websettings"))
         {
             vWebSettings.Visible = true;
             trHrMenu.Visible = false;
         }
         else if (tmpCurrPageName.Contains("templateset"))
         {
             vWebTemplate.Visible = true;
             trHrMenu.Visible = false;
         }
         else if (tmpCurrPageName.Contains("banner"))
         {
             vBanners.Visible = true;
             vLogo.Visible = true;
             trHrMenu.Visible = false;
         }
         else if (tmpCurrPageName.Contains("logo"))
         {
             vBanners.Visible = true;
             vLogo.Visible = true;
             trHrMenu.Visible = false;
         }
         else if (tmpCurrPageName.Contains("welcomepage"))
         {
             vWelcomePageAdd.Visible = true;
             vWelcomePageList.Visible = true;
         }
         else if (tmpCurrPageName.Contains("aboutuspage"))
         {
             vAboutUsPageAdd.Visible = true;
             vAboutUsPageList.Visible = true;
         }
       

        

    
    }
}
