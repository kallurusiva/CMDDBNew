using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMasterDIYMB : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        String Cpage = Request.RawUrl.ToLower();

        if (Cpage.Contains("mobilehome")) aMbHome.Attributes.Add("class", "liActive");
        if (Cpage.Contains("mobiletemplate")) aMbTemplate.Attributes.Add("class", "liActive");
        if (Cpage.Contains("mobianchor")) aMbAnchor.Attributes.Add("class", "liActive");
        if (Cpage.Contains("samplemobi")) aMbSampleMobi.Attributes.Add("class", "liActive");



        if (Cpage.Contains("bt=1")) aMbBtn1.Attributes.Add("class", "liActive");
        if (Cpage.Contains("bt=2")) aMbBtn2.Attributes.Add("class", "liActive");
        if (Cpage.Contains("bt=3")) aMbBtn3.Attributes.Add("class", "liActive");
        if (Cpage.Contains("bt=4")) aMbBtn4.Attributes.Add("class", "liActive");
        if (Cpage.Contains("bt=5")) aMbBtn5.Attributes.Add("class", "liActive");
        if (Cpage.Contains("bt=6")) aMbBtn6.Attributes.Add("class", "liActive");


        if (Session["LoggedInFrom"] != null)
        {
            string tmpLoggedINfrom = Session["LoggedInFrom"].ToString();

            lblDebug.ToolTip = tmpLoggedINfrom;

            if (tmpLoggedINfrom == "SMSSYSTEM_WPY")
            {
                dvSMSBizLink.Visible = false;
                
            }
            else if (tmpLoggedINfrom == "WEBPORTAL")
            {
                dvSMSBizLink.Visible = false;
                dvSMSsystemLink.Visible = false;
            }
            else if (tmpLoggedINfrom == "WESP")
            {
                dvSMSBizLink.Visible = false;
               
            }


            else if (tmpLoggedINfrom == "DPE")
            {
                dvSMSBizLink.Visible = false;
                HypSmsSystem.NavigateUrl = "~/Admin/Ad_Navigate4WebDPE.aspx";
                HypWebPortal.NavigateUrl = "~/Admin/Ad_WelcomeDPE.aspx";
                HypEmail.NavigateUrl = "~/Admin/Ads_EmailPageDPE.aspx"; 

            }

        }


    }
}

