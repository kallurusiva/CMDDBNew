﻿using System;
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
using System.Configuration;


public partial class N_Cart : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    //DataTable dt;
    int tmpRowCount = 0;
    decimal tmpTotalAmount = 0;
    decimal tmpPrepaidTotal = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Session["ClientID"] = GetUserIdfromURL().ToString();
        }
        //if ((Session["cLogin"] == null) || (Session["cLogin"] == ""))
        //{
        //    CommonFunctions.AlertMessageAndRedirect("Please Login to checkout", "N_User_Login.aspx");
        //}
        //else
        //{
            if (!IsPostBack)
            {
                ViewState["TotalAmount"] = "00.00";
                if (Request.QueryString["CpUri"] != null)
                {
                    ViewState["CallingPage"] = Request.QueryString["CpUri"].ToString();
                }
                else
                {
                    ViewState["CallingPage"] = "N_Main.aspx";
                }
                if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
                {
                    Session["navcheckout"] = "0";
                }
                else
                {
                    Session["navcheckout"] = "1";
                }

                DataTable CartDataTable1 = null;
                if (HttpContext.Current.Session["basket"] != null)
                {
                    CartDataTable1 = (DataTable)HttpContext.Current.Session["basket"];
                }
                if (CartDataTable1 != null)
                {
                    if (CartDataTable1.Rows.Count < 1)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('Cart is Empty')", true);
                        //Response.Redirect(ViewState["CallingPage"].ToString());
                        CommonFunctions.AlertMessageAndRedirect("Cart is empty.", "N_User_Account.aspx");
                    }
                }

                //LnkPrepaidPurchase.Visible = false;
                LnkDirectBankIn.Visible = false;
                CheckDirectBankInAllowance();
                LoadCartItems();
            }
        //}
        
    }

    protected void CheckDirectBankInAllowance()
    {
        int vClientId = Convert.ToInt32(Session["ClientID"].ToString());
        CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
        ds = objBALebook.BankIn_UserSettings(vClientId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dRow = ds.Tables[0].Rows[0];
            int vAllowDirectBankIn = Convert.ToInt16(dRow["AllowDirectBankIn"].ToString());
            string vCurrency = dRow["currency"].ToString();

            if (vAllowDirectBankIn == 1)
                LnkDirectBankIn.Visible = true;

            if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
            {
            }
            else
            {
                LnkOnlineBanking.Visible = true;
                lnkCheckOut2PayPal.Text = "CreditCard";

                //if (vCurrency == "MYR")
                //{
                //    if (Session["ipCtry"] == null)
                //    {
                //        Session["ipCtry"] = "";
                //    }
                //    if (Session["ipCtry"].ToString() == "")
                //    {
                //        Session["ipCtry"] = MyGeoLocation.GetCountryCodeFromIP(); ;
                //    }
                //    string IPValDisp = Session["ipCtry"].ToString();

                //    if (Session["ipCtry"].ToString() == "MY")
                //    {
                //        LnkOnlineBanking.Visible = true;
                //        lnkCheckOut2PayPal.Text = "CreditCard";
                //    }                    
                //}
            }
        }
    }

    protected void LnkPrepaidPurchase_Click(object sender, EventArgs e)
    {
        String tmpURI = ViewState["CallingPage"].ToString();
        String vURL = "N_CartPrepaidOld.aspx?CpUri=" + tmpURI;
        //  String vURL = "eBooksBankInSubmit.aspx?CpUri=" + tmpURI;
        Response.Redirect(vURL);
    }

    protected void lnkCheckOut2PayPal_Click(object sender, EventArgs e)
    {
        //String tmpURI = ViewState["CallingPage"].ToString();
        //String vURL = "N_PaypalConfirm.aspx?CpUri=" + tmpURI;
        //Response.Redirect(vURL);
        if ((Session["cLogin"] == null) || (Session["cLogin"].ToString() == ""))
        {
            Session["navcheckout"] = "0";
        }
        else
        {
            Session["navcheckout"] = "1";
        }

        if ((Session["navcheckout"].ToString() == "0"))
        {
            CommonFunctions.AlertMessageAndRedirect("Please Signin for Returning Customer  OR  Create a New Buyer Account", "N_User_Login.aspx");
        }
        else
        {
            Response.Redirect("N_PaypalConfirm.aspx");
        } 
    }

    protected void LnkDirectBankIn_Click(object sender, EventArgs e)
    {
        String tmpURI = ViewState["CallingPage"].ToString();
        String vURL = "N_DirectBankin.aspx?CpUri=" + tmpURI;
        //  String vURL = "eBooksBankInSubmit.aspx?CpUri=" + tmpURI;
        Response.Redirect(vURL);
        //CommonFunctions.AlertMessage("Online Banking Facility is currently under maintenance.  Please try again later.  TQ.");
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
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('Cart is Empty')", true);
                //Response.Redirect(ViewState["CallingPage"].ToString());
                CommonFunctions.AlertMessageAndRedirect("Cart is empty.", "N_User_Account.aspx");
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
        if (tmpDelCart != null)
        {
            if (tmpDelCart.Rows.Count > 0)
            {
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
        newDBS ndbs1 = new newDBS();
        DataSet dst1 = ndbs1.getUserCurrency(Convert.ToInt32(Session["ClientID"]).ToString());
        string userCurrency = string.Empty;
        userCurrency = "$";
        if (dst1.Tables[0].Rows.Count > 0)
        {
            userCurrency = dst1.Tables[0].Rows[0]["Currency"].ToString();
        }

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

            //Label lblPrepaidPrice = (Label)e.Row.FindControl("lblPrepaidPrice");
            //lblPrepaidPrice.Text = dst.Tables[0].Rows[0]["PrepaidValue"].ToString();

            string tempPrepaid = dst.Tables[0].Rows[0]["PrepaidPrice"].ToString();
            tmpPrepaidTotal = tmpPrepaidTotal + Decimal.Parse(tempPrepaid);

            Label lblCurrencyDisp = (Label)e.Row.FindControl("lblCurrencyDisp");
            lblCurrencyDisp.Text = userCurrency.ToString();

            if (rBookId.Contains("EVB"))
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
    }

    protected void gridItems_RowCreated(object sender, GridViewRowEventArgs e)
    {
        newDBS ndbs1 = new newDBS();
        DataSet dst1 = ndbs1.getUserCurrency(Convert.ToInt32(Session["ClientID"]).ToString());
        string userCurrency = string.Empty;
        userCurrency = "$";
        if (dst1.Tables[0].Rows.Count > 0)
        {
            userCurrency = dst1.Tables[0].Rows[0]["Currency"].ToString();
        }

        if ((e.Row.RowType == DataControlRowType.Footer) && (tmpRowCount > 0))
        {
            int intNoOfMergeCol = e.Row.Cells.Count - 1; /*except last column */
            GridViewRow footerRow = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Insert);
            //Adding Footer Total Text Column
            TableCell cell = new TableCell();
            cell.Text = "Total: " + ViewState["ItemsCount"].ToString() + " items";
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.ColumnSpan = 2;
            cell.CssClass = "text-center";
            footerRow.Cells.Add(cell);

            //cell = new TableCell();
            //Label lbl3 = new Label();
            //lbl3.ID = "lblPrepaidTotal";
            //lbl3.Text = tmpPrepaidTotal.ToString() + " Points";
            //lbl3.CssClass = "text-center";
            //cell.Controls.Add(lbl3);
            //cell.HorizontalAlign = HorizontalAlign.Right;

            //footerRow.Cells.Add(cell);

            // Total Amount 
            cell = new TableCell();
            Label lbl2 = new Label();
            lbl2.ID = "lbltotalAmount";
            lbl2.Text = userCurrency.ToString() + " " + Convert.ToDecimal(String.Format("{0:0.00}", Convert.ToDecimal(ViewState["TotalAmount"]))).ToString();
            lbl2.CssClass = "text-center";
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

            //if (Decimal.Parse(tmpPrepaidTotal.ToString()) > 0)
            //{
            //    LnkPrepaidPurchase.Visible = true;
            //}
        }
    }

    public int GetUserIdfromURL()
    {
        //function return the UserID based on the domain entered in the URL 
        int newUserID = 0;
        //string OurWebSiteName = "1argentinasms";
        string OurWebSiteName = ConfigurationManager.AppSettings["WebSiteName"].ToString();
        string tmpMainURL = Request.Url.OriginalString;
        string OrgURL = Request.Url.OriginalString;
        //tmpMainURL = "www.testhari88.com";
        //tmpMainURL = "eb60123238595.1smsbusiness.com";
        tmpMainURL = tmpMainURL.Replace("http://", "");  // removing the http://
        CMSv3.BAL.User objBAL_User = new CMSv3.BAL.User();
        if (tmpMainURL.Contains(OurWebSiteName))
        {
            //subdomain
            string tmpSubDomainURL = tmpMainURL;
            string[] MainURLArr = tmpMainURL.Split('.');
            string userSubDomainName = string.Empty;
            // see if user has typed in www
            if (MainURLArr[0].ToString() == "www")
            {
                userSubDomainName = MainURLArr[1].ToString();
            }
            else
            {
                userSubDomainName = MainURLArr[0].ToString();
            }
            if (userSubDomainName == OurWebSiteName)
            {
                //..user comes to direct website setting the userid to demo as default
                newUserID = 105;
            }
            else
            {
                //..user comes to his sub domain
                newUserID = objBAL_User.GetUserID_BySubDomainName(userSubDomainName);
                CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
                CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
                //..function get all the details of 1malaysia user into MasUser entity 
                MasFunc.Get_1MalaysiaUser_Details(userSubDomainName, ref objMasUser);

                //if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
                Session["MasUSER"] = objMasUser;
                //.................................................................
                if (objMasUser.MID != "NONE")
                {
                    //Response.Redirect("Mas1UserWebRegistration.aspx");
                }
            }
        }
        else
        {
            //owndomain  or subDomain ??
            //string ownDomain = tmpMainURL;
            string[] OwnURLArr = tmpMainURL.Split('.');
            string userOwnDomainName = string.Empty;
            int DomainType = -1;
            // see if user has typed in www
            if (OwnURLArr[0].ToString() == "www")
            {
                userOwnDomainName = OwnURLArr[1].ToString();
                if (OwnURLArr.Count() > 4)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain
            }
            else
            {
                userOwnDomainName = OwnURLArr[0].ToString();
                if (OwnURLArr.Count() > 3)
                    DomainType = 1; //subdomain
                else
                    DomainType = 2; //Owndomain or Anchordomain

            }
            //..user comes to his sub domain
            newUserID = objBAL_User.GetUserID_BySubDomainName2(userOwnDomainName, DomainType);
            CMSv3.Entities.MasUser objMasUser = new CMSv3.Entities.MasUser();
            CMSv3.BAL.MalaysiaSMS objBAL_MalaysiaSMS = new CMSv3.BAL.MalaysiaSMS();
            //..function get all the details of 1malaysia user into MasUser entity 
            MasFunc.Get_1MalaysiaUser_Details(userOwnDomainName, ref objMasUser);
            // if ((objMasUser.AccountType != "WEB10") && (objMasUser.AccountType != "WEB30") && (objMasUser.AccountType != "NULL"))
            Session["MasUSER"] = objMasUser;
            //    //.................................................................

            if (objMasUser.MID != "NONE")
            {
                // Response.Redirect("Mas1UserWebRegistration.aspx");
                //String WebRegURL = "Mas1UserWebRegistration.aspx";
                //StringBuilder sburl = new StringBuilder();
                //sburl.Append("<script>");
                //sburl.Append("window.open('page.html','_blank')");
                //sburl.Append("</script>");
                //Response.Write(sburl.ToString());
                //Response.End();
                //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", WebRegURL));
            }
        }

        //string tmpDname = "pencil";
        //newUserID = objBAL_User.GetUserID_BySubDomainName(tmpDname);
        if (newUserID == 0)
        {
            Response.Redirect("PartnerWebRegistrationNew.aspx");
            //Response.Redirect("InValidDomain.aspx");
        }
        return newUserID;
    }

    protected void LnkOnlineBanking_Click(object sender, EventArgs e)
    {
        string gatewayVal = "1";
        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.BillPlz_getGateway();
        if (dst.Tables[0].Rows.Count > 0)
        {
            gatewayVal = dst.Tables[0].Rows[0]["Gateway"].ToString();
        }
        if (gatewayVal.ToString() == "1")
        {
            Response.Redirect("BillPlzConfirm.aspx");
        }
        else
        {
            Response.Redirect("BizApPayConfirm.aspx");
        }    
        //CommonFunctions.AlertMessage("Online Banking Facility is currently under maintenance.  Please try again later.  TQ.");
    }

}