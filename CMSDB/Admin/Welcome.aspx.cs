using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;
using CMSv3.Entities;


public partial class Admin_Welcome : BasePage
{

    CMSv3.BAL.User BALobjUser = new CMSv3.BAL.User();
//    SqlDataReader dbReader;
 //   DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 


        string mUserID = Session["UserID"].ToString();

        CMSv3.Entities.User objUser = new CMSv3.Entities.User();

        objUser = BALobjUser.GetUserDetailsByID(Convert.ToInt32(mUserID));

        if (objUser != null)
        {
            lblUserId.Text = Convert.ToString(objUser.UserId);
            lblLoginID.Text = objUser.LoginID;
            lblUserType.Text = objUser.UserType;
            lblCreatedDate.Text = Convert.ToString(objUser.CreatedDateTime);

        }

        LtrSessionTimeout.Text = Session.Timeout.ToString();
    }
}
