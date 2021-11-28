using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

public partial class Admin_ShowImagePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string mPicURL = Request.QueryString["picURL"];

        //mPicURL = @"\ImageRepository\Banner1.jpg";

        string mypath = Server.MapPath(Request.ApplicationPath);
        System.Drawing.Image image = System.Drawing.Image.FromFile(mypath + mPicURL);

        int ImageWidthInPixels = image.Width;
        int ImageHeightInPixels = image.Height;
        //Bitmap 
        Bitmap b = new System.Drawing.Bitmap(ImageWidthInPixels, ImageHeightInPixels, PixelFormat.Format24bppRgb);
        Graphics g = Graphics.FromImage(b);
        g.Clear(Color.White);
        g.DrawImage(image, 0, 0, ImageWidthInPixels, ImageHeightInPixels);
        Response.ContentType = "image/jpeg";
        b.Save(Response.OutputStream, ImageFormat.Jpeg); //Use this line, you can output the image to page.
        b.Dispose();

// file:///D:\GlobalSurf\Web\DotNet\CMS\CMSv3\ImageRepository\Banner1.jpg


    }
}
