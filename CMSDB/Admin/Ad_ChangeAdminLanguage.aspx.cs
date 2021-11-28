using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.IO;

public partial class Admin_Ad_ChangeAdminLanguage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        string QlangCode = Request.QueryString["lg"].ToString();
        string mLangCulture = string.Empty;


        switch (QlangCode)
        {
            case "1": mLangCulture = GlobalVar.Lang_English; break;
            case "2": mLangCulture = GlobalVar.Lang_BahasaMalay; break;
            case "3": mLangCulture = GlobalVar.Lang_SimplifedChinese; break; 

        }


        String selectedLanguage = string.Empty;

        Session["ADMdefLanguage"] = mLangCulture;
        //lblErrMessage.Text = "User Sucessfully Logged IN ";
        selectedLanguage = Session["ADMdefLanguage"].ToString();
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

        //Page.ClientScript.RegisterClientScriptBlock(GetType(), "SetLanguage", "alert('Note: You are Changed the default Language \n\n All the Buttons and correponding text would appear in Selected Language');", true);


        //string tmpCurrPageName = Path.GetFileNameWithoutExtension(Request.UrlReferrer.AbsolutePath);
        string tmpCurrPageName = Path.GetFileName(Request.UrlReferrer.AbsolutePath);
        
        tmpCurrPageName = tmpCurrPageName.ToLower();

        CMSv3.BAL.User objUser = new CMSv3.BAL.User();

        int upstatus = objUser.Update_AdminLanguage(Convert.ToInt16(QlangCode), Convert.ToInt32(Session["UserID"])); 


        Response.Redirect(tmpCurrPageName);


    }
}
