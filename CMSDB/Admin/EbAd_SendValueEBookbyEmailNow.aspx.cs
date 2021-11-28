using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Admin_EbAd_SendValueEBookbyEmailNow : System.Web.UI.Page
{
    DataSet ds;

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region
            if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
            {
                Response.Redirect("~/SessionExpire.aspx");
            }
            #endregion

            if (this.PreviousPage != null)
            {
                TextBox txtBookID = PreviousPage.Master.FindControl("ContentBody").FindControl("txtBookID") as TextBox;
                DropDownList ddlSignature = PreviousPage.Master.FindControl("ContentBody").FindControl("ddlSignature") as DropDownList;
                TextBox TextBoxYourName = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxYourName") as TextBox;
                TextBox TextBoxRemarks = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxRemarks") as TextBox;

                TextBox TextBoxName1 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxName1") as TextBox;
                TextBox TextBoxName2 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxName2") as TextBox;
                TextBox TextBoxName3 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxName3") as TextBox;
                TextBox TextBoxName4 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxName4") as TextBox;
                TextBox TextBoxName5 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxName5") as TextBox;

                TextBox TextBoxEmail1 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxEmail1") as TextBox;
                TextBox TextBoxEmail2 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxEmail2") as TextBox;
                TextBox TextBoxEmail3 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxEmail3") as TextBox;
                TextBox TextBoxEmail4 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxEmail4") as TextBox;
                TextBox TextBoxEmail5 = PreviousPage.Master.FindControl("ContentBody").FindControl("TextBoxEmail5") as TextBox;

                lbl_SenderName.Text = "<b>Hi " + TextBoxName1.Text + "</b>,";
                lbl_EmailCompliment.Text = ddlSignature.SelectedValue + ",";
                lbl_EmailSenderName.Text = "<b>" + TextBoxYourName.Text + "</b>";
                lblRemark.Text = TextBoxRemarks.Text;

                ViewState["BookID"] = txtBookID.Text.ToUpper();

                GetEBookKeywordBookInfo();
            }
        }
    }
    protected void GetEBookKeywordBookInfo()
    {

        ds = objBALebook.Ebook_RetrieveDetails(ViewState["BookID"].ToString(), Convert.ToInt32(Session["UserID"].ToString()), Session["MobileLoginID"].ToString().Replace("EB", ""));

        if (ds.Tables[0].Rows.Count > 0)
        {
            //Label Assignation
            //Response.Write(Session["UserID"].ToString());
            String tmpDomainUrl = Session["UserDomainURL"].ToString().Replace("http://", "");
            Header_Title.Text = "The Premier eBook Store";
            SubHeader_Title.Text = tmpDomainUrl;

            DataRow utRow1 = ds.Tables[0].Rows[0];

            String tmpBFree = utRow1["BFree"].ToString();
            String tmpBSeller = utRow1["BSeller"].ToString();
            String tmpBFeature = utRow1["BFeature"].ToString();
            String tmpBNew = utRow1["BNew"].ToString();
            String tmpBValueBuy = utRow1["BValueBuy"].ToString();

            DataRow utRow2;

            String tmpBookCount = String.Empty;
            String tmpCurrency = String.Empty;
            String tmpBookPrice = String.Empty;
            String tmpBookDiscountPrice = String.Empty;
            String tmpBookDesc = String.Empty;

            if (ds.Tables[1].Rows.Count > 0)
            {
                utRow2 = ds.Tables[1].Rows[0];

                tmpCurrency = utRow2["Denom"].ToString();
                tmpBookPrice = String.Format("{0:n2}", Convert.ToDecimal(utRow2["BookPrice"].ToString()));
                tmpBookDiscountPrice = String.Format("{0:n2}", Convert.ToDecimal(utRow2["BookDiscountedPrice"].ToString()));
                tmpBookDesc = utRow2["Description"].ToString();

                lblBookID.Text = utRow2["BookID"].ToString();
                lblBookName.Text = utRow2["BookName"].ToString();
                

                DateTime dDate = Convert.ToDateTime(utRow2["DateCreated"].ToString());
                lblDateAdded.Text = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dDate);
                lblNCurrencyPrice.Text = lblNDiscountPrice.Text = tmpCurrency;

                lblOrgPrice.Text = tmpBookPrice;
                lblAfterDiscount.Text = tmpBookDiscountPrice;

                if (tmpBValueBuy != "0")
                {
                    tmpBookCount = utRow2["BooksCount"].ToString();
                    lblBookCount.Text = tmpBookCount;
                    BookName1.Text = utRow2["Book1Name"].ToString();
                    BookName2.Text = utRow2["Book2Name"].ToString();
                    BookName3.Text = utRow2["Book3Name"].ToString();
                    BookName4.Text = utRow2["Book4Name"].ToString();
                    BookName5.Text = utRow2["Book5Name"].ToString();

                    ImageBook1.ImageUrl = Session["UserDomainURL"].ToString()+ "/" + utRow2["Book1ImageFileFullURL"].ToString();
                    ImageBook2.ImageUrl = Session["UserDomainURL"].ToString()+ "/" + utRow2["Book2ImageFileFullURL"].ToString();
                    ImageBook3.ImageUrl = Session["UserDomainURL"].ToString()+ "/" + utRow2["Book3ImageFileFullURL"].ToString();
                    ImageBook4.ImageUrl = Session["UserDomainURL"].ToString()+ "/" + utRow2["Book4ImageFileFullURL"].ToString();
                    ImageBook5.ImageUrl = Session["UserDomainURL"].ToString()+ "/" + utRow2["Book5ImageFileFullURL"].ToString();

                    if (BookName1.Text == "")
                        dvBook1.Visible = false;
                    if (BookName2.Text == "")
                        dvBook2.Visible = false;
                    if (BookName3.Text == "")
                        dvBook3.Visible = false;
                    if (BookName4.Text == "")
                        dvBook4.Visible = false;
                    if (BookName5.Text == "")
                        dvBook5.Visible = false;                   
                }                
            }
            String tmpHeader_BookType = String.Empty;
            String tmpSubHeader_BookType = String.Empty;
            String tmpSender_Message = String.Empty;
            
            tmpHeader_BookType = "Value-Buy eBooks Promotion!";
            tmpSubHeader_BookType = "Get <font color='red' size='+2'><b>" + tmpBookCount + "</b></font> eBooks for the Price of 1?? Only at <b> " + tmpDomainUrl + " </b>!!";
            tmpSender_Message = "Do not miss many more interesting ebooks that are on sale at  " + tmpDomainUrl + " , check them out today!Best of all, all ebooks in my store are sold at one <b><font color='red'>Flat Price of " + tmpCurrency + " " + tmpBookDiscountPrice + "</font></b> each for SMS purchase.  ";
            
            lblHeader_BookType.Text = tmpHeader_BookType;
            lblSubHeader_BookType.Text = tmpSubHeader_BookType;
            lbl_SenderMessage.Text = tmpSender_Message;

            DataSet dsBook = objBALebook.Ebook_KeywordDetails_ByUserID(Convert.ToInt32(Session["UserID"].ToString()));

            if (dsBook.Tables[0].Rows.Count > 0)
            {
                DataRow utKey = dsBook.Tables[0].Rows[0];
                if (tmpBFree == "0")
                {
                    lblBookPurchase_Format.Text = utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " YourEmail YourName";
                    lblSMS_Format.Text = utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " JohnWoo@yahoo.com John Woo ";
                    lblSend_SCode.Text = "SEND to 32828";
                    lblBookPurchase_Price.Text = "<b>NOTE:-&nbsp;</b> <font color='#85335C'>RM " + Convert.ToDecimal(utKey["Price"].ToString()) / 100 + "</font> &nbsp;per sms received.";
                }
                else
                {
                    lblBookPurchase_Format.Text = "FREE " + utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " YourEmail YourName";
                    lblSMS_Format.Text = "FREE " + utKey["vendorCode"].ToString() + "&nbsp;" + ViewState["BookID"].ToString() + " JohnWoo@yahoo.com John Woo ";
                    lblSend_SCode.Text = "Send To      1) +60146367111   2) +447860034140   3) +6281297978822";
                    lblBookPurchase_Price.Text = "";
                }


                if (dsBook.Tables[1].Rows.Count > 0)
                {
                    DataRow utAccess = dsBook.Tables[1].Rows[0];

                    if (utAccess[0].ToString() == "0")
                    {
                        divSMSCode.Visible = false;
                    }

                    if (utAccess[1].ToString() == "0")
                    {
                        tr_PurchasePaypal.Visible = false;
                    }
                }

            }
        }

    }

}
