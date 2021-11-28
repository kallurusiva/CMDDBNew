<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserEvents.aspx.cs" Inherits="UserEvents" %>


<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">


<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> 
    <asp:Literal ID="ltrEvents" runat="server"></asp:Literal></td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Image ID="Image1" runat="server" ImageUrl="Images/faq_panel.jpg" />
    
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
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>

<tr>
<td colspan="3">

<div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="LtrEventH" Text="" runat="server"></asp:Literal>
                </div>
            </div>   

</td>
</tr>

<tr>
<td>&nbsp;</td>
<td>

        <asp:Repeater ID="rpFaqList" runat="server">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="96%" class="cssfaq">
            <tr>
            <td>
          <%--  <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="LtrEvents" Text="" runat="server"></asp:Literal>
                </div>
            </div>    
            --%>
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
                    <asp:Literal ID="LtrFaqQuestion" Text='<%# Eval("EventTitle")%>' runat="server"></asp:Literal>  
                    &nbsp;&nbsp;
                     <font class="font_EventDates">
                    [ Posted on : &nbsp;<asp:Literal ID="Literal3" Text='<%# Eval("ModifiedDate","{0:dddd, dd-MMM-yyyy hh:mm tt}")%>' runat="server"></asp:Literal>&nbsp;]  
                    </font>
               </div>
             </div>    
            
                </td>
            </tr>
            <tr>
            <td>
            <div class="cssfaqQuestion2">&nbsp;&nbsp;&nbsp;&nbsp;
                 <font class="font_EventDates11">
                    [ To be held From &nbsp;<u><asp:Literal ID="Literal1" Text='<%# Eval("EventDate","{0:ddd, dd-MMM-yyyy hh:mm tt}")%>' runat="server"></asp:Literal></u>&nbsp;
                       To &nbsp;<u><asp:Literal ID="Literal2" Text='<%# Eval("EventDateTO","{0:ddd, dd-MMM-yyyy hh:mm tt}")%>' runat="server"></asp:Literal></u>
                    ]  
                    </font>
            </div>
            </td>
            </tr>
            <tr>
            <td  class="cssfaqAnswer"> 
                <asp:Literal ID="LtrFaqAnswer" Text='<%# Eval("EventContent")%>' runat="server"></asp:Literal>
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

