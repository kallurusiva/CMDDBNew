<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserTestimonials.aspx.cs" Inherits="UserTestimonials" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">


<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> <asp:Literal ID="ltrTestimonialLeft" Text="Testimonial" runat="server"></asp:Literal> </td>
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
<%--<form id="frmTest" runat="server">--%>
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
                <asp:Literal ID="ltrTestimonial" Text="Testimonial" runat="server"></asp:Literal>
                </div>
            </div>    
</td>
</tr>

<tr>
<td>&nbsp;</td>
<td>

        <asp:Repeater ID="rpFaqList" runat="server" 
            onitemdatabound="rpFaqList_ItemDataBound">
        <HeaderTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="96%" class="cssfaq">
            <tr>
            <td colspan="2">
            <%--<div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="ltrTestimonial" Text="Testimonial" runat="server"></asp:Literal>
                </div>
            </div>    --%>
            
            </td>
            </tr>
            
            <tr>
            <td>&nbsp; </td>
            </tr>
         
        </HeaderTemplate>
        
        <ItemTemplate>
        
            <tr>
            <td colspan="2"> 
                <div class="cssfaqQuestion">
                    <div class="cssfaq_TLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                    <div class="cssfaq_QuestionText"> 
                    <%--<asp:Literal ID="ltrSlNo" runat="server" Text='<%# Container.ItemIndex + 1  %>'></asp:Literal>.&nbsp; --%>
                    <asp:Literal ID="Literal2" Text='<%# Eval("tstByName")%>' runat="server"></asp:Literal> ,
                    <font class="font_EventDates">
                    &nbsp;<asp:Literal ID="Literal1" Text='<%# Eval("tstCreatedDate","{0:dddd, dd-MMM-yyyy hh:mm tt}")%>' runat="server"></asp:Literal>&nbsp;  
                    </font>
                    </div>
                </div>    
                
                <asp:HiddenField ID="hdByName" Value='<%# Eval("tstByName")%>' runat="server" />
                <asp:HiddenField ID="hdByDesig" Value='<%# Eval("tstByDesignation")%>' runat="server" />
                <asp:HiddenField ID="hdByCompany" Value='<%# Eval("tstByCompany")%>' runat="server" />
                
                
                </td>
            </tr>
            <tr>
            <td class="cssfaqAnswer" width="132px" align="center">
                <asp:Image ID="tstImage" ImageUrl='<%# Bind("FullImgPath")%>' Width="100" Height="100" runat="server" />
                <br />
                 <font class="font_12Msg_Success">
                <asp:Literal ID="Literal3" Text='<%# Eval("tstByDesignation")%>' runat="server"></asp:Literal> 
                </font><br />
                <asp:Literal ID="Literal4" Text='<%# Eval("tstByCompany")%>' runat="server"></asp:Literal>
                <br />
                <asp:Literal ID="Literal5" Text='<%# Eval("CountryName")%>' runat="server"></asp:Literal>
            </td>
            <td class="cssfaqAnswer" valign="top"> 
               <asp:Literal ID="LtrFaqAnswer" Text='<%# Eval("tstcontent").ToString().Replace(Environment.NewLine,"<br />") %>' runat="server"></asp:Literal>
             </td>
            </tr>
          
        
        </ItemTemplate>
        <SeparatorTemplate>
            <tr>
            <td class="cssfaqSeparator" colspan="2">&nbsp; </td>
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
<%--</form>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

