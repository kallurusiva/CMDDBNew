using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using CMSv3.BAL;
using System.Threading;
using System.Configuration;

public partial class BillPlzReturn : System.Web.UI.Page
{

    string DomainVal;

    protected void Page_Load(object sender, EventArgs e)
    {
        string TID = Request.QueryString["TID"].ToString();

        newDBS ndbs = new newDBS();
        DataSet dstUser = ndbs.BillPlz_getReturnValues(TID.ToString());
        if (dstUser.Tables[0].Rows.Count > 0)
        {
            lblBookID.Text  = dstUser.Tables[0].Rows[0]["ProductCode"].ToString();
            lblBookName.Text  = dstUser.Tables[0].Rows[0]["ProductDesciption"].ToString();
            lblTxDetails.Text = dstUser.Tables[0].Rows[0]["BillId"].ToString();
            //lblPytMade.Text = dstUser.Tables[0].Rows[0]["Denomination"].ToString() + " " + dstUser.Tables[0].Rows[0]["Charges"].ToString();
            lblPytMade.Text = "RM " + dstUser.Tables[0].Rows[0]["Charges"].ToString();
            DomainVal = dstUser.Tables[0].Rows[0]["domain"].ToString();
        }

    }

    protected void lnkToWebsite_Click(object sender, EventArgs e)
    {
        Response.Redirect(DomainVal);
    }
}