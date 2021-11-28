<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminMaster_DIY.master" CodeFile="PremiumSMSReport_FULL.aspx.cs" Inherits="Admin_PremiumSMSReport_FULL" %>

<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_PaidSales.ascx" tagname="EBLeftMenu_PaidSales" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_PaidSales ID="EBLeftMenu_PaidSales1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    
     <style type="text/css">

         .CellPaddingRight { padding-right: 10px; 
         }

          .CellPaddingLeft { padding-left: 10px;
         }

         .FontColHeader {font: bold 12px "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #E432A3; padding-left: 5px; text-decoration: underline;}
         .FontColHead  {font: normal 11px "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #081363; padding-left: 5px;}
         .FontColText  {font: bold 11px "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #3C4688; padding-left: 5px;}

         .auto-style1 {
             color: #FF0000;
         }

     </style>

    <script language="javascript" type="text/javascript">

        function OpenWindow(ImageName) {
            window.open("EbAd_BankInSlipShow.aspx?qImage=" + ImageName, 'WinBankInImage', 'height=500,width=750,scrollbars=yes,resizable=yes');
        }

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
            var ObjgridViewCtlId = '<%=gridBankInBys.ClientID%>';

            //Getting ref. to GridView Row
            // ObjgridViewCtlId.rows


        }

</script>
<form id="form2" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
<ContentTemplate>--%>


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
                            &nbsp; EBooks: Purchases - All Incentive History</td>
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
                            <span class="auto-style1"><strong>Note : Merchant Charges </strong></span><strong> <br class="auto-style1" />
                            </strong><span class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Paypal Credit Card Charges -  5%  + $0.50 </strong></span><strong> <br class="auto-style1" />
                            </strong><span class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Online Banking - $0.40</strong></span><br />
                            <span class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MWallet - $0.30</strong></span>
                                    
                            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="500" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/> Processing... Please wait... 
                             </div>
                            </ProgressTemplate>
                            
                            </asp:UpdateProgress>
                            
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            <asp:GridView ID="gridBankInBys" runat="server" AutoGenerateColumns="False"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="200" onpageindexchanging="gridBankInBys_PageIndexChanging"
                               AllowSorting="true"  
                                OnRowCreated="gridBankInBys_RowCreated"
                                onrowcancelingedit="gridBankInBys_RowCancelingEdit" 
                                onrowediting="gridBankInBys_RowEditing"  
                                onrowdeleting="gridBankInBys_RowDeleting" ondatabound="gridBankInBys_DataBound" 
                                onrowdatabound="gridBankInBys_RowDataBound" OnSorting="gridBankInBys_Sorting" OnRowCommand="gridBankInBys_RowCommand" ShowFooter="true">
                            <Columns>
                            
                            <asp:TemplateField HeaderText="Sno">
           <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
           <ItemStyle Width="10px" HorizontalAlign="Left" VerticalAlign="Top"/>
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Purchase Mode" SortExpression="TDate">        
            <ItemTemplate>
                <asp:Label ID="lblPurchaseMode" runat="server" Text='<% # Bind("PurchaseMode")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Incentive Type" SortExpression="TDate">        
            <ItemTemplate>
                <asp:Label ID="lblIncentiveType" runat="server" Text='<% # Bind("IncentiveType")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Customer/Partner" SortExpression="TDate">        
            <ItemTemplate>
                <asp:Label ID="lblMobile" runat="server" Text='<% # Bind("Mobile")%>'></asp:Label><br />
                <asp:Label ID="lblFullName" runat="server" Text='<% # Bind("FullName")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Product Code" SortExpression="TDate">        
            <ItemTemplate>
                <asp:Label ID="lblProductCode" runat="server" Text='<% # Bind("Bookcode")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Product Name" SortExpression="TDate">        
            <ItemTemplate>
                <asp:Label ID="lblProductName" runat="server" Text='<% # Bind("Bookname")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="TDate">        
            <ItemTemplate>
                <asp:Label ID="lblDate" runat="server" Text='<% # Bind("TDate")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Price" SortExpression="TDate">        
            <ItemTemplate>
                <asp:Label ID="lblPrice" runat="server" Text='<% # Bind("Price")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="After M.Charges" SortExpression="TDate">        
            <ItemTemplate>
                <asp:Label ID="lblAfterTelco" runat="server" Text='<% # Bind("AfterTelco")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Your Status" SortExpression="TDate">        
            <ItemTemplate>
                <asp:Label ID="lblYourStatus" runat="server" Text='<% # Bind("Package")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Book Type" SortExpression="TDate">        
            <ItemTemplate>
                <asp:Label ID="lblYourStatus" runat="server" Text='<% # Bind("BookType")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle Width="25px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Your Share USD">    
            <ItemTemplate>
                <asp:Label ID="lblFinalShare" runat="server" ForeColor="Blue" Text='<% # Bind("finalShare")%>' />
            </ItemTemplate>
            <FooterTemplate></FooterTemplate>
            <ItemStyle Width="10px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>



                             
                             </Columns>
                             <PagerStyle CssClass="cssPager" />
                             
                             <PagerTemplate>
                                    <table border="0">
                                        <tr align="right">
                                           
                                         <td width="100px">      
                                            <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="Page" CommandArgument="First" runat="server"  ID="btnFirst" ImageUrl="~/Images/imgPg_First.gif" />
                                            <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="Page" CommandArgument="Prev" runat="server" ID="btnPrevious" ImageUrl="~/Images/imgPg_Prev.gif"/>
                                                    </td>
                                                    
                                            <td width="100px">
                                                Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;<asp:Label
                                                    ID="PageCountLabel" runat="server" />
                                            </td>
                                              
                                        <td width="100px">
                                            <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="Page" CommandArgument="Next" runat="server" ID="btnNext" ImageUrl="~/Images/imgPg_next.gif"/>
                                            <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="Page" CommandArgument="Last" runat="server" ID="btnLast" ImageUrl="~/Images/imgPg_last.gif" />
                                          </td>
                                       <td width="20px">&nbsp;</td><td width="100px">
                                          <%-- <asp:Button ID="btnDeleteMultiple" runat="server" Text="Delete Selected"/>--%>
                                       </td>
                                          
                                 </tr>
                                    </table>
                                </PagerTemplate>
                                
                             
                            </asp:GridView>
                            
                        
                        </td>
                        <td>
                            &nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td align="left">
                          
                        </td>
                        <td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp; </td></tr></table><%--      </ContentTemplate>  


    </asp:UpdatePanel>--%><asp:HiddenField ID="hdn_UId" runat="server" />
<asp:HiddenField ID="hdn_TranID" runat="server" />

</form>
</asp:Content>

