using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_Ad_SystemNewsPopUp : System.Web.UI.Page
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;


    string strSQL = string.Empty;
    string qNewsID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region Rendering Languague resource
        lblsystemNews.Text = Resources.LangResources.SystemNews;
        lblPostedonHead.Text = Resources.LangResources.Postedon;

      


        #endregion


        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        if (Request.QueryString["NewsID"].ToString() != "")
            qNewsID = Request.QueryString["NewsID"].ToString();



        if (!IsPostBack)
        {
            LoadNewsContent();
        }
    }

    protected void LoadNewsContent()
    {

        strSQL = "EXEC [usp_SystemNews_Retrieve_BySysNewsID] " + qNewsID;

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

                    lblNewsSubject.Text = dbReader["subject"].ToString();
                    String tmpContent = dbReader["Contents"].ToString();
                    //tmpContent = tmpContent.Replace("<br/>", Environment.NewLine);
                    tmpContent = tmpContent.Replace(Environment.NewLine,"<br/>");
                    lblNewsContent.Text = tmpContent;

                    lblPostedonText.Text = dbReader["CreatedDate"].ToString();

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

    }



}


