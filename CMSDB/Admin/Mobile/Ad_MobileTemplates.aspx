<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Mobile/AdminMasterDIYMB.master" AutoEventWireup="true" CodeFile="Ad_MobileTemplates.aspx.cs" Inherits="Admin_Ad_MobileTemplates" %>

<%@ Register src="Ad_Mobi_Menu.ascx" tagname="Ad_Mobi_Menu" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <form id="form2" runat="server">

       <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
       
       
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../../Images/inf_Error.gif" 
                     alt="MessageImage"/></td>
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
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                       
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;<asp:Literal ID="ltrTemplates" runat="server"></asp:Literal></td>
                      
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr style="height:30px;">
                        <td width="5%">&nbsp;</td>
                        <td width="90%">&nbsp;</td>
                        <td width="5%">&nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td valign="top">
                        <table cellpadding="0" cellspacing="0" width="100%" class="stdtable_BdrBlue_BkgGrey">
                        
                        <%--<tr style="background-color: #F1F6DE;" >
                    <td>&nbsp;</td>
                        <td align="left" class="FontBRowText1">
                            <asp:RadioButton ID="rdoMobiTmp1_Blue"  Text="Mobile Template 1 - Blue" runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1"  src="../../Images/Mobile/Templates/mbT1.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                        <td align="left"  class="FontBRowText1">
                         <asp:RadioButton ID="rdoWebTemplate1_Red" Text="Mobile Template 1 - Red" runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT2.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                        <td align="left"  class="FontBRowText1">
                            <asp:RadioButton ID="rdoWebTemplate1_Green" Text="Mobile Template 1 - Green" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT3.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                        <td align="left"  class="FontBRowText1">
                             <asp:RadioButton ID="rdoWebTemplate1_Orange" Text="Mobile Template 1 - Orange" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT4.png" 
                                style="width: 100px; height: 195px" />
                            </td>
                        <td align="left"  class="FontBRowText1">
                            <asp:RadioButton ID="rdoWebTemplate1_Purple" Text="Mobile Template 1 - Light Purple" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT5.png" 
                                style="width: 100px; height: 195px" />
                            </td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>--%>
                    <%--    
                        <tr style="background-color: #F1F6DE;" >
                    <td>&nbsp;</td>
                        <td align="left" class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                             &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                        
                        <tr style="background-color: #F1F6DE;" >
                    <td>&nbsp;</td>
                        <td align="left" class="FontBRowText1">
                              <asp:RadioButton ID="rdoWebTemplate2_Green"  Text="Mobile Template 2 - Green" runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1"  src="../../Images/Mobile/Templates/mbT6.png" 
                                style="width: 100px; height: 195px" /></td>
                             
                             <td align="left"  class="FontBRowText1">
                         <asp:RadioButton ID="rdoWebTemplate2_Maroon" Text="Mobile Template 2 - Maroon" runat="server" 
                                GroupName="GrpTemplate"/>
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT7.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                                
                        <td align="left"  class="FontBRowText1">
                            <asp:RadioButton ID="rdoWebTemplate2_Orange" Text="Mobile Template 2 - Orange" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT8.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                                
                        <td align="left"  class="FontBRowText1">
                             <asp:RadioButton ID="rdoWebTemplate2_Navy" Text="Mobile Template 2 - Navy" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT9.png" 
                                style="width: 100px; height: 195px" />
                            </td>
                        <td align="left"  class="FontBRowText1">
                            <asp:RadioButton ID="rdoWebTemplate2_Purple" Text="Mobile Template 2 - Purple" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT10.png" 
                                style="width: 100px; height: 195px" />
                            </td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                        --%>
                        
                        <tr style="background-color: #F1F6DE;" >
                    <td>&nbsp;</td>
                        <td align="left" class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                             &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                        
                        <tr style="background-color: #F1F6DE;" >
                    <td>&nbsp;</td>
                        <td align="left" class="FontBRowText1">
                              <asp:RadioButton ID="rdoWebTemplate3_Grey"  Text="Mobile Template 11 - Grey" runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1"  src="../../Images/Mobile/Templates/mbT11.png" 
                                style="width: 100px; height: 195px" /></td>
                             
                             <td align="left"  class="FontBRowText1">
                         <asp:RadioButton ID="rdoWebTemplate3_Green" Text="Mobile Template 12 - Green" runat="server" 
                                GroupName="GrpTemplate"/>
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT12.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                                
                        <td align="left"  class="FontBRowText1">
                            <asp:RadioButton ID="rdoWebTemplate3_Red" Text="Mobile Template 13 - Red" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT13.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                                
                        <td align="left"  class="FontBRowText1">
                             <asp:RadioButton ID="rdoWebTemplate3_Blue" Text="Mobile Template 14 - Blue" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT14.png" 
                                style="width: 100px; height: 195px" />
                            </td>
                        <td align="left"  class="FontBRowText1">
                            <asp:RadioButton ID="rdoWebTemplate3_Orange" Text="Mobile Template 15 - Orange" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT15.png" 
                                style="width: 100px; height: 195px" />
                            </td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr style="background-color: #F1F6DE;" >
                    <td>&nbsp;</td>
                        <td align="left" class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                             &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                        
                        <%--<tr style="background-color: #F1F6DE;" >
                    <td>&nbsp;</td>
                        <td align="left" class="FontBRowText1">
                              <asp:RadioButton ID="rdoWebTemplate4_Red"  Text="Mobile Template 16 - Red" runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1"  src="../../Images/Mobile/Templates/mbT16.png" 
                                style="width: 100px; height: 195px" /></td>
                             
                             <td align="left"  class="FontBRowText1">
                         <asp:RadioButton ID="rdoWebTemplate4_Grey" Text="Mobile Template 17 - Grey" runat="server" 
                                GroupName="GrpTemplate"/>
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT17.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                                
                        <td align="left"  class="FontBRowText1">
                            <asp:RadioButton ID="rdoWebTemplate4_Orange" Text="Mobile Template 18 - Orange" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT18.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                                
                        <td align="left"  class="FontBRowText1">
                             <asp:RadioButton ID="rdoWebTemplate4_Green" Text="Mobile Template 19 - Green" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT19.png" 
                                style="width: 100px; height: 195px" />
                            </td>
                        <td align="left"  class="FontBRowText1">
                            <asp:RadioButton ID="rdoWebTemplate4_Blue" Text="Mobile Template 20 - Blue" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT20.png" 
                                style="width: 100px; height: 195px" />
                            </td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr style="background-color: #F1F6DE;" >
                    <td>&nbsp;</td>
                        <td align="left" class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                             &nbsp;</td>
                        <td align="left"  class="FontBRowText1">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                        
                        <tr style="background-color: #F1F6DE;" >
                    <td>&nbsp;</td>
                        <td align="left" class="FontBRowText1">
                              <asp:RadioButton ID="rdoWebTemplate5_Blue"  Text="Mobile Template 21 - Blue Tech" runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1"  src="../../Images/Mobile/Templates/mbT21.png" 
                                style="width: 100px; height: 195px" /></td>
                             
                             <td align="left"  class="FontBRowText1">
                         <asp:RadioButton ID="rdoWebTemplate5_Green" Text="Mobile Template 22 - Green Turbo" runat="server" 
                                GroupName="GrpTemplate"/>
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT22.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                                
                        <td align="left"  class="FontBRowText1">
                            <asp:RadioButton ID="rdoWebTemplate5_Windows" Text="Mobile Template 23 - Windows" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT23.png" 
                                style="width: 100px; height: 195px" />
                                </td>
                                
                        <td align="left"  class="FontBRowText1">
                             <asp:RadioButton ID="rdoWebTemplate5_Orange" Text="Mobile Template 24 - Orange" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT24.png" 
                                style="width: 100px; height: 195px" />
                            </td>
                        <td align="left"  class="FontBRowText1">
                            <asp:RadioButton ID="rdoWebTemplate5_Red" Text="Mobile Template 25 - Red Flow" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp1" src="../../Images/Mobile/Templates/mbT25.png" 
                                style="width: 100px; height: 195px" />
                            </td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                        --%></table>
                        
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%" class="stdtable_BdrBlue_BkgGrey">
                        
                        <tr style="background-color: #F1F6DE;" >
                    <td>&nbsp;</td>
                        <td align="left" class="FontBRowText1">
                          
                                </td>
                 
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                        
                        </table></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnSetTemplate" runat="server" Text="Save Mobile Template" 
                                CssClass="stdbuttonCRUD" onclick="btnSetTemplate_Click" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                   </table>
                 
            </td></tr></table>
            
            </td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    


    </form>

</asp:Content>

