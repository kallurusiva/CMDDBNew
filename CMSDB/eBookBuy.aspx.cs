using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using CMSv3.BAL;


public partial class eBookBuy : UserWeb
{

    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 
    DataSet ds;
    DataTable dt;
    int qCatID = 0;


    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = "~/UserEbookMaster.master";
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion 

        #region //rendering top left panel 

        if (!Session["MasterPageCss"].ToString().Contains("TmpStyleSheet")) 
        {

            HtmlGenericControl myDivObject;
            myDivObject = (HtmlGenericControl)Master.FindControl("dvBannerLeftPanel");

            //myDivObject.InnerHtml = " <asp:Image ID='ImbnLeft' runat='server' ImageUrl='~Images/login_sidehead.jpg' />";

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='dvBannerLeftPanel'>");
            sb.Append("<tr>");
            sb.Append("<td align='left' valign='top'>");
            sb.Append("<img src='Images/table_top_Leftarc.gif' />");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<img alt='imbnLeftimg' src='Images/testim_head.gif' />");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            myDivObject.InnerHtml = sb.ToString();

            //myDivObject.InnerHtml = "<table border='0' class='dvBannerLeftPanel'><tr><td><img alt='imbnLeftimg' src='Images/faq_head.jpg' /> </td></tr></table>";
        }
        #endregion 


          
        if (!IsPostBack)
        {


            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["qCatID"] != null)
                {
                    qCatID = Convert.ToInt32(Request.QueryString["qCatID"].ToString());

                }
            }
            ViewState["qCatID"] = qCatID; 


            int vUserId = Convert.ToInt32(Session["ClientID"]);
            LoadCategories(vUserId);
            LoadEbooks(vUserId);

        }


    }


    protected void LoadEbooks(int vUserId)
    {

        DataSet ds2;
        //vUserId = 7702;
        ds2 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserId);

        ViewState["vEbUserKeyword"] = "";
        ViewState["vEbUserPackageType"] = "";
        ViewState["vEbUserType"] = "";

        if (ds2.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds2.Tables[0].Rows[0];

            ViewState["vEbUserKeyword"] = krow["VendorCode"].ToString();
            ViewState["vEbUserPackageType"] = Convert.ToInt32(krow["PackageType"].ToString());
            ViewState["vEbUserType"] = krow["ebUserType"].ToString();



        }


        //ds = objBALebook.Ebook_Listing_ByUserID(vUserId, " AND isfeatured = 1");
        ds = objBALebook.Ebook_FeatureBuyListing_ByUserID(vUserId, ""); 
        dt = ds.Tables[0];
        
        string tmpstr = string.Empty;

        if (dt.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dt.Rows[0];

            RepBooks.DataSource = ds;
            RepBooks.DataBind(); 

        }
        
       


    }

    protected void LoadCategories(int vUserId)
    {


        ds = objBALebook.Category_Listing_ByUserID(vUserId, "");
        DataTable dtUserCats = ds.Tables[0];
        DataTable dtAdminCats = ds.Tables[1];


        string tmpstr = string.Empty;

        StringBuilder sbCats = new StringBuilder();




        string tmpCatItem = string.Empty;
        int tmpCatID = 0;

        if (dtUserCats.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dtUserCats.Rows[0];

            sbCats.AppendLine("<h2>My Categories</h2>");
            sbCats.AppendLine("<div class='menu_simple'>");
            sbCats.AppendLine("<br/>");
            sbCats.AppendLine("<ul>");


            foreach (DataRow cRow in dtUserCats.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                // qCatID = Convert.ToInt32(ViewState["qCatID"].ToString()); 

                if (tmpCatID == qCatID)
                {
                    tmpCatItem = "<li><a class='current' href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                else
                {
                    tmpCatItem = "<li><a href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                sbCats.AppendLine(tmpCatItem);
            }

            sbCats.AppendLine("</ul>");
            sbCats.AppendLine("</div>");


        }
        else
        {


        }


        if (dtAdminCats.Rows.Count > 0)
        {

            sbCats.AppendLine("<div class='menu_simple'>");
            // sbCats.AppendLine("<span class='eb_head2'>Categories</span>");
            sbCats.AppendLine("<h2>Categories</h2>");
            sbCats.AppendLine("<br/>");
            sbCats.AppendLine("<ul>");

            DataRow tRows = (DataRow)dtAdminCats.Rows[0];

            foreach (DataRow cRow in dtAdminCats.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                // qCatID = Convert.ToInt32(ViewState["qCatID"].ToString()); 

                if (tmpCatID == qCatID)
                {
                    tmpCatItem = "<li><a class='current' href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                else
                {
                    tmpCatItem = "<li><a href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                sbCats.AppendLine(tmpCatItem);
            }

            sbCats.AppendLine("</ul>");
            sbCats.AppendLine("</div>");

        }






        dvLeftContent.InnerHtml = sbCats.ToString();


    }


    protected void LoadCategories22(int vUserId)
    {


        ds = objBALebook.Category_Listing_ByUserID(vUserId, "");
        dt = ds.Tables[0];

        string tmpstr = string.Empty;

        StringBuilder sbCats = new StringBuilder();

        sbCats.AppendLine("<h2>Categories</h2>");
        sbCats.AppendLine("<div class='menu_simple'>");
        //sbCats.AppendLine("<span class='eb_head2'>Categories</span>");
       
        sbCats.AppendLine("<br/>"); 
        sbCats.AppendLine("<ul>");


       
        string tmpCatItem = string.Empty;
        int tmpCatID = 0; 

        if (dt.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dt.Rows[0];

            //foreach(DataRow cRow in dt.Rows)
            //{

            //    tmpCatItem = "<li><a ref='#'>" + cRow["CatBooks"].ToString() + "</a></li>";
            //    sbCats.AppendLine(tmpCatItem);
            //}

            foreach (DataRow cRow in dt.Rows)
            {

                tmpCatID = Convert.ToInt32(cRow["CatID"].ToString());
                // qCatID = Convert.ToInt32(ViewState["qCatID"].ToString()); 

                if (tmpCatID == qCatID)
                {
                    tmpCatItem = "<li><a class='current' href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                else
                {
                    tmpCatItem = "<li><a href='eBooksList.aspx?qCatId=" + cRow["CatID"].ToString() + "'>" + cRow["CatBooks"].ToString() + "</a></li>";
                }
                sbCats.AppendLine(tmpCatItem);
            }


        }


        sbCats.AppendLine("</ul>");
        sbCats.AppendLine("</div>");


        dvLeftContent.InnerHtml = sbCats.ToString(); 


    }


    protected void RepBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            string strPurchaseFormat = string.Empty;

            StringBuilder sp = new StringBuilder();


            HtmlGenericControl objDvPurchase = (HtmlGenericControl)e.Item.FindControl("dvBookPurchaseFormat");


            Label objlblPurFormat = (Label)e.Item.FindControl("lblPurFormat");
            Label objlblBookID = (Label)e.Item.FindControl("lblBookID");

            string tmpPKGtype = ViewState["vEbUserPackageType"].ToString();
            string tmpKeyword = ViewState["vEbUserKeyword"].ToString(); 

            //if (tmpPKGtype == "2")
            if (tmpKeyword != "")
            {

                objDvPurchase.Visible = true;
                objlblPurFormat.Text = ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  YourEmail  YourName";

                Label objlblPurchaseNote = (Label)e.Item.FindControl("lblPurchaseNote"); 

                if(objlblPurchaseNote != null)
                    objlblPurchaseNote.Text = "<b>NOTE:- </b> RM 5.00 per sms received. Eg. " + ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";

            }




        }


    }


    protected void ImgPayPalBuyBtn_Click(object sender, CommandEventArgs e)
    {

        string s = e.CommandArgument.ToString();
        String tBookID = string.Empty;
        String tBookPrice = string.Empty;


        string[] strInfo = s.Split(',');

        for (int i = 0; i < strInfo.Length; i++)
        {
            tBookID = strInfo[0];
            tBookPrice = strInfo[1];
        }



        HttpContext.Current.Response.Clear();
        StringBuilder sb = new StringBuilder();

        String strURL = "http://183.81.165.110/WebApps/GsPayPal/Wsp_PayPalCall.aspx";


        String cpSuccessURLDP = "http://210.5.45.8/EbookBuySuccess.aspx";
        String cpCancelURLDP = "http://210.5.45.8/EbookBuyCancel.aspx";
        String cpFailureURLDP = "http://210.5.45.8/EbookBuyFailure.aspx";
         int vUserId = Convert.ToInt32(Session["ClientID"]);

        //..Get Book and User Details. 

        cpFullName.Value = "SRI HARI MOOTA";
        cpAmount.Value = "5.00";
        cpCurrencyCode.Value = "MYR";
        cpMobileNo.Value = "60149664566";
        cpItemName.Value = "My Book Name";
        cpCustomText.Value = vUserId.ToString() + "#";
        cpItemNumber.Value = tBookID;
        cpUniqueID.Value = vUserId.ToString();
        cpWebSiteName.Value = "www.worldDigitalBiz.com";
        cpUserID.Value = vUserId.ToString();
        cpSkipTAC.Value = "TRUE"; 



        sb.Append("<html>");
        sb.AppendFormat(@"<body onload='document.forms[0].submit()'>");
        sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);

        // Start Collecting Parameters

        sb.AppendFormat("<input type='hidden' name='cpFullName' value='{0}'>", cpFullName.Value);
        sb.AppendFormat("<input type='hidden' name='cpAmount' value='{0}'>", cpAmount.Value);
        sb.AppendFormat("<input type='hidden' name='cpCurrencyCode' value='{0}'>", cpCurrencyCode.Value);
        sb.AppendFormat("<input type='hidden' name='cpMobileNo' value='{0}'>", cpMobileNo.Value);
        sb.AppendFormat("<input type='hidden' name='cpItemName' value='{0}'>", cpItemName.Value);
        sb.AppendFormat("<input type='hidden' name='cpCustomText' value='{0}'>", cpCustomText.Value);
        sb.AppendFormat("<input type='hidden' name='cpItemNumber' value='{0}'>", cpItemNumber.Value);
        sb.AppendFormat("<input type='hidden' name='cpUniqueID' value='{0}'>", cpUniqueID.Value);
        sb.AppendFormat("<input type='hidden' name='cpWebSiteName' value='{0}'>", cpWebSiteName.Value);
        sb.AppendFormat("<input type='hidden' name='cpUserID' value='{0}'>", cpUserID.Value);
        sb.AppendFormat("<input type='hidden' name='cpSuccessURL' value='{0}'>", cpSuccessURLDP);
        sb.AppendFormat("<input type='hidden' name='cpCancelURL' value='{0}'>", cpCancelURLDP);
        sb.AppendFormat("<input type='hidden' name='cpFailureURL' value='{0}'>", cpFailureURLDP);
        sb.AppendFormat("<input type='hidden' name='cpSkipTAC' value='{0}'>", cpSkipTAC.Value);

        // End

        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");

        HttpContext.Current.Response.Write(sb.ToString());
        //HttpContext.Current.Response.End();
        HttpContext.Current.ApplicationInstance.CompleteRequest();

    }
}




