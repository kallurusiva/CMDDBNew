using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class M2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        string strUserAgent = Request.UserAgent;
        LabelManufacturer.Text = "Manufacturer : " + Request.Browser.MobileDeviceManufacturer;
        LabelModel.Text = "Model : " + Request.Browser.MobileDeviceModel;
        LabelScreen.Text = "Screen : " + Request.Browser.ScreenPixelsWidth.ToString() + " x " + Request.Browser.ScreenPixelsHeight.ToString();
        lblUserAgent.Text = strUserAgent;


        if (CommonFunctions.IsMobile())
            lblResult.Text = "Result : Would be redirected a Mobile web page version";
        else
            lblResult.Text = "Result : This is a normal web page";


    }
}
