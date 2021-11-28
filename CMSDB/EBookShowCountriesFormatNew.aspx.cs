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
using System.Net;

public partial class EBookShowCountriesFormatNew : System.Web.UI.Page
{


    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    //DataSet ds;
    //DataTable dt;
    String qBookID = "0";
    string ctryVal = string.Empty;
    bool ShowSMSpurchase = false;
    string appendMessageMY = string.Empty;

    protected void Page_PreInit(object sender, EventArgs e)
    {
        this.Page.MasterPageFile = "";
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["ClientID"] == null) || (Session["ClientID"].ToString() == ""))
        {
            Response.Redirect("~/Default.aspx");
        }
        #endregion

       

        if (!IsPostBack)
        {

            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["qBookID"] != null)
                {
                    qBookID = Request.QueryString["qBookID"].ToString();

                }
            }
            ViewState["qBookID"] = qBookID;

            if (Session["ipCtry"] == null)
            {
                Session["ipCtry"] = "";
            }
            if (Session["ipCtry"].ToString() == "")
            {
                Session["ipCtry"] = MyGeoLocation.GetCountryCodeFromIP(); ;
            }
            ctryVal = Session["ipCtry"].ToString();

           

            newDBS ndbsMY = new newDBS();
            DataSet dstMY = ndbsMY.ebook_getKeywordDetails_CountryWise(ctryVal);

            if (dstMY.Tables[0].Rows.Count > 0)
            {
                DataRow nrow = dstMY.Tables[0].Rows[0];

                appendMessageMY = nrow["displayNote"].ToString();
            }
            else
            {
                appendMessageMY = "";
            }

            //ctryVal = MyGeoLocation.GetCountryCodeFromIP();
            if (ctryVal == "MY")
            {
                ShowSMSpurchase = MyGeoLocation.isSMSPurchaseOpenForCountry("MY");  //Malaysia : MY
            }
            if (ctryVal != "MY")
            {
                ShowSMSpurchase = true;  //USA : US
            }           

            int vUserId = Convert.ToInt32(Session["ClientID"]);
            // LoadCategories(vUserId);

            //string ipVal = MyGeoLocation.GetUserIP();
            //string ctryVal = MyGeoLocation.GetCountryCodeFromIP();
            //Response.Write(ipVal + "-" + ctryVal + "-" + vUserId);
            LoadEbook(qBookID, vUserId);
        }

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

                if (objlblPurchaseNote != null)
                    objlblPurchaseNote.Text = "<b>NOTE:- </b> RM 5.00 per sms received. Eg. " + ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";

            }

        }

    }

    protected void LoadEbook(string qBookID, int vUserID)
    {
        string tmpKeyword = string.Empty;
        int tmpPKGtype = 0;
        String tmpUserType = string.Empty;
        String tmpBookPrice = string.Empty;
        String tmpUserCurrency = string.Empty;
        String tmpEstoreID = string.Empty;

        DataSet ds2;
        //vUserId = 7702;
        ds2 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserID);

        if (ds2.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds2.Tables[0].Rows[0];

            tmpKeyword = krow["VendorCode"].ToString();
            tmpPKGtype = Convert.ToInt32(krow["PackageType"].ToString());
            tmpUserType = krow["ebUserType"].ToString();
            tmpBookPrice = krow["Price"].ToString();
            tmpUserCurrency = krow["UserCurrency"].ToString();

            tmpEstoreID = krow["eStoreID"].ToString();


            if (tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice) / 100;
                tmpBookPrice = "RM " + String.Format("{0:n2}", vPrice.ToString()) + "(Excl.GST)";

            }
        }

        ViewState["vAllowPayPalBuy"] = "";
        ViewState["vAllowSMSBuy"] = "";
        DataTable dtAllowSettings = ds2.Tables[1];
        if (dtAllowSettings.Rows.Count > 0)
        {
            DataRow Srow = dtAllowSettings.Rows[0];

            ViewState["vAllowPayPalBuy"] = Srow["AllowPayPalBuy"].ToString();
            ViewState["vAllowSMSBuy"] = Srow["AllowSMSBuy"].ToString();
        }


        String tmpAllowSmsPurchase = ViewState["vAllowSMSBuy"].ToString().ToUpper();
        if (!ShowSMSpurchase)
            tmpAllowSmsPurchase = "FALSE";

        string tmpstr = string.Empty;

        DataSet ds;
        ds = objBALebook.Ebook_GetBookDetails(qBookID, vUserID);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];

            DataRow dr = dt.Rows[0];

            lblBookID.Text = dr["BookID"].ToString();
            lblBookName.Text = dr["BookNAme"].ToString();
            lblCategory.Text = dr["CategoryName"].ToString();
            // lblDateAdded.Text = String.Format("{0:MMMM d, yyyy}", Convert.ToDecimal(dr["DateCreated"].ToString())); ; // dr["DateCreated"].ToString();

            DateTime dNewDate = Convert.ToDateTime(dr["DateCreated"].ToString());
            String strNewDate = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dNewDate);
            lblDateAdded.Text = strNewDate;

            lbluCurrency1.Text = dr["UserCurrency"].ToString(); ;
            lbluCurrency2.Text = dr["UserCurrency"].ToString(); ;


            lblOrgPrice.Text = String.Format("{0:n2}", Convert.ToDecimal(dr["Price"].ToString()));
            lblAfterDiscount.Text = String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString()));
            lblPrepaidValue.Text = dr["PrepaidPrice"].ToString();

            //String.Format("{0:n2}", Convert.ToDecimal(tBookPriceCancel))
            ImgEbook.ImageUrl = dr["ImageFileFullURL"].ToString();


            String tmpTitle = dr["Title"].ToString();
            String tmpDescription = dr["Description"].ToString();

            int vLaunchStatus = Convert.ToInt16(dr["LaunchStatus"].ToString());
            int isFreeBook = Convert.ToInt16(dr["isFreeBook"].ToString());


            String BookAllowSmsBuy = dr["AllowSMSbuy"].ToString();
            String BookAllowPayPalBuy = dr["AllowPaypalBuy"].ToString();


            if (BookAllowSmsBuy.ToUpper() == "FALSE")
                tmpAllowSmsPurchase = "FALSE";


            tmpDescription = tmpDescription.Replace(Environment.NewLine, "<br/>");
            tmpDescription = "<p class='BkfontDescription'>" + tmpDescription + "</p>";

            if (tmpTitle == "")
                tmpTitle = "";
            else
                tmpTitle = "<p class='BkfontTitle'>" + tmpTitle + "</p>";


            string tmpImagePath = Page.ResolveUrl(ImgEbook.ImageUrl);

            newDBS ndbs = new newDBS();
            DataSet dst = ndbs.ebook_getKeywordDetails_AllCountries(Session["ClientID"].ToString(), qBookID);

            if (dst.Tables[0].Rows.Count > 0)
            {
                DataRow nrow = dst.Tables[0].Rows[0];
                if (nrow["countryName"].ToString() != null)
                {
                    dvBookPurchaseFormat.Visible = true;
                    string ctryName = nrow["countryName"].ToString();
                    string ctryCurrency = nrow["currencyName"].ToString();
                    string ctryPriceTag = nrow["PriceTag"].ToString();
                    string ctryShortcode = nrow["shortcode"].ToString();
                    string ctryNote = nrow["displayNote"].ToString();
                    string ctryKeyword = nrow["Keyword"].ToString();
                    string ctrySendTo = nrow["SendTo"].ToString();

                    imgOne.ImageUrl = "~/Images/flag_indonesia_small1.jpg";
                    Literal101.Text = ctryName;
                    Literal10.Text = ctryName + " Mobile Purchase Format";
                    Literal12.Text = ctrySendTo;
                    lblPurFormat1.Text = ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  YourEmail  YourName";
                    lblPurchaseNote1.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                }
                else
                {
                    dvBookPurchaseFormat.Visible = false;
                }

                DataRow nrow1 = dst.Tables[0].Rows[1];
                if (nrow["countryName"].ToString() != null)
                {
                    dvBookPurchaseFormat1.Visible = true;
                    string ctryName = nrow1["countryName"].ToString();
                    string ctryCurrency = nrow1["currencyName"].ToString();
                    string ctryPriceTag = nrow1["PriceTag"].ToString();
                    string ctryShortcode = nrow1["shortcode"].ToString();
                    string ctryNote = nrow1["displayNote"].ToString();
                    string ctryKeyword = nrow1["Keyword"].ToString();
                    string ctrySendTo = nrow1["SendTo"].ToString();

                    imgTwo.ImageUrl = "~/Images/Flag_sing_small.jpg";
                    Literal102.Text = ctryName;
                    Literal20.Text = ctryName + " Mobile Purchase Format";
                    Literal22.Text = ctrySendTo;
                    lblPurFormat2.Text = ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  YourEmail  YourName";
                    lblPurchaseNote2.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                }
                else
                {
                    dvBookPurchaseFormat1.Visible = false;
                }

                DataRow nrow2 = dst.Tables[0].Rows[2];
                if (nrow2["countryName"].ToString() != null)
                {
                    dvBookPurchaseFormat2.Visible = true;
                    string ctryName = nrow2["countryName"].ToString();
                    string ctryCurrency = nrow2["currencyName"].ToString();
                    string ctryPriceTag = nrow2["PriceTag"].ToString();
                    string ctryShortcode = nrow2["shortcode"].ToString();
                    string ctryNote = nrow2["displayNote"].ToString();
                    string ctryKeyword = nrow2["Keyword"].ToString();
                    string ctrySendTo = nrow2["SendTo"].ToString();

                    imgThree.ImageUrl = "~/Images/flag_mas_small.jpg";
                    Literal103.Text = ctryName;
                    Literal30.Text = ctryName + " Mobile Purchase Format";
                    Literal32.Text = ctrySendTo;
                    lblPurFormat3.Text = ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  YourEmail  YourName";
                    lblPurchaseNote3.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + lblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                }
                else
                {
                    dvBookPurchaseFormat2.Visible = false;
                }
            }


        }
        else
        {

        }

    }





}




