<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="ProfitSharingRequestPaymentShow.aspx.cs" Inherits="Admin_ProfitSharingRequestPaymentShow" %>
<%@ Register src="../SuperAdmin/SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc2" %>
<%@ Register src="EBLeftMenu_SMSPayment.ascx" tagname="EBLeftMenu_SMSPayment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_SMSPayment ID="EBLeftMenu_SMSPayment1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

<script language="javascript" type="text/javascript">

    function SelectAll(chkdbox_id) {

        var objChkbox = document.getElementById(chkdbox_id);
        //alert(objChkbox.checked);

        var frm = document.forms[0];

        for (var i = 0; i < frm.elements.length; i++) {
            if (frm.elements[i].type == "checkbox") {
                frm.elements[i].checked = objChkbox.checked;
            }
        }
    }

    function SelectRow(cb_ID) {

        //Getting the ref. to GridView Control 
       <%-- var ObjgridViewCtlId = '<%=gridEmailList.ClientID%>';--%>

        //Getting ref. to GridView Row
        // ObjgridViewCtlId.rows


    }

</script>

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
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                        <asp:Literal ID="ltrEmailListing" runat="server" 
                                Text="PremiumSMS - Profit Sharing - Request Payment"></asp:Literal>
                                </td>
                        <td width="30%">
                            
                        </td>
                       
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
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
                        
                            <asp:FormView ID="FormView1" runat="server" Width="95%" ondatabound="FormView1_DataBound">
        <ItemTemplate>
            <table id="tbLeftmenu" cellpadding="0" cellspacing="0" runat="server" class="std_tb_Grey" style="text-align: left" width="80%">
                <tr>
                    <td valign="top" class="tb_LeftMenu_01" style="width: 5px;height:30px;">
                    <img src="../Images/spacer.gif" /></td>
                    <td><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icon_dashboard.png" />
                        <asp:Label ID="lblPersonalDetails" runat="server" Text="Request Payment" CssClass="std_TitleBlackLarge"></asp:Label>
                    </td>
                    <td valign="top" class="tb_LeftMenu_02" style="width: 5px;"><img src="../Images/spacer.gif" /></td>
                </tr>               
                <tr>
                    <td colspan="3" class="std_padding_FormView1">
                          <table id="tb1" cellpadding="0" cellspacing="0" class="std_FormView1" style="width:100%;">
                            <tr>
                                <td style="width:45%">
                                    <asp:Label ID="lblUntil" runat="server" Text="&nbsp;Total Profit Until" CssClass="txtBlackBMedium"></asp:Label>
                                </td>
                                <td>:&nbsp;<asp:Label ID="lblUntilVal" runat="server" Text='<% # Bind("monthName")%>' CssClass="txtBlackBMedium"/></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;<asp:Label ID="lblPayout" CssClass="txtBlackBMedium" runat="server" 
                                        Text="Total Payout"></asp:Label>
                                </td>
                                <td>
                                    :
                                    <asp:Label ID="lblDen1" CssClass="txtBlackMedium" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                                    <asp:Label ID="lblPayoutVal" runat="server" CssClass="txtBlackBMedium" 
                                        Text='<% # Bind("TotalShare")%>'></asp:Label>
                                </td>
                            </tr>
                              <tr>
                                  <td>
                                      <asp:Label ID="lblPayoutToDate" runat="server" CssClass="txtBlackBMedium" 
                                          Text="&nbsp;Total Payout To Date"></asp:Label>
                                  </td>
                                  <td>
                                      :<asp:Label ID="lblDen2" CssClass="txtBlackMedium" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                                      &nbsp;
                                      <asp:Label ID="lblPayoutToDateVal" runat="server" CssClass="txtBlackBMedium" 
                                          Text='<% # Bind("paidtodate")%>'></asp:Label>
                                             </td>
                              </tr>
                              <tr>
                                <td><asp:Label ID="lblBalance" runat="server" Text="&nbsp;Balance for Request Payment" CssClass="txtBlackMedium"></asp:Label>
                                </td>
                                <td>:<asp:Label ID="lblDen3" runat="server" CssClass="txtBlackMedium" Text='<% # Bind("Denomination")%>'></asp:Label>
                                    &nbsp;<asp:Label ID="lblBalanceVal" runat="server" CssClass="txtBlackMedium" Text='<% # Bind("eligibleamount")%>'></asp:Label></td>
                            </tr>
                              <tr>
                                <td><asp:Label ID="lblAdminCharges" runat="server" CssClass="txtBlackMedium" Text="&nbsp;Admin Charges"></asp:Label>
                                </td>
                                <td>:<asp:Label ID="lblDen4" runat="server" CssClass="txtBlackMedium" Text='<% # Bind("Denomination")%>'></asp:Label>
                                    &nbsp;<asp:Label ID="lblAdminChargesVal" runat="server" CssClass="txtBlackMedium" Text='<% # Bind("adminCharges")%>'></asp:Label>
                                </td>
                            </tr>                           
                            
                            <tr>
                                <td><asp:Label ID="lblFinal" runat="server" CssClass="txtBlackMedium" Text="&nbsp;Request Payment less Admin Charges"></asp:Label>
                                </td>
                                <td>:<asp:Label ID="lblDen5" runat="server" CssClass="txtBlackMedium" Text='<% # Bind("Denomination")%>'></asp:Label>
                                    &nbsp;<asp:Label ID="lblFinalVal" runat="server" CssClass="txtBlackMedium" Text='<% # Bind("final")%>'></asp:Label>
                                </td>
                            </tr>                           
                            <tr>
                                <td><asp:Label ID="llbConvert" runat="server" CssClass="txtBlackMedium" Text="&nbsp;Current Currency Conversion Rate"></asp:Label>
                                </td>
                                <td>:&nbsp;<asp:Label ID="llbConvertVal" runat="server" CssClass="txtBlackMedium" Text='<% # Bind("convertor")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblLocal" runat="server" CssClass="txtBlackMedium" Text="&nbsp;Total Payout in Local Currency"></asp:Label>
                                </td>
                                <td>:<asp:Label ID="lblDen6" runat="server" CssClass="txtBlackMedium" Text='<% # Bind("localCurrencyDenomination")%>'></asp:Label>
                                    &nbsp;<asp:Label ID="lblLocalVal" runat="server" CssClass="txtBlackMedium" Text='<% # Bind("localFinal")%>'></asp:Label>
                                </td>
                            </tr>                           
                              <tr>
                                  <td>&nbsp;</td>
                                  <td>&nbsp;</td>
                              </tr>
                            <tr>
                                <td colspan="2" class="bgWhite" runat="server" height="40px">&nbsp;
                                    <asp:Button ID="btEdit" runat="server" Text="Confirm Request" CssClass="std_button_imgEdit" OnCommand="Button_View" Visible="false" />
                                    &nbsp;<asp:Label ID="lblNoteVal" runat="server" CssClass=" txtRedMedium" Text=''  Visible="false"></asp:Label>
                               </td>
                            </tr>
                        </table>                      
                    </td>                   
                </tr>
                 <tr><td colspan="2">
                               
                            </td></tr>
                <tr>
                    <td valign="top" class="tb_LeftMenu_04" style="width: 5px;height:30px;">
                    <img src="../Images/spacer.gif" /></td>
                    <td>&nbsp;</td>
                    <td valign="top" class="tb_LeftMenu_03" style="width: 5px;"><img src="../Images/spacer.gif" /></td>
                </tr>                    
            </table>
        </ItemTemplate>        
    </asp:FormView>
                            
                        
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                          <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
                
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
      </ContentTemplate>  
     
 
    <asp:HiddenField ID="hdnSno" runat="server" />
<asp:HiddenField ID="hdnMobile" runat="server" />   

    </form>
</asp:Content>

