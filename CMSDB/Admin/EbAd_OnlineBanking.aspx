<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_OnlineBanking.aspx.cs" Inherits="Admin_EbAd_OnlineBanking" %>

<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_EBookSales.ascx" tagname="EBLeftMenu_EBookSales" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_EBookSales ID="EBLeftMenu_EBookSales1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    
     <style type="text/css">

         .CellPaddingRight { padding-right: 10px; 
         }

          .CellPaddingLeft { padding-left: 10px;
         }

         .auto-style1 {
             color: #FF0000;
         }

     </style>

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
            var ObjgridViewCtlId = '<%=gridPayPalTx.ClientID%>';

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
                            &nbsp; EBooks: Online Banking Purchases</td>
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
                            &nbsp;<span __designer:mapid="5a" class="auto-style1"><strong __designer:mapid="5b">Note: </strong><span __designer:mapid="59" style="font-size:11.0pt;line-height:107%;
font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
Calibri;mso-fareast-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA"><strong __designer:mapid="5c">Please download the Ebook . Download URL valid for 15 days only.</strong></span></span> 
                                    
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
                        
                            <asp:GridView ID="gridPayPalTx" runat="server" AutoGenerateColumns="False" DataKeyNames=""
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="100" onpageindexchanging="gridPayPalTx_PageIndexChanging"
                               AllowSorting="true"  
                                onrowcancelingedit="gridPayPalTx_RowCancelingEdit" 
                                onrowediting="gridPayPalTx_RowEditing"  
                                onrowdeleting="gridPayPalTx_RowDeleting" ondatabound="gridPayPalTx_DataBound" onrowdatabound="gridPayPalTx_RowDataBound" OnRowUpdating="gridPayPalTx_RowUpdating" OnSorting="gridPayPalTx_Sorting" OnRowCommand="gridPayPalTx_RowCommand"
                             >
                            <Columns>
                            
                            <asp:TemplateField HeaderText="Sl No">
                              <ItemTemplate>
                               <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>
                                  <asp:HiddenField ID="hidBookId" Value='<%#Bind("productCode")%>' runat="server" />
                                 
                              </ItemTemplate>
                              <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            

                              <asp:TemplateField HeaderText="eBook" >
                              <ItemTemplate>
                                  <asp:Literal ID="LtrBookID" runat="server" Text='<%# Bind("billid")  %>' Visible="false"></asp:Literal>
                                  <%--<br />--%>
                                   <asp:Label ID="lblBookName" CssClass="fontBlue12" runat="server" Text='<%# Bind("productCode")  %>'></asp:Label>
                                  <br /><br />
                                  <asp:Label ID="lblPurchaseDetails" CssClass="font_Content" runat="server" Text=''/>

                                  <asp:HiddenField ID="hdTXid" value='<%# Eval("billid")  %>' runat="server" />
                                  <asp:HiddenField ID="hdPytStatus" value='<%# Eval("status")  %>' runat="server" />
                                  <asp:HiddenField ID="hdRMPrice" value='<%# Eval("RMPrice")  %>' runat="server" />
                              </ItemTemplate>
                              <ItemStyle Width="120px" HorizontalAlign="Left"  />
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText="Buyer Name<br/>Mobile No.<br/>Email<br/>userlogin" >
                              <ItemTemplate>
                               <asp:Label ID="lblBuyerDetails" runat="server" Text=''/>

                                 

                                  <asp:Label ID="lblBuyerName" runat="server" Text='<%# Eval("Name")  %>'/> <br />
                                  <asp:HyperLink ID="hypMobile" runat="server" NavigateUrl='<%# Eval("wurl")%>' Target="_blank" >
                                  <asp:Label ID="lblBuyerMobile" runat="server" Text='<%# Eval("Mobile")  %>'/>
                                  </asp:HyperLink><br /><asp:Label ID="lblBuyerEmail" runat="server" Text='<%# Eval("Email")  %>'/><br />
                                  <asp:Label ID="lbluserlogin" runat="server" Text='<%# Eval("userlogin")  %>'/>

                              </ItemTemplate>
                              <ItemStyle Width="100px" HorizontalAlign="Left" CssClass="CellPaddingLeft"  />
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText="Purchase Date" >
                              <ItemTemplate>
                               <asp:Label ID="lblDateCreated" runat="server" Text='<%# Bind("TDate")  %>'/><br /><br />
                                <asp:Label ID="lblPytStatus" CssClass="fontBlue12" runat="server" Text='<%# Bind("status")  %>'></asp:Label>
                              </ItemTemplate>
                              <ItemStyle Width="70px" HorizontalAlign="center"  />
                             </asp:TemplateField>

                            <asp:TemplateField HeaderText="Book Password/Download Link" >
                              <ItemTemplate>
                                   <asp:Label ID="lblBookPassword" CssClass="fontBlue12" runat="server" Text='<%# Bind("bookpassword")  %>'></asp:Label><br /><br /><asp:Label ID="lblDownload" CssClass="fontBlue12" runat="server" Text='<%# Bind("booklink")  %>'></asp:Label></ItemTemplate><ItemStyle Width="100px" HorizontalAlign="Left" CssClass="CellPaddingLeft"  />
                             </asp:TemplateField>

                                <asp:TemplateField HeaderText="Re-Send SMS/Email" HeaderStyle-HorizontalAlign="Center">    
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkSendSMS" runat="server" CssClass="links_FuncLinks" Visible="false" Text="Re-Send SMS" CommandArgument='<%# Eval("UID")%>' OnCommand="OnCommand_ImageSendSMSNew" ToolTip='<%# "Send SMS to : " + Eval("Mobile")%>' />
                                    <br /><br />
                                <asp:TextBox ID="txtBuyerEmail" runat="server" Text='<%# Eval("Email")  %>' Visible="false"/><br />
                                <asp:LinkButton ID="LinkSendEmail" runat="server" CssClass="links_FuncLinks" Visible="false" Text="Re-Send Email" CommandArgument='<%# Eval("UID")%>' OnCommand="OnCommand_ImageSendEmailNew" ToolTip='<%# "Send Email to : " + Eval("Email")%>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px"/>
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
                                       </td>
                                          
                                 </tr>
                                    </table>
                                </PagerTemplate>
                                
                             <%--<PagerTemplate>
                                    <table border="0">
                                        <tr align="right">
                                           
                              <td>      
                                             <asp:Button CssClass="stdPagerButton" Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                                ID="btnFirst" />
                                            <asp:Button CssClass="stdPagerButton" Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                                ID="btnPrevious" />
                                                    </td>
                                                    
                                            <td>
                                                Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;<asp:Label
                                                    ID="PageCountLabel" runat="server" />
                                            </td>
                                              
                                        <td>
                                            <asp:Button CssClass="stdPagerButton" Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                                ID="btnNext" />
                                            <asp:Button  CssClass="stdPagerButton" Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                                ID="btnLast" />
                                          </td>
                                        </tr>
                                    </table>
                                </PagerTemplate>--%>
                            </asp:GridView>
                            
                        
                        </td>
                        <td>
                            &nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td align="left">
                           <%-- <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        </td>
                        <td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp; </td></tr></table><%--      </ContentTemplate>  


    </asp:UpdatePanel>--%><asp:HiddenField ID="HdEditBookUID" runat="server" />

    <asp:HiddenField ID="HdEditBookID" runat="server" />

<asp:HiddenField ID="hdnPRMCode_ID" runat="server" />
<asp:HiddenField ID="hdn_EmailID" runat="server" />


    </form>
</asp:Content>


