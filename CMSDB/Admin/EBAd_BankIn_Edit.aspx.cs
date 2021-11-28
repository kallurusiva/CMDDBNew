using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class EBAd_BankIn_Edit : System.Web.UI.Page
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
           
            //...Get the Bank UID of the User. 

            String Bank_UID = Server.UrlDecode(CommonFunctions.Decrypt(Request.QueryString["qUID"].ToString()));

            ViewState["Bank_UID"] = Bank_UID; 

            GetUser_BankInfo(Bank_UID); 
            GetUserInfo(); 
           // RenderCountries(""); 
          //  BtnSave.Enabled = false; 

        }


    }


    protected void GetUser_BankInfo(string BankUid)
    {
        //...Get Estore ID and Email Address of the User
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        String strSearch = string.Empty;
        strSearch = " AND BU.UID = " + BankUid;


        DataSet ds = objBALebook.BankIn_GetUserBanks(vUserID, strSearch);

        if (ds.Tables[0].Rows.Count > 0)
        {

            DataRow dRow = ds.Tables[0].Rows[0];

            txtBankActNo.Text = dRow["BankActNo"].ToString();
            txtFullName.Text = dRow["FullName"].ToString();
            txtRemarks.Text = dRow["Remarks"].ToString();

            int uBankID = Convert.ToInt32(dRow["BankID"].ToString());

            ViewState["BankID"] = uBankID; 

            int uCountryCode = Convert.ToInt32(dRow["CountryCode"].ToString());

            RenderCountries(uCountryCode.ToString());
            //RenderMasterBanks(uCountryCode, uBankID); 
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



    protected void RenderCountries(string SelCountryCode)
    {
        DataSet ds = objBALebook.Bank_Countries("");

        ddlCountry.DataSource = ds;
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataValueField = "CountryCode";
        ddlCountry.DataBind();

        ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));

        ddlCountry.SelectedValue = SelCountryCode;

        int vBankID = Convert.ToInt32(ViewState["BankID"].ToString());

        RenderMasterBanks(Convert.ToInt32(SelCountryCode), vBankID); 

    }


    protected void RenderMasterBanks(int vCountryCode, int vBankID)
    {
        DataSet ds = objBALebook.Bank_GetBankInfoByCountry(vCountryCode);


        ddlMasterBanks.DataSource = ds;
        ddlMasterBanks.DataTextField = "BankName";
        ddlMasterBanks.DataValueField = "BankID";
        ddlMasterBanks.DataBind();

        ddlMasterBanks.Items.Insert(0, new ListItem("Select Bank", "0"));
        ddlMasterBanks.SelectedValue = vBankID.ToString();
        
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

        int Bank_UID = Convert.ToInt32(ViewState["Bank_UID"].ToString()); 

           
            int inStatus = objBALebook.Bank_User_Update(Bank_UID,mBankID, mBankActNo, mFullName, mRemarks, vDisplayAtWebsite, vUserID, vMerchantID); 

            if (inStatus == 1)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Sucess.gif";
                //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
                lblErrMessage.Text = "Bank-In Info successfully Updated";
                lblErrMessage.CssClass = "ValAlert_Success";

                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Bank-In Info Successfully Updated')", true);

                //Response.Redirect("EBAd_BankIn_UserList.aspx");
                CommonFunctions.AlertMessageAndRedirect("Bank-In Info sucessfully Updated", "EBAd_BankIn_UserList.aspx");
               
                return;
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
        int vBankID = Convert.ToInt32(ViewState["BankID"].ToString()); 

        RenderMasterBanks(vCountryCode, vBankID); 

    }
}