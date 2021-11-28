using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class SuperAdmin_SA_DomainReg_ParamValues : System.Web.UI.Page
{

    SqlConnection dbConn;
    SqlCommand dbCmd;
    SqlDataAdapter dbAdap;
    //SqlDataReader dbReader;

    string strSQL = string.Empty;

    DataTable dt;



    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadFormValues();
           
        }

        

    }


    protected void LoadFormValues()
    {


        strSQL = "SELECT Dpid, Years, PromotionCode, RegistrantOrganizationName, RegistrantJobTitle, RegistrantFirstName, RegistrantLastName, " +
                    "RegistrantAddress1, RegistrantAddress2,  RegistrantCity, RegistrantStateProvince, RegistrantStateProvinceChoice, " +
                    "RegistrantPostalCode, RegistrantCountry, RegistrantPhone, RegistrantPhoneExt, RegistrantFax,RegistrantEmailAddress, " +
                    "TechOrganizationName,TechJobTitle,TechFirstName,TechLastName,TechAddress1,TechAddress2,TechCity,TechStateProvince, " +
                    "TechStateProvinceChoice,TechPostalCode,TechCountry,TechPhone,TechPhoneExt,TechFax,TechEmailAddress, " +
                    "AdminOrganizationName,AdminJobTitle,AdminFirstName,AdminLastName,AdminAddress1,AdminAddress2,AdminCity, " +
                    "AdminStateProvince,AdminStateProvinceChoice,AdminPostalCode,AdminCountry,AdminPhone,AdminPhoneExt,AdminFax, " +
                    "AdminEmailAddress,AuxBillingOrganizationName,AuxBillingJobTitle,AuxBillingFirstName,AuxBillingLastName, " +
                    "AuxBillingAddress1,AuxBillingAddress2,AuxBillingCity,AuxBillingStateProvince,AuxBillingStateProvinceChoice, " +
                    "AuxBillingPostalCode,AuxBillingCountry,AuxBillingPhone,AuxBillingPhoneExt,AuxBillingFax,AuxBillingEmailAddress, " +
                    "BillingFirstName,BillingLastName,BillingAddress1,BillingAddress2,BillingCity,BillingStateProvince, " +
                    "BillingStateProvinceChoice,BillingPostalCode,BillingCountry,BillingPhone,BillingPhoneExt,BillingFax, " +
                    "BillingEmailAddress,Nameservers,Nameservers2,AddFreeWhoisguard,WGEnabled,AddFreePositiveSSL " +
                    "from tblDomainParams ";

        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();

            //dbCmd = new SqlCommand(strSQL, dbConn);
            //dbReader = dbCmd.ExecuteReader();

            dbAdap = new SqlDataAdapter(strSQL, dbConn);
            dt = new DataTable();
            dbAdap.Fill(dt);

            FrmDomain.DataSource = dt;
            FrmDomain.DataBind();



        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
        }

    }


    protected void FrmDomain_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        FrmDomain.ChangeMode(e.NewMode);
        LoadFormValues();

    }

    protected void FrmDomain_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {


        //Get all the Data. 

        TextBox YearsTextBox = (TextBox)FrmDomain.Row.FindControl("YearsTextBox");
        TextBox PromotionCodeTextBox = (TextBox)FrmDomain.Row.FindControl("PromotionCodeTextBox");
        
        TextBox RegistrantOrganizationNameTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantOrganizationNameTextBox");
        TextBox RegistrantJobTitleTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantJobTitleTextBox");
        TextBox RegistrantFirstNameTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantFirstNameTextBox");
        TextBox RegistrantLastNameTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantLastNameTextBox");
        TextBox RegistrantAddress1TextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantAddress1TextBox");
        TextBox RegistrantAddress2TextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantAddress2TextBox");
        TextBox RegistrantCityTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantCityTextBox");
        TextBox RegistrantStateProvinceTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantStateProvinceTextBox");
        TextBox RegistrantStateProvinceChoiceTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantStateProvinceChoiceTextBox");
        TextBox RegistrantPostalCodeTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantPostalCodeTextBox");
        TextBox RegistrantCountryTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantCountryTextBox");
        TextBox RegistrantPhoneTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantPhoneTextBox");
        TextBox RegistrantPhoneExtTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantPhoneExtTextBox");
        TextBox RegistrantFaxTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantFaxTextBox");
        TextBox RegistrantEmailAddressTextBox = (TextBox)FrmDomain.Row.FindControl("RegistrantEmailAddressTextBox");

        TextBox TechOrganizationNameTextBox = (TextBox)FrmDomain.Row.FindControl("TechOrganizationNameTextBox");
        TextBox TechJobTitleTextBox = (TextBox)FrmDomain.Row.FindControl("TechJobTitleTextBox");
        TextBox TechFirstNameTextBox = (TextBox)FrmDomain.Row.FindControl("TechFirstNameTextBox");
        TextBox TechLastNameTextBox = (TextBox)FrmDomain.Row.FindControl("TechLastNameTextBox");
        TextBox TechAddress1TextBox = (TextBox)FrmDomain.Row.FindControl("TechAddress1TextBox");
        TextBox TechAddress2TextBox = (TextBox)FrmDomain.Row.FindControl("TechAddress2TextBox");
        TextBox TechCityTextBox = (TextBox)FrmDomain.Row.FindControl("TechCityTextBox");
        TextBox TechStateProvinceTextBox = (TextBox)FrmDomain.Row.FindControl("TechStateProvinceTextBox");
        TextBox TechStateProvinceChoiceTextBox = (TextBox)FrmDomain.Row.FindControl("TechStateProvinceChoiceTextBox");
        TextBox TechPostalCodeTextBox = (TextBox)FrmDomain.Row.FindControl("TechPostalCodeTextBox");
        TextBox TechCountryTextBox = (TextBox)FrmDomain.Row.FindControl("TechCountryTextBox");
        TextBox TechPhoneTextBox = (TextBox)FrmDomain.Row.FindControl("TechPhoneTextBox");
        TextBox TechPhoneExtTextBox = (TextBox)FrmDomain.Row.FindControl("TechPhoneExtTextBox");
        TextBox TechFaxTextBox = (TextBox)FrmDomain.Row.FindControl("TechFaxTextBox");
        TextBox TechEmailAddressTextBox = (TextBox)FrmDomain.Row.FindControl("TechEmailAddressTextBox");

        TextBox AdminOrganizationNameTextBox = (TextBox)FrmDomain.Row.FindControl("AdminOrganizationNameTextBox");
        TextBox AdminJobTitleTextBox = (TextBox)FrmDomain.Row.FindControl("AdminJobTitleTextBox");
        TextBox AdminFirstNameTextBox = (TextBox)FrmDomain.Row.FindControl("AdminFirstNameTextBox");
        TextBox AdminLastNameTextBox = (TextBox)FrmDomain.Row.FindControl("AdminLastNameTextBox");
        TextBox AdminAddress1TextBox = (TextBox)FrmDomain.Row.FindControl("AdminAddress1TextBox");
        TextBox AdminAddress2TextBox = (TextBox)FrmDomain.Row.FindControl("AdminAddress2TextBox");
        TextBox AdminCityTextBox = (TextBox)FrmDomain.Row.FindControl("AdminCityTextBox");
        TextBox AdminStateProvinceTextBox = (TextBox)FrmDomain.Row.FindControl("AdminStateProvinceTextBox");
        TextBox AdminStateProvinceChoiceTextBox = (TextBox)FrmDomain.Row.FindControl("AdminStateProvinceChoiceTextBox");
        TextBox AdminPostalCodeTextBox = (TextBox)FrmDomain.Row.FindControl("AdminPostalCodeTextBox");
        TextBox AdminCountryTextBox = (TextBox)FrmDomain.Row.FindControl("AdminCountryTextBox");
        TextBox AdminPhoneTextBox = (TextBox)FrmDomain.Row.FindControl("AdminPhoneTextBox");
        TextBox AdminPhoneExtTextBox = (TextBox)FrmDomain.Row.FindControl("AdminPhoneExtTextBox");
        TextBox AdminFaxTextBox = (TextBox)FrmDomain.Row.FindControl("AdminFaxTextBox");
        TextBox AdminEmailAddressTextBox = (TextBox)FrmDomain.Row.FindControl("AdminEmailAddressTextBox");

        TextBox AuxBillingOrganizationNameTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingOrganizationNameTextBox");
        TextBox AuxBillingJobTitleTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingJobTitleTextBox");

        TextBox AuxBillingFirstNameTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingFirstNameTextBox");
        TextBox AuxBillingLastNameTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingLastNameTextBox");
        TextBox AuxBillingAddress1TextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingAddress1TextBox");
        TextBox AuxBillingAddress2TextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingAddress2TextBox");
        TextBox AuxBillingCityTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingCityTextBox");
        TextBox AuxBillingStateProvinceTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingStateProvinceTextBox");
        TextBox AuxBillingStateProvinceChoiceTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingStateProvinceChoiceTextBox");
        TextBox AuxBillingPostalCodeTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingPostalCodeTextBox");
        TextBox AuxBillingCountryTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingCountryTextBox");
        TextBox AuxBillingPhoneTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingPhoneTextBox");
        TextBox AuxBillingPhoneExtTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingPhoneExtTextBox");
        TextBox AuxBillingFaxTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingFaxTextBox");
        TextBox AuxBillingEmailAddressTextBox = (TextBox)FrmDomain.Row.FindControl("AuxBillingEmailAddressTextBox");
        
        TextBox BillingFirstNameTextBox = (TextBox)FrmDomain.Row.FindControl("BillingFirstNameTextBox");
        TextBox BillingLastNameTextBox = (TextBox)FrmDomain.Row.FindControl("BillingLastNameTextBox");
        TextBox BillingAddress1TextBox = (TextBox)FrmDomain.Row.FindControl("BillingAddress1TextBox");
        TextBox BillingAddress2TextBox = (TextBox)FrmDomain.Row.FindControl("BillingAddress2TextBox");
        TextBox BillingCityTextBox = (TextBox)FrmDomain.Row.FindControl("BillingCityTextBox");

        TextBox BillingStateProvinceTextBox = (TextBox)FrmDomain.Row.FindControl("BillingStateProvinceTextBox");
        TextBox BillingStateProvinceChoiceTextBox = (TextBox)FrmDomain.Row.FindControl("BillingStateProvinceChoiceTextBox");
        TextBox BillingPostalCodeTextBox = (TextBox)FrmDomain.Row.FindControl("BillingPostalCodeTextBox");
        TextBox BillingCountryTextBox = (TextBox)FrmDomain.Row.FindControl("BillingCountryTextBox");
        TextBox BillingPhoneTextBox = (TextBox)FrmDomain.Row.FindControl("BillingPhoneTextBox");
        TextBox BillingPhoneExtTextBox = (TextBox)FrmDomain.Row.FindControl("BillingPhoneExtTextBox");
        TextBox BillingFaxTextBox = (TextBox)FrmDomain.Row.FindControl("BillingFaxTextBox");
        TextBox BillingEmailAddressTextBox = (TextBox)FrmDomain.Row.FindControl("BillingEmailAddressTextBox");

        TextBox NameserversTextBox = (TextBox)FrmDomain.Row.FindControl("NameserversTextBox");
        TextBox NameserversTextBox2 = (TextBox)FrmDomain.Row.FindControl("NameserversTextBox2");
        //TextBox AddFreeWhoisguardTextBox = (TextBox)FrmDomain.Row.FindControl("AddFreeWhoisguardTextBox");
        //TextBox WGEnabledTextBox = (TextBox)FrmDomain.Row.FindControl("WGEnabledTextBox");
        //TextBox AddFreePositiveSSLTextBox = (TextBox)FrmDomain.Row.FindControl("AddFreePositiveSSLTextBox");
        RadioButtonList rdoLst_AddWhoisGuard = (RadioButtonList)FrmDomain.Row.FindControl("rdoAddWhoisGuard");
        RadioButtonList rdoLst_WGEnabled = (RadioButtonList)FrmDomain.Row.FindControl("rdoWGEnabled");
        RadioButtonList rdoLst_FreePositiveSSL = (RadioButtonList)FrmDomain.Row.FindControl("rdoFreePositiveSSL");



        strSQL = "Update tblDomainParams set Years=" + YearsTextBox.Text +
            ", PromotionCode='" + PromotionCodeTextBox.Text +

        "', RegistrantOrganizationName='" + RegistrantOrganizationNameTextBox.Text +
        "', RegistrantJobTitle = '" + RegistrantJobTitleTextBox.Text +
        "', RegistrantFirstName = '" + RegistrantFirstNameTextBox.Text +
        "', RegistrantLastName = '" + RegistrantLastNameTextBox.Text +
        "', RegistrantAddress1= '" + RegistrantAddress1TextBox.Text +
        "', RegistrantAddress2= '" + RegistrantAddress2TextBox.Text +
        "', RegistrantCity = '" + RegistrantCityTextBox.Text +
        "', RegistrantStateProvince = '" + RegistrantStateProvinceTextBox.Text +
        "', RegistrantStateProvinceChoice = '" + RegistrantStateProvinceChoiceTextBox.Text +
        "', RegistrantPostalCode = '" + RegistrantPostalCodeTextBox.Text +
        "', RegistrantCountry = '" + RegistrantCountryTextBox.Text +
        "', RegistrantPhone = '" + RegistrantPhoneTextBox.Text +
        "', RegistrantPhoneExt = '" + RegistrantPhoneExtTextBox.Text +
        "', RegistrantFax = '" + RegistrantFaxTextBox.Text +
        "', RegistrantEmailAddress = '" + RegistrantEmailAddressTextBox.Text +

        "',TechOrganizationName = '" + TechOrganizationNameTextBox.Text +
        "',TechJobTitle = '" + TechJobTitleTextBox.Text +
        "',TechFirstName = '" + TechFirstNameTextBox.Text +
        "',TechLastName = '" + TechLastNameTextBox.Text +
        "',TechAddress1 = '" + TechAddress1TextBox.Text +
        "',TechAddress2 = '" + TechAddress2TextBox.Text +
        "',TechCity = '" + TechCityTextBox.Text +
        "',TechStateProvince = '" + TechStateProvinceTextBox.Text +
        "',TechStateProvinceChoice = '" + TechStateProvinceChoiceTextBox.Text +
        "',TechPostalCode = '" + TechPostalCodeTextBox.Text +
        "',TechCountry = '" + TechCountryTextBox.Text +
        "',TechPhone = '" + TechPhoneTextBox.Text +
        "',TechPhoneExt = '" + TechPhoneExtTextBox.Text +
        "',TechFax = '" + TechFaxTextBox.Text +
        "',TechEmailAddress = '" + TechEmailAddressTextBox.Text +

        "',AdminOrganizationName = '" + AdminOrganizationNameTextBox.Text +
        "',AdminJobTitle= '" + AdminJobTitleTextBox.Text +
        "',AdminFirstName= '" + AdminFirstNameTextBox.Text +
        "',AdminLastName= '" + AdminLastNameTextBox.Text +
        "',AdminAddress1= '" + AdminAddress1TextBox.Text +
        "',AdminAddress2= '" + AdminAddress2TextBox.Text +
        "',AdminCity= '" + AdminCityTextBox.Text +
        "',AdminStateProvince= '" + AdminStateProvinceTextBox.Text +
        "',AdminStateProvinceChoice = '" + AdminStateProvinceChoiceTextBox.Text +
        "',AdminPostalCode= '" + AdminPostalCodeTextBox.Text +
        "',AdminCountry= '" + AdminCountryTextBox.Text +
        "',AdminPhone= '" + AdminPhoneTextBox.Text +
        "',AdminPhoneExt= '" + AdminPhoneExtTextBox.Text +
        "',AdminFax= '" + AdminFaxTextBox.Text +
        "',AdminEmailAddress= '" + AdminEmailAddressTextBox.Text +

        "',AuxBillingOrganizationName = '" + AuxBillingOrganizationNameTextBox.Text +
        "',AuxBillingJobTitle = '" + AuxBillingJobTitleTextBox.Text +
        "',AuxBillingFirstName = '" + AuxBillingFirstNameTextBox.Text +
        "',AuxBillingLastName = '" + AuxBillingLastNameTextBox.Text +
        "',AuxBillingAddress1 = '" + AuxBillingAddress1TextBox.Text +
        "',AuxBillingAddress2 = '" + AuxBillingAddress2TextBox.Text +
        "',AuxBillingCity = '" + AuxBillingCityTextBox.Text +
        "',AuxBillingStateProvince = '" + AuxBillingStateProvinceTextBox.Text +
        "',AuxBillingStateProvinceChoice = '" + AuxBillingStateProvinceChoiceTextBox.Text +
        "',AuxBillingPostalCode = '" + AuxBillingPostalCodeTextBox.Text +
        "',AuxBillingCountry = '" + AuxBillingCountryTextBox.Text +
        "',AuxBillingPhone = '" + AuxBillingPhoneTextBox.Text +
        "',AuxBillingPhoneExt = '" + AuxBillingPhoneExtTextBox.Text +
        "',AuxBillingFax = '" + AuxBillingFaxTextBox.Text +
        "',AuxBillingEmailAddress = '" + AuxBillingEmailAddressTextBox.Text +

        "',BillingFirstName = '" + BillingFirstNameTextBox.Text +
        "',BillingLastName = '" + BillingLastNameTextBox.Text +
        "',BillingAddress1 = '" + BillingAddress1TextBox.Text +
        "',BillingAddress2 = '" + BillingAddress2TextBox.Text +
        "',BillingCity = '" + BillingCityTextBox.Text +
        "',BillingStateProvince  = '" + BillingStateProvinceTextBox.Text +
        "',BillingStateProvinceChoice  = '" + BillingStateProvinceChoiceTextBox.Text +
        "',BillingPostalCode = '" + BillingPostalCodeTextBox.Text +
        "',BillingCountry = '" + BillingCountryTextBox.Text +
        "',BillingPhone = '" + BillingPhoneTextBox.Text +
        "',BillingPhoneExt = '" + BillingPhoneExtTextBox.Text +
        "',BillingFax = '" + BillingFaxTextBox.Text +
        "',BillingEmailAddress = '" + BillingEmailAddressTextBox.Text +
        "',Nameservers = '" + NameserversTextBox.Text +
        "',Nameservers2 = '" + NameserversTextBox2.Text +
        "',AddFreeWhoisguard = '" + rdoLst_AddWhoisGuard.SelectedValue +
        "',WGEnabled = '" + rdoLst_WGEnabled.SelectedValue +
        "',AddFreePositiveSSL = '" + rdoLst_FreePositiveSSL.SelectedValue + "'";

        
        dbConn = new SqlConnection(GlobalVar.GetDbConnString);

        try
        {
            dbConn.Open();

            dbCmd = new SqlCommand(strSQL, dbConn);
            dbCmd.ExecuteNonQuery();

            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            dbConn.Close();
           
            
        }

        FrmDomain.ChangeMode(FormViewMode.ReadOnly);
        LoadFormValues();


    }
}
