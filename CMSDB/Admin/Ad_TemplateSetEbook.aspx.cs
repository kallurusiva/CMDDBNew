using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;

public partial class Admin_Ad_TemplateSetEbook : BasePage
{
    string strSQL=string.Empty;
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
//    SqlDataAdapter dbAdap;

 //   DataSet ds;
 //   DataTable dtTemplates;
 //   DataTable dtSetTemplate;
    //int TmpTemplateID=0;

    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();                      

    protected void Page_Load(object sender, EventArgs e)
    {


        #region  // SessionCheck
        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 



        #region Code to Hide Left ContentHolder

        //HtmlGenericControl myDivLeftBar;
        //myDivLeftBar = (HtmlGenericControl)Page.Master.FindControl("divLeftBar");

        //myDivLeftBar.Style.Clear();
        //myDivLeftBar.Style.Value = "width:0px;";


        //HtmlGenericControl myDivRightBar;
        //myDivRightBar = (HtmlGenericControl)Page.Master.FindControl("divRightBar");

        //myDivRightBar.Style.Clear();
        //myDivRightBar.Style.Value = " width: 96%; padding-left:20px;";

        #endregion

        ltrSetDefaultTemplate.Text = Resources.LangResources.Set + " " + "Default Template";
        ltrNoteLanguage.Text = "";
        
                               
        ltrNote.Text = Resources.LangResources.Note;

        if((Session.SessionID != null) && (Session["UserID"] != null))
        lblSessionValues.Text = Session.SessionID + " | " + Session["UserID"].ToString();

        if (!IsPostBack)
        {
            if (Request.QueryString["LangChanged"] != null)
            {
                if(Request.QueryString["LangChanged"] == "true")
                {
                   Page.ClientScript.RegisterClientScriptBlock(GetType(), "SetLanguage", "alert('Note: You have Changed your default Language setting \\n\\n All the Buttons and correponding text would appear in Selected Language')", true);
                   // Page.ClientScript.RegisterClientScriptBlock(GetType(), "SetLanguage", "alert('Selected Language')", true);
              
                }
            }
            LoadTemplateInfo();
           // LoadTopRowRowLinks(TmpTemplateID); 
        }

    }


    //protected void LoadTopRowRowLinks(int vTemplateID)
    //{

    //   //ds = objBAL_AccountSettings.RetrieveALL_Settings_HomePage_Defaults(Convert.ToInt32(Session["UserID"]));

    //    ds = objBAL_AccountSettings.Retrieve_Settings_TopRowLinks(Convert.ToInt32(Session["UserID"]));


    //   DataTable dtTopRowLinks = ds.Tables[0];
    //   DataTable dtUserSelTopRowLinks = ds.Tables[1];

        
    //    //...Top Menu Links... 
    //   chkTopRowBtnList.DataSource = dtTopRowLinks;
    //   chkTopRowBtnList.DataTextField = "LinkName";
    //   chkTopRowBtnList.DataValueField = "LinkID";
    //   chkTopRowBtnList.DataBind();

    //   string mTopRowLinks = string.Empty;


    //    if (dtUserSelTopRowLinks.Rows.Count > 0)
    //    {
    //         DataRow uRow = (DataRow)dtUserSelTopRowLinks.Rows[0];

    //         mTopRowLinks = uRow["TopRowLinksToShow"].ToString();
    //    }
    //    else
    //    {
    //        mTopRowLinks = "1,2,3,4,5";
    //    }
 
      

    //   string[] TopRowLinksArray = mTopRowLinks.Split(',');


    //   foreach (ListItem ckL in chkTopRowBtnList.Items)
    //    {
    //        if (TopRowLinksArray.Contains(ckL.Value))
    //        {
    //            ckL.Selected = true;
    //        }

    //    }

    //}

    protected void LoadTemplateInfo()
    {

        string dbMasterPageNameValue = string.Empty;
        string dbUserDomainType = string.Empty;
        string dbMasterCssName = string.Empty;


        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            strSQL = "select MasterPageID, MasterPageName,MasterCSS, M.UserID, UserDomainType from tblUserMasterPage M " +
                      " Left Outer join tblUsers U on U.UserID = M.USerID " + 
                         " where M.UserId =" + Convert.ToInt32(Session["UserID"]);
            

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    dbMasterPageNameValue = dbReader["MasterPageName"].ToString();
                    dbMasterCssName = dbReader["MasterCSS"].ToString();
                    dbUserDomainType = dbReader["UserDomainType"].ToString();
                }
            }


            if (dbMasterPageNameValue == "TmpMasterGen1.master")
            //--- ********  --- ebook template 1 ------- *********   --     
            {
                //TmpTemplateID = 1; 
                if (dbMasterCssName == "TmpStyleSheet6_Gold.css")
                {
                    rdoWebTemplate1_Gold.Checked = true; 
                }
                else if (dbMasterCssName == "TmpStyleSheet6_Magenta.css")
                {
                    rdoWebTemplate1_Magenta.Checked = true; 
                }

                else if (dbMasterCssName == "TmpStyleSheet6_darkCyan.css")
                {
                    rdoWebTemplate1_darkCyan.Checked = true; 
                }

                else if (dbMasterCssName == "TmpStyleSheet6.css")
                {
                    rdoWebTemplate1_Navy.Checked = true; 
                }

                else if (dbMasterCssName == "TmpStyleSheet6_tomato.css")
                {
                    rdoWebTemplate1_tomato.Checked = true; 
                }

            }

            //else if (dbMasterPageNameValue == "TmpMasterGen2.master")
            ////--- ********  --- Own Buttons template 6 ------- *********   --     
            //{
            //    TmpTemplateID = 2; 
            //    if (dbMasterCssName == "TmpStyleSheet6_Gold.css")
            //    {
            //        rdoWebTemplate2_Gold.Checked = true; 
            //    }
            //    else if (dbMasterCssName == "TmpStyleSheet6_Magenta.css")
            //    {
            //        rdoWebTemplate2_Magenta.Checked = true;  
            //    }

            //    else if (dbMasterCssName == "TmpStyleSheet6_darkCyan.css")
            //    {
            //        rdoWebTemplate2_darkCyan.Checked = true;  
            //    }

            //    else if (dbMasterCssName == "TmpStyleSheet6.css")
            //    {
            //        rdoWebTemplate2_Navy.Checked = true; 
            //    }

            //    else if (dbMasterCssName == "TmpStyleSheet6_tomato.css")
            //    {
            //        rdoWebTemplate2_tomato.Checked = true; 
            //    }

            //}
            else
            {
                rdoWebTemplate1_tomato.Checked = true; 

            }


            



           

            //rdoBtnList_Templates.DataSource = dtTemplates;
            //rdoBtnList_Templates.DataTextField = "MasterPageName";
            //rdoBtnList_Templates.DataValueField = "MasterPageName";
            //rdoBtnList_Templates.DataBind();


            //foreach (ListItem ckL in rdoBtnList_Templates.Items)
            //{
            //    if (ckL.Value == tmpSetTemplate)
            //    {
            //        ckL.Selected = true;
            //    }

            //}



        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }


    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        string mSelValue = string.Empty;
        string mCssvalue = string.Empty;
       
        
      

       
            
               

              // ............. Ebook Template 1..........................

        if (rdoWebTemplate1_Gold.Checked == true)
        {
            mSelValue = "TmpMasterGen1.master";
            mCssvalue = "TmpStyleSheet6_Gold.css";
        }
        else if (rdoWebTemplate1_Magenta.Checked == true)
        {
            mSelValue = "TmpMasterGen1.master";
            mCssvalue = "TmpStyleSheet6_Magenta.css";
        }
        else if (rdoWebTemplate1_Navy.Checked == true)
        {
            mSelValue = "TmpMasterGen1.master";
            mCssvalue = "TmpStyleSheet6.css";
        }
        else if (rdoWebTemplate1_tomato.Checked == true)
        {
            mSelValue = "TmpMasterGen1.master";
            mCssvalue = "TmpStyleSheet6_tomato.css";
        }
        else if (rdoWebTemplate1_darkCyan.Checked == true)
        {
            mSelValue = "TmpMasterGen1.master";
            mCssvalue = "TmpStyleSheet6_darkCyan.css";
        }

        // ............. Ebook 2 Template ..........................

        //else if (rdoWebTemplate2_Gold.Checked == true)
        //{
        //    mSelValue = "TmpMasterGen2.master";
        //    mCssvalue = "TmpStyleSheet6_Gold.css";
        //}
        //else if (rdoWebTemplate2_Magenta.Checked == true)
        //{
        //    mSelValue = "TmpMasterGen2.master";
        //    mCssvalue = "TmpStyleSheet6_Magenta.css";
        //}
        //else if (rdoWebTemplate2_Navy.Checked == true)
        //{
        //    mSelValue = "TmpMasterGen2.master";
        //    mCssvalue = "TmpStyleSheet6.css";
        //}
        //else if (rdoWebTemplate2_tomato.Checked == true)
        //{
        //    mSelValue = "TmpMasterGen2.master";
        //    mCssvalue = "TmpStyleSheet6_tomato.css";
        //}
        //else if (rdoWebTemplate2_darkCyan.Checked == true)
        //{
        //    mSelValue = "TmpMasterGen2.master";
        //    mCssvalue = "TmpStyleSheet6_darkCyan.css";
        //}
        else
        {
            mSelValue = "TmpMasterGen1.master";
            mCssvalue = "TmpStyleSheet6_tomato.css";
        }



        
        
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            //strSQL = "select LangID,LangCode, LangName,LangCulture from tblLanguages where Deleted = 0 ;";
            //strSQL = strSQL + "select LanguageCode from tblHomePageSettings where UserId =" + Convert.ToInt32(Session["UserID"]);

            strSQL = "Update [tblUserMasterPage] set MasterPageName = '" + mSelValue + "', MasterCSS = '" +
                     mCssvalue + "'where UserID = " + Convert.ToInt32(Session["UserID"]);
            dbCmd = new SqlCommand(strSQL, dbConn);
            int upStatus = dbCmd.ExecuteNonQuery();

            Session["MasterPageFile"] = mSelValue;
            Session["MasterPageCss"] = mCssvalue;
           
            //Page.ClientScript.RegisterClientScriptBlock(GetType(), "SetLanguage", "alert('Note: You are Changed the default Language \n\n All the Buttons and correponding text would appear in Selected Language');", true);
                        
           // Response.Redirect("Ad_TemplateSett.aspx?LangChanged=true");

            if (upStatus >= 1 )
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Sucess.gif";
                lblErrMessage.Text = "Web Template Changed Successfully. The Changes would be visible on your next visit to the web page.";
                lblErrMessage.CssClass = "font_12Msg_Success";
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
