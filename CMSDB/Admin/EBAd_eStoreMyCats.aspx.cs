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

public partial class Admin_EBAd_eStoreMyCats : System.Web.UI.Page
{

    DataSet ds;
    DataView dv;
    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

    int vUserID = 0;
    int vMerchantID = 0;
    String vMobileLoginID = string.Empty;
    String vEStoreID = string.Empty;

    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;


    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check

        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion


        Page.MaintainScrollPositionOnPostBack = true;

        if (!IsPostBack)
        {

            vUserID = Convert.ToInt32(Session["UserID"].ToString());
            vMerchantID = 0;
            vMobileLoginID = "";

            if (Session["MERID"] != null)
                vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
            else
                vMerchantID = 0;


            if (Session["MobileLoginID"] != null)
                vMobileLoginID = Session["MobileLoginID"].ToString();
            else
                vMobileLoginID = "";



            CheckEStoreID(vUserID);
            LoadSettings();
            Load_MainCategories();


            ViewState["MainCatId"] = "1";
            Load_SubCategories(Convert.ToInt32(ViewState["MainCatId"].ToString()));
            RenderMainCategories(ViewState["MainCatId"].ToString());



        }

        tblMessageBar.Visible = false;

    }

    protected void CheckEStoreID(int vUserID)
    {
        ds = objEbook.Ebook_GeteStoreID(vUserID);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            vEStoreID = dr["eStoreID"].ToString();
        }
    }



    protected void RenderMainCategories(string SelCatID)
    {

        vUserID = Convert.ToInt32(Session["UserID"].ToString());
        DataSet ds = objEbook.EBook_Get_MainCategories(vUserID, "");

    }



    protected void LoadSettings()
    {

        // ds = objEbook.Ebook_DashBoard(vUserID, vMerchantID, vMobileLoginID);

        ds = objEbook.Ebook_eStore_ManagementView(vUserID);

        //DataTable dtUserCat = ds.Tables[0];
        //DataTable dtUserAdm = ds.Tables[1];

        DataTable dtSettings = ds.Tables[0];
        DataTable dtNotify = ds.Tables[1];
        DataTable dtCurrencies = ds.Tables[2];
        DataTable dtUserCurrency = ds.Tables[3];

        //======== Notifcation Settings. 

        if (dtNotify.Rows.Count > 0)
        {
            DataRow nr = dtNotify.Rows[0];

            //rdoOwnBookNotify.SelectedValue = nr["NotifyUserEbooks"].ToString();
            //rdoAdminBookNotify.SelectedValue = nr["NotifyAdminEbooks"].ToString();

            //txtNotifyMobile1.Text = nr["Mobile1"].ToString();
            //txtNotifyMobile2.Text = nr["Mobile2"].ToString();
            //txtNotifyMobile3.Text = nr["Mobile3"].ToString();
            //txtNotifyMobile4.Text = string.Format("{0:s}", nr["Mobile4"].ToString()); //nr["Mobile4"].ToString();
            //txtNotifyMobile5.Text = nr["Mobile5"].ToString();

            //if (txtNotifyMobile1.Text == "0") txtNotifyMobile1.Text = "";
            //if (txtNotifyMobile2.Text == "0") txtNotifyMobile2.Text = "";
            //if (txtNotifyMobile3.Text == "0") txtNotifyMobile3.Text = "";
            //if (txtNotifyMobile4.Text == "0") txtNotifyMobile4.Text = "";
            //if (txtNotifyMobile5.Text == "0") txtNotifyMobile5.Text = "";


        }





        //== User Default Currency 
        if (dtUserCurrency.Rows.Count > 0)
        {
            DataRow uRow = dtUserCurrency.Rows[0];

            String SelectedCurrency = uRow["Currency"].ToString();

        }




    }


    protected void Load_MainCategories()
    {

        // ds = objEbook.Ebook_DashBoard(vUserID, vMerchantID, vMobileLoginID);

        vUserID = Convert.ToInt32(Session["UserID"].ToString());

        DataSet dsMainCats = objEbook.EBook_Get_MainCategories(vUserID, "00");
        DataTable dtMainCats = dsMainCats.Tables[0];



        //========= Main Categories 
        #region Main Categories
        if (dtMainCats.Rows.Count > 0)
        {

            dv = dsMainCats.Tables[0].DefaultView;
            GridMainCats.DataSource = dv;
            GridMainCats.DataBind();

            CheckMasterBox(GridMainCats, "chkSelectAllUser", "UserchkActive");

        }
        else
        {

            //GridMainCats.FooterRow.Visible = false;
            GridMainCats.EmptyDataText = "No Categories Created YET.";
        }

        #endregion


    }


    protected void Load_SubCategories(int vCatmainID)
    {
        vUserID = Convert.ToInt32(Session["UserID"].ToString());
        DataSet dsSubCats = objEbook.EBook_Get_SUBCategories(vUserID, vCatmainID, "");

        DataTable dtSubCats = dsSubCats.Tables[0];

        ViewState["MainCatId"] = vCatmainID;



        //========= Sub  Categories 
        #region Sub Categories
        if (dtSubCats.Rows.Count > 0)
        {

            dv = dsSubCats.Tables[0].DefaultView;



        }
        else
        {

            //DataSet dsEmpty = new DataSet();
            //DataTable dtEmpty = new DataTable();

            dsSubCats.Tables[0].Rows.Add(dsSubCats.Tables[0].NewRow());




        }

        #endregion



    }

    protected void GridSubCats_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

            CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAllAdmin");
            //objChkSelectAll.Attributes.Add("onClick", "toggleCheckBoxes('" + GridSubCats.ClientID + "','" + objChkSelectAll.ClientID + "')");


            //<input type="checkbox" onclick="toggleCheckBoxes('<%= <font size="3"><b>gvProducts.ClientID </b></font>%>',this.checked)" id="chkAll" />
        }

        else if (e.Row.RowType == DataControlRowType.DataRow)
        {

            CheckBox ObjchkActive = (CheckBox)e.Row.FindControl("chkActive");
            Literal objLtrActive = (Literal)e.Row.FindControl("LtrActive");

            if (objLtrActive.Text == "True")
            {
                ObjchkActive.Checked = true;

            }

        }

        else if (e.Row.RowType == DataControlRowType.Footer)
        {


        }

    }

    protected void GridMainCats_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.Header)
        {

            CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAllUser");
            //  objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");
            objChkSelectAll.Attributes.Add("onClick", "toggleCheckBoxes('" + GridMainCats.ClientID + "','" + objChkSelectAll.ClientID + "')");

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }



    }



    protected void btnShowHide_MainCats_Click(object sender, EventArgs e)
    {

        String vStrCheckedCatIds = string.Empty;

        foreach (GridViewRow Grow in GridMainCats.Rows)
        {

            CheckBox chk = (CheckBox)Grow.FindControl("UserchkActive");
            Literal hdCatID = (Literal)Grow.FindControl("hdCatMainID");

            if (!chk.Checked)
            {
                vStrCheckedCatIds = vStrCheckedCatIds + hdCatID.Text + ",";
            }

        }


        //Remove the last comma. 

        if (vStrCheckedCatIds != "")
            vStrCheckedCatIds = vStrCheckedCatIds.Substring(0, vStrCheckedCatIds.Length - 1);
        //Response.Write(vStrCheckedCatIds);

        vUserID = Convert.ToInt32(Session["UserID"].ToString());

        int vCatType = Convert.ToInt16(GlobalVar.EbookCategoryType.User);


        //Response.Write(vCatType.ToString() + "<BR>" + vStrCheckedCatIds.ToString());

        int inStatus = objEbook.Ebook_HomePage_Hide_MainCatIds(vUserID, vStrCheckedCatIds, vCatType);
        Load_SubCategories(Convert.ToInt32(ViewState["MainCatId"].ToString()));


        if (inStatus > 0)
        {
            CommonFunctions.AlertMessage("Your Categories to Show/Hide have been successfully saved.");
            CheckMasterBox(GridMainCats, "chkSelectAllUser", "UserchkActive");
            return;
        }
        else
        {
            CommonFunctions.AlertMessage("Categories to Show/Hide Coult NOT be saved.");
            return;
        }



        //Response.Write(vStrCheckedCatIds); 

    }


    protected void btnShowHide_SubCats_Click(object sender, EventArgs e)
    {

        //int SelMainCatId = Convert.ToInt16(ddlMainCategories.SelectedValue);

        String vStrCheckedCatIds = string.Empty;

        //foreach (GridViewRow Grow in GridSubCats.Rows)
        //{

        //    CheckBox chk = (CheckBox)Grow.FindControl("chkActive");
        //    Literal hdCatID = (Literal)Grow.FindControl("hdCatID");

        //    if (!chk.Checked)
        //    {
        //        vStrCheckedCatIds = vStrCheckedCatIds + hdCatID.Text + ",";
        //    }

        //}


        //Remove the last comma. 

        if (vStrCheckedCatIds != "")
            vStrCheckedCatIds = vStrCheckedCatIds.Substring(0, vStrCheckedCatIds.Length - 1);
        //Response.Write(vStrCheckedCatIds);



        vUserID = Convert.ToInt32(Session["UserID"].ToString());

        int vCatType = Convert.ToInt16(GlobalVar.EbookCategoryType.Admin);
        //CommonFunctions.AlertMessage(vStrCheckedCatIds.ToString());
        //CommonFunctions.AlertMessage(SelMainCatId.ToString());
        //CommonFunctions.AlertMessage(vCatType.ToString());
        //int inStatus = objEbook.Ebook_HomePage_HideCatIds(vUserID, vStrCheckedCatIds, SelMainCatId, vCatType);

        //if (inStatus > 0)
        //{
        //    CommonFunctions.AlertMessage("Categories to Show/Hide have been successfully saved.");
        //    //CheckMasterBox(GridSubCats, "chkSelectAllAdmin", "chkActive");
        //    return;
        //}
        //else
        //{
        //    CommonFunctions.AlertMessage("Categories to Show/Hide Coult NOT be saved.");
        //    return;
        //}



        //Response.Write(vStrCheckedCatIds); 

    }






    protected void CheckMasterBox(GridView gv, String vMasterCheckBox, String vChildCheckBox)
    {

        int ChkBoxLoop = 0;

        foreach (GridViewRow row in gv.Rows)
        {
            if (!((CheckBox)row.FindControl(vChildCheckBox)).Checked)
            {
                //comes here if one of the ceckboxes is not checked         
                ChkBoxLoop = 1;
            }
        }

        GridViewRow ghRow = gv.HeaderRow;
        CheckBox objChkBox = (CheckBox)ghRow.FindControl(vMasterCheckBox);

        if (ChkBoxLoop == 0)
        {
            if (objChkBox != null)
                objChkBox.Checked = true;
        }
        else
        {
            if (objChkBox != null)
                objChkBox.Checked = false;
        }

    }



    protected void BtnNotifications_Click(object sender, EventArgs e)
    {
        //int tmpNotify4UserBooks = Convert.ToInt16(rdoOwnBookNotify.SelectedValue);
        //int tmpNotify4AdminBooks = Convert.ToInt16(rdoAdminBookNotify.SelectedValue);

        ////Mobiles 

        //String vMobile1 = txtNotifyMobile1.Text.Trim();
        //String vMobile2 = txtNotifyMobile2.Text.Trim();
        //String vMobile3 = txtNotifyMobile3.Text.Trim();
        //String vMobile4 = txtNotifyMobile4.Text.Trim();
        //String vMobile5 = txtNotifyMobile5.Text.Trim();


        //vUserID = Convert.ToInt32(Session["UserID"].ToString());
        //vMerchantID = Convert.ToInt32(Session["MERID"].ToString());

        //int vStatus = objEbook.Ebook_eStore_SaveNotifications(vUserID, vMerchantID, tmpNotify4UserBooks, tmpNotify4AdminBooks, vMobile1, vMobile2, vMobile3, vMobile4, vMobile5);

        //if (vStatus > 0)
        //{
        //    CommonFunctions.AlertMessage("eStore Notificatons Successfully saved.");

        //    return;
        //}
        //else
        //{
        //    CommonFunctions.AlertMessage("eStore Notifications Could NOT be saved.");
        //    return;
        //}
    }


    protected void BtnSaveAdminShowHide_Click(object sender, EventArgs e)
    {

        vUserID = Convert.ToInt32(Session["UserID"].ToString());

        int tmpADM_Ebooks = 1; // Convert.ToInt16(rdoADM_Ebooks.SelectedValue); 

        int tmpADM_FeatureBuy = 1; // Convert.ToInt16(rdoADM_FeatureBuy.SelectedValue);
        int tmpADM_BestSeller = 1; // Convert.ToInt16(rdoADM_BestSeller.SelectedValue);
        int tmpADM_NewReleases = 1; // Convert.ToInt16(rdoADM_NewReleases.SelectedValue);
        int tmpADM_ValueBuy = 1; // Convert.ToInt16(rdoADM_ValueBuy.SelectedValue);
        int tmpADM_Free = 1; // Convert.ToInt16(rdoADM_Free.SelectedValue);



        int vStatus = objEbook.Ebook_eStore_SaveAdminBookDisplaySettings(vUserID, tmpADM_Ebooks, tmpADM_FeatureBuy, tmpADM_BestSeller, tmpADM_NewReleases, tmpADM_ValueBuy, tmpADM_Free);


        if (vStatus > 0)
        {
            CommonFunctions.AlertMessage("eStore Settings for Show/Hide Admins successfully saved.");

            return;
        }
        else
        {
            CommonFunctions.AlertMessage("eStore Settings for Show/Hide Admins Could NOT be saved.");
            return;
        }


    }

    protected void ddlMainCategories_SelectedIndexChanged(object sender, EventArgs e)
    {

        //String selMainCatID = ddlMainCategories.SelectedValue;

        //Load_SubCategories(Convert.ToInt32(selMainCatID));


    }
}
