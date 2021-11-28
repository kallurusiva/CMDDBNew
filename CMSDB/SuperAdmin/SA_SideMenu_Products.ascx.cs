using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdmin_SA_SideMenu_Products : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LtrAddProduct.Text = Resources.LangResources.Add + " " + Resources.LangResources.Products;
        LtrMyProducts.Text = Resources.LangResources.Products + " " + Resources.LangResources.Listing;
        LtrManageProducts.Text = Resources.LangResources.Manage + " " + Resources.LangResources.Products;
            
        //LtrAdminNews.Text = "Admin " + Resources.LangResources.News;
        //LtrShowAll.Text = Resources.LangResources.Showall;

    }
}
