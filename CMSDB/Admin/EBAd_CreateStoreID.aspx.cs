using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;

public partial class EBAd_CreateStoreID : System.Web.UI.Page
{

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

        if (!IsPostBack)
        {
            RenderStoreID(); 
            MaintainScrollPositionOnPostBack = true;
        }
    }

    protected void RenderStoreID()
    {
        DataSet ds;
        //DataView dv;
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        String vEStoreID = string.Empty;
        ds = objEbook.Ebook_GeteStoreID(vUserID);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            vEStoreID = dr["eStoreID"].ToString();

            if (vEStoreID == "A" + Session["UserID"].ToString())
            {
                lblStoreID.Text = vEStoreID;
                ViewState["eStoreID"] = vEStoreID;
                tblStoreIDExists.Visible = true;
                tblStoreIDRegister.Visible = true;
            }
            else if (vEStoreID == "NOTCREATED")
            {
                tblStoreIDExists.Visible = false;
                tblStoreIDRegister.Visible = true; 
            }
            else
            {
                lblStoreID.Text = vEStoreID;
                ViewState["eStoreID"] = vEStoreID;

                tblStoreIDExists.Visible = true;
                tblStoreIDRegister.Visible = false;                 
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //get the form details.

        String tmpStoreID = txtStoreID.Text.Trim(); 
        string chkStoreID = tmpStoreID.ToString();

        if (chkStoreID.Substring(0,1).ToUpper() == "A")
        {
            chkStoreID = chkStoreID.Remove(0, 1);
        }

        if (Regex.IsMatch(chkStoreID, @"^\d+$"))
        {
            CommonFunctions.AlertMessage("E-StoreID Already Exists or Not Available. Please enter another E-StoreID");

            lblErrMessage.Text = "E-StoreID Already Exists or Not Available. Please enter another E-StoreID.";
            lblErrMessage.CssClass = "font_12Msg_Error";
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";

            return;
        }

        else
        {
            int inStatus = 0;
            int vMerchantID = 0;

            int vUserID = Convert.ToInt32(Session["UserID"].ToString());

            if (Session["MERID"] != null)
                vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
            else
                vMerchantID = 0;

            inStatus = objBALebook.Ebook_eStoreID_Create(tmpStoreID, vUserID, vMerchantID);

            if (inStatus == 1)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage11", "javascript:alert('" + tmpStoreID + ": Stored ID created successfully')", true);
                RenderStoreID();
                // Response.Redirect("EBAd_Dashboard.aspx");

            }
            else if (inStatus == 2)
            {
                //CommonFunctions.AlertMessage("Ebook Already Exists as a BestSeller. Please enter another BookID", "EBAd_BestSeller.aspx"); 
                CommonFunctions.AlertMessage("E-StoreID Already Exists or Not Available. Please enter another E-StoreID");

                lblErrMessage.Text = "E-StoreID Already Exists or Not Available. Please enter another E-StoreID.";
                lblErrMessage.CssClass = "font_12Msg_Error";
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";

                return;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage15", "javascript:alert('" + tmpBookID + ": eBook already exists as a Best Seller eBook. Please enter another BookID.')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert(' Unable to save the E-StoreID currently.  Please contact Administrator')", true);
            }
        }
    }

    protected void BtnPreview_Click(object sender, EventArgs e)
    {
        string tmpStoreID = txtStoreID.Text;

        string chkStoreID = tmpStoreID.ToString();
        if (chkStoreID.Substring(0,1).ToUpper() == "A")
        {
            chkStoreID = chkStoreID.Remove(0, 1);
        }

        if (Regex.IsMatch(chkStoreID, @"^\d+$"))
        {
            ImgStatus.Visible = true;
            ImgStatus.ImageUrl = "";
            lblResult.CssClass = "ValAlert_Error";
            lblResult.Text = "'<b>" + tmpStoreID + "</b>' is NOT available. Please try another.";
            lblResult.Visible = true;
            return;
        }
        else if (chkStoreID.ToUpper() == "BOOKSTOREID")
        {
            ImgStatus.Visible = true;
            ImgStatus.ImageUrl = "";
            lblResult.CssClass = "ValAlert_Error";
            lblResult.Text = "'<b>" + tmpStoreID + "</b>' is NOT available. Please try another.";
            lblResult.Visible = true;
            return;
        }
        else if (chkStoreID.ToUpper() == "STOREID")
        {
            ImgStatus.Visible = true;
            ImgStatus.ImageUrl = "";
            lblResult.CssClass = "ValAlert_Error";
            lblResult.Text = "'<b>" + tmpStoreID + "</b>' is NOT available. Please try another.";
            lblResult.Visible = true;
            return;
        }
        else
        {
            int cStatus = objBALebook.Ebook_eStoreID_Validity(tmpStoreID);

            if (cStatus == 1)
            {
                //.. Store ID can be stored. 

                ImgStatus.Visible = true;
                lblResult.Text = "'<b>" + tmpStoreID + "</b>' is available";
                lblResult.Visible = true;
                lblResult.CssClass = "font_12Msg_Success";
                btnSave.Visible = true;
            }
            else if (cStatus == 2)
            {
                //.. Stored ID already exists..

                ImgStatus.Visible = true;
                ImgStatus.ImageUrl = "";
                lblResult.CssClass = "ValAlert_Error";
                lblResult.Text = "'<b>" + tmpStoreID + "</b>' is NOT available. Please try another.";
                lblResult.Visible = true;
                return;

            }
            else
            {
                //..error 

            }
        }
    }

}