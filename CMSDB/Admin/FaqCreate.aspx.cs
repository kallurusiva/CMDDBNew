using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSv3.BAL;

public partial class Admin_FaqCreate : BasePage
{

    CMSv3.BAL.FAQ objDAL_Faq = new CMSv3.BAL.FAQ();

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrLanguage.Text = Resources.LangResources.Language;

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        //Session.Abandon();
        //Session.Clear();

        LtrDispWebsite.Text = Resources.LangResources.DisplayatWebsite;

        if (Session["UserDomainType"].ToString() == "EBOOK")
        {
            trSelLanguage.Visible = false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //lblTest.Text = "Tested";


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



        //Get the form values and store them objEvent
        string mFaqQuestion = txtFaqQuestion.Text;
        string mFaqAnswer = txtFaqAnswer.Text;
        //mFaqAnswer = mFaqAnswer.ToString().Replace(Environment.NewLine, "<br/>");
        mFaqAnswer = CommonFunctions.HandleNewLines(mFaqAnswer, Request.UserAgent);
        bool mFaqDisplay = chkDisplaAtWeb.Checked;

        int inStatus = objDAL_Faq.InsertFaqData(mFaqQuestion, mFaqAnswer, Convert.ToInt32(Session["UserID"]), mFaqDisplay, mSelLanguage);


        if (inStatus == 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "News successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";
            
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('FAQ Item inserted Successfully')", true);
            Response.Redirect("FaqListing.aspx");
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
        Server.Transfer("FaqListing.aspx");
    }
}
