using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TopMostMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HypContactUs.Text = Resources.LangResources.ContactUs;
        HypHome.Text = Resources.LangResources.Home;
        HypFreeSMS.Text = Resources.LangResources.Free + " SMS " ;

        HypSMSlogin.Text = Resources.LangResources.CustomerLogin;
        HypPrepaid.Text = "Prepaid Login";

        //if (Session["MasterPageFile"] != null)
        //{

        //    if (Session["MasterPageFile"].ToString() == "TmpMaster4.master")
        //    {
        //        //HypCustLogin.Visible = false;
        //        imgCustLogin.Visible = false;
        //        HypFreeSMS.Visible = false;

        //    }
        //}

    }
}
