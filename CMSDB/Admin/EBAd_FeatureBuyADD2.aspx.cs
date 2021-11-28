using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class EBAd_FeatureBuyADD2 : System.Web.UI.Page
{
    //long MaxEbookFileSize = 5242880;    // 5MB 
    //long MaxEbookImageSize = 2097152;   // 2MB

    //bool ImgFileUploaded = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    //bool EbookFileUploaded = false;
    String EbookFileName = String.Empty;
    String EbookFileUrl = String.Empty;

    CMSv3.Entities.Ebook objEbEntity = new CMSv3.Entities.Ebook();
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
            MaintainScrollPositionOnPostBack = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //get the form details.
        String tmpBookID = txtBookID.Text.Trim().ToUpper();
        int tmpUserID  = Convert.ToInt32(Session["UserID"].ToString());
        int tmpBookUID = Convert.ToInt32(hdBookUID.Value); 

        Boolean tmpShowatHP = Convert.ToBoolean(rdoDisplayOnHomePage.SelectedValue);

        double Num;
        bool isNum = double.TryParse(txtPosition.Text.ToString(), out Num);

        if (isNum)
        {
            int vposition = Convert.ToInt32(txtPosition.Text.ToString());
            newDBS objDBS = new newDBS();
            int inStatus = objDBS.Ebook_FeatureBuy_ADDNew(tmpBookUID, tmpBookID, tmpUserID, tmpShowatHP, vposition);

            if (inStatus == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage11", "javascript:alert('" + tmpBookID + ": eBook marked as Feature Buy successfully')", true);

                tblMessageBar.Visible = true;
                lblErrMessage.Text = "Ebook Marked as FeatureBuy Sucessfully";
                lblErrMessage.CssClass = "font_12Msg_Success";
                MessageImage.Src = "~/Images/inf_Sucess.gif";

                ; Response.Redirect("EBAd_FeatureBuy.aspx");

            }
            else if (inStatus == 2)
            {
                //CommonFunctions.AlertMessage("Ebook Already Exists as a FeatureBuy. Please enter another BookID", "EBAd_FeatureBuy.aspx"); 
                CommonFunctions.AlertMessage("Ebook Already Exists as a FeatureBuy. Please enter another BookID");

                lblErrMessage.Text = "Ebook Already Exists as a FeatureBuy. Please enter another BookID.";
                lblErrMessage.CssClass = "font_12Msg_Error";
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";

                return;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage15", "javascript:alert('" + tmpBookID + ": eBook already exists as a Feature Buy eBook. Please enter another BookID.')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert(' Unable to save the Book currently.  Please contact Administrator')", true);
            }
        }
        else
        {
            CommonFunctions.AlertMessage("Position must be Numeric");
        }        

     //   Response.Redirect("EBAd_FeatureBuy.aspx");  
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string ImgURL = string.Empty;   
       Server.Transfer("EBAd_FeatureBuy.aspx"); 
    }

    protected void BtnPreview_Click(object sender, EventArgs e)
    {
        String tmpBookID = txtBookID.Text.Trim();
        int tmpUserID = Convert.ToInt32(Session["UserID"].ToString());
        
        DataSet ds;
        ds = objBALebook.Ebook_GetBookDetails(tmpBookID, tmpUserID);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];

            DataRow dr = dt.Rows[0];

            lblBookID.Text = dr["BookID"].ToString();
            lblBookName.Text = dr["BookNAme"].ToString();
            lblCategory.Text = dr["CategoryName"].ToString();
           // lblDateAdded.Text = String.Format("{0:MMMM d, yyyy}", Convert.ToDecimal(dr["DateCreated"].ToString())); ; // dr["DateCreated"].ToString();
            string SpecialStatus = dr["SpecialStatus"].ToString();

            if (SpecialStatus == "YES")
            {
                dvBookNotFound.Visible = true;
                dvBookNotFound.InnerHtml = "The Special Admin Ebook is not allowed to be Assigned here.";
                dvBookPreview.Visible = false;

                trHomePageShow.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
            else
            {
                DateTime dNewDate = Convert.ToDateTime(dr["DateCreated"].ToString());
                String strNewDate = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dNewDate);
                lblDateAdded.Text = strNewDate;
                lblOrgPrice.Text = String.Format("{0:n2}", Convert.ToDecimal(dr["Price"].ToString()));
                lblAfterDiscount.Text = String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString()));
                hdBookUID.Value = dr["UID"].ToString();

                //String.Format("{0:n2}", Convert.ToDecimal(tBookPriceCancel))
                ImgEbook.ImageUrl = dr["ImageFileFullURL"].ToString();

                dvBookPreview.Visible = true;
                dvBookNotFound.Visible = false;

                trHomePageShow.Visible = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
            }
        }
        else
        {
            dvBookNotFound.Visible = true;
            dvBookNotFound.InnerHtml = "No Book found with this BookID. Please enter another BookID.";
            dvBookPreview.Visible = false;

            trHomePageShow.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetBookIDs(string prefixText, int count, string contextKey)
    {

        CMSv3.BAL.eBook objEbook1 = new CMSv3.BAL.eBook();

        DataSet ds = objEbook1.GET_BookIDs(prefixText);
        DataTable dt = ds.Tables[0];

        List<string> tmpBookIds = new List<string>();
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    tmpBookIds.Add(dt.Rows[i][1].ToString());
        //}

        foreach (DataRow dr in dt.Rows)
        {

            tmpBookIds.Add(dr["BookID"].ToString());
        }


        return tmpBookIds.ToArray();
    }

}