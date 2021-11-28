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


public partial class EbAd_PhyEBookRequest_Status : BasePage 
{

    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook(); 

    DataSet ds;
    //int qRequestID = 0;
    int qStatus = 0; 


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
            if ((Request.QueryString["qStatus"] != null) && (Request.QueryString["qStatus"] != ""))
            {
                qStatus = Convert.ToInt32(Request.QueryString["qStatus"]);
            }


          
            if (qStatus == 3)
            {
                lblBookStatus.Text = "Physical Book can be Requested Only if you have registered your Own Domain.   You have not Registered your Own Domain Yet .";
                tblValidate.Visible = true; 
            }
            else if (qStatus == 2)
            {


                //Get the Status. 



                lblBookStatus.Text = "Your request for Physical Book is currently <b>PENDING </b>.";
                tblValidate.Visible = true; 

            }


            //if ((Request.QueryString["qReqID"] != null) && (Request.QueryString["qReqID"] != ""))
            //{
            //    qRequestID = Convert.ToInt32(Request.QueryString["qReqID"]);
            //}

            LoadUserDetails();
           

     
        }
    }

    protected void LoadUserDetails()
    {
        int vUserID = Convert.ToInt32(Session["UserID"].ToString());
        ds = objEbook.Ebook_KeywordDetails_ByUserID(vUserID);

        DataTable dtPhy = ds.Tables[2]; 

        if(ds.Tables[0].Rows.Count > 0)
        {
            DataRow URow = ds.Tables[0].Rows[0];

            lblVendorName.Text = URow["MemberName"].ToString();
            lblMobileNo.Text = URow["Mobile"].ToString();
            lblAccountStatus.Text = URow["PackageName"].ToString();
            //lblWebsiteName.Text = URow["MemberName"].ToString();



            if (dtPhy.Rows.Count > 0)
            {

                DataRow PhRow = dtPhy.Rows[0]; 

                //.. Get the Physical Book REquest ID 
                int qRequestID = Convert.ToInt32(PhRow["PhyRequestID"].ToString());

                if (qRequestID > 0)
                {
                    tblPhyBookReqDetails.Visible = true; 
                    LoadPhysicalEbooks(qRequestID);
                }
            }
            else
            {
                tblPhyBookReqDetails.Visible = false;  
            }

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

                lblDeliveryMode.Text = Brow["DeliveryMode"].ToString();
                lblNameOnBook.Text = Brow["NameOnBook"].ToString();

                lblBizCardName.Text = Brow["BizCardName"].ToString();
                ImgBizCard.ImageUrl = ImageFolder + Brow["BizCardImage"].ToString();

                StringBuilder sb = new StringBuilder();

                sb.AppendLine(Brow["Address1"].ToString() + "<br/>");
                sb.AppendLine(Brow["Address2"].ToString() + "<br/>");
                sb.AppendLine(Brow["City"].ToString() + "<br/>");
                sb.AppendLine(Brow["PostCode"].ToString() + " - " + Brow["State"].ToString() + "<br/>");
                sb.AppendLine(Brow["Country"].ToString() + "<br/>");

                lblPostalAddress.Text = sb.ToString();

                String ReqStatus = Brow["Status"].ToString();
                lblBookStatus.Text = "Your request for Physical Book has been <b>" + ReqStatus + "</b>.";

                
            
        }


        DataTable dtDomains = ds.Tables[1];

        if (dtDomains.Rows.Count > 0)
        {
            DataRow Drow = dtDomains.Rows[0];
            lblWebsiteName.Text = Drow["DomainName"].ToString();

        }
        


    }




    protected void btnSaveRequest_Click(object sender, EventArgs e)
    {

    }
}
