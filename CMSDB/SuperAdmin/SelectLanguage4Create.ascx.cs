using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

public partial class SuperAdmin_SelectLanguage4Create : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ltrShowContent.Text = Resources.LangResources.ShowContent;
        //string CurrentQuery = System.Web.HttpContext.Current.Request.Url.Query;
        //lblQuery.Text = CurrentQuery;

    }


    //protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string SelectedLanguage = string.Empty;
    //    int tmpSelLanguage = Convert.ToUInt16(ddlLanguage.SelectedValue);
    //    string CurrentPgName = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath);
    //    string CurrentQuery = System.Web.HttpContext.Current.Request.Url.Query;

    //    switch (tmpSelLanguage)
    //    {
    //        case 1: Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
    //            SelectedLanguage = GlobalVar.Lang_English;
    //            break;
    //        case 2: Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
    //            SelectedLanguage = GlobalVar.Lang_BahasaMalay;
    //            break;
    //        default: Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
    //            SelectedLanguage = GlobalVar.Lang_English;
    //            break;
    //    }

    //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(SelectedLanguage);
    //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(SelectedLanguage);
             


    //}
}
