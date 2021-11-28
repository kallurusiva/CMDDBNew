using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;

public partial class SuperAdmin_SA_AncDomainsCreate : System.Web.UI.Page 
{

    CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();
    CMSv3.BAL.IFMDomains objBAL_ifmDomains = new CMSv3.BAL.IFMDomains(); 

    DataSet dsCat;
    DataView dvCat; 

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrDisplayAtWebsite.Text = Resources.LangResources.DisplayatWebsite;
                
        #region  // SessionCheck
        if ((Session["saUserID"].ToString() == null) || (Session["saUserID"].ToString() == ""))
        {
            Response.Redirect("~/SuperAdmin/SA_SessionExpire.aspx");
        }
        #endregion 

        if (!IsPostBack)
        {

            LoadAncDomainCategories();
        }


    }

    protected void LoadAncDomainCategories()
    {
        dsCat = objBAL_Domains.Retrieve_AncDomainCategories("");
        dvCat = dsCat.Tables[0].DefaultView;

        ddlAncCategory.DataSource = dsCat;
        ddlAncCategory.DataTextField = "CategoryName";
        ddlAncCategory.DataValueField = "CategoryID";
        ddlAncCategory.DataBind(); 


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        
        //Get the form values and store them objEvent
        String mAnchorDomain = txtAnchorDomain.Text.Trim();
        String mSampleURL = txtSampleURL.Text.Trim();
        int mCategoryID = Convert.ToInt32(ddlAncCategory.SelectedValue); 

        bool isActive = chkActive.Checked;

        int inStatus = objBAL_Domains.Insert_AnchorDomains(mAnchorDomain, mSampleURL, mCategoryID, isActive);
        


        if (inStatus == 1)
        {
            //... Storing datat into the IFM database as well. 
            int ifm_inStatus = objBAL_ifmDomains.Insert_AnchorDomains(mAnchorDomain, mSampleURL, mCategoryID, isActive); 

            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Sucess.gif";
            lblErrMessage.Text = "Anchor Domain successfully added";
            lblErrMessage.CssClass = "font_12Msg_Success";
            
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "RecInserted", "alert('FAQ Item inserted Successfully')", true);
            Response.Redirect("SA_AncDomainsListing.aspx");
            return;
        }
        else if (inStatus == 2)
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Duplicate AnchorDomain entered. Please try with Another Domain Name.";
            lblErrMessage.CssClass = "font_12Msg_Error";

        }
        else
        {
            tblMessageBar.Visible = true;
            MessageImage.Src = "~/Images/inf_Error.gif";
            lblErrMessage.Text = "Due to a Technical Reason the system is unable to Save the record. Please contant Administrator";
            lblErrMessage.CssClass = "font_12Msg_Error";
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("SA_AncDomainsListing.aspx");
    }
}
