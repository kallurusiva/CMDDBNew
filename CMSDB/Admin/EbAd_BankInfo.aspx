<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_BankInfo.aspx.cs" Inherits="Admin_EbAd_BankInfo" %>
<%@ Register src="EBLeftMenu_Profit.ascx" tagname="EBLeftMenu_Profit" tagprefix="uc1" %>
<%@ Register src="EBLeftMenu_PayPalCC.ascx" tagname="EBLeftMenu_PayPalCC" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 53px;
            background-color: #F8FAE5;
            FONT-SIZE: 12px;
            COLOR: #015CB6;
            padding-left: 10px;
            FONT-FAMILY: Arial, Helvetica, sans-serif;
            border-bottom: solid 1px #ECECEB;
        }
        .style2
        {
            height: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_PayPalCC ID="EBLeftMenu_PayPalCC1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
<form id="form2" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

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
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp;SMS Profit : My Bank Details</td>
                        <td width="30%" align="right"> 
                            &nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr style="height:30px;">
                        <td width="1%">
                            &nbsp;</td>
                        <td width="98%" align="left">
                            
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="center">
                        
                            <div id="dvWelcomeHeader" style="overflow:hidden; width:700px;  min-height: 50px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                       
                        <td>
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal3" Text="Latest Bank Info via SMS Instruction" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    <tr style="vertical-align:baseline;">
                    <td align="center">
                    <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="80%" >
                            <tr>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td class="ebFormLabel1" align="left" style="width:250px"><asp:Label ID="Label5" runat="server" Text="Payee (Same as your Mykad Full Name)"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblMNameVal" runat="server" Text="Name" CssClass="" /></td>
                            </tr>             
                            <tr>
                                <td class="ebFormLabel1" align="left" ><asp:Label ID="Label6" runat="server" Text="Your Mobile"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblMobileVal" runat="server" Text="Mobile" CssClass="" /></td>
                            </tr>
                            <tr>
                                <td class="ebFormLabel1" align="left" ><asp:Label ID="lblIC" runat="server" Text="NRIC/Passport No"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblICVal" runat="server" Text="Mobile" CssClass="" /></td>
                            </tr>
                            <tr>
                                <td class="ebFormLabel1" align="left" ><asp:Label ID="lblBankName" runat="server" Text="Bank Name"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblBankNameVal" runat="server" Text="Bank Name" CssClass="" /></td>
                            </tr>
                            <tr>
                                <td class="ebFormLabel1" align="left" ><asp:Label ID="lblBankAdd" runat="server" Text="Bank Address"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblBankAddVal" runat="server" Text="Bank Address" CssClass="" /></td>
                            </tr>  
                            <tr>
                                <td class="ebFormLabel1" align="left" ><asp:Label ID="lblAccountNo" runat="server" Text="Account No"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblAccountNoVal" runat="server" Text="" CssClass="" /></td>
                            </tr>                                                      
                            <tr>
                                <td class="ebFormLabel1" align="left" ><asp:Label ID="lblBankCountry" runat="server" Text="Bank Country"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblBankCountryVal" runat="server" Text="" CssClass="" /></td>
                            </tr>
                            <%--<tr>
                                <td class="ebFormLabel1" align="left" ><asp:Label ID="lblPayee" runat="server" Text="Payee Name"/></td>
                                <td class="ebFormText1" align="left">:&nbsp;<asp:Label ID="lblPayeeVal" runat="server" Text="" CssClass="" /></td>
                            </tr> --%>                                                       
                        </table>
                     </td>
                    </tr>
                 
                  <tr>
                  <td>&nbsp;</td>
                  </tr>               
                                        
                  <tr>
                  <td>
                      <asp:Button ID="btnEditBank" runat="server" CssClass="stdbuttonCRUD" OnClick="btnEditBank_Click" Text="Update" />
                      </td>
                  </tr>               
                                        
                      </table>
         
        </div>
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
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
                        
                            <%--<div id="Div1" style="overflow:hidden; width:700px; min-height: 50px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                       
                        <td>
                        <div class="SummaryBoxheadGreen">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal1" Text="NOTE : Add or Edit Bank Details vis SMS Instruction ONLY" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    <tr style="vertical-align:baseline;">
                    <td align="center">
                    <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="70%" >
                            <tr>
                                <td align="left" class="style2"></td>
                            </tr>             

                            <tr>
                                <td align="left" class="FontBHeader">SMS Format : Update Your Name as MyKad or Passport Name</td>
                            </tr>             

                            <tr>
                                <td align="left" class="style1">EB FullName <b>&lt;Your Full Name&gt;</b>
                                <br />
                                <br />
                                <asp:Label ID="Label3" runat="server" Text="[e.g EB FullName Mohd Faizal bin Mohd Shahril" 
                                        CssClass="sideBoxsubhead" />
                                </td>
                            </tr>             

                            <tr>
                                <td align="left">&nbsp;&nbsp;&nbsp; </td>
                            </tr> 
                            <tr>
                                <td align="left" class="style2"></td>
                            </tr>             

                            <tr>
                                <td align="left" class="FontBHeader">SMS Format : Update Bank Name</td>
                            </tr>             

                            <tr>
                                <td align="left" class="style1">EB BankCode <b>&lt;Password&gt;</b> <b>&lt;BankNameCode&gt;</b>
                                <br />
                                <br />
                                <asp:Label ID="LabelTT1" runat="server" Text="[e.g EB BankCode 123123 MAYBANK]" 
                                        CssClass="sideBoxsubhead" />
                                </td>
                            </tr>             

                            <tr>
                                <td align="left">&nbsp;&nbsp;&nbsp; </td>
                            </tr>  
                            <tr>
                                <td align="left" class="FontBHeader">SMS Format : Update Bank Account No</td>
                            </tr>             

                            <tr>
                                <td align="left" class="style1">EB BankNo <b>&lt;Password&gt;</b> <b>&lt;BankAccountNo&gt;</b>
                                <br />
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="[e.g EB BankNo 123123 112255667788]" 
                                        CssClass="sideBoxsubhead" />
                                </td>
                            </tr> 
                            <tr>
                                <td align="left">&nbsp;&nbsp;&nbsp; </td>
                            </tr> 
                            <tr>
                                <td align="left" class="FontBHeader">SMS Format : Update IC/ Passport No</td>
                            </tr>             

                            <tr>
                                <td align="left" class="style1">EB ICNO <b>&lt;Password&gt;</b> <b>&lt;YourIdentificationNo&gt;</b>
                                <br />
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="[e.g EB ICNO 123123 990101011212]" 
                                        CssClass="sideBoxsubhead" />
                                </td>
                            </tr>            
                            </table>
                     </td>
                    </tr>
                 
                  <tr>
                  <td>&nbsp;</td>
                  </tr>               
                                        
                      </table>
         
        </div>
  --%>                          </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
                </table>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <td align="center">&nbsp;</td>
        </table>
                
                </td>
        </tr>
      
        <tr>
            <td>
            &nbsp;
           </td>
        </tr>
      
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
<%--      </ContentTemplate>  


    </asp:UpdatePanel>--%>
    
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

