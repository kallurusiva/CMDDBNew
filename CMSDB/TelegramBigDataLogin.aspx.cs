using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;

public partial class TelegramBigDataLogin : System.Web.UI.Page
{
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString != null && Request.QueryString.Count > 0)
        {
            string TLoginID = Request.QueryString["TelegramID"];
            string mobile = "";
            string password = "";           

            SqlConnection dbConn = new SqlConnection(ConfigurationManager.AppSettings["CMSdb"].ToString());
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand("globalapi.dbo.USPT_Telegram_bigdatalogin", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@chatID", SqlDbType.VarChar).Value = TLoginID.ToString();
            SqlDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {
                    mobile = dbReader["login"].ToString();
                    password = dbReader["password"].ToString();
                }
            }

            dbConn.Close();

            if (mobile.ToString().Trim() == "")
            {
                //String vAlertMsg = "Invalid LoginID/Password";
                Response.Redirect("http://www.bigdatalogin.club");
            }
            else
            {
                String LoginMobileNumber = string.Empty;
                String LoginMerID = string.Empty;
                String LoginUserID = string.Empty;
                String LoginSeqNo = string.Empty;
                String bcode = string.Empty;

                newDBS objNewDB = new newDBS();
                ds = objNewDB.wassap_validateLogin(mobile, password);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    LoginMobileNumber = dr["vGenMobileNo"].ToString();
                    LoginMerID = dr["vMERID"].ToString();
                    LoginUserID = dr["vUSERID"].ToString();
                    LoginSeqNo = dr["seqno"].ToString();
                    bcode = dr["bcode"].ToString();
                }

                if (LoginMobileNumber.ToString().Trim() == "0")
                {
                    String vAlertMsg = "Invalid LoginID/Password";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
                }
                else
                {
                    Session["UserID"] = LoginUserID.ToString();
                    Session["LoginID"] = mobile.ToString();
                    Session["MobileLoginID"] = LoginMobileNumber.ToString();
                    Session["MERID"] = LoginMerID.ToString();
                    Session["LoggedInFrom"] = mobile;
                    Session["SeqNo"] = LoginSeqNo;
                    Session["bcode"] = bcode;
                    Session["menunav"] = "1";
                    Response.Redirect("~/Wassap/W_Dashboard.aspx");
                }
            }
        }
    }
}
