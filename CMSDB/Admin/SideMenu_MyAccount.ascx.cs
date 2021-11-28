using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SideMenu_MyAccount : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        LtrMngMyAccount.Text = (string)GetGlobalResourceObject("LangResources", "ManageMyAccount");
        LtrVwMyAct.Text = (string)GetGlobalResourceObject("LangResources", "View") + " " + (string)GetGlobalResourceObject("LangResources", "MyAccount");


        //if (Session["MobileLoginID"] != null)
        //{
        //    ImgChangePwd.Visible = false;
        //    HypChangePassword.Visible = false;
        //}
        //else
        //{
        //    ImgChangePwd.Visible = true;
        //    HypChangePassword.Visible = true;
        //}

    }
}
