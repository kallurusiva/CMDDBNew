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

public partial class N_TopMenu : System.Web.UI.UserControl
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
        DataTable tbHomePgContent = MainDS.Tables[1];

        string tmpCatstr = string.Empty;
        StringBuilder sbCats = new StringBuilder();

        string tmpCatItem = string.Empty;
        string tmpCatName = string.Empty;
        string tmpCatMainID = string.Empty;

        string tmpMasterfile = string.Empty;
        string tmpMasterCss = string.Empty;

        if (tbHomePgContent.Rows.Count > 0)
        {
            DataRow HpgRow = tbHomePgContent.Rows[0];
            string tmpLogoImage = HpgRow["LogoImg"].ToString();

            if (tmpLogoImage.Substring(0, 8) == "LogoTemp")
            {
                string tmpCompanyName = HpgRow["CompanyName"].ToString();
                string tmpLogoHtml = "<img alt='logo img' width='200' height='200' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                string tmpLogoHtml2 = "<img alt='logo img' width='200' height='200' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                dvLogo.InnerHtml = tmpLogoHtml2;
            }
            else
            {
                string tmpLogoHtml2 = "<img alt='logo img' width='200' height='200' src='" + @"ImageRepository/" + HpgRow["LogoImg"].ToString() + "' />";
                dvLogo.InnerHtml = tmpLogoHtml2;
            }

            if (HpgRow["BannerImg"].ToString().Contains(".swf"))
            {
                dvBanner.InnerHtml = "<object width='1000' height='200'><param name='movie' value='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "'><embed src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' width='820' height='200'></embed></object>";
            }
            else
            {
                dvBanner.InnerHtml = "<img alt='banner image' width='1000' height='200' src='" + @"ImageRepository/" + HpgRow["BannerImg"].ToString() + "' />";
            }
        }


        SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();
        SqlCommand dbCmd = new SqlCommand("usp_Retreive_UserMasterPageAndCss", dbConn);
        dbCmd.CommandType = CommandType.StoredProcedure;
        dbCmd.Parameters.Add("@vUserID", SqlDbType.BigInt).Value = Convert.ToInt32(Session["ClientID"]);
        SqlDataReader dbReader;
        dbReader = dbCmd.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                tmpMasterfile = dbReader["MasterPageName"].ToString();
                tmpMasterCss = dbReader["MasterCSS"].ToString();
            }
        }

        dbConn.Close();

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<ul class='nav navbar-nav'>");

        if (tbMenu.Rows.Count > 0)
        {
            string PageValName = string.Empty;
            DataRow tRows = (DataRow)tbMenu.Rows[0];
            foreach (DataRow cRow in tbMenu.Rows)
            {
                PageValName = "";
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "HOME")
                {
                    if (tmpMasterfile == "N_Master.master" || tmpMasterfile == "TmpMasterGen1.master")
                    {
                        PageValName = "N_Main.aspx";
                    }
                    else if (tmpMasterfile == "N_Master2.master" || tmpMasterfile == "TmpMasterGen2.master")
                    {
                        PageValName = "N_Main2.aspx";
                    }
                    else if (tmpMasterfile == "N_Master3.master" || tmpMasterfile == "TmpMasterGen3.master")
                    {
                        PageValName = "N_Main3.aspx";
                    } 
                    else
                    {
                        PageValName = "N_Main.aspx";
                    }                    
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "FEATUREBUY")
                {
                    PageValName = "N_FeatureBuy.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "NEWRELEASES")
                {
                    PageValName = "N_NewReleases.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "BESTSELLER")
                {
                    PageValName = "N_BestSeller.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "FREE")
                {
                    PageValName = "N_Free.aspx";
                }
                if (cRow["LinkName"].ToString().ToUpper().Trim() == "VALUEBUY")
                {
                    PageValName = "N_ValueBuy.aspx";
                }
                if (PageValName.ToString() == "")
                {
                    sb.AppendLine("<li><a href='" + cRow["LinkURL2"].ToString().Replace("UsersOwnPage", "N_usersownpage").Replace("numerology", "N_Numerology") + "'>" + cRow["LinkName"].ToString() + "</a></li>");
                }
                else
                {
                    sb.AppendLine("<li><a href='" + PageValName.ToString() + "'>" + cRow["LinkName"].ToString() + "</a></li>");
                }
            }
        }
        sb.AppendLine("</ul>");
        dvUserCategories.InnerHtml = sb.ToString();
    }
}