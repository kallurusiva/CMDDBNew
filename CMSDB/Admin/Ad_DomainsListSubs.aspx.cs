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




public partial class Ad_DomainsListSubs : BasePage 
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataReader dbReader;
    SqlDataAdapter dbAdap;


    //SqlConnection IFM32_dbConn;
    //SqlCommand IFM32_dbCmd;
    //SqlDataReader IFM32_dbReader;
    //SqlDataAdapter IFM32_dbAdapter;

    DataSet ds; 

    string strSQL = string.Empty;
    string tmpDomainType = string.Empty;
    string tmpSubDomainLink = string.Empty;

    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;


    protected void Page_Load(object sender, EventArgs e)
    {


       

        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        #endregion 

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);
        //IFM32_dbConn = new SqlConnection(GlobalVar.Get_IFM_DbConnString);

        

        if(!IsPostBack)
        {

            ViewState["sortOrder"] = "asc";
            ViewState["SortExpr"] = "CategoryID";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }


    }




    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {



        String tmpUserMobileNo = string.Empty;
        String tmpUserAccountType = string.Empty;
      
        StringBuilder sb = new StringBuilder(); 
       

        try
        {
            dbConn.Open();
            strSQL = "EXEC [usp_Retreive_DomainDetails] " + Convert.ToInt32(Session["UserID"]);

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbReader = dbCmd.ExecuteReader();

            if (dbReader.HasRows)
            {
                while (dbReader.Read())
                {

                    tmpDomainType = dbReader["UserDomainType"].ToString().Trim();
                    tmpSubDomainLink = dbReader["SubDomain"].ToString();
                    //tmpSubDomainLink = dbReader["SubDomain"].ToString() + "." + GlobalVar.GetAnchorDomainName;
                }
            }


            dbConn.Close();
            dbConn.Open();
            //strSQL = "EXEC [USP_Retrieve_AnchorDomains] 1";
            //dbCmd = new SqlCommand(strSQL, dbConn);


            dbCmd = new SqlCommand("[USP_Retrieve_AnchorDomains]", dbConn);
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Parameters.Add("@vDisplay", SqlDbType.Int).Value = 1;

            dbAdap = new SqlDataAdapter(dbCmd);
            ds = new DataSet();
            dbAdap.Fill(ds);

                
            //rpFaqList.DataSource = ds;
            //rpFaqList.DataBind();
            gridAnchorDomains.DataSource = ds;
            gridAnchorDomains.DataBind(); 


            int cn = ds.Tables[0].Rows.Count;

            //dbConn.Close();
            //IFM32_dbReader.Close(); 

            //MergeRows(gridAnchorDomains);


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



    protected void rpFaqList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            HiddenField objHidDomainName = (HiddenField)e.Item.FindControl("HidDomainName");
            Literal objLtrDomainName = (Literal)e.Item.FindControl("ltrDomainName");

            String tempLink = string.Empty;
            if (objLtrDomainName != null)
            {
                tempLink = "http://" + tmpSubDomainLink + "." + objLtrDomainName.Text;
                objLtrDomainName.Text = "<a class='links_AnchorDomains2' target='_blank' href='" + tempLink + "'>" + tempLink + "</a>";
            }

        }


    }



    protected void gridAnchorDomains_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridAnchorDomains.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridAnchorDomains.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridAnchorDomains.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridAnchorDomains.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void gridAnchorDomains_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;

        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    public string sortOrder
    {
        get
        {
            if (ViewState["sortOrder"].ToString() == "desc")
            {
                ViewState["sortOrder"] = "asc";

            }
            else
            {
                ViewState["sortOrder"] = "desc";
            }

            return ViewState["sortOrder"].ToString();
        }
        set
        {
            ViewState["sortOrder"] = value;
        }
    }


    protected void gridAnchorDomains_DataBound(object sender, EventArgs e)
    {

        //CommonFunctions.InitialiseGridViewPagerRow(gridAnchorDomains.BottomPagerRow, gridAnchorDomains);
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridAnchorDomains.BottomPagerRow, gridAnchorDomains);

        //for (int rowIndex = gridAnchorDomains.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        //{
        //    GridViewRow row = gridAnchorDomains.Rows[rowIndex];
        //    GridViewRow previousRow = gridAnchorDomains.Rows[rowIndex + 1];

        //    for (int i = 0; i < row.Cells.Count; i++)
        //    {
        //        if (row.Cells[i].Text == previousRow.Cells[i].Text)
        //        {
        //            row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
        //                                   previousRow.Cells[i].RowSpan + 1;
        //            previousRow.Cells[i].Visible = false;
        //        }
        //    }
        //}

    }

    //protected void gridAnchorDomains_PreRender(object sender, EventArgs e)
    //{
    //    MergeRows(gridAnchorDomains);
    //}

     protected void gridAnchorDomains_PreRender(object sender, EventArgs e)
    {
       //MergeRows(gridAnchorDomains);
    }

    public static void MergeRows(GridView gridAnchorDomains)
    {
        for (int rowIndex = gridAnchorDomains.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gridAnchorDomains.Rows[rowIndex];
            GridViewRow previousRow = gridAnchorDomains.Rows[rowIndex + 1];

            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (row.Cells[i].Text == previousRow.Cells[i].Text)
                {
                    row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                           previousRow.Cells[i].RowSpan + 1;
                    previousRow.Cells[i].Visible = false;
                }
            }
        }
    }

    protected void gridAnchorDomains_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Literal objLtrSubDomain = (Literal)e.Row.FindControl("ltrSubDomain");
            Literal objLtrltrSubDomainURLlink = (Literal)e.Row.FindControl("ltrSubDomainURLlink");
            HiddenField objhdAnchorDomain = (HiddenField)e.Row.FindControl("hdAnchorDomain"); 

            objLtrSubDomain.Text = tmpSubDomainLink;

            string tempLink = "http://" + tmpSubDomainLink + "." + objhdAnchorDomain.Value;
             objLtrltrSubDomainURLlink.Text = "<a class='links_AnchorDomains2' target='_blank' href='" + tempLink + "'>" + tempLink + "</a>";

             Literal objSampleWebsite = (Literal)e.Row.FindControl("ltrSampleWebsite"); 
            String tmpSampleWebStr = objSampleWebsite.Text;
            if(tmpSampleWebStr.Contains("http://"))
                objSampleWebsite.Text = "<a class='links_AnchorDomains2' target='_blank' href='" + tmpSampleWebStr + "'>" + tmpSampleWebStr + "</a>";
            else
                objSampleWebsite.Text = "<a class='links_AnchorDomains2' target='_blank' href='" + "http://" + tmpSampleWebStr + "'>" + tmpSampleWebStr + "</a>";

        }
    }

}
