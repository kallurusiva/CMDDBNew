using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageNotFound : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string vQueryString = Request.RawUrl;
        Response.Write("RawUrl : " + vQueryString + "<br/>");
        Response.Write("QueryString : " + Request.QueryString + "<br/>");
        Response.Write("PathInfo : " + Request.PathInfo + "<br/>");
        Response.Write("Url.Query : " + Request.Url.Query + "<br/>");
        Response.Write("Url.OriginalString : " + Request.Url.OriginalString + "<br/>");

      
        string tmpSTR = Request.Url.Query;
        int idx = tmpSTR.LastIndexOf("/") + 1;
        string vEnteredText = tmpSTR.Substring(idx).Replace(".aspx", string.Empty).Replace("-", " ");

        Response.Write("Entered Mobile Number " + vEnteredText + "<br/>"); 

        //Response.Write("My URL =" + myURL + "<br/>");
        //Response.Write("MyText =" + mytext + "<br/>");

       

        //foreach(string mstr in Request.Params.AllKeys)
        //{
        //    Response.Write( mstr + " | " + Request.Params[mstr] + "<br/>");
        //}


        //Response.End();

        

        //string vErrorPathStr = Request.QueryString["aspxerrorpath"];
        //int index = vErrorPathStr.LastIndexOf("/") + 1;
        //string vEnteredText = vErrorPathStr.Substring(index).Replace(".aspx", string.Empty).Replace("-", " ");

       // Response.Write(vEnteredText);

        //Check if entered Text is Numeric.
        if (IsNumeric(vEnteredText))
        {

            if((vEnteredText.Length == 10) || (vEnteredText.Length ==11)) 
            {
                Response.Redirect("pgAdvert.aspx?mb=" + vEnteredText.ToString());
                //Response.Redirect("pgAdvert.aspx/" + vEnteredText.ToString());
                //txtMobile.Text = vEnteredText.ToString();
                //Server.Transfer("pgAdvert.aspx");
                                
            }
        }
        else
        {
            Response.Redirect("default.aspx");

        }




    }

    public static bool IsNumeric(string strValue)
    {
        try
        {
            if (strValue.StartsWith("60"))
            {
                Convert.ToInt64(strValue);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        catch
        {
            return false;
        }
    }

  


 



}
