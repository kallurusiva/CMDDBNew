using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class EBAd_UserCategoryADD : System.Web.UI.Page
{


    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 

    protected void Page_Load(object sender, EventArgs e)
    {


        #region session check

        if (Session["UserID"] == null) 
        {
            if(Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 



        if (!IsPostBack)
        {

            //if (Session["LoggedInFrom"] != null)
            //    lblPgFrom.Text = Session["LoggedInFrom"].ToString(); 
            

            MaintainScrollPositionOnPostBack = true;
        }


    }


  


   




   

}