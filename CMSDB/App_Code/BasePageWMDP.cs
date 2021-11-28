using System;
using System.Collections.Generic;
using System.Web;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for BasePageWMDP
/// </summary>
public class BasePageWMDP : System.Web.UI.Page
{
	public BasePageWMDP()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    protected override void InitializeCulture()
    {
        //retrieve culture information from session  
        // string culture = Convert.ToString(Session["MyCulture"]);

        string selectedLanguage = string.Empty;

        if (Session["ADMdefLanguage"] != null)
        {
            selectedLanguage = Session["ADMdefLanguage"].ToString();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
        }
        else
        {
            //   selectedLanguage = "en-US";


            //UICulture = selectedLanguage;
            //Culture = selectedLanguage;
            // Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);
            //}

            #region .... Setting up Default language

            SqlConnection dbConn;
            SqlCommand dbCmd;
            SqlDataReader dbReader;

            string tmpAdminLanguageCode = string.Empty;


            //string tmpLangCode = Session["ADMdefLanguage"].ToString(); 


            string strSQL = "EXEC Usp_CMS_GetUserDetailsByUserID " + Convert.ToInt32(Session["UserID"]);

            dbConn = new SqlConnection(GlobalVar.GetDbConnString);

            try
            {
                dbConn.Open();
                dbCmd = new SqlCommand(strSQL, dbConn);
                dbReader = dbCmd.ExecuteReader();

                if (dbReader.HasRows)
                {
                    while (dbReader.Read())
                    {

                        tmpAdminLanguageCode = dbReader["AdminLanguage"].ToString();
                    }

                }

            }
            
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }



            //String selectedLanguage = string.Empty;
            String mLangCulture = string.Empty;

            switch (tmpAdminLanguageCode)
            {
                case "1": mLangCulture = GlobalVar.Lang_English; break;
                case "2": mLangCulture = GlobalVar.Lang_BahasaMalay; break;
                case "3": mLangCulture = GlobalVar.Lang_SimplifedChinese; break;
                default: mLangCulture = GlobalVar.Lang_English; break;

            }


            Session["ADMdefLanguage"] = mLangCulture;
            //lblErrMessage.Text = "User Sucessfully Logged IN ";
            selectedLanguage = Session["ADMdefLanguage"].ToString();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(selectedLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedLanguage);

            #endregion
        }
        //call base class  
        base.InitializeCulture();
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);



        #region Session Check Commented


        //check to see if the Session is null (doesnt exist)
        if (Context.Session != null)
        {

            //check the IsNewSession value, this will tell us if the session has been reset.
            //IsNewSession will also let us know if the users session has timed out
            if (Session.IsNewSession)
            {

                //now we know it's a new session, so we check to see if a cookie is present
                string cookie = Request.Headers["Cookie"];

                //now we determine if there is a cookie does it contains what we're looking for
                if ((null != cookie) && (cookie.IndexOf("ASP.NET_SessionId") >= 0))
                {

                    //since it's a new session but a ASP.Net cookie exist we know
                    //the session has expired so we need to redirect them
                    CAllSessionError();
                    // Response.Redirect("~/Default.aspx?timeout=yes&success=no");
                    Response.Redirect("~/SessionExpireWMDP.aspx");

                }
            }
        }


        ////check to see if the Session is null (doesnt exist)
        //if (Context.Session != null)
        //{

        //    //check the IsNewSession value, this will tell us if the session has been reset.
        //    //IsNewSession will also let us know if the users session has timed out
        //    if (Session.IsNewSession)
        //    {

        //        //now we know it's a new session, so we check to see if a cookie is present
        //        string cookie = Request.Headers["Cookie"];

        //        //now we determine if there is a cookie does it contains what we're looking for
        //        if ((null != cookie) && (cookie.IndexOf("ASP.NET_SessionId") >= 0))
        //        {

        //            //since it's a new session but a ASP.Net cookie exist we know
        //            //the session has expired so we need to redirect them
        //            Response.Redirect("~/Default.aspx?timeout=yes&success=no");

        //        }
        //    }
        //}

        #endregion

    }

    protected void CAllSessionError()
    {

        string errMessage = string.Empty;

        System.Exception appException = new System.Exception();
        appException = Server.GetLastError();



    }

}