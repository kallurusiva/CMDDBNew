<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EBLeftMenu_SMSPayment.ascx.cs" Inherits="Admin_EBLeftMenu_SMSPayment" %>

<div id='leftmenu'>
<ul>

<li><span class="subheader"><img src="../../Images/WebPortal/Products.png" /><asp:Literal ID="Literal1" runat="server" Text="SMS Profit Sharing"></asp:Literal> </span></li>
<li id="li_Profit" runat="server"> <a href="ProfitSharingOverAll.aspx"><asp:Label ID="lblOverAllProfitSummary" runat="server" Text="OverAll Profit Summary"></asp:Label></a> </li>
<li id="li_Current" runat="server"> <asp:HyperLink ID="HypCurrentMonth" CssClass="LiCon add" runat="server" Text="Current Month" NavigateUrl="~/Admin/EbAd_CurrentMonthProfit.aspx"></asp:HyperLink> </li>

<li>&nbsp;</li>
<li><span class="subheader"><img src="../Images/WebPortal/webTemplate.png" /><asp:Literal ID="Literal2" runat="server" Text="Country-wise Summary" ></asp:Literal> </span></li>
 

                  
            <%--<li><a href="ProfitSharingOverAllCountry.aspx?CCode=61"><asp:Label ID="lblAustralia" runat="server" Text="Australia"></asp:Label></a></li> --%>           
        
                  
            <%--<li><a href="ProfitSharingOverAllCountry.aspx?CCode=86"><asp:Label ID="lblChina" runat="server" Text="China"></asp:Label></a></li>           --%> 
                
                  
            <li><a href="ProfitSharingOverAllCountry.aspx?CCode=62"><asp:Label ID="lblIndonesia" runat="server" Text="Indonesia"></asp:Label></a></li>            
              
            <li><a href="ProfitSharingOverAllCountry.aspx?CCode=60"><asp:Label ID="lblMalaysia" runat="server" Text="Malaysia"></asp:Label></a></li>            
                
            <li><a href="ProfitSharingOverAllCountry.aspx?CCode=63"><asp:Label ID="lblPhilippines" runat="server" Text="Philippines"></asp:Label></a></li>            
                
            <li><a href="ProfitSharingOverAllCountry.aspx?CCode=65"><asp:Label ID="lblSingapore" runat="server" Text="Singapore"></asp:Label></a></li>            
                
            <li><a href="ProfitSharingOverAllCountry.aspx?CCode=66"><asp:Label ID="lblThailand" runat="server" Text="Thailand"></asp:Label></a></li>            
                 
            <%--<li><a href="ProfitSharingOverAllCountry.aspx?CCode=44"><asp:Label ID="lblUnitedKingdom" runat="server" Text="UnitedKingdom"></asp:Label></a></li> --%>           
                
            <li><a href="ProfitSharingOverAllCountry.aspx?CCode=84"><asp:Label ID="lblVietname" runat="server" Text="Vietnam"></asp:Label></a></li>            
        

<li>&nbsp;</li>
<li><span class="subheader"><img src="../Images/WebPortal/webTemplate.png" /><asp:Literal ID="Literal4" runat="server" Text="Monthly Statement" ></asp:Literal> </span></li>

<li><a href="ProfitSharingShortCodeWise.aspx"><asp:Label ID="Label3" runat="server" Text="Monthly Satement"></asp:Label></a></li>             

<li>&nbsp;</li>
<li><span class="subheader"><img src="../Images/WebPortal/webTemplate.png" /><asp:Literal ID="Literal3" runat="server" Text="SMS Payment Details" ></asp:Literal> </span></li>

<%--<li id="li_View" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon add" runat="server" Text="Bank Details" NavigateUrl="~/Admin/EbAd_BankInfo.aspx"></asp:HyperLink> </li>--%>
    <li id="li_View" runat="server"> <asp:HyperLink ID="HyperLink2" CssClass="LiCon add" runat="server" Text="Bank Details" NavigateUrl="~/Admin/SMSPay_BankIn_Add.aspx"></asp:HyperLink> </li>
<li id="li_Request" runat="server"> <asp:HyperLink ID="HypPayRequest" CssClass="LiCon add" runat="server" Text="Payment Request" NavigateUrl="~/Admin/ProfitSharingRequestPayment.aspx"></asp:HyperLink> </li>
<li id="li_Payment" runat="server"> <asp:HyperLink ID="HypPayment" CssClass="LiCon add" runat="server" Text="Payment History" NavigateUrl="~/Admin/ProfitSharingRequestPaymentHistory.aspx"></asp:HyperLink> </li>


</ul>
</div>