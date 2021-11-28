using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using CMSv3.BAL;
using System.Threading;


public partial class eBooksViewCart : UserWeb
{

    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 
    DataSet ds;
    //DataTable dt;
    int tmpRowCount = 0;
    decimal tmpTotalAmount = 0;
    decimal tmpPrepaidTotal = 0;


    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = "~/UserEbookMaster.master";
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        #region //rendering top left panel 

        if (!Session["MasterPageCss"].ToString().Contains("TmpStyleSheet")) 
        {

            HtmlGenericControl myDivObject;
            myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

            //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
            sb.Append("<tr>");
            sb.Append("<td align='left' valign='top'>");
            sb.Append("<img src='Images/table_top_Leftarc.gif' />");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            myDivObject.InnerHtml = sb.ToString();

            //myDivObject.InnerHtml = "<table border='0' class='dvBannerLeftPanel'><tr><td><img alt='imbnLeftimg' src='Images/faq_head.jpg' /> </td></tr></table>";
        }
        #endregion 


          
        if (!IsPostBack)
        {
            ViewState["TotalAmount"] = "00.00";

            if (Request.QueryString["CpUri"] != null)
            {
                ViewState["CallingPage"] = Request.QueryString["CpUri"].ToString();
            }
            else
            {
                ViewState["CallingPage"] = "eBooksList.aspx"; 
            }
            dvPrepaidPurchase.Visible = false;
            LoadCartItems(); 

            //Check if the Direct Bank-In Allowed

            CheckDirectBankInAllowance(); 

        }

        

    }



    protected void CheckDirectBankInAllowance()
    {

        int vClientId = Convert.ToInt32(Session["ClientID"].ToString());
        CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

        ds = objBALebook.BankIn_UserSettings(vClientId); 

        if(ds.Tables[0].Rows.Count > 0)
        {

            DataRow dRow = ds.Tables[0].Rows[0];

            int vAllowDirectBankIn = Convert.ToInt16(dRow["AllowDirectBankIn"].ToString());



            if (vAllowDirectBankIn == 1)
                dvDirectBankIn.Visible = true; 
        }


        

    }

    protected void LoadCartItems()
    {

        DataTable CartDataTable = null;

        if (HttpContext.Current.Session["basket"] != null)
        {
            CartDataTable = (DataTable)HttpContext.Current.Session["basket"];
           
        }

        if (CartDataTable != null)
        {
            if (CartDataTable.Rows.Count > 0)
            {
                tmpRowCount = CartDataTable.Rows.Count;
                ViewState["ItemsCount"] = tmpRowCount;
                gridItems.DataSource = CartDataTable;
                gridItems.DataBind();

            }
        }

    }



    protected void gridItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridItems.PageIndex = e.NewPageIndex;
       
    }



  

    protected void gridItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gridItems.EditIndex = -1;
        LoadCartItems();
    }

    protected void gridItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Get the reference to the gridview row
        GridViewRow gvRow = (GridViewRow)gridItems.Rows[e.RowIndex];

        //Getting the Item to be Deleted; 
        int isDeleted = 0; 
        Literal ltrhdBookId = (Literal)gvRow.FindControl("hdBookId");

        DataTable tmpDelCart;

        tmpDelCart = (DataTable)HttpContext.Current.Session["basket"];

        for (int i = 0; i < tmpDelCart.Rows.Count; i++)
        {
            if (tmpDelCart.Rows[i][0].ToString() == ltrhdBookId.Text)
            {
                tmpDelCart.Rows.Remove(tmpDelCart.Rows[i]);
                isDeleted = 1; 
            }
        }


        HttpContext.Current.Session["basket"] = tmpDelCart;


        //int delStatus = 1; 
        if (isDeleted == 1)
        {
         

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('eBook deleted successfully')", true);
            LoadCartItems(); 

        }
        else
        {
          
        }      
      

    }


    protected void gridItems_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //gridItems.EditIndex = e.NewEditIndex;
        //PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //GridViewRow gRow = (GridViewRow)gridItems.Rows[e.NewEditIndex];
        //Literal ltrTstID = (Literal)gRow.FindControl("hdTstId");
        gridItems.EditIndex = e.NewEditIndex;
        LoadCartItems();

        //Server.Transfer("TestimonialViewEdit.aspx?TestimonialID=" + ltrTstID.Text);
    }



    protected void gridItems_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridItems.BottomPagerRow, gridItems);
       
    }


    protected void gridItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //CheckBox objChkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //objChkSelect.Attributes.Add("onClick", "SelectRow('" + objChkSelect.ClientID + "')");

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");

            HiddenField hdItemsCount = (HiddenField)e.Row.FindControl("hdItemsCount"); 
            HiddenField hdTotalAmount = (HiddenField)e.Row.FindControl("hdTotalAmount");

            Label objlblPrice = (Label)e.Row.FindControl("lblPrice");

            tmpTotalAmount = tmpTotalAmount + Convert.ToDecimal(objlblPrice.Text);
          
            ViewState["TotalAmount"] = tmpTotalAmount;

            Label objlblBookID = (Label)e.Row.FindControl("lblBookID");

            String rBookId = objlblBookID.Text;

            newDBS ndbs = new newDBS();
            DataSet dst = ndbs.getPrepaidPrice(rBookId.ToString());

            Label lblPrepaidPrice = (Label)e.Row.FindControl("lblPrepaidPrice");
            lblPrepaidPrice.Text = dst.Tables[0].Rows[0]["PrepaidValue"].ToString();

            string tempPrepaid = dst.Tables[0].Rows[0]["PrepaidPrice"].ToString();
            tmpPrepaidTotal = tmpPrepaidTotal + Decimal.Parse(tempPrepaid);

            if(rBookId.Contains("EVB"))
            {
                Image objImgEbook = (Image)e.Row.FindControl("ImgEbook");
                objImgEbook.ImageUrl = "Images/ebImages/ValueBuyDummy.png"; 
            }        
        }

    }



    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridItems.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridItems.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridItems.PageIndex = pageNumberDropDownList.SelectedIndex;
                    LoadCartItems();
                }
            }
        }
    }



    protected void gridItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {



        //GridViewRow gRow = (GridViewRow)gridItems.Rows[e.RowIndex];
        //CheckBox chkisShowAtHP = (CheckBox)gRow.FindControl("chkisShowAtHP");


        //Literal hdNewReleaseUID = (Literal)gRow.FindControl("hdNewReleaseUID");

        //Literal hdBookId = (Literal)gRow.FindControl("hdBookId");
        //Literal hdBookUID = (Literal)gRow.FindControl("hdUID");


        //string tmpBookID = hdBookId.Text;
        //int tmpBookUID = Convert.ToInt32(hdBookUID.Text);


        ////int upStatus = ebDBcode.EBook_Update_NewRelease(tmpUID, chkisShowAtHP.Checked);

        //int upStatus = ebDBcode.Ebook_ShowHide_HpItems(7484, tmpBookID, tmpBookUID, 3, chkisShowAtHP.Checked);


        ////int delStatus = 1; 
        //if (upStatus >= 1)
        //{
        //    tblMessageBar.Visible = true;
        //    lblErrMessage.Text = "Ebook Updated Sucessfully";
        //    lblErrMessage.CssClass = "font_12Msg_Success";
        //    MessageImage.Src = "~/Images/inf_Sucess.gif";

        //    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());

        //}
        //else
        //{
        //    lblErrMessage.Text = "Could not Update the Ebook . Technical Error";
        //    lblErrMessage.CssClass = "font_12Msg_Error";
        //    tblMessageBar.Visible = true;
        //    MessageImage.Src = "~/Images/inf_Error.gif";

        //}


        //gridItems.EditIndex = -1;
        //PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());


    }

    protected void gridItems_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if ((e.Row.RowType == DataControlRowType.Footer) && (tmpRowCount > 0))
        {
            int intNoOfMergeCol = e.Row.Cells.Count - 1; /*except last column */

            GridViewRow footerRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Insert);

          
            //Adding Footer Total Text Column
            TableCell cell = new TableCell();
            cell.Text = "Total: " + ViewState["ItemsCount"].ToString() + " items" ; 
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.ColumnSpan = 2;
            cell.CssClass = "fontCart"; 
            footerRow.Cells.Add(cell);

            cell = new TableCell();
            Label lbl3 = new Label();
            lbl3.ID = "lblPrepaidTotal";
            lbl3.Text = tmpPrepaidTotal.ToString() + " Points";
            lbl3.CssClass = "fontViewCart";
            cell.Controls.Add(lbl3);
            cell.HorizontalAlign = HorizontalAlign.Right;

            footerRow.Cells.Add(cell);

            // Total Amount 
            cell = new TableCell();
            Label lbl2 = new Label();
            lbl2.ID = "lbltotalAmount";
            lbl2.Text = Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(ViewState["TotalAmount"]))).ToString();
            lbl2.CssClass = "fontViewCart";
            cell.Controls.Add(lbl2);
            cell.HorizontalAlign = HorizontalAlign.Right;
            
            footerRow.Cells.Add(cell);
           
            cell = new TableCell();
            footerRow.Cells.Add(cell);


            //// Total Items 
            //cell = new TableCell();
            //Label lbl = new Label();
            //lbl.ID = "lbltotalAmount";
            //lbl.Text = ViewState["ItemsCount"].ToString();
            //cell.Controls.Add(lbl);
            //cell.HorizontalAlign = HorizontalAlign.Right;
            //cell.CssClass = "fontViewCart";
            //footerRow.Cells.Add(cell);


            footerRow.CssClass = "rowfooter";

            //if (GridView1.PageCount > 1)
            gridItems.Controls[0].Controls.Add(footerRow);

            if (Decimal.Parse(tmpPrepaidTotal.ToString()) > 0)
            {
                dvPrepaidPurchase.Visible = true;
            }

        }


    }
    protected void LnkBtnContinueShopping_Click(object sender, EventArgs e)
    {
        String tmpURI =  ViewState["CallingPage"] .ToString();
        Response.Redirect(tmpURI);
    }


    protected void lnkCheckOut2PayPal_Click(object sender, EventArgs e)
    {


        String tmpURI = ViewState["CallingPage"].ToString();

        String vURL = "eBooksvCartConfirm.aspx?CpUri=" + tmpURI; 

        Response.Redirect(vURL); 
    }



    protected void LnkDirectBankIn_Click(object sender, EventArgs e)
    {

        String tmpURI = ViewState["CallingPage"].ToString();

        String vURL = "eBooksBankInPre.aspx?CpUri=" + tmpURI;
      //  String vURL = "eBooksBankInSubmit.aspx?CpUri=" + tmpURI;

        Response.Redirect(vURL); 
    }

    protected void LnkPrepaidPurchase_Click(object sender, EventArgs e)
    {

        String tmpURI = ViewState["CallingPage"].ToString();

        String vURL = "eBooksViewCartPrepaid.aspx?CpUri=" + tmpURI;
        //  String vURL = "eBooksBankInSubmit.aspx?CpUri=" + tmpURI;

        Response.Redirect(vURL);
    }
}




