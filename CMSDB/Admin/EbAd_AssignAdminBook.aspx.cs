using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class Admin_EbAd_AssignAdminBook : System.Web.UI.Page
{

    //long MaxEbookFileSize = 5242880;    // 5MB
    //long MaxEbookImageSize = 2097152;   // 2MB

    //bool ImgFileUploaded = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    bool EbookFileUploaded = false;
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
        EbookFileUploaded = GetBool();
        if (!IsPostBack)
        {
            MaintainScrollPositionOnPostBack = true;
            RenderMainCategories();
        }
    }

    private static bool GetBool()
    {
        return false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        int mainCategory;
        int subCategory;
        string bkid;
        string rtmessage = "";
        mainCategory = Convert.ToInt32(ddlMainCategory.SelectedValue);
        subCategory = Convert.ToInt32(ddlCategory.SelectedValue);
        bkid = txtBookID.Text.ToString();

        newDBS ndbs = new newDBS();
        DataSet dst = ndbs.insert_AssignAdminBooks(Convert.ToInt32(Session["UserID"].ToString()), subCategory, bkid);
        if (dst.Tables[0].Rows.Count > 0)
        {
            rtmessage = dst.Tables[0].Rows[0]["returnMessage"].ToString();
        }       
            CommonFunctions.AlertMessage(rtmessage.ToString());
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {


        string ImgURL = string.Empty;


        Server.Transfer("EBAd_BestSeller.aspx");


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
                dvBookNotFound.InnerHtml = "The Special Admin Ebook is not allowed to be Assigned to your Category.";
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

    protected void RenderMainCategories()
    {

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        // DataSet ds = objBALebook.CatMain_Categories(vUserID, "");  
        DataSet ds = objBALebook.EBook_Get_MainCategories(vUserID, "00");

        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlMainCategory.DataSource = ds;
            ddlMainCategory.DataTextField = "ddlCatName";
            ddlMainCategory.DataValueField = "CatMainID";
            ddlMainCategory.DataBind();

            ddlMainCategory.Items.Insert(0, new ListItem("Select Main Category", "0"));
        }
        else
        {
            CommonFunctions.AlertMessageAndRedirect("Please Create MyCategory before adding new book", "EBAd_UserCategoryMain.aspx");
        }

    }

    protected void ddlMainCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        //...get selected category

        int vMainCatID = Convert.ToInt32(ddlMainCategory.SelectedValue);

        LoadCategories(vMainCatID);


    }

    protected void LoadCategories(int vMainCatID)
    {

        String strSearch = " AND MCAT.CatMainID = " + vMainCatID;

        DataSet ds;

        ds = objBALebook.Category_Load_ByUserID(Convert.ToInt32(Session["UserID"]), strSearch);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCategory.DataSource = ds;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Sub Category", "0"));
        }
        else
        {
            CommonFunctions.AlertMessageAndRedirect("Please Create SubCategory before adding new book", "EBAd_UserCategoryList.aspx");
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