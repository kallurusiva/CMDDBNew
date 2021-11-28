<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_DomainReg_ParamValues.aspx.cs" Inherits="SuperAdmin_SA_DomainReg_ParamValues" %>

<%@ Register src="SA_SideMenu_Users.ascx" tagname="SA_SideMenu_Users" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:SA_SideMenu_Users ID="SA_SideMenu_Users1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <form id="form2" runat="server">
<style>

label {

display: block;

float: left;

width: 80px;

}

    .style2
    {
        text-align: left;
    }
    .style3
    {
        text-align: left;
        font-weight: bold;
    }

</style>


<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>


    <table border="0" cellpadding="0" cellspacing="0" width="100%">
              
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                        <asp:Literal ID="ltrDomainRequests" runat="server" 
                                Text="Domain Registeration Parameters"></asp:Literal></td>
                        <td width="30%">
                           <%-- <uc2:SelectLanguage ID="ucSelectLanguage" runat="server" />--%>
                        </td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="98%">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%" align="left">
                            &nbsp;
                            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="50" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/>Processing... Please wait...
                             </div>
                            </ProgressTemplate>
                            
                            </asp:UpdateProgress>
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            &nbsp;</td>
                        <td>
                            &nbsp;</td></tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:FormView ID="FrmDomain" runat="server" CellPadding="4"  
                                 ForeColor="#333333" GridLines="Both" Width="600" 
                                onitemupdating="FrmDomain_ItemUpdating" onmodechanging="FrmDomain_ModeChanging"
                                
                                >
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" />
                                <EditItemTemplate>
                                
                                
                                  <table border="0" cellpadding="2" cellspacing="2" width="100%" class="stdtableBorder_AccountPage">
                                <tr>
                                 <td width="40%" class="style3">Dpid</td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="58%" class="style2">
                                     <asp:Label ID="DpidLabel" runat="server" Text='<%# Eval("Dpid") %>' />
                                    </td>
                                </tr>
                                      <tr>
                                          <td class="style3"">
                                              Years</td>
                                          <td >
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="YearsTextBox" runat="server" Text='<%# Bind("Years") %>' />
                                          </td>
                                      </tr>
                   
                                      <tr>
                                          <td class="style3">
                                              PromotionCode</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="PromotionCodeTextBox" runat="server" 
                                                  Text='<%# Bind("PromotionCode") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Registration Contact Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantOrganizationName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantOrganizationNameTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantOrganizationName") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantJobTitle</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantJobTitleTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantJobTitle") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantFirstName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantFirstNameTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantFirstName") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantLastName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantLastNameTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantLastName") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantAddress1</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantAddress1TextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantAddress1") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantAddress2</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantAddress2TextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantAddress2") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantCity</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantCityTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantCity") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantStateProvince</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantStateProvinceTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantStateProvince") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantStateProvinceChoice</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantStateProvinceChoiceTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantStateProvinceChoice") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantPostalCode</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantPostalCodeTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantPostalCode") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantCountry</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantCountryTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantCountry") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantPhone</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantPhoneTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantPhone") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantPhoneExt</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantPhoneExtTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantPhoneExt") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantFax</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantFaxTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantFax") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              RegistrantEmailAddress</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="RegistrantEmailAddressTextBox" runat="server" 
                                                  Text='<%# Bind("RegistrantEmailAddress") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Technical&nbsp; Contact Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechOrganizationName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechOrganizationNameTextBox" runat="server" 
                                                  Text='<%# Bind("TechOrganizationName") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechJobTitle</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechJobTitleTextBox" runat="server" 
                                                  Text='<%# Bind("TechJobTitle") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechFirstName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechFirstNameTextBox" runat="server" 
                                                  Text='<%# Bind("TechFirstName") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechLastName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechLastNameTextBox" runat="server" 
                                                  Text='<%# Bind("TechLastName") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechAddress1</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechAddress1TextBox" runat="server" 
                                                  Text='<%# Bind("TechAddress1") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechAddress2</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechAddress2TextBox" runat="server" 
                                                  Text='<%# Bind("TechAddress2") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechCity</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechCityTextBox" runat="server" 
                                                  Text='<%# Bind("TechCity") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechStateProvince</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechStateProvinceTextBox" runat="server" 
                                                  Text='<%# Bind("TechStateProvince") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechStateProvinceChoice</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechStateProvinceChoiceTextBox" runat="server" 
                                                  Text='<%# Bind("TechStateProvinceChoice") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechPostalCode</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechPostalCodeTextBox" runat="server" 
                                                  Text='<%# Bind("TechPostalCode") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechCountry</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechCountryTextBox" runat="server" 
                                                  Text='<%# Bind("TechCountry") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechPhone</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechPhoneTextBox" runat="server" 
                                                  Text='<%# Bind("TechPhone") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechPhoneExt</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechPhoneExtTextBox" runat="server" 
                                                  Text='<%# Bind("TechPhoneExt") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              TechFax</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechFaxTextBox" runat="server" Text='<%# Bind("TechFax") %>' /></td>
                                      </tr>
                                      
                                       <tr>
                                          <td class="style3">
                                              TechEmailAddress</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="TechEmailAddressTextBox" runat="server" Text='<%# Bind("TechEmailAddress") %>' /></td>
                                      </tr>
                                      
                                       <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Administrative Contact Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                      
                                       <tr>
                                           <td class="style3">
                                               AdminOrganizationName</td>
                                           <td>
                                               &nbsp;</td>
                                           <td class="style2">
                                               <asp:TextBox ID="AdminOrganizationNameTextBox" runat="server" 
                                                   Text='<%# Bind("AdminOrganizationName") %>' />
                                           </td>
                                      </tr>
                                      
                                       <tr>
                                          <td class="style3">
                                              AdminJobTitle</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminJobTitleTextBox" runat="server" Text='<%# Bind("AdminJobTitle") %>' /></td>
                                      </tr>
                                      
                                       <tr>
                                          <td class="style3">
                                              AdminFirstName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminFirstNameTextBox" runat="server" Text='<%# Bind("AdminFirstName") %>' /></td>
                                      </tr>
                                      
                                       <tr>
                                          <td class="style3">
                                              AdminLastName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminLastNameTextBox" runat="server" Text='<%# Bind("AdminLastName") %>' /></td>
                                      </tr>
                                      
                                       <tr>
                                          <td class="style3">
                                              AdminAddress1</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminAddress1TextBox" runat="server" Text='<%# Bind("AdminAddress1") %>' /></td>
                                      </tr>
                                       <tr>
                                          <td class="style3">
                                              AdminAddress2</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminAddress2TextBox" runat="server" Text='<%# Bind("AdminAddress2") %>' /></td>
                                      </tr>
                                      
                                       <tr>
                                          <td class="style3">
                                              AdminCity</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminCityTextBox" runat="server" Text='<%# Bind("AdminCity") %>' /></td>
                                      </tr>
                                      
                                       <tr>
                                          <td class="style3">
                                              AdminStateProvince</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminStateProvinceTextBox" runat="server" Text='<%# Bind("AdminStateProvince") %>' /></td>
                                      </tr>
                                      
                                        <tr>
                                          <td class="style3">
                                              AdminStateProvinceChoice</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminStateProvinceChoiceTextBox" runat="server" Text='<%# Bind("AdminStateProvinceChoice") %>' /></td>
                                      </tr>
                                        <tr>
                                          <td class="style3">
                                              AdminPostalCode</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminPostalCodeTextBox" runat="server" Text='<%# Bind("AdminPostalCode") %>' /></td>
                                      </tr>
                                       <tr>
                                          <td class="style3">
                                              AdminCountry</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminCountryTextBox" runat="server" Text='<%# Bind("AdminCountry") %>' /></td>
                                      </tr>
                                       <tr>
                                          <td class="style3">
                                              AdminPhone</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminPhoneTextBox" runat="server" Text='<%# Bind("AdminPhone") %>' /></td>
                                      </tr>
                                      
                                      <tr>
                                          <td class="style3">
                                              AdminPhoneExt</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminPhoneExtTextBox" runat="server" Text='<%# Bind("AdminPhoneExt") %>' /></td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AdminFax</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminFaxTextBox" runat="server" Text='<%# Bind("AdminFax") %>' /></td>
                                      </tr>
                                      
                                      <tr>
                                          <td class="style3">
                                              AdminEmailAddress</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AdminEmailAddressTextBox" runat="server" Text='<%# Bind("AdminEmailAddress") %>' /></td>
                                      </tr>
                                      <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Aux Billing Contact Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingOrganizationName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingOrganizationNameTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingOrganizationName") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingJobTitle</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingJobTitleTextBox" runat="server" Text='<%# Bind("AuxBillingJobTitle") %>' /></td>
                                      </tr>
                                      
                                      <tr>
                                          <td class="style3">
                                              AuxBillingFirstName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingFirstNameTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingFirstName") %>' />
                                              </td>
                                      </tr>
                                      
                                      <tr>
                                          <td class="style3">
                                              AuxBillingLastName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingLastNameTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingLastName") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingAddress1</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingAddress1TextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingAddress1") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingAddress2</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingAddress2TextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingAddress2") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingCity</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingCityTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingCity") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingStateProvince</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingStateProvinceTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingStateProvince") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingStateProvinceChoice</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingStateProvinceChoiceTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingStateProvinceChoice") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingPostalCode</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingPostalCodeTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingPostalCode") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingCountry</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingCountryTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingCountry") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingPhone</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingPhoneTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingPhone") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingPhoneExt</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingPhoneExtTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingPhoneExt") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingFax</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingFaxTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingFax") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AuxBillingEmailAddress</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="AuxBillingEmailAddressTextBox" runat="server" 
                                                  Text='<%# Bind("AuxBillingEmailAddress") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Biling Contact Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingFirstName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingFirstNameTextBox" runat="server" 
                                                  Text='<%# Bind("BillingFirstName") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingLastName</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingLastNameTextBox" runat="server" 
                                                  Text='<%# Bind("BillingLastName") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingAddress1</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingAddress1TextBox" runat="server" 
                                                  Text='<%# Bind("BillingAddress1") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingAddress2</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingAddress2TextBox" runat="server" 
                                                  Text='<%# Bind("BillingAddress2") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingCity</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingCityTextBox" runat="server" 
                                                  Text='<%# Bind("BillingCity") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingStateProvince</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingStateProvinceTextBox" runat="server" 
                                                  Text='<%# Bind("BillingStateProvince") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingStateProvinceChoice</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingStateProvinceChoiceTextBox" runat="server" 
                                                  Text='<%# Bind("BillingStateProvinceChoice") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingPostalCode</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingPostalCodeTextBox" runat="server" 
                                                  Text='<%# Bind("BillingPostalCode") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingCountry</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingCountryTextBox" runat="server" 
                                                  Text='<%# Bind("BillingCountry") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingPhone</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingPhoneTextBox" runat="server" 
                                                  Text='<%# Bind("BillingPhone") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingPhoneExt</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingPhoneExtTextBox" runat="server" 
                                                  Text='<%# Bind("BillingPhoneExt") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingFax</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingFaxTextBox" runat="server" 
                                                  Text='<%# Bind("BillingFax") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              BillingEmailAddress</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="BillingEmailAddressTextBox" runat="server" 
                                                  Text='<%# Bind("BillingEmailAddress") %>' />
                                          </td>
                                      </tr>
                                      
                                       <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Other Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                      
                                      <tr>
                                          <td class="style3">
                                              Nameservers 1</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="NameserversTextBox" runat="server" 
                                                  Text='<%# Bind("Nameservers") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              Nameservers 2</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <asp:TextBox ID="NameserversTextBox2" runat="server" 
                                                  Text='<%# Bind("Nameservers2") %>' />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AddFreeWhoisguard</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                             <%-- <asp:TextBox ID="AddFreeWhoisguardTextBox" runat="server" 
                                                  Text='<%# Bind("AddFreeWhoisguard") %>' />--%>
                                              <asp:RadioButtonList ID="rdoAddWhoisGuard" runat="server" RepeatColumns="2" TextAlign="Left" 
                                                  RepeatDirection="Horizontal" CellPadding="2" CellSpacing="2" Width="50px">
                                              
                                                  <asp:ListItem Selected="True">YES</asp:ListItem>
                                                  <asp:ListItem>NO</asp:ListItem>
                                              
                                              </asp:RadioButtonList>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              Who is Guard Enabled</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <%--<asp:TextBox ID="WGEnabledTextBox" runat="server" 
                                                  Text='<%# Bind("WGEnabled") %>' />--%>
                                                   <asp:RadioButtonList ID="rdoWGEnabled" runat="server" RepeatColumns="2" 
                                                  RepeatDirection="Horizontal" CellPadding="2" CellSpacing="2" 
                                                  TextAlign="Left" Width="50px">
                                                  <asp:ListItem Selected="True">YES</asp:ListItem>
                                                  <asp:ListItem>NO</asp:ListItem>
                                              
                                              </asp:RadioButtonList>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              AddFreePositiveSSL</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              <%--<asp:TextBox ID="AddFreePositiveSSLTextBox" runat="server" 
                                                  Text='<%# Bind("AddFreePositiveSSL") %>' />
                                              <br />--%>
                                              <asp:RadioButtonList ID="rdoFreePositiveSSL" runat="server" RepeatColumns="2" 
                                                  RepeatDirection="Horizontal" CellPadding="2" CellSpacing="2" Width="50px">
                                                  <asp:ListItem Selected="True">YES</asp:ListItem>
                                                  <asp:ListItem>NO</asp:ListItem>
                                              </asp:RadioButtonList>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="style3">
                                              &nbsp;</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                              &nbsp;</td>
                                      </tr>
                                      
                                </table>

                                    <br />
                                    <br />
                                    <asp:LinkButton ID="UpdateButton" CssClass="stdbuttonCRUD" runat="server" CausesValidation="True" 
                                        CommandName="Update" Text="Update" />
                                    &nbsp;<asp:LinkButton ID="UpdateCancelButton" CssClass="stdbuttonCRUD" runat="server" 
                                        CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                </EditItemTemplate>
                                <EditRowStyle BackColor="#D6F0E8" />
                                
                                
                                <InsertItemTemplate>
                                  <%--  DomainName:
                                    <asp:TextBox ID="DomainNameTextBox" runat="server" 
                                        Text='<%# Bind("DomainName") %>' />
                                    <br />--%>
                                    Years:
                                    <asp:TextBox ID="YearsTextBox" runat="server" Text='<%# Bind("Years") %>' />
                                    <br />
                                    PromotionCode:
                                    <asp:TextBox ID="PromotionCodeTextBox" runat="server" 
                                        Text='<%# Bind("PromotionCode") %>' />
                                    <br />
                                    RegistrantOrganizationName:
                                    <asp:TextBox ID="RegistrantOrganizationNameTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantOrganizationName") %>' />
                                    <br />
                                    RegistrantJobTitle:
                                    <asp:TextBox ID="RegistrantJobTitleTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantJobTitle") %>' />
                                    <br />
                                    RegistrantFirstName:
                                    <asp:TextBox ID="RegistrantFirstNameTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantFirstName") %>' />
                                    <br />
                                    RegistrantLastName:
                                    <asp:TextBox ID="RegistrantLastNameTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantLastName") %>' />
                                    <br />
                                    RegistrantAddress1:
                                    <asp:TextBox ID="RegistrantAddress1TextBox" runat="server" 
                                        Text='<%# Bind("RegistrantAddress1") %>' />
                                    <br />
                                    RegistrantAddress2:
                                    <asp:TextBox ID="RegistrantAddress2TextBox" runat="server" 
                                        Text='<%# Bind("RegistrantAddress2") %>' />
                                    <br />
                                    RegistrantCity:
                                    <asp:TextBox ID="RegistrantCityTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantCity") %>' />
                                    <br />
                                    RegistrantStateProvince:
                                    <asp:TextBox ID="RegistrantStateProvinceTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantStateProvince") %>' />
                                    <br />
                                    RegistrantStateProvinceChoice:
                                    <asp:TextBox ID="RegistrantStateProvinceChoiceTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantStateProvinceChoice") %>' />
                                    <br />
                                    RegistrantPostalCode:
                                    <asp:TextBox ID="RegistrantPostalCodeTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantPostalCode") %>' />
                                    <br />
                                    RegistrantCountry:
                                    <asp:TextBox ID="RegistrantCountryTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantCountry") %>' />
                                    <br />
                                    RegistrantPhone:
                                    <asp:TextBox ID="RegistrantPhoneTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantPhone") %>' />
                                    <br />
                                    RegistrantPhoneExt:
                                    <asp:TextBox ID="RegistrantPhoneExtTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantPhoneExt") %>' />
                                    <br />
                                    RegistrantFax:
                                    <asp:TextBox ID="RegistrantFaxTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantFax") %>' />
                                    <br />
                                    RegistrantEmailAddress:
                                    <asp:TextBox ID="RegistrantEmailAddressTextBox" runat="server" 
                                        Text='<%# Bind("RegistrantEmailAddress") %>' />
                                    <br />
                                    TechOrganizationName:
                                    <asp:TextBox ID="TechOrganizationNameTextBox" runat="server" 
                                        Text='<%# Bind("TechOrganizationName") %>' />
                                    <br />
                                    TechJobTitle:
                                    <asp:TextBox ID="TechJobTitleTextBox" runat="server" 
                                        Text='<%# Bind("TechJobTitle") %>' />
                                    <br />
                                    TechFirstName:
                                    <asp:TextBox ID="TechFirstNameTextBox" runat="server" 
                                        Text='<%# Bind("TechFirstName") %>' />
                                    <br />
                                    TechLastName:
                                    <asp:TextBox ID="TechLastNameTextBox" runat="server" 
                                        Text='<%# Bind("TechLastName") %>' />
                                    <br />
                                    TechAddress1:
                                    <asp:TextBox ID="TechAddress1TextBox" runat="server" 
                                        Text='<%# Bind("TechAddress1") %>' />
                                    <br />
                                    TechAddress2:
                                    <asp:TextBox ID="TechAddress2TextBox" runat="server" 
                                        Text='<%# Bind("TechAddress2") %>' />
                                    <br />
                                    TechCity:
                                    <asp:TextBox ID="TechCityTextBox" runat="server" 
                                        Text='<%# Bind("TechCity") %>' />
                                    <br />
                                    TechStateProvince:
                                    <asp:TextBox ID="TechStateProvinceTextBox" runat="server" 
                                        Text='<%# Bind("TechStateProvince") %>' />
                                    <br />
                                    TechStateProvinceChoice:
                                    <asp:TextBox ID="TechStateProvinceChoiceTextBox" runat="server" 
                                        Text='<%# Bind("TechStateProvinceChoice") %>' />
                                    <br />
                                    TechPostalCode:
                                    <asp:TextBox ID="TechPostalCodeTextBox" runat="server" 
                                        Text='<%# Bind("TechPostalCode") %>' />
                                    <br />
                                    TechCountry:
                                    <asp:TextBox ID="TechCountryTextBox" runat="server" 
                                        Text='<%# Bind("TechCountry") %>' />
                                    <br />
                                    TechPhone:
                                    <asp:TextBox ID="TechPhoneTextBox" runat="server" 
                                        Text='<%# Bind("TechPhone") %>' />
                                    <br />
                                    TechPhoneExt:
                                    <asp:TextBox ID="TechPhoneExtTextBox" runat="server" 
                                        Text='<%# Bind("TechPhoneExt") %>' />
                                    <br />
                                    TechFax:
                                    <asp:TextBox ID="TechFaxTextBox" runat="server" Text='<%# Bind("TechFax") %>' />
                                    <br />
                                    TechEmailAddress:
                                    <asp:TextBox ID="TechEmailAddressTextBox" runat="server" 
                                        Text='<%# Bind("TechEmailAddress") %>' />
                                    <br />
                                    AdminOrganizationName:
                                    <asp:TextBox ID="AdminOrganizationNameTextBox" runat="server" 
                                        Text='<%# Bind("AdminOrganizationName") %>' />
                                    <br />
                                    AdminJobTitle:
                                    <asp:TextBox ID="AdminJobTitleTextBox" runat="server" 
                                        Text='<%# Bind("AdminJobTitle") %>' />
                                    <br />
                                    AdminFirstName:
                                    <asp:TextBox ID="AdminFirstNameTextBox" runat="server" 
                                        Text='<%# Bind("AdminFirstName") %>' />
                                    <br />
                                    AdminLastName:
                                    <asp:TextBox ID="AdminLastNameTextBox" runat="server" 
                                        Text='<%# Bind("AdminLastName") %>' />
                                    <br />
                                    AdminAddress1:
                                    <asp:TextBox ID="AdminAddress1TextBox" runat="server" 
                                        Text='<%# Bind("AdminAddress1") %>' />
                                    <br />
                                    AdminAddress2:
                                    <asp:TextBox ID="AdminAddress2TextBox" runat="server" 
                                        Text='<%# Bind("AdminAddress2") %>' />
                                    <br />
                                    AdminCity:
                                    <asp:TextBox ID="AdminCityTextBox" runat="server" 
                                        Text='<%# Bind("AdminCity") %>' />
                                    <br />
                                    AdminStateProvince:
                                    <asp:TextBox ID="AdminStateProvinceTextBox" runat="server" 
                                        Text='<%# Bind("AdminStateProvince") %>' />
                                    <br />
                                    AdminStateProvinceChoice:
                                    <asp:TextBox ID="AdminStateProvinceChoiceTextBox" runat="server" 
                                        Text='<%# Bind("AdminStateProvinceChoice") %>' />
                                    <br />
                                    AdminPostalCode:
                                    <asp:TextBox ID="AdminPostalCodeTextBox" runat="server" 
                                        Text='<%# Bind("AdminPostalCode") %>' />
                                    <br />
                                    AdminCountry:
                                    <asp:TextBox ID="AdminCountryTextBox" runat="server" 
                                        Text='<%# Bind("AdminCountry") %>' />
                                    <br />
                                    AdminPhone:
                                    <asp:TextBox ID="AdminPhoneTextBox" runat="server" 
                                        Text='<%# Bind("AdminPhone") %>' />
                                    <br />
                                    AdminPhoneExt:
                                    <asp:TextBox ID="AdminPhoneExtTextBox" runat="server" 
                                        Text='<%# Bind("AdminPhoneExt") %>' />
                                    <br />
                                    AdminFax:
                                    <asp:TextBox ID="AdminFaxTextBox" runat="server" 
                                        Text='<%# Bind("AdminFax") %>' />
                                    <br />
                                    AdminEmailAddress:
                                    <asp:TextBox ID="AdminEmailAddressTextBox" runat="server" 
                                        Text='<%# Bind("AdminEmailAddress") %>' />
                                    <br />
                                    AuxBillingOrganizationName:
                                    <asp:TextBox ID="AuxBillingOrganizationNameTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingOrganizationName") %>' />
                                    <br />
                                    AuxBillingJobTitle:
                                    <asp:TextBox ID="AuxBillingJobTitleTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingJobTitle") %>' />
                                    <br />
                                    AuxBillingFirstName:
                                    <asp:TextBox ID="AuxBillingFirstNameTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingFirstName") %>' />
                                    <br />
                                    AuxBillingLastName:
                                    <asp:TextBox ID="AuxBillingLastNameTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingLastName") %>' />
                                    <br />
                                    AuxBillingAddress1:
                                    <asp:TextBox ID="AuxBillingAddress1TextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingAddress1") %>' />
                                    <br />
                                    AuxBillingAddress2:
                                    <asp:TextBox ID="AuxBillingAddress2TextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingAddress2") %>' />
                                    <br />
                                    AuxBillingCity:
                                    <asp:TextBox ID="AuxBillingCityTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingCity") %>' />
                                    <br />
                                    AuxBillingStateProvince:
                                    <asp:TextBox ID="AuxBillingStateProvinceTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingStateProvince") %>' />
                                    <br />
                                    AuxBillingStateProvinceChoice:
                                    <asp:TextBox ID="AuxBillingStateProvinceChoiceTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingStateProvinceChoice") %>' />
                                    <br />
                                    AuxBillingPostalCode:
                                    <asp:TextBox ID="AuxBillingPostalCodeTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingPostalCode") %>' />
                                    <br />
                                    AuxBillingCountry:
                                    <asp:TextBox ID="AuxBillingCountryTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingCountry") %>' />
                                    <br />
                                    AuxBillingPhone:
                                    <asp:TextBox ID="AuxBillingPhoneTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingPhone") %>' />
                                    <br />
                                    AuxBillingPhoneExt:
                                    <asp:TextBox ID="AuxBillingPhoneExtTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingPhoneExt") %>' />
                                    <br />
                                    AuxBillingFax:
                                    <asp:TextBox ID="AuxBillingFaxTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingFax") %>' />
                                    <br />
                                    AuxBillingEmailAddress:
                                    <asp:TextBox ID="AuxBillingEmailAddressTextBox" runat="server" 
                                        Text='<%# Bind("AuxBillingEmailAddress") %>' />
                                    <br />
                                    BillingFirstName:
                                    <asp:TextBox ID="BillingFirstNameTextBox" runat="server" 
                                        Text='<%# Bind("BillingFirstName") %>' />
                                    <br />
                                    BillingLastName:
                                    <asp:TextBox ID="BillingLastNameTextBox" runat="server" 
                                        Text='<%# Bind("BillingLastName") %>' />
                                    <br />
                                    BillingAddress1:
                                    <asp:TextBox ID="BillingAddress1TextBox" runat="server" 
                                        Text='<%# Bind("BillingAddress1") %>' />
                                    <br />
                                    BillingAddress2:
                                    <asp:TextBox ID="BillingAddress2TextBox" runat="server" 
                                        Text='<%# Bind("BillingAddress2") %>' />
                                    <br />
                                    BillingCity:
                                    <asp:TextBox ID="BillingCityTextBox" runat="server" 
                                        Text='<%# Bind("BillingCity") %>' />
                                    <br />
                                    BillingStateProvince:
                                    <asp:TextBox ID="BillingStateProvinceTextBox" runat="server" 
                                        Text='<%# Bind("BillingStateProvince") %>' />
                                    <br />
                                    BillingStateProvinceChoice:
                                    <asp:TextBox ID="BillingStateProvinceChoiceTextBox" runat="server" 
                                        Text='<%# Bind("BillingStateProvinceChoice") %>' />
                                    <br />
                                    BillingPostalCode:
                                    <asp:TextBox ID="BillingPostalCodeTextBox" runat="server" 
                                        Text='<%# Bind("BillingPostalCode") %>' />
                                    <br />
                                    BillingCountry:
                                    <asp:TextBox ID="BillingCountryTextBox" runat="server" 
                                        Text='<%# Bind("BillingCountry") %>' />
                                    <br />
                                    BillingPhone:
                                    <asp:TextBox ID="BillingPhoneTextBox" runat="server" 
                                        Text='<%# Bind("BillingPhone") %>' />
                                    <br />
                                    BillingPhoneExt:
                                    <asp:TextBox ID="BillingPhoneExtTextBox" runat="server" 
                                        Text='<%# Bind("BillingPhoneExt") %>' />
                                    <br />
                                    BillingFax:
                                    <asp:TextBox ID="BillingFaxTextBox" runat="server" 
                                        Text='<%# Bind("BillingFax") %>' />
                                    <br />
                                    BillingEmailAddress:
                                    <asp:TextBox ID="BillingEmailAddressTextBox" runat="server" 
                                        Text='<%# Bind("BillingEmailAddress") %>' />
                                    <br />
                                    Nameservers:
                                    <asp:TextBox ID="NameserversTextBox" runat="server" 
                                        Text='<%# Bind("Nameservers") %>' />
                                    <br />
                                    AddFreeWhoisguard:
                                    <asp:TextBox ID="AddFreeWhoisguardTextBox" runat="server" 
                                        Text='<%# Bind("AddFreeWhoisguard") %>' />
                                    <br />
                                    WGEnabled:
                                    <asp:TextBox ID="WGEnabledTextBox" runat="server" 
                                        Text='<%# Bind("WGEnabled") %>' />
                                    <br />
                                    AddFreePositiveSSL:
                                    <asp:TextBox ID="AddFreePositiveSSLTextBox" runat="server" 
                                        Text='<%# Bind("AddFreePositiveSSL") %>' />
                                    <br />
                                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                                        CommandName="Insert" Text="Insert" />
                                    &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                                        CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                </InsertItemTemplate>
                                <ItemTemplate>
                                
                                <table border="0" cellpadding="2" cellspacing="2" width="100%" class="stdtableBorder_AccountPage">
                                <tr>
                                 <td width="40%" class="style3">Dpid</td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="58%" class="style2">
                                     <asp:Label ID="DpidLabel" runat="server" Text='<%# Eval("Dpid") %>' />
                                    </td>
                                </tr>
                                
                              
                                    <tr>
                                        <td width="40%" class="style3">
                                            Years</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td width="58%" class="style2">
                                            <asp:Label ID="YearsLabel" runat="server" Text='<%# Bind("Years") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="40%" class="style3">
                                            PromotionCode</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td width="58%" class="style2">
                                            <asp:Label ID="PromotionCodeLabel" runat="server" 
                                                Text='<%# Bind("PromotionCode") %>' />
                                        </td>
                                    </tr>
                                     <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Registration Contact Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                    <tr>
                                        <td width="40%" class="style3">
                                            RegistrantOrganizationName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td width="58%" class="style2">
                                            <asp:Label ID="RegistrantOrganizationNameLabel" runat="server" 
                                                Text='<%# Bind("RegistrantOrganizationName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="40%" class="style3">
                                            RegistrantJobTitle</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td width="58%" class="style2">
                                            <asp:Label ID="RegistrantJobTitleLabel" runat="server" 
                                                Text='<%# Bind("RegistrantJobTitle") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="40%" class="style3">
                                            RegistrantFirstName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td width="58%" class="style2">
                                            <asp:Label ID="RegistrantFirstNameLabel" runat="server" 
                                                Text='<%# Bind("RegistrantFirstName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="40%" class="style3">
                                            RegistrantLastName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td width="58%" class="style2">
                                            <asp:Label ID="RegistrantLastNameLabel" runat="server" 
                                                Text='<%# Bind("RegistrantLastName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="40%" class="style3">
                                            RegistrantAddress1</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td width="58%" class="style2">
                                            <asp:Label ID="RegistrantAddress1Label" runat="server" 
                                                Text='<%# Bind("RegistrantAddress1") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="40%" class="style3">
                                            RegistrantAddress2</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td width="58%" class="style2">
                                            <asp:Label ID="RegistrantAddress2Label" runat="server" 
                                                Text='<%# Bind("RegistrantAddress2") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="40%" class="style3">
                                            RegistrantCity</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td width="58%" class="style2">
                                            <asp:Label ID="RegistrantCityLabel" runat="server" 
                                                Text='<%# Bind("RegistrantCity") %>' />
                                        </td>
                                    </tr>
                                
                                    <tr>
                                        <td class="style3" width="40%">
                                            RegistrantStateProvince</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="RegistrantStateProvinceLabel" runat="server" 
                                                Text='<%# Bind("RegistrantStateProvince") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            RegistrantStateProvinceChoice</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="RegistrantStateProvinceChoiceLabel" runat="server" 
                                                Text='<%# Bind("RegistrantStateProvinceChoice") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            RegistrantPostalCode</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="RegistrantPostalCodeLabel" runat="server" 
                                                Text='<%# Bind("RegistrantPostalCode") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            RegistrantCountry</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="RegistrantCountryLabel" runat="server" 
                                                Text='<%# Bind("RegistrantCountry") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            RegistrantPhone</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="RegistrantPhoneLabel" runat="server" 
                                                Text='<%# Bind("RegistrantPhone") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            RegistrantPhoneExt</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="RegistrantPhoneExtLabel" runat="server" 
                                                Text='<%# Bind("RegistrantPhoneExt") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            RegistrantFax</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="RegistrantFaxLabel" runat="server" 
                                                Text='<%# Bind("RegistrantFax") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            RegistrantEmailAddress</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="RegistrantEmailAddressLabel" runat="server" 
                                                Text='<%# Bind("RegistrantEmailAddress") %>' />
                                        </td>
                                    </tr>
                                    
                                     <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Technical Contact Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                      
                                      
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechOrganizationName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechOrganizationNameLabel" runat="server" 
                                                Text='<%# Bind("TechOrganizationName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechJobTitle</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechJobTitleLabel" runat="server" 
                                                Text='<%# Bind("TechJobTitle") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechFirstName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                                             <asp:Label ID="TechFirstNameLabel" runat="server" 
                                                Text='<%# Bind("TechFirstName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechLastName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                          
                                                 <asp:Label ID="TechLastNameLabel" runat="server" 
                                                Text='<%# Bind("TechLastName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechAddress1</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechAddress1Label" runat="server" 
                                                Text='<%# Bind("TechAddress1") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechAddress2</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechAddress2Label" runat="server" 
                                                Text='<%# Bind("TechAddress2") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechCity</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechCityLabel" runat="server" Text='<%# Bind("TechCity") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechStateProvince</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechStateProvinceLabel" runat="server" 
                                                Text='<%# Bind("TechStateProvince") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechStateProvinceChoice</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechStateProvinceChoiceLabel" runat="server" 
                                                Text='<%# Bind("TechStateProvinceChoice") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechPostalCode</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechPostalCodeLabel" runat="server" 
                                                Text='<%# Bind("TechPostalCode") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechCountry</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechCountryLabel" runat="server" 
                                                Text='<%# Bind("TechCountry") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechPhone</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechPhoneLabel" runat="server" Text='<%# Bind("TechPhone") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechPhoneExt</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechPhoneExtLabel" runat="server" 
                                                Text='<%# Bind("TechPhoneExt") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechFax</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechFaxLabel" runat="server" Text='<%# Bind("TechFax") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            TechEmailAddress</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="TechEmailAddressLabel" runat="server" 
                                                Text='<%# Bind("TechEmailAddress") %>' />
                                        </td>
                                    </tr>
                                    
                                     <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Administration Contact Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                      
                                      
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminOrganizationName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminOrganizationNameLabel" runat="server" 
                                                Text='<%# Bind("AdminOrganizationName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminJobTitle</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminJobTitleLabel" runat="server" 
                                                Text='<%# Bind("AdminJobTitle") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminFirstName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminFirstNameLabel" runat="server" 
                                                Text='<%# Bind("AdminFirstName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminLastName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminLastNameLabel" runat="server" 
                                                Text='<%# Bind("AdminLastName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminAddress1</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminAddress1Label" runat="server" 
                                                Text='<%# Bind("AdminAddress1") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminAddress2</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminAddress2Label" runat="server" 
                                                Text='<%# Bind("AdminAddress2") %>' />
                                        </td>
                                    </tr>
                                
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminCity</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminCityLabel" runat="server" Text='<%# Bind("AdminCity") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminStateProvince</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminStateProvinceLabel" runat="server" 
                                                Text='<%# Bind("AdminStateProvince") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminStateProvinceChoice</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminStateProvinceChoiceLabel" runat="server" 
                                                Text='<%# Bind("AdminStateProvinceChoice") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminPostalCode</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminPostalCodeLabel" runat="server" 
                                                Text='<%# Bind("AdminPostalCode") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminCountry</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminCountryLabel" runat="server" 
                                                Text='<%# Bind("AdminCountry") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminPhone</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminPhoneLabel" runat="server" 
                                                Text='<%# Bind("AdminPhone") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminPhoneExt</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminPhoneExtLabel" runat="server" 
                                                Text='<%# Bind("AdminPhoneExt") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminFax</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminFaxLabel" runat="server" Text='<%# Bind("AdminFax") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AdminEmailAddress</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AdminEmailAddressLabel" runat="server" 
                                                Text='<%# Bind("AdminEmailAddress") %>' />
                                        </td>
                                    </tr>
                                    
                                     <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Aux Billing Contact Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                      
                                      
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingOrganizationName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingOrganizationNameLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingOrganizationName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingJobTitle</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingJobTitleLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingJobTitle") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingFirstName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingFirstNameLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingFirstName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingLastName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingLastNameLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingLastName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingAddress1</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingAddress1Label" runat="server" 
                                                Text='<%# Bind("AuxBillingAddress1") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingAddress2</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingAddress2Label" runat="server" 
                                                Text='<%# Bind("AuxBillingAddress2") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingCity</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingCityLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingCity") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingStateProvince</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingStateProvinceLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingStateProvince") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingStateProvinceChoice</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingStateProvinceChoiceLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingStateProvinceChoice") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingPostalCode</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingPostalCodeLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingPostalCode") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingCountry</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingCountryLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingCountry") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingPhone</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingPhoneLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingPhone") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingPhoneExt</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingPhoneExtLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingPhoneExt") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingFax</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingFaxLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingFax") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AuxBillingEmailAddress</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AuxBillingEmailAddressLabel" runat="server" 
                                                Text='<%# Bind("AuxBillingEmailAddress") %>' />
                                        </td>
                                    </tr>
                                    
                                     <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Billing Contact Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingFirstName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingFirstNameLabel" runat="server" 
                                                Text='<%# Bind("BillingFirstName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingLastName</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingLastNameLabel" runat="server" 
                                                Text='<%# Bind("BillingLastName") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingAddress1</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingAddress1Label" runat="server" 
                                                Text='<%# Bind("BillingAddress1") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingAddress2</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingAddress2Label" runat="server" 
                                                Text='<%# Bind("BillingAddress2") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingStateProvince</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingStateProvinceLabel" runat="server" 
                                                Text='<%# Bind("BillingStateProvince") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingCity</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingCityLabel" runat="server" 
                                                Text='<%# Bind("BillingCity") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingStateProvinceChoice</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingStateProvinceChoiceLabel" runat="server" 
                                                Text='<%# Bind("BillingStateProvinceChoice") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingPostalCode</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingPostalCodeLabel" runat="server" 
                                                Text='<%# Bind("BillingPostalCode") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingCountry</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingCountryLabel" runat="server" 
                                                Text='<%# Bind("BillingCountry") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingPhone</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingPhoneLabel" runat="server" 
                                                Text='<%# Bind("BillingPhone") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingPhoneExt</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingPhoneExtLabel" runat="server" 
                                                Text='<%# Bind("BillingPhoneExt") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingFax</td>
                                        <td width="2%">
                                        </td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingFaxLabel" runat="server" 
                                                Text='<%# Bind("BillingFax") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            BillingEmailAddress</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="BillingEmailAddressLabel" runat="server" 
                                                Text='<%# Bind("BillingEmailAddress") %>' />
                                        </td>
                                    </tr>
                                    
                                     <tr>
                                          <td class="style3 subHeaderFontGrad SummaryBoxheadGreen">
                                              Other Details</td>
                                          <td class="SummaryBoxheadGreen">
                                              &nbsp;</td>
                                          <td class="style2 SummaryBoxheadGreen">
                                              &nbsp;</td>
                                      </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            Nameservers</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="NameserversLabel" runat="server" 
                                                Text='<%# Bind("Nameservers") %>' />
                                        </td>
                                    </tr>
                                     <tr>
                                          <td class="style3">
                                              Nameservers 2</td>
                                          <td>
                                              &nbsp;</td>
                                          <td class="style2">
                                                  <asp:Label ID="Nameservers2Label" runat="server" 
                                                Text='<%# Bind("Nameservers2") %>' />
                                          </td>
                                      </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AddFreeWhoisguard</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AddFreeWhoisguardLabel" runat="server" 
                                                Text='<%# Bind("AddFreeWhoisguard") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            WGEnabled</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="WGEnabledLabel" runat="server" Text='<%# Bind("WGEnabled") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            AddFreePositiveSSL</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            <asp:Label ID="AddFreePositiveSSLLabel" runat="server" 
                                                Text='<%# Bind("AddFreePositiveSSL") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style3" width="40%">
                                            &nbsp;</td>
                                        <td width="2%">
                                            &nbsp;</td>
                                        <td class="style2" width="58%">
                                            &nbsp;</td>
                                    </tr>
                                
                                </table>
                                
                                
                                    <br />
                                    <br />
                                    <asp:Button ID="BtnUpdate" CssClass="stdbuttonCRUD" CommandName="Edit" runat="server" Text="EDIT" />&nbsp; &nbsp; &nbsp; 
                                </ItemTemplate>
                                <RowStyle BackColor="#D6F0E8" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                
                            </asp:FormView>
                          </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td><td align="left">
                          <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        </td>
                        <td>
                            &nbsp;</td></tr><tr>
                    <td>&nbsp;</td><td>&nbsp;
                        
                    </td>
                    <td>&nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
              &nbsp;
            </td></tr></table></ContentTemplate></asp:UpdatePanel></form>
            
</asp:Content>

