<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserNews.aspx.cs" Inherits="UserNews" %>


<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">


<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> <asp:Literal ID="LtrNewsLeft" Text="News" runat="server"></asp:Literal> </td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Image ID="Image1" runat="server" ImageUrl="Images/news_panel.jpg" />
    
</td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">&nbsp;</td>
<td width="1%">&nbsp;</td>
</tr>
<tr>
<td colspan="3">&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
<div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="ltrNewsHead" Text="News" runat="server"></asp:Literal>
                </div>
</td>
<td>&nbsp;</td>
</tr>

<tr>
<td>&nbsp;</td>
<td>

        <asp:Repeater ID="rpFaqList" runat="server">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="cssfaq">
            <tr>
            <td>
           <%-- <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="LtrNews" Text="News" runat="server"></asp:Literal>
                </div>
            </div>   --%> 
            
            </td>
            </tr>
            
            <tr>
            <td>&nbsp; </td>
            </tr>
         
        </HeaderTemplate>
        
        <ItemTemplate>
        
            <tr>
            <td> 
                <div class="cssfaqQuestion">
                    <div class="cssfaq_TLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                    <div class="cssfaq_QuestionText"> 
                    <asp:Literal ID="ltrSlNo" runat="server" Text='<%# Container.ItemIndex + 1  %>'></asp:Literal>.&nbsp; 
                    <asp:Literal ID="LtrFaqQuestion" Text='<%# Eval("NewsTitle")%>' runat="server"></asp:Literal>  
                    &nbsp;&nbsp;
                    <font class="font_EventDates">
                    [ Posted on : &nbsp;<asp:Literal ID="Literal1" Text='<%# Eval("NewsDate","{0:dddd, dd-MMM-yyyy hh:mm tt}")%>' runat="server"></asp:Literal>&nbsp;]  
                    </font>
                    </div>
                  
                 
                 
                </div>    
            
                </td>
            </tr>
            <tr>
            <td  class="cssfaqAnswer"> 
                <asp:Literal ID="LtrFaqAnswer" Text='<%# Eval("NewsContent").ToString().Replace(Environment.NewLine,"<br/>")%>' runat="server"></asp:Literal>
             </td>
            </tr>
          
        
        </ItemTemplate>
        <SeparatorTemplate>
            <tr>
            <td class="cssfaqSeparator">&nbsp; </td>
            </tr>
        
        </SeparatorTemplate>
        
        <FooterTemplate>
            <tr>
            <td>&nbsp; </td>
            <td>&nbsp; </td>
            </tr>
            </table>
        </FooterTemplate>
        </asp:Repeater>
        

  <table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr>
  <td>&nbsp;</td>
  </tr>
</table>
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>


</table>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
  <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />

</asp:Content>

