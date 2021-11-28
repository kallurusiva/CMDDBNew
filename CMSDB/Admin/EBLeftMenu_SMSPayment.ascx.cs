using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class Admin_EBLeftMenu_SMSPayment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // String Cpage = Request.RawUrl.ToLower();

        //if (Cpage.Contains("feature")) aEBFeatureBuy.Attributes.Add("class", "liActive");


        if (Session["UserDomainType"] != null)
        {
            String tmpUserType = Session["UserDomainType"].ToString();


        }
    }
}