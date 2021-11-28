using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;
using System.IO;
using System.Text;


public partial class Admin_Ad_EmailListing : BasePage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataAdapter dbAdap;

    DataSet ds;
    DataView dv;

    string strSQL;

    //CMSv3.BAL.Faq objBAl_Faq = new CMSv3.BAL.Faq();
    CMSv3.BAL.FAQ objBAL_Faq = new CMSv3.BAL.FAQ();
    //int qLgType = 0;

    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 


        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "CreatedDate";

            #region Setting ViewState for Retrieval Type -- USER , ADMIN or ALL

            
            if (Request.QueryString["RtType"] != null)
            {

                switch (Request.QueryString["RtType"].ToString())
                {
                    case "USER": ViewState["RtType"] = "USER";
                        break;
                    case "ADMIN": ViewState["RtType"] = "ADMIN";
                        break;
                    case "ALL": ViewState["RtType"] = "ALL";
                        break;
                    default: ViewState["RtType"] = "USER";
                        break;
                }
            }
            else
            {
                ViewState["RtType"] = "USER";
            }

            #endregion

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

            
        }
        else
        {
           
        }

        tblMessageBar.Visible = false;
    }

    


    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        //ds = objBAL_Faq.Retrieve_AllFaqByUserID(Convert.ToInt32(Session["UserID"]));



        //strSQL = "Select enqID, Name,ContactNo, Email, Subject, Body, enqType,CreatedDate,UserID,CountryName," +
        //        "Case When enqType = 1 Then 'ContactUs' ELSE 'Free Registration' END as 'enqTypeText' " +
        //            " from tblEnquiry T " +
        //            " left outer join tblCountry C on t.CountryCode = C.CountryCode " +
        //            "where UserId = " + Convert.ToInt32(Session["UserID"]) +
        //            " and deleted = 0 order By CreatedDate desc";

        strSQL = "EXEC [usp_EmailsCaptured_RetreiveByUserID]" + Convert.ToInt32(Session["UserID"]);

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);

            dbAdap = new SqlDataAdapter(dbCmd);
            ds = new DataSet();
            dbAdap.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {

                dv = ds.Tables[0].DefaultView;
                if (vSortExpr != string.Empty)
                {
                    
                    dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
                }


                gridEmailList.DataSource = dv;
                gridEmailList.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridEmailList.DataSource = ds;
                gridEmailList.DataBind();

                int ColCount = gridEmailList.Rows[0].Cells.Count;
                gridEmailList.Rows[0].Cells.Clear();
                gridEmailList.Rows[0].Cells.Add(new TableCell());
                gridEmailList.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridEmailList.Rows[0].Cells[0].Text = "No records Found";
                gridEmailList.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




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


    protected void gridEmailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEmailList.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridEmailList.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridEmailList.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridEmailList.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridEmailList_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    public string sortOrder
    {
        get
        {
            if (ViewState["sortOrder"].ToString() == "desc")
            {
                ViewState["sortOrder"] = "asc";

            }
            else
            {
                ViewState["sortOrder"] = "desc";
            }

            return ViewState["sortOrder"].ToString();
        }
        set
        {
            ViewState["sortOrder"] = value;
        }
    }


    //protected void gridEmailList_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gridEmailList.EditIndex = e.NewEditIndex;

      

    //    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    //}

    //protected void gridEmailList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gridEmailList.EditIndex = -1;
    //    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    //}

    //protected void gridEmailList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    //Get the reference to the gridview row
    //    GridViewRow gRow = (GridViewRow)gridEmailList.Rows[e.RowIndex];

    //    //Get the reference to the TextFields in the grid view row
    //    TextBox tbFaqQuestion = (TextBox)gRow.FindControl("txtFaqQuestion");
    //    TextBox tbFaqAnswer = (TextBox)gRow.FindControl("txtFaqAnswer");
    //    Literal ltrFaqID = (Literal)gRow.FindControl("hdFaqID");
    //    HiddenField objHidUserType = (HiddenField)gRow.FindControl("hidUsertype");
    //    HiddenField objHidUserID = (HiddenField)gRow.FindControl("hidUserID");

    //    CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");

    //    string tmpFaqAnswer = tbFaqAnswer.Text;
    //    tmpFaqAnswer = tmpFaqAnswer.ToString().Replace(Environment.NewLine, "<br/>");

    //    bool upStatus;
    //    if (Convert.ToInt16(objHidUserType.Value) == 2)
    //    {
    //        ////..if exists update else insert 
    //        //SqlConnection dbconn = new SqlConnection(GlobalVar.GetDbConnString.ToString());
    //        //dbconn.Open();

    //        //string strSQL = "Insert tblShowAdminItems (ItemTable, ItemIds, ForUserID) values ('tblFAQ'," + Convert.ToInt32(ltrFaqID.Text) + "," + Convert.ToInt32(Session["UserID"]) + ")";

    //        //SqlCommand dbCmd = new SqlCommand(strSQL,dbconn);
    //        //dbCmd.ExecuteNonQuery();
    //        //dbconn.Close();

    //        CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
    //        upStatus = objBAL_CommonFunc.InsertUpdate_ShowAdminItems("tblFAQ",ltrFaqID.Text, Convert.ToInt32(Session["UserID"]));
                        
    //    }
    //    else
    //    {
    //        upStatus = objBAL_Faq.UpdateFaqData(tbFaqQuestion.Text, tmpFaqAnswer, Convert.ToInt32(objHidUserID.Value), Convert.ToInt32(ltrFaqID.Text), chkActive.Checked,1);
    //    }
    //    if (upStatus)
    //    {
    //        tblMessageBar.Visible = true;
    //        lblErrMessage.Text = "Faq Updated Sucessfully";
    //        lblErrMessage.CssClass = "font_12Msg_Success";
    //        MessageImage.Src = "~/Images/inf_Sucess.gif";
    //    }
    //    else
    //    {
    //        lblErrMessage.Text = "Could not Update the Faq. Technical Error";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";
    //    }

    //    gridEmailList.EditIndex = -1;
    //    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    //}

    

    protected void gridEmailList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowcount = 0;
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridEmailList.Rows[e.RowIndex];

        //Getting EnquiryID reference
        Literal ltrenqID = (Literal)gvRow.FindControl("hdenqID");

        int EnqIdToDelte = Convert.ToInt32(ltrenqID.Text);

       // bool delStatus = objBAL_Faq.DeleteFaqData(Convert.ToInt32(Session["UserID"]), FaqIdToDelte);
        strSQL = "Update tblEnquiry set Deleted = 1 where enqId = " + EnqIdToDelte + " and UserID = " + Convert.ToInt32(Session["UserID"]);
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);

            rowcount = dbCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }


        if (rowcount >= 1)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Item Deleted Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";

        }
        else
        {
            lblErrMessage.Text = "Could not delete the item. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }


        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void gridEmailList_DataBound(object sender, EventArgs e)
    {

        //CommonFunctions.InitialiseGridViewPagerRow(gridEmailList.BottomPagerRow, gridEmailList);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridEmailList.BottomPagerRow, gridEmailList);

    }


    protected void btn2Excel_Click(object sender, EventArgs e)
    {

        PrepareGridViewForExport(gridEmailList);

        DateTime Cdt = DateTime.Now;

        string tmpAttachment = "attachment;filename=EmailCapturedList_" + Cdt.Year + Cdt.Month + Cdt.Day + Cdt.Hour + Cdt.Minute + ".xls";
        strSQL = "EXEC [usp_EmailsCaptured_RetreiveByUserID]" + Convert.ToInt32(Session["UserID"]);

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);

            dbAdap = new SqlDataAdapter(dbCmd);
            ds = new DataSet();
            dbAdap.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dv = ds.Tables[0].DefaultView;
            }
            else
            {

                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                dv = ds.Tables[0].DefaultView;
            }

            
            
            gridEmailList.DataSource = dv;
            gridEmailList.HeaderStyle.BackColor = System.Drawing.Color.Ivory;
            gridEmailList.HeaderStyle.Font.Bold = true;
            gridEmailList.AllowPaging = false;
            gridEmailList.AllowSorting = false;
            gridEmailList.Columns[9].Visible = false;
            gridEmailList.DataBind();

            //GridView gv = new GridView();
            //gv.DataSource = dv;
            //gv.DataBind();
            //gv.HeaderStyle.BackColor = System.Drawing.Color.Beige;
            //gv.HeaderStyle.Font.Bold = true;

            Response.Clear();
            Response.AddHeader("content-disposition",tmpAttachment);
            Response.Charset = "";
            Response.ContentType = "application/ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            gridEmailList.RenderControl(htmlWrite);
            //gridEmailList.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

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

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    private void PrepareGridViewForExport(Control gv)
    {
        LinkButton lb = new LinkButton();
        Literal l = new Literal();
        string name = String.Empty;
        for (int i = 0; i < gv.Controls.Count; i++)
        {
            if (gv.Controls[i].GetType() == typeof(LinkButton))
            {
                l.Text = (gv.Controls[i] as LinkButton).Text;
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            else if (gv.Controls[i].GetType() == typeof(DropDownList))
            {
                l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            else if (gv.Controls[i].GetType() == typeof(CheckBox))
            {
                l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            if (gv.Controls[i].HasControls())
            {
                PrepareGridViewForExport(gv.Controls[i]);
            }
        }
    }


}
