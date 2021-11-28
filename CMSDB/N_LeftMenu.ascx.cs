using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class N_LeftMenu : System.Web.UI.UserControl
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
        Load_HP_Categories(vUserID, "2222");
    }

    protected void Load_HP_Categories(int vUserId, String vUserType)
    {
        //.......... LOADING user Categories 

        if (vUserType == "ADMIN")
            ds = objBALebook.Category_HP_Listing_ByAdminID(vUserId, "");
        else if (vUserType == "2222")
            ds = objBALebook.Category_HP_Listing_ByUserID(vUserId, "2222");
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
        else if (vUserType == "2222")
        {
            dvFranchise.InnerHtml = sbCats.ToString();
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
        sb.AppendLine("<span class='list-group-item active'>" + vMainCatName + "<span class='pull-right' id='slide-submenu'><i class='fa fa-chevron-down'></i></span></span>");
        sb.AppendLine("<br/>");
        foreach (DataRow cRow in dtCats)
        {
            tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
            //if (tmpCatID == qCatID)
            //{
            //    tmpCatItem = "<a class='list-group-item' href='N_List.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CategoryName"].ToString() + " <span class='badge'>" + cRow["Bookscount"].ToString() + "</span> </a>";
            //}
            //else
            //{
            //    tmpCatItem = "<a class='list-group-item' href='N_List.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CategoryName"].ToString() + " <span class='badge'>" + cRow["Bookscount"].ToString() + "</span> </a>";    
            //}
            if (tmpCatID == qCatID)
            {
                tmpCatItem = "<a class='list-group-item' href='N_List.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CategoryName"].ToString() + "</a>";
            }
            else
            {
                tmpCatItem = "<a class='list-group-item' href='N_List.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CategoryName"].ToString() + "</a>";
            }
            sb.AppendLine(tmpCatItem);
        }
        return (sb.ToString());
    }

}