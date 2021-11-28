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
using System.Text;

public partial class Admin_Ad_MobileHome2 : System.Web.UI.Page
{
    DataSet ds;
    DataTable dtButtons;
    DataTable dtBtnSelections;
    DataTable dtBtnTitles;

    int retTemplateID = 0; 

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
            
            LoadMyTemplatesAndTitles();

            LoadAllTemplates();

            mobileIframe.Attributes.Add("src", "../../Mb/mb_Preview.aspx?prvUserID=" + Convert.ToInt32(Session["UserID"].ToString()));
            //ModalPopupExtender1.Show(); 
        }

    }

    protected void LoadAllTemplates()
    {

        ds = objMb.Retrieve_ALLTemplates();


        DataTable dtTemplates;


        dtTemplates = ds.Tables[0];

      //  select3.DataSource = dtTemplates;
      //  select3.DataBind();


        String mTemplateName = string.Empty;
        String mTemplateID = string.Empty;
        String mImage = string.Empty;


        foreach (DataRow dtRow in dtTemplates.Rows)
        {
            mTemplateID     = dtRow["TemplateID"].ToString();
            mTemplateName   = dtRow["TemplateName"].ToString();



            mImage = @"<img src='../../Images/Mobile/ColorSet2/News.png'/>";
            ListItem vListItem = new ListItem(mTemplateName, mTemplateID);

           // vListItem.Attributes.Add("image_src", mImage); 
           // vListItem.Attributes.Add("style", "background-image:url(../../Images/Mobile/forward.png);");
           // vListItem.Attributes.Add("class","ddlimg"); 
            
            
            ddlTemplates.Items.Add(vListItem);

            if (Convert.ToInt32(mTemplateID) == retTemplateID)
                ddlTemplates.SelectedValue = retTemplateID.ToString();
                

            
        }



        //ddlTemplates.DataSource = ds;
        //ddlTemplates.DataTextField = "TemplateName";
        //ddlTemplates.DataValueField ="TemplateID";
        //ddlTemplates.DataBind(); 

        


    }

    protected void LoadMyTemplatesAndTitles()
    {
        DataTable dtMyTemplates; 
        ds = objMb.Retrieve_SelectedTemplate(Convert.ToInt32(Session["UserID"].ToString()));
        dtMyTemplates = ds.Tables[0];


        String TmpID = string.Empty;
        String TmpTitle1 = string.Empty;
        String TmpTitle2 = string.Empty;

        foreach (DataRow dtRow in dtMyTemplates.Rows)
        {
            retTemplateID = Convert.ToInt32(dtRow["TemplateID"].ToString());
            TmpTitle1 = dtRow["Title1"].ToString();
            TmpTitle2 = dtRow["Title2"].ToString(); 
        }

        txtTitle1.Text = TmpTitle1;
        txtTitle2.Text = TmpTitle2;
        
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
        dvButtons.RowFilter = "ShownAs = 1 and ButtonName='About US'";
        RenderCheckBoxListWithSelections(dvButtons, chkAboutBtns, csvSelButtonStr);



        //..Own Buttons
        dvButtons.RowFilter = "ShownAs = 3";
        RenderCheckBoxListWithSelections(dvButtons, chkOwnBtns, csvSelButtonStr);


        //..Other Buttons
        dvButtons.RowFilter = "ShownAs = 1 and ButtonName<>'About US'";
        RenderCheckBoxListWithSelections(dvButtons, chkOtherButtons, csvSelButtonStr);


        //..Social Media Buttons
        dvButtons.RowFilter = "ShownAs = 4";
        RenderCheckBoxListWithSelections(dvButtons, chkSocialBtns, csvSelButtonStr);


        //..Bottom LInk Buttons
        dvButtons.RowFilter = "ShownAs = 2";
        RenderCheckBoxListWithSelections(dvButtons, chkBottonBtns, csvSelButtonStr);



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


           // ckItem.Text = ckItem.Text + @"<div style='float:right;'><a href='#' tooltip='edit'><img style='padding-left:100px;  border:none;'  src='..\..\Images\Mobile\edit.png'/></a> <a href='#' tooltip='preview'><img style='padding-left:20px; border:none;'  src='..\..\Images\Mobile\preview.png'/></a></div>";

        }


    }




    protected void LoadHTMLButtonLinks()
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


        StringBuilder sbBtns = new StringBuilder();
        sbBtns.AppendLine("<table id='tblButtons' cellpadding='0' cellspacing='0' width='100%'>");
       // sbBtns.AppendLine("<tr>");


        String tmpBtnID = string.Empty;
        String tmpBtnName = string.Empty;
        String tmpRowCss = string.Empty;
        String tmpisChecked = string.Empty;
        int tmpShownAs = 0;

        int RowAdded_OwnMobile = 0;
        int RowAdded_SocialMedia = 0; 



        ds = objMb.RetrieveAll_MobiButtonsInfo();
        dtButtons = ds.Tables[0];

        DataView dvButtons = ds.Tables[0].DefaultView;


        foreach (DataRowView dvRow in dvButtons) 
        {
            tmpBtnID = dvRow["ButtonID"].ToString(); 
            tmpBtnName = dvRow["ButtonName"].ToString();
            tmpShownAs = Convert.ToInt16(dvRow["ShownAs"].ToString());

            String TmpBtnStr = string.Empty;

            switch (tmpShownAs)
            {
                case 1: tmpRowCss = "FontBRowText1";
                    break;
                case 2: tmpRowCss = "FontBRowText2";
                  
                    break;
                case 3: tmpRowCss = "FontBRowText3";
                    if(RowAdded_OwnMobile == 0)
                        sbBtns.AppendLine("<tr><td class='FontBRowTextBkg' style='padding-left: 40px;'>My Mobile Buttons</td></tr>");
                    RowAdded_OwnMobile = 1;
                    break;

                case 4: tmpRowCss = "FontBRowText4"; 
                    if (RowAdded_SocialMedia == 0)
                        sbBtns.AppendLine("<tr><td class='FontBRowTextBkg' style='padding-left: 40px;'>Social Media Buttons</td></tr>");
                    RowAdded_SocialMedia = 1;
                    break;
            }

            if (csvSelButtonStr.Contains(tmpBtnID))
                tmpisChecked = "checked";
            else
                tmpisChecked = "";
 

             //<input id="ctl00_ContentBody_CheckBox1" type="checkbox" name="ctl00$ContentBody$CheckBox1" />
            //TmpBtnStr = "<td class='"+ tmpRowCss +"'> <asp:CheckBox ID='chkBtnID" + tmpBtnID + "' Text='" + tmpBtnName + "' runat='server' /> </td>";
            TmpBtnStr = "<tr><td class='" + tmpRowCss + "'> <input ID='chkBtnID" + tmpBtnID + "' " + tmpisChecked + " type='checkbox' value='" + tmpBtnID + "' runat='server' /><span class='chkboxText'>" + tmpBtnName + "</span></td></tr>";

            sbBtns.AppendLine(TmpBtnStr); 

        }

       // sbBtns.AppendLine("</tr>");
        sbBtns.AppendLine("</table>");

        divbuttomHTML.InnerHtml = sbBtns.ToString(); 
        



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

    protected void btnSave_Click1(object sender, EventArgs e)
    {

        String SelectedChkListStr = string.Empty;


        int tmpTemplateID = Convert.ToInt32(ddlTemplates.SelectedValue); 


        //Logo title Info..
        String tmpTitle1 = txtTitle1.Text.Trim();
        String tmpTitle2 = txtTitle2.Text.Trim();

        

        //Default Buttons 
        foreach (ListItem ckItem in chkAboutBtns.Items)
        {

            if (ckItem.Selected)
            {
                if (SelectedChkListStr != string.Empty) SelectedChkListStr += ",";
                SelectedChkListStr += ckItem.Value;
            }
        }

        

        //Other Buttons 
        foreach (ListItem ckItem in chkOtherButtons.Items)
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


        bool chkMobileWebDetection = false;

        int upStatus = objMb.UpdateButtonSelection(Convert.ToInt32(Session["UserID"].ToString()), SelectedChkListStr, tmpTitle1, tmpTitle2, tmpTemplateID, chkMobileWebDetection);


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

        mobileIframe.Attributes.Add("src", "../../Mb/mb_Preview.aspx?prvUserID=" + Convert.ToInt32(Session["UserID"].ToString())); 
        

    }

}

