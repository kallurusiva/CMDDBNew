<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_EMSContentAdd.aspx.cs" Inherits="SA_EMSContentAdd" %>


<%@ Register src="SA_SideMenu_EMS.ascx" tagname="SA_SideMenu_EMS" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                            <asp:Literal ID="LtrAddNewButtonPage" runat="server" 
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
            <td>&nbsp;</td>
            </tr> 
            <tr><td>
                <asp:FormView ID="FvEMS" runat="server"
                 GridLines="Vertical" Width="100%" onmodechanging="FvEMS_ModeChanging" 
                    ondatabound="FvEMS_DataBound" oniteminserting="FvEMS_ItemInserting" onitemupdating="FvEMS_ItemUpdating" 
                >
               <ItemTemplate>
            
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
                            <asp:Button ID="BtnUpdate" runat="server" CommandName="Edit" 
                                CssClass="stdbuttonCRUD" Text=" EDIT " />
                             
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnBackToListing" runat="server" CssClass="stdbuttonCRUD" 
                                onclick="btnBackToListing_Click" Text="Back to Listing" />
                             
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
                                        <font class="font_12Msg_Success">User Details </font>:- </td>
                                    <td width="75%" class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%" align="right">
                                        Full Name :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Mobile Number :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        SubDomain :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtSubDomain" runat="server" 
                                            CssClass="stdTextField1_disabled" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        OwnDomain :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtOwnDomain" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
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
                                        <font class="font_12Msg_Success">Email Login details </font>:- </td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;Admin Login ID :</td>
                                    <td class="tblFormText1">
                                        <asp:Label ID="lblAdmLoginID" Text='<%# Eval("AdminID") %>' runat="server" 
                                            CssClass="SearchLabelBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Admin Password:</td>
                                    <td class="tblFormText1">
                                        <asp:Label ID="lblAdmPassword" Text='<%# Eval("AdminPwd") %>' runat="server" 
                                            CssClass="SearchLabelBold"></asp:Label>
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
                                        &nbsp;Enquiry Login ID :</td>
                                    <td class="tblFormText1">
                                        <asp:Label ID="lblenqID" Text='<%# Eval("EnquiryID") %>' runat="server" 
                                            CssClass="SearchLabelBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Enquiry Password:</td>
                                    <td class="tblFormText1">
                                        <asp:Label ID="lblenqPassword" Text='<%# Eval("EnquiryPwd") %>' runat="server" 
                                            CssClass="SearchLabelBold"></asp:Label>
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
                                        Http URL link :</td>
                                    <td class="tblFormText1">
                                        <asp:Label ID="lblhttpURLlink" runat="server" CssClass="SearchLabelBold" 
                                            Text='<%# Eval("HttpURLlink") %>'></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        <font class="font_12Msg_Success">Additional details </font>:-</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                    
                                   
                                    
                                        Google HTML upload status :</td>
                                    <td class="tblFormText1">
                                    
                                     <asp:Image ID="ImgHTMLUpStatus" runat="server" />
                                    
                                    <asp:Literal ID="ltrHtmlUpStatus" Text='<%# Eval("HtmlUpStatus") %>' runat="server"></asp:Literal>
                                   
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        MX Records Status :</td>
                                    <td class="tblFormText1">
                                        <asp:Image ID="ImgMxRecStatus" runat="server" />
                                        <asp:CheckBox ID="chkMxCreated" Checked='<%# Eval("MxRecStatus") %>' runat="server" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
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
                         &nbsp; 
                        </td>
                        <td>
                            &nbsp;
                            
                            </td>
                        
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        &nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                </table>
            
                </ItemTemplate>
                
                <EditItemTemplate>
                
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
                        &nbsp;&nbsp;
                        <asp:Button ID="BtnUpdate" CssClass="stdbuttonCRUD" CommandName="UPDATE" ToolTip="Edit My content" runat="server" Text="Update" />&nbsp; &nbsp;
                        <asp:Button ID="BtnCancel" CssClass="stdbuttonCRUD" CommandName="Cancel" runat="server" Text="Cancel" />
                      
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
                                        <font class="font_12Msg_Success">User Details </font>:- </td>
                                    <td width="75%" class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%" align="right">
                                        Full Name :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Mobile Number :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        SubDomain :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtSubDomain" runat="server" 
                                            CssClass="stdTextField1_disabled" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        OwnDomain :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtOwnDomain" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
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
                                        <font class="font_12Msg_Success">Email details </font>:- </td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;Admin Login ID :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdmLoginID" runat="server" Text='<%# Eval("AdminID")  %>' CssClass="stdTextField1" 
                                            Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                          ControlToValidate="txtAdmLoginID" Display="Dynamic" 
                          ErrorMessage="Please enter Admin LoginID" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                      &nbsp;
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                          ControlToValidate="txtAdmLoginID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                          Display="Dynamic" runat="server" ErrorMessage="Enter a Valid Email" ValidationGroup="VgCheck" 
                          SetFocusOnError="True"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Admin Password:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdmPassword" runat="server" 
                                            Text='<%# Eval("AdminPwd")  %>' CssClass="stdTextField1" 
                                            Width="350px"></asp:TextBox>
                       
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ControlToValidate="txtAdmPassword" Display="Dynamic" 
                          ErrorMessage="Please enter Admin Password" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                            
                                            
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
                                        Enquiry Login ID:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtEnqLoginID" runat="server" CssClass="stdTextField1" 
                                            Text='<%# Eval("EnquiryID")  %>' Width="350px"></asp:TextBox>
                                           
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                          ControlToValidate="txtEnqLoginID" Display="Dynamic" 
                          ErrorMessage="Please enter Enquiry LoginID" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                          &nbsp; 
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                          ControlToValidate="txtEnqLoginID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                          Display="Dynamic" runat="server" ErrorMessage="Enter a Valid Email" ValidationGroup="VgCheck" 
                          SetFocusOnError="True"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Enquiry Password:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtEnqPassword" runat="server" CssClass="stdTextField1" 
                                            Text='<%# Eval("EnquiryPwd")  %>' Width="350px"></asp:TextBox>
                                            
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                          ControlToValidate="txtEnqPassword" Display="Dynamic" 
                          ErrorMessage="Please enter Enquiry Password" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
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
                                        Http URL link :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtHttpURLlink" runat="server" CssClass="stdTextField1" Text='<%# Eval("HttpUrlLink")  %>' 
                                            Width="350px"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        <font class="font_12Msg_Success">Additional details </font>:-</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Upload Google Html :</td>
                                    <td class="tblFormText1">
                                          <asp:FileUpload ID="FU_HtmlFile" runat="server" CssClass="stdUploadField" 
                          Width="410px" />
                          <asp:Label ID="lblUpMessage" runat="server" CssClass="FontNote"></asp:Label>
                           <asp:RegularExpressionValidator ID="FileUploadValidator" runat="server" 
                            ControlToValidate="FU_HtmlFile" Enabled="true" ValidationGroup="vgCheck" 
                            ErrorMessage="<br/>Only Html files are allowed.  Please select another file." 
                            
                          ValidationExpression=".*(\.[Hh][Tt][Mm][Ll]|\.[Hh][Tt][Mm])" 
                          Display="Dynamic"></asp:RegularExpressionValidator>
                          
                           &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                          ControlToValidate="FU_HtmlFile" CssClass="font_11Msg_Error" Display="Dynamic" 
                          ErrorMessage="* Please select a HTML file to upload." ValidationGroup="vgCheck"></asp:RequiredFieldValidator>
                          </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Update MX Records :</td>
                                    <td class="tblFormText1">
                                        <asp:CheckBox ID="chkMxRecStatus" runat="server" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                            </table></td>
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
                
                </EditItemTemplate>
                
                <InsertItemTemplate>
                
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
                            <asp:Button ID="BtnSave" runat="server" CommandName="Insert" 
                                CssClass="stdbuttonCRUD" Text="SAVE" ValidationGroup="VgCheck"/>
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
                                        <font class="font_12Msg_Success">User Details </font>:-</td>
                                    <td width="75%" class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%" align="right">
                                        Full Name :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Mobile Number :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        SubDomain :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtSubDomain" runat="server" 
                                            CssClass="stdTextField1_disabled" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        OwnDomain :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtOwnDomain" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
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
                                        <font class="font_12Msg_Success">Email details </font>:-</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;Admin Login ID :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdmLoginID" runat="server" ValidationGroup="VgCheck" CssClass="stdTextField1" 
                                            Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                          ControlToValidate="txtAdmLoginID" Display="Dynamic" 
                          ErrorMessage="Please enter Admin LoginID" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                          &nbsp;
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                          ControlToValidate="txtAdmLoginID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                          Display="Dynamic" runat="server" ErrorMessage="Enter a Valid Email" ValidationGroup="VgCheck" 
                          SetFocusOnError="True"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Admin Password :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdmPassword" runat="server" CssClass="stdTextField1" Width="350px" 
                                            ></asp:TextBox>
                                            
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                          ControlToValidate="txtAdmPassword" Display="Dynamic" 
                          ErrorMessage="Please enter Admin Password" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                          
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
                                        Enquiry Login ID :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtEnqLoginID" runat="server" CssClass="stdTextField1" 
                                            Width="350px"></asp:TextBox>
                                            
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                          ControlToValidate="txtEnqLoginID" Display="Dynamic" 
                          ErrorMessage="Please enter Enquiry LoginID" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                          &nbsp;
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                          ControlToValidate="txtEnqLoginID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                          Display="Dynamic" runat="server" ErrorMessage="Enter a Valid Email" ValidationGroup="VgCheck" 
                          SetFocusOnError="True"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Enquiry Password :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtEnqPassword" runat="server" CssClass="stdTextField1" 
                                            Width="350px"></asp:TextBox>
                                            
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                          ControlToValidate="txtEnqPassword" Display="Dynamic" 
                          ErrorMessage="Please enter Enquiry Password" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
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
                                        Http URL link :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtHttpURLlink" runat="server" CssClass="stdTextField1" 
                                            Width="350px"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                <%--<tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        <font class="font_12Msg_Success">Additional details </font>:-</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Upload Google Html :</td>
                                    <td class="tblFormText1">
                                          <asp:FileUpload ID="FU_HtmlFile" runat="server" CssClass="stdUploadField" 
                          Width="410px" />
                          <asp:Label ID="lblUpMessage" runat="server" CssClass="FontNote"></asp:Label>
                           <asp:RegularExpressionValidator ID="FileUploadValidator" runat="server" 
                            ControlToValidate="FU_HtmlFile" Enabled="true" ValidationGroup="vgCheck" 
                            ErrorMessage="<br/>Only Html files are allowed.  Please select another file." 
                            
                          ValidationExpression=".*(\.[Hh][Tt][Mm][Ll]|\.[Hh][Tt][Mm])" 
                          Display="Dynamic"></asp:RegularExpressionValidator>
                          
                           &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                          ControlToValidate="FU_HtmlFile" CssClass="font_11Msg_Error" Display="Dynamic" 
                          ErrorMessage="* Please select a HTML file to upload." ValidationGroup="vgCheck"></asp:RequiredFieldValidator>
                          </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Update MX Records :</td>
                                    <td class="tblFormText1">
                                        <asp:CheckBox ID="chkMxRecStatus" runat="server" />
                                    </td>
                                </tr>--%>



                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
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
                
                </InsertItemTemplate>
                
             </asp:FormView>
             </td></tr>
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
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

    </form>


 
</asp:Content>

