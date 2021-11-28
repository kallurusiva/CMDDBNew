using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql; 
using System.Data.SqlClient; 

public partial class Admin_Ad_MobileHome : System.Web.UI.Page
{
    DataSet ds;
    DataTable dtButtons;
    DataTable dtBtnSelections;
    DataTable dtBtnTitles; 

    CMSv3.BAL.MbMain objMb = new CMSv3.BAL.MbMain(); 

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion

        Page.MaintainScrollPositionOnPostBack = true;




        if (!IsPostBack)
        {
            LoadButtonLinks();
           // RenderButtonSelections(); 
            

        }

    }



    protected void LoadButtonLinks()
    {

        //..retrieving the user selected buttons 
        ds = objMb.Retrieve_SelectedButtonsByUserID(Convert.ToInt32(Session["UserID"].ToString()));
        dtBtnSelections = ds.Tables[0];
        dtBtnTitles = ds.Tables[1];

        //..looping thru table to get the selected buttons CSV string.. 
        String csvSelButtonStr = string.Empty;
        foreach (DataRow dtRow in dtBtnSelections.Rows)
        {
            if (csvSelButtonStr != string.Empty)
                csvSelButtonStr += ",";
            csvSelButtonStr += dtRow["ButtonID"].ToString();
        }

        //string testStr = "7";

        //bool vals = csvSelButtonStr.Contains(testStr);




        ds = objMb.RetrieveAll_MobiButtonsInfo();
        dtButtons = ds.Tables[0];

        DataView dvButtons = ds.Tables[0].DefaultView;

        
        //..Default Buttons
        dvButtons.RowFilter = "ShownAs = 1";
        RenderCheckBoxListWithSelections(dvButtons, chkDefaultBtns, csvSelButtonStr); 

        
        //chkDefaultBtns.DataSource = dvButtons;
        //chkDefaultBtns.DataTextField = "ButtonName";
        //chkDefaultBtns.DataValueField = "ButtonID";
        //chkDefaultBtns.DataBind(); 

        //..Own Buttons
        
        dvButtons.RowFilter = "ShownAs = 2";
        RenderCheckBoxListWithSelections(dvButtons, chkOwnBtns, csvSelButtonStr); 

        //chkOwnBtns.DataSource = dvButtons;
        //chkOwnBtns.DataTextField = "ButtonName";
        //chkOwnBtns.DataValueField = "ButtonID";
        //chkOwnBtns.DataBind(); 


        //..Bottom LInk Buttons

        dvButtons.RowFilter = "ShownAs = 3";
        RenderCheckBoxListWithSelections(dvButtons, chkBottonBtns, csvSelButtonStr); 

        //chkBottonBtns.DataSource = dvButtons;
        //chkBottonBtns.DataTextField = "ButtonName";
        //chkBottonBtns.DataValueField = "ButtonID";
        //chkBottonBtns.DataBind(); 

        //..Social Media Buttons
        dvButtons.RowFilter = "ShownAs = 4";
        RenderCheckBoxListWithSelections(dvButtons, chkSocialBtns, csvSelButtonStr); 



        //..Title information 

        foreach(DataRow tRow in dtBtnTitles.Rows)
        {
            txtTitle1.Text = tRow["Title1"].ToString();
            txtTitle2.Text = tRow["Title2"].ToString();

        }

        


        //dvButtons.RowFilter = "ShownAs = 99";

        //foreach (DataRowView tvRow in dvButtons)
        //{
        //    string tBtnName = tvRow["ButtonName"].ToString();

        //    if (tBtnName == "Title1")
        //        txtTitle1.Text = tvRow["ButtonURL"].ToString();


        //    if (tBtnName == "Title2")
        //        txtTitle2.Text = tvRow["ButtonURL"].ToString(); 
        //}

       


        //chkSocialBtns.DataSource = dvButtons;
        //chkSocialBtns.DataTextField = "ButtonName";
        //chkSocialBtns.DataValueField = "ButtonID";
        //chkSocialBtns.DataBind(); 


        //chkButtonLinks.DataSource = dtButtons;
        //chkButtonLinks.DataTextField = "ButtonName";
        //chkButtonLinks.DataValueField = "ButtonID";
        //chkButtonLinks.DataBind();


        

       

        //foreach (ListItem ckItem in chkButtonLinks.Items)
        //{
        //    if (csvSelButtonStr != string.Empty)
        //    {
        //        if (csvSelButtonStr.Contains(ckItem.Value))
        //        {
        //            ckItem.Selected = true;
        //        }
        //    }
        //    else
        //    {
        //        ckItem.Selected = false;
        //    }

        //}



    }


    protected void RenderCheckBoxListWithSelections(DataView dvSource, CheckBoxList chkList, string vSelListStr)
    {



        chkList.DataSource = dvSource;
        chkList.DataTextField = "ButtonName";
        chkList.DataValueField = "ButtonID";
        chkList.DataBind(); 



        foreach (ListItem ckItem in chkList.Items)
        {
            if (vSelListStr != string.Empty)
            {
                if (vSelListStr.Contains(ckItem.Value))
                {
                    ckItem.Selected = true;
                }
            }
            else
            {
                ckItem.Selected = false;
            }

        }


    }




    //protected void RenderButtonSelections()
    //{
    //    ds = objMb.Retrieve_SelectedButtonsByUserID(Convert.ToInt32(Session["UserID"].ToString()));


    //    //..retrieving the user selected buttons 
    //    ds = objMb.Retrieve_SelectedButtonsByUserID(Convert.ToInt32(Session["UserID"].ToString()));
    //    dtBtnSelections = ds.Tables[0];

    //    //..looping thru table to get the selected buttons CSV string.. 
    //    String csvSelButtonStr = string.Empty;
    //    foreach (DataRow dtRow in dtBtnSelections.Rows)
    //    {
    //        if (csvSelButtonStr != string.Empty)
    //            csvSelButtonStr += ",";
    //        csvSelButtonStr += dtRow["ButtonID"].ToString();
    //    }


    //    foreach (Control cs in this.Controls)
    //    {
    //        if (cs.GetType() == typeof(CheckBox))
    //        {

    //            CheckBox tmpChkbox = (CheckBox)cs; 



    //        }

    //    }



    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {



    }

    protected void btnSave_Click1(object sender, EventArgs e)
    {

        String SelectedChkListStr = string.Empty;


        
        
        //Default Buttons 
        foreach (ListItem ckItem in chkDefaultBtns.Items)
        {

            if (ckItem.Selected)
            {
                if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
                SelectedChkListStr += ckItem.Value;
            }
        }

        
        //own  Buttons 
        foreach (ListItem ckItem in chkOwnBtns.Items)
        {

            if (ckItem.Selected)
            {
                if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
                SelectedChkListStr += ckItem.Value;
            }
        }

        
        //Social  Buttons 
        foreach (ListItem ckItem in chkSocialBtns.Items)
        {

            if (ckItem.Selected)
            {
                if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
                SelectedChkListStr += ckItem.Value;
            }
        }


        //BottomLinks 
        foreach (ListItem ckItem in chkBottonBtns.Items)
        {

            if (ckItem.Selected)
            {
                if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
                SelectedChkListStr += ckItem.Value;
            }
        }

        //Logo title Info..
        String tmpTitle1 = txtTitle1.Text.Trim();
        String tmpTitle2 = txtTitle2.Text.Trim();




        bool chkMobileWebDetection = false;
        int upStatus = objMb.UpdateButtonSelection(Convert.ToInt32(Session["UserID"].ToString()), SelectedChkListStr, tmpTitle1, tmpTitle2, 1, chkMobileWebDetection);


        if (upStatus != -1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Button Settings successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the Settings. Please contant Administrator";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }



    }
}

