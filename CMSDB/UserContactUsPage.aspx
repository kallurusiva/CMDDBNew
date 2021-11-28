<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="UserContactUsPage.aspx.cs" Inherits="UserContactUsPage" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLEFT" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td align="center" class="subHeaderMenuFontGrad"> <asp:Literal ID="ltrContactUs" Text="Contact Us" runat="server"></asp:Literal> </td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
<tr>
<td>
    <asp:Image ID="Image1" runat="server" ImageUrl="Images/ContactUs_panel.jpg" />
    
</td>
</tr>
<tr>
<td>&nbsp;</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
<%--<form id="form1" runat="server">--%>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td width="1%">&nbsp;</td>
<td width="98%">&nbsp;</td>
<td width="1%">&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
     <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="ltrContactUs3" Text="Contact Us" runat="server"></asp:Literal>
                </div>
   </div>     </td>
<td>&nbsp;</td>
</tr>

<tr>
<td>&nbsp;</td>
<td>
&nbsp;
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td align="center">
     <table cellpadding="0" cellspacing="0" width="100%" class="stdtableBorder_Main">
         <tr>
            <td  width="10%">&nbsp;</td>
             <td width="40%" align="left" class="font_14BoldGrey">
                 &nbsp;</td>
             <td width="40%" align="center">
                 &nbsp;</td>
             <td width="10%">&nbsp;</td>
         </tr>
         <tr>
            <td  width="10%">&nbsp;</td>
             <td width="40%" align="left" class="font_14BoldGrey">
                 &nbsp;</td>
             <td width="40%" align="center">
                 &nbsp;</td>
             <td width="10%">&nbsp;</td>
         </tr>
         <tr>
            <td  width="10%">&nbsp;</td>
             <td width="40%" align="left" class="font_14BoldGrey">
                 <asp:Literal ID="ltrCompanyName" Text="" runat="server"></asp:Literal>
                 <br />
                 <asp:Literal ID="LtrNickName" Text="" runat="server"></asp:Literal>
                 <br />
                 <br />
                 <asp:Literal ID="LtrAddress" Text="" runat="server"></asp:Literal>
                 <br />
                 <br />
         <%--        <img alt="homephone" id="imgHomePhone" runat="server" src="Images/icon_homephone.jpg" style="width: 27px; height: 23px" />
                  &nbsp;&nbsp;--%><asp:Literal ID="ltrHomephone" Text="" runat="server"></asp:Literal>
                 <br />
          <%--       <img alt="handphne" id="imgHandPhone" runat="server" src="Images/icon_handphone.jpg" style="width: 27px; height: 25px" />
                     &nbsp;&nbsp;--%><asp:Literal ID="LtrHandPhone" Text="" runat="server"></asp:Literal>
                 <br />
             <%--    <img alt="fax" id="imgFaxPhone" runat="server" src="Images/icon_fax.jpg" style="width: 27px; height: 25px" />
                 &nbsp;&nbsp;--%><asp:Literal ID="ltrFaxNo" Text="" runat="server"></asp:Literal>
             
                 <br />
           <%--      <img alt="Email" id="imgEmail" runat="server" src="Images/icon_email.jpg" style="width: 27px; height: 25px" />
                 &nbsp;&nbsp;--%><asp:Literal ID="ltrEmail" Text="" runat="server"></asp:Literal>
             
             </td>
             <td width="40%" align="center">
                 <asp:Image ID="ImgContact" Width="150" Height="150" runat="server" /></td>
             <td width="10%">&nbsp;</td>
         </tr>
         <tr>
            <td  width="10%">&nbsp;</td>
             <td width="40%" align="left" class="font_14BoldGrey">
                 &nbsp;</td>
             <td width="40%" align="center">
                 &nbsp;</td>
             <td width="10%">&nbsp;</td>
         </tr>
         <tr>
            <td  width="10%">&nbsp;</td>
             <td width="40%" align="left" class="font_14BoldGrey">
                 &nbsp;</td>
             <td width="40%" align="center">
                 &nbsp;</td>
             <td width="10%">&nbsp;</td>
         </tr>
     </table>
    </td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
     &nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
     <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="LtrContactus2" Text="Contact Us" runat="server"></asp:Literal>
                </div>
     </div>
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
    <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
     <tr>
     <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
     <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
     </tr>
     </table>
</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>
            <table cellpadding="0" cellspacing="2" width="100%" runat="server" id="tblEntryForm">
              <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;</td>
                  <td class="tblFormText" width="80%" >
                      &nbsp;</td>
                
              </tr>
              <tr>
                  
                  <td class="tblFormLabel" width="20%" >&nbsp;<asp:Label ID="lblName" 
                          runat="server" Text="Name"></asp:Label></td>
                  <td class="tblFormText" width="80%" >
                      <asp:TextBox ID="txtName" CssClass="stdTextField1" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Please enter name" 
                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                  </td>
                
              </tr>
               <tr> 
                  <td class="tblFormLabel">&nbsp;<asp:Label ID="lblContactNo" runat="server" 
                          Text="Contact No."></asp:Label></td>
                  <td  class="tblFormText"><asp:TextBox ID="txtContactNo" CssClass="stdTextField1" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="txtContactNo" Display="Dynamic" 
                          ErrorMessage="Please enter ContactNo" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
                
              </tr>
               <tr>
                 
                  <td class="tblFormLabel">&nbsp;<asp:Label ID="lblEmail" runat="server" 
                          Text="Email"></asp:Label></td>
                  <td  class="tblFormText"><asp:TextBox ID="txtEmail" CssClass="stdTextField1" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                          ControlToValidate="txtEmail" Display="Dynamic" 
                          ErrorMessage="Please enter email." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                      ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                      Display="Dynamic" runat="server" ErrorMessage="*  Enter a Valid Email" ValidationGroup="VgCheck" 
                      SetFocusOnError="True"></asp:RegularExpressionValidator>
                   </td>
                 
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">
                      &nbsp;<asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label></td>
                  <td  class="tblFormText" valign="top" >
                            <asp:DropDownList ID="DdlCountry" CssClass="stdDropDown1" runat="server">
                            </asp:DropDownList>
                        </td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;<asp:Label ID="lblSubject" 
                          runat="server" Text="Subject"></asp:Label></td>
                  <td  class="tblFormText" valign="top" ><asp:TextBox ID="txtSubject" CssClass="stdTextField1" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                          ControlToValidate="txtSubject" Display="Dynamic" 
                          ErrorMessage="Please enter Subject" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;<asp:Label ID="lblMessage" 
                          runat="server" Text="Message"></asp:Label></td>
                  <td  class="tblFormText" valign="top" ><asp:TextBox ID="txtMessage" 
                          CssClass="stdTextArea2" runat="server" TextMode="MultiLine"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                          ControlToValidate="txtMessage" Display="Dynamic" 
                          ErrorMessage="Please enter Message." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                   </td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >
                      <asp:Button ID="btnSubmit" runat="server" Text="Send" 
                          onclick="btnSubmit_Click" ValidationGroup="VgCheck" />
                   </td>
               
              </tr>
              
               <tr>
                
                  <td class="tblFormLabel" valign="top">&nbsp;</td>
                  <td  class="tblFormText" valign="top" >&nbsp;</td>
               
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



<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>



</table>
   <%-- </form>--%>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
     <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

