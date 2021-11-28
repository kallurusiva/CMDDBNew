using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ebLeftCategoriesTest : System.Web.UI.UserControl
{

    int qCatID = 0;
    String vCatSearch = string.Empty;

    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    DataSet ds;
    //DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {


        int vUserID = Convert.ToInt32(Session["ClientID"]);
        Load_HP_Categories(vUserID, "USER");
        Load_HP_Categories(vUserID, "ADMIN");

    }


    protected void Load_HP_Categories(int vUserId, String vUserType)
    {


        //.......... LOADING user Categories 

        if (vUserType == "ADMIN")
            ds = objBALebook.Category_HP_Listing_ByAdminID(vUserId, "");
        else
            ds = objBALebook.Category_HP_Listing_ByUserID(vUserId, "");

        DataTable dtMainCats = ds.Tables[0];
        DataTable dtSubCats = ds.Tables[1];



        string tmpCatstr = string.Empty;
        StringBuilder sbCats = new StringBuilder();

        string tmpCatItem = string.Empty;
        string tmpCatName = string.Empty;
        string tmpCatMainID = string.Empty;


        //User Categories 
        if (dtMainCats.Rows.Count > 0)
        {

            DataRow tRows = (DataRow)dtMainCats.Rows[0];

            foreach (DataRow cRow in dtMainCats.Rows)
            {

                tmpCatMainID = cRow["CatMainID"].ToString();
                tmpCatName = cRow["CategoryName"].ToString();
                tmpCatstr = string.Empty;

                //if (dtSubCats.Rows.Count > 0)
                //{

                DataView dvCats = dtSubCats.DefaultView; // dtSubCats.Select("CatMainID = " + tmpCatMainID); 
                dvCats.RowFilter = "CatMainID = " + tmpCatMainID;

                DataRow[] tmpRows = dtSubCats.Select("CatMainID = " + tmpCatMainID);
                if (tmpRows.Length > 0)
                {
                    tmpCatstr += GetSubCategory_DIV(tmpRows, tmpCatName);
                    tmpCatstr += "<br/>";
                }
                sbCats.AppendLine(tmpCatstr);
                //}


            }



        }
        else
        {
            // dvUserCategories.Visible = false;
        }



        if (vUserType == "ADMIN")
        {
            dvCategories.InnerHtml = sbCats.ToString();
        }
        else
        {
            dvUserCategories.InnerHtml = sbCats.ToString();
        }

        sbCats.Length = 0;
    }



    protected string GetSubCategory_DIV(DataRow[] dtCats, String vMainCatName)
    {
        string tmpCatItem = string.Empty;
        int tmpCatID = 0;

        StringBuilder sb = new StringBuilder();

        //sb.AppendLine("<div class='widget widget-category'>");
        sb.AppendLine("<h3 class='widget-title'>" + vMainCatName + "</h3>");
        sb.AppendLine("<br/>");
        sb.AppendLine("<ul class='category-list'>");

        //  DataRow tRows = (DataRow)dtCats.Rows[0];

        foreach (DataRow cRow in dtCats)
        {
            tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
            // qCatID = Convert.ToInt32(ViewState["qCatID"].ToString()); 

            if (tmpCatID == qCatID)
            {
                tmpCatItem = "<li><a href='ebookslist.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
            }
            else
            {
                tmpCatItem = "<li><a href='ebookslist.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
            }
            sb.AppendLine(tmpCatItem);
        }

        sb.AppendLine("</ul>");
        //sb.AppendLine("</div>");
        //dvUserCategories.InnerHtml = sb.ToString();

        return (sb.ToString());
    }
}