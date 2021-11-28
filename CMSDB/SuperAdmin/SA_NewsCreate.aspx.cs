using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSv3.BAL;


public partial class SuperAdmin_SA_NewsCreate : System.Web.UI.Page 
{

    CMSv3.BAL.News objBAL_News = new CMSv3.BAL.News();

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrDisplayAtWebsite.Text = Resources.LangResources.DisplayatWebsite;
        tblMessageBar.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        //Get the form values
        string mNewsTitle = txtNewsTitle.Text;
        string mNewsContent = txtNewsContent.Text;
        //mNewsContent = mNewsContent.Replace(Environment.NewLine, "<br/>");
        mNewsContent = CommonFunctions.HandleNewLines(mNewsContent, Request.UserAgent);

        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage4Create");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);


        bool mNewsDisplayAtWebSite = chkActive.Checked;

        int inStatus = objBAL_News.InsertNewsData(mNewsTitle, mNewsContent, mNewsDisplayAtWebSite, Convert.ToInt32(Session["saUserID"]), mSelLanguage);

        if (inStatus > 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "News successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('News Item inserted Successfully')", true);
            Response.Redirect("SA_NewsListing.aspx?LgType=" + mSelLanguage);
            return;
        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the record. Please contant Administrator";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }



    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("SA_NewsListing.aspx");
    }
}

