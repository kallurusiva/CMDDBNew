using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eBookBasketBar : System.Web.UI.UserControl
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["ClientID"].ToString() == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 



        #region ... Getting UserCurrency

        if (Session["UserCurrency"] != null)
        {

            lblCurrency.Text = Session["UserCurrency"].ToString();
        }
        else
        {

            //Get the User currency. 
            CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
            DataSet ds = objEbook.Ebook_KeywordDetails_ByUserID(Convert.ToInt32(Session["ClientID"]));

            if (ds.Tables[0].Rows.Count > 0)
            {

                DataRow krow = ds.Tables[0].Rows[0];

                Session["UserCurrency"] = krow["UserCurrency"].ToString();

            }


        }

        #endregion 

        if (HttpContext.Current.Session["basket"] != null)
        {
            DataTable Basket_DataTable = null;
            decimal tmpTotalAmount = 0;
            int tmpCount = 0; 
            
            ///read Basket_DataTable from session if exist
            Basket_DataTable = (DataTable)HttpContext.Current.Session["basket"];

            tmpCount = Basket_DataTable.Rows.Count; 

            for (int i = 0; i < Basket_DataTable.Rows.Count; i++)
            {
               
                //..calculate the total amount
                tmpTotalAmount = tmpTotalAmount + Convert.ToDecimal(Basket_DataTable.Rows[i][2]);

            }

            if (Session["UserCurrency"] != null)
                lblCurrency.Text = Session["UserCurrency"].ToString();
            else
                lblCurrency.Text = "USD"; 


            lblItemCount.Text = tmpCount.ToString();
            lblTotalAmount.Text = tmpTotalAmount.ToString();

            HypViewCart.NavigateUrl = "eBooksViewCart.aspx?CpUri=" + Request.Url.AbsoluteUri;

            HypCheckOut.NavigateUrl = "eBooksViewCart.aspx?CpUri=" + Request.Url.AbsoluteUri;
            //String vURL = "eBooksvCartConfirm.aspx";
            //HypCheckOut.NavigateUrl = vURL; 
            


        }
        else
        {
            HypViewCart.NavigateUrl = "Javascript: alert('No Items Added to cart yet')";

            HypCheckOut.NavigateUrl = "Javascript: alert('No Items Added to cart yet')";

        }



        


    }
}