<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_ChangeDomainRegEbookMsg.aspx.cs" Inherits="Admin_Ad_ChangeDomainRegEbookMsg" %>
<%@ Register src="EbLeftMenu_Profile.ascx" tagname="EbLeftMenu_Profile" tagprefix="uc1" %>

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
    <uc1:EbLeftMenu_Profile ID="EbLeftMenu_Profile1" runat="server" />
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
                        
                        
                            
                        </td><asp:Label ID="lblMsg"  runat="server" CssClass="font_12Msg_Success"></asp:Label><td>
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

