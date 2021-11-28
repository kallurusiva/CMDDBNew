using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_LeftMenu_WebSettings : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //int PhyBookRequestStatus = 0; 

        //HypWebEnquiryAdd.Text = "Web Enquiry";
        //HypMyWebEnquiryListing.Text = "Web Settings" ;

        //HypAdminWebEnquiry.Text = "Admin " + Resources.LangResources.WebEnquiry;
        //HypShowALL.Text = Resources.LangResources.Showall;

        if (Session["UserDomainType"] != null)
        {
            String tmpUserType = Session["UserDomainType"].ToString();

            if (tmpUserType == "SME")
            {
                //HypBottomBanner.Visible = false;
                //HypSideBanner.Visible = false;


            }


            if (tmpUserType == "EBOOK")
            {
                //HypWebTemplate.NavigateUrl = "Ad_TemplateSetEbook.aspx";
                HypWebTemplate.NavigateUrl = "EbAd_SetDesign12.aspx";
                HypWebTemplate.Text = "Web Design 1";

               


                HypBottomBanner.Visible = false;
                HypSideBanner.Visible = false;

                HypImagesGallery.Visible = false;
                HypVideoGallery.Visible = false;

                HypCurrentDesign.Visible = true; 


                 String vPkgType = Session["EbUserPackageType"].ToString();

                 if (vPkgType == "2")
                 {
                     //HypDesign2.Visible = true;
                     ////HypDesign2.NavigateUrl = "EbAd_SetDesign2.aspx";
                     //HypDesign2.NavigateUrl = "EbAd_SetDesign13.aspx";

                     //HypDesign3.Visible = true;
                     ////HypDesign3.NavigateUrl = "EbAd_SetDesign3.aspx"; 
                     //HypDesign3.NavigateUrl = "EbAd_SetDesign14.aspx"; 
                 }
               // HypEmailSystem.NavigateUrl = "Ads_EmailPageEbook.aspx";


               // liPhyBookHeader.Visible = true;
               //liPhyBookLink1.Visible = true;

                // 24-Oct-2014 commented everything and showing the buttons to everyone... The condition to checked only on Submission of Book Request. 
                ////liPhyBookHeader.Visible = false;
                ////liPhyBookLink1.Visible = false;

                
                ////if(Session["ShowPhyBookRequestButton"] != null)
                ////{

                ////    String ShowPhyBookRequestButton = Session["ShowPhyBookRequestButton"].ToString(); 

                ////    //Show the Button if the Domain is Registered After '2014-09-01' and The user is not a FREE user. 

                ////    String vUserType = Session["EbUserType"].ToString();



                ////    if ((ShowPhyBookRequestButton == "1") && (vUserType == "PAID"))   //PAID
                ////    {
                ////        liPhyBookHeader.Visible = true;
                ////        liPhyBookLink1.Visible = true;
                ////    }
                ////    else
                ////    {
                ////        liPhyBookHeader.Visible = false;
                ////        liPhyBookLink1.Visible = false;
                ////    }
                ////}
                
                //... PhyBookRequestStatus   1:  Proceed with Request ,   2: Already Requested ,   3: Does not qualify as No OwnDomain Exists or Registered. 

                //if(Session["PhyBookRequestStatus"] != null)
                //{


                //   // Session["PhyBookRequestStatus"] = PhyBookRequestStatus;
                //    PhyBookRequestStatus = Convert.ToInt32(Session["PhyBookRequestStatus"].ToString()); 

                //    if ((PhyBookRequestStatus == 2) || (PhyBookRequestStatus == 3))
                //    {
                //        HypBookRequest.NavigateUrl = "~/Admin/EbAd_PhyEBookRequest_Status.aspx?qStatus=" + PhyBookRequestStatus;
                //        //http://localhost:52512/Admin/EbAd_PhyEBookRequest_Status.aspx
                        
                //    }
                    

                //}
                //else
                //{
                    //CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
                    //PhyBookRequestStatus = objEbook.PhyBook_ValidateBookRequest(Convert.ToInt32(Session["UserID"].ToString()));

                    //Session["PhyBookRequestStatus"] = PhyBookRequestStatus;

                    //if((PhyBookRequestStatus == 2) || (PhyBookRequestStatus == 3))
                    //{
                    //    HypBookRequest.NavigateUrl = "~/Admin/EbAd_PhyEBookRequest_Status.aspx?qStatus=" + PhyBookRequestStatus; 
                    //}

               // }


            }

        }



    }
}
