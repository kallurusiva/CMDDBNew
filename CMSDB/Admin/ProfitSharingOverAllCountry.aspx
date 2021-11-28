<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="ProfitSharingOverAllCountry.aspx.cs" Inherits="Admin_ProfitSharingOverAllCountry" %>


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
                                Text="PremiumSMS - Profit Sharing"></asp:Literal>
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
      <asp:TemplateField HeaderText="SNO">
           <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
           <ItemStyle Width="50px" HorizontalAlign="Left" VerticalAlign="Top"/>
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Mobile">        
            <ItemTemplate>
                <asp:Label ID="lblMobile" runat="server" Text='<% # Bind("Mobile")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Top" />
      </asp:TemplateField>

      <asp:TemplateField HeaderText="MemberName">        
            <ItemTemplate>
                <asp:Label ID="lblMName" runat="server" Text='<% # Bind("MName")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="150px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Gross Profit">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationG" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblGProfit" runat="server" Text='<% # Bind("GrossProfit")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="150px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>   
             
        <asp:TemplateField HeaderText="Your Share">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationS" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblYShare" runat="server" Text='<% # Bind("yourShare")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>
             
        <asp:TemplateField HeaderText="View Details">        
            <ItemTemplate>
                <asp:ImageButton ID="ImageButtonR" runat="server"  ImageUrl="~/Images/icon_view.png" CommandArgument='<%# Eval("Mobile")%>' OnCommand="Button_View"/> 
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

    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AllowPaging="True" 
    AutoGenerateColumns="False"  PageSize="20" onrowdatabound="GridView2_RowDataBound"
         CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
    onsorting="GridView2_Sorting" OnRowCreated="GridView2_RowCreated" onpageindexchanging="GridView2_PageIndexChanging"
    ondatabound="GridView2_DataBound" ShowFooter="True" EnableModelValidation="True" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">

   <Columns>        
      <asp:TemplateField HeaderText="SNO">
           <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
           <ItemStyle Width="50px" HorizontalAlign="Left" VerticalAlign="Top"/>
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Mobile">        
            <ItemTemplate>
                <asp:Label ID="lblMobile" runat="server" Text='<% # Bind("Mobile")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Top" />
      </asp:TemplateField>

      <asp:TemplateField HeaderText="MemberName">        
            <ItemTemplate>
                <asp:Label ID="lblMName" runat="server" Text='<% # Bind("MName")%>'></asp:Label>
            </ItemTemplate>
          <FooterTemplate>
                <asp:Label runat="server" ID="lblFooterTotal" Text="Total"></asp:Label>
            </FooterTemplate>         
            <ItemStyle Width="150px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Gross Profit">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationG" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblGProfit" runat="server" Text='<% # Bind("GrossProfit")%>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label runat="server" ID="lblGrossAmount" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>   
             
        <asp:TemplateField HeaderText="Your Share">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationS" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblYShare" runat="server" Text='<% # Bind("yourShare")%>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label runat="server" ID="lblShareAmount" Text=""></asp:Label>
            </FooterTemplate>
            <ItemStyle Width="150px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>
             
        <asp:TemplateField HeaderText="View Details">        
            <ItemTemplate>
                <asp:ImageButton ID="ImageButtonR" runat="server"  ImageUrl="~/Images/icon_view.png" CommandArgument='<%# Eval("Mobile")%>' OnCommand="Button_View"/> 
            </ItemTemplate>
            <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" />
        </asp:TemplateField>
     </Columns> 

    <HeaderStyle CssClass="headerRow" />
     <AlternatingRowStyle CssClass="alternateRowStyle" />
     <FooterStyle CssClass="footerRowStyle" />
     <RowStyle CssClass="rowStyle" />
      <PagerTemplate>
               
        </PagerTemplate>
      </asp:GridView>
     
 
    <asp:HiddenField ID="hdnSno" runat="server" />
<asp:HiddenField ID="hdnMobile" runat="server" />   

    </form>
</asp:Content>

