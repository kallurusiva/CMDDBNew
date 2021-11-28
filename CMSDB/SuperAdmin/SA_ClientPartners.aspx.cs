using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdmin_SA_ClientPartners : System.Web.UI.Page
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    string strSQL;
    //string tmpIncPlan;
    int qLgType = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 


        //FCKeditor1.BasePath = "~/OtherUtils/fckeditor/";
        //FCKeditor1.ImageBrowserURL = "~/Images/";
        //FCKeditor1.AutoDetectLanguage = true;
        //FCKeditor1.Width = 1024;
        //FCKeditor1.Height = 512;

        //int mLanguage= 1;
       

        if (Request.QueryString["LgType"] != null)
            qLgType = Convert.ToInt16(Request.QueryString["LgType"]);

        // ddlLanguage.SelectedValue = Convert.ToString(mLanguage);
        


        if (!IsPostBack)
        {


            LoadClientPartnersData(qLgType);

        }




       ltrClientPartners.Text = Resources.LangResources.clientpartners;
     }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        //PreSelecting the Language DropDown --
        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");

        if (objddlSelLang.Items[0].ToString() == "ALL")
        {
            objddlSelLang.Items.RemoveAt(0);
        }

        objddlSelLang.SelectedValue = Convert.ToString(qLgType);


    }


    protected void LoadClientPartnersData(int vLanguage)
    {

        //if exists load Client partners Data;

        //int inStatus;
        string tmpClientPartnersData = string.Empty;

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        strSQL = "Select CPid,CPdata,UserId,LgType from [tblClientPartners] where UserID = " + Convert.ToUInt32(Session["saUserID"]) + " and LgType = " + vLanguage;
        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                tmpClientPartnersData = dbReader["CpData"].ToString();
                hidCpid.Value = dbReader["cpID"].ToString();
            }

        }
        else
        {
            tmpClientPartnersData = "<br> No Content for Client Partner has been added yet. Type  your Client Partners details here.";
        }

        dbConn.Close();

        // txtIncPlanContent.Value = tmpIncPlanContent;
        //FCKeditor1.Value = tmpClientPartnersData;
        myEditor.Value = tmpClientPartnersData;



    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {


        //-- accessing the Selected Language 
        ContentPlaceHolder cph = Page.Master.FindControl("ContentBody") as ContentPlaceHolder;
        UserControl uc = (UserControl)cph.FindControl("ucSelectLanguage");
        DropDownList objddlSelLang = (DropDownList)uc.FindControl("ddlLanguage");
        int mSelLanguage = Convert.ToUInt16(objddlSelLang.SelectedValue);

        if (mSelLanguage == 0)
            mSelLanguage = 1;



        //string tmpstr = FCKeditor1.Value;
        string tmpstr = myEditor.Value;
        tmpstr = tmpstr.Replace("'", "''");

        int inStatus;       

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        strSQL = "Insert into [tblClientPartners] (CPData,UserID,LgType) values (N'" + tmpstr + "'," + Convert.ToUInt32(Session["saUserID"]) + "," + mSelLanguage + ")"; 
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
            lblErrMessage.Text = "Client Partners information successfully added";
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
