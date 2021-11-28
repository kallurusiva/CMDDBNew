using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Admin_SMS_EbAd_EBook_CreateList_BookCode_SMS_FreeSYS : System.Web.UI.Page
{
    DataSet ds;
    DataSet dst;
    int vTimeDiff = 0;
    int iTotalCount;
    int EngMaxLen = 600;
    int ChiMaxLen = 240;

    int stdEngMaxLen = 150;
    int stdChiMaxLen = 60;
    string LID = string.Empty;

    CMSv3.BAL.MalaysiaSMS objMalaysia = new CMSv3.BAL.MalaysiaSMS();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion
        LID = Request.QueryString["LID"].ToString();
        if (!IsPostBack)
        {
            ViewState["LID"] = LID;

            hdnMsgCharLen.Value = EngMaxLen.ToString();
            hdnMsgCharLenEng.Value = EngMaxLen.ToString();
            hdnMsgCharLenChi.Value = ChiMaxLen.ToString();

            hdnMSG_StdMaxLen.Value = stdEngMaxLen.ToString();
            hdnMSG_StdEngMaxLen.Value = stdEngMaxLen.ToString();
            hdnMSG_StdChiMaxLen.Value = stdChiMaxLen.ToString();

            String sReplyMsgErrorMsg = revReplyMsg.ValidationExpression;

            revReplyMsg.ErrorMessage = "Maximum " + EngMaxLen.ToString() + " characters allowed.";
            revReplyMsg.ValidationExpression = sReplyMsgErrorMsg + "{1," + EngMaxLen.ToString() + "}$";
            ddlMessageLang.SelectedValue = "E";

            TextBoxReplyMsg.Text = Server.HtmlDecode(TextBoxReplyMsg.Text);
            TextBoxReplyMsgLength.Value = TextBoxReplyMsg.Text.Length.ToString();

            ddlMessageLang.Attributes.Add("onChange", "OnChangeLanguage(this.value)");
            TextBoxReplyMsg.Attributes.Add("onKeyUp", "OnKeyStringCount(this.value)");
            TextBoxReplyMsg.Attributes.Add("onKeyDown", "OnKeyStringCount(this.value)");
            TextBoxReplyMsg.Attributes.Add("onKeyPress", "OnKeyStringCount(this.value)");
            TextBoxReplyMsg.Attributes.Add("onClick", "OnKeyStringCount(this.value)");
            TextBoxReplyMsg.Attributes.Add("onFocus", "SetCursorToTextEnd(this.id)");

            TextBoxMobileList.Text = "";
            newDBS ndbs = new newDBS();
            dst = ndbs.Ebook_CreateList_BookCode_sendSMS_getList_FreeSYS(Session["UserID"].ToString(), ViewState["LID"].ToString());
            if (dst.Tables[0].Rows.Count > 0)
            {
                DataRow utRow1 = dst.Tables[0].Rows[0];
                TextBoxMobileList.Text = utRow1["Txt"].ToString();
            }

            ds = objMalaysia.Retrieve_AccountDetails(Session["MERID"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow utRow = ds.Tables[0].Rows[0];

                LabelSenderIDVal.Text = LabelMsgSenderIDVal.Text = utRow["SenderId"].ToString();
                LabelMerchantCodeVal.Text = utRow["Mcode"].ToString();
                LabelSMSBalanceVal.Text = String.Format("{0:0.00}", utRow["BalanceCredit"]);
            }

            DataSet dsTime = objMalaysia.Retrieve_DayLightTimeZoneInfo(Session["MERID"].ToString());

            if (dsTime.Tables[0].Rows.Count > 0)
            {
                vTimeDiff = Convert.ToInt32(dsTime.Tables[0].Rows[0]["TimeDif"].ToString());
            }

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        TextBoxReplyMsg.Text = ConvertToPlainText(TextBoxReplyMsg.Text);

        String sReplyMsg = TextBoxReplyMsg.Text;
        bool bUnicode = IsUnicode(sReplyMsg);

        if (bUnicode)
        {
            Check_UnicodeMsgLanguage();
            CommonFunctions.AlertMessage("Detected Unicode in Message. This message will convert to Unicode.Maximum " + ChiMaxLen.ToString() + " Chars.Pls check message");
        }
        else
        {
            Retrieve_MsgLanguage();
            Confirm_MessageInfo();
        }
    }
    protected void btnSaveContinue_Click(object sender, EventArgs e)
    {
        Retrieve_MsgLanguage();
        Confirm_MessageInfo();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"EbAd_BookCodes.aspx");
    }
    protected void btnSendNow_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            String vDeductSMSCredits = LabelTotalMessageCdtChgsVal.Text;
            int iBalanceCreditStatus = Retrieve_UserAccountDetails(vDeductSMSCredits);

            if (iBalanceCreditStatus != 1)
            {
                CommonFunctions.AlertMessageAndRedirect("Sorry Insufficient Balance.Kindly Top your SMS", @"EbAd_BookCodes.aspx");
            }
            else
            {
                String vUserID = Session["MERID"].ToString();
                String vCategoryName = "0";
                String vReportName = txtReportName.Text;
                String vMobileList = TextBoxMobileList.Text;
                String vPrefix = String.Empty;
                String vPersonalise = String.Empty;
                String vMessage = String.Empty;
                String vMsgType = String.Empty;
                String vCreditType = String.Empty;
                String vMsgCHN = String.Empty;

                if (IsUnicode(TextBoxReplyMsg.Text))
                {
                    vMessage = "";
                    vMsgType = "1";
                    vCreditType = "SMSCHN";
                    vMsgCHN = TextBoxReplyMsg.Text;  //HitechSMS_Functions.ConvertStoreDBToAscii(TextBoxReplyMsg.Text);
                }
                else
                {
                    vMessage = TextBoxReplyMsg.Text;
                    vMsgType = "0";
                    vCreditType = "SMSNNR";
                    vMsgCHN = "";
                }

                String vSender = LabelMsgSenderIDVal.Text;

                int tmpStatus = objMalaysia.Send_MessageUpdated(Session["MERID"].ToString(), vCategoryName, vMobileList, vPrefix, vPersonalise, vMessage, vMsgType, vSender, "0", vDeductSMSCredits, vCreditType, ConvertToAscii(vMsgCHN), vReportName);
                hdnHistID.Value = tmpStatus.ToString();

                CommonFunctions.AlertMessage("SMS has been sent successfully");

                Server.Transfer(@"EbAd_1WayReportSpecific.aspx");
            }
        }
    }
    protected void btnBackMsg_Click(object sender, EventArgs e)
    {
        tblSendSMS.Visible = true;
        tblConfirmSMS.Visible = false;
    }
    protected void ddlMessageLang_SelectedIndexChanged(object sender, EventArgs e)
    {
        Retrieve_MsgLanguage();
    }
    protected void Retrieve_MsgLanguage()
    {
        String MsgLanguage = ddlMessageLang.SelectedValue.Trim();
        String ValExpress = revReplyMsg.ValidationExpression.ToString();

        TextBoxReplyMsg.Text = ConvertToPlainText(TextBoxReplyMsg.Text);
        String sReplyMsg = TextBoxReplyMsg.Text;
        String sMsgCount = String.Empty;

        if (IsUnicode(sReplyMsg))
        {
            sMsgCount = Count_CategoryTotalSMS(sReplyMsg, stdChiMaxLen, ChiMaxLen);
            ValExpress = ValExpress.Replace(EngMaxLen.ToString(), ChiMaxLen.ToString());
            revReplyMsg.ValidationExpression = ValExpress;
            revReplyMsg.ErrorMessage = "Maximum " + ChiMaxLen.ToString() + " Unicode characters allowed.";
            hdnMsgCharLen.Value = ChiMaxLen.ToString();
            ddlMessageLang.SelectedValue = "C";
        }
        else
        {
            sMsgCount = Count_CategoryTotalSMS(sReplyMsg, stdEngMaxLen, EngMaxLen);
            ValExpress = ValExpress.Replace(ChiMaxLen.ToString(), EngMaxLen.ToString());
            revReplyMsg.ValidationExpression = ValExpress;
            revReplyMsg.ErrorMessage = "Maximum " + EngMaxLen.ToString() + " characters allowed.";
            hdnMsgCharLen.Value = EngMaxLen.ToString();
            ddlMessageLang.SelectedValue = "E";
        }

        TextBoxTotalLen.Text = TextBoxReplyMsg.Text.Length.ToString();
        TextBoxReplyMsgCount1.Text = sMsgCount;
        hdnMsg_Count.Value = sMsgCount;
        revReplyMsg.Validate();
    }
    protected void Check_UnicodeMsgLanguage()
    {
        TextBoxReplyMsg.Focus();
        ddlMessageLang.SelectedValue = "C";

        BtSendSMS.Visible = false;
        BtSaveContinue.Visible = true;

        Retrieve_MsgLanguage();
    }
    protected void Confirm_MessageInfo()
    {
        if (Page.IsValid)
        {
            tblSendSMS.Visible = false;
            tblConfirmSMS.Visible = true;

            LabelTotalCountVal.Text = hdnMsg_Count.Value;
            LabelMobileCountVal.Text = iTotalCount.ToString();
            LabelMsgLanguageVal.Text = ddlMessageLang.SelectedItem.Text;
            LabelMsgSenderIDVal.Text = LabelSenderIDVal.Text;

            LabelMsgScheduleChgVal.Text = "1.0";
            LabelMsgFormatVal.Text = ConvertToAscii(TextBoxReplyMsg.Text);
            LabelTotalMessageCdtChgsVal.Text = (1 * iTotalCount * Convert.ToDouble(hdnMsg_Count.Value)).ToString();
        }
    }
    protected int Retrieve_UserAccountDetails(String iDeductSMSCredits)
    {
        Double iCreditStatus = 0;
        Double BalanceCredit = -1;
        int tStatus = 1;

        ds = objMalaysia.Retrieve_AccountDetails(Session["MERID"].ToString());

        bool bCredit = double.TryParse(iDeductSMSCredits, out iCreditStatus);

        if (bCredit)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow utRow = ds.Tables[0].Rows[0];
                String sBalance = utRow["BalanceCredit"].ToString();
                BalanceCredit = Convert.ToDouble(sBalance);
            }
            if (BalanceCredit > 0)
            {
                tStatus = Check_UserSMSBalanceSufficient(Convert.ToDouble(iDeductSMSCredits), BalanceCredit);
            }
            else
            {
                tStatus = -1;
            }
        }
        else
        {
            tStatus = -1;
        }

        return tStatus;
    }
    public static string ConvertToPlainText(string str)
    {
        char[] charArr = str.ToCharArray();
        String strUniCode = String.Empty;

        try
        {
            foreach (char ch in charArr)
            {
                const int MaxAnsiCode = 255;
                int charAnsii = Convert.ToInt32(ch);

                if (charAnsii > MaxAnsiCode)
                {
                    if ((charAnsii == 8216) || (charAnsii == 8217))
                    {
                        strUniCode = strUniCode + "'";
                    }
                    else if ((charAnsii == 8220) || (charAnsii == 8221))
                    {
                        strUniCode = strUniCode + "''";
                    }
                    else
                    {
                        strUniCode = strUniCode + ch;
                    }
                }
                else if (charAnsii == 34)
                {
                    strUniCode = strUniCode + "''";
                }
                else if (charAnsii == 39)
                {
                    strUniCode = strUniCode + "'";
                }
                else
                {
                    strUniCode = strUniCode + ch;
                }
            }
        }
        catch (FormatException e)
        {
            strUniCode = e.Message;
        }
        return strUniCode;
    }
    public static bool IsUnicode(string strMsg)
    {
        const int MaxAnsiCode = 255;
        string strNewMsg = string.Empty;
        bool Success;

        try
        {
            Success = strMsg.ToCharArray().Any(c => c > MaxAnsiCode); // If this line is reached, no exception was thrown
        }
        catch (FormatException e)
        {
            string s = e.Message;
            Success = false; // If this line is reached, an exception was thrown
        }
        return Success;
    }
    public static String Count_CategoryTotalSMS(String strMsg, int iMsgDefaultLength, int iMsgTotalLength)
    {
        string strMsgCount = string.Empty;
        int iCurrent_Msg_CharLen = strMsg.Trim().Length;
        int iTotalMsg2 = iMsgDefaultLength * 2;
        int iTotalMsg3 = iMsgDefaultLength * 3;

        try
        {
            if (iCurrent_Msg_CharLen > 0 && iCurrent_Msg_CharLen <= iMsgDefaultLength)
            {
                strMsgCount = "1";
            }
            else if ((iCurrent_Msg_CharLen > iMsgDefaultLength) && (iCurrent_Msg_CharLen <= iTotalMsg2))
            {
                strMsgCount = "2";
            }
            else if ((iCurrent_Msg_CharLen > iTotalMsg2) && (iCurrent_Msg_CharLen <= iTotalMsg3))
            {
                strMsgCount = "3";
            }
            else if ((iCurrent_Msg_CharLen > iTotalMsg3) && (iCurrent_Msg_CharLen <= iMsgTotalLength))
            {
                strMsgCount = "4";
            }
            else
            {
                strMsgCount = "4";
            }
        }
        catch (FormatException e)
        {
            strMsgCount = e.Message;
        }

        return strMsgCount;
    }
    public static string ConvertToAscii(string str)
    {
        char[] charArr = str.ToCharArray();
        String strUniCode = String.Empty;

        try
        {
            foreach (char ch in charArr)
            {
                const int MaxAnsiCode = 255;
                int charAnsii = Convert.ToInt32(ch);

                if (charAnsii > MaxAnsiCode)
                {
                    strUniCode = strUniCode + "&#" + charAnsii + ";";
                }
                else
                {
                    strUniCode = strUniCode + ch;
                }
            }
        }
        catch (FormatException e)
        {
            strUniCode = e.Message;
        }
        return strUniCode;
    }
    public static string decodeSMSMessage(String strMsg)
    {
        string strNewMsg = string.Empty;
        try
        {
            strMsg = strMsg.Replace("^*^", "'");
            strMsg = strMsg.Replace("&amp;", "&");
            strMsg = strMsg.Replace("???", "+");
            strMsg = strMsg.Replace("\r\n", "<br>");
            //strMsg = strMsg.Replace("\r\n", "<br/>");
            strNewMsg = strMsg;
            // vbCr = "\r"  //vbLf = "\n" //vbCrLf = "\r\n"
        }
        catch (FormatException e)
        {
            strNewMsg = e.Message;
        }
        return strNewMsg;
    }
    public static int Check_UserSMSBalanceSufficient(Double iDeductSMSCredits, Double iBalanceCredit)
    {
        int iStatus;

        if (iBalanceCredit > iDeductSMSCredits)
        {
            iStatus = 1;
        }
        else if (iBalanceCredit <= 0)
        {
            iStatus = -1;
        }
        else
        {
            iStatus = -1;
        }
        return iStatus;
    }
    protected void ctvMobile1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        List<String> sMobileList = Get_DistinctList(TextBoxMobileList.Text);
        Get_DistinctMobile(sMobileList);

        int i = 0;

        foreach (string sMobile in sMobileList)
        {
            i++;
        }

        String sComma = TextBoxMobileList.Text.Substring(TextBoxMobileList.Text.Length - 1);
        if (sComma == ",") { i = i - 1; }

        iTotalCount = i;
        ctvMobile1.ErrorMessage = "<b>Only 5000 Mobile Allowed</b><br/>Current Total Mobile : " + i;

        try
        {
            args.IsValid = ((i <= 5000));

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            args.IsValid = false;
        }
    }
    protected void Get_DistinctMobile(List<string> list)
    {

        string tMobileDistinctList = string.Join(",", list.ToArray());
        TextBoxMobileList.Text = tMobileDistinctList;
    }
    protected static List<String> Get_DistinctList(String tStringList)
    {
        List<string> list = new List<string>();
        List<string> strDistinctList = new List<string>();
        try
        {

            String[] tString = tStringList.Split(',');
            foreach (string tWord in tString)
            {
                list.Add(tWord);
            }

            strDistinctList = list.Distinct().ToList();
        }
        catch (FormatException ex)
        {
            strDistinctList = list;
            Console.WriteLine(ex);
        }
        return strDistinctList;
    }
}
