<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_TemplateSetEbook.aspx.cs" Inherits="Admin_Ad_TemplateSetEbook" %>

<%@ Register src="SideMenu_PgSettings.ascx" tagname="SideMenu_PgSettings" tagprefix="uc1" %>

<%@ Register src="LeftMenu_Gallery.ascx" tagname="LeftMenu_Gallery" tagprefix="uc2" %>

<%@ Register src="LeftMenu_WebSettings.ascx" tagname="LeftMenu_WebSettings" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc3:LeftMenu_WebSettings ID="LeftMenu_WebSettings1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <style type="text/css">
 .styleRow
 { color: #3C3D3D; font: bold 12px "Trebuchet MS", Verdana, Arial;
    background-color: #78ADD0; height: 24px; padding: 5px 5px 2px 25px; 
    background: -webkit-gradient(linear, left top, left bottom, from(#78ADD0), to(#CDEBFF)); /* for webkit browsers */
    background: -moz-linear-gradient(top,  #78ADD0,  #CDEBFF); /* for firefox 3.6+ */
    filter:progid:DXImageTransform.Microsoft.Gradient(StartColorStr=#78ADD0 ,EndColorStr=#CDEBFF,GradientType=0);
 }

</style>

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
                        
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="ltrSetDefaultTemplate" runat="server"></asp:Literal></td>
                       
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
           <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="100%" runat="server">
            <tr>
            <td width="1%">&nbsp;</td>
            <td width="98%">&nbsp;</td>
            <td width="1%">&nbsp;</td>
            </tr> 
            <tr>
            <td>&nbsp;</td>
            <td>
                <table cellpadding="0" cellspacing="0" class="stdtable_BdrBlue_BkgGrey" width="100%">
                    <tr>
                        <td width="2%"></td>
                        <td width="20%"></td>
                        <td width="20%"></td>
                        <td width="20%"></td>
                        <td width="20%"></td>
                        <td width="20%"></td>
                        <td width="2%"></td>
                    </tr>
                    
                    
                   
                  <%--  <tr>
                    <td>&nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                    
                    

                       <%-- Ebook Generic Template  1  --%>
                    <tr>
                        <td colspan="7" class="styleRow" align="left">
                         Ebook Templates Design 1 :  Set up your top menu with your own buttons as the priority. [with Banner and Logo]
                        </td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left">
                               <asp:RadioButton ID="rdoWebTemplate1_Navy" Text="Template Design1 Navy" 
                                   runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTmpEbook1_Navy.jpg" 
                                style="width: 200px; height: 196px" />
                                </td>
                        <td>
                             <asp:RadioButton ID="rdoWebTemplate1_Magenta" Text="Template Design1 Magenta" 
                                 runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTmpEbook1_Magenta.jpg" 
                                style="width: 200px; height: 196px" />
                                </td>
                        <td>
                            <asp:RadioButton ID="rdoWebTemplate1_darkCyan" Text="Template Design1 Cyan" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTmpEbook1_Cyan.jpg" 
                                style="width: 200px; height: 196px" />
                                
                                </td>
                        <td>
                              <asp:RadioButton ID="rdoWebTemplate1_Gold" Text="Template Design1  Gold" 
                                  runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTmpEbook1_Gold.jpg" 
                                style="width: 200px; height: 196px" />
                            
                            </td>
                        <td>
                                             <asp:RadioButton ID="rdoWebTemplate1_tomato" Text="Template Design1 tomato" 
                                                 runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTmpEbook1_tomato.jpg" 
                                style="width: 200px; height: 196px" />
                                </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr >
                    <td>&nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>


                     <%-- Ebook Generic Template  2  --%>
                  <%--  <tr >
                        <td colspan="7" class="styleRow" align="left">
                         Ebook Templates Design 2 :  Set up your top menu with your own buttons as the priority. [without Banner and Logo]
                        </td>
                    </tr>
                    <tr >
                    <td>&nbsp;</td>
                        <td align="left">
                               <asp:RadioButton ID="rdoWebTemplate2_Navy" Text="Template Design2 Navy" 
                                   runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTemplateGen2_Navy.jpg" 
                                style="width: 165px; height: 147px" />
                                </td>
                        <td>
                             <asp:RadioButton ID="rdoWebTemplate2_Magenta" Text="Template Design2 Magenta" 
                                 runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTemplateGen2_Magenta.jpg" 
                                style="width: 165px; height: 147px" />
                                </td>
                        <td>
                            <asp:RadioButton ID="rdoWebTemplate2_darkCyan" Text="Template Design2 Cyan" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTemplateGen2_darkCyan.jpg" 
                                style="width: 165px; height: 147px" />
                                
                                </td>
                        <td>
                              <asp:RadioButton ID="rdoWebTemplate2_Gold" Text="Template Design2  Gold" 
                                  runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTemplateGen2_Gold.jpg" 
                                style="width: 165px; height: 147px" />
                            
                            </td>
                        <td>
                         <asp:RadioButton ID="rdoWebTemplate2_tomato" Text="Template Design2 tomato" 
                                     runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTemplateGen2_tomato.jpg" 
                                style="width: 165px; height: 147px" />
                                </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr >
                    <td>&nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>


                     <%-- Own Button Template : Without Banner, Logo , Free SMS , Customer Login and Language Dropdown --%>
                     
                    <%--<tr visible="false">
                        <td colspan="7" class="styleRow" align="left">
                         Own Button Templates:  Set up your top menu with your own buttons as the priority. 
                            <br />
                                                        [Without Banner, Logo,  Free SMS ,Customer Login and Language Dropdown (Default 
                            predefined Language is set for the website.] 
                        </td>
                    </tr>--%>
                    <%--<tr visible="false">
                    <td>&nbsp;</td>
                        <td align="left">
                               <asp:RadioButton ID="rdoWebTemplateOwnBtn_WL_Navy" Text="Own ButtonsTemplate_Navy" 
                                   runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTemplateOwnBtn_WL_Navy.jpg" 
                                style="width: 165px; height: 147px" />
                                </td>
                        <td>
                             <asp:RadioButton ID="rdoWebTemplateOwnBtn_WL_Magenta" Text="Own Buttons Template_Magenta" 
                                 runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTemplateOwnBtn_WL_Magenta.jpg" 
                                style="width: 165px; height: 147px" />
                                </td>
                        <td>
                            <asp:RadioButton ID="rdoWebTemplateOwnBtn_WL_Cyan" Text="Own Buttons Template_Cyan" 
                                runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTemplateOwnBtn_WL_darkCyan.jpg" 
                                style="width: 165px; height: 147px" />
                                
                                </td>
                        <td>
                              <asp:RadioButton ID="rdoWebTemplateOwnBtn_WL_Gold" Text="Own ButtonsTemplate_Gold" 
                                  runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTemplateOwnBtn_WL_Gold.jpg" 
                                style="width: 165px; height: 147px" />
                            
                            </td>
                        <td>
                                             <asp:RadioButton ID="rdoWebTemplateOwnBtn_WL_tomato" Text="Own Buttons Template_tomato" 
                                                 runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/webTemplateOwnBtn_WL_tomato.jpg" 
                                style="width: 165px; height: 147px" />
                                </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                                     
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left">
                            <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="stdbuttonCRUD" 
                                onclick="BtnSave_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="BtnCancel" runat="server" Text="Cancel"  CssClass="stdbuttonCRUD" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left" class="FontNote" colspan="2">
                            <b><asp:Literal ID="ltrNote" runat="server"></asp:Literal></b>: &nbsp; <asp:Literal ID="ltrNoteLanguage" runat="server"></asp:Literal>
                        </td>
                        <td align="left" class="FontNote">
                        
                            &nbsp;</td>
                        <td align="left" class="FontNote">
                        
                            &nbsp;</td>
                        <td align="left" class="FontNote">
                        
                            &nbsp;</td>
                        <td align="left" class="FontNote">
                        
                            &nbsp;</td>
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
             
             
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            </tr>
        </table>
                
                </td>
        </tr>
        <tr>
            <td style="color: White;">
                &nbsp;
                <%--<asp:HyperLink ID="HyperLink23" NavigateUrl="~/Admin/MyHomePageSettings_Async.aspx" runat="server">..</asp:HyperLink>--%>
                <asp:Label ID="lblSessionValues" runat="server" Text="tests"></asp:Label>
            </td>
        </tr>
    </table>

    </form>
</asp:Content>

