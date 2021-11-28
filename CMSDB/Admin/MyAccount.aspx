<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="Admin_MyAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="SideMenu_MyAccount.ascx" tagname="SideMenu_MyAccount" tagprefix="uc1" %>

<%@ Register src="LeftMenu_Profile.ascx" tagname="LeftMenu_Profile" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
<uc2:LeftMenu_Profile ID="LeftMenu_Profile1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script language="javascript" type="text/javascript">

    function CheckKeyCode(e) {
        if (navigator.appName == "Microsoft Internet Explorer") {
            if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 8)) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            if ((e.charCode >= 48 && e.charCode <= 57) || (e.charCode == 0)) {
                return true;
            }
            else {
                return false;
            }
        }
    }


</script>
<form id="MyAccountForm" runat="server">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" visible="false" id="tblMessageBar"  runat="server">
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
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; <asp:Literal ID="LtrMyActSettings" runat="server" 
                                Text="My Account Settings [Website and Mobile Web]"></asp:Literal>&nbsp;
                          </td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
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
                            &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:FormView ID="FrmAccount" runat="server"  Width="98%"
                                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="2" 
                                GridLines="Vertical" 
                                onitemupdating="FrmAccount_ItemUpdating" 
                                onmodechanged="FrmAccount_ModeChanged" 
                                onmodechanging="FrmAccount_ModeChanging" 
                                ondatabound="FrmAccount_DataBound" 
                                oniteminserting="FrmAccount_ItemInserting" 
                                onprerender="FrmAccount_PreRender" >
                            <ItemTemplate>
                            
                              <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td width="50%">&nbsp; </td>
                              <td>&nbsp; </td>
                               <td width="50%">&nbsp; </td>
                              </tr>
                              <tr>
                              <td width="44%" align="left" valign="top">
                                <table border="0" cellpadding="0" cellspacing="2" width="100%" class="stdtableBorder_AccountPage">
                                <tr>
                                 <td width="20%">&nbsp;</td>
                                 <td width="2%">&nbsp;</td>
                                 <td width="55%">&nbsp;</td>
                                 <td width="23%">&nbsp;</td>
                                </tr>
                                <tr>
                                <td colspan="3"> <font class="Section_headtext">
                                <asp:Literal ID="ltrUserDetails" Text="User Details" runat="server"></asp:Literal>
                                
                                 </font></td>
                                <%--<td>&nbsp;</td>
                                <td>&nbsp;</td>--%>
                                <td align="left"><font class="Section_headtext2">
                                    <asp:Literal ID="LtrDisplayAtWebsite" Text="Display at Website" runat="server"></asp:Literal>
                                 </font></td>
                                </tr>
                                
                                <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrCompanyName" runat="server" Text="Company Name"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox6" CssClass="stdTextField1_disabled" ReadOnly="true" runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox></td>
                                <td>&nbsp;<asp:CheckBox ID="CheckBox4" Enabled="false" Checked='<%# Bind("CompanyNameChk") %>'   runat="server" /></td>
                                </tr>
                                
                                <tr>
                                 <td  align="left"> 
                                     <asp:Literal ID="LtrUserName" runat="server" Text="Full Name"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtUserName" CssClass="stdTextField1_disabled" ReadOnly="true" runat="server" Text='<%# Bind("FullName") %>'></asp:TextBox></td>
                                 <td>&nbsp;</td>
                                </tr>
                                <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrNickName" runat="server" Text="Nick Name"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox1" CssClass="stdTextField1_disabled"  ReadOnly="true" runat="server" Text='<%# Bind("NickName") %>'></asp:TextBox></td>
                                     <td>&nbsp; <asp:CheckBox ID="chkNickName" Enabled="false" Checked='<%# Bind("NickNameChk") %>'   runat="server" /></td>
                                </tr>
                                 <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrEmail" runat="server" Text="Email Address"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox2" CssClass="stdTextField1_disabled"  ReadOnly="true" runat="server" Text='<%# Bind("email") %>'></asp:TextBox></td>
                                <td>&nbsp; <asp:CheckBox ID="ChkEmail" Enabled="false" Checked='<%# Eval("EmailChk") %>'  runat="server" /></td>
                                </tr>
                                <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrHandPhone" runat="server" Text="Mobile No"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox3" CssClass="stdTextField1_disabled"  ReadOnly="true" runat="server" Text='<%# Bind("HandPhone") %>'></asp:TextBox></td>
                                <td>&nbsp; <asp:CheckBox ID="ChkHandPhone" Enabled="false" Checked='<%# Eval("MobileNoChk") %>' runat="server" /></td>
                                </tr>
                                                             
                                <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrHomePhone" runat="server" Text="Contact No"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox5" CssClass="stdTextField1_disabled" ReadOnly="true" runat="server" Text='<%# Bind("HomePhone") %>'></asp:TextBox></td>
                                <td>&nbsp; <asp:CheckBox ID="ChkHomePhone" Enabled="false" Checked='<%# Eval("HomePhoneChk") %>' runat="server" /></td>
                                </tr>
                                
                                 <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrFaxNo" runat="server" Text="Fax No"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtFaxNo" CssClass="stdTextField1_disabled" ReadOnly="true" runat="server" Text='<%# Bind("FaxNo") %>'></asp:TextBox></td>
                                <td>&nbsp; <asp:CheckBox ID="CheckBox2" Enabled="false" Checked='<%# Eval("FaxNoChk") %>' runat="server" /></td>
                                </tr>
                                
                                 <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrAddress" runat="server" Text="Address"></asp:Literal>
                                     <br />
                                     <asp:Label ID="lblLocationMap" CssClass="font_11Msg_Error" runat="server" Text="(Location Map)"></asp:Label>
                                    </td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtAddress" CssClass="stdTextArea1_disabled" ReadOnly="true" runat="server" TextMode="MultiLine" Text='<%# Bind("Address") %>'></asp:TextBox></td><td>&nbsp; <asp:CheckBox ID="CheckBox3" Enabled="false" Checked='<%# Eval("AddressChk") %>' runat="server" /></td>
                                </tr>
                                
                                 <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>
                                    &nbsp;
                                 </td>
                                 <td>&nbsp;</td></tr><tr>
                                 <td align="left"> 
                                     <asp:Literal ID="ltrMyPhoto" runat="server" Text="My Photo"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                    <div id="dvUserPhoto">
                                        <asp:Image ID="ImgUserPhoto" CssClass="dvUserPhotoCss" BorderWidth="1px" ImageUrl='<%# Eval("FullImgPath") %>' BorderColor="#ACA9A9" AlternateText="aspimg" runat="server" />
                                    </div>   
                                 </td>
                                 <td>&nbsp; <asp:CheckBox ID="chkUserPhoto" Enabled="false" Checked='<%# Eval("UserPhotoChk") %>' runat="server" /></td>
                                </tr>
                                
                                <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr></table></td><td width="1%">&nbsp; </td>
                              <td width="55%" align="left" valign="top"> 
                              
                                 <table border="0" cellpadding="0" cellspacing="2" width="100%" class="stdtableBorder_AccountPage">
                                 <tr>
                                 <td width="30%">&nbsp;</td><td width="2%">&nbsp;</td><td width="50%">&nbsp;</td><td width="23%">&nbsp;</td></tr><tr>
                                 <td align="left" colspan="3"><font class="Section_headtext">
                                 <asp:Literal ID="ltrFollowUs" runat="server" Text="Follow us Links"></asp:Literal>  </font></td>
<%--                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>--%>
                                 <td align="left"><font class="Section_headtext2"> <asp:Literal ID="LtrDisplayAtWebsite2" Text="Display at Website" runat="server"></asp:Literal></font></td></tr><tr>
                                 <td align="left"> &nbsp; Yahoo MailID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox14" CssClass="stdTextField1_disabled"  ReadOnly="true" runat="server" Text='<%# Bind("YahooID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="CheckBox7" Enabled="false" runat="server" Checked='<%# Bind("YahooChecked") %>' /></td>
                                 </tr>
                                                                
                                 <tr>
                                 <td align="left"> &nbsp; Hotmail MailID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox15" CssClass="stdTextField1_disabled"  ReadOnly="true" runat="server" Text='<%# Bind("HotmailID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="CheckBox8"  Enabled="false" runat="server" Checked='<%# Bind("HotmailChecked") %>' /></td>
                                 </tr>
                                 
                                  <tr>
                                 <td align="left"> &nbsp; Skype ID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox16" CssClass="stdTextField1_disabled"  ReadOnly="true" runat="server" Text='<%# Bind("SkypeID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="CheckBox9" Enabled="false" runat="server" Checked='<%# Bind("SkypeChecked") %>' /></td>
                                 </tr>
                                 
                                 <tr>
                                 <td align="left"> &nbsp; TwitterID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox17" CssClass="stdTextField1_disabled"  ReadOnly="true" runat="server" Text='<%# Bind("TwitterID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="CheckBox10" Enabled="false" runat="server" Checked='<%# Bind("TwitterChecked") %>' /></td>
                                 </tr>
                                 
                                 <tr>
                                 <td align="left"> &nbsp; BlogSpot ID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox18" CssClass="stdTextField1_disabled"  ReadOnly="true" runat="server" Text='<%# Bind("BlogSpotID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="CheckBox11" Enabled="false" runat="server" Checked='<%# Bind("BlogSpotChecked") %>' /></td>
                                 </tr>
                                 
                                 <tr>
                                 <td align="left"> &nbsp; Facebook ID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox19" CssClass="stdTextField1_disabled"  ReadOnly="true" runat="server" Text='<%# Bind("FacebookID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="CheckBox12" Enabled="false" runat="server" Checked='<%# Bind("FacebookChecked") %>' /></td>
                                 </tr>
                                 
                                  <tr>
                                 <td align="left"> &nbsp; Facebook Page</td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox20" CssClass="stdTextField1_disabled"  ReadOnly="true" runat="server" Text='<%# Bind("FaceBookGroupLink") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="CheckBox1" Enabled="false" runat="server" Checked='<%# Bind("FaceBookGroupLinkChecked") %>' /></td>
                                 </tr>
                                 
                                
                                <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><%--         <tr>
                                 <td colspan="3"> <font class="Section_headtext">Company Details </font></td>
                               <td>&nbsp;</td>
                                </tr>
                                
                               
                                
                                <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrCompanyDesc" runat="server" Text="Company Description"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="TextBox7" CssClass="stdTextArea2_disabled" Wrap="true"  ReadOnly="true" runat="server" Text='<%# Eval("CompanyInfo").ToString().Replace("<br/>",Environment.NewLine)%>' TextMode="MultiLine"></asp:TextBox></td>
                                     
                               <td>&nbsp;</td>
                                </tr>--%>
                                
                                
                                
                                <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td> &nbsp;</td><td>&nbsp;</td></tr><tr>
                                 <td colspan="4" class="Section_headtext2">
                                 <%--<b>NOTE :</b> For subdomain only Yahoo Messenger will appear at Website--%>
                                 </td>
                                 
                          
                                </tr>
                                
                                </table>
                              
                              
                              </td>
                              </tr>
                              <tr>
                              <td align="center"> 
                                  <asp:Button ID="BtnEdit" CssClass="stdbuttonCRUD" CommandName="Edit" runat="server" Text="EDIT MyAccount Settings" />&nbsp; &nbsp; &nbsp; 
                                  </td>
                              <td>&nbsp; </td>
                              <td>&nbsp; </td>
                              </tr>
                              
                              
                              <tr>
                              <td>&nbsp; </td>
                              <td>&nbsp; </td>
                              <td>&nbsp; </td>
                              </tr>
                              
                              </table>
                            
                            </ItemTemplate>
                                
                            <EditItemTemplate>
                             
                             <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td width="50%">&nbsp; </td>
                              <td>&nbsp; </td>
                               <td width="50%">&nbsp; </td>
                              </tr>
                              <tr>
                              <td width="44%" align="left" valign="top">
                                <table border="0" cellpadding="0" cellspacing="2" width="100%"  class="stdtableBorder_AccountPage">
                                <tr>
                                 <td width="27%">&nbsp;</td><td width="2%">&nbsp;</td><td width="48%">&nbsp;</td><td width="23%">&nbsp;</td></tr><tr>
                                <td colspan="3"> <font class="Section_headtext">User Details </font></td>
                                <%--<td>&nbsp;</td>
                                <td>&nbsp;</td>--%>
                                <td align="left"><font class="Section_headtext2">
                                    <asp:Literal ID="LtrDisplayAtWebsite" Text="Display at Website" runat="server"></asp:Literal></font></td></tr><tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrCompanyName" runat="server" Text="Company Name"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtCompanyName" CssClass="stdTextField1"  runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkCompanyName" runat="server"  Checked='<%# Eval("CompanyNameChk") %>' /></td>
                                </tr>
                                
                                <tr>
                                 <td  align="left"> 
                                     <asp:Literal ID="LtrUserName" runat="server" Text="Full Name"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtFullName" CssClass="stdTextField1" runat="server" Text='<%# Bind("FullName") %>'></asp:TextBox></td><td>&nbsp;</td></tr><tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrNickName" runat="server" Text="Nick Name"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtNickName" CssClass="stdTextField1"   runat="server" Text='<%# Bind("NickName") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkNickName" Checked='<%# Eval("NickNameChk") %>' runat="server" /></td>
                                </tr>
                                 <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrEmail" runat="server" Text="Email Address"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtEmail" CssClass="stdTextField1"  runat="server" Text='<%# Bind("email") %>'></asp:TextBox></td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtEmail" ValidationGroup="VgCheck" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="server" ErrorMessage=" [ Invalid Email ]"></asp:RegularExpressionValidator><td>&nbsp;<asp:CheckBox ID="chkEmail"  Checked='<%# Eval("EmailChk") %>' runat="server" /></td>
                                </tr>
                                <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrHandPhone" runat="server" Text="Mobile No"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtHandPhone" MaxLength="11" CssClass="stdTextField1"  runat="server" Text='<%# Bind("HandPhone") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkHandPhone"  Checked='<%# Eval("MobileNoChk") %>' runat="server" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtHandPhone" ValidationGroup="VgCheck" ValidationExpression="^[0-9]+$" Display="Dynamic" runat="server" ErrorMessage=" [ Only Numbers are allowed ]"></asp:RegularExpressionValidator></td></tr><tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrHomePhone" runat="server" Text="Contact No"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtHomePhone" MaxLength="11" CssClass="stdTextField1" runat="server" Text='<%# Bind("HomePhone") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkHomePhone" Checked='<%# Eval("HomePhoneChk") %>' runat="server" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtHomePhone" ValidationGroup="VgCheck" ValidationExpression="^[0-9]+$" Display="Dynamic" runat="server" ErrorMessage=" [ Only Numbers are allowed ]"></asp:RegularExpressionValidator></td></tr><tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrFaxNo" runat="server" Text="Fax No"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtFaxNo" CssClass="stdTextField1" MaxLength="11" runat="server" Text='<%# Bind("FaxNo") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkFaxNo" Checked='<%# Eval("FaxNoChk") %>' runat="server" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtFaxNo" ValidationGroup="VgCheck" ValidationExpression="^[0-9]+$" Display="Dynamic" runat="server" ErrorMessage=" [ Only Numbers are allowed ]"></asp:RegularExpressionValidator></td></tr><tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrAddress" runat="server" Text="Address"></asp:Literal>
                                     <br />
                                     <asp:Label ID="lblLocationMap" CssClass="font_11Msg_Error" runat="server" Text="(Location Map)"></asp:Label>
                                     </td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtAddress" CssClass="stdTextArea1" runat="server" TextMode="MultiLine" Text='<%# Bind("Address") %>'></asp:TextBox></td><td>&nbsp; <asp:CheckBox ID="chkAddress" Checked='<%# Eval("AddressChk") %>' runat="server" /></td>
                                </tr>
                                
                                 <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr>
                                 <td align="left"> 
                                     <asp:Literal ID="ltrMyPhoto" runat="server" Text="My Photo"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                    <div id="dvUserPhoto">
                                        <asp:Image ID="ImgUserPhoto" CssClass="dvUserPhotoCss" ImageUrl='<%# Eval("FullImgPath") %>'  AlternateText="aspimg" runat="server" />
                                    </div>   
                                 </td>
                                 <td>&nbsp;<asp:CheckBox ID="chkUserPhoto" Checked='<%# Eval("UserPhotoChk") %>' runat="server" /></td>
                                </tr>
                                
                                <tr>
                                 <td><asp:Literal ID="Literal2" runat="server" Text="Upload new Photo"></asp:Literal></td><td>&nbsp;: </td>
                                 <td>
                                     <asp:FileUpload ID="fupl_UserPhoto" runat="server" />
                                 </td>
                                 <td>&nbsp;</td></tr><tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr></table></td><td width="1%">&nbsp; </td>
                              <td width="55%" align="left" valign="top"> 
                              
                                 <table border="0" cellpadding="0" cellspacing="2" width="100%"  class="stdtableBorder_AccountPage">
                                 <tr>
                                 <td width="25%">&nbsp;</td><td width="2%">&nbsp;</td><td width="55%">&nbsp;</td><td width="18%">&nbsp;</td></tr><tr>
                                 <td colspan="3" align="left"> <font class="Section_headtext">
                                 <asp:Literal ID="ltrFollowUs" runat="server" Text="Follow us Links"></asp:Literal> </font> </td>
                                 <td align="left"><font class="Section_headtext2">
                                    <asp:Literal ID="LtrDisplayAtWebsite2" Text="Display at Website" runat="server"></asp:Literal></font></td></tr><tr>
                                 <td align="left"> &nbsp; Yahoo MailID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtYahooID" CssClass="stdTextField1"  runat="server" Text='<%# Bind("YahooID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkYahoo" runat="server" Checked='<%# Bind("YahooChecked") %>' /></td>
                                 </tr>
                                                                
                                 <tr>
                                 <td align="left"> &nbsp; Hotmail MailID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtHotmailID" CssClass="stdTextField1"  runat="server" Text='<%# Bind("HotmailID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkHotmail" runat="server" Checked='<%# Bind("HotmailChecked") %>' /></td>
                                 </tr>
                                 
                                  <tr>
                                 <td align="left"> &nbsp; Skype MailID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtSkypeID" CssClass="stdTextField1"   runat="server" Text='<%# Bind("SkypeID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="ChkSkype" runat="server" Checked='<%# Bind("SkypeChecked") %>' /></td>
                                 </tr>
                                 
                                 <tr>
                                 <td align="left"> &nbsp; TwitterID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtTwitterID" CssClass="stdTextField1"  runat="server" Text='<%# Bind("TwitterID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkTwitter" runat="server" Checked='<%# Bind("TwitterChecked") %>' /></td>
                                 </tr>
                                 
                                 <tr>
                                 <td align="left"> &nbsp; BlogSpot ID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtBlogSpotID" CssClass="stdTextField1"  runat="server" Text='<%# Bind("BlogSpotID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkBlogSpot" runat="server" Checked='<%# Bind("BlogSpotChecked") %>' /></td>
                                 </tr>
                                 
                                 <tr>
                                 <td align="left"> &nbsp; Facebook ID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtFacebookId" CssClass="stdTextField1"  runat="server" Text='<%# Bind("FacebookID") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkFacebook" runat="server" Checked='<%# Bind("FacebookChecked") %>' /></td>
                                 </tr>
                                 
                                  <tr>
                                 <td align="left"> &nbsp; Facebook Page </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtFacebookGroupLink" CssClass="stdTextField1"  runat="server" Text='<%# Bind("FaceBookGroupLink") %>'></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkFaceBookGroupLink" runat="server" Checked='<%# Bind("FaceBookGroupLinkChecked") %>' /></td>
                                 </tr>
                                 
                                
                                <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><%-- <tr>
                                 <td> Company Details </td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                </tr>--%>
                                
                       
                                
                                 <%--<tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrCompanyDesc" runat="server" Text="Company Description"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtCompanyInfo" CssClass="stdTextArea2" Wrap="true" runat="server" Text='<%# Bind("CompanyInfo") %>' TextMode="MultiLine"></asp:TextBox>
                                     </td>
                                     <td>&nbsp;</td>
                                </tr>--%>
                                
                                
                                
                                <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr>
                                 <td colspan="4" class="Section_headtext2">
                                 <b>NOTE :</b> For subdomain only Yahoo Messenger will appear at Website
                                 </td>
                                 
                          
                                </tr>
                                </table>
                              
                              
                              </td>
                              </tr>
                              <tr>
                              <td align="center"> 
                                  <asp:Button ID="BtnUpdate" CssClass="stdbuttonCRUD" ValidationGroup="VgCheck" CommandName="UPDATE" ToolTip="Update My Account Settings" runat="server" Text="Update" />&nbsp; &nbsp; &nbsp; 
                                  <asp:Button ID="BtnCancel" CssClass="stdbuttonCRUD" CommandName="Cancel" runat="server" Text="Cancel" />
                                  
                                  </td>
                              <td>&nbsp; </td>
                              <td>&nbsp; </td>
                              </tr>
                              
                               <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr></table></EditItemTemplate><EditRowStyle BackColor="#EEF0D6" />
                             
                            <InsertItemTemplate>
                                                        
                              <table border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr>
                              <td width="50%">&nbsp; </td>
                              <td>&nbsp; </td>
                               <td width="50%">&nbsp; </td>
                              </tr>
                              <tr>
                              <td width="48%" align="left" valign="top">
                                <table border="0" cellpadding="0" cellspacing="2" width="100%"  class="stdtableBorder_AccountPage">
                                <tr>
                                 <td width="20%">&nbsp;</td><td width="2%">&nbsp;</td><td width="55%">&nbsp;</td><td width="23%">&nbsp;</td></tr><tr>
                                <td colspan="3"> <font class="Section_headtext">User Details </font></td>
                                <td align="left"><font class="Section_headtext2">
                                    <asp:Literal ID="LtrDisplayAtWebsite" Text="Display at Website" runat="server"></asp:Literal></font></td></tr><tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrCompanyName" runat="server" Text="Company Name"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtCompanyName" CssClass="stdTextField1" runat="server" Text=''></asp:TextBox></td><td>
                                    &nbsp; <asp:CheckBox ID="chkCompanyName" runat="server" />
                                     </td>
                                </tr>
                                
                                <tr>
                                 <td  align="left"> 
                                     <asp:Literal ID="LtrUserName" runat="server" Text="Full Name"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtFullName" CssClass="stdTextField1" runat="server" Text=''></asp:TextBox></td><td>&nbsp;</td></tr><tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrNickName" runat="server" Text="Nick Name"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtNickName" CssClass="stdTextField1"  runat="server" Text=''></asp:TextBox></td><td>&nbsp; <asp:CheckBox ID="chkNickName"  runat="server" /></td>
                                </tr>
                                 <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrEmail" runat="server" Text="Email Address"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtEmail" CssClass="stdTextField1" runat="server" Text=''></asp:TextBox></td><td>&nbsp; <asp:CheckBox ID="ChkEmail"  runat="server" /></td>
                                </tr>
                                <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrHandPhone" runat="server" Text="Mobile No"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtHandPhone" CssClass="stdTextField1"  runat="server" Text=''></asp:TextBox></td><td>&nbsp; <asp:CheckBox ID="chkHandPhone"  runat="server" /></td>
                                </tr>
                                                             
                                <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrHomePhone" runat="server" Text="Contact No"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtHomePhone" CssClass="stdTextField1"  runat="server" Text=''></asp:TextBox></td><td>&nbsp; <asp:CheckBox ID="chkHomePhone"  runat="server" /></td>
                                </tr>
                                
                                 <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrFaxNo" runat="server" Text="Fax No"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtFaxNo" CssClass="stdTextField1"  runat="server" Text=''></asp:TextBox></td><td>&nbsp; <asp:CheckBox ID="chkFaxNo"  runat="server" /></td>
                                </tr>
                                
                                 <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrAddress" runat="server" Text="Address"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtAddress" CssClass="stdTextArea1" runat="server" TextMode="MultiLine" Text=""></asp:TextBox></td><td>&nbsp; <asp:CheckBox ID="chkAddress" runat="server" /></td>
                                </tr>
                                
                                 <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr>
                                 <td align="left"> 
                                     <asp:Literal ID="Literal1" runat="server" Text="My Photo"></asp:Literal></td><td>&nbsp;: </td>
                                 <td align="left"> 
                                    <div id="dvUserPhoto">
                                        <asp:Image ID="ImgUserPhoto" CssClass="dvUserPhotoCss" BorderWidth="1px" BorderColor="#ACA9A9"  AlternateText="aspimg" runat="server" />
                                    </div>   
                                 </td>
                                <td>&nbsp; <asp:CheckBox ID="chkUserPhoto"  runat="server" /></td>
                                </tr>
                                
                                <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr>
                                 <td><asp:Literal ID="Literal2" runat="server" Text="Upload new Photo"></asp:Literal></td><td>&nbsp;: </td>
                                 <td>
                                     <asp:FileUpload ID="fupl_UserPhoto" runat="server" />
                                 </td>
                                   <td>&nbsp;</td></tr></table></td><td width="1%">&nbsp; </td>
                              <td width="51%" align="left" valign="top"> 
                              
                                 <table border="0" cellpadding="0" cellspacing="2" width="100%" class="stdtableBorder_AccountPage">
                                 <tr>
                                 <td  width="30%">&nbsp;</td><td  width="2%">&nbsp;</td><td  width="40%">&nbsp;</td><td  width="23%">&nbsp;</td></tr><tr>
                                 <td align="left"><font class="Section_headtext"> Follow us Links </font></td>
                                 <td >&nbsp;</td><td >&nbsp;</td><td align="left" width="10%"><font class="Section_headtext2">
                                    <asp:Literal ID="Literal3" Text="Display at Website" runat="server"></asp:Literal></font></td></tr><tr>
                                 <td align="left"> &nbsp; Yahoo MailID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtYahooID" CssClass="stdTextField1"   runat="server" Text=''></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkYahoo" runat="server"  /></td>
                                 </tr>
                                                                
                                 <tr>
                                 <td align="left"> &nbsp; Hotmail MailID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtHotmailID" CssClass="stdTextField1"   runat="server" Text=''></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkHotmail"  runat="server"  /></td>
                                 </tr>
                                 
                                  <tr>
                                 <td align="left"> &nbsp; Skype ID</td><td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtSkypeID" CssClass="stdTextField1"  runat="server" Text=''></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkSkype"  runat="server" /></td>
                                 </tr>
                                 
                                 <tr>
                                 <td align="left"> &nbsp; TwitterID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtTwitterID" CssClass="stdTextField1"  runat="server" Text=''></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkTwitter"  runat="server"  /></td>
                                 </tr>
                                 
                                 <tr>
                                 <td align="left"> &nbsp; BlogSpot ID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtBlogSpotID" CssClass="stdTextField1"  runat="server" Text=''></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkBlogSpot"  runat="server"  /></td>
                                 </tr>
                                 
                                 <tr>
                                 <td align="left"> &nbsp; Facebook ID </td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtFacebookID" CssClass="stdTextField1" runat="server" Text=''></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkFacebook" runat="server" /></td>
                                 </tr>
                                 
                                  <tr>
                                 <td align="left"> &nbsp; Facebook Page</td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtFacebookGroupLink" CssClass="stdTextField1" runat="server" Text=''></asp:TextBox></td><td>&nbsp;<asp:CheckBox ID="chkFaceBookGroupLink" runat="server" /></td>
                                 </tr>
                                 
                                
                                <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><%-- <tr>
                                 <td> <font class="Section_headtext">Company Details </font></td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                </tr>--%>
                                
                          
                                
                               <%--  <tr>
                                 <td align="left"> 
                                     <asp:Literal ID="LtrCompanyDesc" runat="server" Text="Company Description"></asp:Literal></td>
                                 <td>&nbsp;: </td>
                                 <td align="left"> 
                                     <asp:TextBox ID="txtCompanyinfo" CssClass="stdTextArea2" Wrap="true"  runat="server" Text='' TextMode="MultiLine"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                </tr>
                                --%>
                                
                                
                                <tr>
                                 <td>&nbsp;</td><td>&nbsp;</td><td> &nbsp;</td><td>&nbsp;</td></tr><tr>
                                 <td colspan="4" class="Section_headtext2">
                                 <b>NOTE :</b> For subdomain only Yahoo Messenger will appear at Website
                                 </td>
                                 
                          
                                </tr>
                                
                                
                                </table>
                              
                              
                              </td>
                              </tr>
                              <tr>
                              <td align="center"> 
                                  <asp:Button ID="BtnSave" CssClass="stdbuttonCRUD" CommandName="Insert" runat="server" Text="SAVE MyAccount Settings" />&nbsp; &nbsp; &nbsp; 
                                  </td>
                              <td>&nbsp; </td>
                              <td>&nbsp; </td>
                              </tr>
                              
                              
                              <tr>
                              <td>&nbsp; </td>
                              <td>&nbsp; </td>
                              <td>&nbsp; </td>
                              </tr>
                              
                              </table>
                            
                            </InsertItemTemplate>    
                            <InsertRowStyle BackColor="#F3F3F2" />
                            </asp:FormView>
                        </td>
                        <td>&nbsp;</td></tr><tr>
                        <td>
                            &nbsp;</td><td>
                            &nbsp;</td><td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr></table></form></asp:Content>