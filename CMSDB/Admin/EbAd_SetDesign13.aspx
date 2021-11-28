<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_SetDesign13.aspx.cs" Inherits="Admin_EbAd_SetDesign13" %>

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
            height: 15px;
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
                    
                    
                
                    

                      
                    <tr>
                        <td colspan="7" class="styleRow" align="left">
                         Ebook Templates Design 2 : Set up your Template with your Photograph, FaceBookPageURL and Welcome Text.
                        </td>
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
                        <td>
                                             &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left">
                               &nbsp;</td>
                        <td colspan="4" align="left" class="FontNote2">
                             Image Size Limit:&nbsp; 150pixels (height) x 200pixels (width).&nbsp; 
                             Only Jpeg, Gif or Png files are allowed.&nbsp; MAX size upto 1MB only.</td>
                       
                       
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left" class="tblFormLabel1">
                               Select Photograph : 
                                </td>
                        <td colspan="4" class="tblFormText1" align="left">
                                                 <asp:FileUpload ID="FU_Photo1" runat="server" />

                             &nbsp; &nbsp;
                                            &nbsp;
                                            <asp:Label ID="lblUpMessage1" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>
                                                
                                            <asp:RegularExpressionValidator ID="FileUploadValidator1" runat="server" 
                                                ControlToValidate="FU_Photo1" Enabled="true" ValidationGroup="VgCheck" 
                                                ErrorMessage="<br/>Only jpg, gif or PNG type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                
                                                    <br />
                                                
                                             <asp:CustomValidator ID="CustomVdr_Photo1" runat="server" Display="Dynamic" ControlToValidate="FU_Photo1" ValidateEmptyText="true" ValidationGroup="VgCheck"
                                                                    ErrorMessage="Photo1 Image size should not be greater than 1 MB." OnServerValidate="CustomVdr_Photo1_ServerValidate"></asp:CustomValidator>    

                                                 <br />
                                                 <asp:Image ID="ImgPhotoGraph1" CssClass="ImgTestimonialCss" runat="server" />

                                            </td>
                        
                       
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td class="auto-style1"></td>
                        <td align="left" class="auto-style1">
                               </td>
                        <td class="FontNote2" align="left" colspan="4">
                             The FacebookPage URL must be from a FaceBook Page, 
                             Not a FaceBook Account. Please refer to the video tutorial in INFO button if you need help.</td>
                        
                        
                        <td class="auto-style1">
                            </td>
                    </tr>
                    
                    
                    <tr style="height:45px;">
                    <td>&nbsp;</td>
                        <td align="left" class="tblFormLabel1">
                               Enter Facebook Page URL : </td>
                        <td colspan="4" align="left" class="tblFormText1">
                             <a href="https://www.facebook.com/">https://www.facebook.com/</a> <asp:TextBox ID="txtFBpageURL" CssClass="stdTextField1" ValidationGroup="VgCheck" Width="240px" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="VgCheck" runat="server" ControlToValidate="txtFBpageURL" ErrorMessage="Please enter FaceBook Page URL"></asp:RequiredFieldValidator>
                             .
                        </td>
                        
                       
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left">
                               &nbsp;</td>
                        <td colspan="4" align="left" class="FontNote2">
                           Please enter a breif description about your Website, details of your business or activities.  This description would be shown on the home page.</td>
                        
                        
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left" class="tblFormLabel1">
                               Enter Welcome Page Text : </td>
                        <td colspan="4" class="tblFormText1" align="left">
                             <asp:TextBox ID="txtWelcomePage" CssClass="stdTextArea1" Width="540px" ValidationGroup="VgCheck" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        &nbsp;
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="VgCheck" runat="server" ControlToValidate="txtWelcomePage" ErrorMessage="Please enter Welcome Page Text"></asp:RequiredFieldValidator>
                        </td>
                        
                     
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
                        <td>
                                             &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left" class="tblFormLabel1">
                               Select Template Design : 
                                </td>
                        <td colspan="4" class="tblFormText1" align="left">
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
                        <td>
                                             &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                        <td align="left">
                               <asp:RadioButton ID="rdoEbD2template_Black" Text="WebDesign2 Black" 
                                   runat="server" ValidationGroup="VgCheck" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/ebImages/Design13_Black.jpg" 
                                style="width: 200px; height: 160px" />
                                </td>
                        <td>
                             <asp:RadioButton ID="rdoEbD2template_Blue" Text="WebDesign2 Blue" 
                                 runat="server" ValidationGroup="VgCheck" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/ebImages/Design13_Blue.jpg" 
                                style="width: 200px; height: 160px" />
                                </td>
                        <td>
                            <asp:RadioButton ID="rdoEbD2template_Green" Text="WebDesign2 Green" 
                                runat="server" ValidationGroup="VgCheck" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/ebImages/Design13_Green.jpg" 
                                style="width: 200px; height: 160px" />
                                
                                </td>
                        <td>
                              <asp:RadioButton ID="rdoEbD2template_Orange" ValidationGroup="VgCheck" Text="WebDesign2  Orange" 
                                  runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/ebImages/Design13_Orange.jpg" 
                                style="width: 200px; height: 160px" />
                            
                            </td>
                        <td>
                                             <asp:RadioButton ID="rdoEbD2template_Red" ValidationGroup="VgCheck" Text="WebDesign2 Red" 
                                                 runat="server" GroupName="GrpTemplate" />
                            <br />
                            <img alt="webtmp2" src="../Images/ebImages/Design13_Red.jpg" 
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
                        <td>
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

