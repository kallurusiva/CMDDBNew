using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdmin_SA_IncentivePlanCreate : System.Web.UI.Page
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    //SqlDataReader dbReader;
    string strSQL;
    //string tmpIncPlan;
    
    


    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 


        ////FCKeditor1.BasePath = "~/OtherUtils/fckeditor/";
        ////FCKeditor1.ImageBrowserURL = "~/Images/";
        ////FCKeditor1.AutoDetectLanguage = true;
        ////FCKeditor1.Width = 1024;
        ////FCKeditor1.Height = 512;

              
                


        LtrAddIncentivePlan.Text = Resources.LangResources.Incentiveplan;
     }

    protected void BtnSave_Click(object sender, EventArgs e)
    {

        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage4Create");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);

        if (mSelLanguage == 0)
            mSelLanguage = 1;

        

        //HtmlTextArea tmpTA = (HtmlTextArea)this.FindControl("myEditor");
        string tmpstr = myEditor.Content.ToString();

        ////string tmpstr = FCKeditor1.Value;
        tmpstr = tmpstr.Replace("'", "''");

        int inStatus;       

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        strSQL = "Insert into tblIncentivePlan (PlanData,UserID,LgType) values (N'" + tmpstr + "'," + Convert.ToUInt32(Session["saUserID"]) + "," + mSelLanguage + ")"; 
        dbCmd = new SqlCommand(strSQL, dbConn);
        int rowCount = dbCmd.ExecuteNonQuery();

        dbConn.Close();

        if (rowCount >= 1)
            inStatus = 1;
        else
            inStatus = -1;


        if (inStatus == 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Incentive Plan successfully added";
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
}
