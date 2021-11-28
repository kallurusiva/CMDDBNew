using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Template1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string tmp = Request.UserHostAddress;
        Response.Write("Request.UserHostAddress : " + tmp + "<br>");

        tmp = Request.UserHostName;
        Response.Write("Request.UserHostName : " + tmp + "<br>");

              

        tmp = Request.ApplicationPath;
        Response.Write("Request.ApplicationPath : " + tmp + "<br>");

        tmp = Request.Browser.Browser;
        Response.Write("Request.Browser.Browser : " + tmp + "<br>");

        tmp = Request.FilePath;
        Response.Write("Request.FilePath : " + tmp + "<br>");


        tmp = Request.HttpMethod;
        Response.Write("Request.HttpMethod : " + tmp + "<br>");

        tmp = Request.Path;
        Response.Write("Request.Path : " + tmp + "<br>");

        tmp = Request.PathInfo;
        Response.Write("Request.PathInfo : " + tmp + "<br>");

        tmp = Request.RawUrl;
        Response.Write("Request.RawUrl : " + tmp + "<br>");

        tmp = Request.Url.AbsolutePath;
        Response.Write("Request.Url.AbsolutePath : " + tmp + "<br>");

        tmp = Request.Url.PathAndQuery;
        Response.Write("Request.Url.PathAndQuery : " + tmp + "<br>");

        tmp = Request.Url.OriginalString;
        Response.Write("Request.Url.OriginalString : " + tmp + "<br>");


        string tmpMainURL = Request.Url.OriginalString;
        tmpMainURL = tmpMainURL.Replace("http://","");

        

        

        //Removing http:// from the strin g
        //string MainSiteName = "1argentinasms";

        
        string[] xMainURLArr = tmpMainURL.Split('.');

        //tmpSubDomainURL = tmpSubDomainURL.Replace("www", "");
        for (int i = 0; i < xMainURLArr.Length; i++)
        {
            Response.Write(i + "-" + xMainURLArr[i].ToString() + "<br>");
        }


        if (tmpMainURL.Contains("1argentinasms"))
        {
            //subdomain
            string tmpSubDomainURL = tmpMainURL;
            string[] MainURLArr = tmpMainURL.Split('.');
            
            //tmpSubDomainURL = tmpSubDomainURL.Replace("www", "");
            for(int i = 0; i < MainURLArr.Length ; i++)
            {
                Response.Write( i + "-" +  MainURLArr[i].ToString() + "<br>");
            }
        }
        else
        {
            //owndomain
            string ownDomain = tmpMainURL;
            tmpMainURL = tmpMainURL.Replace("http://","");
                    
        }



//Dim s As String = Request.UserHostAddress()
//'request's user's host address and writes using the response object's write method
//Response.Write(s)

//Dim a As String = Request.ApplicationPath()
//'request's the application path 
//Response.Write(a)

//Dim aa As String = Request.Browser.Browser
//'request's the type of browser 
//Response.Write(aa)

//Dim b As String = Request.CurrentExecutionFilePath
//'request's the current execution path 
//Response.Write(b)

//Dim c As String = Request.FilePath
//'request's the path to the file that you are currently working with
//Response.Write(c)

//Dim cc As String = Request.HttpMethod
//'gets the HttpMethod
//Response.Write(cc)

//If Request.Browser.Browser = "IE" Then
//'checks to see if the browser is IE and if true displays a message
//Response.Write("You are using IE")
//Else
//Response.Write("You are using some other browser")
//End If

//Response.Write("Your computer is/has the following" & Request.Useragent) 
//'displays the user information about his computer


    }
}
