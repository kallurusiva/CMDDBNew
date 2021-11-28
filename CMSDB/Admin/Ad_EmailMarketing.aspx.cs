using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;

public partial class Admin_Ad_EmailMarketing : BasePage
{

   

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        ltrEmNote.Text = "Email marketing feature will be available soon.";
        ltrEmNote2.Text = "<b>NOTE :</b> Only Available for those who purchase WEB30 Own Domain";
    }

    

       
}
