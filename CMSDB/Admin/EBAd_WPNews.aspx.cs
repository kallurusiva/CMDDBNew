using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EBAd_WPNews : System.Web.UI.Page
{

    DataSet ds;
    DataView dv;


    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;

    protected void Page_Load(object sender, EventArgs e)
    {

        #region session check

        if ((Session["UserID"] == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 


        if(!IsPostBack)
        {

            int vID = 3;
            String strPageID = string.Empty;

            if (Request.QueryString != null && Request.QueryString.Count > 0)
            {
                strPageID = Request.QueryString["qInfoId"].ToString();
            }

            if (strPageID != "")
            {
                vID = Convert.ToInt32(strPageID);
            }

            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "DateCreated";
            ViewState["SearchStr"] = "";

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString(), ViewState["SearchStr"].ToString());


          //  PopulateContent(vID);
        }


    }


   //// protected void PopulateContent(int qInfoID)
   // {


   //     DataSet ds;
   //     CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

   //     ds = objEbook.WpNews_ListByUID(qInfoID, "EDIT"); 
        

   //     DataTable dt = ds.Tables[0];

   //     if (dt.Rows.Count > 0)
   //     {
   //         DataRow drInfo;

   //         drInfo = dt.Rows[0];

   //         //txtInfoTitle.Text = drInfo["PageTitle"].ToString();
   //         //tmpInfoContent = drInfo["PageContent"].ToString();
   //         //tmpdisplayAtWeb = Convert.ToBoolean(drInfo["isDisplay"].ToString());

   //         //chkDisplayAtWeb.Checked = tmpdisplayAtWeb;

   //         lblContent.Text = drInfo["Content"].ToString();

   //     }
   // }


   protected void PopulateGrid(string vSortExpr, string vSortDir, String vSearchStr)
    {

        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        ds = objEbook.WpNews_ListByUID(0, "LIST"); 
       
        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {

                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


            GridNews.DataSource = dv;
            GridNews.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            GridNews.DataSource = ds;
            GridNews.DataBind();

            int ColCount = GridNews.Rows[0].Cells.Count;
            GridNews.Rows[0].Cells.Clear();
            GridNews.Rows[0].Cells.Add(new TableCell());
            GridNews.Rows[0].Cells[0].ColumnSpan = ColCount;
            GridNews.Rows[0].Cells[0].Text = "No records Found";
            GridNews.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




        }



    }





    protected void GridNews_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_SortExpr = e.SortExpression;
        m_SortDir = e.SortDirection;

        ViewState["SortExpr"] = m_SortExpr;

        PopulateGrid(m_SortExpr, sortOrder, ViewState["SearchStr"].ToString());
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

    protected void GridNews_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hyp1 = (HyperLink)e.Row.FindControl("HypReadMore");
            HiddenField hdnUID = ((HiddenField)e.Row.FindControl("hdnUID"));

            hyp1.NavigateUrl = "javascript:OpenWindow('" + hdnUID.Value.ToString() + "')";
        }
    }  





}