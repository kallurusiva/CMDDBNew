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

    DataSet ds;
    //DataView dv;


    String m_SortExpr = string.Empty;
    string bEditStatus = string.Empty;
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
            ViewState["vIdentifier"] = ""; 

            //if (Session["LoggedInFrom"] != null)
            //    lblPgFrom.Text = Session["LoggedInFrom"].ToString(); 
            

            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "CategoryName";
            ViewState["SearchStr"] = "";

            Retrieve_BankInfo(); 
           // RenderCountries(""); 
          //  BtnSave.Enabled = false; 

        }


    }


    protected void Retrieve_BankInfo()
    {
        String vIdentifier = string.Empty; 

        ds = objBALebook.Retrieve_EMSContent_ByUserID(Convert.ToInt32(Session["UserID"].ToString()));

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[0].Rows[0];
            vIdentifier = utRow["Identifier"].ToString();
            ViewState["vIdentifier"] = vIdentifier; 
           // Retrieve_BankInfo(utRow["Identifier"].ToString());
        }


        ds = objBALebook.Retrieve_UserBankInfo(vIdentifier);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = ds.Tables[0].Rows[0];

            lblMemberName.Text = utRow["MemberName"].ToString();
            lblMobileID.Text = utRow["Mobile"].ToString(); 

            txtBankActNo.Text = utRow["AcNo"].ToString();
            //txtBankName.Text = utRow["BankCode"].ToString();
            txtBankAddress.Text = utRow["BankAddress"].ToString();
            txtIC.Text = utRow["IC"].ToString();

            string tmpCountryCode = utRow["BankCountry"].ToString();
            string tmpBankSNO = utRow["bankSNO"].ToString();
            bEditStatus = utRow["bankEditStatus"].ToString();

            if (bEditStatus == "1")
            {
                BtnSave.Visible = false;
                txtIC.Enabled = false;
                txtBankActNo.Enabled = false;
                txtBankAddress.Enabled = false;
                ddlCountry.Enabled = false;
            }

            RenderCountries(tmpCountryCode, tmpBankSNO); 
        }
    }



    protected void RenderCountries11(string strSearch)
    {
        DataSet ds = objBALebook.Bank_Countries(strSearch);

        ddlCountry.DataSource = ds;
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataValueField = "CountryCode";
        ddlCountry.DataBind();

        ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));

    }


    protected void RenderCountries(string SelCountryCode, string SelBankSNO)
    {
        DataSet ds = objBALebook.Bank_Countries(SelCountryCode);

        ddlCountry.DataSource = ds;
        ddlCountry.DataTextField = "CountryName";
        ddlCountry.DataValueField = "CountryCode";
        ddlCountry.DataBind();

        ddlCountry.Items.Insert(0, new ListItem("Select Bank", "0"));

        if ((SelCountryCode != "") || (SelCountryCode != "0"))
            ddlCountry.SelectedValue = SelBankSNO;

       //int vBankID = Convert.ToInt32(ViewState["BankID"].ToString());


    }

   

    
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (!Page.IsValid)
            return; 

        //Get the form values

        int mCountryCode = Convert.ToInt32(ddlCountry.SelectedValue);
      

        String mBankActNo = txtBankActNo.Text; 
        String mIC = txtIC.Text;  
        //String mBankName = txtBankName.Text;
        String mBankAddress = txtBankAddress.Text;
        int mBankcountry = Convert.ToInt32(ddlCountry.SelectedValue); 



        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        int vMerchantID=0; 

        if (Session["MERID"] != null)
            vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
        else
            Response.Redirect("~/SessionExpireEbook.aspx");

            int vIdentifier = Convert.ToInt32( ViewState["vIdentifier"].ToString()); 

            //int inStatus = objBALebook.Category_WP_Add(mCatMainID,mCategoryName, mDisplayAtWebSite, vUserID, vMerchantID);
            int inStatus = objBALebook.SMSPay_Bank_Add(vIdentifier, mBankActNo, "", mBankAddress, mIC, mBankcountry); 

            if (inStatus == 1)
            {
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Sucess.gif";
                //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
                lblErrMessage.Text = "Bank-In Info successfully added";
                lblErrMessage.CssClass = "ValAlert_Success";

                //ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Bank-In Info Successfully')", true);

                CommonFunctions.AlertMessageAndRedirect("Bank-In Info sucessfully Updated", "SMSPay_BankIn_Add.aspx");
               
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



    
}