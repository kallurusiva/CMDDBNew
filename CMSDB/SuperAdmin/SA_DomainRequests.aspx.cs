using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;

public partial class SuperAdmin_SA_DomainRequests : BasePage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataAdapter dbAdap;
    SqlDataReader dbReader;

    string strSQL = string.Empty;
    

    DataSet ds;
    DataView dv;


    //CMSv3.BAL.Faq objBAl_Faq = new CMSv3.BAL.Faq();
    CMSv3.BAL.CommonFunc objBAL_CommonFunc = new CMSv3.BAL.CommonFunc();
    //int qLgType = 0;

    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "";

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


        strSQL = "select ReqID,DomainName,RequestDate,R.RegisteredStatus,R.RegisteredDate,R.UserID,U.FullName, U.Email, U.HandPhone,S.CompanyName,Usr.LoginID " +
                 "from tblDomainRequest R " +
                 "left outer join tblUserDetails U ON U.UserID = R.UserID  " +
                 "left outer join tblHomePageSettings S on S.Userid = R.UserId  " +
                 "left outer join tblUsers Usr on Usr.UserID = r.UserID  " +
                 "Where R.RegisteredStatus = 0 " +
                 "order by RequestDate desc ";


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


                gridDomainList.DataSource = dv;
                gridDomainList.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridDomainList.DataSource = ds;
                gridDomainList.DataBind();

                int ColCount = gridDomainList.Rows[0].Cells.Count;
                gridDomainList.Rows[0].Cells.Clear();
                gridDomainList.Rows[0].Cells.Add(new TableCell());
                gridDomainList.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridDomainList.Rows[0].Cells[0].Text = "No records Found";
                gridDomainList.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




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


    protected void gridDomainList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridDomainList.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridDomainList.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridDomainList.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridDomainList.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridDomainList_Sorting(object sender, GridViewSortEventArgs e)
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


    protected void gridDomainList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridDomainList.EditIndex = e.NewEditIndex;



        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

    }

    protected void gridDomainList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridDomainList.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridDomainList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //int rowCount;
        //Get the reference to the gridview row
        GridViewRow gRow = (GridViewRow)gridDomainList.Rows[e.RowIndex];

    //    //Get the reference to the TextFields in the grid view row
    //    TextBox tbFaqQuestion = (TextBox)gRow.FindControl("txtFaqQuestion");
    //    TextBox tbFaqAnswer = (TextBox)gRow.FindControl("txtFaqAnswer");
    //    Literal ltrFaqID = (Literal)gRow.FindControl("hdFaqID");
    //    HiddenField objHidUserType = (HiddenField)gRow.FindControl("hidUsertype");

        Literal ltrReqID = (Literal)gRow.FindControl("ltrReqID");
        HiddenField objHidUserID = (HiddenField)gRow.FindControl("hidUserID");
        CheckBox chkActive = (CheckBox)gRow.FindControl("chkActive");
        TextBox objTxtDomainName = (TextBox)gRow.FindControl("txtOwnDomainName");

        //HtmlInputRadioButton objrdoApprove = (HtmlInputRadioButton)gRow.FindControl("rdoApprove");
        //HtmlInputRadioButton objrdoReject = (HtmlInputRadioButton)gRow.FindControl("rdoReject");

        RadioButtonList objRDOApproveReject = (RadioButtonList)gRow.FindControl("rdolst_ApproveReject");

        
        int tmpApprove=0;
        if (objRDOApproveReject != null) 
            tmpApprove = Convert.ToInt16(objRDOApproveReject.SelectedValue);


        bool upStatus;

        if (tmpApprove == 2) //rejected
        {

            upStatus = objBAL_CommonFunc.Update_DomainRequestStatus(objTxtDomainName.Text, Convert.ToInt32(objHidUserID.Value), tmpApprove , Convert.ToInt32(ltrReqID.Text));

            //Send Rejection Email
            //SendEmail_DomainRequestStatus("Rejected", objTxtDomainName.Text, objHidUserID.Value);

        }
        else //approved
        {
            upStatus = objBAL_CommonFunc.Update_DomainRequestStatus(objTxtDomainName.Text, Convert.ToInt32(objHidUserID.Value), tmpApprove , Convert.ToInt32(ltrReqID.Text));
            //Send Approved Email
            //SendEmail_DomainRequestStatus("Approved", objTxtDomainName.Text, objHidUserID.Value);
        }

    

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


        if (upStatus)
        {
            tblMessageBar.Visible = true;
            lblErrMessage.Text = "Domain request Status Updated Sucessfully";
            lblErrMessage.CssClass = "font_12Msg_Success";
            MessageImage.Src = "~/Images/inf_Sucess.gif";
        }
        else
        {
            lblErrMessage.Text = "Could not Update the status. Technical Error";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
        }

        gridDomainList.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

}

    

    //protected void gridDomainList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int rowcount = 0;
    //    //Get the reference to the gridview row
    //    GridViewRow gvRow = (GridViewRow)gridDomainList.Rows[e.RowIndex];

    //    //Getting EnquiryID reference
    //    Literal ltrenqID = (Literal)gvRow.FindControl("hdenqID");

    //    int EnqIdToDelte = Convert.ToInt32(ltrenqID.Text);

    //   // bool delStatus = objBAL_Faq.DeleteFaqData(Convert.ToInt32(Session["UserID"]), FaqIdToDelte);
    //    strSQL = "Update tblEnquiry set Deleted = 1 where enqId = " + EnqIdToDelte + " and UserID = " + Convert.ToInt32(Session["UserID"]);
    //    dbConn = new SqlConnection(GlobalVar.GetDbConnString);

    //    try
    //    {
    //        dbConn.Open();
    //        dbCmd = new SqlCommand(strSQL, dbConn);

    //        rowcount = dbCmd.ExecuteNonQuery();

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        dbConn.Close();
    //    }


    //    if (rowcount >= 1)
    //    {
    //        tblMessageBar.Visible = true;
    //        lblErrMessage.Text = "Item Deleted Sucessfully";
    //        lblErrMessage.CssClass = "font_12Msg_Success";
    //        MessageImage.Src = "~/Images/inf_Sucess.gif";

    //    }
    //    else
    //    {
    //        lblErrMessage.Text = "Could not delete the item. Technical Error";
    //        lblErrMessage.CssClass = "font_12Msg_Error";
    //        tblMessageBar.Visible = true;
    //        MessageImage.Src = "~/Images/inf_Error.gif";
    //    }


    //    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    //}



    protected void gridDomainList_DataBound(object sender, EventArgs e)
    {

        //CommonFunctions.InitialiseGridViewPagerRow(gridDomainList.BottomPagerRow, gridDomainList);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridDomainList.BottomPagerRow, gridDomainList);

    }

    protected void gridDomainList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {

            //CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            //objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");

            //To get the up/down image at the sorted column 
            //CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //CheckBox objChkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //objChkSelect.Attributes.Add("onClick", "SelectRow('" + objChkSelect.ClientID + "')");
            //if (gridDomainList.Rows.Count > 0)
            //{

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");



            ////..Getting reference to the lblModifiedBy control 
            //Label objModByLabel = (Label)e.Row.FindControl("lblModifiedBy");
            //string strModifiedBy = objModByLabel.Text;


            //DataRowView drv = ((DataRowView)e.Row.DataItem);

            //TextBox objfaqAnswer = (TextBox)e.Row.FindControl("txtFaqAnswer");
            //if (objfaqAnswer != null)
            //{
            //    string tmpstr = drv["FaqAnswer"].ToString().Replace("<br/>", Environment.NewLine);
            //    objfaqAnswer.Text = tmpstr;
            //}

           

            //.. getting reference the gridview row in row databound event. 
            string strLoginName = string.Empty;
            DataRowView rowView = (DataRowView)e.Row.DataItem;

            //need to find out if the logged users is not a superadmin disable the last cell 

            //============

            Literal objLtrActive = (Literal)e.Row.FindControl("LtrActive");
            Image objImgActive = (Image)e.Row.FindControl("ImgActive");

            //String LtrShowActive = rowView["LtrActive"].ToString();

            if (objImgActive != null)
            {
                if (objLtrActive.Text != "")
                {
                    if (objLtrActive.Text == "1")
                    {

                        objImgActive.ImageUrl = @"~\Images\Active_Show.jpg";
                        //objImgActive.ImageUrl = @"~\Images\checkbox_ticked.jpg";

                    }
                    else if (objLtrActive.Text == "2")
                    {
                        objImgActive.ImageUrl = @"~\Images\Active_Hide.jpg";
                        //objImgActive.ImageUrl = @"~\Images\checkbox_empty.jpg";
                    }
                    else
                    {
                        objImgActive.ImageUrl = @"~\Images\inf_notice.gif";
                        
                    }
                }
            }


        }

    }


    protected void SendEmail_DomainRequestStatus(string vEmailType, string vDomainName,string vUserID)
    {

        //Get Admin Email Address and Name.
        string mFullName = string.Empty;
        string mEmailAddress = string.Empty;
        string mEmailSubject = "Domain Name Request Status - " + GlobalVar.GetAnchorDomainName;
        string mEmailFrom = "SupportTeam@" + GlobalVar.GetAnchorDomainName;
        string mUserWebSiteName = string.Empty;
        string mUserHandPhone = string.Empty;
        string mEmailBody = string.Empty;
        string mSmsBody = string.Empty;


        if (vEmailType.ToLower() == "approved")
        {
            mEmailBody = "Your request for Domain Name registration. <b><u>" + vDomainName + "</u></b> has been approved and completed.<br/><br/> " +
                                "You can now have access to your website using your own Domain Name. <br/>" +
                                "<br/><br/>" +
                                "Please do let us know if you encounter any difficulties";

      
        }
        else
        {
            mEmailBody = "Your request for Domain Name registration. <b><u>" + vDomainName + "</u></b> is rejected. </b>" +
                          "<br/><br/>" +                      
                               "<b>The Domain is already taken.Please login to select a different domain name. </b><br/>" +
                               "Plese check if your domain name is available or domain name does not contain any invalid characters. <br/>" +
                               "<br/><br/>";
                               
        }

        try
        {
            dbConn = new SqlConnection(GlobalVar.GetDbConnString);
            dbConn.Open();
            strSQL = "EXEC [usp_Retreive_EmailDetails_ByUserID] " + Convert.ToInt32(vUserID);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    mFullName = dbReader["FullName"].ToString();
                    mEmailAddress = dbReader["Email"].ToString();
                    mUserWebSiteName = dbReader["WebSiteName"].ToString();
                    mUserHandPhone = dbReader["HandPhone"].ToString();

                }

            }

            CommonFunctions.GenericSendEmail(mEmailAddress, mEmailFrom, mEmailBody, mEmailSubject, mFullName, "", "");

            if (vEmailType.ToLower() == "approved")
            {
                mSmsBody = Environment.NewLine;
                mSmsBody = mSmsBody + "Congratulations " + mFullName + ". ";
                mSmsBody = mSmsBody + "Your domain " + mUserWebSiteName + " is setup and now ready. ";
                mSmsBody = mSmsBody + "Thank you for your support.";
                //mSmsBody = mSmsBody + Environment.NewLine + Environment.NewLine;
                //mSmsBody = mSmsBody + "www." + GlobalVar.GetAnchorDomainName;

                if (mUserHandPhone != null)
                    CommonFunctions.MySendSMS(mSmsBody, mUserHandPhone, GlobalVar.GetAnchorDomainName);

            }
            else
            {
                mSmsBody = Environment.NewLine;
                mSmsBody = mSmsBody + "Dear " + mFullName + ". ";
                mSmsBody = mSmsBody + "Your request for Domain: " + vDomainName + " could not be setup.";
                mSmsBody = mSmsBody + "Please raise your request again.";
                //mSmsBody = mSmsBody + Environment.NewLine + Environment.NewLine;
                //mSmsBody = mSmsBody + "www." + GlobalVar.GetAnchorDomainName;

                if (mUserHandPhone != null)
                    CommonFunctions.MySendSMS(mSmsBody, mUserHandPhone, GlobalVar.GetAnchorDomainName);
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
