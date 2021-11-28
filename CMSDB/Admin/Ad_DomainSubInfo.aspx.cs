using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
//using System.Web.Mail;
using System.Net.Mail;
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;




public partial class Ad_DomainSubInfo : BasePage 
{

    //SqlConnection dbConn;
    //SqlCommand dbCmd;
    //SqlDataReader dbReader;
    //SqlDataAdapter dbAdap;


    //SqlConnection IFM32_dbConn;
    //SqlCommand IFM32_dbCmd;
    //SqlDataReader IFM32_dbReader;
    //SqlDataAdapter IFM32_dbAdapter;

    DataSet ds;
    //DataSet ds1; 


    string strSQL = string.Empty;
    string tmpDomainType = string.Empty;
    string tmpSubDomain = string.Empty;
    string tmpSubDomainLink = string.Empty;
    int DefAnchorDomainID; 

    String m_SortExpr = string.Empty;
    //SortDirection m_SortDir = SortDirection.Ascending;

    CMSv3.BAL.Domains objBAL_Domains = new CMSv3.BAL.Domains();

    protected void Page_Load(object sender, EventArgs e)
    {


       

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        
        if(!IsPostBack)
        {

            LoadSubDomainInfo();
        }


    }

    protected void LoadSubDomainInfo()
    {

        ds = objBAL_Domains.Retrieve_SubDomainInfo(Convert.ToInt32(Session["UserID"]));

        foreach (DataRow dtRow in ds.Tables[0].Rows)
        {
            tmpSubDomain = dtRow["SubDomain"].ToString();
            DefAnchorDomainID = Convert.ToInt32(dtRow["DefAnchorDomainID"].ToString());
            String tmpAnchorDomain = dtRow["Anchordomain"].ToString();
            String tmpIndustry = dtRow["Industry"].ToString();
            String tmpURL = tmpSubDomain + "." + tmpAnchorDomain;

            ViewState["SubDomainName"] = tmpSubDomain;
            lblCurrentSubdomain.Text = tmpSubDomain;
            lblCompleteSubDomainURL.Text = "<a href='http://" + tmpURL + "' target='_blank'>" + tmpURL + "</a>";
            LoadCategories(DefAnchorDomainID); 
        }


    }


    protected void LoadCategories(int vAnchorID)
    {
        
        DataSet dsCat;
        DataView dvCat;

        dsCat = objBAL_Domains.Retrieve_AncDomainsByIndustry(); 
        dvCat = dsCat.Tables[0].DefaultView;


        ddlAnchorDomains.DataSource = dsCat;
        ddlAnchorDomains.DataTextField = "AncIndustry";
        ddlAnchorDomains.DataValueField = "TID";
        ddlAnchorDomains.DataBind();

      //  ddlAnchorDomains.Items.Insert(0, new ListItem("Select AnchorDomain (Industry)", "0"));

        if (vAnchorID != 0)
        {
            ddlAnchorDomains.SelectedValue = vAnchorID.ToString();
        }


    }

  
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        int SelAnchorDomainID = Convert.ToInt32(ddlAnchorDomains.SelectedValue);
        string SelAnchorDomainText = ddlAnchorDomains.SelectedItem.Text;

        int uStatus = objBAL_Domains.Update_DefaultAncDomainID(Convert.ToInt32(Session["UserID"]), SelAnchorDomainID);

        if (uStatus >= 1)
        {
            CommonFunctions.AlertMessage(@"Default Anchor Domain Changed to  \n\n" + SelAnchorDomainText);

            String tmpAncDomain = SelAnchorDomainText;
            int GetFirstSlashidx = tmpAncDomain.IndexOf(@"(");
            if (GetFirstSlashidx > 0)
                tmpAncDomain = tmpAncDomain.Substring(0, GetFirstSlashidx);

            String tmpAncURL = ViewState["SubDomainName"].ToString() + "." + tmpAncDomain; 
            
            Label objlblMaster_AncURL = (Label)Page.Master.FindControl("lblUserURL");
            objlblMaster_AncURL.Text = @"<a target='_blank' class='links_DomainName' alt='Click to Open the Website' href='http://" + tmpAncURL + "'>" + tmpAncURL + "</a>" + " <br />";
           // objlblMaster_AncURL.Text = lblCompleteSubDomainURL.Text;
            LoadSubDomainInfo(); 


        }
        else
        {
            CommonFunctions.AlertMessage("Default Anchor Domain Could not be Changed. Please contact Administrator.");
        }

    }
}
