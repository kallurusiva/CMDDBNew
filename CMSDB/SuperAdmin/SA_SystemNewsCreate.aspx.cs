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

public partial class SuperAdmin_SA_SystemNewsCreate : System.Web.UI.Page 
{

    string strSQL = string.Empty;
    SqlConnection dbConn;
    SqlCommand dbCmd;
    //SqlDataAdapter dbAdap;
    SqlDataReader dbReader;

    //DataSet ds;
    //DataView dv;



    CMSv3.BAL.FAQ objDAL_Faq = new CMSv3.BAL.FAQ();

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrDisplayAtWebsite.Text = Resources.LangResources.DisplayatWebsite;
        ltrSystemNews.Text = "System " + Resources.LangResources.News;
        ltrSysContent.Text = Resources.LangResources.Content;
        ltrSysSubject.Text = Resources.LangResources.subject;
                
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

        string mSysSubject = txtSysSubject.Text;
        string mSysContent = txtSysContent.Text;
        //mSysContent = mSysContent.ToString().Replace(Environment.NewLine, "<br/>");
        mSysContent = CommonFunctions.HandleNewLines(mSysContent, Request.UserAgent);
        bool isActive = chkActive.Checked;   

        //int inStatus = objDAL_Faq.InsertFaqData(mFaqQuestion, mFaqAnswer, Convert.ToInt32(Session["saUserID"]), isActive, mSelLanguage);

        strSQL = "EXEC [usp_SystemNews_InsertData] '" + mSysSubject + "','" + mSysContent + "'," + Convert.ToInt32(Session["saUserID"]) + "," + isActive + "," + mSelLanguage;
       
 
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();
        dbCmd = new SqlCommand(strSQL, dbConn);
        int rowCount = dbCmd.ExecuteNonQuery();


        if (rowCount >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "News successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";
            
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('FAQ Item inserted Successfully')", true);
            Response.Redirect("SA_SystemNewsListing.aspx?LgType=" + mSelLanguage);
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
        Server.Transfer("SA_SystemNewsListing.aspx");
    }


    protected void btnSaveSend_Click(object sender, EventArgs e)
    {

        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage4Create");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);

        if (mSelLanguage == 0)
            mSelLanguage = 1;



        //Get the form values and store them objEvent

        string mSysSubject = txtSysSubject.Text;
        string mSysContent = txtSysContent.Text;
        mSysContent = mSysContent.ToString().Replace(Environment.NewLine, "<br/>");
        bool isActive = chkActive.Checked;

        //int inStatus = objDAL_Faq.InsertFaqData(mFaqQuestion, mFaqAnswer, Convert.ToInt32(Session["saUserID"]), isActive, mSelLanguage);

        strSQL = "EXEC [usp_SystemNews_InsertData] '" + mSysSubject + "','" + mSysContent + "'," + Convert.ToInt32(Session["saUserID"]) + "," + isActive + "," + mSelLanguage;


        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();
        dbCmd = new SqlCommand(strSQL, dbConn);
        int rowCount = dbCmd.ExecuteNonQuery();


        if (rowCount >= 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "News successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

            //Send Email to Selected Users (WEB 10 / WEB 30)
            fnSendEmail_SystemNews(mSysSubject,mSysContent, chkWEB10.Checked, chkWEB30.Checked);



            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('FAQ Item inserted Successfully')", true);
            Response.Redirect("SA_SystemNewsListing.aspx?LgType=" + mSelLanguage);
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



    protected void fnSendEmail_SystemNews(string vSubject, string vSystemNews, bool WEB10chk, bool WEB30chk)
    {

        if((WEB10chk) || (WEB30chk))
        {

            //Form the Email variables. 

            string vAdmin_Emailfrom = "Administrator@" + GlobalVar.GetAnchorDomainName;
            //string vAdmin_EmailFullName = "Administrator";
            
            string vAdmin_EmailSubject = "System News from : " + GlobalVar.GetAnchorDomainName;

            string vUser_Email = string.Empty;
            string vUser_Name = string.Empty;
            string vUSer_EmailBody = string.Empty;
            
            //Get the list of All Users EmailAddress and Names, 
            string strSQL = string.Empty;
            strSQL = "Select FullName, Email from TblUserDetails UD INNER JOIN tblUsers U ON U.UserId = UD.UserId ";


            if ((WEB10chk) && (WEB30chk))
            {
                strSQL = strSQL + " Where (U.UserDomainType = 'WEB30' OR U.UserDomainType = 'WEB10')";

            }
            else if (WEB30chk)
            {
                strSQL = strSQL + " Where U.UserDomainType = 'WEB30'";
            }
            else if (WEB10chk)
            {
                strSQL = strSQL + " Where U.UserDomainType = 'WEB10'";
            }

            //strSQL = strSQL + " and UD.Email = 'msri_hari@yahoo.com' ";

            try
            {
                dbConn = new SqlConnection(GlobalVar.GetDbConnString);
                dbConn.Open();
                dbCmd = new SqlCommand(strSQL, dbConn);
                dbReader = dbCmd.ExecuteReader();

                if (dbReader.HasRows)
                {
                    while (dbReader.Read())
                    {

                         vUSer_EmailBody = "<br><br>" +
                        "<div>" +
                        "<table border='0' cellpadding='5' cellspacing='1' width='100%'>"  +
                        "<tr><td><font class='font_12BlueBold'>" + vSubject + "</font>" +
                        "</td></tr>" + 
                        "<tr><td>&nbsp;</td></tr>" + 
                        "</table>" + 
                        "<table border='0' cellpadding='5' cellspacing='1' width='100%' class='stdtableBorder_Search'>" +
                        "<tr><td>&nbsp;</td></tr>" +
                        "<tr><td>" + vSystemNews + "</td></tr>" +
                        "<tr><td>&nbsp;</td></tr>" +
                        "</table></div>" +
                        "<br><br>";

                         vUser_Name = dbReader["FullName"].ToString();
                         vUser_Email = dbReader["Email"].ToString();

                         MyMail.CommonSendEmail(vUser_Email, vAdmin_Emailfrom, vUSer_EmailBody, vAdmin_EmailSubject, vUser_Name, "", "fromSystemNEWS");
                        //MyMail.CommonSendEmail(vemailto, vemailfrom, vemailbody, vemsubject, vemfullname, f1, f2);


                    }
                }






            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }




        }


    }
}
