using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EBLeftMenu_RegSTEPS : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        #region session check

        if (Session["UserID"] == null)
        {
            if (Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 

       

            CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

            int vUserID = Convert.ToInt32(Session["UserID"].ToString());

            DataSet ds = objEbook.EBook_RegProcess_GetDetails(vUserID);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    DataRow tRow = ds.Tables[0].Rows[0];

                    bool vDomain = Convert.ToBoolean(tRow["Domain"].ToString());
                    bool vStoreID = Convert.ToBoolean(tRow["StoreID"].ToString());
                    bool vProfile = Convert.ToBoolean(tRow["Profile"].ToString());
                    bool vPhyBook = Convert.ToBoolean(tRow["PhyBook"].ToString());
                    bool vVendorCode = Convert.ToBoolean(tRow["VendorCode"].ToString());
                    bool regComplete = Convert.ToBoolean(tRow["regComplete"].ToString());

                    if (vDomain)
                    {
                        if (regComplete)
                        {
                        lblStepStatus1.Text = "";
                        lblStepStatus1.CssClass = "fontRegCompleted";
                        }
                    }

                    if (vStoreID)
                    {
                        lblStepStatus2.Text = "";
                        lblStepStatus2.CssClass = "fontRegCompleted";
                    }


                    //if (vProfile)
                    //{
                    //    lblStepStatus3.Text = "Completed";
                    //    lblStepStatus3.CssClass = "fontRegCompleted";
                    //}

                    //if (vPhyBook)
                    //{
                    //    lblStepStatus4.Text = "Completed";
                    //    lblStepStatus4.CssClass = "fontRegCompleted";
                    //}



                    if (Session["EbUserPackageType"] != null)
                    {
                        int PkgType = Convert.ToInt32(Session["EbUserPackageType"].ToString());

                        //.. if PkgType = 1 ... AV user. 

                        if (PkgType == 1)
                        {
                            //lblStepStatus5.Text = "Only for PV user";
                            //liStep4.Visible = false;
                            //liStep5.Visible = false;


                        }
                        else
                        {
                            if (vVendorCode)
                            {
                                //lblStepStatus5.Text = "Completed";
                                //lblStepStatus5.CssClass = "fontRegCompleted";
                            }

                            //liStep4.Visible = false;
                            ////liStep5.Visible = true;
                            //liStep5.Visible = false;

                        }



                    }
                    else
                    {
                        if (vVendorCode)
                        {
                            //lblStepStatus5.Text = "Completed";
                            //lblStepStatus5.CssClass = "fontRegCompleted";
                        }
                    }



                }

            }


    }
}
