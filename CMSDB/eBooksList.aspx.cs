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
using System.Collections;
using System.Xml;
using System.IO;
using System.Net;


public partial class eBooksList : UserWeb
{

    
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook(); 
    DataSet ds;
    DataTable dt;
    bool ShowSMSpurchase = false; 
    int qCatID = 0;
    String vCatSearch = string.Empty;
    string ctryVal = string.Empty;

    //int vEbUserPackageType = 0;
    string vEbUserKeyword = string.Empty;
    String vEbUserType = string.Empty;

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
                        
            int vUserId = Convert.ToInt32(Session["ClientID"]);

            if(Request.QueryString.Count > 0)
            {
                if (Request.QueryString["qCatID"] != null)
                {
                    qCatID = Convert.ToInt32(Request.QueryString["qCatID"].ToString());
                   
                }
            }
            ViewState["qCatID"] = qCatID;

            if (Session["ipCtry"] == null)
            {
                Session["ipCtry"] = "";
            }
            if (Session["ipCtry"].ToString() == "")
            {
                Session["ipCtry"] = MyGeoLocation.GetCountryCodeFromIP(); ;
            }
            string IPValDisp = Session["ipCtry"].ToString();		
		    //Response.Write(IPValDisp);

            if (Session["ipCtry"].ToString() == "MY")
            {
                ShowSMSpurchase = true;
            }
            else
            {
                ShowSMSpurchase = false;
            }
            //ShowSMSpurchase = MyGeoLocation.isSMSPurchaseOpenForCountry("MY");  //Malaysia : MY  
            //ShowSMSpurchase = true;
           
           // LoadCategories(vUserId);
            LoadEbooks( Convert.ToInt32(Session["ClientID"]), Convert.ToInt32(ViewState["qCatID"].ToString()));

        }


    }


    protected void LoadEbooks(int vUserId, int vCatId)
    {
        //.. Get User & Keyword Details

        DataSet ds2;
        //vUserId = 7702;
        ds2 = objBALebook.Ebook_KeywordDetails_ByUserID(vUserId);

        ViewState["vEbUserKeyword"] = "";
        ViewState["vEbUserPackageType"] = "";
        ViewState["vEbUserType"] = "";
        ViewState["vEbookPrice"] = "";
        ViewState["vEbStoreID"] = "";

        if (ds2.Tables[0].Rows.Count > 0)
        {
            DataRow krow = ds2.Tables[0].Rows[0];

            ViewState["vEbUserKeyword"] = krow["VendorCode"].ToString();
            ViewState["vEbUserPackageType"] = Convert.ToInt32(krow["PackageType"].ToString());
            ViewState["vEbUserType"] = krow["ebUserType"].ToString();
            ViewState["vEbookPrice"] = krow["Price"].ToString();
            ViewState["vEbStoreID"] = krow["eStoreID"].ToString(); 
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

        if(vCatId != 0)
        vCatSearch = " AND BK.CATID = " + vCatId;        
        
        ViewState["catSearch"] = vCatSearch;       

        ds = objBALebook.Ebook_Listing_ByUserID(vUserId, vCatSearch); 
        dt = ds.Tables[0];
        
        string tmpstr = string.Empty;
        int totalPages = 0;
       
        if (dt.Rows.Count > 0)
        {
            DataRow tRows = (DataRow)dt.Rows[0];

            PagedDataSource ObjPds = new PagedDataSource();
            DataView dv = new DataView(dt);
            ObjPds.DataSource = dv; 
            ObjPds.AllowPaging = true;

            ObjPds.PageSize = 10;
            ObjPds.CurrentPageIndex = PageNumber;
            totalPages = ObjPds.PageCount - 1;            

            ViewState["CurrentPage"] = ObjPds.CurrentPageIndex; 

            if (ObjPds.PageCount > 1)
            {
                rptPages.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i < ObjPds.PageCount; i++)
                    pages.Add((i + 1).ToString());
                rptPages.DataSource = pages;
                rptPages.DataBind();
            }
            else
            {
                rptPages.Visible = false;
            }
           
            RepBooks.DataSource = ObjPds;
            RepBooks.DataBind();
        } 

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptPages.ItemCommand +=
           new RepeaterCommandEventHandler(rptPages_ItemCommand);
    }


    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
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

            sbCats.AppendLine("<h2>" + Resources.LangResources.MyCategory  + "</h2>");
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
            sbCats.AppendLine("<h2>" + Resources.LangResources.Categories + "</h2>");
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


    protected void RepBooks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
           
            string strPurchaseFormat = string.Empty;

            StringBuilder sp = new StringBuilder();


            HiddenField objhdIsFreeBook = (HiddenField)e.Item.FindControl("hdIsFreeBook");

            int isFreeBook = Convert.ToInt32(objhdIsFreeBook.Value); 




            HtmlGenericControl objDvPurchase = (HtmlGenericControl)e.Item.FindControl("dvBookPurchaseFormat"); 

           
            Label objlblPurFormat = (Label)e.Item.FindControl("lblPurFormat"); 
            Label objlblBookID = (Label)e.Item.FindControl("lblBookID");

            string tmpPKGtype = ViewState["vEbUserPackageType"].ToString();
            string tmpKeyword = ViewState["vEbUserKeyword"].ToString();
            string tmpBookPrice = ViewState["vEbookPrice"].ToString(); 

            if(tmpBookPrice != "")
            {
                decimal vPrice = Convert.ToDecimal(tmpBookPrice) / 100;
                tmpBookPrice = "RM " + String.Format("{0:n2}", vPrice.ToString()) + "(Excl.GST)"; 
            }

           // if (1 == 1)


            //... Getting individual Book Limitations for SMS and PayPal Purchases. 

            HiddenField objhdAllowSMsBuy = (HiddenField)e.Item.FindControl("hdAllowSMsBuy"); 
            HiddenField objhdAllowPayPalBuy = (HiddenField)e.Item.FindControl("hdAllowPayPalBuy");

            String BookAllowSmsBuy = objhdAllowSMsBuy.Value;
            String BookAllowPayPalBuy = objhdAllowPayPalBuy.Value; 



            LinkButton objLnkPayPal = (LinkButton)e.Item.FindControl("LnkPayPalBuy");
            LinkButton objLnkAddtoCart = (LinkButton)e.Item.FindControl("lnkAddtoCart");

            String tmpAllowPayPal = ViewState["vAllowPayPalBuy"].ToString();

            if (BookAllowPayPalBuy.ToUpper() == "FALSE")
                tmpAllowPayPal = "FALSE";


            if (tmpAllowPayPal.ToUpper() == "TRUE")
            {
              
                if (objLnkPayPal != null)
                {
                    objLnkPayPal.Visible = true;
                    objLnkAddtoCart.Visible = true; 
                }
            }


            String tmpAllowSmsPurchase = ViewState["vAllowSMSBuy"].ToString().ToUpper();

            if(BookAllowSmsBuy.ToUpper() == "FALSE")
                tmpAllowSmsPurchase = "FALSE"; 


            if (!ShowSMSpurchase)  ///to show only for Malaysia. 
                tmpAllowSmsPurchase = "FALSE"; 


            HiddenField obhdLaunchStatus = (HiddenField)e.Item.FindControl("hdLaunchStatus"); 
            int vLaunchStatus = Convert.ToInt16(obhdLaunchStatus.Value);

            

            HtmlTable objtablFree = (HtmlTable)e.Item.FindControl("tblFreeEbooksPurchase");
            HtmlTable objtablBook = (HtmlTable)e.Item.FindControl("tblPurchase");
            HtmlTable objtblComingSoon = (HtmlTable)e.Item.FindControl("tblComingSoon");

            ctryVal = MyGeoLocation.GetCountryCodeFromIP();

            

            if (ctryVal != "MY")
            {
                ShowSMSpurchase = true;  //USA : US
            }


            if (tmpKeyword != "") 
            {

                objDvPurchase.Visible = true;


                if (isFreeBook == 0)
                {

                    if (tmpAllowSmsPurchase == "FALSE")
                    {
                        objDvPurchase.Visible = false;
                    }
                    else
                    {

                        Label objlblPurchaseNote = (Label)e.Item.FindControl("lblPurchaseNote");
                        objtablFree.Visible = false;
                        objtblComingSoon.Visible = false;
                        Literal objLit12_1 = (Literal)e.Item.FindControl("Literal12");


                        if (tmpKeyword == "ZZ" && ctryVal == "MY")
                        {
                            String vStoreID = ViewState["vEbStoreID"].ToString();

                            if (vStoreID != "")
                            {
                                objtablBook.Visible = true;
                                objlblPurFormat.Text = "ZZ  " + vStoreID + "  " + objlblBookID.Text + "  YourEmail  YourName";
                                objLit12_1.Text = "send To 36247";
                                if (objlblPurchaseNote != null)
                                    objlblPurchaseNote.Text = "<b>" + Resources.LangResources.Note + ":- </b> <span class='PriceFont'>" + string.Format("{0:0.00}", tmpBookPrice) + " </span> " + Resources.LangResources.persmsreceived + ". Eg. ZZ " + ViewState["vEbStoreID"] + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                            }
                            else
                            {
                                objDvPurchase.Visible = false;
                            }


                        }
                        else
                        {
                            if (ctryVal == "MY")
                            {
                                objtablBook.Visible = true;
                                objlblPurFormat.Text = ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  YourEmail  YourName";
                                objLit12_1.Text = "send To 36247";
                                if (objlblPurchaseNote != null)
                                    objlblPurchaseNote.Text = "<b>" + Resources.LangResources.Note + ":- </b> <span class='PriceFont'>" + string.Format("{0:0.00}", tmpBookPrice) + " </span> " + Resources.LangResources.persmsreceived + ". Eg. " + ViewState["vEbUserKeyword"] + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                            }
                            else
                            {
                                objDvPurchase.Visible = false;
                            }
                        }



                        if (ctryVal != "MY")
                        {
                            objDvPurchase.Visible = true;
                            objtablBook.Visible = true;
                            newDBS ndbs = new newDBS();
                            DataSet dst = ndbs.ebook_getKeywordDetails_CountryWise(ctryVal);
                            String vStoreID1 = ViewState["vEbStoreID"].ToString();
                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                DataRow nrow = dst.Tables[0].Rows[0];
                                if (nrow["countryName"].ToString() != null)
                                { 
                                string ctryName = nrow["countryName"].ToString();
                                string ctryCurrency = nrow["currencyName"].ToString();
                                string ctryPriceTag = nrow["PriceTag"].ToString();
                                string ctryShortcode = nrow["shortcode"].ToString();
                                string ctryNote = nrow["displayNote"].ToString();
                                string ctryKeyword = nrow["Keyword"].ToString();
                                string ctrySendTo = nrow["SendTo"].ToString();

                                Literal objLit10 = (Literal)e.Item.FindControl("Literal10");
                                Literal objLit11 = (Literal)e.Item.FindControl("Literal11");
                                Literal objLit12 = (Literal)e.Item.FindControl("Literal12");
                                Label lblPNote = (Label)e.Item.FindControl("lblPurchaseNote");

                                objLit10.Text = ctryName + " Mobile Purchase";
                                objLit12.Text = ctrySendTo;
                                objlblPurFormat.Text = ctryKeyword + "  " + vStoreID1 + "  " + objlblBookID.Text + "  YourEmail  YourName";
                                lblPNote.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + vStoreID1 + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                                }
                                else
                                {
                                    objDvPurchase.Visible = false;
                                }
                            }
                            else
                            {
                                HtmlGenericControl objDvPurchase1 = (HtmlGenericControl)e.Item.FindControl("dvBookPurchaseFormat");
                                objDvPurchase1.Visible = false;
                            }
                        }
                    }
                }
                else
                {

                    objDvPurchase.Attributes.Add("class", "dvBookPurchase_FreeBookCss");
                    Label objlblPurchaseNote2 = (Label)e.Item.FindControl("lblPurchaseNote2");
                    Label objlblPurFormat2 = (Label)e.Item.FindControl("lblPurFormat2"); 

                    objtablFree.Visible = true;
                    objtablBook.Visible = false;
                    objtblComingSoon.Visible = false;

                    String vStoreID = ViewState["vEbStoreID"].ToString();
                    objlblPurFormat2.Text = HttpUtility.HtmlEncode("FREE  " + string.Empty + string.Empty + string.Empty + vStoreID + "  " + objlblBookID.Text + "  YourEmail  YourName");

                    if (objlblPurchaseNote2 != null)
                        objlblPurchaseNote2.Text = "<b>Eg. FREE  " + vStoreID + "  " + objlblBookID.Text + "  JohnWoo@yahoo.com  John Woo";


                    Label objlblAfterDiscount = (Label)e.Item.FindControl("lblAfterDiscount");

                    
                        String strPrice = "0.00";
                        decimal vPrice = Convert.ToDecimal(strPrice);
                        tmpBookPrice = String.Format("{0:n2}", vPrice.ToString());

                        //decimal vPrice = Convert.ToDecimal(tmpBookPrice);
                        //tmpBookPrice = tmpBookCurrency + " " + String.Format("{0:n2}", vPrice);


                        objlblAfterDiscount.Text = tmpBookPrice;

                        Image objFreebookImg = (Image)e.Item.FindControl("ImgFreeBook"); 

                        if(objFreebookImg != null)
                        {
                            objFreebookImg.Visible = true;
                        }



                   

                    if (objLnkPayPal != null)
                    {
                        objLnkPayPal.Visible = false;
                        objLnkAddtoCart.Visible = false; 
                    }


                }

            }

            if (vLaunchStatus == 2)
            {
                objDvPurchase.Visible = true;
                objDvPurchase.Attributes.Add("class", "dvBookPurchase_ComingCss");


                objtablFree.Visible = false;
                objtablBook.Visible = false;
                objtblComingSoon.Visible = true;

                Image objFreebookImg = (Image)e.Item.FindControl("ImgFreeBook");

                if (objFreebookImg != null)
                {
                    objFreebookImg.Visible = true;
                    objFreebookImg.ImageUrl = "~/Images/ebImages/ComingSoonSmall1.jpg"; 
                }



                if (objLnkPayPal != null)
                {
                    objLnkPayPal.Visible = false;
                    objLnkAddtoCart.Visible = false; 
                }

            }


           
           

        }


    }


    protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        LoadEbooks(Convert.ToInt32(Session["ClientID"]), Convert.ToInt32(ViewState["qCatID"].ToString()));
    }


    protected void rptPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            int vCurrentPage = Convert.ToInt32(ViewState["CurrentPage"].ToString());

            vCurrentPage = vCurrentPage + 1; 
            if (vCurrentPage <= 0)
                vCurrentPage = 1; 

            LinkButton objItem = (LinkButton)e.Item.FindControl("btnPage"); 

            if(objItem != null)
            {
                if (objItem.Text == vCurrentPage.ToString())
                    objItem.CssClass = "Pag_Item_current"; 
            }

        }

        

    }


    protected void LnkPayPalBuy_Command(object sender, CommandEventArgs e)
    {

        String vBookDetails = e.CommandArgument.ToString().Trim();

        string[] BookInfo = vBookDetails.Split('#');

        String vBookID = string.Empty;
        String vBookName = string.Empty;
        String vBookPrice = string.Empty;
        String vImageUrl = string.Empty; 
        String CallingPageUri = Request.Url.AbsoluteUri;



        foreach (string part in BookInfo)
        {

            vBookID = BookInfo[0].ToString();
            vBookName = BookInfo[1].ToString();
            vBookPrice = BookInfo[2].ToString();
            vImageUrl = BookInfo[3].ToString(); 
        }


        String vUserID = Session["ClientID"].ToString();
        String vCustomText = "EBOOK" + "#" + vUserID + "#" + vBookID + "#" + vBookPrice;

        Random rand = new Random((int)DateTime.Now.Ticks);
        int vUnique = 0;
        vUnique = rand.Next(1, 500000);

        String vUniqueID = vUnique.ToString();

        //CommonFunctions.ConfirmPayPalBuy(vBookID, vUserID, CallingPageUri);

        //... Buy Now adds the item to the Cart instead of directly sending to BuyNow page. 
        String vCustomString = vBookID + "#" + vBookName + "#" + vBookPrice + "#" + vImageUrl;
        CommonFunctions.AddItemtoCart(vCustomString, Request.Url.AbsoluteUri); 


       // CommonFunctions.ProceedToPalBuy("", vBookPrice, "USD", "", vBookName, vBookID, vCustomText, vUniqueID, "worldDigitalBiz.com", vUserID, CallingPageUri);

        //CommonFunctions.ProceedToPalBuy(); 
        // ( cpFullName,  cpAmount,  cpCurrencyCode,  cpMobileNo,  cpItemName,  cpItemNumber,  cpCustomText,  cpUniqueID,  cpWebSiteName,  cpUserID)



    }


    
    protected void LnkPayPalBuy_Click(object sender, CommandEventArgs e)
    {
        String vBookDetails = e.CommandArgument.ToString().Trim();

        string[] BookInfo = vBookDetails.Split('#');

        String vBookID = string.Empty;
        String vBookName = string.Empty;
        String vBookPrice = string.Empty;
        String CallingPageUri = Request.Url.AbsoluteUri;



        foreach (string part in BookInfo)
        {

            vBookID = BookInfo[0].ToString();
            vBookName = BookInfo[1].ToString();
            vBookPrice = BookInfo[2].ToString();
        }


        String vUserID = Session["ClientID"].ToString();
        String vCustomText = "EBOOK" + "#" + vUserID + "#" + vBookID + "#" + vBookPrice;

        Random rand = new Random((int)DateTime.Now.Ticks);
        int vUnique = 0;
        vUnique = rand.Next(1, 500000);

        String vUniqueID = vUnique.ToString();

        CommonFunctions.ProceedToPalBuy("", vBookPrice, "USD", "", vBookName, vBookID, vCustomText, vUniqueID, "worldDigitalBiz.com", vUserID, CallingPageUri);
    }



    protected void lnkAddtoCart_Command(object sender, CommandEventArgs e)
    {
        String vBookDetails = e.CommandArgument.ToString().Trim();

        string[] BookInfo = vBookDetails.Split('#');

        String vBookID = string.Empty;
        String vBookName = string.Empty;
        String vBookPrice = string.Empty;
        String vImageUrl = string.Empty; 
        String CallingPageUri = Request.Url.AbsoluteUri;

        CMSv3.Entities.CartItems objItems = new CMSv3.Entities.CartItems();

        foreach (string part in BookInfo)
        {
            vBookID = BookInfo[0].ToString();
            vBookName = BookInfo[1].ToString();
            vBookPrice = BookInfo[2].ToString();
            vImageUrl = BookInfo[3].ToString(); 

            objItems.BookID = vBookID;
            objItems.BookName = vBookName;
            objItems.Price = Convert.ToDecimal(vBookPrice);
            objItems.ImageURL = vImageUrl; 

            ShoppingCart.AddCartItem(objItems);
            System.Threading.Thread.Sleep(500);
            // UpdatePanel1.Update(); 

            Server.Transfer("eBooksList.aspx");
        }
    }
    
}




