using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_MyAccount : BasePage
{

    CMSv3.BAL.AccountSettings objBAL_ActSettings = new CMSv3.BAL.AccountSettings();
    DataSet ds;

    //DataTable dtHomePage;
    //DataTable dtCommApps;


    protected void Page_Load(object sender, EventArgs e)
    {
        #region  // SessionCheck
        if ((Session["UserID"] == null))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }
        else if ((Session["UserID"].ToString() == ""))
        {
            Response.Redirect("~/SessionExpire.aspx");
        }

        #endregion 

        #region Loading Global Resource values  

        LtrMyActSettings.Text = (string)GetGlobalResourceObject("LangResources", "MyAccount") + " " + (string)GetGlobalResourceObject("LangResources", "Settings") + "  (Website, MobileWeb and Contact Setting)"; 
        

        Literal objLtrDisplayAtWebsite = (Literal)FrmAccount.FindControl("LtrDisplayAtWebsite");
        if(objLtrDisplayAtWebsite != null)
        objLtrDisplayAtWebsite.Text = Resources.LangResources.DisplayatWebsite;

        Literal objLtrDisplayAtWebsite2 = (Literal)FrmAccount.FindControl("LtrDisplayAtWebsite2");
        if (objLtrDisplayAtWebsite2 != null)
            objLtrDisplayAtWebsite2.Text = Resources.LangResources.DisplayatWebsite;


        #endregion

        
        

        if (!IsPostBack)
        {

            LoadSettingsData();

        }


    }

    protected void LoadSettingsData()
    {

        ds = objBAL_ActSettings.RetrieveALL_Settings_HomePageData(Convert.ToInt32(Session["UserId"]));

        if (ds.Tables[0].Rows.Count > 0)
        {
            FrmAccount.DataSource = ds;
            FrmAccount.DataBind();
        }
        else
        {
            FrmAccount.ChangeMode(FormViewMode.Insert);
        }
        

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
    }


    protected void FrmAccount_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {

        //Get all the Data. 

        TextBox tFullName = (TextBox)FrmAccount.Row.FindControl("txtFullName");
        TextBox tNickName = (TextBox)FrmAccount.Row.FindControl("txtNickName");
        TextBox tEmail = (TextBox)FrmAccount.Row.FindControl("txtEmail");
        TextBox tHandPhone = (TextBox)FrmAccount.Row.FindControl("txtHandPhone");
        TextBox tHomePhone = (TextBox)FrmAccount.Row.FindControl("txtHomePhone");
        TextBox tFaxNo = (TextBox)FrmAccount.Row.FindControl("txtFaxNo");
        TextBox tAddress = (TextBox)FrmAccount.Row.FindControl("txtAddress");

        CheckBox cCompanyName = (CheckBox)FrmAccount.Row.FindControl("chkCompanyName");
        CheckBox cNickName = (CheckBox)FrmAccount.Row.FindControl("chkNickName");
        CheckBox cEmail = (CheckBox)FrmAccount.Row.FindControl("chkEmail");
        CheckBox cHandPhone = (CheckBox)FrmAccount.Row.FindControl("chkHandPhone");
        CheckBox cHomePhone = (CheckBox)FrmAccount.Row.FindControl("chkHomePhone");
        CheckBox cFaxNo = (CheckBox)FrmAccount.Row.FindControl("chkFaxNo");
        CheckBox cAddress = (CheckBox)FrmAccount.Row.FindControl("chkAddress");
        CheckBox cUserPhoto = (CheckBox)FrmAccount.Row.FindControl("chkUserPhoto");


        TextBox tYahooID = (TextBox)FrmAccount.Row.FindControl("txtYahooID");
        TextBox tHotmailID = (TextBox)FrmAccount.Row.FindControl("txtHotmailID");
        TextBox tSkypeID = (TextBox)FrmAccount.Row.FindControl("txtSkypeID");
        TextBox tTwitterID = (TextBox)FrmAccount.Row.FindControl("txtTwitterID");
        TextBox tBlogSpotID = (TextBox)FrmAccount.Row.FindControl("txtBlogSpotID");
        TextBox tFacebookId = (TextBox)FrmAccount.Row.FindControl("txtFacebookId");
        TextBox tFacebookGroupLink = (TextBox)FrmAccount.Row.FindControl("txtFacebookGroupLink");
        TextBox tCompanyName = (TextBox)FrmAccount.Row.FindControl("txtCompanyName");
        //TextBox tCompanyInfo = (TextBox)FrmAccount.Row.FindControl("txtCompanyInfo");


        CheckBox cYahoo = (CheckBox)FrmAccount.Row.FindControl("chkYahoo");
        CheckBox cHotmail = (CheckBox)FrmAccount.Row.FindControl("chkHotmail");
        //CheckBox cGoogle = (CheckBox)FrmAccount.Row.FindControl("chkGoogle");
        CheckBox cSkype = (CheckBox)FrmAccount.Row.FindControl("chkSkype");
        CheckBox cTwitter = (CheckBox)FrmAccount.Row.FindControl("chkTwitter");
        CheckBox cBlogSpot = (CheckBox)FrmAccount.Row.FindControl("chkBlogSpot");
        CheckBox cFacebook = (CheckBox)FrmAccount.Row.FindControl("chkFacebook");
        CheckBox cFacebookGroupLink = (CheckBox)FrmAccount.Row.FindControl("chkFaceBookGroupLink");

        FileUpload fUserPhoto = (FileUpload)FrmAccount.Row.FindControl("fupl_UserPhoto");

        string strImgFileName = string.Empty;
        string strImgActual_FileName = string.Empty;
        string strImgFileURL = string.Empty;

        Random rnum = new Random();

        if (fUserPhoto.HasFile)
        {
            strImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + fUserPhoto.FileName;
            strImgActual_FileName = fUserPhoto.FileName;
           
            //instead of server.mapPath set the path in web.config file and use that path.
            strImgFileURL = Server.MapPath("~") + GlobalVar.GetImgStoreFolder.ToString();
            
            fUserPhoto.SaveAs(strImgFileURL + strImgFileName);

        }


        CMSv3.Entities.CommApps objCommApps = new CMSv3.Entities.CommApps();

        objCommApps.yahooid = tYahooID.Text;
        objCommApps.Hotmailid = tHotmailID.Text;
        objCommApps.Skypeid = tSkypeID.Text;
        objCommApps.Twitterid = tTwitterID.Text;
        objCommApps.BlogSpotid = tBlogSpotID.Text;
        objCommApps.Facebookid = tFacebookId.Text;
        objCommApps.FaceBookGroupLink = tFacebookGroupLink.Text;

        
        objCommApps.yahooChecked = cYahoo.Checked;
        objCommApps.HotmailChecked = cHotmail.Checked;
        //objCommApps.GoogleChecked = cGoogle.Checked;
        objCommApps.SkypeChecked = cSkype.Checked;
        objCommApps.TwitterChecked = cTwitter.Checked;
        objCommApps.BlogSpotChecked = cBlogSpot.Checked;
        objCommApps.FacebookChecked = cFacebook.Checked;
        objCommApps.FaceBookGroupLinkChecked = cFacebookGroupLink.Checked;

        CMSv3.Entities.UserDetails objUserDetails = new CMSv3.Entities.UserDetails();

        objUserDetails.FullName = tFullName.Text;
        objUserDetails.NickName = tNickName.Text;
        objUserDetails.Email = tEmail.Text;

        if (tHandPhone.Text == "")
            tHandPhone.Text = "0";
        objUserDetails.Handphone = Convert.ToInt64(tHandPhone.Text);

        if (tHomePhone.Text == "")
            tHomePhone.Text = "0";
        objUserDetails.Homephone = Convert.ToInt64(tHomePhone.Text);

        if (tFaxNo.Text == "")
            tFaxNo.Text = "0";
        objUserDetails.FaxNo = Convert.ToInt64(tFaxNo.Text);

        String tmpAddress = tAddress.Text;
        tmpAddress = tmpAddress.ToString().Replace(Environment.NewLine, "<br/>");
        objUserDetails.Address = tmpAddress;

        objUserDetails.CompanyName = tCompanyName.Text;


        //String tmpCompanyinfo = tCompanyInfo.Text;
        //tmpCompanyinfo = tmpCompanyinfo.ToString().Replace(Environment.NewLine, "<br/>");
        //objUserDetails.CompanyInfo = tmpCompanyinfo;

        objUserDetails.UserID = Convert.ToInt32(Session["UserID"]);

        objUserDetails.CompanyNameChecked = cCompanyName.Checked;
        objUserDetails.NickNameChecked = cNickName.Checked;
        objUserDetails.EmailChecked = cEmail.Checked;
        objUserDetails.HandPhoneChecked = cHandPhone.Checked;
        objUserDetails.HomePhoneChecked = cHomePhone.Checked;
        objUserDetails.FaxNoChecked = cFaxNo.Checked;
        objUserDetails.UserPhotoChecked = cUserPhoto.Checked;
        objUserDetails.AddressChecked = cAddress.Checked;
        

        CMSv3.Entities.MyImage objUserPhoto = new CMSv3.Entities.MyImage();

        objUserPhoto.ActualImgName = strImgActual_FileName;
        objUserPhoto.ImgName = strImgFileName;
        objUserPhoto.ImgPath = GlobalVar.GetImgStoreFolder.ToString();
        objUserPhoto.ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.UserImage);


        int Status = objBAL_ActSettings.InsertUpdate_Settings_HomePageData(objUserDetails, objCommApps, objUserPhoto);
        string result = string.Empty;
        if (Status > 0)
        {
            result = "success";
        }
        else
        {
            result = "failure";
        }

        FrmAccount.ChangeMode(FormViewMode.ReadOnly);
        LoadSettingsData();


    }

    protected void FrmAccount_ModeChanged(object sender, EventArgs e)
    {

    }
    protected void FrmAccount_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FrmAccount.ChangeMode(e.NewMode);

        LoadSettingsData();
            
    }
    protected void FrmAccount_DataBound(object sender, EventArgs e)
    {

        FormViewRow Frow = (FormViewRow)FrmAccount.Row;

        //TextBox objContent = (TextBox)Frow.FindControl("txtCompanyInfo");

        //if (objContent != null)
        //{
        //    string tmpCompanyInfoContent = objContent.Text;
        //    tmpCompanyInfoContent = tmpCompanyInfoContent.ToString().Replace("<br/>", Environment.NewLine);
        //    objContent.Text = tmpCompanyInfoContent;
        //}

        TextBox objHandPphone = (TextBox)Frow.FindControl("txtHandPhone");
        if (objHandPphone != null)
        {
            objHandPphone.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        }

        TextBox objHomePhone = (TextBox)Frow.FindControl("txtHomePhone");
        if (objHomePhone != null)
        {
            objHomePhone.Attributes.Add("onkeypress", "javascript:return CheckKeyCode(event)");
        }



        TextBox objAddress = (TextBox)Frow.FindControl("txtAddress");
        if (objAddress != null)
        {
            string tmpAddressText = objAddress.Text;
            tmpAddressText = tmpAddressText.ToString().Replace("<br/>", Environment.NewLine);
            objAddress.Text = tmpAddressText;
        }




        Image objUserPhoto = (Image)FrmAccount.Row.FindControl("ImgUserPhoto");

        if (FrmAccount.CurrentMode == FormViewMode.Insert)
        {
            if (objUserPhoto != null)
                objUserPhoto.ImageUrl = @"~/ImageRepository/Dummy_User.gif"; 

        }
        //if (objUserPhoto != null)
        //    objUserPhoto.ImageUrl = @"~/ImageRepository/" + DataBinder.Eval(FrmAccount.DataItem, "ImgName").ToString();
        //else
        //    objUserPhoto.ImageUrl = "~/ImageRepository/dummyUser.gif";



    }
    protected void FrmAccount_ItemInserting(object sender, FormViewInsertEventArgs e)
    {


        //Get all the Data. 

        TextBox tFullName = (TextBox)FrmAccount.Row.FindControl("txtFullName");
        TextBox tNickName = (TextBox)FrmAccount.Row.FindControl("txtNickName");
        TextBox tEmail = (TextBox)FrmAccount.Row.FindControl("txtEmail");
        TextBox tHandPhone = (TextBox)FrmAccount.Row.FindControl("txtHandPhone");
        TextBox tHomePhone = (TextBox)FrmAccount.Row.FindControl("txtHomePhone");
        TextBox tFaxNo = (TextBox)FrmAccount.Row.FindControl("txtFaxNo");
        TextBox tAddress = (TextBox)FrmAccount.Row.FindControl("txtAddress");

            //.. Checkboxes for user details 
            CheckBox cCompanyName = (CheckBox)FrmAccount.Row.FindControl("chkCompanyName");
            CheckBox cNickName = (CheckBox)FrmAccount.Row.FindControl("chkNickName");
            CheckBox cEmail = (CheckBox)FrmAccount.Row.FindControl("chkEmail");
            CheckBox cHandPhone = (CheckBox)FrmAccount.Row.FindControl("chkHandPhone");
            CheckBox cHomePhone = (CheckBox)FrmAccount.Row.FindControl("chkHomePhone");
            CheckBox cFaxNo = (CheckBox)FrmAccount.Row.FindControl("chkFaxNo");
            CheckBox cAddress = (CheckBox)FrmAccount.Row.FindControl("chkAddress");
            CheckBox cUserPhoto = (CheckBox)FrmAccount.Row.FindControl("chkUserPhoto");


        TextBox tYahooID = (TextBox)FrmAccount.Row.FindControl("txtYahooID");
        TextBox tHotmailID = (TextBox)FrmAccount.Row.FindControl("txtHotmailID");
        TextBox tSkypeID = (TextBox)FrmAccount.Row.FindControl("txtSkypeID");
        TextBox tTwitterID = (TextBox)FrmAccount.Row.FindControl("txtTwitterID");
        TextBox tBlogSpotID = (TextBox)FrmAccount.Row.FindControl("txtBlogSpotID");
        TextBox tFacebookId = (TextBox)FrmAccount.Row.FindControl("txtFacebookId");
        TextBox tFacebookGroupLink = (TextBox)FrmAccount.Row.FindControl("txtFacebookGroupLink");
        TextBox tCompanyName = (TextBox)FrmAccount.Row.FindControl("txtCompanyName");
        //TextBox tCompanyInfo = (TextBox)FrmAccount.Row.FindControl("txtCompanyInfo");


        CheckBox cYahoo = (CheckBox)FrmAccount.Row.FindControl("chkYahoo");
        CheckBox cHotmail = (CheckBox)FrmAccount.Row.FindControl("chkHotmail");
        //CheckBox cGoogle = (CheckBox)FrmAccount.Row.FindControl("chkGoogle");
        CheckBox cSkype = (CheckBox)FrmAccount.Row.FindControl("chkSkype");
        CheckBox cTwitter = (CheckBox)FrmAccount.Row.FindControl("chkTwitter");
        CheckBox cBlogSpot = (CheckBox)FrmAccount.Row.FindControl("chkBlogSpot");
        CheckBox cFacebook = (CheckBox)FrmAccount.Row.FindControl("chkFacebook");
        CheckBox cFacebookGroupLink = (CheckBox)FrmAccount.Row.FindControl("chkFaceBookGroupLink");
        FileUpload fUserPhoto = (FileUpload)FrmAccount.Row.FindControl("fupl_UserPhoto");

        string strImgFileName = string.Empty;
        string strImgActual_FileName = string.Empty;
        string strImgFileURL = string.Empty;

        Random rnum = new Random();

        if (fUserPhoto.HasFile)
        {
            strImgFileName = Session["UserID"].ToString() + "_" + Convert.ToString(rnum.Next(9999999)) + "_" + fUserPhoto.FileName;
            strImgActual_FileName = fUserPhoto.FileName;

            //instead of server.mapPath set the path in web.config file and use that path.
            //strImgFileURL = Server.MapPath("~") + GlobalVar.GetImgStoreFolder.ToString();
            strImgFileURL = Server.MapPath("~") + @"\ImageRepository\";

            fUserPhoto.SaveAs(strImgFileURL + strImgFileName);

        }


        CMSv3.Entities.CommApps objCommApps = new CMSv3.Entities.CommApps();

        objCommApps.yahooid = tYahooID.Text;
        objCommApps.Hotmailid = tHotmailID.Text;
        objCommApps.Skypeid = tSkypeID.Text;
        objCommApps.Twitterid = tTwitterID.Text;
        objCommApps.BlogSpotid = tBlogSpotID.Text;
        objCommApps.Facebookid = tFacebookId.Text;
        objCommApps.FaceBookGroupLink = tFacebookGroupLink.Text;

     
        objCommApps.yahooChecked = cYahoo.Checked;
        objCommApps.HotmailChecked = cHotmail.Checked;
        objCommApps.SkypeChecked = cSkype.Checked;
        objCommApps.TwitterChecked = cTwitter.Checked;
        objCommApps.BlogSpotChecked = cBlogSpot.Checked;
        objCommApps.FacebookChecked = cFacebook.Checked;
        objCommApps.FaceBookGroupLinkChecked = cFacebookGroupLink.Checked;


        CMSv3.Entities.UserDetails objUserDetails = new CMSv3.Entities.UserDetails();

        objUserDetails.FullName = tFullName.Text;
        objUserDetails.NickName = tNickName.Text;
        objUserDetails.Email = tEmail.Text;
        
        if(tHandPhone.Text != "")
            objUserDetails.Handphone = Convert.ToInt64(tHandPhone.Text);
        else
            objUserDetails.Handphone = 0;

        if (tHomePhone.Text != "")
            objUserDetails.Homephone = Convert.ToInt64(tHomePhone.Text);
        else
            objUserDetails.Homephone = 0;

        if (tFaxNo.Text != "")
            objUserDetails.FaxNo = Convert.ToInt64(tFaxNo.Text);
        else
            objUserDetails.FaxNo = 0;


        objUserDetails.CompanyName = tCompanyName.Text;
        objUserDetails.Address = tAddress.Text;

        objUserDetails.CompanyNameChecked = cCompanyName.Checked;
        objUserDetails.NickNameChecked = cNickName.Checked;
        objUserDetails.EmailChecked = cEmail.Checked;
        objUserDetails.HandPhoneChecked = cHandPhone.Checked;
        objUserDetails.HomePhoneChecked = cHomePhone.Checked;
        objUserDetails.FaxNoChecked = cFaxNo.Checked;
        objUserDetails.UserPhotoChecked = cUserPhoto.Checked;
        objUserDetails.AddressChecked = cAddress.Checked;


        //string TmpCompanyInfo = tCompanyInfo.Text;
        //TmpCompanyInfo = TmpCompanyInfo.ToString().Replace(Environment.NewLine, "<br/>");
        // objUserDetails.CompanyInfo = TmpCompanyInfo;

        objUserDetails.UserID = Convert.ToInt32(Session["UserID"]);


        CMSv3.Entities.MyImage objUserPhoto = new CMSv3.Entities.MyImage();

        objUserPhoto.ActualImgName = strImgActual_FileName;
        objUserPhoto.ImgName = strImgFileName;
        objUserPhoto.ImgPath = GlobalVar.GetImgStoreFolder.ToString();
        objUserPhoto.ImgType = Convert.ToInt16(GlobalVar.ImageTypeEnums.UserImage);


        int Status = objBAL_ActSettings.InsertUpdate_Settings_HomePageData(objUserDetails, objCommApps, objUserPhoto);
        string result = string.Empty;
        if (Status > 0)
        {
            result = "success";
        }
        else
        {
            result = "failure";
        }

        FrmAccount.ChangeMode(FormViewMode.ReadOnly);
        LoadSettingsData();


    }
    protected void FrmAccount_PreRender(object sender, EventArgs e)
    {

        Literal ltFullName = (Literal)FrmAccount.Row.FindControl("LtrUserName");
        Literal ltNickName = (Literal)FrmAccount.Row.FindControl("LtrNickName");
        Literal ltEmail = (Literal)FrmAccount.Row.FindControl("LtrEmail");
        Literal ltHandPhone = (Literal)FrmAccount.Row.FindControl("LtrHandPhone");
        Literal ltHomePhone = (Literal)FrmAccount.Row.FindControl("LtrHomePhone");
        Literal ltUserDetails = (Literal)FrmAccount.Row.FindControl("ltrUserDetails");
        Literal ltDisplayAtWebsite = (Literal)FrmAccount.Row.FindControl("LtrDisplayAtWebsite");
        Literal ltDisplayAtWebsite2 = (Literal)FrmAccount.Row.FindControl("LtrDisplayAtWebsite2");
        Literal ltMyPhoto = (Literal)FrmAccount.Row.FindControl("ltrMyPhoto");
        Literal ltFollowUs = (Literal)FrmAccount.Row.FindControl("ltrFollowUs");
        
        

        Literal ltAddress = (Literal)FrmAccount.Row.FindControl("LtrAddress");
        Literal ltCompanyName = (Literal)FrmAccount.Row.FindControl("LtrCompanyName");

        ltFullName.Text = Resources.LangResources.Name;
        ltNickName.Text = Resources.LangResources.Nickname;
        ltEmail.Text = Resources.LangResources.Email;
        ltHandPhone.Text = Resources.LangResources.HandPhone;
        ltHomePhone.Text = Resources.LangResources.HomePhone;

        ltCompanyName.Text = Resources.LangResources.Company;
        ltAddress.Text = Resources.LangResources.Address;
        ltDisplayAtWebsite.Text = Resources.LangResources.DisplayatWebsite;
        if (ltDisplayAtWebsite2 != null)
        ltDisplayAtWebsite2.Text = Resources.LangResources.DisplayatWebsite; 
        
        LtrMyActSettings.Text = Resources.LangResources.MyAccount + " " + Resources.LangResources.Settings;
        if(ltFollowUs != null)
        ltFollowUs.Text = Resources.LangResources.FollowUson;


        Button btUpdate = (Button)FrmAccount.Row.FindControl("BtnUpdate"); 
        if (btUpdate != null)
            btUpdate.Text = Resources.LangResources.Save + " " + Resources.LangResources.MyAccount + " " + Resources.LangResources.Settings;

        Button BtEdit = (Button)FrmAccount.Row.FindControl("BtnEdit");
        if (BtEdit != null)
            BtEdit.Text = Resources.LangResources.Edit + " " + Resources.LangResources.MyAccount + " " + Resources.LangResources.Settings;


        Button BtnCancel = (Button)FrmAccount.Row.FindControl("BtnCancel");
        if (BtnCancel != null)
            BtnCancel.Text = Resources.LangResources.Cancel;


        Label lblLocationMap = (Label)FrmAccount.Row.FindControl("lblLocationMap");

        if (lblLocationMap != null)
            lblLocationMap.Text = Resources.LangResources.LocationMap;


        ltMyPhoto.Text = Resources.LangResources.My + " " + Resources.LangResources.Photo; 

        

    }
}
