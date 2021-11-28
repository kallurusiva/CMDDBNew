using System;
using System.Collections.Generic;
using System.Web;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


/// <summary>
/// Summary description for UserWeb
/// </summary>
public class MobiBase : System.Web.UI.Page
{
    public MobiBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected override void InitializeCulture()
    {
        //retrieve culture information from session  
        // string culture = Convert.ToString(Session["MyCulture"]);

        #region  // SessionCheck
        if ((Session["defLanguage"].ToString() == null) || (Session["defLanguage"].ToString() == ""))
        {
            Response.Redirect("~/mb/index.aspx");
        }
        #endregion 

        string selectedLanguage;

        if (Session["defLanguage"] != null)
            selectedLanguage = Session["defLanguage"].ToString();
        else
            selectedLanguage = "en-US";


        //UICulture = selectedLanguage;
        //Culture = selectedLanguage;
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
        //}

        //call base class  
        base.InitializeCulture();
    }


    protected override void OnPreInit(EventArgs e)
    {
       
        //if (Session["MasterPageFile"] == null)
        //{
        //    string strSQL = "Select MasterPageName from tblUserMasterPage where UserId = " + Convert.ToInt32(Session["ClientID"]);

        //    SqlConnection dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        //    dbConn.Open();
        //    SqlCommand dbCmd = new SqlCommand(strSQL, dbConn);
        //    string masterfile = Convert.ToString(dbCmd.ExecuteScalar());
        //    dbConn.Close();

        //    if (!masterfile.Equals(string.Empty))
        //    {
        //        base.MasterPageFile = masterfile;
        //        Session["MasterPageFile"] = masterfile;

        //    }

        //}
        //else
        //{
        //    base.MasterPageFile = Session["MasterPageFile"].ToString();
        //}

      //  base.MasterPageFile = "MbAnchorImg.master";
     //   base.OnInit(e);

    }
}
