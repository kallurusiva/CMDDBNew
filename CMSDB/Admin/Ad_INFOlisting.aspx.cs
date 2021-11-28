using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using System.Web.Mail;
using System.Net.Mail;
using System.Configuration;


public partial class Admin_Ad_INFOlisting : BasePage 
{

    SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;

    DataSet ds; 

    string strSQL = string.Empty;

    int qINOFid = 0; 



    protected void Page_Load(object sender, EventArgs e)
    {

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        String dbString = ConfigurationManager.AppSettings["CommonDB32"].ToString();
        dbConn = new SqlConnection(dbString);


        

        if(!IsPostBack)
        {

           // LoadPassword();

            if (Request.QueryString["qINFOid"] != null)
            {
                qINOFid = Convert.ToInt16(Request.QueryString["qINFOid"]);
                LoadInfoData(qINOFid);
            }
            else
            {
                //get the first infoid from the database. 
                CMSv3.BAL.Products objBAL_Products = new CMSv3.BAL.Products();
                ds = objBAL_Products.INFO_RetrieveAll(101,"ACTIVE");

                //int mInfoID = 0;
                String mInfoTitle = string.Empty;
                //int BtnCnt = 1;

                if (ds.Tables[0].Rows.Count > 0)
                {


                    DataRow dr = ds.Tables[0].Rows[0];
                    qINOFid = Convert.ToInt32(dr["infoID"].ToString());
                    LoadInfoData(qINOFid);
                }

            }

       

        }


    }


    protected void LoadInfoData(int qInfoID)
    {

        //if exists load Client partners Data;

        //bool tmpdisplayAtWeb;
        string tmpInfoContent = string.Empty;
        string tmpClientPartnersData = string.Empty;

        CMSv3.BAL.Products objBAL_Products = new CMSv3.BAL.Products();

        DataSet ds;
        ds = objBAL_Products.INFO_Retrieve_byInfoID(qInfoID);

        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            DataRow drInfo;

            drInfo = dt.Rows[0];

            //txtInfoTitle.Text = drInfo["infoTitle"].ToString();
            //tmpdisplayAtWeb = Convert.ToBoolean(drInfo["isDisplay"].ToString());
            //chkDisplayAtWeb.Checked = tmpdisplayAtWeb;

            tmpInfoContent = drInfo["infoContent"].ToString();

        }

        lblInfoContent.Text = tmpInfoContent; 
        

    }


}
