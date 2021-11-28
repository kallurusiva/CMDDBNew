using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class EBLeftMenu_Books : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        String Cpage = Request.RawUrl.ToLower();

        //if (Cpage.Contains("feature")) aEBFeatureBuy.Attributes.Add("class", "liActive");

        if (Cpage.Contains("feature")) 
        {

            liFeatureBuy.Visible = true; 
            
        }

        else if (Cpage.Contains("bestseller"))
        {
            liBestSeller.Visible = true;  
        }

        else if (Cpage.Contains("catalog"))
        {
            liEbookCatalog.Visible = true;  
        }
        else if (Cpage.Contains("valuebuy"))
        {
            liValueBuy.Visible = true;   
        }
          
    }
}
