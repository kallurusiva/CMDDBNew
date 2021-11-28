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


public partial class EbAd_PhyEBookRequest : BasePage 
{

    CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook(); 
    DataSet ds;
    bool ImgFileUploaded1 = false;
    string ImgFileName1 = string.Empty;
    string ImgFileUrl1 = string.Empty;
    bool ImgFileUploaded2 = false;
    string ImgFileName2 = string.Empty;
    string ImgFileUrl2 = string.Empty;
    long MaxImageSize = 307200;   // 300 KB
    int PhyBookRequestStatus = 0;

    private static bool Getbool()
    {
        return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"].ToString() == null) || (Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpireEbook.aspx");
        }
        #endregion 

        Page.MaintainScrollPositionOnPostBack = true;
       
        ImgFileUploaded1= Getbool();
        ImgFileUploaded2 = Getbool();
        //tr_bannerBody.Visible = false;
        //tr_bannerHead.Visible = false;

        if (!IsPostBack)
        {
            ViewState["LogoWasUploaded"] = "false";
            ViewState["BannerWasUploaded"] = "false";
            ViewState["FileImageUrl"] = "";

            if ((Request.QueryString["ImgToDelete"] != null) && (Request.QueryString["ImgToDelete"] != ""))
            {
                DeleteImage(Request.QueryString["ImgToDelete"]);
            }



            PreCheck_BookRequest();

            

            LoadPhysicalEbooks();

     
        }
    }

    protected void CheckPhyBookRequestStatus()
    {
               


    }

    protected void DeleteImage(string vImageID2Delete)
    {

        

    }

    protected void LoadPhysicalEbooks()
    {
        int vUserID = Convert.ToInt32(Session["UserID"].ToString()); 

        ds = objEbook.PhyBook_GetALL_Ebooks(vUserID,""); 

       
        DataTable dtBooks = ds.Tables[0];
        DataTable dtTemplates = ds.Tables[1];
        DataTable dtBizCards = ds.Tables[2];
       
        
        int tmpPhyEbookID = 0; 

        if(dtBooks.Rows.Count>0)
        {
            int i=1; 
            foreach(DataRow Brow in dtBooks.Rows)
            {
               
                tmpPhyEbookID = Convert.ToInt32(Brow["PhyBookID"].ToString()); 

                if( i == 1)
                {
                    lblBookName1.Text = Brow["PhyBookName"].ToString();
                    ViewState["PhyBookID1"] = Convert.ToInt32(Brow["PhyBookID"].ToString()); 
                    RenderPhyEbookTemplates(tmpPhyEbookID,dtTemplates,rdoEbookTemplates1); 
                }

                if( i==2)
                {
                    lblBookName2.Text = Brow["PhyBookName"].ToString();
                    ViewState["PhyBookID2"] = Convert.ToInt32(Brow["PhyBookID"].ToString()); 
                    RenderPhyEbookTemplates(tmpPhyEbookID,dtTemplates,rdoEbookTemplates2); 
                }
                i++; 
            }
           
        }

        if (dtBizCards.Rows.Count > 0)
        {
            rdoBizCards.Items.Clear();

            string ImageFolder = "";
            ImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();

            foreach(DataRow BzRow in dtBizCards.Rows)
            {
                string tmpTemplateID = BzRow["BizCardID"].ToString();
                string tmpTemplateName = BzRow["BizCardName"].ToString();
                string tmpTpImageName = BzRow["BizCardImage"].ToString();

                rdoBizCards.Items.Add(new ListItem(String.Format("<div id='dvUsrLogo' class='ebBizCardBox' ><img class='ebBizCardImgCss' src='{0}'></div>", ImageFolder + tmpTpImageName), tmpTemplateID));


                ListItem CurrItem = rdoBizCards.Items.FindByValue(tmpTemplateID);
                CurrItem.Text = "TemplateID :[<span class='AdminFont'> " + tmpTemplateName + "</span> ]" + "<br/>" + CurrItem.Text;


            }

        }
        
        


    }

    protected void RenderPhyEbookTemplates(int vPhyEbookID, DataTable vDtTemplates, RadioButtonList rdoBtnList)
    {

        string ImageFolder = "";
        ImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();

        DataRow[] tRows = vDtTemplates.Select("PhyBookID = " + vPhyEbookID);


         // rendering ebook templates 

                rdoBtnList.Items.Clear(); 

                foreach (DataRow Lrow in tRows)
                {
                    //TemplateID, TemplateName, TpImageName

                    string tmpTemplateID = Lrow["TemplateID"].ToString();
                    string tmpTemplateName = Lrow["TemplateName"].ToString();
                    string tmpTpImageName = Lrow["TpImageName"].ToString();


                    rdoBtnList.Items.Add(new ListItem(String.Format("<div id='dvUsrLogo' class='ebTemplateBox' ><img class='ebTempImgCss' src='{0}'></div>", ImageFolder + Lrow["TpImageName"].ToString()), Lrow["TemplateID"].ToString()));


                    ListItem CurrItem = rdoBtnList.Items.FindByValue(Lrow["TemplateID"].ToString());
                    CurrItem.Text = "TemplateID :[<span class='AdminFont'> " + Lrow["TemplateName"].ToString() + "</span> ]" + "<br/>" + CurrItem.Text;

                }


          


    }


    protected void CustomVdr_Photo1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //30720 = 15 KB  ( 1024 * 30 )
        if (FU_Photo1.FileBytes.Length > 307200) 
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }



    protected void CustomVdr_Photo2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //30720 = 15 KB  ( 1024 * 30 )
        if (FU_Photo2.FileBytes.Length > 307200)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void PreValidateRequest()
    {

        

        if(!FU_Photo1.HasFile)
        {
            CustomVdr_Photo1.IsValid = false;
            CustomVdr_Photo1.ErrorMessage = "Please Select the PhotoGraph for Book No. 1"; 
            return;
        }
        else
        {
            if (FU_Photo1.FileBytes.Length > MaxImageSize)
            {
                CustomVdr_Photo1.IsValid = false;
                return; 

            }


        }

        if (!FU_Photo2.HasFile)
        {
            CustomVdr_Photo2.IsValid = false;
            CustomVdr_Photo2.ErrorMessage = "Please Select the PhotoGraph for Book No. 2"; 
            //CommonFunctions.AlertMessage("Please select the PhotoGraph for BOOK NO. 2");
            return;
        }
        else
        {
            if (FU_Photo2.FileBytes.Length > MaxImageSize)
            {
                CustomVdr_Photo2.IsValid = false;
                return; 
            }

        }




    }


    protected void CheckEligibility()
    {

          if(Session["ShowPhyBookRequestButton"] != null)
          {

               String ShowPhyBookRequestButton = Session["ShowPhyBookRequestButton"].ToString(); 
                if (ShowPhyBookRequestButton == "1")
                {
                    PhyBookRequestStatus = 5; 
                    Response.Redirect("~/Admin/EbAd_PhyEBookRequest_NE.aspx?qStatus=" + PhyBookRequestStatus);
                }


          }

         

        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        PhyBookRequestStatus = objEbook.PhyBook_ValidateBookRequest(Convert.ToInt32(Session["UserID"].ToString()));

        Session["PhyBookRequestStatus"] = PhyBookRequestStatus;
       

        if ((PhyBookRequestStatus == 2) || (PhyBookRequestStatus == 3))
        {
            Response.Redirect("~/Admin/EbAd_PhyEBookRequest_Status.aspx?qStatus=" + PhyBookRequestStatus);
        }

    }



    protected void PreCheck_BookRequest()
    {

        
        CMSv3.BAL.eBook objEbook = new CMSv3.BAL.eBook();
        PhyBookRequestStatus = objEbook.PhyBook_ValidateBookRequest(Convert.ToInt32(Session["UserID"].ToString()));

        Session["PhyBookRequestStatus"] = PhyBookRequestStatus;


        if ((PhyBookRequestStatus == 2) || (PhyBookRequestStatus == 3))
        {
            Response.Redirect("~/Admin/EbAd_PhyEBookRequest_Status.aspx?qStatus=" + PhyBookRequestStatus);
        }

    }


    protected void btnSaveRequest_Click(object sender, EventArgs e)
    {
        CheckEligibility(); 

        PreValidateRequest(); 

        if (!Page.IsValid)
            return;

        int vPhyBookID1 = Convert.ToInt32(ViewState["PhyBookID1"].ToString()); 
        int vPhyBookID2 = Convert.ToInt32(ViewState["PhyBookID2"].ToString()); 

        String SelTemplate1 = rdoEbookTemplates1.SelectedValue;
        String SelTemplate2 = rdoEbookTemplates2.SelectedValue;

        int SelBizCardID = Convert.ToInt16(rdoBizCards.SelectedValue); 

        String SelNameOnBook = txtNameOnPrintedBook.Text.Trim(); 

        
        //Getting Photograph 1
        Random rnum = new Random();
        String tmpImageFolder = ConfigurationManager.AppSettings["EbookImageFolder"].ToString();
        if (FU_Photo1.HasFile)
        {

            if (FU_Photo1.FileBytes.Length < MaxImageSize)
            {
                ImgFileUploaded1 = false;
                //Get the name of the file
                string fileName = FU_Photo1.FileName;

                ImgFileName1 = Convert.ToString(rnum.Next(9999)) + "_" + FU_Photo1.FileName;
               
                //instead of server.mapPath set the path in web.config file and use that path.
                ImgFileUrl1 = Server.MapPath("~") + tmpImageFolder;

                FU_Photo1.SaveAs(ImgFileUrl1 + ImgFileName1);
                lblUpMessage1.Text = "Image uploaded : " + FU_Photo1.FileName;
                ImgFileUploaded1 = true;
                FU_Photo1.Dispose();

            }
        }


        //Getting Photograph 2
        if (FU_Photo2.HasFile)
        {

            if (FU_Photo2.FileBytes.Length < MaxImageSize)
            {
                ImgFileUploaded2 = false;
                //Get the name of the file
                string fileName = FU_Photo2.FileName;

                ImgFileName2 = Convert.ToString(rnum.Next(9999)) + "_" + FU_Photo2.FileName;

                //instead of server.mapPath set the path in web.config file and use that path.
                ImgFileUrl2 = Server.MapPath("~") + tmpImageFolder;

                FU_Photo2.SaveAs(ImgFileUrl2 + ImgFileName2);
                lblUpMessage2.Text = "Image uploaded : " + FU_Photo2.FileName;
                ImgFileUploaded2 = true;
                FU_Photo2.Dispose();

            }
        }


        //..Delivery Address information 

        int SelDeliveryMode = Convert.ToInt32(rdoDeliveryMode.SelectedValue);

        String selAddress1 = txtAddress1.Text.Trim();
        String selAddress2 = txtAddress2.Text.Trim();
        String selCity = txtCity.Text.Trim();
        String selState = txtState.Text.Trim();
        String selPostCode = txtPostcode.Text.Trim();
        String selCountry = txtCountry.Text.Trim();


        int vUserId = Convert.ToInt32(Session["UserID"].ToString());
        String vMobileLoginID = Session["MobileLoginID"].ToString();
        String vMerchantID = Session["MerID"].ToString(); 

        int vBookRequestID = objEbook.PhyBook_RequestADD(vUserId,vMobileLoginID,vMerchantID, vPhyBookID1, SelTemplate1, vPhyBookID2, SelTemplate2,SelBizCardID, SelNameOnBook, ImgFileName1, ImgFileName2, SelDeliveryMode, selAddress1, selAddress2, selCity, selState, selPostCode, selCountry); 


        if(vBookRequestID != 0)
        {
            Response.Redirect("EbAd_PhyEbookRequest_Confirm.aspx?qReqID=" + vBookRequestID); 

        }
        else
        {
            lblErrMessage.Text = "An Error occurred while creating the Physical Book Request. Please Try Again.";
            tblMessageBar.Visible = true;
            tblMessageBar.Attributes.Add("class", "MessagerBarCssERROR");
            CommonFunctions.AlertMessage("Physical Book Reqeust Could not be Created Due an Error.  Please try Again. ");
            
        }


    }
}
