<%@ Page Title="" Language="C#" MasterPageFile="~/UserEbookMaster.master" AutoEventWireup="true" CodeFile="eBooksValueBuyDummy.aspx.cs" Inherits="eBooksValueBuyDummy" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 1000px;
            height: 600px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

    <link href="App_Themes/Default/eBookPage.css" rel="stylesheet" />
   <link href="App_Themes/Default/EbHomePageStyles.css" rel="stylesheet" />


    <%--<form id="frmTest" runat="server">--%>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>

            <td width="150px"></td>
            <td ></td>
        </tr>
        <tr style="height:40px;">
            <td>
               <%-- <asp:Label ID="lblCategoryHeader" CssClass="eb_head2" runat="server" Text="Categories"></asp:Label>--%>
            </td>
        </tr>

        
        <tr>
            <td valign="top">
                 
                <div id="dvLeftContent" class="CategoryBox" runat="server">
                   
                </div>
            </td>
            <td valign="top">
                <div id="dvRightContent" style="padding-left: 10px;" runat="server">
                    <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>

                </div>


            </td>
        </tr>


        <tr>
            <td valign="top">
                 
                &nbsp;</td>
            <td valign="top">
                <img alt="coming Soon" class="auto-style1" src="Images/ComingSoon.jpg" /></td>
        </tr>


        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>


    </table>


</td>
</tr>

</table>
<%--</form>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

