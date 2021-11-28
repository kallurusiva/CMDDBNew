using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SuperAdmin_SA_INFOedit : System.Web.UI.Page
{
    SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //string strSQL;
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
        int qInfoID = 0;


        if (Request.QueryString["qInfoID"].ToString() != null && Request.QueryString["qInfoID"].ToString() != "")
        {
            qInfoID = Convert.ToUInt16(Request.QueryString["qInfoID"]);
        }



        if (!IsPostBack)
        {

            ViewState["infoID"] = qInfoID; 
            LoadInfoData(qInfoID);

        }


        ltrHeader.Text = "EDIT INFO item";

       
     }




    protected void LoadInfoData(int qInfoID)
    {

        //if exists load Client partners Data;

        bool tmpdisplayAtWeb; 
        string tmpInfoContent = string.Empty; 
        string tmpClientPartnersData = string.Empty;

          CMSv3.BAL.Products objBAL_Products = new CMSv3.BAL.Products();

        DataSet ds;
        ds = objBAL_Products.INFO_Retrieve_byInfoID(qInfoID);

        DataTable dt = ds.Tables[0]; 

        if(dt.Rows.Count > 0)
        {
            DataRow drInfo;

            drInfo = dt.Rows[0];

            txtInfoTitle.Text = drInfo["infoTitle"].ToString();
            tmpInfoContent = drInfo["infoContent"].ToString();
            tmpdisplayAtWeb = Convert.ToBoolean(drInfo["isDisplay"].ToString());

            chkDisplayAtWeb.Checked = tmpdisplayAtWeb; 

        }

        myEditor.Content = tmpInfoContent;



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
        inStatus = objBAL_Products.INFO_Update(Convert.ToInt32(Session["saUserID"]), tmpInfoTitle, tmpstr, vDisplayatWeb,Convert.ToInt16(ViewState["infoID"].ToString()));
        
         

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
