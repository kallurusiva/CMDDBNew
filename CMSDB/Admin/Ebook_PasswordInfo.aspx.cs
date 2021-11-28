using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Ebook_PasswordInfo : System.Web.UI.Page
{
    CMSv3.BAL.AccountSettings objBAL_ActSettings = new CMSv3.BAL.AccountSettings();
    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

    //DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"] == null))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        else if ((Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }

        #endregion

        #region Loading Global Resource values

        //LtrMyActSettings.Text = (string)GetGlobalResourceObject("LangResources", "MyAccount") + " " + (string)GetGlobalResourceObject("LangResources", "Settings") + "  (Website, MobileWeb and Contact Setting)";


        #endregion

        if (!IsPostBack)
        {

            

        }

    }
}