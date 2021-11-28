using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;

public partial class Admin_Ad_TestimonialHome : BasePage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    //SqlDataReader dbReader;

    DataSet ds;
    //DataView dv;
    //protected System.Web.UI.WebControls.Literal PageType;
        
    string strSQL = string.Empty;

    
    string tblName = "tblTestimonial";
    string tblColumn = "TstID";


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
        ltrHeader.Text = Resources.LangResources.Testimonial + " " + Resources.LangResources.Summary;

        
        //PageType.Text = Resources.LangResources.Testimonial;
        string PageTypeText = Resources.LangResources.Testimonial;

        //ltrPageType1.Text = PageTypeText;
        //ltrPageType2.Text = PageTypeText;
        //ltrPageType3.Text = PageTypeText;
        //ltrPageType4.Text = PageTypeText;
        //ltrPageType5.Text = PageTypeText;
        //ltrPageType6.Text = PageTypeText;
        

        if (!IsPostBack)
        { 
            PopulateItemSummary();
        }

        
        
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

    //protected void PopulateItemSummary()
    //{

    //    //ds = objBAL_Faq.Retrieve_FaqSUmmary_ByUserID(Convert.ToInt32(Session["UserID"]));

    //    //strSQL = "EXEC [usp_Faq_Retreive_Summary] " + Convert.ToInt32(Session["UserID"]);
    //    strSQL = "EXEC [usp_TableItem_Retreive_Summary] " + Convert.ToInt32(Session["UserID"]) + "," + tblName + "," + tblColumn;
        

    //    try
    //    {
    //        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
    //        dbConn.Open();

    //        dbCmd = new SqlCommand(strSQL, dbConn);
    //        dbReader = dbCmd.ExecuteReader();

    //        if (dbReader.HasRows)
    //        {
    //            while (dbReader.Read())
    //            {
    //                ltrSys_En_count.Text = "<b>" +  dbReader["sa_En_count"].ToString() + "</b>";
    //                ltrSys_My_count.Text = "<b>" + dbReader["sa_My_count"].ToString() + "</b>";

    //                ltrUs_En_count.Text = "<b>" + dbReader["us_En_count"].ToString() + "</b>";
    //                ltrUs_My_count.Text = "<b>" + dbReader["us_My_count"].ToString() + "</b>";

    //                ltrWeb_En_Count.Text = "<b>" + dbReader["Web_En_Count"].ToString() + "</b>";
    //                ltrWeb_My_Count.Text = "<b>" + dbReader["Web_My_Count"].ToString() + "</b>";

    //                ltrLoginUserID.Text = dbReader["LoginID"].ToString();
    //                ltrLoginUserID2.Text = dbReader["LoginID"].ToString();

    //                int UsrEnCount = Convert.ToInt32(dbReader["us_En_count"].ToString());
    //                int UsrMyCont = Convert.ToInt32(dbReader["us_My_count"].ToString());

    //                int WebEncount = Convert.ToInt32(dbReader["Web_En_Count"].ToString());
    //                int WebMycount = Convert.ToInt32(dbReader["Web_My_Count"].ToString());

    //                //if ((WebEncount == 0) && (WebMycount == 0))
    //                //{
    //                //    rdoAppearanceStatus.Items[1].Selected = true;
    //                //}
    //                if ((UsrEnCount == WebEncount) || (UsrMyCont == WebMycount))
    //                {
    //                    rdoAppearanceStatus.Items[1].Selected = true;   // do no show Admin Itmes 
    //                }
    //                else
    //                {
    //                    rdoAppearanceStatus.Items[0].Selected = true;
    //                }

    //            }
    //        }
          

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        dbConn.Close();
    //    }
        

    //}




    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (rdoAppearanceStatus.SelectedValue == "0")
        {
            strSQL = "EXEC  [usp_ShowAdmin_SET_DisplayStatus] " + tblName + "," + tblColumn +  "," + Convert.ToInt32(Session["UserId"]) + ",'DISPLAY'";
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

                Response.Redirect("Ad_TestimonialHome.aspx");

            }
            else
            {
              //  tblMessageBar.Visible = true;
              //  MessageImage.Src = "~/Images/inf_Error.gif";
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
