<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="ProfitSharingRequestPayment.aspx.cs" Inherits="Admin_ProfitSharingRequestPayment" %>


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
                        
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                             PageSize="20" onrowdatabound="GridView1_RowDataBound"
                             onsorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" onpageindexchanging="GridView1_PageIndexChanging"
                             OnDataBound ="GridView1_DataBound" ShowFooter="True" EnableModelValidation="True">
                             
         <Columns>        
      <asp:TemplateField >
           <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
           <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
      </asp:TemplateField>

      <asp:TemplateField>        
            <ItemTemplate>
                <asp:Label ID="lblCountry" runat="server" Text='<% # Bind("CountryName")%>'></asp:Label>
                <asp:Image ID="ImageCtry" runat="server" ToolTip='<% # Bind("CountryName")%>' /> 
                <asp:HiddenField ID="hdnCtryName" runat="server" Value='<% # Bind("CountryName")%>'/>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Gross Profit">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationP" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblGross" runat="server" Text='<% # Bind("grossprofit")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Your Share">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationS" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblShare" runat="server" Text='<% # Bind("yourShare")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>   
             
        <asp:TemplateField HeaderText="Gross Profit">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationPS" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblsGross" runat="server" Text='<% # Bind("sGrossProfit")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField  HeaderText="Your Share">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationSS" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblsShare" runat="server" Text='<% # Bind("syourShare")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField >        
            <ItemTemplate>
                <asp:Label ID="lblDenominationTP" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblTotalProfit" runat="server" Text='<% # Bind("TotalShare")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField> 

        <asp:TemplateField >        
            <ItemTemplate>
                <asp:Label ID="lblDenominationPR" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblTotalAmountPaidReq" runat="server" Text='<% # Bind("paidtodate")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField>        
            <ItemTemplate>
                <asp:Label ID="lblDenominationBAL" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblBalance" runat="server" Text='<% # Bind("balance")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField>        
            <ItemTemplate>
                <asp:Label ID="lblDenominationCLAIM" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblClaim" runat="server" Text='<% # Bind("eligibleAmount")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField>        
            <ItemTemplate>
                <asp:Label ID="lblDenominationMR" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblMinimumRequest" runat="server" Text='<% # Bind("minimumRequest")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField>        
            <ItemTemplate>                
                <asp:Label ID="lblEligibleMinimumRequest" runat="server" Text='<% # Bind("eligibleStatusDisp")%>'></asp:Label>                
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>
             
        <asp:TemplateField>        
            <ItemTemplate>
                <asp:LinkButton ID="LinkButtonR" runat="server" Text='<% # Bind("RequestButton")%>' ImageUrl="~/Images/icon_view.png" CommandArgument='<%# Eval("countryCode")%>' OnCommand="Button_View"/> 
                <asp:HiddenField ID="hdnEligibleStatus" runat="server" Value='<% # Bind("eligibleStatus")%>'/>
            </ItemTemplate>
            <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" />
        </asp:TemplateField>
     </Columns> 
                             <PagerStyle CssClass="cssPager" />
                             
                             <PagerTemplate>
                                    <
                                </PagerTemplate>
                                
                             <HeaderStyle CssClass="rowheader" />
                                <AlternatingRowStyle CssClass="rowalt" />
                            </asp:GridView>
                            
                        
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

