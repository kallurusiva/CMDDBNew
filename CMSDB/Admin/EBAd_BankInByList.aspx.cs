using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

public partial class EBAd_BankInByList : System.Web.UI.Page 
{

    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;


    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check 

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 


       

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "DateCreated";

            
            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }

        tblMessageBar.Visible = false;
        MaintainScrollPositionOnPostBack = true; 
    }

    
    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

      //  ds = objPayPal.EB_PayPal_RetrieveTX(Convert.ToInt32(Session["UserID"]), ""); 

        int vUserID = Convert.ToInt32(Session["UserID"]);

        ds = objBALebook.Bank_Client_GetBankInsList(vUserID, "");

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);

            
            gridBankInBys.DataSource = dv;
            gridBankInBys.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            gridBankInBys.DataSource = ds;
            gridBankInBys.DataBind();

            int ColCount = gridBankInBys.Rows[0].Cells.Count;
            gridBankInBys.Rows[0].Cells.Clear();
            gridBankInBys.Rows[0].Cells.Add(new TableCell());
            gridBankInBys.Rows[0].Cells[0].ColumnSpan = ColCount;
            gridBankInBys.Rows[0].Cells[0].Text = "No records Found";
            gridBankInBys.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




        }



    }


    protected void gridBankInBys_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridBankInBys.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridBankInBys.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridBankInBys.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridBankInBys.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridBankInBys_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridBankInBys.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void gridBankInBys_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       

       // //Get the reference to the gridview row
       // GridViewRow gvRow = (GridViewRow)gridBankInBys.Rows[e.RowIndex];

       // //Getting eventID reference
       // HiddenField ObjhdFreeEbookUID = (HiddenField)gvRow.FindControl("hdFreeEbookUID");

       // int tmpBSuid = Convert.ToInt32(ObjhdFreeEbookUID.Value); 

       //// int delStatus = objEbook.EBook_Delete(ObjhdBookId.Value, Convert.ToInt32(ObjhdUID.Value));

       // int delStatus = objEbook.EBook_FreeEbook_Delete(tmpBSuid); 

       // //int delStatus = 1; 
       // if (delStatus >= 1)
       // {
       //     tblMessageBar.Visible = true;
       //     lblErrMessage.Text = "Ebook unMarked as Best Seller Sucessfully";
       //     lblErrMessage.CssClass = "font_12Msg_Success";
       //     MessageImage.Src = "~/Images/inf_Sucess.gif";

       //     PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

       // }
       // else
       // {
       //     lblErrMessage.Text = "Could not unMark the Ebook as Best Seller. Technical Error";
       //     lblErrMessage.CssClass = "font_12Msg_Error";
       //     tblMessageBar.Visible = true;
       //     MessageImage.Src = "~/Images/inf_Error.gif";

       // }



       // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('eBook unMarked as Best-Seller successfully')", true);




    }


    protected void gridBankInBys_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //gridBankInBys.EditIndex = e.NewEditIndex;
        //PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //GridViewRow gRow = (GridViewRow)gridBankInBys.Rows[e.NewEditIndex];
        //Literal ltrTstID = (Literal)gRow.FindControl("hdTstId");
        gridBankInBys.EditIndex = e.NewEditIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //Server.Transfer("TestimonialViewEdit.aspx?TestimonialID=" + ltrTstID.Text);
    }



    protected void gridBankInBys_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridBankInBys.BottomPagerRow, gridBankInBys);
    }


    protected void gridBankInBys_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            //objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");

            ////To get the up/down image at the sorted column 
            //CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {     
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");

            String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();
            //instead of server.mapPath set the path in web.config file and use that path.
            String ImgFileUrl = Server.MapPath("~") + tmpImageFolder + "/BankInSlips/";

            Label objlblBankinSlip = (Label)e.Row.FindControl("lblBankInSlip"); 

            HyperLink objHypBankInSlip = (HyperLink)e.Row.FindControl("HypBankInSlip");
            //objHypBankInSlip.NavigateUrl = ImgFileUrl + objlblBankinSlip.Text;

            objHypBankInSlip.NavigateUrl = "javascript:OpenWindow('" + objlblBankinSlip.Text + "')";

            HiddenField objhidRcvStatus = (HiddenField)e.Row.FindControl("hidRcvStatus");
            LinkButton objLnkBtnConfirmation = (LinkButton)e.Row.FindControl("LnkBtnConfirmation");
            LinkButton objLnkResendEmail = (LinkButton)e.Row.FindControl("LnkResendEmail");
            string hdrcv = objhidRcvStatus.Value.ToString();
            if (objhidRcvStatus.Value.ToString() == "1")
            {
                objLnkBtnConfirmation.Visible = false;
                objLnkResendEmail.Visible = true;
            }
            
        }
    }



   
    protected void gridBankInBys_Sorting(object sender, GridViewSortEventArgs e)
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

      

    protected void gridBankInBys_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "EditByUser")
        {
           // grdListUsers.SelectedIndex = Convert.ToInt32(e.CommandArgument);


            string s = e.CommandArgument.ToString();

            string[] strInfo = s.Split(',');

            for (int i = 0; i < strInfo.Length; i++)
            {
                hdn_UId.Value = strInfo[0];
                hdn_TranID.Value = strInfo[1];


            }

            Server.Transfer(@"EBAd_FreeEbookEdit.aspx");
        }

    }


    protected void OnCommand_ConfirmPayment(object sender, CommandEventArgs e)
    {
        string[] IDs = e.CommandArgument.ToString().Split(',');
        string qUID = string.Empty;
        String qTransactionID = string.Empty; 

        foreach (string ID in IDs)
        {
            hdn_UId.Value = IDs[0];
            hdn_TranID.Value = IDs[1];
        }
    }

  
}
