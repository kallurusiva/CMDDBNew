<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_SetDesign11.aspx.cs" Inherits="Admin_EbAd_SetDesign11" %>

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

                

        .auto-style1 {
            background-color: #EEEFEB;
            border-bottom: solid 1pt #D4DFAA;
            border-left: solid 1pt #D4DFAA;
            font-size: 12px;
            color: #4E5163;
            height: 25px;
            padding-left: 20px;
            width: 195px;
        }
        .auto-style2 {
            background-color: #EEEFEB;
            border-bottom: solid 1pt #D4DFAA;
            border-left: solid 1pt #D4DFAA;
            font-size: 12px;
            color: #4E5163;
            height: 25px;
            padding-left: 20px;
            width: 177px;
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
            <td width="98%">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <%--<tr>
                       
                        <td>
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal5" Text="Show or Hide Home Page Products" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>--%>
                    
                    <%--<tr style="vertical-align:baseline;">
                    <td align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                            <tr>
                                <td width="250px" >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>                             
                        
                             <tr>
                                <td>&nbsp;</td>
                                <td class="FontSubHeader">  Display Home Page Products at Website</td>
                            </tr>                           
                        
                             <tr>
                                <td class="ebFormLabel1">Feature Buy</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_FeatureBuy" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Best Seller</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_BestSeller" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">New Releases</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_NewReleases" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Value Buy</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_ValueBuy" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Free</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_Free" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  
                                    <asp:Button ID="BtnSaveAdminShowHide" runat="server" CssClass="stdbuttonCRUD" Text="Save Home Page Products Display Settings" OnClick="BtnSaveAdminShowHide_Click"/>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>
                        
                        </table>
                        
                        
                    
                    </td>
                    </tr>--%>
                    
                                        
                      </table>
         
                            </td>
            <td width="1%">&nbsp;</td>
            </tr> 
            <tr>
            <td>&nbsp;</td>
            <td>
                <table cellpadding="0" cellspacing="0" class="stdtable_BdrBlue_BkgGrey" width="100%">
                    <%--<tr>
                        <td width="2%"></td>
                        <td width="20%" class="tblFormLabel1">Picture1</td>
                        <td width="20%" class="tblFormLabel1">Picture2</td>
                        <td width="20%" class="tblFormLabel1">Picture3</td>
                        <td width="20%" class="tblFormLabel1">Picture4</td>
                        <td width="20%" colspan="2" class="tblFormLabel1">Picture5</td>
                        <td width="2%"></td>
                    </tr>--%>
                    
                    <tr>
                    <td>&nbsp;</td>
                                 <%--<td class="auto-style1" align="left">
                                                 <asp:FileUpload ID="Picture11" runat="server" />
                                            &nbsp; &nbsp;&nbsp;
                                            <asp:Label ID="lblUpMessage1" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>                                                
                                            <asp:RegularExpressionValidator ID="FileUploadValidator1" runat="server" 
                                                ControlToValidate="Picture11" Enabled="true" ValidationGroup="VgCheck" 
                                                ErrorMessage="<br/>Only jpg, gif or PNG type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                 <br />
                                                 <asp:Image ID="ImgPhotoGraph1" CssClass="ImgTestimonialCss" runat="server" />
                                </td>
                       
                                 <td class="auto-style2" align="left">
                                                 <asp:FileUpload ID="Picture12" runat="server" />
                                            &nbsp; &nbsp;&nbsp;
                                            <asp:Label ID="lblUpMessage2" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>                                                
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                ControlToValidate="Picture12" Enabled="true" ValidationGroup="VgCheck" 
                                                ErrorMessage="<br/>Only jpg, gif or PNG type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                 <br />
                                                 <asp:Image ID="ImgPhotoGraph2" CssClass="ImgTestimonialCss" runat="server" />
                                 </td>

                                 <td class="tblFormText1" align="left">
                                                 <asp:FileUpload ID="Picture13" runat="server" />
                                            &nbsp; &nbsp;&nbsp;
                                            <asp:Label ID="lblUpMessage3" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>                                                
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                ControlToValidate="Picture13" Enabled="true" ValidationGroup="VgCheck" 
                                                ErrorMessage="<br/>Only jpg, gif or PNG type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                 <br />
                                                 <asp:Image ID="ImgPhotoGraph3" CssClass="ImgTestimonialCss" runat="server" />
                                 </td>
                       
                                 <td class="tblFormText1" align="left">
                                                 <asp:FileUpload ID="Picture14" runat="server" />
                                            &nbsp; &nbsp;&nbsp;
                                            <asp:Label ID="lblUpMessage4" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>                                                
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                ControlToValidate="Picture14" Enabled="true" ValidationGroup="VgCheck" 
                                                ErrorMessage="<br/>Only jpg, gif or PNG type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                 <br />
                                                 <asp:Image ID="ImgPhotoGraph4" CssClass="ImgTestimonialCss" runat="server" />
                                 </td>
                       
                                 <td class="tblFormText1" align="left">
                                                 <asp:FileUpload ID="Picture15" runat="server" />
                                            &nbsp; &nbsp;&nbsp;
                                            <asp:Label ID="lblUpMessage5" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>                                                
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                ControlToValidate="Picture15" Enabled="true" ValidationGroup="VgCheck" 
                                                ErrorMessage="<br/>Only jpg, gif or PNG type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                 <br />
                                                 <asp:Image ID="ImgPhotoGraph5" CssClass="ImgTestimonialCss" runat="server" />
                                 </td>                       --%>
                        <td>&nbsp;</td>
                    </tr>
                    
                    <%--<tr>
                    <td>&nbsp;</td>
                        <td align="left">Link EBook Code1:&nbsp;
                               <asp:TextBox runat="server" ID="txtCode1"></asp:TextBox></td>
                        <td>Link EBook Code2:&nbsp;
                             <asp:TextBox runat="server" ID="txtCode2"></asp:TextBox></td>
                        <td>Link EBook Code3:&nbsp;
                            <asp:TextBox runat="server" ID="txtCode3"></asp:TextBox></td>
                        <td>Link EBook Code4:&nbsp;
                              <asp:TextBox runat="server" ID="txtCode4"></asp:TextBox></td>
                        <td colspan="2">Link EBook Code5:&nbsp;
                                             <asp:TextBox runat="server" ID="txtCode5"></asp:TextBox></td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left" class="tblFormText1">
                               &nbsp;</td>
                        <td colspan="5" class="tblFormText1" align="left">
                             &nbsp;</td>
                       
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left" class="tblFormLabel1">
                               Select Template Design : 
                                </td>
                        <td colspan="5" class="tblFormText1" align="left">
                             Select only of the temlate design as shown below</td>
                       
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
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
                        <td colspan="2">
                                             &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left">
                               <asp:RadioButton ID="rdoEbD2template_Black" Text="WebDesign4 Black" 
                                   runat="server" ValidationGroup="VgCheck" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/ebImages/Design11_Black.jpg" 
                                style="width: 200px; height: 160px" />
                                </td>
                        <td>
                             <asp:RadioButton ID="rdoEbD2template_Blue" Text="WebDesign4 Blue" 
                                 runat="server" ValidationGroup="VgCheck" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/ebImages/Design11_Blue.jpg" 
                                style="width: 200px; height: 160px" />
                                </td>
                        <td>
                            <asp:RadioButton ID="rdoEbD2template_Green" Text="WebDesign4 Green" 
                                runat="server" ValidationGroup="VgCheck" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/ebImages/Design11_Green.jpg" 
                                style="width: 200px; height: 160px" />
                                
                                </td>
                        <td>
                              <asp:RadioButton ID="rdoEbD2template_Orange" ValidationGroup="VgCheck" Text="WebDesign4 Orange" 
                                  runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/ebImages/Design11_Orange.jpg" 
                                style="width: 200px; height: 160px" />
                            
                            </td>
                        <td colspan="2">
                                             <asp:RadioButton ID="rdoEbD2template_Red" ValidationGroup="VgCheck" Text="WebDesign4 Red" 
                                                 runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/ebImages/Design11_Red.jpg" 
                                style="width: 200px; height: 160px" />
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
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>

   
                                     
                    <tr>
                    <td>&nbsp;</td>
                         <td>
                            &nbsp;</td>
                        <td align="left" colspan="2">
                            <asp:Button ID="BtnSave" runat="server" Text="Save Web Design Settings" CssClass="stdbuttonCRUD" ValidationGroup="VgCheck"
                                onclick="BtnSave_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="BtnCancel" runat="server" Text="Cancel"  CssClass="stdbuttonCRUD" OnClick="BtnCancel_Click" />
                        </td>
                       
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
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
                        <td align="left" class="FontNote" colspan="2">
                        
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

