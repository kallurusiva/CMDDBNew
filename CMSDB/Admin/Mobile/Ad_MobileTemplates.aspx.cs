using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.Sql; 
using System.Data.SqlClient;

public partial class Admin_Ad_MobileTemplates : System.Web.UI.Page
{
    DataSet ds;
    //DataTable dtButtons;
    DataTable dtTemplates;

    
    CMSv3.BAL.MbMain objMb = new CMSv3.BAL.MbMain(); 

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        //Page.MaintainScrollPositionOnPostBack = true;
        #region Code to Hide Menu buttons for WebPortal

        //HtmlTableRow tr1 = (HtmlTableRow)Master.FindControl("MROW1");
        //tr1.Visible = false;


        //HtmlTableRow tr2 = (HtmlTableRow)Master.FindControl("MROW2");
        //tr2.Visible = false;

        //HtmlTableRow tr3 = (HtmlTableRow)Master.FindControl("MROW3");
        //tr3.Visible = false;

        //HtmlContainerControl tmpDivHeader = (HtmlContainerControl)Master.FindControl("headercontent");
        //tmpDivHeader.Attributes.Add("height", "80px");

        #endregion



        #region to hide left contentplaceholder

        HtmlGenericControl myDivLeftBar;
        myDivLeftBar = (HtmlGenericControl)Page.Master.FindControl("divLeftBar");

        myDivLeftBar.Style.Clear();
        myDivLeftBar.Style.Value = "width:0px;";


        HtmlGenericControl myDivRightBar;
        myDivRightBar = (HtmlGenericControl)Page.Master.FindControl("divRightBar");

        myDivRightBar.Style.Clear();
        myDivRightBar.Style.Value = " width: 96%; padding-left:20px;";

        #endregion

        if (!IsPostBack)
        {
            LoadTemplateInfo();
           // RenderButtonSelections(); 
            

        }

    }



    protected void LoadTemplateInfo()
    {

        //..retrieving the user selected buttons 

        ds = objMb.Retrieve_SelectedTemplate(Convert.ToInt32(Session["UserID"].ToString()));
        dtTemplates = ds.Tables[0];
        

        //..looping thru table to get the selected buttons CSV string.. 
        String TemplateCSSstr = string.Empty;
        
        foreach (DataRow dtRow in dtTemplates.Rows)
        {
            TemplateCSSstr = dtRow["TemplateCSS"].ToString();
        }

        //string testStr = "7";

        //bool vals = csvSelButtonStr.Contains(testStr);

        if ((TemplateCSSstr == null) || (TemplateCSSstr == ""))
            TemplateCSSstr = "mbAncButtons_t11.css";


        switch (TemplateCSSstr)
        {
                /*
            case "mbStyleButtons.css": rdoMobiTmp1_Blue.Checked = true;  break;
            case "mbStyleButtons_t2.css": rdoWebTemplate1_Red.Checked = true; break;
            case "mbStyleButtons_t3.css": rdoWebTemplate1_Green.Checked = true; break;
            case "mbStyleButtons_t4.css": rdoWebTemplate1_Orange.Checked = true; break;
            case "mbStyleButtons_t5.css": rdoWebTemplate1_Purple.Checked = true; break;
                 */
                /*
            case "mbStyleButtons_t6.css": rdoWebTemplate2_Green.Checked = true; break;
            case "mbStyleButtons_t7.css": rdoWebTemplate2_Maroon.Checked = true; break;
            case "mbStyleButtons_t8.css": rdoWebTemplate2_Orange.Checked = true; break;
            case "mbStyleButtons_t9.css": rdoWebTemplate2_Navy.Checked = true; break;
            case "mbStyleButtons_t10.css": rdoWebTemplate2_Purple.Checked = true; break;
            */
            case "mbAncButtons_t11.css": rdoWebTemplate3_Grey.Checked = true; break;
            case "mbAncButtons_t12.css": rdoWebTemplate3_Green.Checked = true; break;
            case "mbAncButtons_t13.css": rdoWebTemplate3_Red.Checked = true; break;
            case "mbAncButtons_t14.css": rdoWebTemplate3_Blue.Checked = true; break;
            case "mbAncButtons_t15.css": rdoWebTemplate3_Orange.Checked = true; break;

            //case "mbAncButtons_t16.css": rdoWebTemplate4_Red.Checked = true; break;
            //case "mbAncButtons_t17.css": rdoWebTemplate4_Grey.Checked = true; break;
            //case "mbAncButtons_t18.css": rdoWebTemplate4_Orange.Checked = true; break;
            //case "mbAncButtons_t19.css": rdoWebTemplate4_Green.Checked = true; break;
            //case "mbAncButtons_t20.css": rdoWebTemplate4_Blue.Checked = true; break;

            //case "mbAncButtons_t21.css": rdoWebTemplate5_Blue.Checked = true; break;
            //case "mbAncButtons_t22.css": rdoWebTemplate5_Green.Checked = true; break;
            //case "mbAncButtons_t23.css": rdoWebTemplate5_Windows.Checked = true; break;
            //case "mbAncButtons_t24.css": rdoWebTemplate5_Orange.Checked = true; break;
            //case "mbAncButtons_t25.css": rdoWebTemplate5_Red.Checked = true; break; 
            

        }


        //if (TemplateCSSstr == "mbStyleButtons.css")
        //{
        //    rdoMobiTmp1_Blue.Checked = true;
        //}
        //else if(TemplateCSSstr == "mbStyleButtons_t2.css")
        //{
        //    rdoWebTemplate1_Red.Checked = true;
        //}
        //else if (TemplateCSSstr == "mbStyleButtons_t3.css")
        //{
        //    rdoWebTemplate1_Green.Checked = true;
        //}
        


       


    }



    //protected void btnSave_Click1(object sender, EventArgs e)
    //{

    //    String SelectedChkListStr = string.Empty;


        
        
    //    //Default Buttons 
    //    foreach (ListItem ckItem in chkDefaultBtns.Items)
    //    {

    //        if (ckItem.Selected)
    //        {
    //            if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
    //            SelectedChkListStr += ckItem.Value;
    //        }
    //    }

        
    //    //own  Buttons 
    //    foreach (ListItem ckItem in chkOwnBtns.Items)
    //    {

    //        if (ckItem.Selected)
    //        {
    //            if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
    //            SelectedChkListStr += ckItem.Value;
    //        }
    //    }

        
    //    //Social  Buttons 
    //    foreach (ListItem ckItem in chkSocialBtns.Items)
    //    {

    //        if (ckItem.Selected)
    //        {
    //            if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
    //            SelectedChkListStr += ckItem.Value;
    //        }
    //    }


    //    //BottomLinks 
    //    foreach (ListItem ckItem in chkBottonBtns.Items)
    //    {

    //        if (ckItem.Selected)
    //        {
    //            if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
    //            SelectedChkListStr += ckItem.Value;
    //        }
    //    }

    //    //Logo title Info..
    //    String tmpTitle1 = txtTitle1.Text.Trim();
    //    String tmpTitle2 = txtTitle2.Text.Trim();





    //    int upStatus = objMb.UpdateButtonSelection(Convert.ToInt32(Session["UserID"].ToString()), SelectedChkListStr, tmpTitle1, tmpTitle2);


    //    if (upStatus != -1)
    //    {
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Sucess.gif";
    //        lblErrMessage.Text = "Button Settings successfully added";
    //        lblErrMessage.CssClass = "font_12Msg_Success";

    //    }
    //    else
    //    {
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";
    //        lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the Settings. Please contant Administrator";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //    }



    //}


    protected void btnSetTemplate_Click(object sender, EventArgs e)
    {

        String TmpSelCss = string.Empty;

        /*
        if (rdoMobiTmp1_Blue.Checked == true)
        {
            TmpSelCss = "mbStyleButtons.css";
           
        }
        else if (rdoWebTemplate1_Red.Checked == true)
        {
            TmpSelCss = "mbStyleButtons_t2.css";
         
        }
        else if (rdoWebTemplate1_Green.Checked == true)
        {
            TmpSelCss = "mbStyleButtons_t3.css";
        }
        else if (rdoWebTemplate1_Orange.Checked == true) 
        {
            TmpSelCss = "mbStyleButtons_t4.css";
        }
        else if (rdoWebTemplate1_Purple.Checked == true) 
        {
            TmpSelCss = "mbStyleButtons_t5.css";
        }

            */
        /*
        if (rdoWebTemplate2_Green.Checked == true) 
        {
            TmpSelCss = "mbStyleButtons_t6.css";
        }
        else if (rdoWebTemplate2_Maroon.Checked == true) 
        {
            TmpSelCss = "mbStyleButtons_t7.css";
        }
        else if (rdoWebTemplate2_Orange.Checked == true) 
        {
            TmpSelCss = "mbStyleButtons_t8.css";
        }
        else if (rdoWebTemplate2_Navy.Checked == true) 
        {
            TmpSelCss = "mbStyleButtons_t9.css";
        }
        else if (rdoWebTemplate2_Purple.Checked == true) 
        {
            TmpSelCss = "mbStyleButtons_t10.css";
        }

         */

          //... AnchorImage Templates... 
        if (rdoWebTemplate3_Grey.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t11.css";
        }
        else if (rdoWebTemplate3_Green.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t12.css";
        }
        else if (rdoWebTemplate3_Red.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t13.css";
        }
        else if (rdoWebTemplate3_Blue.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t14.css";
        }
        else if (rdoWebTemplate3_Orange.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t15.css";
        }


/*
        //... MenuIcon  Templates... 
        else if (rdoWebTemplate4_Red.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t16.css";
        }
        else if (rdoWebTemplate4_Grey.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t17.css";
        }
        else if (rdoWebTemplate4_Orange.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t18.css";
        }
        else if (rdoWebTemplate4_Green.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t19.css";
        }
        else if (rdoWebTemplate4_Blue.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t20.css";
        }



        //... BackGround  Templates... 
        else if (rdoWebTemplate5_Blue.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t21.css";
        }
        else if (rdoWebTemplate5_Green.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t22.css";
        }
        else if (rdoWebTemplate5_Windows.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t23.css";
        }
        else if (rdoWebTemplate5_Orange.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t24.css";
        }
        else if (rdoWebTemplate5_Red.Checked == true) 
        {
            TmpSelCss = "mbAncButtons_t25.css";
        }
        */

        int upStatus = objMb.UpdateTemplateSelection(Convert.ToInt32(Session["UserID"].ToString()), TmpSelCss, "", "");


        if (upStatus != -1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Template Selection successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the Template Selection. Please contant Administrator";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }


    }
 
}

