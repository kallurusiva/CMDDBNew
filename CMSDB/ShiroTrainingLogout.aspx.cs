using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShiroTrainingLogout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string returnURL = string.Empty;

        Session.Abandon();
        Session.RemoveAll();
        Session.Clear();

        Session["UserID"] = string.Empty;

        if (Session["referringURL"] != null)
        {
            Response.Write(Session["referringURL"].ToString());
        }
        else
        {
            Response.Redirect("http://www.PartnerTraining.club/ShiroTraining.aspx");
        }
    }
}
