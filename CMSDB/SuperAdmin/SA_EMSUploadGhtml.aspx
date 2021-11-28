<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_EMSUploadGhtml.aspx.cs" Inherits="SuperAdmin_SA_EMSUploadGhtml" %>


<%@ Register src="SA_SideMenu_EMS.ascx" tagname="SA_SideMenu_EMS" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            font-variant: normal;
            color: #4E5163;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
            text-align: right;
            border-bottom: 1pt solid #D4DFAA;
            padding-right: 20px;
            background-color: #E2E6DC;
        }
        .style3
        {
            font-size: 12px;
            color: #4E5163;
            border-left: 1pt solid #D4DFAA;
            border-bottom: 1pt solid #D4DFAA;
            padding-left: 20px;
            background-color: #EEEFEB;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    
    <uc1:SA_SideMenu_EMS ID="SA_SideMenu_EMS1" runat="server" />
    
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
    <table cellpadding="0" cellspacing="0" border="0" width="99%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="ltrAllUsersListing" runat="server" 
                                Text="Gemail Html Upload"></asp:Literal></td>
                            <td width="30%" align="right">&nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td></tr></table></td></tr><tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="1%">&nbsp;</td>
                        <td width="98%">&nbsp;</td>
                        <td width="1%">&nbsp;</td>
                    </tr>
                    
                    
                     <%--<tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                    
                    <%--<tr>
                        <td>&nbsp;</td>
                        <td>
                        
                        <table id="Table1" align="center" cellpadding="0" cellspacing="2" class="stdtableBorder_Search">
                                <tr>
                                    <td style="width:10px;">&nbsp;</td>
                                    <td style="width:120px;" class="SearchLabelBold">Select Columns<br />
                                        &nbsp;to Hide</td>
                                    <td style="width:5px;"> &nbsp;</td>
                                    <td style="width:650px;" align="left"> 
                                        <asp:CheckBoxList ID="cklist_HideColumns" runat="server" CellPadding="2" 
                                            CellSpacing="2" RepeatColumns="5" RepeatDirection="Horizontal">
                                       
                                            <asp:ListItem>CompanyName</asp:ListItem>
                                            <asp:ListItem Value="FullName">Name</asp:ListItem>
                                            <asp:ListItem>Email</asp:ListItem>
                                            <asp:ListItem Value="HandPhone">MobileNo</asp:ListItem>
                                            <asp:ListItem>RegisteredDate</asp:ListItem>
                                            <asp:ListItem>ExpiryDate</asp:ListItem>
                                            <asp:ListItem Value="PurchasedBy">Debtor Mobile</asp:ListItem>
                                            <asp:ListItem Value="PurchaserTo">Purchaser Mobile</asp:ListItem>
                                            <asp:ListItem Value="isActive">Activated</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                    <td align="left">
                                    <asp:Button ID="btnHideColumns" CssClass="stdbuttonAction" 
                                            ValidationGroup="VgCheck" runat="server" Text="Search" 
                                            onclick="btnSearch_Click" />
                                    &nbsp; 
                                        </td>
                                    <td style="width:5px;"> &nbsp;</td>
                                    <td style="width:20px;"> </td>
                                </tr>
                                
                            </table>
                        
                        
                        
                        </td>
                        <td>&nbsp;</td>
                    </tr>--%>
                    
                    <tr>
                        <td>
                            &nbsp;</td><td>
                        
                            <table cellpadding="0" cellspacing="3" id="tblPlan" width="98%" runat="server">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%">&nbsp;
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <div id="dvButtonNo" class="LogoBoxheadBlue">
                            &nbsp;<br /> &nbsp;&nbsp; &nbsp;
                            <asp:Label ID="lblButtonNoHeader" runat="server" CssClass="FontSubHeader"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                  
                            
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                             
                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                         
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <table class="style1" id="tblButtonInfo">
                                <tr>
                                    <td width="25%" class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td width="75%" class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        For User MobileNumber :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:Label ID="lblMobileNo" runat="server" CssClass="SearchLabelBold" 
                                            Text='<%# Bind("AnchorDomain") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Full Name :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:Label ID="lblFullName" runat="server" CssClass="SearchLabelBold" 
                                            Text='<%# Bind("ButtonNo") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Upload Html File :</td>
                                    <td class="tblFormText1">
                                    <asp:FileUpload ID="FU_HtmlFile" runat="server" CssClass="stdUploadField" 
                          Width="410px" />
                          <asp:Label ID="lblUpMessage" runat="server" CssClass="FontNote"></asp:Label>
                           <asp:RegularExpressionValidator ID="FileUploadValidator" runat="server" 
                            ControlToValidate="FU_HtmlFile" Enabled="true" ValidationGroup="vgCheck" 
                            ErrorMessage="<br/>Only Html files are allowed.  Please select another file." 
                            
                          ValidationExpression=".*(\.[Hh][Tt][Mm][Ll]|\.[Hh][Tt][Mm])" 
                          Display="Dynamic"></asp:RegularExpressionValidator>
                          
                           &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                          ControlToValidate="FU_HtmlFile" CssClass="font_11Msg_Error" Display="Dynamic" 
                          ErrorMessage="* Please select a HTML file to upload." ValidationGroup="vgCheck"></asp:RequiredFieldValidator>
                          
                                        </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        </td>
                                    <td class="style3">
                                        </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        <asp:Button ID="btnUploadHTML" runat="server" CssClass="stdbuttonCRUD" 
                          Text="Upload HTML"  ValidationGroup="vgCheck" onclick="btnUploadHTML_Click" /></td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        &nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                </table>
                            
                            </td><td>
                            &nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td align="left">
                           <%-- <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        </td>
                        <td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
                &nbsp;</td></tr></table>
     
</form>
 
 </asp:Content>