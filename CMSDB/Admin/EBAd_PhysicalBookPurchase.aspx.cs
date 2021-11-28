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
using System.Net;
using System.Text;
using System.IO;

public partial class Admin_EBAd_PhysicalBookPurchase : System.Web.UI.Page
{
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
            newDBS objNewDB = new newDBS();
            DataSet ds = objNewDB.EBook_getPhysicalBookPages();
            txtPages.DataSource = ds;
            txtPages.DataTextField = "pages";
            txtPages.DataValueField = "bpages";
            txtPages.DataBind();
            LoadDetails("", "1", "1", "32");
        }
    }

    protected void txtUnits_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDetails(txtCode.Text.ToString(), txtSize.SelectedValue.ToString(), txtUnits.SelectedValue.ToString(), txtPages.SelectedValue.ToString());
    }

    protected void txtPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDetails(txtCode.Text.ToString(), txtSize.SelectedValue.ToString(), txtUnits.SelectedValue.ToString(), txtPages.SelectedValue.ToString());
    }

    protected void txtSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDetails(txtCode.Text.ToString(), txtSize.SelectedValue.ToString(), txtUnits.SelectedValue.ToString(), txtPages.SelectedValue.ToString());
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        newDBS objNewDBs = new newDBS();
        DataSet dss = objNewDBs.EBook_BuyPhysicalBookValidate(Session["LoginID"].ToString(), txtCode.Text.ToString(), txtSize.SelectedValue.ToString(), txtUnits.SelectedValue.ToString(), txtPages.SelectedValue.ToString(), txtShippingAddress.Text.ToString());
        if (dss.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = dss.Tables[0].Rows[0];
            string errorcode = utRow["errorCode"].ToString();
            string mwalletBalance = utRow["mwalletBalance"].ToString();
            string shippingfees = utRow["shippingfees"].ToString();
            string handlingfees = utRow["handlingfees"].ToString();
            string totalCharges = utRow["totalCharges"].ToString();
            string booksPrice = utRow["booksPrice"].ToString();
            string booktitle = utRow["BookTitle"].ToString();
            string bookURL = utRow["BookImageURL"].ToString();

            txtPrice.Text = booksPrice.ToString();
            lblHandlingPrice.Text = handlingfees.ToString();
            lblShippingFees.Text = shippingfees.ToString();
            lblTotal.Text = totalCharges.ToString();
            lblTitle.Text = booktitle.ToString();
            imgBook.Visible = true;
            imgBook.ImageUrl = "http://14.102.146.116/DocumentRepository/eBookImages/" + bookURL.ToString();

            if (errorcode.ToString() == "1") { CommonFunctions.AlertMessageAndRedirect("Book Code does not exists.", "EBAd_PhysicalBookPurchase.aspx"); }
            else if (errorcode.ToString() == "2") { CommonFunctions.AlertMessageAndRedirect("You must be the Author of the Book.", "EBAd_PhysicalBookPurchase.aspx"); }
            else if (errorcode.ToString() == "3") { CommonFunctions.AlertMessageAndRedirect("InSufficient Credit Balance to order. Current MWallet Balance: USD " + mwalletBalance.ToString(), "EBAd_PhysicalBookPurchase.aspx"); }

            if (errorcode.ToString() == "0")
            {
                btnSave.Visible = false;
                btnConfirm.Visible = true;
            }
        }        
    }

    protected void LoadDetails(string ecode, string esize, string eunits, string epages)
    {
        newDBS objNewDBs = new newDBS();
        DataSet dss = objNewDBs.EBook_getPhysicalBookDetails(Session["LoginID"].ToString(), ecode.ToString(), esize.ToString(), eunits.ToString(), epages.ToString());
        if (dss.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = dss.Tables[0].Rows[0];
            txtPrice.Text = utRow["booksPrice"].ToString();
            lblHandlingPrice.Text = utRow["handlingfees"].ToString();
            lblShippingFees.Text = utRow["shippingfees"].ToString();
            lblTotal.Text = utRow["totalCharges"].ToString();
            lblMWallet.Text = utRow["mwalletBalance"].ToString();

            if (Convert.ToDecimal(utRow["mwalletBalance"].ToString()) >= Convert.ToDecimal(utRow["totalCharges"].ToString()))
            {
                btnSave.Visible = true;
            }
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        newDBS objNewDBs = new newDBS();
        DataSet dss = objNewDBs.EBook_BuyPhysicalBook(Session["LoginID"].ToString(), txtCode.Text.ToString(), txtSize.SelectedValue.ToString(), txtUnits.SelectedValue.ToString(), txtPages.SelectedValue.ToString(), txtShippingAddress.Text.ToString());
        if (dss.Tables[0].Rows.Count > 0)
        {
            DataRow utRow = dss.Tables[0].Rows[0];
            string errorcode = utRow["errorCode"].ToString();
            string mwalletBalance = utRow["mwalletBalance"].ToString();

            if (errorcode.ToString() == "1") { CommonFunctions.AlertMessageAndRedirect("Book Code does not exists.", "EBAd_PhysicalBookPurchase.aspx"); }
            else if (errorcode.ToString() == "2") { CommonFunctions.AlertMessageAndRedirect("You must be the Author of the Book.", "EBAd_PhysicalBookPurchase.aspx"); }
            else if (errorcode.ToString() == "3") { CommonFunctions.AlertMessageAndRedirect("InSufficient Credit Balance to order. Current MWallet Balance: USD " + mwalletBalance.ToString(), "EBAd_PhysicalBookPurchase.aspx"); }
            else {
                HttpWebRequest WebReq = null;
                HttpWebResponse WebResp;
                String strSMSvalue = "";
                strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=49061723&message=" + Server.UrlEncode("Physical Book Order – Please look into it\n\nBook Code:" + txtCode.Text.ToString() + "\nBok Title:" + lblTitle.Text.ToString());
                WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);

                //WebReq.ClientCertificates.Add(Cert);
                WebReq.Method = "GET";
                WebResp = (HttpWebResponse)WebReq.GetResponse();
                if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                {
                    Stream _Answer = WebResp.GetResponseStream();
                    StreamReader Answer = new StreamReader(_Answer);
                    String strTemp = Answer.ReadToEnd();
                }
                strSMSvalue = "http://gt.evenchise.com/MessageBridge.aspx?chatid=78100762&message=" + Server.UrlEncode("Physical Book Order – Please look into it\n\nBook Code:" + txtCode.Text.ToString() + "\nBok Title:" + lblTitle.Text.ToString());
                WebReq = (HttpWebRequest)WebRequest.Create(strSMSvalue);

                //WebReq.ClientCertificates.Add(Cert);
                WebReq.Method = "GET";
                WebResp = (HttpWebResponse)WebReq.GetResponse();
                if (WebResp.StatusCode == HttpStatusCode.OK)    // 200
                {
                    Stream _Answer = WebResp.GetResponseStream();
                    StreamReader Answer = new StreamReader(_Answer);
                    String strTemp = Answer.ReadToEnd();
                }
                CommonFunctions.AlertMessageAndRedirect("Order Completed Successfully. Current MWallet Balance: USD " + mwalletBalance.ToString(), "EBAd_PhysicalBooksHistory.aspx"); 
            
            }
        }
    }

}