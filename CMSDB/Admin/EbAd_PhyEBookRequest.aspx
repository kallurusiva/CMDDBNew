<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_PhyEBookRequest.aspx.cs" Inherits="EbAd_PhyEBookRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<%@ Register src="LeftMenu_WebSettings.ascx" tagname="LeftMenu_WebSettings" tagprefix="uc1" %>



<%@ Register src="EBLeftMenu_RegSTEPS.ascx" tagname="EBLeftMenu_RegSTEPS" tagprefix="uc2" %>



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
        .auto-style1 {
            text-align: left;
        }
        </style>
    <script language="javascript" type="text/javascript">

        function fnDeleteImage(imgID) {
            //alert(imgID);
            location.href = 'Ad_LogoSettings.aspx?ImgToDelete=' + imgID;
        
        }
    
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_RegSTEPS ID="EBLeftMenu_RegSTEPS1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <form id="MyHomePageForm" runat="server" enctype="multipart/form-data">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss"  id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
            <td>
                
                <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubHeader">
                  <tr>
                        
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; Physical EBook Request&nbsp;
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
                                <tr>
                                 <td width="23%">&nbsp;</td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="75%">&nbsp;</td>
                                </tr>
                       
                             <%--     <tr>
                                 <td colspan="3">
                                 
                           <asp:Panel ID="PanelLogoHead" runat="server">
                                     <div id="dvLogoPanelHead" class="PanelCss" >
                                            <table width="100%">
                                                <tr>
                                                    <td align="left"><font class="PanelCss_Head">
                                                 <asp:Literal ID="Literal3" runat="server" Text="Select Logo Template"></asp:Literal>
                                                  </font>
                                                        
                                                    </td>
                                                    <td align="right" width="450px">
                                                    <asp:Label runat="server" ID="lblLogo" />&nbsp; 
                                                        <asp:Image ID="ImgLogoEc" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                     </asp:Panel>
                                 </td>
                                </tr>--%>
                                
                               
                                <tr>
                                <td colspan="3">
                                <div id="dvWelcomeHeader" style="overflow:hidden; width:960px; min-height: 150px;"  class="ebSummaryBox">
        
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                    <tr>
                       
                                        <td colspan="3">
                                        <div class="SummaryBoxheadOren">
                                                    <div class="sideBoxheadText"> 
                                                    <asp:Literal ID="Literal3" Text="STEP 1:  Choose Book Templates " runat="server"></asp:Literal> </div>
                                                </div>
                                                </td>
                                    </tr>
                    
                                    <tr style="vertical-align:baseline;">
                                    <td colspan="3" align="center">
            
                  
                  
                                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                                            <tr>
                                                <td width="250px" >&nbsp;</td>
                                                <td >  &nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td class="ebFormLabel1"><strong>Book No. 1</strong></td>
                                                <td class="ebFormText1">  &nbsp;   
                                                    <asp:Label ID="lblBookName1" CssClass="AdminFont" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>

                             
                        
                                             <tr>
                                                
                                                <td colspan="2" >  &nbsp;
                                    
                                                     <asp:RadioButtonList ID="rdoEbookTemplates1" runat="server" CellPadding="5" 
                                                         CellSpacing="10" RepeatColumns="5" RepeatDirection="Horizontal">
                                                     </asp:RadioButtonList>
                                                </td>
                                            </tr>
                        
                                             <tr>
                                                <td>&nbsp;</td>
                                                <td >  
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="VgCheck" ControlToValidate="rdoEbookTemplates1" runat="server" ErrorMessage="Please Select your Template for Book 1"></asp:RequiredFieldValidator>
                                                 </td>
                                            </tr>
                        
                                             <tr>
                                                <td class="ebFormLabel1"><strong>Book No. 2</strong></td>
                                                <td class="ebFormText1">  
                                 
                                 
                                                    <asp:Label ID="lblBookName2" CssClass="AdminFont" runat="server" Text=""></asp:Label>
                                 
                                 
                                                 </td>
                                            </tr>
                        
                                             <tr>
                                                
                                                <td colspan="2">  
                                    
                                                     <asp:RadioButtonList ID="rdoEbookTemplates2" runat="server" CellPadding="5" 
                                                         CellSpacing="10" RepeatColumns="5" RepeatDirection="Horizontal">
                                                     </asp:RadioButtonList>
                                                 </td>
                                            </tr>
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td >  
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="VgCheck" ControlToValidate="rdoEbookTemplates2" runat="server" ErrorMessage="Please Select your Template for Book 2"></asp:RequiredFieldValidator></td>
                                            </tr>
                        
                                             </table>
                        
                        
                    
                                    </td>
                                    </tr>
                    
                                        
                                      </table>
         
                                    </div>
                               
                                </td>
                                </tr>
                                                              
                 
                                <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                                </tr>
                                  
                                
                                   <tr>
                                <td colspan="3">
                                <div id="dvWelcomeHeader" style="overflow:hidden; width:960px; min-height: 150px;"  class="ebSummaryBox">
        
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                    <tr>
                       
                                        <td colspan="3">
                                        <div class="SummaryBoxheadOren">
                                                    <div class="sideBoxheadText"> 
                                                    <asp:Literal ID="Literal4" Text="STEP 2:  Choose Business Card Template" runat="server"></asp:Literal> </div>
                                                </div>
                                                </td>
                                    </tr>
                    
                                    <tr style="vertical-align:baseline;">
                                    <td colspan="3" align="center">
            
                  
                  
                                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                                            <tr>
                                                <td width="250px" >&nbsp;</td>
                                                <td >  &nbsp;</td>
                                            </tr>

                             
                        
                                             <tr>
                                                
                                                <td colspan="2" >  &nbsp;
                                    
                                                     <asp:RadioButtonList ID="rdoBizCards" runat="server" CellPadding="5" 
                                                         CellSpacing="10" RepeatColumns="5" RepeatDirection="Horizontal">
                                                     </asp:RadioButtonList>
                                                </td>
                                            </tr>
                        
                                             <tr>
                                                <td>&nbsp;</td>
                                                <td >  
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="VgCheck" ControlToValidate="rdoBizCards" runat="server" ErrorMessage="Please Select your Template for Business Card"></asp:RequiredFieldValidator>
                                                 </td>
                                            </tr>
                        
                                             </table>
                        
                        
                    
                                    </td>
                                    </tr>
                    
                                        
                                      </table>
         
                                    </div>
                               
                                </td>
                                </tr>
                                                              
                 
                                <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                                </tr>
                                                            
                 
                                <tr>
                                <td colspan="3">
                                    <div id="dvSTEP2" style="overflow:hidden; width:960px; min-height: 150px;"  class="ebSummaryBox">
        
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                    <tr>
                       
                                        <td colspan="3">
                                        <div class="SummaryBoxheadOren">
                                                    <div class="sideBoxheadText"> 
                                                    <asp:Literal ID="Literal1" Text="STEP 3:  Provide Additional Information" runat="server"></asp:Literal> </div>
                                                </div>
                                                </td>
                                    </tr>
                    
                                    <tr style="vertical-align:baseline;">
                                    <td colspan="3" align="center">
            
                  
                  
                                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                                            <tr>
                                                <td width="30%" >&nbsp;</td>
                                                <td  width="70%" >  &nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td class="ebFormLabel1" style="padding-top: 10px; padding-bottom: 10px;"><strong>Name you would like to appear on
                                                    <br />
                                                    the printed Books : </strong></td>
                                                <td class="ebFormText1">  &nbsp;   
                                                    <asp:TextBox ID="txtNameOnPrintedBook" runat="server" CssClass="stdTextField2"></asp:TextBox>
                                                </td>
                                            </tr>

                             
                        
                                             <tr>
                                                <td colspan="2" >
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="VgCheck" ControlToValidate="txtNameOnPrintedBook" runat="server" ErrorMessage="Name on the BOOK Cannot be Empty."></asp:RequiredFieldValidator>
                                                 </td>
                                                    
                                            </tr>
                        
                                             <tr>
                                                <td colspan="2" align="left" class="fontINFO" >&nbsp; Please upload two (2) of your recent photos which you will like to appear on the printed books.<br />
&nbsp;
                                                     Please note that clearer the pictures you submit, the clearer is the output of the printed books. </td>
                                                    
                                            </tr>
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td >  &nbsp;</td>
                                            </tr>

                                             <tr>
                                                <td class="ebFormLabel1"><strong>Upload Photograph 1 : </strong></td>
                                                <td class="ebFormText1">  &nbsp;   
                                                 <asp:FileUpload ID="FU_Photo1" runat="server" />
                                            &nbsp; &nbsp;
                                            &nbsp;
                                            <asp:Label ID="lblUpMessage1" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>
                                                
                                            <asp:RegularExpressionValidator ID="FileUploadValidator1" runat="server" 
                                                ControlToValidate="FU_Photo1" Enabled="true" 
                                                ErrorMessage="<br/>Only jpg or gif type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                
                                                    <br />
                                                
                                             <asp:CustomValidator ID="CustomVdr_Photo1" runat="server" Display="Dynamic" ControlToValidate="FU_Photo1" ValidateEmptyText="true" ValidationGroup="VgCheck"
                                                                    ErrorMessage="Photo1 Image size should not be greater than 300KB." OnServerValidate="CustomVdr_Photo1_ServerValidate"></asp:CustomValidator>    
                                                
                                                </td>
                                            </tr>

                                             <tr>
                                                <td >&nbsp;</td>
                                                <td >  &nbsp;</td>
                                            </tr>

                                             <tr>
                                                <td class="ebFormLabel1"><strong>Upload Photograph 2 : </strong></td>
                                                <td class="ebFormText1">  &nbsp;   

                                                    <asp:FileUpload ID="FU_Photo2" runat="server" />
                                            &nbsp; &nbsp;
                                            &nbsp;
                                            <asp:Label ID="lblUpMessage2" runat="server" CssClass="font_12Msg_Success" 
                                                Text=""></asp:Label>
                                                
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  Display="Dynamic"
                                                ControlToValidate="FU_Photo2" Enabled="true" 
                                                ErrorMessage="<br/>Only jpg or gif type images are allowed.  Please select another image." 
                                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])"></asp:RegularExpressionValidator>
                                                
                                                    <br />
                                                
                                             <asp:CustomValidator ID="CustomVdr_Photo2"  Display="Dynamic" runat="server" ControlToValidate="FU_Photo2" ValidateEmptyText="true" ValidationGroup="VgCheck"
                                                                    ErrorMessage="Photo2 Image size should not be greater than 300KB." OnServerValidate="CustomVdr_Photo2_ServerValidate"></asp:CustomValidator>    
                                                    </td>
                                            </tr>

                                             <tr>
                                                <td >&nbsp;</td>
                                                <td >  &nbsp;</td>
                                            </tr>
                        
                                        </table>
                        
                        
                    
                                    </td>
                                    </tr>
                    
                                        
                                      </table>
         
                                    </div></td>
                                </tr>
                                                              
                 
                                <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                                </tr>
                                                              
                 
                                <tr>
                                <td colspan="3">
                                    <div id="dvSTEP3" style="overflow:hidden; width:960px; min-height: 150px;"  class="ebSummaryBox">
        
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                    <tr>
                       
                                        <td colspan="3">
                                        <div class="SummaryBoxheadOren">
                                                    <div class="sideBoxheadText"> 
                                                    <asp:Literal ID="Literal2" Text="STEP 4:  Shipping / Delivery Address " runat="server"></asp:Literal> </div>
                                                </div>
                                                </td>
                                    </tr>
                    
                                    <tr style="vertical-align:baseline;">
                                    <td colspan="3" align="center">
            
                  
                  
                                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                                            <tr>
                                                <td width="30%" align="left" >&nbsp;</td>
                                                <td width="70%" >  &nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td colspan="2" align="left" class="fontINFO" >&nbsp; Please provide the complete postal address where the printed Books can be delivered to you.</td>
                                                
                                            </tr>

                                            <tr>
                                                
                                                <td colspan="2">  
                                                    &nbsp;</td>
                                            </tr>

                             
                        
                                            <tr>
                                                
                                                <td colspan="2">  
                                                    <asp:Label ID="Label1" CssClass="ValAlert_Error" runat="server" Text="NOTE: Temporarily all collect from HQ after 5 working days. Except Saturday, Sundays or Public Holidays."></asp:Label>
&nbsp;</td>
                                            </tr>

                             
                        
                                            <tr>
                                                <td class="ebFormLabel1"><strong>Mode of Delivery : </strong></td>
                                                <td class="ebFormText1" align="left">  &nbsp;   
                                                    <asp:RadioButtonList ID="rdoDeliveryMode" runat="server" CellPadding="2" CellSpacing="2">
                                                        <asp:ListItem Value="1">I will collect it from HQ</asp:ListItem>
                                                       <%-- <asp:ListItem Value="2">Deliver it to  AAM</asp:ListItem>
                                                        <asp:ListItem Value="3">Delilver to my Postal Address as Mentioned Below</asp:ListItem>  --%>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>

                             
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td >  &nbsp;
                                    
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="VgCheck" ControlToValidate="rdoDeliveryMode" runat="server" ErrorMessage="Please select the Mode of Delivery"></asp:RequiredFieldValidator>
                                    
                                                     </td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td >  &nbsp;</td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td ><strong>Street Address Line 1 </strong></td>
                                                <td class="auto-style1" >  
                                                    <asp:TextBox ID="txtAddress1" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                                 </td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td class="auto-style1" >  &nbsp;</td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td ><strong>Street Address Line 2</strong></td>
                                                <td class="auto-style1" >    
                                                    <asp:TextBox ID="txtAddress2" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                                 </td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td class="auto-style1" >  &nbsp;</td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td ><strong>City </strong></td>
                                                <td class="auto-style1" >    
                                                    <asp:TextBox ID="txtCity" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                                 </td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td class="auto-style1" >  &nbsp;</td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td ><strong>State </strong></td>
                                                <td class="auto-style1" >    
                                                    <asp:TextBox ID="txtState" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                                 </td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td class="auto-style1" >  &nbsp;</td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td ><strong>Postal / Zip Code </strong></td>
                                                <td class="auto-style1" >    
                                                    <asp:TextBox ID="txtPostcode" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                                 </td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td class="auto-style1" >  &nbsp;</td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td ><strong>Country </strong></td>
                                                <td class="auto-style1" >    
                                                    <asp:TextBox ID="txtCountry" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                                 </td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td class="auto-style1" >    
                                                    &nbsp;</td>
                                            </tr>
                        
                                        </table>
                        
                        
                    
                                    </td>
                                    </tr>
                    
                                        
                                      </table>
         
                                    </div></td>
                                </tr>
                                                              
                 
                                <tr>
                                <td colspan="3">
                                    
                                     <asp:ValidationSummary ID="ValidationSummary2" runat="server" BorderColor="Red" BorderStyle="Dotted" CssClass="ValAlert_Error" HeaderText="The Following errors occured while submitting the Physical Book Request." ShowMessageBox="True" ValidationGroup="VgCheck" />
                                    </td>
                                </tr>
                                                              
                 
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                 
                                     <asp:Button ID="btnSaveRequest" CssClass="stdbuttonCRUD" ValidationGroup="VgCheck" runat="server" Text="Submit Physical Book Request" OnClick="btnSaveRequest_Click" />
                                    </td>
                                </tr>
                                
                       
                               
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                 
                                     &nbsp;</td>
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
                &nbsp;</td></tr></table></form>
                
                
</asp:Content>

