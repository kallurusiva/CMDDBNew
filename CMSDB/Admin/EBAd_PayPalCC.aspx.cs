using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EBAd_PayPalCC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Session Check 

        if (Session["UserID"] == null)
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        else
        {
            if (Session["UserID"].ToString() == "")
                Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 


        //txtUserDomainEmail.Attributes.Add("readonly", "readonly"); 

        if(!IsPostBack)
        {

            int vUserID = Convert.ToInt32(Session["UserID"].ToString()); 
            LoadEMSDetails(vUserID); 

        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        //CommonFunctions.AlertMessage("Payment Type changed Please ensure .  As our technical team is working on the required prerequisites");
       // CommonFunctions.AlertMessage("Currently Own PayPal Settings are not allowed to be Save.  As our technical team is working on the required prerequisites");
       // return; 

        String tmpPayPalEmailID = string.Empty;
        int vEmailType = 0;

        lblError.Visible = false; 

       if(rdoUsePayPalEmail.Checked)
       {
           tmpPayPalEmailID = txtPayPalEmail.Text.Trim(); 

           if(tmpPayPalEmailID == string.Empty)
           {
               CustomValidatorPaypal.IsValid = false;
               CustomValidatorPaypal.ErrorMessage = "";
               txtPayPalEmail.Focus();
               txtPayPalEmail.BackColor = System.Drawing.Color.PapayaWhip;

               lblError.Text = "PayPal email cannot be Empty.!!";
               lblError.Visible = true;

           }
           else
           {
               CustomValidatorPaypal.IsValid = true; 
           }
           vEmailType = 1; // "PayPal"; 
       }
       else
       {
           vEmailType = 0; // "UserDomain"; 
           //tmpPayPalEmailID = txtUserDomainEmail.Text.Trim(); 

           if(tmpPayPalEmailID.Contains("Yet"))
           {
               lblError.Text = "Your Email System has not been Created Yet.  Please enter your own PayPal Business Email.";
               lblError.Visible = true;

               lblErrMessage.Visible = true;
               lblErrMessage.Text = "Your Email System has not been Created Yet.  Please Choose and enter your own PayPal Business Email.";
               return; 
           }
       }


        if(Page.IsValid)
        {
            


            int vUserId = Convert.ToInt32(Session["UserID"].ToString()); 
            
            //Save Settings... 
              CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
              int inStatus = objEbook.PayPalSettings(vUserId, vEmailType, tmpPayPalEmailID);

              CommonFunctions.AlertMessage("Your PayPal Settings have been Saved");


        }

    }

    protected void LoadEMSDetails(int vUserID)
    {
        string SearchStr = string.Empty;

        //SearchStr = " MobileLoginID = (Select MobileLoginID from tblUsers where UserID = " + vUserID + ")";
        //SearchStr = " and MobileLoginID = '" + vMobileLoginID + "'";
        //ds = objBAL_Gems.Retrieve_EMSContent(SearchStr);

        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();

        DataSet ds = objEbook.Retrieve_EMSContent_ByUserID(vUserID); 

        DataTable dtUserDetails;
        dtUserDetails = ds.Tables[0];

        DataTable dtPayPalSettings; 
        dtPayPalSettings = ds.Tables[1]; 

        if (dtUserDetails.Rows.Count > 0)
        {

            foreach (DataRow URow in dtUserDetails.Rows)
            {
                String tmpDomainEmailid  = URow["AdminID"].ToString();
                String tmpDomainEmailPassword  = URow["AdminPwd"].ToString();

                //txtUserDomainEmail.Text = tmpDomainEmailid;
                //txtUserDomainPwd.Text = tmpDomainEmailPassword; 

            
            }
        }
        else
        {
            // trPlatinum.Visible = false;
            //trAlertEmailSystem.Visible = true;

            //txtUserDomainEmail.Text = "No Domain Email Created Yet."; 
        }



        if(dtPayPalSettings.Rows.Count > 0)
        {
            DataRow Prow = dtPayPalSettings.Rows[0];

            int tmpEmailType = Convert.ToInt16(Prow["EmailType"].ToString());
            string tmpEmailAddress = Prow["EmailID"].ToString();

            if (tmpEmailType == 1)
            {
                rdoUsePayPalEmail.Checked = true;
                txtPayPalEmail.Text = tmpEmailAddress;
            }
            else
            {
                //rdoUseDomainEmail.Checked = true;
            }

           

        }


    }


}