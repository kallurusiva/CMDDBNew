using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using CMSv3.BAL;
using System.Net;

public partial class O_dtShowCountryFormat : System.Web.UI.Page
{
    CMSv3.BAL.eBook objBALebook = new CMSv3.BAL.eBook();
    //DataSet ds;
    //DataTable dt;
    String qBookID = "0";
    string ctryVal = string.Empty;
    bool ShowSMSpurchase = false;
    string appendMessageMY = string.Empty;

    string flagMalaysiaStatus = string.Empty;
    string flagSingaporeStatus = string.Empty;
    string flagIndonesiaStatus = string.Empty;
    string flagThilandStatus = string.Empty;
    string flagPhilippinesStatus = string.Empty;
    string flagVietnamStatus = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["qBookID"] != null)
                {
                    qBookID = Request.QueryString["qBookID"].ToString();

                }
            }
            int vUserId = Convert.ToInt32(Session["ClientID"]);
            ViewState["qBookID"] = qBookID;
            //Session["ipCtry"] = "MY";
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
            //ShowSMSpurchase = true;
            if (ctryVal == "MY")
            {
                ShowSMSpurchase = MyGeoLocation.isSMSPurchaseOpenForCountry("MY");  //Malaysia : MY
            }
            if (ctryVal != "MY")
            {
                ShowSMSpurchase = true;  //USA : US
            } 
            LoadEbook(qBookID, vUserId);
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

        if (ds2.Tables[3].Rows.Count > 0)
        {
            DataRow srow = ds2.Tables[3].Rows[0];
            flagMalaysiaStatus = srow["MalaysiaFlag"].ToString();
            flagSingaporeStatus = srow["SingaporeFlag"].ToString();
            flagIndonesiaStatus = srow["IndonesiaFlag"].ToString();
            flagThilandStatus = srow["ThailandFlag"].ToString();
            flagPhilippinesStatus = srow["PhilippionesFlag"].ToString();
            flagVietnamStatus = srow["VietnaemFlag"].ToString();
        }

        if (flagMalaysiaStatus.ToString() == "0") { dvPBookFormat2.Visible = false; }
        if (flagSingaporeStatus.ToString() == "0") { dvPBookFormat1.Visible = false; }
        if (flagIndonesiaStatus.ToString() == "0") { dvflgIndonesia.Visible = false; }
        if (flagThilandStatus.ToString() == "0") { dvPBookFormat3.Visible = false; }
        if (flagPhilippinesStatus.ToString() == "0") { dvPBookFormat5.Visible = false; }
        if (flagVietnamStatus.ToString() == "0") { dvPBookFormat4.Visible = false; }

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

            DateTime dNewDate = Convert.ToDateTime(dr["DateCreated"].ToString());
            String strNewDate = String.Format("{0:MMMM d, yyyy h:mm:ss tt}", dNewDate);
            String tmpDescription = dr["Description"].ToString();
            tmpDescription = tmpDescription.Replace(Environment.NewLine, "<br/>");

            int vLaunchStatus = Convert.ToInt16(dr["LaunchStatus"].ToString());
            int isFreeBook = Convert.ToInt16(dr["isFreeBook"].ToString());
            String BookAllowSmsBuy = dr["AllowSMSbuy"].ToString();
            String BookAllowPayPalBuy = dr["AllowPaypalBuy"].ToString();
            if (BookAllowSmsBuy.ToUpper() == "FALSE")
                tmpAllowSmsPurchase = "FALSE";

            if (tmpKeyword != "")
            {                
                dvGlobalPurchase.Visible = true;
               
                if (isFreeBook == 0)
                {
                    
                    if (tmpAllowSmsPurchase == "FALSE")
                    {
                        
                    }
                    else
                    {
                        newDBS ndbs1 = new newDBS();
                        DataSet dst1 = ndbs1.ebook_getKeywordDetails_AllCountries(Session["ClientID"].ToString(), ViewState["qBookID"].ToString());
                        pBookID.Text = dr["BookID"].ToString();
                        pBookName.Text = dr["BookNAme"].ToString();
                        pBookCategory.Text = dr["CategoryName"].ToString();
                        pBookDate.Text = strNewDate;
                        pBookOrgPrice.Text = dr["UserCurrency"].ToString() + " " + String.Format("{0:n2}", Convert.ToDecimal(dr["Price"].ToString()));
                        pBookDiscountPrice.Text = dr["UserCurrency"].ToString() + " " + String.Format("{0:n2}", Convert.ToDecimal(dr["DiscountedPrice"].ToString()));
                        pBookPrepaidPrice.Text = dr["PrepaidPrice"].ToString();
                        pBookImage.ImageUrl = dr["ImageFileFullURL"].ToString();

                        if (dst1.Tables[0].Rows.Count > 0)
                        {
                            DataRow nrow = dst1.Tables[0].Rows[0];
                            if (nrow["countryName"].ToString() != null)
                            {
                                dvPBookFormat.Visible = true;
                                string ctryName = nrow["countryName"].ToString();
                                string ctryCurrency = nrow["currencyName"].ToString();
                                string ctryPriceTag = nrow["PriceTag"].ToString();
                                string ctryShortcode = nrow["shortcode"].ToString();
                                string ctryNote = nrow["displayNote"].ToString();
                                string ctryKeyword = nrow["Keyword"].ToString();
                                string ctrySendTo = nrow["SendTo"].ToString();
                                string isDisplay = nrow["Display"].ToString();

                                pBookSendTo.Text = ctrySendTo;
                                pPFormat.Text = ctryKeyword + " &nbsp; " + tmpEstoreID + " &nbsp; " + pBookID.Text + " &nbsp; YourEmail &nbsp; YourName";
                                pBookDFormat.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + pBookID.Text + "  JohnWoo@yahoo.com  John Woo";

                                if (isDisplay == "0") { dvPBookFormat.Visible = false; }
                            }
                            else
                            {
                                dvPBookFormat.Visible = false;
                            }

                            DataRow nrow1 = dst1.Tables[0].Rows[1];
                            if (nrow["countryName"].ToString() != null)
                            {
                                dvPBookFormat1.Visible = true;
                                string ctryName = nrow1["countryName"].ToString();
                                string ctryCurrency = nrow1["currencyName"].ToString();
                                string ctryPriceTag = nrow1["PriceTag"].ToString();
                                string ctryShortcode = nrow1["shortcode"].ToString();
                                string ctryNote = nrow1["displayNote"].ToString();
                                string ctryKeyword = nrow1["Keyword"].ToString();
                                string ctrySendTo = nrow1["SendTo"].ToString();
                                string isDisplay = nrow1["Display"].ToString();

                                pBookSendTo1.Text = ctrySendTo;
                                pPFormat1.Text = ctryKeyword + " &nbsp; " + tmpEstoreID + " &nbsp; " + pBookID.Text + " &nbsp; YourEmail &nbsp; YourName";
                                pBookDFormat1.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + pBookID.Text + "  JohnWoo@yahoo.com  John Woo";

                                if (isDisplay == "0") { dvPBookFormat1.Visible = false; }
                            }
                            else
                            {
                                dvPBookFormat1.Visible = false;
                            }

                            DataRow nrow2 = dst1.Tables[0].Rows[2];
                            if (nrow2["countryName"].ToString() != null)
                            {
                                dvPBookFormat2.Visible = true;
                                string ctryName = nrow2["countryName"].ToString();
                                string ctryCurrency = nrow2["currencyName"].ToString();
                                string ctryPriceTag = nrow2["PriceTag"].ToString();
                                string ctryShortcode = nrow2["shortcode"].ToString();
                                string ctryNote = nrow2["displayNote"].ToString();
                                string ctryKeyword = nrow2["Keyword"].ToString();
                                string ctrySendTo = nrow2["SendTo"].ToString();
                                string isDisplay = nrow2["Display"].ToString();
                                
                                pBookSendTo2.Text = ctrySendTo;
                                if (tmpKeyword == "ZZ" && ctryVal == "MY")
                                {
                                    pPFormat2.Text = "CENT5&nbsp; ZZ" + " &nbsp; " + tmpEstoreID.ToString() + " &nbsp; " + pBookID.Text + "  &nbsp;YourEmail  YourName";
                                    pBookDFormat2.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote.Replace("ZZ ZZ", "ZZ " + tmpEstoreID) + ". Eg. " + "CENT5 ZZ" + " " + tmpEstoreID.ToString() + "  " + pBookID.Text + "  JohnWoo@yahoo.com  John Woo";                                    
                                }
                                else
                                {
                                    pPFormat2.Text = tmpEstoreID + " &nbsp; " + pBookID.Text + " &nbsp; YourEmail &nbsp; YourName";
                                    pBookDFormat2.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + tmpEstoreID + "  " + pBookID.Text + "  JohnWoo@yahoo.com  John Woo";
                                }

                                if (isDisplay == "0") { dvPBookFormat2.Visible = false; }
                            }
                            else
                            {
                                dvPBookFormat2.Visible = false;
                            }


                            DataRow nrow3 = dst1.Tables[0].Rows[3];
                            if (nrow3["countryName"].ToString() != null)
                            {
                                dvPBookFormat3.Visible = true;
                                string ctryName = nrow3["countryName"].ToString();
                                string ctryCurrency = nrow3["currencyName"].ToString();
                                string ctryPriceTag = nrow3["PriceTag"].ToString();
                                string ctryShortcode = nrow3["shortcode"].ToString();
                                string ctryNote = nrow3["displayNote"].ToString();
                                string ctryKeyword = nrow3["Keyword"].ToString();
                                string ctrySendTo = nrow3["SendTo"].ToString();
                                string isDisplay = nrow3["Display"].ToString();

                                pBookSendTo3.Text = ctrySendTo;
                                pPFormat3.Text = ctryKeyword + " &nbsp; " + tmpEstoreID + " &nbsp; " + pBookID.Text + " &nbsp; YourEmail &nbsp; YourName";
                                pBookDFormat3.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + pBookID.Text + "  JohnWoo@yahoo.com  John Woo";

                                if (isDisplay == "0") { dvPBookFormat3.Visible = false; }
                            }
                            else
                            {
                                dvPBookFormat3.Visible = false;
                            }

                            DataRow nrow4 = dst1.Tables[0].Rows[4];
                            if (nrow4["countryName"].ToString() != null)
                            {
                                dvPBookFormat4.Visible = true;
                                string ctryName = nrow4["countryName"].ToString();
                                string ctryCurrency = nrow4["currencyName"].ToString();
                                string ctryPriceTag = nrow4["PriceTag"].ToString();
                                string ctryShortcode = nrow4["shortcode"].ToString();
                                string ctryNote = nrow4["displayNote"].ToString();
                                string ctryKeyword = nrow4["Keyword"].ToString();
                                string ctrySendTo = nrow4["SendTo"].ToString();
                                string isDisplay = nrow4["Display"].ToString();

                                pBookSendTo4.Text = ctrySendTo;
                                pPFormat4.Text = ctryKeyword + " &nbsp; " + tmpEstoreID + " &nbsp; " + pBookID.Text + " &nbsp; YourEmail &nbsp; YourName";
                                pBookDFormat4.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + pBookID.Text + "  JohnWoo@yahoo.com  John Woo";

                                if (isDisplay == "0") { dvPBookFormat4.Visible = false; }
                            }
                            else
                            {
                                dvPBookFormat4.Visible = false;
                            }

                            DataRow nrow5 = dst1.Tables[0].Rows[5];
                            if (nrow5["countryName"].ToString() != null)
                            {
                                dvPBookFormat5.Visible = true;
                                string ctryName = nrow5["countryName"].ToString();
                                string ctryCurrency = nrow5["currencyName"].ToString();
                                string ctryPriceTag = nrow5["PriceTag"].ToString();
                                string ctryShortcode = nrow5["shortcode"].ToString();
                                string ctryNote = nrow5["displayNote"].ToString();
                                string ctryKeyword = nrow5["Keyword"].ToString();
                                string ctrySendTo = nrow5["SendTo"].ToString();
                                string isDisplay = nrow5["Display"].ToString();

                                pBookSendTo5.Text = ctrySendTo;
                                pPFormat5.Text = ctryKeyword + " &nbsp; " + tmpEstoreID + " &nbsp; " + pBookID.Text + " &nbsp; YourEmail &nbsp; YourName";
                                pBookDFormat5.Text = "<b><u>" + Resources.LangResources.Note + ":- </b></u> " + ctryNote + ". Eg. " + ctryKeyword + " " + tmpEstoreID + "  " + pBookID.Text + "  JohnWoo@yahoo.com  John Woo";

                                if (isDisplay == "0") { dvPBookFormat5.Visible = false; }
                            }
                            else
                            {
                                dvPBookFormat5.Visible = false;
                            }



                        }         
                    }

                }
                else
                {                    
                    
                }
               
            }

        }
        else
        {

        }
    }
        
}