using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Admin_Ad_CurrencyConvertEdit : System.Web.UI.Page
{

    DataSet ds;
    //DataView dv;


    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;

    newDBS objPS = new newDBS();

    protected void Page_Load(object sender, EventArgs e)
    {

        #region session check

        if (Session["UserID"] == null)
        {
            if (Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion

        if ((Request.QueryString["CCODE"] != null) && (Request.QueryString["CCODE"].ToString() != ""))
        {
            ViewState["CCODE"] = Request.QueryString["CCODE"].ToString();
        }


        if (!IsPostBack)
        {          

            GetUserInfo();    
        }
    }


    protected void GetUserInfo()
    {
        lblCurrencyName.Text = ViewState["CCODE"].ToString();

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        ds = objPS.CurrencyConvert_List(Session["UserID"].ToString(), ViewState["CCODE"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dRow = ds.Tables[0].Rows[0];
            txtPoints.Text = dRow["convertpoints"].ToString();
        }

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (!Page.IsValid)
            return;

        //Get the form values     

        String mPoints = txtPoints.Text;
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        int vMerchantID = 0;

        if (Session["MERID"] != null)
            vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
        else
            Response.Redirect("~/SessionExpireEbook.aspx");


        int inStatus = objPS.CurrencyConvert_Update(Session["UserID"].ToString(), ViewState["CCODE"].ToString(), Convert.ToDouble(mPoints));

        if (inStatus == 1)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            //lblErrMessage.Text = "Category: '<b>" + OldCategoryName + "</b>' sucessfully updated to '" + mCategoryName + "'";
            lblErrMessage.Text = "Currency Conbversion successfully modified.";
            lblErrMessage.CssClass = "ValAlert_Success";
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('Bank-In Info Successfully')", true);
            CommonFunctions.AlertMessageAndRedirect("Currency Conbversion successfully modified", "Ad_CurrencyConvertList.aspx");
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
}