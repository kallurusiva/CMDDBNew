using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSv3.BAL;
using System.Globalization;


public partial class SuperAdmin_SA_EventsCreate : System.Web.UI.Page 
{
    CMSv3.BAL.Events objBAL_Events = new CMSv3.BAL.Events();
    CMSv3.Entities.Events objEvents = new CMSv3.Entities.Events();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrDisplayAtWebsite.Text = Resources.LangResources.DisplayatWebsite;

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        if (!IsPostBack)
        {
            //txtEvtDate2_CalendarExtender.SelectedDate = System.DateTime.Now;
        }

        txtEvtFROMdate.Attributes.Add("readonly", "readonly");
        txtEvtTOdate.Attributes.Add("readonly", "readonly");

        //txtEvtDate2.ReadOnly = true;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Get the form values and store them objEvent
        objEvents = new CMSv3.Entities.Events();
        //string tmpDatetime = Picker4.Text; Picker4.Format.

        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage4Create");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);

        if (mSelLanguage == 0)
            mSelLanguage = 1;


        objEvents.EventDateFROM = ParseDate(txtEvtFROMdate.Text);
        objEvents.EventDateTO = ParseDate(txtEvtTOdate.Text);
        
        string tmpEvntContent = txtEvtContent.Text;
        //tmpEvntContent = tmpEvntContent.ToString().Replace(Environment.NewLine, "<br/>");
        tmpEvntContent = CommonFunctions.HandleNewLines(tmpEvntContent, Request.UserAgent);

        objEvents.EventContent = tmpEvntContent;

        objEvents.EventTitle = txtEvtTitle.Text;
        objEvents.UserID = Convert.ToInt32(Session["saUserID"]);

      
        bool mDisplayatWebsite = chkActive.Checked;

        int inStatus = objBAL_Events.InsertEventData(objEvents, mDisplayatWebsite, mSelLanguage);

        if (inStatus == 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "News successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Event Item inserted Successfully')", true);
            Response.Redirect("SA_EventsListing.aspx?LgType=" + mSelLanguage);
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


    public static DateTime FormatDate(string date)
    {
        char sept = '/';
        if (date.Contains("-"))
        {
            sept = '-';
        }

        string[] arr = date.Split(sept);
        return Convert.ToDateTime(arr[1].ToString() + "/" + arr[0].ToString() + "/" + arr[2].ToString());
    }


    public DateTime ParseDate(string date)
    {

        char sept = '/';
        if (date.Contains("-"))
        {
            sept = '-';
        }

        string[] arr = date.Split(sept);
        string TmpDateString = string.Empty;

        TmpDateString = arr[0].ToString() + "/" + arr[1].ToString() + "/" + arr[2].ToString();


        DateTimeFormatInfo dateFormatProvider = new DateTimeFormatInfo();
        dateFormatProvider.ShortDatePattern = "dd/MM/yyyy";
        return DateTime.Parse(TmpDateString, dateFormatProvider);
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("SA_EventsListing.aspx");
    }
}
