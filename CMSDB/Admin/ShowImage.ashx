<%@ WebHandler Language="C#" Class="ShowImage" %>



using System;
using System.Configuration;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.ComponentModel;


public class ShowImage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
       // context.Response.Write("Hello World");

        string tmpPicURL;
        if (context.Request.QueryString["picURL"] != null)
            tmpPicURL = context.Request.QueryString["picURL"].ToString();
        else
            throw new ArgumentException("No parameter specified");



        if (tmpPicURL != null)
        {
            showPicture(tmpPicURL);
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    
    public void showPicture(string vPicURL)
    {

        string mPicURL = vPicURL.ToString().Replace("/", "\\");
        //// Create/Load the image from the string value in session
        //Bitmap b = new Bitmap(mPicURL);
        //b.Save(mPicURL, ImageFormat.Jpeg);
        ////b.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        //b.Dispose();
                
        Image im = Image.FromFile(mPicURL);
        im.Dispose();
       // <img src="../ImageRepository/BannerTemplate2.jpg" />
        
    }

}