using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class faqTemplate : System.Web.UI.Page
{

    SqlConnection dbconn;
    SqlCommand dbcmd;
    SqlDataAdapter dbadap;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {

        dbconn = new SqlConnection(GlobalVar.GetDbConnString);
        dbconn.Open();

        string strSQL = "select FaqID,FaqQuestion,FaqAnswer,faqModifiedDate,Active, Priority " + 
             "from tblFAq where userId = 104 and Active = 1 Order by Priority";

        dbcmd = new SqlCommand(strSQL, dbconn);
        dbadap = new SqlDataAdapter(dbcmd);
        ds = new DataSet();
        dbadap.Fill(ds);

        rpFaqList.DataSource = ds;
        rpFaqList.DataBind();



    }
}
