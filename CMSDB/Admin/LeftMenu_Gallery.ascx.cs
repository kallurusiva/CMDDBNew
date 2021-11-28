using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_LeftMenu_Events : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        HypImagesGallery.Text = Resources.LangResources.ImageGallery;
        HypVideoGallery.Text =  Resources.LangResources.VideoGallery;

        //HypAdminEvents.Text = "Admin " + Resources.LangResources.Events;
        //HypShowALL.Text = Resources.LangResources.Showall;
    
    }
}
