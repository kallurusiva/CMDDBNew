<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_TestimonialEdit.aspx.cs" Inherits="SuperAdmin_SA_TestimonialEdit" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="SA_SideMenu_Testimonial.ascx" tagname="SA_SideMenu_Testimonial" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:SA_SideMenu_Testimonial ID="SA_SideMenu_Testimonial1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script language="javascript" type="text/javascript">

    function fnFileUploaded() {
    
    
    }

    function fnFileUploadErr() {
    
    
    }

</script>


    <form id="tForm" runat="server">
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
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="96%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Label ID="lblEditTestimonial" runat="server" Text="Edit Testimonial"></asp:Label>
                            </td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="96%">
                    <tr>
                        <td width="5%">
                            &nbsp;</td>
                        <td width="20%">
                            &nbsp;</td>
                        <td width="5%">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="5%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                               <asp:Literal ID="ltrEvents0" runat="server" Text="Enter Testimonial"></asp:Literal>
                        </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtTestimonial" CssClass="stdTextArea2" runat="server" 
                                ToolTip="Enter a Testimonial"  ValidationGroup="vgCheck" 
                                TextMode="MultiLine"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="vgCheck" ControlToValidate="txtTestimonial" Display="Dynamic" SetFocusOnError="true"
                              runat="server" ErrorMessage="Enter Testimonial content"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            <asp:Label ID="lblEnteredBy" runat="server" Text="Entered By" CssClass="FormLabel"></asp:Label>
                            </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                            <asp:Label ID="lblTstName" runat="server" Text="Name"></asp:Label> :</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtTstname" runat="server" ValidationGroup="vgCheck" CssClass="stdTextField2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="vgCheck" ControlToValidate="txtTstname" Display="Dynamic" SetFocusOnError="true"
                              runat="server" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                        <asp:Label ID="lblDesgination" runat="server" Text="Designation" ></asp:Label>
                             :</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtTstDesgination" runat="server" ValidationGroup="vgCheck" CssClass="stdTextField2"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="vgCheck" ControlToValidate="txtTstDesgination" Display="Dynamic" SetFocusOnError="true"
                              runat="server" ErrorMessage="Enter Designation"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td  align="right">
                        <asp:Label ID="lblCompany" runat="server" Text="Company" ></asp:Label>
                             :</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtTstCompany" ValidationGroup="vgCheck" runat="server" CssClass="stdTextField2"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="vgCheck" ControlToValidate="txtTstCompany" Display="Dynamic" SetFocusOnError="true"
                            runat="server" ErrorMessage="Enter Designation"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                        <asp:Label ID="LblCountry" runat="server" Text="Country" ></asp:Label>
                             :</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:DropDownList ID="DdlCountry" CssClass="stdDropDown2" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            Image</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:Image ID="ImgUser" runat="server" BorderColor="ActiveBorder" BorderStyle="Solid" BorderWidth="1px" CssClass="ImgTestimonialCss" /></td>
                            
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                        <asp:Label ID="LblUploadImage" runat="server" Text="Change Image" ></asp:Label>
                            </td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                        <asp:FileUpload ID="UploadImgCtrl" runat="server"  
                                ToolTip="Click Browse to button to select an image from your computer." />
                            &nbsp;
                        <asp:Button ID="btnUpload" CssClass="stdButtonNormal" runat="server" onclick="btnUpload_Click" 
                                Text="Upload Image" />
                                
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                         <asp:Label ID="lblUpMessage" runat="server" Text="" ValidationGroup="vgCheck2" CssClass="font_12Msg_Success"></asp:Label>
                            <asp:RegularExpressionValidator ID="FileUploadValidator"  runat="server" 
                                ControlToValidate="UploadImgCtrl" ErrorMessage="Only jpg or gif type images are allowed.  Please select another image." 
                                ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg])" Enabled="true"></asp:RegularExpressionValidator>
                           
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            Display at Website</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:CheckBox ID="chkActive" runat="server" />
                           
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                         <asp:Button ID="btnSave" runat="server" ValidationGroup="vgCheck" CssClass="stdbuttonAction" 
                                Text="Update" onclick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonAction" 
                                Text="Cancel" onclick="btnCancel_Click" />
                   
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td >
                            </td>
                        <td >
                            </td>
                        <td >
                            </td>
                        <td align="left" >
                            </td>
                        <td >
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                     &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
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
    </table>
</form>
</asp:Content>

