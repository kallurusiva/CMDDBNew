using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class EBAd_BankIn_Add : System.Web.UI.Page
{

    //DataSet ds;
    //DataView dv;


    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 

    protected void Page_Load(object sender, EventArgs e)
    {


        #region session check

        if (Session["UserID"] == null) 
        {
            if(Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 


        txtBankActNo.Attributes.Add("onkeypress", "javascript:return CheckKeyCode_AlphaNum(event)");
        


        if (!IsPostBack)
        {

            //if (Session["LoggedInFrom"] != null)
            //    lblPgFrom.Text = Session["LoggedInFrom"].ToString(); 
            

            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "CategoryName";
            ViewState["SearchStr"] = "";
           
            GetUserInfo(); 
            RenderCountries(""); 
          //  BtnSave.Enabled = false; 

        }


    }


    protected void GetUserInfo()
    {
        //...Get Estore ID and Email Address of the User
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        DataSet ds = objBALebook.Bank_GetUserInfo(vUserID); 

        if(ds.Tables[0].Rows.Count > 0)
        {

            DataRow dRow = ds.Tables[0].Rows[0]; 

            lbleStoreID.Text = dRow["eStoreID"].ToString();
            lbleMailID.Text = dRow["eMailID"].ToString();  


        }


    }



    protected void RenderCountries(string strSearch)
    {
        DataSet ds = objBALebook.Bank_Countries(strSearch);

        ddlCountry.DataSource = ds;
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataValueField = "CountryCode";
        ddlCountry.DataBind();

        ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));

    }


    protected void RenderMasterBanks(int vCountryCode)
    {
        DataSet ds = objBALebook.Bank_GetBankInfoByCountry(vCountryCode);


        ddlMasterBanks.DataSource = ds;
        ddlMasterBanks.DataTextField = "BankName";
        ddlMasterBanks.DataValueField = "BankID";
        ddlMasterBanks.DataBind();

        ddlMasterBanks.Items.Insert(0, new ListItem("Select Bank", "0"));

    }

    
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (!Page.IsValid)
            return; 

        //Get the form values

        int mCountryCode = Convert.ToInt32(ddlCountry.SelectedValue);
        int mBankID = Convert.ToInt32(ddlMasterBanks.SelectedValue); 

        String mBankActNo = txtBankActNo.Text; 
        String mFullName = txtFullName.Text;
        String mRemarks = txtRemarks.Text; 
        bool vDisplayAtWebsite =   chkActive.Checked;

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        int vMerchantID=0; 

        if (Session["MERID"] != null)
            vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
        else
            Response.Redirect("~/SessionExpireEbook.aspx");



            //int inStatus = objBALebook.Category_WP_Add(mCatMainID,mCategoryName, mDisplayAtWebSite, vUserID, vMerchantID);
            int inStatus = objBALebook.Bank_User_Add(mBankID, mBankActNo, mFullName, mRemarks, vDisplayAtWebsite, vUserID, vMerchantID); 

            if (inStatus == 1)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Sucess.gif";
                //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
                lblErrMessage.Text = "Bank-In Info successfully added";
                lblErrMessage.CssClass = "ValAlert_Success";

                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Bank-In Info Successfully')", true);

                CommonFunctions.AlertMessageAndRedirect("Bank-In Info sucessfully Added", "EBAd_BankIn_UserList.aspx");
               
                return;
            }
            else if(inStatus == 2)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";
                lblErrMessage.Text = "You are allowed to ADD Max No. of 3 Bank-Info Details only. Please delete an existing Bank-In Info to Add New.!! ";
                lblErrMessage.CssClass = "ValAlert_Error";

                CommonFunctions.AlertMessage("You are allowed to ADD Max No. of 3 Bank-Info Details only.\\n\\nPlease delete an existing Bank-In Info to Add New.!!");
               // String vAlertMsg = "You have exceed the Max No. of Categories you can create.\n\nPlease delete an existing category or Upgrade.!!";
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);


            }
            else
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";
                lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the record. Please contant Administrator";
                lblErrMessage.CssClass = "ValAlert_Error";
            }
        

      

    }



    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

        int vCountryCode = Convert.ToInt32(ddlCountry.SelectedValue);

        RenderMasterBanks(vCountryCode); 

    }
}