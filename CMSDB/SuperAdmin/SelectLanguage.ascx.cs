using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

public partial class SuperAdmin_SelectLanguage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ltrShowContent.Text = Resources.LangResources.ShowContent;
        //string CurrentQuery = System.Web.HttpContext.Current.Request.Url.Query;
        //lblQuery.Text = CurrentQuery;

    }


    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        string SelectedLanguage = string.Empty;
        int tmpSelLanguage = Convert.ToUInt16(ddlLanguage.SelectedValue);
        string CurrentPgName = System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath);
        string CurrentQuery = System.Web.HttpContext.Current.Request.Url.Query;
        string tmpPageUrl = string.Empty;

        if (CurrentQuery.Contains("?"))
        {
            if (CurrentQuery.Contains("&"))
            {
                int idxUpto = CurrentQuery.IndexOf("&");
                tmpPageUrl = CurrentQuery.Substring(0, idxUpto);
                CurrentPgName = CurrentPgName + tmpPageUrl;
                Response.Redirect(CurrentPgName + "&LgType=" + tmpSelLanguage);
            }
            else if (CurrentQuery.Contains("?LgType"))
            {
                Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
            }
            else
            {
                CurrentPgName = CurrentPgName + CurrentQuery;
                Response.Redirect(CurrentPgName + "&LgType=" + tmpSelLanguage);
            }
        }
        else
        {
            Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
        }

        

        //switch (tmpSelLanguage)
        //{
        //    case 1: Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
        //        SelectedLanguage = GlobalVar.Lang_English;
        //        break;
        //    case 2: Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
        //        SelectedLanguage = GlobalVar.Lang_BahasaMalay;
        //        break;
        //    default: Response.Redirect(CurrentPgName + "?LgType=" + tmpSelLanguage);
        //        SelectedLanguage = GlobalVar.Lang_English;
        //        break;
        //}

        //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(SelectedLanguage);
        //Thread.CurrentThread.CurrentUICulture = new CultureInfo(SelectedLanguage);
             


    }
}
