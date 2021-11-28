<%@ Page Language="C#" MasterPageFile="~/N_Master.master" AutoEventWireup="true" CodeFile="N_Numerology.aspx.cs" Inherits="N_Numerology" %>
<%@ Register Src="~/N_Footer.ascx" TagPrefix="uc1" TagName="N_Footer" %>
<%--<%@ Register Src="~/N_LeftMenu.ascx" TagPrefix="uc1" TagName="N_LeftMenu" %>--%>
<%@ Register Src="~/N_TopMenu.ascx" TagPrefix="uc1" TagName="N_TopMenu" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopMenu" runat="Server">
    <uc1:N_TopMenu runat="server" ID="N_TopMenu" />
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" runat="Server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

   <%-- <uc1:N_LeftMenu runat="server" ID="N_LeftMenu" />--%>

   

                <%--<div class="col-xs-9 content-middle">--%>
                        <br />
                    <div class="row">
                        <div class="col-xs-12 product-list">
                            <div class="row">
                                <%--<div class="col-xs-8">--%>
                                    <asp:Label ID="lblUserContent" runat="server" Text="xxxx"></asp:Label>
                                <%--</div>--%>                                
                            </div>
                        </div>
                    </div>
                 

                    
                <%--</div>--%>

    <uc1:N_Footer runat="server" ID="N_Footer" />

</asp:Content>