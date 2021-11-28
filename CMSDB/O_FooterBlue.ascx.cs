using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class O_FooterBlue : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        newDBS ndbsP = new newDBS();
        string fbID = ndbsP.getFaceBookID(Session["ClientID"].ToString());
        fblink.HRef = "http://www.facebook.com/" + fbID.ToString(); 
    }
}