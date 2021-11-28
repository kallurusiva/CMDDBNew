using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;

public partial class PgAdvert : System.Web.UI.Page
{

    string qMobile = string.Empty;
    string qlang = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        
        //if (Page.PreviousPage != null)
        //{
        //    TextBox SourceTextBox = (TextBox)Page.PreviousPage.FindControl("txtMobile");
        //    if (SourceTextBox != null)
        //    {
        //        qMobile = SourceTextBox.Text;
        //    }
        //}

      
        if (Request.QueryString["mb"] != null)
            qMobile = Request.QueryString["mb"].ToString();


        //if (Request.QueryString["ln"] == null)
        //    qlang = "en";
        //else
        //    qlang = Request.QueryString["ln"].ToString();

        //string tmpSTR = Request.Url.Query;
        //int url_start = tmpSTR.IndexOf(";") + 1;

        //string myURL = tmpSTR.Substring(url_start);
        //int url_end = myURL.LastIndexOf(":");
        //myURL = myURL.Substring(0, url_end);
        //Response.Write(myURL);

        //string vQueryString = Request.PathInfo;
        //int index = vQueryString.LastIndexOf("/") + 1;
        //qMobile = vQueryString.Substring(index).Replace(".aspx", string.Empty).Replace("-", " ");

        //if (Request.UrlReferrer != null)
        //{
        //    Response.Write("URL referrer :" + Request.UrlReferrer.ToString() + "<br/>");
        //}


        //Response.Write("RawUrl : " + Request.RawUrl + "<br/>");
        //Response.Write("QueryString : " + Request.QueryString + "<br/>");
        //Response.Write("PathInfo : " + Request.PathInfo + "<br/>");
        //Response.Write("Url : " + Request.Url + "<br/>");
        //Response.Write("Url.Query : " + Request.Url.Query + "<br/>");
        //Response.Write("Url.OriginalString : " + Request.Url.OriginalString + "<br/>");
        //Response.Write("User AGent : " + "Request.UserAgent" + "<br/>" );


        string tmpMainURL;
        string tmpMobile = Request.QueryString["mb"];
        
        //;= Request.Url.OriginalString;
        //int tmpMainIDx = tmpMainURL.IndexOf(":") - 1;
        //tmpMainURL = tmpMainURL.Substring(0, tmpMainIDx);;
        //Response.Write("Main URL : " + tmpMainURL + "<br/>");

        tmpMainURL = Convert.ToString(Request.Url);
        tmpMainURL = tmpMainURL.Replace(Request.RawUrl, string.Empty);
        tmpMainURL = tmpMainURL + "/" + tmpMobile;
        //Response.Write("<a href='' target='_blank'>" +  tmpMainURL + "/" + Request.QueryString["mb"] + "</a>");
      // Response.Write("<a href='' target='_blank'>" + tmpMainURL + "</a>");


        lblPageLink.Text = "<a class='links_AdvertDomain' href='" + tmpMainURL + "' target='_blank'>" + tmpMainURL + "</a>";
        ltrMobileNo1.Text = tmpMobile;
        ltrMobileNo2.Text = tmpMobile;
        

       if(qMobile != string.Empty)
           loadUserDetails(qMobile);

       if (!IsPostBack)
       {
           //tblFREE.Visible = false;
           //tblNOTfree.Visible = false;
          // hypSignUp.Attributes.Add("onclick", "javascript: fnShowHideDiv('NOTFREE');");
       }

       //tblFREE.Attributes.Add("onclick", "return OpentblFREE();");
       //tblNOTfree.Attributes.Add("onclick", "return OpentblNotFREE();");

       

    }


    protected void loadUserDetails(string qMobile)
    {


        //---- Checking for the Valid PIN from Another SERVER------------
        ASCIIEncoding encoding = new ASCIIEncoding();
        string postData = "Mobile=" + qMobile;
        byte[] data = encoding.GetBytes(postData);


        #region // Retreiving User Status from 1MalaysiaSMS.com
        // Prepare web request...
        HttpWebRequest http_UserRequest = (HttpWebRequest)WebRequest.Create("http://64.78.18.32/mlmsms/AdminX/WebAdvert_User_Post.asp");
        http_UserRequest.Method = "POST";
        http_UserRequest.ContentType = "application/x-www-form-urlencoded";
        http_UserRequest.ContentLength = data.Length;
        Stream newStream = http_UserRequest.GetRequestStream();
        // Send the data.
        newStream.Write(data, 0, data.Length);
        newStream.Close();

        

        // *** Retrieve request info headers
        HttpWebResponse http_UserResponse = (HttpWebResponse)http_UserRequest.GetResponse();
        Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page
        StreamReader loResponseStream = new StreamReader(http_UserResponse.GetResponseStream(), enc);
        string Html_UserResponse = loResponseStream.ReadToEnd();
        http_UserResponse.Close();
        loResponseStream.Close();

        #endregion


        string[] UserResponseArray = Html_UserResponse.Split(',');

        string uExists = UserResponseArray[0];
        string uName = UserResponseArray[1];
        string uType = UserResponseArray[2];
        string uStep = UserResponseArray[3];
        string uDomainName = UserResponseArray[4];
        string uDomainType = UserResponseArray[5];
        string uPageLink = UserResponseArray[6];
        string uCurrentMA = UserResponseArray[7];
       // uStep = "TWO";

        if (uExists.ToUpper() == "TRUE")
        {
            lblName.Text = uName;
            lblMobileno.Text = qMobile;

            if (uType.ToUpper() == "FREE")
            {
                lblStatus.Text = uType + " ( Not Eligible to Sponsor )";

                if(qMobile.ToString().Substring(0,2) == "65")
                {
                    tblFree_Tr_MAS.Visible = false;
                    tblFree_Tr_Sing.Visible = true;

                    if (uCurrentMA == "EXISTS")
                    {
                        hypSignUp.Attributes.Add("onclick", "javascript: fnShowHideDiv('NOTFREE');");
                       
                    }
                    else
                    {

                        hypSignUp.Attributes.Add("onclick", "javascript: fnShowHideDiv('FREE');");
                    }


                }
                else{
                    tblFree_Tr_Sing.Visible = false;
                    tblFree_Tr_MAS.Visible = true;


                    //...free users are eligible to sponsor if they have completed STEP 2 ....
                    if (uStep != "TWO")
                    {

                        hypSignUp.Attributes.Add("onclick", "javascript: fnShowHideDiv('FREE');");
                    }
                    else
                    {
                        hypSignUp.Attributes.Add("onclick", "javascript: fnShowHideDiv('NOTFREE');");

                    }
                }
                 

                
                //lnkSignUp.Attributes.Add("OnClientClick", "return OpentblFREE();");
                //hypFreeSMSSystem.Attributes.Add("onclick", "return OpentblFREE();");
                //hypFreeSMSSystem.Attributes.Add("href", "Javascript: OpentblFREE();");
                //tblFREE.Visible = true;
                //tblNOTfree.Visible = false;
            }
            else
            {
                lblStatus.Text = uType;
                hypSignUp.Attributes.Add("onclick", "javascript: fnShowHideDiv('NOTFREE');");
                //lnkSignUp.Attributes.Add("OnClientClick", "return OpentblNotFREE();");
                //hypFreeSMSSystem.Attributes.Add("onclick", "return OpentblNotFREE();");
                //hypFreeSMSSystem.Attributes.Add("href", "Javascript: OpentblNotFREE();");
                //tblFREE.Visible = false;
                //tblNOTfree.Visible = true;
            }

            //if(uDomainName != "NULL")
            //{
            //    lblDomain.Text = uDomainName;
            //    lblPageLink.Text = uPageLink;
            //}



        }
        else
        {

            Response.Redirect("default.aspx");

        }


    }


    protected void dpLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (dpLanguage.SelectedValue != "0")
        {
            if (dpLanguage.SelectedValue == "en")
            {
                Response.Redirect("pgAdvert.aspx?mb=" + qMobile);
            }
            else
            {
                Response.Redirect("pgAdvertbm.aspx?mb=" + qMobile);
            }
        }
    }
}
