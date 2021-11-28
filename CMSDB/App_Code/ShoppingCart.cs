using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

/// <summary>
/// Summary description for ShoppingCart
/// </summary>
public class ShoppingCart
{
    public static DataTable Basket_DataTable = null;

	public ShoppingCart()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static void AddCartItem(CMSv3.Entities.CartItems CartItems)
    {

        if (HttpContext.Current.Session["basket"] != null)
            ///read Basket_DataTable from session if exist
            Basket_DataTable = (DataTable)HttpContext.Current.Session["basket"];
        else
        {
            //create an empty DataTable and Add some columns to it
            Basket_DataTable = new DataTable();
            Basket_DataTable.Columns.Add("id");
            Basket_DataTable.Columns.Add("name");
            Basket_DataTable.Columns.Add("price");
            Basket_DataTable.Columns.Add("currency");
            Basket_DataTable.Columns.Add("ImageURL");
            Basket_DataTable.Columns.Add("count");
            Basket_DataTable.Columns.Add("total");
        }


        string tmpBookID = CartItems.BookID;

        if (tmpBookID != null)
        {
            
            bool Found = false;
            decimal tmpTotalAmount = 0; 
            for (int i = 0; i < Basket_DataTable.Rows.Count; i++)
            {
                //search item in DataTable
                if (Basket_DataTable.Rows[i][0].ToString() == tmpBookID)
                    Found = true;

                //..calculate the total amount
                tmpTotalAmount = tmpTotalAmount + Convert.ToDecimal(Basket_DataTable.Rows[i][2]); 

            }


            //String tmpCurrency = "RM";


            String vCurrency = string.Empty;

            if (HttpContext.Current.Session["UserCurrency"] != null)
                vCurrency = HttpContext.Current.Session["UserCurrency"].ToString();
            else
                vCurrency = "";



            int tmpCount = Basket_DataTable.Rows.Count; 


            //add to basket
            if (Found == false)
            {
                tmpCount = tmpCount + 1; 
                tmpTotalAmount = tmpTotalAmount + CartItems.Price;
                Basket_DataTable.Rows.Add(new object[] { CartItems.BookID, CartItems.BookName, CartItems.Price, vCurrency, CartItems.ImageURL, tmpCount, tmpTotalAmount });

            }
        }


        HttpContext.Current.Session["basket"] = Basket_DataTable;



    }

}