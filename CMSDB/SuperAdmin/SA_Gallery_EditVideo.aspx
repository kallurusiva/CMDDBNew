<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_Gallery_EditVideo.aspx.cs" Inherits="SA_Gallery_EditVideo" %>

<%@ Register src="SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc3" %>

<%@ Register src="SA_SideMenu_PgSettings.ascx" tagname="SA_SideMenu_PgSettings" tagprefix="uc1" %>

<%@ Register src="SA_SideMenu_Gallery.ascx" tagname="SA_SideMenu_Gallery" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SA_SideMenu_Gallery ID="SA_SideMenu_Gallery1" runat="server" />
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
                      </td>
                
              </tr>
              <tr>
                  
                  <td class="tblFormLabel1" align="right">Display at Website :</td>
                  <td class="tblFormText1Help" align="left">
                      <asp:CheckBox ID="chkActive" runat="server" Checked="True" />
                    &nbsp; Check to Show/Hide Image at website.</td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">&nbsp;</td>
                  <td class="tblFormText1" align="left">
                      &nbsp;</td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">Current Video : </td>
                  <td class="tblFormText1" align="left">
                     <div id="dvgiImage" class="dvgiImages"> 
                         <asp:Literal ID="ltrVideoFrame" runat="server"></asp:Literal>
                     </div>
                   </td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">&nbsp;</td>
                  <td class="tblFormText1Help" align="left">
                      To Change, Copy and Paste the new Youtube Link here.</td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">Insert new Video Link :</td>
                  <td class="tblFormText1Help" align="left">
                       <asp:TextBox ID="txtVideoLink" runat="server" CssClass="stdTextField2" 
                          ValidationGroup="vgCheck"></asp:TextBox>
&nbsp;&nbsp;</td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">&nbsp;</td>
                  <td class="tblFormText1Help" align="left">
                      Enter title for the Image.</td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">Video Title :</td>
                  <td class="tblFormText1" align="left">
                      <asp:TextBox ID="txtVideoTitle" runat="server" CssClass="stdTextField2"></asp:TextBox>
                  &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="txtVideoTitle" CssClass="font_11Msg_Error" Display="Dynamic"
                          ErrorMessage="Title cannot be empty." ValidationGroup="vgCheck"></asp:RequiredFieldValidator>
                  </td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">&nbsp;</td>
                  <td class="tblFormText1Help" align="left">
                      Select category for the video based upon Industry.</td>
                
              </tr>
                         
               
              
              
              <tr>
                  
                  <td class="tblFormLabel1" align="right">Category :</td>
                  <td class="tblFormText1" align="left">
                      <asp:DropDownList ID="ddlCategory" runat="server" CssClass="stdDropDown" Width="209px">
                      </asp:DropDownList>
                  &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="ddlCategory" Display="Dynamic" 
                          ErrorMessage="Please select category" InitialValue="Select Category" 
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

