using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class N_usersOwnPage : System.Web.UI.Page
{
    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;

    String strSQL = string.Empty;
    int qButtonNo = 0;
    string qButtonText = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int vUserId = Convert.ToInt32(Session["ClientID"]);
            int vLangType = 1;
            if (Request.QueryString["LgType"] != null)
            {
                vLangType = Convert.ToUInt16(Request.QueryString["LgType"]);
                // ddlLanguage.SelectedValue = Convert.ToString(vLangType);
            }

            if (Request.QueryString["BN"] != null)
            {
                //qButtonNo = Convert.ToInt16(Request.QueryString["ButtonNo"]);
                qButtonText = HttpUtility.UrlDecode(Request.QueryString["BN"].ToString());
            }

            if (Request.QueryString["Bt"] != null)
            {
                //qButtonNo = Convert.ToInt16(Request.QueryString["ButtonNo"]);
                qButtonNo = Convert.ToInt16(Request.QueryString["Bt"]);
            }
            LoadData_ByButtonName(vLangType, qButtonText, qButtonNo);
        }
    }

    protected void LoadData_ByButtonName(int vLangType, string vButtonText, int vButtonNo)
    {
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        dbConn.Open();
        String tmpUserContent = string.Empty;
        vButtonText = vButtonText.Replace("'", "''");
        strSQL = "EXEC  [usp_UserOwnPage_Retrieve_ByButtonName] " + Convert.ToInt32(Session["ClientID"]) + ",N'" + vButtonText + "'," + vButtonNo;
        dbCmd = new SqlCommand(strSQL, dbConn);
        dbReader = dbCmd.ExecuteReader();
        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                tmpUserContent = dbReader["UserPageContent"].ToString();
            }
        }
        else
        {
            tmpUserContent = "<br> No Content has been added yet. To Create, click on the Add the content";
        }

        dbConn.Close();
        lblUserContent.Text = tmpUserContent;
    }

}