using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CMSv3.BAL;
using System.IO;
using System.Text;

public partial class Admin_Ad_FeedBackListing : BasePage
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataAdapter dbAdap;

    DataSet ds;
    DataView dv;

    string strSQL;

    //CMSv3.BAL.Faq objBAl_Faq = new CMSv3.BAL.Faq();
    CMSv3.BAL.FAQ objBAL_Faq = new CMSv3.BAL.FAQ();
    //int qLgType = 0;

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


        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "desc";
            ViewState["SortExpr"] = "row";

            #region Setting ViewState for Retrieval Type -- USER , ADMIN or ALL


            if (Request.QueryString["RtType"] != null)
            {

                switch (Request.QueryString["RtType"].ToString())
                {
                    case "USER": ViewState["RtType"] = "USER";
                        break;
                    case "ADMIN": ViewState["RtType"] = "ADMIN";
                        break;
                    case "ALL": ViewState["RtType"] = "ALL";
                        break;
                    default: ViewState["RtType"] = "USER";
                        break;
                }
            }
            else
            {
                ViewState["RtType"] = "USER";
            }

            #endregion

            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }
        else
        {

        }

        tblMessageBar.Visible = false;
    }

    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {
        strSQL = "EXEC esms.dbo.getGeedbackList " + Session["LoginID"].ToString();

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();
            dbCmd = new SqlCommand(strSQL, dbConn);

            dbAdap = new SqlDataAdapter(dbCmd);
            ds = new DataSet();
            dbAdap.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dv = ds.Tables[0].DefaultView;
                if (vSortExpr != string.Empty)
                {
                    dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
                }
                gridEmailList.DataSource = dv;
                gridEmailList.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

                gridEmailList.DataSource = ds;
                gridEmailList.DataBind();

                int ColCount = gridEmailList.Rows[0].Cells.Count;
                gridEmailList.Rows[0].Cells.Clear();
                gridEmailList.Rows[0].Cells.Add(new TableCell());
                gridEmailList.Rows[0].Cells[0].ColumnSpan = ColCount;
                gridEmailList.Rows[0].Cells[0].Text = "No records Found";
                gridEmailList.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;
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

    protected void gridEmailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridEmailList.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (gridEmailList.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < gridEmailList.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    gridEmailList.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }

    protected void gridEmailList_Sorting(object sender, GridViewSortEventArgs e)
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

    protected void gridEmailList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }

    protected void gridEmailList_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(gridEmailList.BottomPagerRow, gridEmailList);
    }

    

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    private void PrepareGridViewForExport(Control gv)
    {
        LinkButton lb = new LinkButton();
        Literal l = new Literal();
        string name = String.Empty;
        for (int i = 0; i < gv.Controls.Count; i++)
        {
            if (gv.Controls[i].GetType() == typeof(LinkButton))
            {
                l.Text = (gv.Controls[i] as LinkButton).Text;
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            else if (gv.Controls[i].GetType() == typeof(DropDownList))
            {
                l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            else if (gv.Controls[i].GetType() == typeof(CheckBox))
            {
                l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";
                gv.Controls.Remove(gv.Controls[i]);
                gv.Controls.AddAt(i, l);
            }
            if (gv.Controls[i].HasControls())
            {
                PrepareGridViewForExport(gv.Controls[i]);
            }
        }
    }


}
