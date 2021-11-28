<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_DomainsList.aspx.cs" Inherits="Ad_DomainsList" %>



<%@ Register src="EBLeftMenu_RegSTEPS.ascx" tagname="EBLeftMenu_RegSTEPS" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-style: italic;
            font-variant: normal;
            font-weight: bold;
            font-size: 120%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
            height: 30px;
            position: relative;
            vertical-align: middle;
            color: #B04D4D;
            width: 306px;
            margin-left: 0;
            margin-right: 0;
            margin-top: 30px;
            margin-bottom: 50px;
        }
        .style2
        {
            width: 306px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <p>
        </p>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


<script language="javascript" type="text/javascript">

    function fnCheckDomain() {


        var tmpURL = "http://www.namecheap.com/domain-name-search.asp";
        window.open(tmpURL, "winDomainCheck", "width=600px,height=550px,resizable=yes, scrollbars=yes,dependent=yes,left=150,top=150");
    
    
    }

</script>
    <form id="form1" runat="server">
    <input type="hidden" value="ipadr" id="hdIpAddress" name="hdIpAddress" />
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
                            &nbsp;</td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="1" class="stdtableBorder_Main" width="98%">
                    <tr style="height:30px;">
                        <td width="1%">&nbsp;</td>
                        <td width="98%" align="left" class="font_12Msg_Error">
                            
                        </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                        
                        
                            <table cellpadding="0" cellspacing="2" style="width: 100%;" class="stdtableBorder_Only">
                               <%-- <tr>
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
                                </tr>--%>
                                
                                <tr>
                                    <td class="style1">
                                        OwnDomain Registration :</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                
                               <%-- <tr>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>--%>
                                
                                <tr id="trWEB10Section" runat="server">
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="font_12Msg_Error">
                                        This is feature is available for [Web30 or Platinum users] only. </td>
                                </tr>
                                
                                
                                <tr id="trWEB30_DomainRegistered" runat="server" visible="false">
                                    <td class="style2">
                                        Your registered Domain Name</td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label CssClass="font_14SuccessBold" ID="lblDomainName" runat="server"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Literal ID="ltrDomainRegStatus" runat="server"></asp:Literal>
                                        <asp:Label ID="lblExpiry" runat="server" CssClass="font_12Msg_Error" Text=""></asp:Label>
                                        
                                        </td>
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
                                
                              
                                
                                <%--<tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>--%>
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
                                    <td width="50%" class="FontNote">
                                        <font class="loginfont12">STEP 1 :</font> Check Domain availability.
                                        <br />
                                        <font class="loginfont12">STEP 2 :</font> Click Register once domain availability is confirmed.
                                        <br />
                                        <br />
                                       </td>
                                </tr>                                      
                                <tr>
                                    <td>
                                        Enter Domain Name </td>
                                    <td>
                                        :</td>
                                    <td valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0" width="50%">
                                    <tr>
                                    <td>
                                        <asp:TextBox ID="txtOwnDmChoice1" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                        <%--<asp:Button ID="btnDomainCheck1" CssClass="stdButtonNormal" runat="server" 
                                           ToolTip="Check if the Entered Domain Name is available ?"  
                                            Text="Check availabilty ?" OnClientClick="fnCheckDomain()"/>--%>
                                        
                                    </td>
                                    <td>
                                            &nbsp;
                                        <asp:DropDownList ID="ddlExtension" CssClass="stdDropDown" runat="server">
                                         <asp:ListItem Text=".com" Value=".com"></asp:ListItem>
                                         <asp:ListItem Text=".net" Value=".net"></asp:ListItem>
                                         <asp:ListItem Text=".biz" Value=".biz"></asp:ListItem>
                                         <asp:ListItem Text=".org" Value=".org"></asp:ListItem>
                                         <asp:ListItem Text=".me" Value=".me"></asp:ListItem>
                                         <asp:ListItem Text=".mobi" Value=".mobi"></asp:ListItem>
                                         
                                        </asp:DropDownList>
                                        </td>
                                        
                                        <td>
                                        &nbsp;
                                        <asp:Button ID="btnDomainCheckNow0" runat="server" ValidationGroup="VgCheck" 
                                            CssClass="stdButtonNormal" onclick="btnDomainCheckNow_Click" Text="Check availabilty" />
                                    </td>
                                    
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtOwnDmChoice1" Display="Dynamic" 
                                            ErrorMessage="Domain Name cannot be empty" SetFocusOnError="True" 
                                            ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                     <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                         ControlToValidate="txtOwnDmChoice1" Display="Dynamic" ValidationGroup="VgCheck" 
                                         ErrorMessage="Domain Name is inValid. must contain .com or .net etc.," 
                                            ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>--%>
                                            
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtOwnDmChoice1"
                                             ValidationExpression="^[a-zA-Z0-9\-]+$" Display="Dynamic" runat="server" ValidationGroup="VgCheck"  
                                             ErrorMessage=" - Only [Aa-Zz] Alphabhets, [0-9] numerals and  [ - ] hyphen is allowed."></asp:RegularExpressionValidator>
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
                                           &nbsp;<%--<asp:Label CssClass="font_11Msg_Error" ID="tmplabel" Text="label" runat="server"></asp:Label>--%></td>
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
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                
                                <tr>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label CssClass="font_11Msg_Error" ID="lblDomainReq2" runat="server"></asp:Label>
                                        <%--<asp:Button ID="sendsms" runat="server" Height="26px" onclick="sendsms_Click" 
                                            Text="SendSms" Width="85px" />--%> 
                                    </td>
                                </tr>
                                
                            </table>
                        </td><td>
                            &nbsp;</td></tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
                        </td></tr></table></td></tr></table></td></tr><tr>
            <td>
                &nbsp;</td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    </form>
</asp:Content>

