using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EBAd_WPTraining : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        #region session check

        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 


        if(!IsPostBack)
        {
            int vID =3;
            String strPageID = string.Empty;

            if (Request.QueryString != null && Request.QueryString.Count > 0)
            {
                strPageID = Request.QueryString["qInfoId"].ToString();
            }

            if (strPageID != "")
            {
                vID = Convert.ToInt32(strPageID);
            }

            PopulateContent(vID);

           
        }


    }



    protected void PopulateContent(int qInfoID)
    {


        DataSet ds;
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

        ds = objEbook.WpTraining_ListByUID(qInfoID, "EDIT");

        
        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            DataRow drInfo;

            drInfo = dt.Rows[0];

            //txtInfoTitle.Text = drInfo["PageTitle"].ToString();
            //tmpInfoContent = drInfo["PageContent"].ToString();
            //tmpdisplayAtWeb = Convert.ToBoolean(drInfo["isDisplay"].ToString());

            //chkDisplayAtWeb.Checked = tmpdisplayAtWeb;

            lblContent.Text = drInfo["Content"].ToString();

        }
    }

}