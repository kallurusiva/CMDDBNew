using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;

public partial class Admin_Ad_EventHome : BasePage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    //SqlDataReader dbReader;

    DataSet ds;
    //DataView dv;

    string strSQL = string.Empty;

    string tblName = "tblEvents";
    string tblColumn = "EventId";


    //CMSv3.BAL.Faq objBAl_Faq = new CMSv3.BAL.Faq();
    //CMSv3.BAL.FAQ objBAL_Faq = new CMSv3.BAL.FAQ();
    //int qLgType = 0;

    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        // Language rendering 

        ltrHeader.Text = Resources.LangResources.Events + " " + Resources.LangResources.Summary;
        
        if (!IsPostBack)
        { 
            PopulateItemSummary();
        }


        //PageType.Text = Resources.LangResources.Testimonial;
        string PageTypeText = Resources.LangResources.Events;

        //ltrPageType1.Text = PageTypeText;
        //ltrPageType2.Text = PageTypeText;
        //ltrPageType3.Text = PageTypeText;
        //ltrPageType4.Text = PageTypeText;
        //ltrPageType5.Text = PageTypeText;
        //ltrPageType6.Text = PageTypeText;

        //tblMessageBar.Visible = false;
    }



    protected void PopulateItemSummary()
    {

      //  ds = objBAL_Faq.Retrieve_FaqSUmmary_ByUserID(Convert.ToInt32(Session["UserID"]));

        //strSQL = "EXEC [usp_Faq_Retreive_Summary] " + Convert.ToInt32(Session["UserID"]);
        CMSv3.BAL.AdminSettings objBal_AdminSettings = new CMSv3.BAL.AdminSettings();

        int tmpUserId = Convert.ToInt32(Session["UserID"]);


        ds = objBal_AdminSettings.GetSummary_ByTable(tmpUserId, tblName, tblColumn);

        //        strSQL = "EXEC [usp_TableItem_Retreive_Summary] " + Convert.ToInt32(Session["UserID"]) + "," + tblName + "," + tblColumn;


        if (ds.Tables[0].Rows.Count > 0)
        {

            // DataRow utRow = ds.Tables[0].Rows[0];

            //  DataTable dt = ds.Tables[0];

            // DataRow utRow; 

            DataView dv = ds.Tables[0].DefaultView;


            lblCnt_SfEng.Text = "0";
            lblCnt_SfBhM.Text = "0";
            lblCnt_SfChn.Text = "0";

            lblCnt_AdEng.Text = "0";
            lblCnt_AdBhM.Text = "0";
            lblCnt_AdChn.Text = "0";



            foreach (DataRow utRow in dv.Table.Rows)
            {
                int mUserId = Convert.ToInt32(utRow["UserId"].ToString());
                int mLgType = Convert.ToInt16(utRow["Lgtype"].ToString());
                string mCount = utRow["ItemCount"].ToString();


                if (mUserId == tmpUserId)
                {

                    switch (mLgType)
                    {
                        case 1: lblCnt_SfEng.Text = mCount; break;
                        case 2: lblCnt_SfBhM.Text = mCount; break;
                        case 3: lblCnt_SfChn.Text = mCount; break;
                    }
                }
                else
                {

                    switch (mLgType)
                    {
                        case 1: lblCnt_AdEng.Text = mCount; break;
                        case 2: lblCnt_AdBhM.Text = mCount; break;
                        case 3: lblCnt_AdChn.Text = mCount; break;
                    }
                }

            }


        }

        DataTable dtSAitems = ds.Tables[1];

        if (dtSAitems.Rows.Count > 0)
        {
            DataRow sRow = dtSAitems.Rows[0];

            string saCount = sRow["saCount"].ToString();

            if (saCount == "0")
            {
                rdoAppearanceStatus.Items[0].Selected = true;   // show Admin Itmes 
            }
            else
            {
                rdoAppearanceStatus.Items[1].Selected = true;   // do no show Admin Itmes 
            }

        }
        

    }




    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (rdoAppearanceStatus.SelectedValue == "0")
        {
            strSQL = "EXEC  [usp_ShowAdmin_SET_DisplayStatus] " + tblName + "," + tblColumn + "," + Convert.ToInt32(Session["UserId"]) + ",'DISPLAY'";
        }
        else
        {

            strSQL = "EXEC  [usp_ShowAdmin_SET_DisplayStatus] " + tblName + "," + tblColumn + "," + Convert.ToInt32(Session["UserId"]) + ",'HIDE'";
        }

        try
        {
            dbConn = new SqlConnection(GlobalVar.GetDbConnString);
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);
            int rowCount = dbCmd.ExecuteNonQuery();

            if (rowCount >= 0)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Sucess.gif";
                lblErrMessage.Text = "Settings successfully changed.";
                lblErrMessage.CssClass = "font_12Msg_Success";

                //CommonFunctions.AlertMessage("Status Changed");
               //CommonFunctions.AlertMessageAndRedirect("Status Changed", "Ad_FaqHome.aspx");


                //string javaScript = "<script language=JavaScript>alert('Status Changed'); window.location.href = 'Ad_FaqHome.aspx';</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "loadScript", javaScript, true);
                //Page.ClientScript.RegisterStartupScript(typeof(

                Response.Redirect("Ad_EventHome.aspx");

            }
            else
            {
             //   tblMessageBar.Visible = true;
             //   MessageImage.Src = "~/Images/inf_Error.gif";
              //  lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the record. Please contant Administrator";
              //  lblErrMessage.CssClass = "font_12Msg_Error";
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }



    }
}
