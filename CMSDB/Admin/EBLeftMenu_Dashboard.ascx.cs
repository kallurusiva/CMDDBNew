using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;

public partial class EBLeftMenu_Dashboard : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        DataSet ds = objEbook.Category_Load_ByUserID(Convert.ToInt32(Session["UserID"]), "2");

        //HypFranchiseEBooks.Visible = false;
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    HypFranchiseEBooks.Visible = true;
        //}

        if (ds.Tables[2].Rows.Count > 0)
        {
            DataRow URow = ds.Tables[2].Rows[0];

            if (URow["package"].ToString() == "0")
            {
                li101.Visible = false;
                li15.Visible = false;
                li16.Visible = false;
            }
            //if (URow["authorStatus"].ToString() == "0")
            //{
            //    li14.Visible = false;
            //}

        }

       
    }
}
