using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;


public partial class Ad_Navigate4WebDPE : System.Web.UI.Page
{

    string go2Page = string.Empty;
    string tmpMobileLoginID = string.Empty;
    string tmpCountryPrefix = string.Empty;
    string tmpMuserName = string.Empty;
    string tmpMPassword = string.Empty;
    String tmpMID = string.Empty;




    protected void Page_Load(object sender, EventArgs e)
    {

        String tmpLoggedInFrom = String.Empty;



       

        String ValidStatusText = string.Empty;
        //int ValidStatus = 0;

             if (Session["MobileLoginID"] != null)
                tmpMobileLoginID = Session["MobileLoginID"].ToString();
        

            string strReferringURL = string.Empty;

            if(Session["referringURL"] != null)
                strReferringURL = Session["referringURL"].ToString();

    

            if (tmpMobileLoginID != string.Empty)
            {

                int DPE_ValidStatus = 0;
                tmpMobileLoginID = tmpMobileLoginID.Replace("DPE", ""); 

                String DPe_ValidStatusText = CommonFunctions.ValidateLoginStatus_DPE(tmpMobileLoginID, ref DPE_ValidStatus);

                String strURL = ConfigurationManager.AppSettings["DPE_SMSURL"].ToString();
                String tmpLoginFrom = "DPE";

                DataSet dsDPE = new DataSet();

                CMSv3.BAL.DPE objDPE = new CMSv3.BAL.DPE();

                dsDPE = objDPE.DPE_GetDetails(tmpMobileLoginID);

                if (dsDPE.Tables[0].Rows.Count > 0)
                {

                    DataRow UserStatus_Row = dsDPE.Tables[0].Rows[0];


                    tmpMuserName = UserStatus_Row["LoginMobile"].ToString();
                    tmpMPassword = UserStatus_Row["LoginPwd"].ToString();


                }


                if (Session["LoggedInFrom"] != null)
                {
                    tmpLoginFrom = Session["LoggedInFrom"].ToString();
                    hdDebug.Value = tmpLoginFrom;
                }


              


                if (Session["referringURL"] != null)
                    strReferringURL = Session["referringURL"].ToString();



                if ((DPE_ValidStatus == 0) || (DPE_ValidStatus == 3))
                {
                    if (DPE_ValidStatus == 3)
                    {
                        CommonFunctions.AlertMessage(DPe_ValidStatusText);

                    }

                    HttpContext.Current.Response.Clear();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<html>");
                    sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                    sb.AppendFormat("<form name='form' action='{0}' method='post'>", strURL);
                    sb.AppendFormat("<input type='hidden' name='Muser' value='{0}'>", tmpMuserName);
                    sb.AppendFormat("<input type='hidden' name='Mpwd' value='{0}'>", tmpMPassword);
                    sb.AppendFormat("<input type='hidden' name='MLoginFrom' value='{0}'>", tmpLoginFrom);
                    sb.AppendFormat("<input type='hidden' name='ReferringURL' value='{0}'>", strReferringURL);
                    // Other params go here
                    sb.Append("</form>");
                    sb.Append("</body>");
                    sb.Append("</html>");

                    HttpContext.Current.Response.Write(sb.ToString());
                    //HttpContext.Current.Response.End();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                }
                else
                {
                    CommonFunctions.AlertMessage(DPe_ValidStatusText);
                    LblNotice.Text = DPe_ValidStatusText;
                    ModalPopUpExtender1.Show();
                }

            }

          

        
    }


    protected void fnValidateDPELogin(string vMobileLoginID)
    {


       

    }
}
