using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TestUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Introducing delay for demonstration.
        System.Threading.Thread.Sleep(3000);
        Label1.Text = "Page refreshed at " +
            DateTime.Now.ToString();   
    }



  
    protected void btn_Banner_Logo0_Click(object sender, EventArgs e)
    {

         //Store Image file prefixed with userid_randomNo_fileName 
        Random rnum = new Random();

        string ImgFileName = string.Empty;
        string ImgFileUrl = string.Empty;


        if (FU_Banner.HasFile)
        {

            ImgFileName = "134" + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + FU_Banner.FileName;

            //instead of server.mapPath set the path in web.config file and use that path.
            ImgFileUrl = Server.MapPath("~") + @"\ImageRepository\";

            FU_Banner.SaveAs(ImgFileUrl + ImgFileName);
           // lblUpMessageBanner.Text = "Image uploaded : " + FU_Banner.FileName + "<br/><font class='links_TopLineRed'>[Please click the 'SAVE Web Settings' Button down below to save your settings]</font>"; ;
           // FileWasUpload = true;
            ViewState["Bnr_FileImageUrl"] = ImgFileUrl;
            ViewState["Bnr_FileImageName"] = ImgFileName;
            ViewState["Bnr_ActualFileName"] = FU_Banner.FileName;
            ViewState["BannerWasUploaded"] = "true";

            lblImg.Text = ImgFileName + "  | " + ImgFileUrl;
        }
    }
}
