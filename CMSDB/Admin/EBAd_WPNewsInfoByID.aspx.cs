using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EBAd_WPNewsInfoByID : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



        if (!IsPostBack)
        {
            DataSet ds;
            CMSv3.BAL.eBook ObjEbook = new CMSv3.BAL.eBook(); 


            lblStatementTitle.Text = "Latest News";
            ButtonClose.Attributes.Add("OnClick", "javascript:CloseWindow()");

            int sNewsId = Convert.ToInt32(Request.QueryString["NewsId"].ToString());

            ds = ObjEbook.WpNews_ListByUID(sNewsId, "EDIT"); 


            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow utRow = ds.Tables[0].Rows[0];

                lblTitleNews.Text = utRow["Title"].ToString();
                lblNewsFull.Text = utRow["Content"].ToString();
                lblDate1.Text = "posted on&nbsp;" + utRow["DateCreated"].ToString();
            }
        }


    }
}