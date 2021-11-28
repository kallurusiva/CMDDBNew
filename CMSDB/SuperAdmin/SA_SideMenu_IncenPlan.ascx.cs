using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdmin_SA_SideMenu_IncenPlan : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Hyp_IncPlanCreate.Text = Resources.LangResources.Incentiveplan + " " + Resources.LangResources.Add;
        Hyp_IncPlanListing.Text = Resources.LangResources.Incentiveplan + " " + Resources.LangResources.View;

        ltrIncentivePlan.Text = Resources.LangResources.Manage + " " + Resources.LangResources.Incentiveplan;

        //LtrAdminNews.Text = "Admin " + Resources.LangResources.News;
        //LtrShowAll.Text = Resources.LangResources.Showall;

    }
}
