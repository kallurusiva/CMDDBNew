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

public partial class Admin_EBAd_PhysicalBookPurchaseDone : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //string ebookCode = Request.Form["cpCode"].ToString();
        //string booksize = Request.Form["cpSize"].ToString();
        //string bookunits = Request.Form["cpUnits"].ToString();
        //string bookpages = Request.Form["cpPages"].ToString();

        string ebookCode = Convert.ToString((TextBox)PreviousPage.FindControl("txtCode.Text"));


            //newDBS objNewDB = new newDBS();
            //DataSet ds = objNewDB.EBook_getPhysicalBookDetails(Session["LoginID"].ToString(), ebookCode.ToString(), booksize.ToString(), bookunits.ToString(), bookpages.ToString());
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DataRow utRow = ds.Tables[0].Rows[0];
        //txtCode.Text = ebookCode.ToString();
            //    txtSize.Text = booksize.ToString();
            //    txtCode.Text = bookunits.ToString();
            //    txtPages.Text = bookpages.ToString();
            //    txtPrice.Text = utRow["booksPrice"].ToString();
            //    lblHandlingPrice.Text = utRow["handlingfees"].ToString();
            //    lblShippingFees.Text = utRow["shippingfees"].ToString();
            //    lblTotal.Text = utRow["totalCharges"].ToString();
            //    lblMWallet.Text = utRow["mwalletBalance"].ToString();
            //}
        //}
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
}