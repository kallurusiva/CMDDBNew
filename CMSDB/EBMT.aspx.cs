using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.IO;

public partial class EBMT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {        

            String inputVal = string.Empty;
            if (Request.QueryString.Count > 0)
            {
        
                if (Request.QueryString[0] != null)
                
                {
                     inputVal = Request.QueryString[0].ToString();                     
                     DataSet ds2;
                     newDBS clsObjNewDbs = new newDBS();
             
                     ds2 = clsObjNewDbs.getMTebookDownload(inputVal);
                     int Status = Convert.ToInt32(ds2.Tables[0].Rows[0]["Status"].ToString());
                     int Validity = Convert.ToInt32(ds2.Tables[0].Rows[0]["Validity"].ToString());
                     String vfileName = ds2.Tables[0].Rows[0]["BookName"].ToString();
                    // String EbookfileURL = ConfigurationManager.AppSettings["EbookFileFolder"].ToString();
                    // String EbookFilePath = EbookfileURL + vfileName;

                    // if (Status > Validity)
                    //{
                    //    Response.Write("Invalid Request. Request Book does not exists/ Expire.");
                    //}
                    //else
                    //{
                    //    if (File.Exists(Server.MapPath(EbookFilePath)))
                    //    {
                    //        Response.ContentType = ContentType;
                    //        Response.AppendHeader("Content-Disposition", "attachment; filename=" + vfileName);
                    //        Response.WriteFile(EbookFilePath);
                    //    }
                    //    else
                    //    {
                    //        String vAlertMsg = "Sorry !!. The system is not able to download the requested File.  Please Try Again or contact Administrator.";
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
                    //    }
                    //}
                     String EbookfileURL = @"E:\webs\EBooks\DocumentRepository\eBooks\";
                     String EbookFilePath = EbookfileURL + vfileName;

                     if (Status > Validity)
                     {
                         Response.Write("Invalid Request. Request Book does not exists/ Expire.");
                     }
                     else
                     {
                         if (File.Exists(EbookFilePath))
                         {
                             Response.ContentType = ContentType;
                             Response.AppendHeader("Content-Disposition", "attachment; filename=" + vfileName);
                             Response.WriteFile(EbookFilePath);
                         }
                         else
                         {
                             String vAlertMsg = "Sorry !!. The system is not able to download the requested File.  Please Try Again or contact Administrator.";
                             ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert('" + vAlertMsg + "')", true);
                         }
                     }
                }
            }
                else
                {                    
                     inputVal = "0";
                     Response.Write("Invalid Request. Request Book does not exists/ Expire.");                
                }

            //Response.Write(EbookFilePath.ToString());
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage22", "javascript:alert(' Downloading the Book: " + EbookFilePath + "')", true);
           
        }
    }
}