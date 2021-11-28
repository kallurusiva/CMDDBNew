using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Admin_EbAd_SendEbookbyEmail : System.Web.UI.Page
{
    DataSet ds;

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    protected void Page_Load(object sender, EventArgs e)
    {
        #region
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion
        if (!IsPostBack)
        {
            ViewState["isValueBook"] = "0";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ViewState["isValueBook"].ToString() == "0")
        {
            Server.Transfer(@"EbAd_SendEBookbyEmailNow.aspx");
        }
        else
        {
            Server.Transfer(@"EbAd_SendValueEBookbyEmailNow.aspx");   
        }

    }
    protected void BtnPreview_Click(object sender, EventArgs e)
    {
        String tmpBookID = txtBookID.Text;

        ds = objBALebook.Ebook_RetrieveDetails(tmpBookID, Convert.ToInt32(Session["UserID"].ToString()), Session["MobileLoginID"].ToString().Replace("EB",""));
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnSave.Visible = true;
            btnCancel.Visible = true;
            
            DataRow utRow1 = ds.Tables[0].Rows[0];
            DataRow utRow2 = ds.Tables[1].Rows[0];

            String tmpBookValueBuy = utRow1["BValueBuy"].ToString();
            TextBoxYourName.Text = utRow2["MemberName"].ToString();

            if (tmpBookValueBuy == "0")
            {
                ViewState["isValueBook"] = "0";
                dvBookPreview.Visible = true;
                dvValueBookPreview.Visible = false;
                lblBookID.Text = tmpBookID.ToUpper();
                lblBookName.Text = utRow2["BookName"].ToString();
                lblCategory.Text = utRow2["CategoryName"].ToString();

                DateTime dDate = Convert.ToDateTime(utRow2["DateCreated"].ToString());
                lblDateAdded.Text = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dDate);

                ImgEbook.ImageUrl = utRow2["ImageFileFullURL"].ToString();
                lblNCurrencyPrice.Text = lblNDiscountPrice.Text = utRow2["Denom"].ToString();
                lblOrgPrice.Text = String.Format("{0:n2}", Convert.ToDecimal(utRow2["BookPrice"].ToString()));
                lblAfterDiscount.Text = String.Format("{0:n2}", Convert.ToDecimal(utRow2["BookDiscountedPrice"].ToString()));
           
            }
            else
            {
                ViewState["isValueBook"] = "1";
                dvBookPreview.Visible = false;
                dvValueBookPreview.Visible = true;
                BookName1.Text = utRow2["BookID1"].ToString();
                BookName2.Text = utRow2["BookID2"].ToString();
                BookName3.Text = utRow2["BookID3"].ToString();
                BookName4.Text = utRow2["BookID4"].ToString();
                BookName5.Text = utRow2["BookID5"].ToString();

                ImageBook1.ImageUrl = utRow2["Book1ImageFileFullURL"].ToString();
                ImageBook2.ImageUrl = utRow2["Book2ImageFileFullURL"].ToString();
                ImageBook3.ImageUrl = utRow2["Book3ImageFileFullURL"].ToString();
                ImageBook4.ImageUrl = utRow2["Book4ImageFileFullURL"].ToString();
                ImageBook5.ImageUrl = utRow2["Book5ImageFileFullURL"].ToString();

                lblValueBookID.Text = tmpBookID.ToUpper();
                lblValueBookName.Text = utRow2["BookName"].ToString();
                lblValueBookCount.Text = utRow2["BooksCount"].ToString();

                DateTime dvalueDate = Convert.ToDateTime(utRow2["DateCreated"].ToString());
                lblValueDateAdded.Text = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dvalueDate);

                lblCurrencyPrice.Text = lblCurrencyDiscount.Text = utRow2["Denom"].ToString();
                lblValueOrgPrice.Text = String.Format("{0:n2}", Convert.ToDecimal(utRow2["BookPrice"].ToString()));
                lblValueAfterDiscount.Text = String.Format("{0:n2}", Convert.ToDecimal(utRow2["BookDiscountedPrice"].ToString()));
           
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
