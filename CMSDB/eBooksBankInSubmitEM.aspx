<%@ Page Title="" Language="C#" MasterPageFile="~/UserEbookMaster.master" AutoEventWireup="true" CodeFile="eBooksBankInSubmitEM.aspx.cs" Inherits="eBooksBankInSubmitEM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

    <link href="App_Themes/Default/eBookPage.css" rel="stylesheet" />
   <link href="App_Themes/Default/EbHomePageStyles.css" rel="stylesheet" />


    <style type="text/css">
table.gridtable {
	font-family: verdana,arial,sans-serif;
	font-size:11px;
	color:#333333;
	border-width: 1px;
	border-color: #666666;
	border-collapse: collapse;
}
table.gridtable th {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #dedede;
}
table.gridtable td {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #ffffff;
}
</style>


    <style type="text/css">

 .CssdvBookImage 
{
    border: 1px dotted #BAC0C7;
    padding: 10px; 
    width : 300px;
    height: 300px;
    margin: 2px;
    align-content: center;

    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;

}

 .imgBankLogo {
      max-width: 150px;
      max-height: 70px;

 }

 .bkImageCss {
    max-width: 220px;
    max-height: 270px;
}


  .CssdvBookDetails
{
    border: 1px dotted #BAC0C7;
    padding: 10px; 
    width : 80%;
    height: 100%;
    margin: 2px;
    align-content: center;

    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;

}

.reqFieldCSS { font-size: 14px; color: red;}


.cssdvBookDescription
{
    border: 1px dotted #BAC0C7;
    padding: 10px; 
    width : 970px;
    min-height: 450px; 
    margin: 5px;
    align-content: center;

    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;
}


.BkfontTitle		{ FONT-SIZE: 14px; COLOR: #296692; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; font-weight: bold;}
.BkfontNote		    { FONT-SIZE: 10px; COLOR: #E75151; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; }
.BkfontDescription		{ FONT-SIZE: 14px; COLOR: #296692; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; text-align: justify; letter-spacing: 0.05em; text-align-last: center; word-spacing: 0.05em;
                          
}

         .FontWaiting { color: indianred; font: bold 150%/100% "Trebuchet MS","Lucida Console", Arial, sans-serif; 
                         background-color:#FFFFFF; line-height: 150px; padding: 20px;

                        -webkit-border-radius: 6px;                         
						 -moz-border-radius: 6px;						 
						 border-radius: 6px;

         }

.BkFontBHeader          {color: #687367; font-style:italic; font: bold 110%/100% "Trebuchet MS","Lucida Console", Arial, sans-serif; 
                        margin: 30px 0 50px; vertical-align:middle; background-color:#AFD4CF; line-height: 30px; padding-left: 5px;
                         -webkit-border-radius: 6px;                         
						 -moz-border-radius: 6px;						 
						 border-radius: 6px;
					     }

.bkFormLabel   { background-color: #F9D0AC; border-bottom: solid 1pt #CCAB71; font-variant: small-caps; color: #4E5163; font: bold 14px "Trebuchet MS","Lucida Console", Arial, sans-serif; height:35px; padding-left:10px; text-align:left;}
.bkFormText    { background-color: #FFE6CF; border-bottom: solid 1pt #CCAB71; border-left: solid 1pt #C9E9ED;   font-size: 14px; color: #4E5163; height:35px; padding-left: 20px;}

.bkFormText1Help {background-color: #CCAB71; border-bottom: solid 1pt #D4DFAA; border-left: solid 1pt #D4DFAA;   font-size: 10px; color: #5C80A8; height:35px; padding-left: 20px; vertical-align: bottom;}


.stdbuttonBuy            
{   border-right: 1px solid #dedede;
    border-bottom: 1px solid #dedede;
    filter:progid:DXImageTransform.Microsoft.Gradient(GradientType=0,StartColorStr=#76E28A,EndColorStr=#BAE2C2);
    background-color:#FEA854;letter-spacing: 1px;cursor:pointer;
    font-size:120%;line-height:100%; 
    border-top:1px solid #999999; border-left:1px solid #999999;
    font-family:  'Exo', Arial, Verdana, sans-serif; font-variant:small-caps;
    text-decoration:none; font-weight:bold; color:#FFFFB8;
    padding: 10px 25px;
    height: 42px;
     text-shadow: 			rgba(0,0,0,1) 0 1px 0;
    -webkit-border-radius: 6px;                         
    -moz-border-radius: 6px;						 
    border-radius: 6px;


}
    
.stdbuttonBuy button  { width:auto;    overflow:visible;    padding:4px 10px 3px 7px; /* IE6 */}    
.stdbuttonBuy:hover, .buttons a:hover   {background-color:#dff4ff; border:1px solid #c2e1ef; color:#336699;}
.stdbuttonBuy a:active   {background-color:#6299c5; border:1px solid #6299c5; color:#fff;}


.CssdvBookPurchase
{
    border: 1px solid #BAC0C7;
    position: relative;
    margin: 5px 0;
    padding: 10px 15px;
    background-color: #eef4f9;

    /* easy rounded corners for modern browsers */
    -moz-border-radius: 6px;
    -webkit-border-radius: 6px;
    border-radius: 6px;

    width: 480px;
    height: 72px;
    float: left; 
    margin-left: 10px;


    
}

.CssdvBookPurchase22
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
    height: 72px;
    float: left; 
    margin-left: 10px;


    
}

.bkPurchase_format {
    font: bold 100%/100%  "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #FF3000;
     text-shadow: 1px 0px 1px rgba(170, 170, 170, 1);
	letter-spacing: 1px;
	text-transform: capitalize;
    padding: 2px 5px;

}


.bkPurchase_send { 
    font: bold 11px verdana, "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #E91DEB; text-align: right; 
}

.bkPurchase_header { 
    font: bold 11px  Arial, sans-serif; color: #922EC5; text-align: left; 
}


.bkPurchase_Note { 
    font: 10px Arial, sans-serif; color: #9F4D11; text-align: left; padding-top: 2px; font-size-adjust:inherit;
}



 

.ebImageBox { width: 180px; }
.ebDescriptionBox { width: 650px; }
.ebDetailsBox { width: 270px; }

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




.ebImgHomeCss {

   background-color : transparent;
    max-width: 165px;
    max-height: 205px;
    padding-right: 30px; 
}

.ebDvImageBox {

    -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=50)";       /* IE 8 */
filter: alpha(opacity=50);  /* IE 5-7 */
-moz-opacity: 0.5;          /* Netscape */
-khtml-opacity: 0.5;        /* Safari 1.x */
opacity: 0.5; 
}


         #dvBookContainer22 {
             height: 566px;
         }


         </style>


    <style type="text/css"> 

          .FontWaiting { color: indianred; font: bold 150%/100% "Trebuchet MS","Lucida Console", Arial, sans-serif; 
                         background-color:#FFFFFF; line-height: 150px; padding: 20px;

                        -webkit-border-radius: 6px;                         
						 -moz-border-radius: 6px;						 
						 border-radius: 6px;

         }

      .LockOff { 
         display: none; 
         visibility: hidden; 
      } 

      .LockOn { 
         display: block; 
         visibility: visible; 
         position: absolute; 
         z-index: 999; 
         top: 0px; 
         left: 0px; 
         width: 105%; 
         height: 105%; 
         background-color: #ccc; 
         text-align: center; 
         padding-top: 20%; 
         filter: alpha(opacity=75); 
         opacity: 0.75; 
      } 
   </style> 

   <script type="text/javascript">
       function skm_LockScreen(str) {
           //alert('showing');
           var lock = document.getElementById('skm_LockPane');
           if (lock)
               lock.className = 'LockOn';

           // lock.innerHTML = str;
       }
   </script> 
 <div id="skm_LockPane" class="LockOff">

       <span class="FontWaiting">Please wait while we navigate you to PayPal Site... </span>

   </div>  

    <%--<form id="frmTest" runat="server">--%>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>

            <td width="20px"></td>
            <td align="right" >
               

                &nbsp;</td>
            <td align="right" >
               

                &nbsp;</td>
        </tr>
        <%--        <tr style="height:40px;">
            <td>
              
            </td>
        </tr>--%>

        
        <tr>
            <td valign="top">
    
            </td>
            <td valign="top" align="center">
                <div id="dvRightContent" style="padding-left: 10px;" runat="server">


                    <div id="dvBookDetails" class="CssdvBookDetails" runat="server">

                                       <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                          


                                           <tr>
                                              <td width="25%" class="bkFormLabel">&nbsp;</td>
                                              <td width="75%" class="bkFormText" align="left">
                                                  
                                                 <span class="cssfaq_head">Bank-In Details Submission Form</span> 

                                              </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">&nbsp;</td>
                                              <td class="bkFormText" align="left">
                                                  
                                                  &nbsp;</td>
                                          </tr>

                                                 <tr>
                                              <td class="bkFormLabel">Vendor Email Id</td>
                                              <td class="bkFormText" align="left">
                                                  
                                                   <asp:Label ID="lblVendorEmail" CssClass="fontEBName" runat="server"></asp:Label>
                                                   </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Vendor Mobile No.</td>
                                              <td class="bkFormText" align="left">
                                                  
                                                   <asp:Label ID="lblVendorMobile" CssClass="fontEBName" runat="server"></asp:Label>
                                                   </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel" align="right">&nbsp;</td>
                                              <td class="bkFormText" align="left">
                                                  
                                                  <span class="BkfontNote">
                                                   <strong>NOTE</strong> :
                                                   Any enquires / difficulties pertaining to purchase, please contact the vendor by mobile or email.
                                                      </span>
                                                      </td>
                                          </tr>


                                           <tr>
                                              <td class="bkFormLabel">&nbsp;</td>
                                              <td class="bkFormText" align="left">
                                                  
                                                  &nbsp;</td>
                                          </tr>


                                           <tr>
                                              <td class="bkFormLabel">&nbsp;</td>
                                              <td class="bkFormText" align="left">
                                                  
                                                  <span class="font_12BlueBold">   Please Key In the Transaction Reference Number for easier Tracking, Please fill up the form below :-  </span>

                                              </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Transaction Reference ID:</td>
                                              <td class="bkFormText" align="left">
                                                  
                                                   <asp:TextBox ID="txtTransactionID" runat="server" CssClass="stdTextField1" ValidationGroup="VgCheck"></asp:TextBox>
                                                   </td>
                                          </tr>

                                          
                                           <tr>
                                              <td class="bkFormLabel">Select Bank <span class="reqFieldCSS">*</span></td>
                                              <td class="bkFormText"  align="left">
                                                  
                                                   <asp:DropDownList ID="ddlBanks" CssClass="stdDropDown2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBanks_SelectedIndexChanged" ValidationGroup="VgCheck">
                                                   </asp:DropDownList>
                                                   &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlBanks" ValidationGroup="VgCheck" InitialValue="0"  runat="server" CssClass="font_11Msg_Error"
                                                        ErrorMessage="Please Select a Bank"></asp:RequiredFieldValidator>
                                                  <br />
                                                   <div id="dvSelBankDetails" runat="server" visible="false">
                                                      <asp:Image ID="ImgBank" CssClass="imgBankLogo" runat="server" />
                                                      <br />
                                                       <asp:Label ID="lblBankActName" CssClass="fontCurrency" runat="server" Text=""></asp:Label>
                                                      <br />
                                                       <asp:Label ID="lblBankActNo" CssClass="fontCurrency" runat="server" Text=""></asp:Label>
                                                      <br />
                                                      <asp:Label ID="lblCountry" CssClass="fontCurrency" runat="server" Text=""></asp:Label>&nbsp; <asp:Image ID="ImgCountryFlag" runat="server" />
                                                      <br />
                                                      <asp:Label ID="lblSwiftCode" CssClass="fontCurrency" runat="server" Text=""></asp:Label>

                                                  </div>

                                                </td>
                                          </tr>

                                            <tr>
                                              <td class="bkFormLabel">Full Name&nbsp; <span class="reqFieldCSS">*</span></td>
                                              <td class="bkFormText" align="left">
                                                  
                                                   <asp:TextBox ID="txtBankinBy" runat="server" CssClass="stdTextField1" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtBankinBy" ValidationGroup="VgCheck"  runat="server" CssClass="font_11Msg_Error" ErrorMessage="Full Name cannot be Empty"></asp:RequiredFieldValidator>
                                                   </td>
                                          </tr>


                                           <tr>
                                              <td class="bkFormLabel">Amount Banked In <span class="reqFieldCSS">*</span></td>
                                              <td class="bkFormText"  align="left">
                                                  
                                                   <asp:TextBox ID="txtBankInAmount" runat="server" CssClass="stdTextField1" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtBankInAmount" ValidationGroup="VgCheck"  runat="server" CssClass="font_11Msg_Error" ErrorMessage="Amount cannot be Empty"></asp:RequiredFieldValidator>
                                                </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Banked In Date <span class="reqFieldCSS">*</span></td>
                                              <td class="bkFormText" align="left">
                                                  
                                                   <asp:TextBox ID="txtBankInDate" runat="server" CssClass="stdTextField1" ValidationGroup="VgCheck"></asp:TextBox>
                                                   <asp:CalendarExtender ID="txtBankInDate_CalendarExtender" runat="server" Enabled="True" PopupPosition="TopRight" TargetControlID="txtBankInDate" TodaysDateFormat="MM/dd/yyyy">
                                                   </asp:CalendarExtender>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtBankInDate" ValidationGroup="VgCheck"  runat="server" CssClass="font_11Msg_Error" ErrorMessage="BankIn Date cannot be Empty"></asp:RequiredFieldValidator>
                                                </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Banked in Time <span class="reqFieldCSS">*</span></td>
                                              <td class="bkFormText"  align="left">
                                                  
                                                   <asp:TextBox ID="txtBankInTime" runat="server" CssClass="stdTextField1" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtBankInTime" ValidationGroup="VgCheck"  runat="server" CssClass="font_11Msg_Error" ErrorMessage="BankIn Time cannot be Empty"></asp:RequiredFieldValidator>
                                                </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Bank In Reference&nbsp; </td>
                                              <td class="bkFormText"  align="left">
                                                  
                                                   <asp:TextBox ID="txtBankInRef" runat="server" CssClass="stdTextField1" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Upload Bank-In Slip</td>
                                              <td class="bkFormText"  align="left">
                                                  
                                                   <asp:FileUpload ID="UploadImgCtrl" runat="server" />
                                                   &nbsp;

                            <asp:Label ID="lblErrorImg" CssClass="font_12Msg_Error" runat="server" Text=""></asp:Label>
                                                   <br />

                            <asp:RegularExpressionValidator ID="FileUploadValidator"  runat="server"  ValidationGroup="VgCheck" Display="Dynamic"
                                ControlToValidate="UploadImgCtrl" ErrorMessage="Only jpg, gif or Png type images are allowed.<br> Please select another image." 
                                ValidationExpression="^.*\.(jpg|JPG|gif|GIF|png|PNG)$" Enabled="true" CssClass="font_11Msg_Error"></asp:RegularExpressionValidator>

                           
                             &nbsp;<asp:CustomValidator ID="CustomValidator_BookImage" runat="server" ControlToValidate="UploadImgCtrl" Display="Dynamic" ValidationGroup="VgCheck"
                                                                    ErrorMessage="" OnServerValidate="CustomVdr_eBookImage_ServerValidate" CssClass="font_11Msg_Error"></asp:CustomValidator>
                            

                                                   </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Purchase Description</td>
                                              <td class="bkFormText"  align="left">
                                                  
                                                   <asp:TextBox ID="txtBankInDesc" runat="server" CssClass="stdTextArea1" Rows="5" TextMode="MultiLine" ValidationGroup="VgCheck" Width="420px"></asp:TextBox>
                                                   </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">&nbsp;</td>
                                              <td class="bkFormText"  align="right">
                                                  
                                                   <asp:LinkButton ID="lnkPrintForm0" OnClientClick="window.print();" CssClass="links_TopLine" runat="server">[ Print Form ]</asp:LinkButton>
                                               </td>
                                          </tr>

                                             <tr>
                                               <td colspan="2" align="center">
                                                   <%--      <asp:Button ID="buttonBuy" runat="server" CssClass="stdbuttonBuy" Text="Confirm Buy" OnClientClick="skm_LockScreen('Please wait while we take you to PayPal Site...');" ValidationGroup="VgCheck" OnClick="buttonBuy_Click" />--%>&nbsp;&nbsp;
                                                    </td>
                                           </tr>
                                           <tr>
                                               <td colspan="2" align="center">

                                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="stdbuttonBuy" Text="Submit Bank-In Details" OnClick="BtnSubmit_Click" />
                                                 </td>
                                           </tr>

                                           <tr>
                                               <td colspan="2" class="font_11Msg_Error">

                                          

                                                   &nbsp;</td>
                                           </tr>

                                          

                                           <tr>
                                               <td colspan="2">&nbsp;</td>
                                           </tr>
                                      </table>

                                     

                                 </div>


                </div>

                


            </td>
            <td valign="top">
                &nbsp;</td>
        </tr>


    <%--    <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>--%>


       <tr>
            <td>
                &nbsp;</td>
            <td align="center" valign="middle">
                &nbsp;

             


            </td>
        </tr>


       <tr>
            <td>
                &nbsp;</td>
            <td align="center" valign="middle">


                    <div id="dvInVoice" class="CssdvBookDetails" runat="server" visible="false">

                                       

                                     

                        <table class="style1">
                            <tr>
                                <td width="35%">&nbsp;</td>
                                <td  width="65%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="BkFontBHeader" colspan="2">&nbsp;Direct Bank-In Invoice </td>
                               
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDateTime" CssClass="font_12BoldGrey" runat="server"></asp:Label>
                                </td>
                                <td>Transaction ID :
                                    <asp:Label ID="lblTransactionID" CssClass="font_12BlueBold" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;<hr />&nbsp;</td>
                                
                            </tr>

                           <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblInvoiceHeader2" CssClass="font_12BlueBold" runat="server"></asp:Label>
                                </td>
                                
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                             <tr>
                                <td colspan="2" class="fontDescription">
                                   
                                    Thank you for your purchase!.&nbsp; The following is an invoice detailing your transaction details.&nbsp;
                                    <br />
                                    Please print or save a copy of this invoice for your records.
                                    <br />
                                    <br />
                                    For any further queries , please let us know.
                                   
                                </td>
                                
                            </tr>

                             <tr>
                                <td colspan="2">&nbsp;<hr />&nbsp;</td>
                                
                            </tr>

                             <tr>
                                <td colspan="2">




                                    <table class="gridtable" width="80%">
                                        <tr>
                                            <th width="70%">Description</th>
                                            <th width="30%">Price</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblItemsDesc" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblItemsPrice" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Total : </td>
                                            <td>
                                                <asp:Label ID="lblItemsPriceTotal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>




                                </td>
                                
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            </table>

                                       

                                     

                    </div>




            </td>
        </tr>


    </table>
        


</td>
</tr>

</table>
    <%--</form>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    </asp:Content>

