using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Globalization;
using System.Globalization;
using CMSv3.BAL;
using MKB.TimePicker;


public partial class Admin_EventsCreate : BasePage
{
    CMSv3.BAL.Events objBAL_Events = new CMSv3.BAL.Events();
    CMSv3.Entities.Events objEvents = new CMSv3.Entities.Events();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 
        ltrLanguage.Text = Resources.LangResources.Language;

        if (!IsPostBack)
        {
            //txtEvtDate2_CalendarExtender.SelectedDate = System.DateTime.Now;

            
        }
       
        //txtEvtDate2.ReadOnly = true;
        txtEvtFROMdate.Attributes.Add("readonly", "readonly");
        txtEvtTOdate.Attributes.Add("readonly", "readonly");

        if(Session["UserDomainType"].ToString() == "EBOOK")
        {
            trSelLanguage.Visible = false; 
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Get the form values and store them objEvent
        objEvents = new CMSv3.Entities.Events();

        //string tmpCurrLang = Session["defLanguage"].ToString();

        //objEvents.EventDateFROM = FormatDate(txtEvtFROMdate.Text, tmpCurrLang);
        //objEvents.EventDateTO = FormatDate(txtEvtTOdate.Text, tmpCurrLang);

        objEvents.EventDateFROM = ParseDate(txtEvtFROMdate.Text);
        objEvents.EventDateTO = ParseDate(txtEvtTOdate.Text);



        //Date.ParseExact(CType(date,"MM/dd/yy", New Globalization.DateTimeFormatInfo);
        //System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator = "-";
        //objEvents.EventDateFROM =  DateTime.Parse(txtEvtFROMdate.Text, System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat);
        //objEvents.EventDateTO = DateTime.Parse(txtEvtTOdate.Text, System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat);


        //string selFromDate = txtEvtFROMdate.Text;
        //string selToDate = txtEvtTOdate.Text;

        //string selFromTime = TimeSelector_From.Date.ToShortTimeString();
        //string selToTime = TimeSelector_TO.Date.ToShortTimeString();

        //string FullFromDateTime = selFromDate + " " + selFromTime;
        //string FullToDateTime = selToDate + " " + selToTime;

        //objEvents.EventDateFROM = Convert.ToDateTime(FullFromDateTime);
        //objEvents.EventDateTO = Convert.ToDateTime(FullToDateTime);

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


        ///////objEvents.EventDate = Convert.ToDateTime(txtEvtDate2.Text);

        //-- Replace line breaks;
        String tmpEventContent = txtEvtContent.Text;
        //tmpEventContent = tmpEventContent.ToString().Replace(Environment.NewLine, "<br/>");
        tmpEventContent = CommonFunctions.HandleNewLines(tmpEventContent, Request.UserAgent);
        objEvents.EventContent = tmpEventContent;
        
        
        objEvents.EventTitle = txtEvtTitle.Text;
        objEvents.UserID = Convert.ToInt32(Session["UserID"]);
        bool mNewsDisplay = chkDisplaAtWeb.Checked;

        int inStatus = objBAL_Events.InsertEventData(objEvents, mNewsDisplay, mSelLanguage);

        if (inStatus == 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "News successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Event Item inserted Successfully')", true);
            Response.Redirect("EventsListing.aspx");
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



    public static DateTime FormatDate(string date, string vCurrLang)
    {
        char sept = '/';
        if (date.Contains("-"))
        {
            sept = '-';
        }

        string[] arr = date.Split(sept);
        string TmpDateString = string.Empty;

        
        TmpDateString = arr[1].ToString() + "/" + arr[0].ToString() + "/" + arr[2].ToString();

        DateTime tmpDate;
        //tmpDate = parseda

       // System.DateTime tmpDate = DateTime.Parse(TmpDateString, System.Globalization.CultureInfo.CreateSpecificCulture(vCurrLang).DateTimeFormat);
        tmpDate = DateTime.Parse(TmpDateString);

        //tmpDate = (DateTime)(TypeDescriptor.GetConverter(new DateTime(1990, 5, 6)).ConvertFrom(TmpDateString));
       // tmpDate = DateTime.ParseExact(TmpDateString, "ddMMyyyy", System.Globalization.CultureInfo.CurrentCulture);

        //tmpDate = DateTime.ParseExact(TmpDateString, "MM/dd/yyyy hh:mm", null);
        return tmpDate;
        //return Convert.ToDateTime(arr[1].ToString() + "/" + arr[0].ToString() + "/" + arr[2].ToString());
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("EventsListing.aspx");
    }
}
