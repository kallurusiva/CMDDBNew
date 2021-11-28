using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdmin_SA_INFOcreate : System.Web.UI.Page
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    string strSQL;
    //string tmpIncPlan;
    //int qLgType = 1;

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
       

       


        if (!IsPostBack)
        {


           // LoadClientPartnersData(qLgType);

        }


        ltrHeader.Text = "Add INFO item";

       
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
        myEditor.Content = tmpClientPartnersData;



    }


    protected void BtnSave_Click(object sender, EventArgs e)
    {


        //-- accessing the Selected Language 
        

        //string tmpstr = FCKeditor1.Value;
        string tmpstr = myEditor.Content.ToString();
        tmpstr = tmpstr.Replace("'", "''");


        String tmpInfoTitle = txtInfoTitle.Text.Trim(); 

        int vDisplayatWeb = Convert.ToInt16(chkDisplayAtWeb.Checked); 


        int inStatus;

        CMSv3.BAL.Products objBAL_Products = new CMSv3.BAL.Products();
        inStatus = objBAL_Products.INFO_Create(Convert.ToInt32(Session["saUserID"]), tmpInfoTitle, tmpstr, vDisplayatWeb);

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();

        //strSQL = "Insert into [tblClientPartners] (CPData,UserID,LgType) values (N'" + tmpstr + "'," + Convert.ToUInt32(Session["saUserID"]) + "," + mSelLanguage + ")"; 
        //dbCmd = new SqlCommand(strSQL, dbConn);
        //int rowCount = dbCmd.ExecuteNonQuery();

        //dbConn.Close();

        //if (rowCount >= 1)
        //    inStatus = 1;
        //else
        //    inStatus = -1;


        if (inStatus == 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Info Item successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";
            CommonFunctions.AlertMessage("INFO item created successfully.");
            Response.Redirect("SA_INFOListing.aspx");
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
