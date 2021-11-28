using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;

public partial class Admin_LeftMenu_INFO : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
        DataSet ds;

        CMSv3.BAL.Products objBAL_Products = new CMSv3.BAL.Products();

        if (!IsPostBack)
        {

            StringBuilder sb = new StringBuilder(); 

            sb.AppendLine("<div id='leftmenu'>"); 
            sb.AppendLine("<ul>");
            sb.AppendLine("<li><span class='header'><img src='../Images/WebPortal/Products.png' /> INFO </span></li>"); 
          
            ds = objBAL_Products.INFO_RetrieveAll(101,"ACTIVE");


            int mInfoID = 0; 
            String mInfoTitle = string.Empty; 
            int BtnCnt = 1; 

            if (ds.Tables[0].Rows.Count > 0)
            {

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    mInfoID = Convert.ToInt32(dr["infoID"].ToString()); 
                    mInfoTitle = dr["infoTitle"].ToString();

                    sb.AppendLine("<li> <a ID='HypInfoLink" + BtnCnt + "' Class='LiCon listing' href='Ad_INFOListing.aspx?qINFOid=" + mInfoID + "'>" + mInfoTitle  + "</a> </li>");
                    BtnCnt += 1; 
                }
            }

            sb.AppendLine("</ul>");
            sb.AppendLine("</div>"); 

            dvInfoItems.InnerHtml = sb.ToString(); 


        }





    
    }
}
