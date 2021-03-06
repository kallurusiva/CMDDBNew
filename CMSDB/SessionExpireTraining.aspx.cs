using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SessionExpireTraining : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Remove("UserID");
        Session.RemoveAll();

        CommonFunctions.AlertMessageAndRedirect("Session Expired. Please Login again.", "http://www.partnertraining.club");
    }
}