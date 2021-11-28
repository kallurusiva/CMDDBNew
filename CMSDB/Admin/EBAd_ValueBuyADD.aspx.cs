using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class EBAd_ValueBuyADD : System.Web.UI.Page
{

    //long MaxEbookFileSize = 5242880;    // 5MB
    //long MaxEbookImageSize = 2097152;   // 2MB

    //bool ImgFileUploaded = false;
    string ImgFileName = string.Empty;
    string ImgFileUrl = string.Empty;

    //bool EbookFileUploaded = false;
    String EbookFileName = String.Empty;
    String EbookFileUrl = String.Empty;

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



        txtPrice.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        txtDiscount.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");

        txtDiscountedPrice.Attributes.Add("readonly", "readonly");

        if (!IsPostBack)
        {

            txtPrice.Text = "50";
            txtDiscount.Text = "50";
            txtDiscountedPrice.Text = "25";

            //txtSenderEmailID.Text = "";

            txtSMSmessage.Text = "Thank you for your purchase. An ebook is being sent to you,Pls check your email Inbox & Bulk folder as sometime it may go the latter.";

            string vEmailMessageText = string.Empty;

            vEmailMessageText += "Dear Customer," + Environment.NewLine + Environment.NewLine;
            vEmailMessageText += "Thank you for your Order." + Environment.NewLine + Environment.NewLine;
            vEmailMessageText += "The Ebook you purchased is attached. Please download it for reading purpose." + Environment.NewLine + Environment.NewLine;
            vEmailMessageText += "Best Regards," + Environment.NewLine;


            txtEmailMessage.Text = vEmailMessageText;



            ViewState["FileImageUrl"] = "";
            ViewState["FileImageName"] = "";
            ViewState["FileImageUploaded"] = false;

            ViewState["FileEbookUrl"] = "";
            ViewState["FileEbookName"] = "";
            ViewState["FileEbookUploaded"] = false;

         
            rdoNoOfBooks.SelectedIndex = 0;
            txtBookID1.Visible = true;
            txtBookID2.Visible = true; 

            MaintainScrollPositionOnPostBack = true;
        }


    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        

        if (Page.IsValid)
        {
            //Book Details...
            //==================================
            objEbEntity.BookName = txtBookName.Text.Trim();
            objEbEntity.BookTitle = txtBookName.Text.Trim();
            objEbEntity.catID = 75; 
            objEbEntity.categoryName = "ValueBuyUSER";
            objEbEntity.BookRefID = "BookByUser";


            bool chkShowAtHp = Convert.ToBoolean(rdoDispHomePage.SelectedValue);

            objEbEntity.isDisplay = Convert.ToBoolean(rdoDisplayatWebsite.SelectedValue);
            objEbEntity.isBuySMS = Convert.ToBoolean(rdoBuySMS.SelectedValue);
            objEbEntity.isBuyPayPal = Convert.ToBoolean(rdoBuyPayPal.SelectedValue);
            //ebEntity.isFeatured = Convert.ToBoolean(rdoFeatured.SelectedValue);
            objEbEntity.isFeatured = false;
            objEbEntity.isBestSeller = false;

            objEbEntity.Price = Convert.ToDecimal(txtPrice.Text);
            objEbEntity.Discount = Convert.ToDecimal(txtDiscount.Text);

            objEbEntity.LaunchStatus = Convert.ToInt16(rdoLaunchStatus.SelectedValue); 

            objEbEntity.CreatedBy = Convert.ToInt32(Session["UserID"]);

            int vMerchantID = 0;

            if (Session["MERID"] != null)
                vMerchantID = Convert.ToInt32(Session["MERID"].ToString());
            else
                Response.Redirect("~/SessionExpireEbook.aspx");

            objEbEntity.MerchantID = vMerchantID; 


            objEbEntity.Description = "";

            objEbEntity.ImgFileName = ViewState["FileImageName"].ToString();
            objEbEntity.ImgFilePath = ViewState["FileImageUrl"].ToString();

            objEbEntity.EbookFileName = ViewState["FileEbookName"].ToString();
            objEbEntity.EbookFilePath = ViewState["FileEbookUrl"].ToString();


            objEbEntity.CCmobile1 = txtCCMobile1.Text.Trim();
            objEbEntity.CCmobile2 = txtCCMobile2.Text.Trim();
            objEbEntity.CCmobile3 = txtCCMobile3.Text.Trim(); 


            // Reply Info 
            //objEbEntity.ReplySubject = txtSubject.Text.Trim();
            //objEbEntity.SenderEmailID = txtSenderEmailID.Text.Trim();
            //objEbEntity.ReplySMS = txtSMSmessage.Text.Trim();
            //objEbEntity.ReplyEmail = txtEmailMessage.Text.Trim();

            objEbEntity.ReplySubject = txtSubject.Text.Trim();
            objEbEntity.SenderEmailID = "noreply@ebooksmsdelivery.com";
            objEbEntity.ReplySMS = txtSMSmessage.Text.Trim();
            objEbEntity.ReplyEmail = txtEmailMessage.Text.Trim();

            String vBookID1 = txtBookID1.Text.Trim().ToUpper();
            String vBookID2 = txtBookID2.Text.Trim().ToUpper();
            String vBookID3 = txtBookID3.Text.Trim().ToUpper();
            String vBookID4 = txtBookID4.Text.Trim().ToUpper();
            String vBookID5 = txtBookID5.Text.Trim().ToUpper();

            int vBookCount = Convert.ToInt16(rdoNoOfBooks.SelectedValue);

            int vUserID = Convert.ToInt32(Session["UserID"].ToString());

            int aStatus = objBALebook.EBook_AddBook_ValueBuy_ByUser(vUserID, objEbEntity, vBookID1, vBookID2, vBookID3, vBookID4, vBookID5, vBookCount, chkShowAtHp);
        

            if (aStatus == 2)
            {
                CommonFunctions.AlertMessage("A Book by this name already exists. Please Check.");
            }
            else if (aStatus == 1)
            {
                CommonFunctions.AlertMessage("Value-Buy eBook Added Successfully");

                Response.Redirect("EBAd_ValueBuyList.aspx?qStatus=1");
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



        ds = objBALebook.Ebook_CheckValueBuyBookIDs(vBookCount, txtBookID1.Text, txtBookID2.Text, txtBookID3.Text, txtBookID4.Text, txtBookID5.Text);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];

            int vBook1_Status = Convert.ToInt16(dr["BookID1"].ToString());
            int vBook2_Status = Convert.ToInt16(dr["BookID2"].ToString());
            int vBook3_Status = Convert.ToInt16(dr["BookID3"].ToString());
            int vBook4_Status = Convert.ToInt16(dr["BookID4"].ToString());
            int vBook5_Status = Convert.ToInt16(dr["BookID5"].ToString());

            vStatus = Convert.ToInt16("1");

            switch (vBookCount)
            {
                case 2: vBook3_Status = 1; vBook4_Status = 1; vBook5_Status = 1;
                    break;

                case 3: vBook4_Status = 1; vBook5_Status = 1;
                    break;

                case 4: vBook5_Status = 1;
                    break;

            }



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


    protected void rdoNoOfBooks_SelectedIndexChanged(object sender, EventArgs e)
    {

        string selNoofBooks = rdoNoOfBooks.SelectedValue;

        switch (selNoofBooks)
        {
            case "2": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = false; txtBookID4.Visible = false; txtBookID5.Visible = false; break;
            case "3": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = true;  txtBookID4.Visible = false; txtBookID5.Visible = false; break;
            case "4": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = true;  txtBookID4.Visible = true;  txtBookID5.Visible = false; break;
            case "5": txtBookID1.Visible = true; txtBookID2.Visible = true; txtBookID3.Visible = true;  txtBookID4.Visible = true;  txtBookID5.Visible = true; break;
        }
    }


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


}