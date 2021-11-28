using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSv3.BAL;


public partial class Admin_NewsCreate : BasePage
{

    CMSv3.BAL.News objBAL_News = new CMSv3.BAL.News();

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrLanguage.Text = Resources.LangResources.Language;

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        LtrDispWebsite.Text = Resources.LangResources.DisplayatWebsite.ToUpperInvariant();

        tblMessageBar.Visible = false;
        if (Session["UserDomainType"].ToString() == "EBOOK")
        {
            trSelLanguage.Visible = false;
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        //Get the form values
        string mNewsTitle = txtNewsTitle.Text;
        string mNewsContent = txtNewsContent.Text;
        //mNewsContent = mNewsContent.Replace(Environment.NewLine, "<br/>");
        mNewsContent = CommonFunctions.HandleNewLines(mNewsContent, Request.UserAgent);
        bool mNewsDisplay = chkDisplaAtWeb.Checked;

        

         int mSelLanguage = 0;
         if (Session["UserDomainType"].ToString() == "EBOOK")
         {
             mSelLanguage = 1;
         }
         else
         {

             //-- accessing the Selected Language 
             ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
             UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage4Create");
             DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
             mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);
         }

        if (mSelLanguage == 0)
            mSelLanguage = 1;


        int inStatus = objBAL_News.InsertNewsData(mNewsTitle, mNewsContent, mNewsDisplay, Convert.ToInt32(Session["UserID"]), mSelLanguage);

        if (inStatus >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "News successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('News Item inserted Successfully')", true);
            Response.Redirect("NewsListing.aspx?LgType=" + mSelLanguage);
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
        Server.Transfer("NewsListing.aspx");
    }
}

