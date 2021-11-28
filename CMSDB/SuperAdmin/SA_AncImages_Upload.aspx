<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_AncImages_Upload.aspx.cs" Inherits="SA_AncImages_Upload" %>

<%@ Register src="SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc3" %>

<%@ Register src="SA_SideMenu_PgSettings.ascx" tagname="SA_SideMenu_PgSettings" tagprefix="uc1" %>

<%@ Register src="SA_SideMenu_Gallery.ascx" tagname="SA_SideMenu_Gallery" tagprefix="uc2" %>

<%@ Register src="SA_SideMenu_Domains.ascx" tagname="SA_SideMenu_Domains" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc4:SA_SideMenu_Domains ID="SA_SideMenu_Domains1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <form id="form2" runat="server">

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
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="ltrHeader" runat="server" 
                                Text=""></asp:Literal></td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="98%" runat="server">
                    <tr>
                   <td>
                   
                   
                   <table cellpadding="0" cellspacing="2" width="100%" runat="server" id="tblEntryForm">
              <tr>
                  
                  <td class="tblFormLabel1" width="20%" >&nbsp;</td>
                  <td class="tblFormText1Help" width="80%" align="left" >
                      Select image to upload.</td>
                
              </tr>
              <tr>
                  
                  <td class="tblFormLabel1" align="right">Select Image to Upload :</td>
                  <td class="tblFormText1" align="left">
                   <asp:FileUpload ID="FU_Image" runat="server" CssClass="stdUploadField" 
                          Width="410px" />
                        <asp:Label ID="lblUpMessage" runat="server" CssClass="FontNote"></asp:Label>
                                                
                        <asp:RegularExpressionValidator ID="FileUploadValidator" runat="server" 
                            ControlToValidate="FU_Image" Enabled="true" ValidationGroup="vgCheck" 
                            ErrorMessage="<br/>Only jpg,gif or Png type images are allowed.  Please select another image." 
                            
                          ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])" 
                          Display="Dynamic"></asp:RegularExpressionValidator>
                            
                         <asp:CustomValidator ID="CustomVdr_Logo" runat="server" ControlToValidate="FU_Image"
                          ErrorMessage="* Image size should not be greater than 200 KB." ValidationGroup="vgCheck"  
                          OnServerValidate="CustomVdr_Image_ServerValidate" Display="Dynamic"></asp:CustomValidator>

                  &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                          ControlToValidate="FU_Image" CssClass="font_11Msg_Error" Display="Dynamic" 
                          ErrorMessage="* Please select an image to upload." ValidationGroup="vgCheck"></asp:RequiredFieldValidator>
                  </td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">&nbsp;</td>
                  <td class="tblFormText1Help" align="left">
                      Select category for the video based upon Industry.</td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">Select Anchor Domain&nbsp; :</td>
                  <td class="tblFormText1" align="left">
                      <asp:DropDownList ID="ddlAnchorDomain" runat="server" ValidationGroup="vgCheck" CssClass="stdDropDown" Width="209px">
                      </asp:DropDownList>
                  &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="ddlAnchorDomain" Display="Dynamic" 
                          ErrorMessage="Please select AnchorDomain" InitialValue="0" 
                          ValidationGroup="vgCheck"></asp:RequiredFieldValidator>
                  </td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">&nbsp;</td>
                  <td class="tblFormText1" align="left">
                      &nbsp;</td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">&nbsp;</td>
                  <td class="tblFormText1" align="left">
                      <asp:Button ID="btnSaveImage" runat="server" CssClass="stdbuttonCRUD" 
                          Text="Save Image" onclick="btnSaveImage_Click" ValidationGroup="vgCheck" />
                  </td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">&nbsp;</td>
                  <td class="tblFormText1" align="left">
                      &nbsp;</td>
                
              </tr>
                         
               
              
              
               </table>
                   
                   
                   </td>    
                    </tr>
                    
                      <tr>
                      <td>
                        &nbsp; 
                      </td>
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
                &nbsp;
            </td>
        </tr>
    </table>

    </form>
    
</asp:Content>

