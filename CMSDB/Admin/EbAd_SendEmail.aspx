<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_SendEmail.aspx.cs" Inherits="Admin_EbAd_SendEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


.bkFormLabel   { background-color: #E8F0F1; border-bottom: solid 1pt #C9E9ED; font-variant: small-caps; color: #4E5163; font: bold 14px "Trebuchet MS","Lucida Console", Arial, sans-serif; height:35px; padding-left:10px; text-align:left;}
.bkFormText    { background-color: #F1F8F9; border-bottom: solid 1pt #C9E9ED; border-left: solid 1pt #C9E9ED;   font-size: 14px; color: #4E5163; height:35px; padding-left: 20px;}



.CssdvBookPurchase
{
    border: 1px solid #BAC0C7;
    position: relative;
    margin: 5px 0;
    padding: 10px 15px;
    background-color: #F3C89E;

     background: -webkit-gradient(linear, left top, left bottom, from(#FF9D6D), to(#F3C89E)); /* for webkit browsers */
    background: -moz-linear-gradient(top,  #FF9D6D,  #F3C89E); /* for firefox 3.6+ */
    filter:progid:DXImageTransform.Microsoft.Gradient(StartColorStr=#FF9D6D,EndColorStr=#F3C89E,GradientType=0);

    /* easy rounded corners for modern browsers */
    -moz-border-radius: 6px;
    -webkit-border-radius: 6px;
    border-radius: 6px;

    width: 480px;
    height: 51px;
    float: left; 
    margin-left: 10px;


    
}

.Purchase_header { 
    font: bold 11px  Arial, sans-serif; color: #922EC5; text-align: left; 
}



.Purchase_format {
    font: bold 100%/100%  "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #FF3000;
     text-shadow: 1px 0px 1px rgba(170, 170, 170, 1);
	letter-spacing: 1px;
	text-transform: capitalize;
    padding: 2px 5px;

}


.Purchase_send { 
    font: bold 11px verdana, "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #E91DEB; text-align: right; 
}


.Purchase_Note { 
    font: 10px Arial, sans-serif; color: #9F4D11; text-align: left; padding-top: 2px; font-size-adjust:inherit;
}

 .bkImageCss {
    max-width: 300px;
    max-height: 450px;
}


  .ebHeaderBox {
    width: 1160px;
    height: 30px;
    border: 1px dotted #BAC0C7;
     padding: 5px; 
      margin: 2px;
       background-color: #EEFAFE;
     -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;
}




.ebHeaderBox {
    width: 1160px;
    height: 30px;
    border: 1px dotted #BAC0C7;
     padding: 5px; 
      margin: 2px;
       background-color: #EEFAFE;
     -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;
}


.eb_head        { height: 40px; border-bottom: solid 3px #FAC96B; font: bold 120%/100% "Trebuchet MS","Lucida Console", Arial, sans-serif;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <div id="divLeftMenu" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
<form id="tForm" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>&nbsp;</td>
        </tr>
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
                <table cellpadding="0" cellspacing="0" border="0" width="96%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; Send SMS to Mobile Contact&nbsp; </td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <%--<asp:PlaceHolder ID="tblSendSMS" runat="server">--%>
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">                    
                    <tr>
                        <td width="2%">
                            &nbsp;</td>
                        <td width="25%">
                            &nbsp;</td>
                        <td width="60%">
                            &nbsp;</td>
                        <td width="15%">
                            &nbsp;</td>
                    </tr>
                    <tr><td colspan="4" align="left"><div id="dvEbHeader" class="ebHeaderBox" runat="server">
                       <asp:Label ID="lblHeader" CssClass="eb_head" runat="server" Text=""></asp:Label>
                   </div></td></tr>
                    <%--<tr>
                        <td>
                            &nbsp;</td>
                        <td >
                               <asp:Literal ID="Literal3" runat="server" 
                                Text="<%$ Resources:LangResources, Events %>"></asp:Literal>
                                &nbsp;
                                 <asp:Literal ID="Literal4" runat="server" 
                                Text="<%$ Resources:LangResources, Date %>"></asp:Literal></td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEvtDate" CssClass="stdTextField1" runat="server"></asp:TextBox>
                            <a href="javascript:ShowCal('<%=txtEvtDate.ClientID%>');">
                            <asp:Image ID="ImgCal" runat="server" BorderStyle="None" 
                                ImageUrl="~/Images/cal.gif" /></a>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                                        
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" align="left">
                                       <asp:Image ID="ImgEbook" CssClass="bkImageCss" ImageUrl="" runat="server" />
                                 </td>
                        <td class="tblFormText1" align="left">

                                       <table border="0" cellpadding="0" cellspacing="0" width="95%">
                                          <tr>
                                              <td width="100px" class="bkFormLabel">Book ID:</td>
                                              <td width="150px" class="bkFormText"> <asp:Label ID="lblBookID" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Book Name:</td>
                                              <td class="bkFormText"> <asp:Label ID="lblBookName" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Category:</td>
                                              <td class="bkFormText"> <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Date Added:</td>
                                              <td class="bkFormText"> <asp:Label ID="lblDateAdded" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Email to</td>
                                              <td class="bkFormText"> <asp:Label ID="LabelEmailIdVal" runat="server" Text=""/></td>
                                          </tr>
                                </table>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                     
                   
                     <%--<tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Merchant Code :</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelMerchantCodeVal" runat="server" CssClass="SearchLabelBold" 
                                Text=""/>
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>--%>
                   
                     <%--<tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            Sender Mobile ID</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelSenderIDVal" runat="server" CssClass="SearchLabelBold" 
                                Text=''/>&nbsp;
                <asp:Label ID="LabelSenderIDMsg" runat="server" CssClass="" Text="Note: will always take latest sender id on the schedule date."/>
                </td>
                        <td align="left" class="tblFormText1">
                            &nbsp;</td>
                    </tr>--%>
                   
                     <%--<tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            SMS Balance :</td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelSMSBalanceVal" runat="server" CssClass="SearchLabelBold" 
                                Text=""/>
                            &nbsp;SMS Credits</td>
                        <td  align="left" class="tblFormText1">
                            &nbsp;</td>
                    </tr>--%>
                   
                     <%--<tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            SMS Credit Charges : </td>
                        <td class="tblFormText1" align="left">
                            <asp:Label ID="LabelSMSCreditChgs" runat="server" CssClass="SearchLabelBold" 
                                Text="0.5"/>&nbsp;SMS Credits
                            </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>--%>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            <asp:Button ID="BtnSendBookNow" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonCRUD" 
                                Text="Send EBook Now" onclick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="stdbuttonCRUD" 
                                Text="Cancel" onclick="btnCancel_Click" />
                                </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td>
                     &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <%--</asp:PlaceHolder>--%>
            </td>
        </tr>
        </table>
                
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>

