using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EBAd_BankInSlipShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if(Request.QueryString.Count>0)
        {
            String qImageName = Request.QueryString["qImage"];


            String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();
            //instead of server.mapPath set the path in web.config file and use that path.
            String ImgFileUrl = Server.MapPath("~") + tmpImageFolder + "BankInSlips/";

            ImgBankInSlip.ImageUrl =  tmpImageFolder + "BankInSlips/" + qImageName;
        
        //http://localhost:52512/DocumentRepository/eBookImages/BankInSlips/5002_Button Log Off.png
        //    D:\HostingSpaces\globaluser1\1worldsms.com\wwwroot\/DocumentRepository/eBookImages/BankInSlips/648_tp1.jpg"


        }


    }
}