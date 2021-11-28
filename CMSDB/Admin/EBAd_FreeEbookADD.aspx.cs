using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class EBAd_FreeEbookADD : System.Web.UI.Page
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
            validate_Page();
            MaintainScrollPositionOnPostBack = true;
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
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

            int inStatus = objDBS.Ebook_FreeEbook_ADDNew(tmpBookUID, tmpBookID, tmpUserID, tmpShowatHP, vposition);

            if (inStatus == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage11", "javascript:alert('" + tmpBookID + ": eBook marked as Free Ebook successfully')", true);

                tblMessageBar.Visible = true;
                lblErrMessage.Text = "Ebook Marked as Free Ebook Sucessfully";
                lblErrMessage.CssClass = "font_12Msg_Success";
                MessageImage.Src = "~/Images/inf_Sucess.gif";

                Response.Redirect("EBAd_FreeEbooks.aspx");
            }
            else if (inStatus == 2)
            {
                CommonFunctions.AlertMessage("Ebook Already Exists as a Free Ebook. Please enter another BookID");

                lblErrMessage.Text = "Ebook Already Exists as a Free Ebook. Please enter another BookID.";
                lblErrMessage.CssClass = "font_12Msg_Error";
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";
                return;
            }
            else if (inStatus == 3)
            {
                //CommonFunctions.AlertMessage("Ebook Already Exists as a BestSeller. Please enter another BookID", "EBAd_BestSeller.aspx"); 
                CommonFunctions.AlertMessage("Admin Ebook canot be added as FREE EBook.");

                lblErrMessage.Text = "Admin Ebook canot be added as FREE EBook.";
                lblErrMessage.CssClass = "font_12Msg_Error";
                tblMessageBar.Visible = true;
                MessageImage.Src = "~/Images/inf_Error.gif";

                return;
            }            
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert(' Unable to save the Book currently.  Please contact Administrator')", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string ImgURL = string.Empty;
        Server.Transfer("EBAd_FreeEbooks.aspx"); 
    }

    protected void BtnPreview_Click(object sender, EventArgs e)
    {
        String tmpBookID = txtBookID.Text.Trim();
        int tmpUserID = Convert.ToInt32(Session["UserID"].ToString());

        DataSet ds;
        ds = objBALebook.Ebook_GetBookDetails(tmpBookID,tmpUserID);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];

            lblBookID.Text = dr["BookID"].ToString();
            lblBookName.Text = dr["BookNAme"].ToString();
            lblCategory.Text = dr["CategoryName"].ToString();
            string createdby = dr["CreatedBy"].ToString();

            if (createdby == "7484")
            {
                CommonFunctions.AlertMessage("Admin Ebook canot be added as FREE EBook.");
            }
            else
            {
                DateTime dNewDate = Convert.ToDateTime(dr["DateCreated"].ToString());
                String strNewDate = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dNewDate);
                lblDateAdded.Text = strNewDate;

                lblOrgPrice.Text = String.Format("{0:n2}", Convert.ToDecimal(dr["Price"].ToString()));
                lblAfterDiscount.Text = String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString()));

                hdBookUID.Value = dr["UID"].ToString();

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

    protected void validate_Page()
    {
        if (Session["MobileLoginID"] != null)
        {
            SqlConnection dbConn1;
            SqlCommand dbCmd1;
            SqlDataReader dbReader;

            string mlmStatusPack = string.Empty;
            String mUserId = Session["MobileLoginID"].ToString().Replace("EB", "");
            string strSQL = "EXEC eSMS.dbo.uspT_getUserPackageType " + mUserId;

            dbConn1 = new SqlConnection(GlobalVar.GetDbConnString);

            try
            {
                dbConn1.Open();
                dbCmd1 = new SqlCommand(strSQL, dbConn1);
                dbReader = dbCmd1.ExecuteReader();

                if (dbReader.HasRows)
                {
                    while (dbReader.Read())
                    {
                        mlmStatusPack = dbReader["mlmStatus"].ToString();
                    }
                }

                if (mlmStatusPack == "0")
                {
                    //CommonFunctions.AlertMessage("This Facility is for upgraded Partners only. Please upgrade to enjoy this facility.");
                    CommonFunctions.AlertMessageAndRedirect("This Facility is for upgraded Partners only. Please upgrade now to enjoy Free Your Own EBook uploads and ability to assign the EBook for FREE to Capture Database of MobileNo and Email for future marketing.", "Ad_WelcomeEbook.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                dbConn1.Close();
            }
        }
    }

}