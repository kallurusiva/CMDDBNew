<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_DomainsListTEST.aspx.cs" Inherits="Ad_DomainsListTEST" %>

<%@ Register src="SideMenu_MyAccount.ascx" tagname="SideMenu_MyAccount" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


<script language="javascript" type="text/javascript">

    function fnCheckDomain() {


        var tmpURL = "http://www.namecheap.com/domain-name-search.asp";
        window.open(tmpURL, "winDomainCheck", "width=600px,height=550px,resizable=yes, scrollbars=yes,dependent=yes,left=150,top=150");
    
    
    }

</script>
    <form id="form1" runat="server">

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
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="1" class="stdtableBorder_Main" width="98%">
                    <tr style="height:30px;">
                        <td width="1%">&nbsp;</td>
                        <td width="98%" align="left" class="font_12Msg_Error">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                        </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                        
                        
                            <table cellpadding="0" cellspacing="2" style="width: 100%;" class="stdtableBorder_Only">
                                <tr>
                                    <td width="20%" class="Section_headtext">SubDomain </td>
                                    <td width="2%"></td>
                                    <td width="50%""></td>
                                </tr>
                                <tr  style="height:25px;">
                                    <td class="subHeaderFontGrad">
                                        Your SubDomain</td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblSubDomain" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height:25px;">
                                    <td class="subHeaderFontGrad">
                                        Your SubDomain Link</td>
                                    <td>
                                        :</td>
                                    <td>
                                       <asp:Label ID="lblSubDomainLink" runat="server"></asp:Label>
                                        
                                    </td>
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
                                    <td class="Section_headtext">
                                        OwnDomain</td>
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
                                
                                <tr id="trWEB10Section" runat="server">
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="font_12Msg_Error">
                                        This is feature is available for those who have purchased&nbsp; (web30) own 
                                        domain only. </td>
                                </tr>
                                
                                
                                <tr id="trWEB30_DomainRegistered" runat="server" visible="false">
                                    <td>
                                        Your registered Domain Name</td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label CssClass="font_14SuccessBold" ID="lblDomainName" runat="server"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Literal ID="ltrDomainRegStatus" runat="server"></asp:Literal></td>
                                </tr>
                                
                                
                                <tr id="trWEB30Section" runat="server">
                                    <td colspan="3">
                                    <table border="0" cellpadding="2" cellspacing="2" width="100%">
                                    
                        
                                <tr>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td  width="2%">
                                        &nbsp;</td>
                                    <td  width="50%">
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
                                <td colspan="3">
                                
                                
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                        
                               <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                   <tr height="0px">
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td width="2%">
                                        &nbsp;</td>
                                    <td width="50%">
                                        &nbsp;</td>
                                </tr>                                      
                                <tr>
                                    <td>
                                        Enter Domain Name </td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:TextBox ID="txtOwnDmChoice1" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                    &nbsp;<asp:Button ID="btnDomainCheck1" CssClass="stdButtonNormal" runat="server" 
                                           ToolTip="Check if the Entered Domain Name is available ?"  
                                            Text="Check availabilty ?" OnClientClick="fnCheckDomain()"/>
                                        &nbsp;
                                        <asp:Button ID="btnDomainCheckNow0" runat="server" ValidationGroup="VgCheck" 
                                            CssClass="stdButtonNormal" onclick="btnDomainCheckNow_Click" Text="Check availabilty" />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtOwnDmChoice1" Display="Dynamic" 
                                            ErrorMessage="Domain Name cannot be empty" SetFocusOnError="True" 
                                            ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                         ControlToValidate="txtOwnDmChoice1" Display="Dynamic" ValidationGroup="VgCheck" 
                                         ErrorMessage="Domain Name is inValid. must contain .com or .net etc.," 
                                            ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                            
                                             <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="50" runat="server">
                                            <ProgressTemplate>
                                            <div id="progress" runat="server" visible="true">
                                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/>
                                                Please wait...while the system checks for domain name availability
                                             </div>
                                            </ProgressTemplate>
                                            
                                            </asp:UpdateProgress>
                                            
                                    </td>
                                </tr>
                                
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="lblDomainReq" runat="server" CssClass="font_11Msg_Error"></asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnRegister" runat="server" CssClass="stdbuttonAction" 
                                            onclick="btnRegister_Click" Text="Register Domain" Visible="false" />
                                    </td>
                                </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;<asp:Label CssClass="font_11Msg_Error" ID="tmplabel" Text="label" runat="server"></asp:Label></td>
                                   </tr>
                                </table>
                                </ContentTemplate>
                              </asp:UpdatePanel>
                              
                              </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp; </td>
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
                                    <td class="font_12Msg_Error">
                                       <b>NOTE</b>:</td>
                                </tr>
                                
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="font_11Msg_Error">
                                        1. Please make sure the entered domain name is available. </td>
                                </tr>
                                
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td  class="font_11Msg_Error">
                                        2. It will take 3 working days to activated your domain.&nbsp; you will be 
                                        notified via email once activated. </td>
                                </tr>
                                
                                
                                            </table>
                                    </td>
                                
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
                                        <asp:Label CssClass="font_11Msg_Error" ID="lblDomainReq2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                
                            </table>
                        </td><td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    </form>
</asp:Content>

