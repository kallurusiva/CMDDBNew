using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;

public partial class SuperAdmin_SA_FaqCreate : System.Web.UI.Page 
{

    CMSv3.BAL.FAQ objDAL_Faq = new CMSv3.BAL.FAQ();

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrDisplayAtWebsite.Text = Resources.LangResources.DisplayatWebsite;
                
        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 


        #region  // rendering Language links //  Commented Code 

        //string selectedLanguage = string.Empty;

        //string QryLanguage = Request.QueryString["Lang"];
        //if (QryLanguage == null || QryLanguage.ToString() == "")
        //{
        //    selectedLanguage = "en-US";
        //}
        //else
        //{
        //    selectedLanguage = QryLanguage;

        //}


        //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
        //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);





        //string CurrentPgName = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath);

        //ContentPlaceHolder cph = Page.Master.FindControl("ContentLeftMenu") as ContentPlaceHolder;
        //UserControl uc = (UserControl)cph.FindControl("SA_SideMenu_Faq1");

        //HyperLink HyFaqCreate = (HyperLink)uc.FindControl("Hyp_faqCreate");
        //HyFaqCreate.NavigateUrl = HyFaqCreate.NavigateUrl + "?Lang=" + selectedLanguage;

        //HyperLink HyFaqListing = (HyperLink)uc.FindControl("Hyp_faqListing");
        //HyFaqListing.NavigateUrl = HyFaqListing.NavigateUrl + "?Lang=" + selectedLanguage;


        //HyperLink HyEnglish = (HyperLink)uc.FindControl("Hyp_LgType_Eng");
        //HyEnglish.NavigateUrl = CurrentPgName + "?Lang=en-US";

        //HyperLink HyBahasa = (HyperLink)uc.FindControl("Hyp_LgType_Bms");
        //HyBahasa.NavigateUrl = CurrentPgName + "?Lang=ms-MY";

        //HyperLink HyChinese = (HyperLink)uc.FindControl("Hyp_LgType_Chi");
        //HyChinese.NavigateUrl = CurrentPgName + "?Lang=zh-CN";

        #endregion

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage4Create");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);

        if (mSelLanguage == 0)
            mSelLanguage = 1;



        //Get the form values and store them objEvent
        string mFaqQuestion = txtFaqQuestion.Text;
        string mFaqAnswer = txtFaqAnswer.Text;
        //mFaqAnswer = mFaqAnswer.ToString().Replace(Environment.NewLine, "<br/>");
        mFaqAnswer = CommonFunctions.HandleNewLines(mFaqAnswer, Request.UserAgent);
        bool isActive = chkActive.Checked;   

        int inStatus = objDAL_Faq.InsertFaqData(mFaqQuestion, mFaqAnswer, Convert.ToInt32(Session["saUserID"]), isActive, mSelLanguage);

        //String strSQL = "Insert into tblFaq (FaqQuestion,FaqAnswer,	UserID,	ModifiedBy,	Priority,	Active	) " +
        //                "Values ( N'" + mFaqQuestion + "',N'" + mFaqAnswer + "'," + Convert.ToInt32(Session["saUserID"]) + "," + Convert.ToInt32(Session["saUserID"]) + ",94,1)";


        //int inStatus;
        //SqlConnection dbConn;
        //SqlCommand dbCmd;

        //dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        //dbConn.Open();
        //dbCmd = new SqlCommand(strSQL, dbConn);
        //int rowCount = dbCmd.ExecuteNonQuery();

        //if (rowCount >= 1)
        //    inStatus = 1;
        //else
        //    inStatus = -1;
        


        if (inStatus == 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "News successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";
            
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('FAQ Item inserted Successfully')", true);
            Response.Redirect("SA_FaqListing.aspx?LgType=" + mSelLanguage);
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
        Server.Transfer("SA_FaqListing.aspx");
    }
}
