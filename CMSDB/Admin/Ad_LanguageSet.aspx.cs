using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Globalization;

public partial class Admin_Ad_LanguageSet : BasePage
{
    string strSQL=string.Empty;
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataAdapter dbAdap;

    DataSet ds;
    DataTable dtLanguages;
    DataTable dtSetLanguage;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 
        
        ltrSetDefaultLanguage.Text = Resources.LangResources.Set + " " + "Defualt " + Resources.LangResources.Language;
        ltrNoteLanguage.Text = "1. When Language is set, All the buttons including the Admin Buttons will be Converted to the Selected Language. <br/>" +
                               "2. Website will appear in Selected Language. <br/>" +
                               "3. Only Selected language items will appear for the Faq, Testimonial, News, Events, Products etc., <br/>";
        ltrNote.Text = Resources.LangResources.Note;

        if (!IsPostBack)
        {
            if (Request.QueryString["LangChanged"] != null)
            {
                if(Request.QueryString["LangChanged"] == "true")
                {
                   Page.ClientScript.RegisterClientScriptBlock(GetType(), "SetLanguage", "alert('Note: You have Changed your default Language setting \\n\\n All the Buttons and correponding text would appear in Selected Language')", true);
                   // Page.ClientScript.RegisterClientScriptBlock(GetType(), "SetLanguage", "alert('Selected Language')", true);
              
                }
            }
            LoadLanguages();
        }

    }

    protected void LoadLanguages()
    {

        
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            strSQL = "select LangID,LangCode, LangName,LangCulture from tblLanguages where Deleted = 0 ;";
            strSQL = strSQL + "select LanguageCode from tblHomePageSettings where UserId =" + Convert.ToInt32(Session["UserID"]);


            dbCmd = new SqlCommand(strSQL, dbConn);

            dbAdap = new SqlDataAdapter(dbCmd);
            ds = new DataSet();
            dbAdap.Fill(ds);

            dtLanguages = ds.Tables[0];
            dtSetLanguage = ds.Tables[1];

            string tmpSetLanguage = dtSetLanguage.Rows[0][0].ToString();

            rdoBtnList_Language.DataSource = dtLanguages;
            rdoBtnList_Language.DataTextField = "LangName";
            rdoBtnList_Language.DataValueField = "LangCode";
            rdoBtnList_Language.DataBind();


            foreach (ListItem ckL in rdoBtnList_Language.Items)
            {
                if (ckL.Value == tmpSetLanguage)
                {
                    ckL.Selected = true;
                }

            }



        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }


    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        string mSelValue = rdoBtnList_Language.SelectedValue;


        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            //strSQL = "select LangID,LangCode, LangName,LangCulture from tblLanguages where Deleted = 0 ;";
            //strSQL = strSQL + "select LanguageCode from tblHomePageSettings where UserId =" + Convert.ToInt32(Session["UserID"]);

            strSQL = "Update tblHomePageSettings set LanguageCode = " + mSelValue + " where UserID = " + Convert.ToInt32(Session["UserID"]);
            dbCmd = new SqlCommand(strSQL, dbConn);
            int upStatus = dbCmd.ExecuteNonQuery();

            strSQL = "Select LanguageCode, LangName,LangCulture from tblHomePageSettings Hp " +
                    "Inner Join tblLanguages L ON Hp.LanguageCode = L.LangCode " +
                    "Where Hp.UserId = " + Convert.ToInt32(Session["UserID"]);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbAdap = new SqlDataAdapter(dbCmd);
            ds = new DataSet();
            dbAdap.Fill(ds);

            String mLangCulture = ds.Tables[0].Rows[0][2].ToString();


            String selectedLanguage = string.Empty;
            Session["defLanguage"] = mLangCulture;
            //lblErrMessage.Text = "User Sucessfully Logged IN ";
            selectedLanguage = Session["defLanguage"].ToString();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

            //Page.ClientScript.RegisterClientScriptBlock(GetType(), "SetLanguage", "alert('Note: You are Changed the default Language \n\n All the Buttons and correponding text would appear in Selected Language');", true);
                        
            Response.Redirect("Ad_LanguageSet.aspx?LangChanged=true");

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }

    }
}
