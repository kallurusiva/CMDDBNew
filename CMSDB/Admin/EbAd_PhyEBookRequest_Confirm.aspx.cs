using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using CMSv3.BAL;
using System.Configuration;
using System.Text;


public partial class EbAd_PhyEBookRequest_Confirm : BasePage 
{

    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook(); 

    DataSet ds;
    int qRequestID = 0; 


    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 

        Page.MaintainScrollPositionOnPostBack = true;
       

        //tr_bannerBody.Visible = false;
        //tr_bannerHead.Visible = false;

        if (!IsPostBack)
        {

            if ((Request.QueryString["qReqID"] != null) && (Request.QueryString["qReqID"] != ""))
            {
                qRequestID = Convert.ToInt32(Request.QueryString["qReqID"]);
                ViewState["qRequestID"] = qRequestID; 
            }

            LoadUserDetails();
            LoadPhysicalEbooks(qRequestID);

     
        }
    }

    protected void LoadUserDetails()
    {
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        ds = objEbook.Ebook_KeywordDetails_ByUserID(vUserID); 

        if(ds.Tables[0].Rows.Count > 0)
        {
            DataRow URow = ds.Tables[0].Rows[0];

            lblVendorName.Text = URow["MemberName"].ToString();
            lblMobileNo.Text = URow["Mobile"].ToString();
            lblAccountStatus.Text = URow["PackageName"].ToString();
            lblWebsiteName.Text = URow["MemberName"].ToString(); 



        }


           

    }


    protected void LoadPhysicalEbooks(int qRequestID)
    {
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());

        ds = objEbook.PhyBook_Get_EbookRequestID(vUserID, qRequestID); 

       
        DataTable dtRequest = ds.Tables[0];


        string ImageFolder = "";
        ImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();


        if (dtRequest.Rows.Count > 0)
        {

            DataRow Brow = dtRequest.Rows[0]; 
            
               
                int tmpPhyEbookID1 = Convert.ToInt32(Brow["PhyBookID1"].ToString()); 
                lblBookName1.Text = Brow["BookName1"].ToString();
            
                lblBookName2.Text = Brow["BookName2"].ToString();
                int tmpPhyEbookID2 = Convert.ToInt32(Brow["PhyBookID2"].ToString());

                ImgPhyBook1.ImageUrl = ImageFolder + Brow["TpImage1"].ToString();
                ImgPhyBook2.ImageUrl = ImageFolder + Brow["TpImage2"].ToString();

                ImgPhoto1.ImageUrl = ImageFolder + Brow["PhotoGraph1"].ToString();
                ImgPhoto2.ImageUrl = ImageFolder + Brow["PhotoGraph2"].ToString();

                lblNameOnBook.Text = Brow["NameOnBook"].ToString();

                lblDeliveryMode.Text = Brow["DeliveryMode"].ToString();

                lblBizCardName.Text = Brow["BizCardName"].ToString();
                ImgBizCard.ImageUrl = ImageFolder + Brow["BizCardImage"].ToString();
                

                StringBuilder sb = new StringBuilder();

                sb.AppendLine(Brow["Address1"].ToString() + "<br/>");
                sb.AppendLine(Brow["Address2"].ToString() + "<br/>");
                sb.AppendLine(Brow["City"].ToString() + "<br/>");
                sb.AppendLine(Brow["PostCode"].ToString() + " - " +  Brow["State"].ToString() + "<br/>");
                sb.AppendLine(Brow["Country"].ToString() + "<br/>");

                lblPostalAddress.Text = sb.ToString(); 
            
        }


        DataTable dtDomains = ds.Tables[1]; 

        if(dtDomains.Rows.Count > 0)
        {
             DataRow Drow = dtDomains.Rows[0];
             lblWebsiteName.Text = Drow["DomainName"].ToString(); 

        }

        
        


    }




    protected void btnSaveRequest_Click(object sender, EventArgs e)
    {


        tblSubmitBook.Visible = true;
        tblPhyBookDetails.Visible = false; 


        // 1. Update the Book record to Confirmed. 
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        int vPhyBookReqID = Convert.ToInt32(ViewState["qRequestID"].ToString()); 

        int UpStatus = objEbook.PhyBook_ConfirmBookRequest(vUserID, vPhyBookReqID);

        Session["PhyBookRequestStatus"] = "2";

        Response.Redirect("EbAd_PhyEBookRequest_Submit.aspx"); 

        // 2. Send sms to the User informing him of Physcial Book request Creation. 
        

        // 3. Send sms to SMS ALerts to the recipients from ADMIN 





        // 4. Send an Email to User. 

        // 5. Send Emails to Email ALerts to the recipients from ADMIN 



    }
}
