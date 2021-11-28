<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_RegSTEPS.ascx.cs" Inherits="Admin_EBLeftMenu_RegSTEPS" %>
<div id='leftmenu' style="width: 300px;">
<ul>
<li><span class="header"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal2" runat="server" Text="Registration"></asp:Literal> </span></li>

<%-- STEP 1  --%>
<li id="liStep1" runat="server"> 
    <asp:HyperLink ID="HypSTEP1" CssClass="LiCon add" runat="server" Text="" NavigateUrl="~/Admin/Ad_DomainRegEbook.aspx">
        <asp:Label ID="Label4" CssClass="fontStepA" runat="server" Text="STEP 1"></asp:Label>
        <br /><asp:Label ID="Label3" CssClass="fontStepB" runat="server" Text="Register Domain"></asp:Label>
        <br /><asp:Label ID="lblStepStatus1" CssClass="fontRegPending" runat="server" Text=""></asp:Label>

    </asp:HyperLink> 
</li>

<%-- STEP  2  --%>
<li id="liStep2" runat="server"> 
       <asp:HyperLink ID="HypSTEP2" CssClass="LiCon add" runat="server" Text="" NavigateUrl="~/Admin/EBad_CreateStoreID.aspx">
        <asp:Label ID="Label5" CssClass="fontStepA" runat="server" Text="STEP 2"></asp:Label>
        <br /><asp:Label ID="Label6" CssClass="fontStepB" runat="server" Text="Register Store ID"></asp:Label>
        <br /><asp:Label ID="lblStepStatus2" CssClass="fontRegPending" runat="server" Text=""></asp:Label>

    </asp:HyperLink> 

</li>

<%-- STEP  3  --%>
<%--<li id="liStep3" runat="server"> 
     <asp:HyperLink ID="HypSTEP3" CssClass="LiCon add" runat="server" Text="" NavigateUrl="~/Admin/Ebook_ProfilePage.aspx">
        <asp:Label ID="Label1" CssClass="fontStepA" runat="server" Text="STEP 3"></asp:Label>
        <br /><asp:Label ID="Label7" CssClass="fontStepB" runat="server" Text="Register Profile"></asp:Label>
        <br /><asp:Label ID="lblStepStatus3" CssClass="fontRegPending" runat="server" Text="pending"></asp:Label>

    </asp:HyperLink> 
</li>--%>


    <%-- STEP  4  --%>
<%--<li id="liStep4" runat="server"> 
     <asp:HyperLink ID="HypSTEP4" CssClass="LiCon add" runat="server" Text="" NavigateUrl="~/Admin/EbAd_PhyEbookRequest.aspx">
        <asp:Label ID="Label2" CssClass="fontStepA" runat="server" Text="STEP 4"></asp:Label>
        <br /><asp:Label ID="Label8" CssClass="fontStepB" runat="server" Text="Register Physical Book"></asp:Label>
        <br /><asp:Label ID="lblStepStatus4" CssClass="fontRegPending" runat="server" Text="pending"></asp:Label>

    </asp:HyperLink> 
</li>--%>


    <%-- STEP  5  --%>
<%--<li id="liStep5" runat="server"> 
     <asp:HyperLink ID="HypSTEP5" CssClass="LiCon add" runat="server" Text="" NavigateUrl="~/Admin/EBAd_KeywordRegister.aspx">
        <asp:Label ID="Label10" CssClass="fontStepA" runat="server" Text="STEP 5"></asp:Label>
        <br /><asp:Label ID="Label11" CssClass="fontStepB" runat="server" Text="Register Vendor Code"></asp:Label>
        <br /><asp:Label ID="lblStepStatus5" CssClass="fontRegPending" runat="server" Text="pending"></asp:Label>

    </asp:HyperLink> 
</li>--%>

</ul>
</div>