using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Admin_TestListing : System.Web.UI.Page
{
        SqlConnection dbConn;
        //SqlCommand dbCmd;
        //SqlDataReader dbReader;
        //SqlDataAdapter dbAdapter;
        DataSet SearchDS = new DataSet();
        DataSet ds = new DataSet();
        DataView dv = new DataView();
        String FinalSrQry = String.Empty;

        String m_SortExpr = string.Empty;
        String m_SortDir = string.Empty;

        String strUSERID = string.Empty;
        string m_strSortDir = String.Empty;
    
    protected void Page_Load(object sender, EventArgs e)
    {

       //strUSERID = Session["UserID"].ToString();
        strUSERID = "104" ;
        if (!IsPostBack)
        {
            dv = bindgrid("");
           grdSearchAddrBook.DataSource = dv;
           grdSearchAddrBook.DataBind();
        }
        

    }


    private DataView bindgrid(string mSortDirection)
    {
		//String ConnString = "Data Source=localhost;Initial Catalog=DatabaseName;Integrated Security=True";
        String StrQuery = string.Empty;

        if (mSortDirection == null)
            mSortDirection = " ASC";

        StrQuery = "SELECT NewsID,NewsTitle,NewsContent,NewsDate from tblNews where USerID = " + strUSERID;


        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        SqlDataAdapter dbAdapter = new SqlDataAdapter(StrQuery, dbConn);
        dbAdapter.Fill(ds);

        System.Threading.Thread.Sleep(2000);
		
        if (ViewState["sortExpr"] != null)
		{
			dv = new DataView(ds.Tables[0]);

            dv.Sort = (string)ViewState["sortExpr"] + mSortDirection;


			//dv.Sort = (string)ViewState["sortExpr"] ;
		}
		else
			dv = ds.Tables[0].DefaultView;
		return dv;

        
	}


    protected void PageNumberDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList pageNumberDropDownList = sender as DropDownList;
        ViewState["pageId"] = pageNumberDropDownList.SelectedIndex;
        if (pageNumberDropDownList != null)
        {
            if (grdSearchAddrBook.Rows.Count > 0)
            {
                if (pageNumberDropDownList.SelectedIndex < grdSearchAddrBook.PageCount ||
                  pageNumberDropDownList.SelectedIndex >= 0)
                {
                    grdSearchAddrBook.PageIndex = pageNumberDropDownList.SelectedIndex;

                    if (GridViewSortDirection == SortDirection.Ascending)
                    {   //GridViewSortDirection = SortDirection.Descending;
                        m_strSortDir = " Asc";
                    }
                    else
                    {
                        //GridViewSortDirection = SortDirection.Ascending;
                        m_strSortDir = " Desc";
                    }
                    grdSearchAddrBook.DataSource = bindgrid(m_strSortDir);
                    grdSearchAddrBook.DataBind();
                }
            }
        }
    }
   protected void grdSearchAddrBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
   {
       grdSearchAddrBook.PageIndex = e.NewPageIndex;

       
       if (GridViewSortDirection == SortDirection.Ascending)
       {

           //GridViewSortDirection = SortDirection.Descending;
           m_strSortDir = " Asc";
       }
       else
       {
           //GridViewSortDirection = SortDirection.Ascending;
           m_strSortDir = " Desc";
       }

       grdSearchAddrBook.DataSource = bindgrid(m_strSortDir);
       grdSearchAddrBook.DataBind();
   }

        public SortDirection GridViewSortDirection
    {

        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];

        }

        set { ViewState["sortDirection"] = value; }

    }



   protected void InitialiseGridViewPagerRow(GridViewRow gridViewRow)
   {
       if (gridViewRow != null)
       {
           // Check the page index so that we can :
           //  1. Disable the 'First' and 'Previous' paging image buttons if paging index is at 0
           //  2. Disable the 'Last' and 'Next' paging image buttons if paging index is at the end
           //  3. Enable all image buttons if the conditions of 1 and 2 are not satisfied
           Button firstbutton = gridViewRow.FindControl("btnFirst") as Button;
           Button Prevbutton = gridViewRow.FindControl("btnPrevious") as Button;
           Button Nextbutton = gridViewRow.FindControl("btnNext") as Button;
           Button Lastbutton = gridViewRow.FindControl("btnLast") as Button;


           //ImageButton firstbutton = gridViewRow.FindControl("firstbutton") as ImageButton;
           //ImageButton Prevbutton = gridViewRow.FindControl("Prevbutton") as ImageButton;
           //ImageButton Lastbutton = gridViewRow.FindControl("Lastbutton") as ImageButton;
           //ImageButton Nextbutton = gridViewRow.FindControl("Nextbutton") as ImageButton;

           if (grdSearchAddrBook.PageIndex == 0)
           {
               // Disable 'First' and 'Previous' Paging image buttons

               if (firstbutton != null && Prevbutton != null)
               {
                   firstbutton.Enabled = false;
                   Prevbutton.Enabled = false;
               }
           }
           else if ((grdSearchAddrBook.PageIndex + 1) == grdSearchAddrBook.PageCount)
           {
               // Disable 'Last' and 'Next' Paging image buttons

               if (Lastbutton != null && Nextbutton != null)
               {
                   Lastbutton.Enabled = false;
                   Nextbutton.Enabled = false;
               }
           }
           else
           {
               // Enable the Paging image buttons

               if (firstbutton != null && Lastbutton != null &&
                    Prevbutton != null && Nextbutton != null)
               {
                   firstbutton.Enabled = true;
                   Lastbutton.Enabled = true;
                   Nextbutton.Enabled = true;
                   Prevbutton.Enabled = true;
               }
           }

           // Get the DropDownList found as part of the Pager Row. 
           // One can then initialise the DropDownList to contain
           // the appropriate page settings. Eg. Page Number and number of Pages

           DropDownList pageNumberDropDownList = gridViewRow.FindControl("PageNumberDropDownList") as DropDownList;
           Label pageCountLabel = gridViewRow.FindControl("PageCountLabel") as Label;
           if (pageNumberDropDownList != null && pageCountLabel != null)
           {
               for (int i = 0; i < grdSearchAddrBook.PageCount; i++)
               {
                   int page = i + 1;
                   pageNumberDropDownList.Items.Add(new ListItem(page.ToString(), i.ToString()));
               }
               pageNumberDropDownList.SelectedIndex = grdSearchAddrBook.PageIndex;
               pageCountLabel.Text = grdSearchAddrBook.PageCount.ToString();
           }
       }
   }

   protected void grdSearchAddrBook_DataBound(object sender, EventArgs e)
   {
       InitialiseGridViewPagerRow(grdSearchAddrBook.BottomPagerRow);
   }


}
