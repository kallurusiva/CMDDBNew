<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ads_EmailPage.aspx.cs" Inherits="Admin_Ads_EmailPage" %>


<%@ Register src="EBLeftMenu_PayPalCC.ascx" tagname="EBLeftMenu_PayPalCC" tagprefix="uc1" %>


<%@ Register src="LeftMenu_WebSettings.ascx" tagname="LeftMenu_WebSettings" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 18px;
        }
        .style2
        {
            background-color: #E2E6DC;
            border-bottom: solid 1pt #D4DFAA;
            font-variant: small-caps;
            color: #4E5163;
            height: 18px;
            padding-right: 20px;
            text-align: right;
            font-variant: normal;
            font-style: normal;
            font-weight: bold;
            font-size: 105%;
            line-height: 100%;
            font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
        }
        .style3
        {
            background-color: #EEEFEB;
            border-bottom: solid 1pt #D4DFAA;
            border-left: solid 1pt #D4DFAA;
            font-size: 12px;
            color: #4E5163;
            height: 18px;
            padding-left: 20px;
        }
        .style4
        {
            width: 3%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:LeftMenu_WebSettings ID="LeftMenu_WebSettings1" runat="server" />
    
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <form id="form2" runat="server">



    <table border="0" cellpadding="0" cellspacing="0" width="90%" align="center">
              
        <tr style="height:20px">
            <td align="center">
            
                &nbsp;</td>
        </tr>
              
        <tr style="height:20px">
            <td align="right">
            <%--<asp:HyperLink ID="HypBackToWP"  CssClass="small green awesome" NavigateUrl="~/Admin/Ad_Welcome.aspx" Text = "Back to WebPortal"  runat="server" />--%>
            &nbsp;&nbsp;&nbsp;
             </td>
        </tr>
        <tr>
            <td align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" class="tblSubHeader">
                  <tr>
                     
                        <td width="90%" align="left" class="subHeaderFontGrad">
                                                        &nbsp; Email System&nbsp;</td>
                       
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="100%" runat="server">
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td width="70%">&nbsp;
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr id="trPlatinum" runat="server" visible="false">
                        <td class="style4">
                            &nbsp;</td>
                        <td align="left">
                        <table class="style1" id="tblButtonInfo" width="100%">
                                <%--<tr>
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
                                </tr>--%>
                                <tr>
                                    <td  width="25%">
                                        &nbsp;</td>
                                    <td  width="75%">
                                      <%-- <asp:Image ID="ImgEmailLogo" runat="server" />  --%>      
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        <font class="font_12Msg_Success">Mail&nbsp; details </font>:- </td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;Admin Email ID:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdEmailID" runat="server" Text='<%# Eval("AdSenseID")  %>' CssClass="stdTextField1" 
                                            Width="350px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Admin Password:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtEmailPwd" runat="server" Text='<%# Eval("AdSensePwd")  %>' CssClass="stdTextField1" 
                                            Width="350px" Enabled="False"></asp:TextBox>
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
                                        Enquiry Email ID:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtEnquiryID" runat="server" 
                                            Text='<%# Eval("AdSenseID")  %>' CssClass="stdTextField1" 
                                            Width="350px" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Enuiry Password:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtEnquiryPwd" runat="server" 
                                            Text='<%# Eval("AdSenseID")  %>' CssClass="stdTextField1" 
                                            Width="350px" Enabled="False" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        </td>
                                    <td class="style3">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        Http Link to 
                                        <br />
                                        Manage your Mails:</td>
                                    <td class="tblFormText1">
                                       <%-- <asp:TextBox ID="txtHttpUrlLink" runat="server" 
                                            Text='<%# Eval("AdSenseID")  %>' CssClass="stdTextField1" 
                                            Width="350px" Enabled="False" ></asp:TextBox>--%>
                                        <asp:HyperLink ID="HypGmailLink" Target="_blank" runat="server" CssClass="links_AnchorDomains2"></asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="font_11Msg_Error" style="border: dashed 1px #D80000;" >
                                        <ol>
                                            <li><font class="font_11Msg_Error">This Facility is available Only for <b>Platinum 
                                                Partners</b> , <b>Own Domain and WEBEmailSMS</b> Users. </font></li>
                                            <li>Only 3 Free emails are allowed. We have created 2 basic emails. </li>
                                            <li>To Create additional emails follow the http link given above and login 
                                                using Admin Mail ID.</li>
                                            <li>Additional emails for ZOHO are charged at USD $2 / user / month.</li>
                                            <li>Charges for additional emails are not related to us. we only do the Email setup. </li>
                                            <%--<li>Need to login using full admin id at Google.&nbsp; e.g.&nbsp;&nbsp; UserName : 
                                                <asp:HyperLink ID="HypAdminLoginID" CssClass="links_FuncLinks" runat="server"></asp:HyperLink></li>--%>
                                            <li>You can change password anytime but please do remember the password, as our 
                                                records will not reflect your latest password and we will not have any access 
                                                anymore. </li>
                                        </ol>
                        
                    </td>
                                </tr>
                            </table>
                        
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr id="trUnPlatinum" runat="server" visible="false">
                    <td class="style4">
                            &nbsp;</td>
                        <td class="font_11Msg_Error" style="border: dashed 1px #D80000;">
                                        <ul>
                                            <li><font class="font_12Msg_Error">This Facility is available only for <b>Platinum 
                                                Partners</b> and <b>Own Domain</b> Users. </font></li>
                                           
                                        </ul>
                        
                    </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr id="trNotPurchased" runat="server" visible="false">
                    <td class="style4">
                            &nbsp;</td>
                        <td class="font_11Msg_Error" style="border: dashed 1px #D80000;">
                                        <ul>
                                            <li><font class="font_12Msg_Error">You have not purchased the <b>EMAIL SYSTEM</b>. </font></li>

                                        </ul>
                        
                    </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr id="trAlertEmailSystem" runat="server" visible="false">
                    <td class="style4">
                            &nbsp;</td>
                        <td class="font_11Msg_Error" style="border: dashed 1px #D80000;">
                                        <ul>
                                            <li><font class="font_12Msg_Error">
                                                <asp:Literal ID="ltrNotPurchasedMsg" Text="" runat="server"></asp:Literal>
                                            <%--The <b>EMAIL SYSTEM</b> for your account is under progress. <br />
                                                It will take 10 working days from the date of your purchase to verify and activate your email system.--%>
                                            
                                            </font></li>

                                        </ul>
                        
                    </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    
                    
                    </table>
            </td>
        </tr>
        </table>
                
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

    </form>
    
</asp:Content>

