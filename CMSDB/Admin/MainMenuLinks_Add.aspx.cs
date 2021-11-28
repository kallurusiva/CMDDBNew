using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CMSv3.BAL;

public partial class Admin_MainMenuLinks_Add : System.Web.UI.Page
{

    DataSet ds;
    CMSv3.BAL.AdminSettings objBAL_AdminSettings = new CMSv3.BAL.AdminSettings();


    protected void Page_Load(object sender, EventArgs e)
    {

        

        if (!IsPostBack)
        {

            ds = objBAL_AdminSettings.GetAll_TopmenuLinks();

            blstMenuLinks.DataSource = ds;
            blstMenuLinks.DataValueField = "LinkID";
            blstMenuLinks.DataTextField = "LinkName";
            blstMenuLinks.DataBind();
    }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //get the form values

        string mtxtMenuLinkName = txtMenuLinkName.Text;
        string mtxtMenuLinkUrl = txtMenuLinkURL.Text;



            int inStatus = objBAL_AdminSettings.Insert_MainMenuLInks(mtxtMenuLinkName, mtxtMenuLinkUrl, Convert.ToInt32(Session["UserID"]));

            // if inStatus = 1 inserted....  else LinkName already exists. .
            if (inStatus == 1)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Sucess.gif";
                //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
                lblErrMessage.Text = "Link Name successfully added";
                lblErrMessage.CssClass = "font_12Msg_Success";

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('New Link inserted Successfully')", true);
                //Response.Redirect("MainMenuLinks_Add.aspx");

                ds = objBAL_AdminSettings.GetAll_TopmenuLinks();

                blstMenuLinks.DataSource = ds;
                blstMenuLinks.DataValueField = "LinkID";
                blstMenuLinks.DataTextField = "LinkName";
                blstMenuLinks.DataBind();

                
                return;
            }
            else
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";
                //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
                lblErrMessage.Text = "Entered Link name already exists. Please enter another Link Name";
                lblErrMessage.CssClass = "font_12Msg_Success";

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Entered Link name already exists.')", true);
                //Response.Redirect("FaqListing.aspx");
                return;
            }



    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
