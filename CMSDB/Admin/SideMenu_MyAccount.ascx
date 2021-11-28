<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SideMenu_MyAccount.ascx.cs" Inherits="Admin_SideMenu_MyAccount" %>

<link href="../App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" type="text/css" />

<%--<div id="dvHM_Panel" class="Hm_Panel">
<div id="dvHM_Header" class="Hm_Header">
   <div id="dvHM_HeaderImg" class="Hm_headimg"> <img alt="tl" src="../Images/table_top_Leftarc.gif" style="width: 10px; height: 20px" /> </div>
   <div id="dvHM_HeaderText" class="Hm_headtext"><asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:LangResources, ManageEvents %>"></asp:Literal> </div> 
</div>
<div id="dvHM_Content" class="Hm_Content">

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
        <td width="2%">&nbsp;</td>
        <td  width="150px">
        <asp:Image ID="Image1" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
            <asp:HyperLink ID="HyperLink1" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="EventsCreate.aspx">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:LangResources, Add %>"></asp:Literal>&nbsp; Events  
            </asp:HyperLink>

        </td>
        <td>&nbsp;</td>
        <td  width="150px">

         <asp:Image ID="Image4" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
         <asp:HyperLink ID="HyperLink4" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="EventsListing.aspx">
          <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:LangResources, ViewEvents %>">ViewEvents</asp:Literal>&nbsp;
         </asp:HyperLink>

        </td>
        <td>&nbsp;</td>
        <td  width="5%">&nbsp;</td>

        </tr>
    </table>
</div>



</div>--%>


<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="96%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" >
                  <tr>
                        <td width="3%" align="left" valign="top" class="tblTopBarSub">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="22%" align="left" class="subHeaderMenuFontGrad tblTopBarSub" >
                            <asp:Literal ID="LtrMngMyAccount" runat="server" Text="Manage MyAccount"></asp:Literal> 
                             </td>
                        <td width="2%"  align="right" valign="top" class="tblTopBarSub">
                            &nbsp;</td>
                        <td width="75%" align="right" class="tblTopBarBkg">
                        
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                            <td width="2%">&nbsp;</td>
                            <td  width="180px">
                           <%-- <asp:Image ID="Image2" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                                <asp:HyperLink ID="HyperLink3" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="EventsCreate.aspx">
                                <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:LangResources, Add %>"></asp:Literal>&nbsp; Events  
                                </asp:HyperLink>--%>
                            
                            </td>
                            <td>&nbsp;</td>
                            <td  width="150px">
                            
                             <asp:Image ID="Image3" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HyperLink2" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="MyAccount.aspx">
                              <asp:Literal ID="LtrVwMyAct" runat="server" Text="View MyAccount Settings"></asp:Literal>&nbsp;
                             </asp:HyperLink>
                            
                            </td>
                            <td>&nbsp;</td>
                             <td  width="150px">
                            
                           <%--  <asp:Image ID="ImgChangePwd" ImageUrl="~/Images/tb_menuitem.jpg" runat="server" />
                             <asp:HyperLink ID="HypChangePassword" CssClass="Links_TopBarMenu" runat="server" NavigateUrl="Ad_ChangePassword.aspx">
                              <asp:Literal ID="ltrChangePassword" runat="server" Text="Change Password"></asp:Literal>&nbsp;
                             </asp:HyperLink>--%>
                            
                            </td>
                            <td  width="5%">&nbsp;</td>
                            
                            </tr>
                            </table>
                       
                        
                        </td>
                            
                    </tr>
                 </table>
            </td>
        </tr>

        </table></td>
        </tr>
    </table>