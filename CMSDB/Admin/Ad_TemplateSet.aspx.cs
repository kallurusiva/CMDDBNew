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

public partial class Admin_Ad_TemplateSet : BasePage
{
    string strSQL=string.Empty;
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    //SqlDataAdapter dbAdap;

    //DataSet ds;
    //DataTable dtTemplates;
    //DataTable dtSetTemplate;
    int TmpTemplateID;

    CMSv3.BAL.AccountSettings objBAL_AccountSettings = new CMSv3.BAL.AccountSettings();                      

    protected void Page_Load(object sender, EventArgs e)
    {
        TmpTemplateID = GetZero();

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
        ltrNoteLanguage.Text = "1. Web Template selection is available only for WEB30 Users ";   
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
                }
            }
            LoadTemplateInfo();
        }
    }

    private static int GetZero()
    {
        return 0;
    }

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


            if (dbMasterPageNameValue == "UserMaster.master")
            {
                TmpTemplateID = 1; 
                if (dbMasterCssName == "UserMaster_Orange.css")
                {
                    rdoWebTemplate1_Orange.Checked = true;
                }
                else if (dbMasterCssName == "UserMaster_Green.css")
                {
                    rdoWebTemplate1_green.Checked = true;
                }
                else if (dbMasterCssName == "UserMaster_Purple.css")
                {
                    rdoWebTemplate1_Purple.Checked = true;
                }
                else if (dbMasterCssName == "UserMaster_Red.css")
                {
                    rdoWebTemplate1_Red.Checked = true;
                }
                else
                {
                    rdoWebTemplate1.Checked = true;
                }
            }
            else if (dbMasterPageNameValue == "TmpMaster1.master")
            {

                //--- ********  --- template 2 ------- *********   --     
                TmpTemplateID = 2; 
                if (dbMasterCssName == "TmpStyleSheet2.css")
                {
                    rdoWebTemplate2.Checked = true;
                }
                else if (dbMasterCssName == "TmpMaster_Red.css")
                {
                    rdoWebTemplate2_Red.Checked = true;
                }
                else if (dbMasterCssName == "TmpMaster_Green.css")
                {
                    rdoWebTemplate2_Green.Checked = true;
                }
                else if (dbMasterCssName == "TmpMaster_Purple.css")
                {
                    rdoWebTemplate2_Purple.Checked = true;
                }
                else if (dbMasterCssName == "TmpMaster_Orange.css")
                {
                    rdoWebTemplate2_Orange.Checked = true;
                }
            }
            else if (dbMasterPageNameValue == "TmpMaster2.master")
            {
                //--- ********  --- template 3 ------- *********   --     
                TmpTemplateID = 3; 
                if (dbMasterCssName == "TmpStyleSheet3.css")
                {
                    rdoWebTemplate3.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet2x_Orange.css")
                {
                    rdoWebTemplate3_Orange.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet2x_Purple.css")
                {
                    rdoWebTemplate3_Purple.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet2x_Green.css")
                {
                    rdoWebTemplate3_Green.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet2x_Red.css")
                {
                    rdoWebTemplate3_Red.Checked = true;
                }
            }
            else if (dbMasterPageNameValue == "TmpMaster3.master")
            //--- ********  --- template 4 ------- *********   --     
            {
                TmpTemplateID = 4; 
                if (dbMasterCssName == "TmpStyleSheet3_Pink.css")
                {
                    rdoWebTemplate4_Pink.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet3_Olive.css")
                {
                    rdoWebTemplate4_Olive.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet3_Grey.css")
                {
                    rdoWebTemplate4_Grey.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet3_Brown.css")
                {
                    rdoWebTemplate4_Brown.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet3_Yellow.css")
                {
                    rdoWebTemplate4_Yellow.Checked = true;
                }

            }
            else if (dbMasterPageNameValue == "TmpMaster4.master")
            //--- ********  --- template 5 ------- *********   --     
            {
                TmpTemplateID = 5; 
                if (dbMasterCssName == "TmpStyleSheet4_Gold.css")
                {
                    rdoWebTemplate5_Gold.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet4_Magenta.css")
                {
                    rdoWebTemplate5_Magenta.Checked = true;
                }

                else if (dbMasterCssName == "TmpStyleSheet4_darkCyan.css")
                {
                    rdoWebTemplate5_darkCyan.Checked = true;
                }

                else if (dbMasterCssName == "TmpStyleSheet4.css")
                {
                    rdoWebTemplate5_Navy.Checked = true;
                }

                else if (dbMasterCssName == "TmpStyleSheet4_tomato.css")
                {
                    rdoWebTemplate5_tomato.Checked = true;
                }
            }
            else if (dbMasterPageNameValue == "TmpMaster5.master")
            //--- ********  --- Own Buttons template 5 ------- *********   --     
            {
                TmpTemplateID = 6; 
                if (dbMasterCssName == "TmpStyleSheet5_Gold.css")
                {
                    rdoWebTemplateOwnBtn_Gold.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet5_Magenta.css")
                {
                    rdoWebTemplateOwnBtn_Magenta.Checked = true;
                }

                else if (dbMasterCssName == "TmpStyleSheet5_darkCyan.css")
                {
                    rdoWebTemplateOwnBtn_DarkCyan.Checked = true;
                }

                else if (dbMasterCssName == "TmpStyleSheet5.css")
                {
                    rdoWebTemplateOwnBtn_Navy.Checked = true;
                }

                else if (dbMasterCssName == "TmpStyleSheet5_tomato.css")
                {
                    rdoWebTemplateOwnBtn_tomato.Checked = true;
                }

            }

            else if (dbMasterPageNameValue == "TmpMaster5AA.master")
            //--- ********  --- Own Buttons template 5 AA (WL : Without Languague Dropdown)------- *********   --     
            {
                TmpTemplateID = 7; 
                //if (dbMasterCssName == "TmpStyleSheet5_Gold.css")
                //{
                //    rdoWebTemplateOwnBtn_WL_Gold.Checked = true;
                //}
                //else if (dbMasterCssName == "TmpStyleSheet5_Magenta.css")
                //{
                //    rdoWebTemplateOwnBtn_WL_Magenta.Checked = true;
                //}

                //else if (dbMasterCssName == "TmpStyleSheet5_darkCyan.css")
                //{
                //    rdoWebTemplateOwnBtn_WL_Cyan.Checked = true;
                //}

                //else if (dbMasterCssName == "TmpStyleSheet5.css")
                //{
                //    rdoWebTemplateOwnBtn_WL_Navy.Checked = true;
                //}

                //else if (dbMasterCssName == "TmpStyleSheet5_tomato.css")
                //{
                //    rdoWebTemplateOwnBtn_WL_tomato.Checked = true;
                //}

            }


            else if (dbMasterPageNameValue == "TmpMaster6.master")
            //--- ********  --- Own Buttons template 6 ------- *********   --     
            {
                TmpTemplateID = 8; 
                if (dbMasterCssName == "TmpStyleSheet6_Gold.css")
                {
                    rdoWebTemplateOwnBtn2_Gold.Checked = true;
                }
                else if (dbMasterCssName == "TmpStyleSheet6_Magenta.css")
                {
                    rdoWebTemplateOwnBtn2_Magenta.Checked = true;
                }

                else if (dbMasterCssName == "TmpStyleSheet6_darkCyan.css")
                {
                    rdoWebTemplateOwnBtn2_Cyan.Checked = true;
                }

                else if (dbMasterCssName == "TmpStyleSheet6.css")
                {
                    rdoWebTemplateOwnBtn2_Navy.Checked = true;
                }

                else if (dbMasterCssName == "TmpStyleSheet6_tomato.css")
                {
                    rdoWebTemplateOwnBtn2_tomato.Checked = true;
                }

            }
            else
            {
                rdoWebTemplate1.Checked = true;

            }


            #region Disable templates which are not available for WEB10 Users 

            //...  Released all the templates all the users  :  Hari :  28-SEP-2011


            //if ((dbUserDomainType == "WEB10") || (dbUserDomainType == string.Empty))
            //{
            //    rdoWebTemplate2.Enabled = false;
            //    rdoWebTemplate2_Green.Enabled = false;
            //    rdoWebTemplate2_Orange.Enabled = false;
            //    rdoWebTemplate2_Purple.Enabled = false;
            //    rdoWebTemplate2_Red.Enabled = false;

            //    rdoWebTemplate1_Orange.Enabled = false;
            //    rdoWebTemplate1_green.Enabled = false;
            //    rdoWebTemplate1_Red.Enabled = false;
            //    rdoWebTemplate1_Purple.Enabled = false;

            //    rdoWebTemplate3.Enabled = false;
            //    rdoWebTemplate3_Green.Enabled = false;
            //    rdoWebTemplate3_Orange.Enabled = false;
            //    rdoWebTemplate3_Purple.Enabled = false;
            //    rdoWebTemplate3_Red.Enabled = false;

            //    rdoWebTemplate4_Brown.Enabled = false;
            //    rdoWebTemplate4_Grey.Enabled = false;
            //    rdoWebTemplate4_Olive.Enabled = false;
            //    rdoWebTemplate4_Pink.Enabled = false;
            //    rdoWebTemplate4_Yellow.Enabled = false;

            //    rdoWebTemplate5_tomato.Enabled = false;
            //    rdoWebTemplate5_Navy.Enabled = false;
            //    rdoWebTemplate5_Magenta.Enabled = false;
            //    rdoWebTemplate5_darkCyan.Enabled = false;
            //    rdoWebTemplate5_Gold.Enabled = false;

            //    rdoWebTemplateOwnBtn_tomato.Enabled = false;
            //    rdoWebTemplateOwnBtn_Navy.Enabled = false;
            //    rdoWebTemplateOwnBtn_Magenta.Enabled = false;
            //    rdoWebTemplateOwnBtn_DarkCyan.Enabled = false;
            //    rdoWebTemplateOwnBtn_Gold.Enabled = false;

            //    rdoWebTemplateOwnBtn2_tomato.Enabled = false;
            //    rdoWebTemplateOwnBtn2_Navy.Enabled = false;
            //    rdoWebTemplateOwnBtn2_Magenta.Enabled = false;
            //    rdoWebTemplateOwnBtn2_Cyan.Enabled = false;
            //    rdoWebTemplateOwnBtn2_Gold.Enabled = false;


          //  }
                


            #endregion



           

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
       
        
      
        if (rdoWebTemplate1_Orange.Checked == true)
        {
            mSelValue = "UserMaster.master";
            mCssvalue = "UserMaster_Orange.css";
        }
        else if (rdoWebTemplate1_green.Checked == true)
        {
            mSelValue = "UserMaster.master";
            mCssvalue = "UserMaster_green.css";
        }
        else if (rdoWebTemplate1_Purple.Checked == true)
        {
            mSelValue = "UserMaster.master";
            mCssvalue = "UserMaster_Purple.css"; 
        }
        else if (rdoWebTemplate1_Red.Checked == true)
        {
            mSelValue = "UserMaster.master";
            mCssvalue = "UserMaster_Red.css";
        }
        else if (rdoWebTemplate2.Checked == true)
        {
            mSelValue = "TmpMaster1.master";
            mCssvalue = "TmpStyleSheet2.css";
        }
        else if (rdoWebTemplate2_Orange.Checked == true)
        {
            mSelValue = "TmpMaster1.master";
            mCssvalue = "TmpMaster_Orange.css";
        }
        else if (rdoWebTemplate2_Green.Checked == true)
        {
            mSelValue = "TmpMaster1.master";
            mCssvalue = "TmpMaster_Green.css";
        }
        else if (rdoWebTemplate2_Purple.Checked == true)
        {
            mSelValue = "TmpMaster1.master";
            mCssvalue = "TmpMaster_Purple.css"; 
        }
        else if (rdoWebTemplate2_Red.Checked == true)
        {
            mSelValue = "TmpMaster1.master";
            mCssvalue = "TmpMaster_Red.css";
        }

        // ............. Template 3 ------------

        else if (rdoWebTemplate3.Checked == true)
        {
            mSelValue = "TmpMaster2.master";
            mCssvalue = "TmpStyleSheet3.css";
        }
        else if (rdoWebTemplate3_Green.Checked == true)
        {
            mSelValue = "TmpMaster2.master";
            mCssvalue = "TmpStyleSheet2x_Green.css";
        }
        else if (rdoWebTemplate3_Orange.Checked == true)
        {
            mSelValue = "TmpMaster2.master";
            mCssvalue = "TmpStyleSheet2x_Orange.css";
        }
        else if (rdoWebTemplate3_Purple.Checked == true)
        {
            mSelValue = "TmpMaster2.master";
            mCssvalue = "TmpStyleSheet2x_Purple.css";
        }
        else if (rdoWebTemplate3_Red.Checked == true)
        {
            mSelValue = "TmpMaster2.master";
            mCssvalue = "TmpStyleSheet2x_Red.css";
        }

        // ............. Template 4 ..............................


        else if (rdoWebTemplate4_Yellow.Checked == true)
        {
            mSelValue = "TmpMaster3.master";
            mCssvalue = "TmpStyleSheet3_Yellow.css";
        }
        else if (rdoWebTemplate4_Pink.Checked == true)
        {
            mSelValue = "TmpMaster3.master";
            mCssvalue = "TmpStyleSheet3_Pink.css";
        }
        else if (rdoWebTemplate4_Olive.Checked == true)
        {
            mSelValue = "TmpMaster3.master";
            mCssvalue = "TmpStyleSheet3_Olive.css";
        }
        else if (rdoWebTemplate4_Brown.Checked == true)
        {
            mSelValue = "TmpMaster3.master";
            mCssvalue = "TmpStyleSheet3_Brown.css";
        }
        else if (rdoWebTemplate4_Grey.Checked == true)
        {
            mSelValue = "TmpMaster3.master";
            mCssvalue = "TmpStyleSheet3_Grey.css";
        }

        // ............. Template 5 ..............................

        else if (rdoWebTemplate5_Gold.Checked == true)
        {
            mSelValue = "TmpMaster4.master";
            mCssvalue = "TmpStyleSheet4_Gold.css";
        }
        else if (rdoWebTemplate5_Magenta.Checked == true)
        {
            mSelValue = "TmpMaster4.master";
            mCssvalue = "TmpStyleSheet4_Magenta.css";
        }
        else if (rdoWebTemplate5_Navy.Checked == true)
        {
            mSelValue = "TmpMaster4.master";
            mCssvalue = "TmpStyleSheet4.css";
        }
        else if (rdoWebTemplate5_tomato.Checked == true)
        {
            mSelValue = "TmpMaster4.master";
            mCssvalue = "TmpStyleSheet4_tomato.css";
        }
        else if (rdoWebTemplate5_darkCyan.Checked == true)
        {
            mSelValue = "TmpMaster4.master";
            mCssvalue = "TmpStyleSheet4_darkCyan.css";
        }

             // ............. Own Button Template ..........................

        else if (rdoWebTemplateOwnBtn_Gold.Checked == true)
        {
            mSelValue = "TmpMaster5.master";
            mCssvalue = "TmpStyleSheet5_Gold.css";
        }
        else if (rdoWebTemplateOwnBtn_Magenta.Checked == true)
        {
            mSelValue = "TmpMaster5.master";
            mCssvalue = "TmpStyleSheet5_Magenta.css";
        }
        else if ( rdoWebTemplateOwnBtn_Navy.Checked == true)
        {
            mSelValue = "TmpMaster5.master";
            mCssvalue = "TmpStyleSheet5.css";
        }
        else if (rdoWebTemplateOwnBtn_tomato.Checked == true)
        {
            mSelValue = "TmpMaster5.master";
            mCssvalue = "TmpStyleSheet5_tomato.css";
        }
        else if (rdoWebTemplateOwnBtn_DarkCyan.Checked == true)
        {
            mSelValue = "TmpMaster5.master";
            mCssvalue = "TmpStyleSheet5_darkCyan.css";
        }


                 // ............. Own Button Template (WL) ..........................

        //else if (rdoWebTemplateOwnBtn_WL_Gold.Checked == true)
        //{
        //    mSelValue = "TmpMaster5AA.master";
        //    mCssvalue = "TmpStyleSheet5_Gold.css";
        //}
        //else if (rdoWebTemplateOwnBtn_WL_Magenta.Checked == true)
        //{
        //    mSelValue = "TmpMaster5AA.master";
        //    mCssvalue = "TmpStyleSheet5_Magenta.css";
        //}
        //else if (rdoWebTemplateOwnBtn_WL_Navy.Checked == true)
        //{
        //    mSelValue = "TmpMaster5AA.master";
        //    mCssvalue = "TmpStyleSheet5.css";
        //}
        //else if (rdoWebTemplateOwnBtn_WL_tomato.Checked == true)
        //{
        //    mSelValue = "TmpMaster5AA.master";
        //    mCssvalue = "TmpStyleSheet5_tomato.css";
        //}
        //else if (rdoWebTemplateOwnBtn_WL_Cyan.Checked == true)
        //{
        //    mSelValue = "TmpMaster5AA.master";
        //    mCssvalue = "TmpStyleSheet5_darkCyan.css";
        //}


              // ............. Own Button 2 Template ..........................

        else if (rdoWebTemplateOwnBtn2_Gold.Checked == true)
        {
            mSelValue = "TmpMaster6.master";
            mCssvalue = "TmpStyleSheet6_Gold.css";
        }
        else if (rdoWebTemplateOwnBtn2_Magenta.Checked == true)
        {
            mSelValue = "TmpMaster6.master";
            mCssvalue = "TmpStyleSheet6_Magenta.css";
        }
        else if (rdoWebTemplateOwnBtn2_Navy.Checked == true)
        {
            mSelValue = "TmpMaster6.master";
            mCssvalue = "TmpStyleSheet6.css";
        }
        else if (rdoWebTemplateOwnBtn2_tomato.Checked == true)
        {
            mSelValue = "TmpMaster6.master";
            mCssvalue = "TmpStyleSheet6_tomato.css";
        }
        else if (rdoWebTemplateOwnBtn2_Cyan.Checked == true)
        {
            mSelValue = "TmpMaster6.master";
            mCssvalue = "TmpStyleSheet6_darkCyan.css";
        }

        else
        {
            mSelValue = "UserMaster.master";
            mCssvalue = "CommonStyleSheet.css";
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
