using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.Globalization;
using System.Threading;
using CMSv3.BAL;
using System.Data.SqlClient;
using System.IO;

public partial class O_topBlue : System.Web.UI.UserControl
{

    //int qCatID = 0;
    String vCatSearch = string.Empty;

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    //DataTable dt;
    DataSet ds1;
    //DataTable dt1;
    DataSet MainDS;

    protected void Page_Load(object sender, EventArgs e)
    {
        int vUserID = Convert.ToInt32(Session["ClientID"]);
        Load_HP_Categories(vUserID);
    }


    protected void Load_HP_Categories(int vUserId)
    {
        //.......... LOADING user Categories 
        
            ds = objBALebook.Category_HP_Listing_ByAdminID(vUserId, "");      
            ds1 = objBALebook.Category_HP_Listing_ByUserID(vUserId, "");
            CMSv3.BAL.HomePage objBAL_HomePg = new CMSv3.BAL.HomePage();
            MainDS = objBAL_HomePg.RetrieveAll_HomePageContent(Convert.ToInt32(Session["ClientID"]));

        DataTable dtMainCats = ds.Tables[0];
        DataTable dtMainCats1 = ds1.Tables[0];
        DataTable tbMenu = MainDS.Tables[0];

        string tmpCatstr = string.Empty;
        StringBuilder sbCats = new StringBuilder();

        string tmpCatItem = string.Empty;
        string tmpCatName = string.Empty;
        string tmpCatMainID = string.Empty;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<nav class='menu-wrapper sticky-header'>");
        sb.AppendLine("<div class='container-fluid' runat='server'>");
        sb.AppendLine("<ul class='menu'>");
        //sb.AppendLine("<li><a href='#'>Category</a>");
        //sb.AppendLine("<ul>");

        //if (dtMainCats.Rows.Count > 0)
        //{
        //    DataRow tRows = (DataRow)dtMainCats.Rows[0];
        //    foreach (DataRow cRow in dtMainCats.Rows)
        //    {
        //        sb.AppendLine("<li><a href='O_dtList.aspx?qCatId=" + cRow["CatMainID"].ToString() + "'>" + cRow["CategoryName"].ToString() + "</a></li>");
        //    }
        //}

        //if (dtMainCats1.Rows.Count > 0)
        //{
        //    DataRow tRows = (DataRow)dtMainCats1.Rows[0];
        //    foreach (DataRow cRow in dtMainCats1.Rows)
        //    {
        //        sb.AppendLine("<li><a href='O_dtList.aspx?qCatId=" + cRow["CatMainID"].ToString() + "'>" + cRow["CategoryName"].ToString() + "</a></li>");
        //    }
        //}

        //sb.AppendLine("</ul>");
        //sb.AppendLine("</li>");

        //Response.Write(Session["MasterPageFile"].ToString());
        //Response.End();

        if (tbMenu.Rows.Count > 0)
        {
            string PageValName = string.Empty;
            DataRow tRows = (DataRow)tbMenu.Rows[0];
            foreach (DataRow cRow in tbMenu.Rows)
            {
                PageValName = "";
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "HOME")
                {
                    if (Session["MasterPageFile"].ToString().ToUpper() == "O_MASTERNEW.MASTER")
                    {
                        PageValName = "O_dtNew.aspx";
                    }
                    else 
                    { 
                        PageValName = "O_dtBlue.aspx";
                    }
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "FEATUREBUY")
                {
                    PageValName = "O_dtFeatureBuy.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "NEWRELEASES")
                {
                    PageValName = "O_dtNewRelease.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "BESTSELLER")
                {
                    PageValName = "O_dtBestSeller.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "FREE")
                {
                    PageValName = "O_dtFree.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "VALUEBUY")
                {
                    PageValName = "O_dtValueBuy.aspx";
                }
                if (PageValName.ToString() == "")
                {
                    sb.AppendLine("<li class='visible-lg'><a href='" + cRow["LinkURL2"].ToString().Replace("UsersOwnPage", "O_dtusersownpage").Replace("numerology","O_dtNumerology") + "'><span>" + cRow["LinkName"].ToString() + "</a></li>");
                }
                else
                {
                    sb.AppendLine("<li class='visible-lg'><a href='" + PageValName.ToString() + "'><span>" + cRow["LinkName"].ToString() + "</a></li>");
                }                
            }
        }

        //sb.AppendLine("<li class='visible-lg'><a href='product_list.html'><span>Features Buy<span class='tip hot'>Hot</span></span></a></li>");
        //sb.AppendLine("<li class='visible-lg'><a href='product_list.html'><span>Best Seller<span class='tip hot'>Hot</span></span></a></li>");
        //sb.AppendLine("<li class='visible-lg'><a href='product_list.html'><span>New Release<span class='tip hot'>Hot</span></span></a></li>");
        //sb.AppendLine("<li class='visible-lg'><a href='product_list.html'><span>Value Buy<span class='tip hot'>Hot</span></span></a></li>");
        //sb.AppendLine("<li class='visible-lg'><a href='product_list.html'><span>Free<span class='tip hot'>Hot</span></span></a></li>");
        sb.AppendLine("</ul>");

        sb.AppendLine("<ul class='mobile-menu'>");
        if (tbMenu.Rows.Count > 0)
        {
            string PageValName = string.Empty;
            DataRow tRows = (DataRow)tbMenu.Rows[0];
            foreach (DataRow cRow in tbMenu.Rows)
            {
                PageValName = "";
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "HOME")
                {
                    if (Session["MasterPageFile"].ToString().ToUpper() == "O_MASTERNEW.MASTER")
                    {
                        PageValName = "O_dtNew.aspx";
                    }
                    else
                    {
                        PageValName = "O_dtBlue.aspx";
                    }
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "FEATUREBUY")
                {
                    PageValName = "O_dtFeatureBuy.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "NEWRELEASES")
                {
                    PageValName = "O_dtNewRelease.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "BESTSELLER")
                {
                    PageValName = "O_dtBestSeller.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "FREE")
                {
                    PageValName = "O_dtFree.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "VALUEBUY")
                {
                    PageValName = "O_dtValueBuy.aspx";
                }
                if (PageValName.ToString() == "")
                {
                    sb.AppendLine("<li><a href='" + cRow["LinkURL2"].ToString().Replace("UsersOwnPage", "O_dtusersownpage").Replace("numerology", "O_dtNumerology") + "'><span>" + cRow["LinkName"].ToString() + "</a></li>");
                }
                else
                {
                    sb.AppendLine("<li><a href='" + PageValName.ToString() + "'><span>" + cRow["LinkName"].ToString() + "</a></li>");
                }
            }
        }
        sb.AppendLine("</ul>");

        sb.AppendLine("</div>");
        sb.AppendLine("</li>");
        sb.AppendLine("</nav>");

        dvUserCategories.InnerHtml = sb.ToString();

    }


   


}