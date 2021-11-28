<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_BankInByList.aspx.cs" Inherits="EBAd_BankInByList" %>

<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_PayPalCC.ascx" tagname="EBLeftMenu_PayPalCC" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_PayPalCC ID="EBLeftMenu_PayPalCC1" runat="server" />
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
                            &nbsp; EBooks: Purchases</td>
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
                            &nbsp; 
                                    
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
                              AllowPaging="true" PageSize="10" onpageindexchanging="gridBankInBys_PageIndexChanging"
                               AllowSorting="true"  
                                onrowcancelingedit="gridBankInBys_RowCancelingEdit" 
                                onrowediting="gridBankInBys_RowEditing"  
                                onrowdeleting="gridBankInBys_RowDeleting" ondatabound="gridBankInBys_DataBound" onrowdatabound="gridBankInBys_RowDataBound" OnSorting="gridBankInBys_Sorting" OnRowCommand="gridBankInBys_RowCommand"
                             >
                            <Columns>
                            
                            <asp:TemplateField HeaderText="Sl No">
                              <ItemTemplate>
                               <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>
                                   <asp:HiddenField ID="hdUID" Value='<%#Bind("UID")%>' runat="server" />
                                  <asp:HiddenField ID="hidPurchasedItems" Value='<%#Bind("PurchasedItems")%>' runat="server" />
                                  <asp:HiddenField ID="hidRcvStatus" Value='<%#Bind("RecieveStatus")%>' runat="server" />
                                 
                              </ItemTemplate>
                              <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            
                              <asp:TemplateField HeaderText="Transaction ID">
                              <ItemTemplate>
                                   <asp:Label ID="lblTransactionID" CssClass="fontBlue12" runat="server" Text='<%# Bind("TransactionID")  %>'></asp:Label>
                              </ItemTemplate>
                              <ItemStyle Width="70px" HorizontalAlign="Left"  />
                             </asp:TemplateField>


                              <asp:TemplateField HeaderText="Purchased Items">
                              <ItemTemplate>
                                   <asp:Label ID="lblPurchasedItems" CssClass="fontBlue12" runat="server" Text='<%# Bind("PurchasedItems")  %>'></asp:Label>
                                <%--  <br />
                                   <asp:Image ID="lblImageFilePath" ImageUrl='<%# Bind("ImageFileFullURL")%>' CssClass="ebookImgCss" runat="server" />--%>
                              </ItemTemplate>
                              <ItemStyle Width="120px" HorizontalAlign="Left"  />
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText="BankIn Amount" SortExpression="BankInAmt" >
                              <ItemTemplate>
                                  <asp:Label ID="lblBankInAmt" CssClass="fontBlue" runat="server" Text='<%# Bind("BankInAmt", "{0:0.00}")  %>'></asp:Label>
                              </ItemTemplate>
                              <ItemStyle Width="50px" HorizontalAlign="Center"/>
                             </asp:TemplateField>


                              <asp:TemplateField HeaderText="Banked By" >
                              <ItemTemplate>
                                
                                <span class="FontColHeader">  Bank-In By </span> <br />
                                <span class="FontColHead">  Full Name :</span><asp:Label ID="lblBankersName" CssClass="FontColText" runat="server" Text='<%# Eval("BankersName")  %>'/> <br />
                                 <span class="FontColHead">  Mobile :</span><asp:Label ID="lblBankersMobile" CssClass="FontColText" runat="server" Text='<%# Eval("BankersMobile")  %>'/> <br />
                                 <span class="FontColHead">  Email  :</span><asp:Label ID="lblBankersEmail" CssClass="FontColText" runat="server" Text='<%# Eval("BankersEmail")  %>'/><br />

                                 <br /><span class="FontColHeader">  Banked Into </span> <br />                                  
                                 <span class="FontColHead">Account No. :</span> <asp:Label ID="lblBankActNo" CssClass="FontColText" runat="server" Text='<%# Eval("BankActNo")  %>'/> <br />
                                 <span class="FontColHead">Bank Name :</span> <asp:Label ID="lblBankName" runat="server" CssClass="FontColText" Text='<%# Eval("BankName")  %>'/> <br />
                                 <span class="FontColHead">Country  :</span><asp:Label ID="lblCountryName" runat="server" CssClass="FontColText" Text='<%# Eval("CountryName")  %>'/><br />
                                                    


                                <br /><span class="FontColHeader">  Banked Details </span> <br />
                                <span class="FontColHead">BankIn Date Time : </span><asp:Label ID="lblBankInDateTime" runat="server" CssClass="FontColText" Text='<%# Bind("BankInDateTime")  %>'/> <br />
                                <span class="FontColHead">BankIn Slip : </span>
                                  <asp:HyperLink ID="HypBankInSlip" Target="_blank" runat="server">
                                  <asp:Label ID="lblBankInSlip" runat="server" CssClass="FontColText" Text='<%# Bind("BankInSlip")  %>'/>
                                  </asp:HyperLink><br /><span class="FontColHead">Reference :</span> <asp:Label ID="lblBankInReference" runat="server"  CssClass="FontColText" Text='<%# Eval("BankInReference")  %>'/><br />
                               <span class="FontColHead">Description :</span> <br /><asp:Label ID="lblBankInDescription" CssClass="FontColText" runat="server" Text='<%# Eval("BankInDescription")  %>'/><br />



                              </ItemTemplate>
                              <ItemStyle Width="210px" HorizontalAlign="Left" CssClass="CellPaddingLeft"  />
                             </asp:TemplateField>


                            

                            
                              <asp:TemplateField HeaderText="Recorded TimeStamp" SortExpression="DateCreated" >
                              <ItemTemplate>
                               <asp:Label ID="lblDateCreated" runat="server" Text='<%# Bind("DateCreated","{0:dd-MMM-yyyy hh:mm}")  %>'/>
                              </ItemTemplate>
                              <ItemStyle Width="70px" HorizontalAlign="center"  />
                             </asp:TemplateField>


                              <asp:TemplateField HeaderText="BankIn Status" SortExpression="bStatus" >
                              <ItemTemplate>
                                   <asp:Label ID="lblbStatus" CssClass="fontBlue12" runat="server" Text='<%# Bind("bStatus")  %>'></asp:Label></ItemTemplate><ItemStyle Width="100px" HorizontalAlign="Left" CssClass="CellPaddingLeft"  />
                             </asp:TemplateField>

                                 <asp:TemplateField HeaderText="My Remarks" >
                              <ItemTemplate>
                              
                                <asp:Label ID="lblMyRemarks" runat="server" CssClass="FontColText" Text='<%# Bind("MyRemarks")  %>'/>  

                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left" CssClass="CellPaddingLeft"  />
                             </asp:TemplateField>

                                <asp:TemplateField HeaderText="Confirm Payment" HeaderStyle-HorizontalAlign="Center">    
                                <ItemTemplate>
                                <asp:LinkButton ID="LnkBtnConfirmation" runat="server" CssClass="links_FuncLinks" Text="[ CONFIRM ]" CommandArgument='<%# Eval("UID") + "," +  Eval("TransactionID")%>' OnCommand="OnCommand_ConfirmPayment" ToolTip='Click here to Confirm Payment or Update Remarks ' PostBackUrl="EbAd_BanKInConfirmation.aspx"/>
                                    <asp:LinkButton ID="LnkResendEmail" runat="server" CssClass=" FontColHeader" Text="[ RESENDEMAIL ]" CommandArgument='<%# Eval("UID") + "," +  Eval("TransactionID")%>' OnCommand="OnCommand_ConfirmPayment" ToolTip='Click here to resend Email' PostBackUrl="EbAd_BanKInConfirmationResend.aspx" Visible="false"/>
                                </ItemTemplate>
                                <ItemStyle  HorizontalAlign="Center" VerticalAlign="Middle" Width="100px"/>
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

