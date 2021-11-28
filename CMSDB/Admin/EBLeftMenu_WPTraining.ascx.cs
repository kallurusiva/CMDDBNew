using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class EBLeftMenu_WPTraining : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet ds;
        
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();


        ds = objEbook.WpTraining_LeftMenu(); 

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable t1 = new DataTable();
            t1 = ds.Tables[0];

            foreach (DataRow dr in t1.Rows)
            {
                String strLbl = "lblLeft" + dr["Title"].ToString();
                String strHref1 = "EBAd_WpTraining.aspx?qInfoId=" + dr["UID"].ToString();
                menuItem.Controls.Add(new LiteralControl("<li><a href='" + strHref1 + "'><asp:Label ID='" + strLbl + "' runat='server'>" + dr["Title"].ToString() + "</asp:Label></a></li>"));
                
            }
        }
       
    }
}
