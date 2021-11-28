using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PopCalendar : BasePage
{
    public  string strSelectedDate = string.Empty;
    public String strFormName = string.Empty;
    public String strCtrlName = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //'-------------------------------------------------------------------
            // ' Set the Calendar to Today's date in the first load
            // '-------------------------------------------------------------------
            myCalendar.SelectedDate = System.DateTime.Now;
        }

         strSelectedDate = myCalendar.SelectedDate.ToString("dd/MM/yyyy");
         strFormName = Request.QueryString["FormName"];
         strCtrlName = Request.QueryString["CtrlName"];
               

    }

    protected void myCalendar_SelectionChanged(object sender, EventArgs e)
    {
        strSelectedDate = myCalendar.SelectedDate.ToString("dd/MM/yyyy");
    }
}
