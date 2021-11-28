<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_PhyEBookRequest_Confirm.aspx.cs" Inherits="EbAd_PhyEBookRequest_Confirm" %>

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
                            - Confirmation</td>
                     
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

                             <table id="tblSubmitBook" class="stdtableBorder_MainBold" visible="false" runat="server" border="0" cellpadding="0" cellspacing="2" width="100%">
                                <tr>
                                 <td width="5%">&nbsp;</td>
                                 <td width="90%">&nbsp;</td>
                                 <td width="5%">&nbsp;</td>
                                </tr>
                                  <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                                </tr>


                                  <tr>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;<asp:Label ID="lblConfirm" CssClass="font_12Msg_Success" runat="server" Text="Thank you for your Submission."></asp:Label></td>
                                        <td> &nbsp;</td>
                                </tr>


                                  <tr>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                </tr>


                                  <tr>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;</td>
                                </tr>

                                  <td colspan="3">
                                    &nbsp;</td>
                                </tr>

                                 <tr>
                                        <td> &nbsp;</td>
                                        <td> &nbsp;<asp:Label ID="Label1" CssClass="ValAlert_Error" runat="server" Text="The Printed Books shall be delivered to your Delivery Address between 2-4 Weeks."></asp:Label></td>
                                        <td> &nbsp;</td>
                                </tr>


                                 </table>

                            <table id="tblPhyBookDetails" runat="server" border="0" cellpadding="0" cellspacing="2" width="100%">
                                <tr>
                                 <td width="23%">&nbsp;</td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="75%">&nbsp;</td>
                                </tr>


                                  <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                                </tr>
                                       

                                <tr>
                                <td colspan="3">
                                <div id="dvUserDetails" style="overflow:hidden; width:960px; min-height: 150px;"  class="ebSummaryBox">
        
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                    <tr>
                       
                                        <td colspan="3">
                                        <div class="SummaryBoxheadOren">
                                                    <div class="sideBoxheadText"> 
                                                    <asp:Literal ID="Literal4" Text="Account Details" runat="server"></asp:Literal> </div>
                                                </div>
                                                </td>
                                    </tr>
                    
                                    <tr style="vertical-align:baseline;">
                                    <td colspan="3" align="center">
            
                  
                  
                                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                                            <tr>
                                                <td width="50%" >&nbsp;</td>
                                                <td width="50%" >  &nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td class="ebFormLabel1"><strong>Vendor Name</strong></td>
                                                <td class="ebFormText1">  
                                                    <asp:Label ID="lblVendorName" runat="server"></asp:Label>
                                                </td>
                                            </tr>

                             
                        
                                             <tr>
                                                <td class="ebFormLabel1">   
                                                    <strong>Mobile No.</strong></td>
                                                <td class="ebFormText1">  
                                 
                                 
                                                    <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                 
                                 
                                                 </td>
                                            </tr>
                        
                                             <tr>
                                                <td class="ebFormLabel1"><strong>Account Status</strong></td>
                                                <td  class="ebFormText1">  
                                 
                                 
                                                    <asp:Label ID="lblAccountStatus" runat="server"></asp:Label>
                                                 </td>
                                            </tr>
                        
                                             <tr>
                                                <td class="ebFormLabel1"><strong>eBook Website</strong></td>
                                                <td  class="ebFormText1">  
                                 
                                 
                                                    <asp:Label ID="lblWebsiteName" runat="server"></asp:Label>
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
                                <div id="dvWelcomeHeader" style="overflow:hidden; width:960px; min-height: 150px;"  class="ebSummaryBox">
        
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                    <tr>
                       
                                        <td colspan="3">
                                        <div class="SummaryBoxheadOren">
                                                    <div class="sideBoxheadText"> 
                                                    <asp:Literal ID="Literal3" Text="Physical Books Chosen" runat="server"></asp:Literal> </div>
                                                </div>
                                                </td>
                                    </tr>
                    
                                    <tr style="vertical-align:baseline;">
                                    <td colspan="3" align="center">
            
                  
                  
                                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                                            <tr>
                                                <td width="35%" >&nbsp;</td>
                                                <td width="35%" >  &nbsp;</td>
                                                <td width="30%" >  &nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td class="ebFormLabel1"><strong>Book No. 1</strong></td>
                                                <td class="ebFormText1">  <strong>Book No. 2</strong></td>
                                                <td class="ebFormText1">  <strong>Business Card </strong></td>
                                            </tr>

                             
                        
                                             <tr>
                                                
                                                <td colspan="2" >  &nbsp;
                                    
                                                     </td>
                                                
                                                <td >  &nbsp;</td>
                                            </tr>
                        
                                             <tr>
                                                <td class="ebFormLabel1">   
                                                    <asp:Label ID="lblBookName1" CssClass="AdminFont" runat="server" Text=""></asp:Label>
                                                 </td>
                                                <td class="ebFormText1">  
                                 
                                 
                                                    <asp:Label ID="lblBookName2" CssClass="AdminFont" runat="server" Text=""></asp:Label>
                                 
                                 
                                                 </td>
                                                <td class="ebFormText1">  
                                 
                                 
                                                    <asp:Label ID="lblBizCardName" CssClass="AdminFont" runat="server"></asp:Label>
                                 
                                 
                                                 </td>
                                            </tr>
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td >  
                                 
                                 
                                                    &nbsp;</td>
                                                <td >  
                                 
                                 
                                                    &nbsp;</td>
                                            </tr>
                        
                                             <tr>
                                                
                                                <td colspan="2">  
                                    
                                                     &nbsp;</td>
                                                
                                                <td>  
                                    
                                                     &nbsp;</td>
                                            </tr>
                        
                                             <tr>
                                                <td>
                                                    <asp:Image ID="ImgPhyBook1" CssClass="ebTempImgCss_Confirm" runat="server" ImageUrl="~/Images/ebImages/3851.jpg" />
                                                 </td>
                                                <td>  
                                 
                                 
                                                    <asp:Image ID="ImgPhyBook2" CssClass="ebTempImgCss_Confirm" runat="server" ImageUrl="~/Images/ebImages/3921.jpg" />
                                                 </td>
                                                <td>  
                                 
                                 
                                                    <asp:Image ID="ImgBizCard" CssClass="ebTempImgCss_Confirm" runat="server" ImageUrl="~/Images/ebImages/3921.jpg" />
                                                 </td>
                                            </tr>
                        
                                             <tr>
                                                
                                                <td colspan="2">  
                                    
                                                     &nbsp;</td>
                                                
                                                <td>  
                                    
                                                     &nbsp;</td>
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
                                                    <asp:Literal ID="Literal1" Text="Cover Page Information" runat="server"></asp:Literal> </div>
                                                </div>
                                                </td>
                                    </tr>
                    
                                    <tr style="vertical-align:baseline;">
                                    <td colspan="3" align="center">
            
                  
                  
                                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                                            <tr>
                                                <td width="50%" >&nbsp;</td>
                                                <td width="50%" >  &nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td class="ebFormLabel1" style="padding-top: 10px; padding-bottom: 10px;"><strong>Name to appear on
                                                    the printed Books : </strong></td>
                                                <td class="ebFormText1">  
                                                    <asp:Label ID="lblNameOnBook" runat="server"></asp:Label>
                                                    </td>
                                            </tr>

                             
                        
                                             <tr>
                                                <td colspan="2" align="left" class="fontINFO" ><strong>Uploaded Photographs :-&nbsp; </strong></td>
                                                    
                                            </tr>
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td >  &nbsp;</td>
                                            </tr>

                                             <tr>
                                                <td >
                                                    <asp:Image ID="ImgPhoto1" CssClass="ebTempImgCss_Confirm" runat="server" />
                                                 </td>
                                                <td >  
                                                    <asp:Image ID="ImgPhoto2" CssClass="ebTempImgCss_Confirm" runat="server" />
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
                                                    <asp:Literal ID="Literal2" Text="Shipping / Delivery Address " runat="server"></asp:Literal> </div>
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
                                                <td colspan="2" align="left" class="fontINFO" >Printed Books would be delivered to you at</td>
                                                
                                            </tr>

                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>  &nbsp;</td>
                                            </tr>

                             
                        
                                            <tr>
                                                <td class="ebFormLabel1"><strong>Mode of Delivery : </strong></td>
                                                <td class="ebFormText1" align="left">  &nbsp;   
                                                    <asp:Label ID="lblDeliveryMode" runat="server"></asp:Label>
                                                    </td>
                                            </tr>

                             
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td >  &nbsp;
                                    
                                                     </td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td ><strong>Postal Address</strong></td>
                                                <td class="auto-style1" >  
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblPostalAddress" runat="server"></asp:Label>
                                                 </td>
                                            </tr>
                        
                                           
                        
                                             <tr>
                                                <td >&nbsp;</td>
                                                <td class="auto-style1" >  &nbsp;</td>
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
                                    
                                     &nbsp;</td>
                                </tr>
                                                              
                 
                                <tr>
                                <td colspan="3" class="ValAlert_Error">
                                    
                                     NOTE :&nbsp; Ensure Delivery address is correct otherwise resending and re-printing of books as a result would incur additional cost of USD 50.</td>
                                </tr>
                                                              
                 
                                <tr>
                                <td colspan="3">
                                    
                                     &nbsp;</td>
                                </tr>
                                                              
                 
                                <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td align="left">
                                 
                                     <asp:Button ID="BtnConfirmRequest" CssClass="stdbuttonCRUD" ValidationGroup="VgCheck" runat="server" Text="Confirm Physical Book Request" OnClick="btnSaveRequest_Click" />
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

