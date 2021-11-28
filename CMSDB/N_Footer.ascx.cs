using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class N_Footer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        newDBS ndbsMY = new newDBS();
        DataSet dstMY = ndbsMY.get_DomainDetails(Session["ClientID"].ToString());
        string domainVal = string.Empty;

        if (dstMY.Tables[0].Rows.Count > 0)
        {
            DataRow nrow = dstMY.Tables[0].Rows[0];
            domainVal = nrow["domainName"].ToString();
        }
        else
        {
            domainVal = "worldDigitalBiz.com";
        }
        dName.Text = domainVal.ToString();
    }
}