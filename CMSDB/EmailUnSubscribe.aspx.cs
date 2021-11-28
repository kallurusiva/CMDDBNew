using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class EmailUnSubscribe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.WassapTemplates_unsubscribe(txtEmail.Text.ToString());

        CommonFunctions.AlertMessage("Unsubscription done.");
    }
}