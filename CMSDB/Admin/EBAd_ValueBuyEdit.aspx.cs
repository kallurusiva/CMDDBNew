using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class EBAd_ValueBuyEdit : System.Web.UI.Page
{

    //long MaxEbookFileSize = 5242880;    // 5MB
    //long MaxEbookImageSize = 2097152;   // 2MB

    bool ImgFileUploaded = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    //bool EbookFileUploaded = false;
    String EbookFileName = String.Empty;
    String EbookFileUrl = String.Empty;

    string qBookID = string.Empty;
    DataSet ds;

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


        ImgFileUploaded = GetBool();
        txtPrice.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtDiscount.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");

        txtDiscountedPrice.Attributes.Add("readonly", "readonly");

        if (!IsPostBack)
        {


            qBookID = Server.UrlDecode(Decrypt(Request.QueryString["BookID"].ToString()));

            ViewState["qBookID"] = qBookID; 

           // qBookID = Request.QueryString["BookID"].ToString();
            LoadBookDetails(qBookID); 


        }


    }

    private static bool GetBool()
    {
        return false;
    }

    protected void LoadBookDetails(string vBookId)
    {

        if (vBookId != "")
        {


            ViewState["qBookID"] = vBookId;

            ds = objBALebook.Ebook_ValueBuy_Edit(vBookId, Convert.ToInt32((Session["UserID"].ToString()))); 
            

            
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataRow bkRow = ds.Tables[0].Rows[0];

                lblBookCode.Text = bkRow["BookID"].ToString(); 

                txtBookName.Text = bkRow["BookName"].ToString();

                txtPrice.Text = bkRow["Price"].ToString();
                txtDiscount.Text = bkRow["Discount"].ToString();

                decimal vPrice = Convert.ToDecimal(txtPrice.Text);
                decimal vDiscount = Convert.ToDecimal(txtDiscount.Text);

                decimal vDiscPrice = (vPrice - (vPrice * vDiscount) / 100);

                txtDiscountedPrice.Text = vDiscPrice.ToString();


                //chkActive.Checked = Convert.ToBoolean(drow["Active"].ToString());
                rdoDisplayatWebsite.SelectedValue = Convert.ToBoolean(bkRow["isDisplay"].ToString()).ToString();
                rdoDispHomePage.SelectedValue = Convert.ToBoolean(bkRow["isShowAtHp"].ToString()).ToString();

                // rdoFeatured.SelectedValue = Convert.ToBoolean(bkRow["isFeatured"].ToString()).ToString();
                rdoBuySMS.SelectedValue = Convert.ToBoolean(bkRow["AllowSMSbuy"].ToString()).ToString();
                rdoBuyPayPal.SelectedValue = Convert.ToBoolean(bkRow["AllowPaypalBuy"].ToString()).ToString();

                rdoLaunchStatus.SelectedValue = bkRow["LaunchStatus"].ToString(); 


                ViewState["FileImageUrl"] = "";
                ViewState["FileImageName"] = "";


                ViewState["FileEbookUrl"] = "";
                ViewState["FileEbookName"] = "";


                txtSubject.Text = bkRow["eSubject"].ToString();
                txtSenderEmailID.Text = bkRow["eSenderEmailID"].ToString();
                txtSMSmessage.Text = bkRow["ReplySMS"].ToString();

                String vEmailMessage = bkRow["eMessage"].ToString();
                txtEmailMessage.Text = vEmailMessage.Replace("<br/>", Environment.NewLine);


                rdoNoOfBooks.SelectedValue = bkRow["BooksCount"].ToString();


                txtCCMobile1.Text = bkRow["Mobile1"].ToString();
                txtCCMobile2.Text = bkRow["Mobile2"].ToString();
                txtCCMobile3.Text = bkRow["Mobile3"].ToString();

                txtBookID1.Text = bkRow["BookID1"].ToString();
                txtBookID2.Text = bkRow["BookID2"].ToString();
                txtBookID3.Text = bkRow["BookID3"].ToString();
                txtBookID4.Text = bkRow["BookID4"].ToString();
                txtBookID5.Text = bkRow["BookID5"].ToString();


                RenderBookIds(bkRow["BooksCount"].ToString());


            }


        }



    }


    protected void RenderBookIds(string vBooksCount)
    {

        switch (vBooksCount)
        {
            case "2": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = false; txtBookID4.Visible = false; txtBookID5.Visible = false; break;
            case "3": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = true; txtBookID4.Visible = false; txtBookID5.Visible = false; break;
            case "4": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = true; txtBookID4.Visible = true; txtBookID5.Visible = false; break;
            case "5": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = true; txtBookID4.Visible = true; txtBookID5.Visible = true; break;
        }


    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        int vMerchantID = 0;

        if (Session["MERID"] != null)
            vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
        else
            Response.Redirect("~/SessionExpireEbook.aspx");


        if (Page.IsValid)
        {
            //Book Details...
            //==================================

            objEbEntity.BookID = ViewState["qBookID"].ToString(); 
            objEbEntity.BookName = txtBookName.Text.Trim();
            objEbEntity.BookTitle = txtBookName.Text.Trim();
            objEbEntity.catID = 75; 
            objEbEntity.categoryName = "ValueBuyUSER";
            objEbEntity.BookRefID = "BookByUser";

            objEbEntity.MerchantID = 111; 


            bool chkShowAtHp = Convert.ToBoolean(rdoDispHomePage.SelectedValue);

            objEbEntity.isDisplay = Convert.ToBoolean(rdoDisplayatWebsite.SelectedValue);
            objEbEntity.isBuySMS = Convert.ToBoolean(rdoBuySMS.SelectedValue);
            objEbEntity.isBuyPayPal = Convert.ToBoolean(rdoBuyPayPal.SelectedValue);
            //ebEntity.isFeatured = Convert.ToBoolean(rdoFeatured.SelectedValue);
            objEbEntity.isFeatured = false;
            objEbEntity.isBestSeller = false;

            objEbEntity.LaunchStatus = Convert.ToInt16(rdoLaunchStatus.SelectedValue); 

            objEbEntity.Price = Convert.ToDecimal(txtPrice.Text);
            objEbEntity.Discount = Convert.ToDecimal(txtDiscount.Text);

            

            objEbEntity.CreatedBy = Convert.ToInt32(Session["UserID"]);
            objEbEntity.MerchantID = vMerchantID; 

            objEbEntity.Description = "";

            objEbEntity.ImgFileName = ViewState["FileImageName"].ToString();
            objEbEntity.ImgFilePath = ViewState["FileImageUrl"].ToString();

            objEbEntity.EbookFileName = ViewState["FileEbookName"].ToString();
            objEbEntity.EbookFilePath = ViewState["FileEbookUrl"].ToString();
      



            // Reply Info 
            objEbEntity.ReplySubject = txtSubject.Text.Trim();
            objEbEntity.SenderEmailID = txtSenderEmailID.Text.Trim();
            objEbEntity.ReplySMS = txtSMSmessage.Text.Trim();
            objEbEntity.ReplyEmail = txtEmailMessage.Text.Trim();

            objEbEntity.CCmobile1 = txtCCMobile1.Text.Trim();
            objEbEntity.CCmobile2 = txtCCMobile2.Text.Trim();
            objEbEntity.CCmobile3 = txtCCMobile3.Text.Trim(); 


            String vBookID1 = txtBookID1.Text.Trim().ToUpper();
            String vBookID2 = txtBookID2.Text.Trim().ToUpper();
            String vBookID3 = txtBookID3.Text.Trim().ToUpper();
            String vBookID4 = txtBookID4.Text.Trim().ToUpper();
            String vBookID5 = txtBookID5.Text.Trim().ToUpper();

            int vBookCount = Convert.ToInt16(rdoNoOfBooks.SelectedValue);

            int vUserID = Convert.ToInt32(Session["UserID"].ToString());

            int aStatus = objBALebook.EBook_ValueBuy_Update(vUserID, objEbEntity, vBookID1, vBookID2, vBookID3, vBookID4, vBookID5, vBookCount, chkShowAtHp);

            if (aStatus == 2)
            {
                CommonFunctions.AlertMessage("ValueBuy Book Title already exists");
            }
            else if (aStatus == 1)
            {
                CommonFunctions.AlertMessage("Value Buy Book Updated Successfully");
                Response.Redirect("EBAd_ValueBuyList.aspx?qStatus=2");
            }


        }





    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {


        string ImgURL = string.Empty;
        
        Server.Transfer("EBAd_ValueBuyList.aspx"); 


    }



    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {

        decimal vPrice = 0;
        decimal vDiscount = 0;
        decimal vDisPrice = 0;

        vPrice = Convert.ToDecimal(txtPrice.Text);
        vDiscount = Convert.ToDecimal(txtDiscount.Text);


        if ((vPrice != 0) && (vDiscount != 0))
        {
            vDisPrice = vPrice - ((vPrice * vDiscount) / 100);
        }

        txtDiscountedPrice.Text = vDisPrice.ToString();

    }

    protected void txtPrice_TextChanged(object sender, EventArgs e)
    {

        decimal vPrice = 0;
        decimal vDiscount = 0;
        decimal vDisPrice = 0;

        vPrice = Convert.ToDecimal(txtPrice.Text);
        vDiscount = Convert.ToDecimal(txtDiscount.Text);
        if ((vPrice != 0) && (vDiscount != 0))
        {
            vDisPrice = vPrice - ((vPrice * vDiscount) / 100);
        }

        txtDiscountedPrice.Text = vDisPrice.ToString();


    }


    protected void txtBookName_TextChanged(object sender, EventArgs e)
    {
        txtSubject.Text = "Ebook: " + txtBookName.Text.Trim(); 
    }


    protected void CheckBookIDStatus()
    {
        int vStatus = 1;

        int vBookCount = Convert.ToInt16(rdoNoOfBooks.SelectedValue);

        vStatus = Convert.ToInt16("1");

        ds = objBALebook.Ebook_CheckValueBuyBookIDs(vBookCount, txtBookID1.Text, txtBookID2.Text, txtBookID3.Text, txtBookID4.Text, txtBookID5.Text);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];

            int vBook1_Status = Convert.ToInt16(dr["BookID1"].ToString());
            int vBook2_Status = Convert.ToInt16(dr["BookID2"].ToString());
            int vBook3_Status = Convert.ToInt16(dr["BookID3"].ToString());
            int vBook4_Status = Convert.ToInt16(dr["BookID4"].ToString());
            int vBook5_Status = Convert.ToInt16(dr["BookID5"].ToString());

            switch (vBookCount)
            {
                case 2: vBook3_Status = 1; vBook4_Status = 1; vBook5_Status = 1;
                    break;

                case 3: vBook4_Status = 1; vBook5_Status = 1;
                    break;

                case 4: vBook5_Status = 1;
                    break;

            }

            vStatus = 1;

            if (vBook1_Status == 0)
            {
                vStatus = 2; CustomValidatorBook1.IsValid = false; lblBookIDResult.Visible = true; lblBookIDResult.Text = "'" + txtBookID1.Text + "': BookID doest not Exists. Please Check.";
                txtBookID1.BackColor = System.Drawing.Color.LightPink; txtBookID1.Focus();
                return;
            }

            if (vBook2_Status == 0)
            {
                vStatus = 2; CustomValidatorBook2.IsValid = false; lblBookIDResult.Visible = true; lblBookIDResult.Text = "'" + txtBookID2.Text + "': BookID doest not Exists. Please Check.";
                txtBookID2.BackColor = System.Drawing.Color.LightPink; txtBookID2.Focus();
                return;
            }

            if (vBook3_Status == 0)
            {
                vStatus = 2; CustomValidatorBook3.IsValid = false; lblBookIDResult.Visible = true; lblBookIDResult.Text = "'" + txtBookID3.Text + "': BookID doest not Exists. Please Check.";
                txtBookID3.BackColor = System.Drawing.Color.LightPink; txtBookID3.Focus();
                return;
            }

            if (vBook4_Status == 0)
            {
                vStatus = 2; CustomValidatorBook3.IsValid = false; lblBookIDResult.Visible = true; lblBookIDResult.Text = "'" + txtBookID4.Text + "': BookID doest not Exists. Please Check.";
                txtBookID4.BackColor = System.Drawing.Color.LightPink; txtBookID4.Focus();
                return;
            }

            if (vBook5_Status == 0)
            {
                vStatus = 2; CustomValidatorBook3.IsValid = false; lblBookIDResult.Visible = true; lblBookIDResult.Text = "'" + txtBookID5.Text + "': BookID doest not Exists. Please Check.";
                txtBookID5.BackColor = System.Drawing.Color.LightPink; txtBookID5.Focus();
                return;
            }



            btnSave.Visible = true;
            btnPreview.Visible = false;
            lblShowSaveBtn.Visible = true;
            lblShowSaveBtn.Text = "ALL BookIDs validated. Please Click Save Button.";
            btnSave.Focus();


        }
        else
        {
            vStatus = 2;
            btnSave.Visible = false;
            btnPreview.Visible = true;
            lblShowSaveBtn.Visible = false;
        }


        // return vStatus; 


    }


    //protected void rdoNoOfBooks_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    string selNoofBooks = rdoNoOfBooks.SelectedValue;

    //    switch (selNoofBooks)
    //    {
    //        case "2": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = false; txtBookID4.Visible = false; txtBookID5.Visible = false; break;
    //        case "3": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = true; txtBookID4.Visible = false; txtBookID5.Visible = false; break;
    //        case "4": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = true; txtBookID4.Visible = true; txtBookID5.Visible = false; break;
    //        case "5": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID4.Visible = true; txtBookID4.Visible = true; txtBookID5.Visible = true; break;
    //    }
    //}


    protected void btnPreview_Click(object sender, EventArgs e)
    {
        //validating the book IDs 

        CheckBookIDStatus();

        
    }

    protected void txtBookID1_TextChanged(object sender, EventArgs e)
    {
        // String tmpBookID = txtBookID1.Text.Trim();

        //DataSet ds;
        //ds = objBALebook.Ebook_GetBookDetails(tmpBookID);

        //if (ds.Tables[0].Rows.Count > 0)
        //{

        //}


        CheckBookID(txtBookID1, lblBookCheck1); 
    }
    protected void txtBookID2_TextChanged(object sender, EventArgs e)
    {
        CheckBookID(txtBookID2, lblBookCheck2); 
    }
    protected void txtBookID3_TextChanged(object sender, EventArgs e)
    {
        CheckBookID(txtBookID3, lblBookCheck3); 
    }


    protected void txtBookID4_TextChanged(object sender, EventArgs e)
    {
        CheckBookID(txtBookID4, lblBookCheck4); 
    }
    protected void txtBookID5_TextChanged(object sender, EventArgs e)
    {
        CheckBookID(txtBookID5, lblBookCheck5); 
    }

    protected void rdoNoOfBooks_SelectedIndexChanged(object sender, EventArgs e)
    {

        string selNoofBooks = rdoNoOfBooks.SelectedValue;

        switch (selNoofBooks)
        {
            case "2": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = false; txtBookID4.Visible = false; txtBookID5.Visible = false;
                txtBookID3.Text = ""; txtBookID4.Text = ""; txtBookID5.Text = "";
                break;
            case "3": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = true; txtBookID4.Visible = false; txtBookID5.Visible = false;
                txtBookID4.Text = ""; txtBookID5.Text = "";
                break;
            case "4": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = true; txtBookID4.Visible = true; txtBookID5.Visible = false;
                txtBookID5.Text = "";
                break;
            case "5": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID4.Visible = true; txtBookID4.Visible = true; txtBookID5.Visible = true; break;
        }
    }



    protected void CheckBookID(TextBox tb, Label lbchk)
    {

        DataSet ds;
        int tmpUserID = Convert.ToInt32(Session["UserID"].ToString());

        ds = objBALebook.Ebook_GetBookDetails(tb.Text, tmpUserID);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lbchk.Visible = true;
            lblBookCheck1.CssClass = "ValAlert_Success";
            lbchk.Text = "Entered Book Code is VALID."; 

        }
        else
        {
            tb.Focus();
            tb.BackColor = System.Drawing.Color.PaleGoldenrod;
            lbchk.Visible = true;
            lblBookCheck1.CssClass = "ValAlert_Error";
            lbchk.Text = "Entered Book Code does not Exist. Please Check."; 
        }

    }

    public static string Encrypt(string val)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(val);
        var encBytes = System.Security.Cryptography.ProtectedData.Protect(bytes, new byte[0], System.Security.Cryptography.DataProtectionScope.LocalMachine);
        return Convert.ToBase64String(encBytes);
    }


    public static string Decrypt(string val)
    {
        var bytes = Convert.FromBase64String(val);
        var encBytes = System.Security.Cryptography.ProtectedData.Unprotect(bytes, new byte[0], System.Security.Cryptography.DataProtectionScope.LocalMachine);
        return System.Text.Encoding.UTF8.GetString(encBytes);
    }


}