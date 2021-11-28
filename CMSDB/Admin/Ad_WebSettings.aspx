<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_WebSettings.aspx.cs" Inherits="Admin_Ad_WebSettings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<%@ Register src="LeftMenu_WebSettings.ascx" tagname="LeftMenu_WebSettings" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            height: 17px;
        }
        .stylehand
        {
            cursor: hand;
        }
        .style3
        {
            background-color: #E7F1D8;
            font: bold 90%/100% "Trebuchet MS","Lucida Console", Arial, sans-serif;
            border-bottom: solid 1pt #BED7DA;
            color: #62657A;
            padding-left: 10px;
            height: 56px;
        }
        .style4
        {
            height: 56px;
        }
        .style5
        {
            background-color: #F1DFD8;
            border-bottom: solid 1pt #DFB6AA;
            border-left: solid 1pt #DFB6AA;
            font-size: 12px;
            color: #4E5163;
            height: 56px;
            padding-left: 5px;
        }
        </style>
    <script language="javascript" type="text/javascript">

        function fnDeleteImage(imgID) {
            //alert(imgID);
            location.href = 'MyHomePageSettings.aspx?ImgToDelete=' + imgID;
        
        }
    
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:LeftMenu_WebSettings ID="LeftMenu_WebSettings1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <form id="MyHomePageForm" runat="server" enctype="multipart/form-data">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr><td>&nbsp;</td></tr>
        <tr style="height:20px" id="tblMessageBar" visible="false" runat="server">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" >
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        
        <tr>
            <td>
               
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        
                        <td align="left" class="subHeaderFontGrad">
                            &nbsp; <asp:Literal ID="LtrMyActSettings" runat="server" 
                                Text="My Home Page Settings"></asp:Literal>&nbsp;
                          </td>
                       
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="2" class="stdtableBorder_MainBold" width="100%">
                    <tr>
                        <td width="2%">
                            &nbsp;</td>
                        <td width="96%">
                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </asp:ToolkitScriptManager>
                        </td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                <%--<tr id="trdefLang1" runat="server">
                                 <td width="35%">&nbsp;</td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="63%"  align="left" class="FontBRowHelp">Select the default language for the 
                                     Website to start with.</td>
                                </tr>--%>
                                <div runat="server" id="dvLang" visible="false">
                                <tr  id="trdefLang2" runat="server">
                                 <td  align="left"  class="FontBRowText">Select Website Language</td>
                                 <td class="style4"></td>
                                 <td align="left"  class="style5">
                                     <asp:RadioButtonList ID="rdoDefLanguague" runat="server" CellSpacing="10" CellPadding="5" RepeatDirection="Horizontal">
                                         <asp:ListItem Value="1">English</asp:ListItem>
                                         <%--<asp:ListItem Value="2">Bahasa Malay</asp:ListItem>
                                         <asp:ListItem Value="4">Bahasa Indonesia</asp:ListItem>
                                         <asp:ListItem Value="3">Chinese Simplified</asp:ListItem>--%>
                                    
                                     
                                     </asp:RadioButtonList>
                                 
                                 </td>
                                </tr>
                                </div>
                                
                              <%--    <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left" class="FontBRowHelp">Select the languages to be shown in languages dropdown at 
                                     Website.</td>
                                </tr>
                                
                                <tr>
                                 <td align="left" class="FontBRowText"> 
                                     SELECT Languague Dropdown</td>
                                 <td>&nbsp;</td>
                                 <td align="left" class="tblFormText"> 
                                     <asp:CheckBoxList ID="chkLangDropdown" RepeatDirection="Horizontal" 
                                         CellPadding="2" CellSpacing="10" Height="20px" RepeatColumns="5" runat="server">
                                         <asp:ListItem Value="1">English</asp:ListItem>
                                         <asp:ListItem Value="2">Bahasa Malay</asp:ListItem>
                                         <asp:ListItem Value="3">Chinese Simplified</asp:ListItem>
                                    </asp:CheckBoxList></td>
                                </tr>--%>
                                
                                
                                <tr class="BlankWhiteHorizontalLine">
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left" class="FontBRowHelp">Select the links to appear at the top most row 
                                     at the Website. </td>
                                </tr>
                                
                            
                                
                                 <tr>
                                 <td align="left" class="FontBRowText"> 
                                     Select Top Row Links</td>
                                 <td>:</td>
                                 <td align="left" class="tblFormText"> 
                                     <asp:CheckBoxList ID="chkTopRowBtnList" RepeatDirection="Horizontal" CellPadding="2" CellSpacing="10" Height="20px" RepeatColumns="5" runat="server">
                            </asp:CheckBoxList></td>
                                </tr>
                                
                                 <tr>
                                 <td align="left"> 
                                     </td>
                                 <td></td>
                                 <td align="left" class="FontBRowHelp"> 
                                     Select the menu items below to appear a the Website. 
                                     </td>
                                </tr>
                                
                                 <tr>
                                 <td align="left" style="font-weight: 700" class="FontBRowText"> 
                                     <asp:Literal ID="LtrTopMenuLinks" runat="server" Text="Select Top Menu Links "></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"  class="tblFormText"> 
                                    <div style="float:left;">
                                    <asp:CheckBoxList ID="chkList_TopMenuItems" runat="server" RepeatColumns="4" 
                                        RepeatDirection="Horizontal" CellPadding="2" CellSpacing="10" Height="20px">
                                    </asp:CheckBoxList>
                                    
                                    </div>
                                  <%--  <div style="float:left; margin: 2px; padding:10px;">
                                     <asp:CheckBox ID="chkExtraWebButton" Text="Business Tips" runat="server" />
                                     </div> --%>                                     
                                     </td>
                                </tr>
                                
                                 <tr>
                                 <td align="left"> 
                                     &nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left"> 
                                     &nbsp;</td>
                                </tr>
                               
                                 <tr>
                                 <td align="left"  class="FontBRowText"> 
                                     Selected Logo</td>
                                 <td>&nbsp;</td>
                                 <td align="left" class="tblFormText"> 
                                     <div id="dvSelectedLogo" style="padding-top: 5px; padding-bottom: 5px;" runat="server"></div></td>
                                </tr>
                                
                            
                                
                               
                                 <tr>
                                 <td align="left"> 
                                     &nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left"> 
                                     &nbsp;</td>
                                </tr>
                                
                            
                                
                               
                                 <tr>
                                 <td align="left"  class="FontBRowText"> 
                                     Selected Banner</td>
                                 <td>&nbsp;</td>
                                 <td align="left" class="tblFormText"> 
                                    <div id="dvSeletedBanner" style="padding-top: 5px; padding-bottom: 5px;" runat="server"></div></td>
                                </tr>
                                
                            
                                
                               
                                 <tr>
                                 <td align="left"> 
                                     &nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left"> 
                                     &nbsp;</td>
                                </tr>
                                
                            
                                
                               
                                 <tr id="trCopyRights" runat="server" visible="false">
                                 <td align="left" class="FontBRowText"> 
                                     CopyRights Information</td>
                                 <td>&nbsp;</td>
                                 <td align="left" class="tblFormText"> 
                                     Default&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;
                                     <asp:RadioButton ID="rdoCopyRightsDefault" GroupName="grpCopyRights" runat="server" 
                                         Text="" />
                                     <br />
                                     Enter NEW :&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:RadioButton ID="rdoCopyRightsNewText" GroupName="grpCopyRights" runat="server" 
                                         Text="" />
                                     &nbsp;<asp:TextBox ID="txtNewCopyRightsInfo" CssClass="stdTextField2" runat="server" 
                                         Text='<%# Bind("CopyRightsInfo") %>'></asp:TextBox>
                                         
                                         </td>
                                </tr>
                                
                            
                                
                               
                                 <tr>
                                 <td colspan="3">
                                     &nbsp;</td>
                                </tr>
                                
                                
                               
                                <tr>
                                 <td class="style2"></td>
                                 <td class="style2"></td>
                                 <td class="style2"></td>
                                </tr>
                                
                                
                                
                               
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                    <%-- <asp:ImageButton ImageUrl='' ID='imgDelete' OnClick='imgDelete_Click' ToolTip='Delete logo' AccessKey='' runat='server'/>--%>
                                     <asp:Button ID="Button1" CssClass="stdbuttonCRUD" runat="server" 
                                         Text="SAVE web page settings" onclick="Button1_Click" />
                                    </td>
                                </tr>
                                
                                
                                
                               
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                     &nbsp;</td>
                                </tr>
                                
                                
                                
                               
                                <tr>
                                 <td class="font_stdupdateMsg"><b>NOTE</b> </td>
                                 <td>:</td>
                                 <td align="left" class="font_stdupdateMsg">
                                     For subdomain, Only LogoTemplate1 and BannerTemplate 1 will be Selected.
                                    </td>
                                </tr>
                                
                                
                                
                               
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                     &nbsp;</td>
                                </tr>
                                
                                
                                
                               
                                </table>
                            
                            
                            </td>
                        <td>&nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td>
                            &nbsp;</td><td>
                            &nbsp;</td></tr></table></td></tr></table></td>
            </tr>
            <tr>
            <td>
              </td></tr></table></form>
                
                
</asp:Content>

