<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_WPNews.aspx.cs" Inherits="EBAd_WPNews" %>

<%@ Register src="EBLeftMenu_Books.ascx" tagname="EBLeftMenu_Books" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_ValueBuy.ascx" tagname="EBLeftMenu_ValueBuy" tagprefix="uc2" %>

<%@ Register src="EBLeftMenu_WPinfo.ascx" tagname="EBLeftMenu_WPinfo" tagprefix="uc3" %>

<%@ Register src="EBLeftMenu_WPNews.ascx" tagname="EBLeftMenu_WPNews" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

       <script language="javascript" type="text/javascript">
           function OpenWindow(NewsId) {
               window.open("EbAd_WpNewsInfoByID.aspx?NewsId=" + NewsId, '', 'height=500,width=750,scrollbars=yes,resizable=yes');
           }
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
   
        </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form1" runat="server">
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
                <table cellpadding="0" cellspacing="0" border="0" width="96%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; News List</td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="96%">
                            </td>
                    </tr>
                    
                   
                    <tr>
                         
                        <td align="center" >
                            <asp:GridView ID="GridNews" runat="server" AllowPaging="false" ShowFooter="true"  
                                AllowSorting="true" AlternatingRowStyle-CssClass="rowalt" AutoGenerateColumns="False" 
                                CssClass="mGrid" DataKeyNames="UID" HeaderStyle-CssClass="rowheader" 
                                onrowdatabound="GridNews_RowDataBound"  onsorting="GridNews_Sorting"
                                PageSize="30">
                                <Columns>
                            
                                    <asp:TemplateField HeaderText="Sl No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSlNo" runat="server" Text="<%# Container.DataItemIndex + 1  %>" />
                                            <asp:HiddenField ID="hdnUID" Value='<%#Bind("UID")%>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="News Header" SortExpression="Title">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNewsTitle" runat="server" Text='<%# Bind("Title")  %>' />

                                              &nbsp;&nbsp;...
                                        <asp:HyperLink Id="HypReadMore" runat="server" CssClass="links_FuncLinks" Text="Read more"/>

                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="390px" />
                                    </asp:TemplateField>
                                     
                                      <asp:TemplateField HeaderText="Posted On" SortExpression="DateCreated" >
                                      <ItemTemplate>
                                       <asp:Label ID="lblDateCreated" runat="server" Text='<%# Bind("DateCreated","{0:dd-MMM-yyyy hh:mm}")  %>'/>
                                      </ItemTemplate>
                                      <ItemStyle Width="100px" HorizontalAlign="center"  />
                                     </asp:TemplateField>

                                   
                                </Columns>
                             
                                <HeaderStyle CssClass="rowheader" />
                                <AlternatingRowStyle CssClass="rowalt" />
                                <FooterStyle CssClass ="rowfooter" />
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
                
                </td>
        </tr>
        </table>



    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

