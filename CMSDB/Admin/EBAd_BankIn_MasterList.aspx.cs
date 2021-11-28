using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

public partial class EBAd_BankIn_MasterList : System.Web.UI.Page 
{

    DataSet ds;
    DataView dv;
    String m_SortExpr = string.Empty;
    SortDirection m_SortDir = SortDirection.Ascending;


    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
   

    protected void Page_Load(object sender, EventArgs e)
    {
        #region session check 

        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 


       

        if (!IsPostBack)
        {
            ViewState["sortOrder"] = "";
            ViewState["SortExpr"] = "";

            
            PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
        }

        tblMessageBar.Visible = false;
        MaintainScrollPositionOnPostBack = true; 
    }

    
    protected void PopulateGrid(string vSortExpr, string vSortDir)
    {

        ds = objEbook.BankIn_GetList(""); 

        if (ds.Tables[0].Rows.Count > 0)
        {

            dv = ds.Tables[0].DefaultView;
            if (vSortExpr != string.Empty)
            {
                dv.Sort = string.Format("{0} {1}", vSortExpr, vSortDir);
            }


            // dv.Sort = string.Format("{0},{1}", m_SortExpr, m_SortDir);


            GridBanks.DataSource = dv;
            GridBanks.DataBind();
        }
        else
        {
            DataTable dt = new DataTable();
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());

            GridBanks.DataSource = ds;
            GridBanks.DataBind();

            int ColCount = GridBanks.Rows[0].Cells.Count;
            GridBanks.Rows[0].Cells.Clear();
            GridBanks.Rows[0].Cells.Add(new TableCell());
            GridBanks.Rows[0].Cells[0].ColumnSpan = ColCount;
            GridBanks.Rows[0].Cells[0].Text = "No records Found";
            GridBanks.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Left;




        }



    }


    protected void GridBanks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridBanks.PageIndex = e.NewPageIndex;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }



    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (GridBanks.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < GridBanks.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    GridBanks.PageIndex = pageNumberDropDownList.SelectedIndex;
                    PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
                }
            }
        }
    }


    protected void GridBanks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridBanks.EditIndex = -1;
        PopulateGrid(ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString());
    }

   

    protected void GridBanks_DataBound(object sender, EventArgs e)
    {
        CommonFunctions.InitialiseGridViewPagerRowWithImages(GridBanks.BottomPagerRow, GridBanks);
    }


    protected void GridBanks_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {

            //CheckBox objChkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            //objChkSelectAll.Attributes.Add("onClick", "SelectAll('" + objChkSelectAll.ClientID + "')");

            ////To get the up/down image at the sorted column 
            //CommonFunctions.GetSortedImage(e.Row, ViewState["SortExpr"].ToString(), ViewState["sortOrder"].ToString()); 

        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
     
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D6E0C1';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");




            //.. getting reference the gridview row in row databound event. 
            string strLoginName = string.Empty;
            DataRowView rowView = (DataRowView)e.Row.DataItem;

            String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();


            Literal objLtrCountryName = (Literal)e.Row.FindControl("LtrCountryName");


            if (objLtrCountryName.Text != "")
            {
                Image objImgCountry = (Image)e.Row.FindControl("ImgCountry");
                if (objImgCountry != null)
                    objImgCountry.ImageUrl = @"\eBookAdminX\Images\Flags\48\" + objLtrCountryName.Text + ".png";
            }



            Literal objLtrBankLogo = (Literal)e.Row.FindControl("LtrBankLogo");


            if (objLtrBankLogo.Text != "")
            {
                Image objImgBankLogo = (Image)e.Row.FindControl("ImgBankLogo");
                if (objImgBankLogo != null)
                    objImgBankLogo.ImageUrl = tmpImageFolder + "BankLogos/" + objLtrBankLogo.Text;
            }

           
                
                


            }

          
        }
        

 

    protected void GridBanks_Sorting(object sender, GridViewSortEventArgs e)
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


    protected void Button_View(object sender, CommandEventArgs e)
    {
        string s = e.CommandArgument.ToString();

        string[] strInfo = s.Split(',');

        for (int i = 0; i < strInfo.Length; i++)
        {
            HdEditBookUID.Value = strInfo[0];
            HdEditBookID.Value = strInfo[1];

            
        }

       // Response.Redirect(@"EBAd_FreeEbookEdit.aspx"); 

       Server.Transfer(@"EBAd_FreeEbookEdit.aspx");
    }

    protected void GridBanks_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "EditByUser")
        {
           // grdListUsers.SelectedIndex = Convert.ToInt32(e.CommandArgument);


            string s = e.CommandArgument.ToString();

            string[] strInfo = s.Split(',');

            for (int i = 0; i < strInfo.Length; i++)
            {
                HdEditBookUID.Value = strInfo[0];
                HdEditBookID.Value = strInfo[1];


            }

            Server.Transfer(@"EBAd_FreeEbookEdit.aspx");
        }

    }

}
