using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_SMS_EbAd_CreditCharges : System.Web.UI.Page
{
    DataSet ds;
    DataView dv;

    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        if(!IsPostBack)
        {
            Populate_CreditCharges();
        }
    }

    protected void Populate_CreditCharges()
    {
        ds = objMalaysia.Retrieve_CreditCardCharges();

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;

            GridViewCreditCharges.DataSource = dv;
            GridViewCreditCharges.DataBind();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {

            dv = ds.Tables[1].DefaultView;

            GridViewCreditBaseCharges.DataSource = dv;
            GridViewCreditBaseCharges.DataBind();
        }
    }    
}
