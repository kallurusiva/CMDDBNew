<%@ Page Title="" Language="C#" MasterPageFile="~/UserEbookMaster.master" AutoEventWireup="true" CodeFile="eBooksBuyPP.aspx.cs" Inherits="eBooksBuyPP" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

    <link href="App_Themes/Default/eBookPage.css" rel="stylesheet" />
   <link href="App_Themes/Default/EbHomePageStyles.css" rel="stylesheet" />

     <style type="text/css"> 
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

 .bkImageCss {
    max-width: 220px;
    max-height: 270px;
}


  .CssdvBookDetails
{
    border: 1px dotted #BAC0C7;
    padding: 10px; 
    width : 650px;
    height: 450px;
    margin: 2px;
    align-content: center;

    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;

}


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


         .auto-style1 {
             height: 19px;
         }


         #dvBookContainer22 {
             height: 566px;
         }


         </style>
    
   <div id="skm_LockPane" class="LockOff">

       <span class="FontWaiting">Please wait while we navigate you to PayPal Site... </span>

   </div> 

    <%--<form id="frmTest" runat="server">--%>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>

            <td width="150px"></td>
            <td ></td>
        </tr>
   
        
        <tr>
            <td valign="top">
                 
                <div id="dvLeftContent" class="ribbon" style="width: 180px;" runat="server">
                   
                </div>
            </td>
            <td valign="top">
                <div id="dvRightContent" style="padding-left: 10px;" runat="server">

                    <div id="dvEbHeader" class="ebHeaderBox" runat="server">
                       <asp:Label ID="lblHeader" CssClass="eb_head" runat="server" Text=""></asp:Label>
                   </div>

                    <div id="dvBookContainer22">

                     <table border="0" cellpadding="0" cellspacing="0" >

                         <tr>
                             <td align="center">
                                 <%--Book Image Goes Here--%>
                                 <div id="dvBookImage" class="CssdvBookImage">
                                       <asp:Image ID="ImgEbook" CssClass="bkImageCss" ImageUrl="" runat="server" />
                                 </div>


                             </td>
                             <td>
                                 <%--Book Details Goes Here--%>
                                 <div id="dvBookDetails" class="CssdvBookDetails">

                                       <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 535px">
                                          <tr>
                                              <td width="100px" class="bkFormLabel">eBook Code:</td>
                                              <td width="150px" class="bkFormText"> <asp:Label ID="lblBookID" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">eBook Name:</td>
                                              <td class="bkFormText"> <asp:Label ID="lblBookName" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Category:</td>
                                              <td class="bkFormText"> <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Pay Price :</td>
                                              <td class="bkFormText"> 
                                                  <asp:Label ID="lblNetPrice" runat="server"></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Pay Currency:</td>
                                              <td class="bkFormText">
                                                  
                                                   <asp:Label ID="lbluCurrency" CssClass="fontCurrency"  runat="server"></asp:Label>
                                                  &nbsp;
                                                   </td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">&nbsp;</td>
                                              <td class="bkFormText">
                                                  
                                                   &nbsp;</td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Enter Name</td>
                                              <td class="bkFormText">
                                                  
                                                   <asp:TextBox ID="txtBuyerName" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                                   &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="VgCheck" ControlToValidate="txtBuyerName" CssClass="font_11Msg_Error" ErrorMessage="Name cannot be Empty"></asp:RequiredFieldValidator>
                                                   </td>
                                          </tr>

                                            <tr>
                                              <td class="bkFormLabel">&nbsp;</td>
                                              <td class="bkFormText" style=" vertical-align: bottom;"> 
                                                  &nbsp;
                                                 <span class="BkfontNote">Ebook would be sent to this email address. </span>  </td>
                                          </tr>

                                            <tr>
                                              <td class="bkFormLabel">Enter Email Addresss</td>
                                              <td class="bkFormText"> 
                                                  <asp:TextBox ID="txtBuyerEmail" runat="server" CssClass="stdTextField1"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="reqValImage" ControlToValidate="txtBuyerEmail" runat="server" ErrorMessage="Enter Email ID." ValidationGroup="VgCheck" Display="Dynamic" CssClass="font_11Msg_Error"></asp:RequiredFieldValidator>

                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                          ControlToValidate="txtBuyerEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                          Display="Dynamic" runat="server" ErrorMessage=" Enter a Valid Email" ValidationGroup="VgCheck" 
                          SetFocusOnError="True" CssClass="font_11Msg_Error"></asp:RegularExpressionValidator>

                                                  </td>
                                          </tr>

                                            <tr>
                                              <td class="bkFormLabel">Enter Mobile No</td>
                                              <td class="bkFormText"> 
                                                  
                                                   <asp:TextBox ID="txtBuyerMobile" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                                   &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtBuyerMobile" ValidationGroup="VgCheck"  runat="server" CssClass="font_11Msg_Error" ErrorMessage="Mobile No. cannot be Empty"></asp:RequiredFieldValidator>
                                                </td>
                                          </tr>
                                             <tr>
                                               <td colspan="2">&nbsp;</td>
                                           </tr>
                                           <tr>
                                               <td colspan="2" align="center" class="auto-style1">
                                                   </td>
                                           </tr>
                                             <tr>
                                               <td colspan="2" align="center">
                                                   <asp:Button ID="buttonBuy" runat="server" CssClass="stdbuttonBuy" Text="Confirm Buy" OnClientClick="skm_LockScreen('Please wait while we take you to PayPal Site...');" ValidationGroup="VgCheck" OnClick="buttonBuy_Click" />
                                                   &nbsp;&nbsp;
                                                    <asp:Button ID="buttonCancel" runat="server" CssClass="stdbuttonBuy" Text="Cancel" OnClick="buttonCancel_Click" />
                                                 </td>
                                           </tr>
                                           <tr>
                                               <td colspan="2" class="font_11Msg_Error">

                                          

                                                   &nbsp;</td>
                                           </tr>

                                           <tr>
                                               <td colspan="2" class="font_11Msg_Error">

                                          

                                                   &nbsp;</td>
                                           </tr>

                                           <tr>
                                               <td colspan="2" class="font_11Msg_Error">

                                          

                                                   <strong>NOTE</strong>:&nbsp;Once click &quot;Confirm Buy&quot; you will be navigated to 
                                                   <img alt="paypallogo" width="150" height="55" src="Images/ebImages/PayPalLogo1.jpg" /> website.</td>
                                           </tr>

                                           <tr>
                                               <td colspan="2">&nbsp;</td>
                                           </tr>
                                      </table>

                                     

                                 </div>


                                 


                             </td>
                         </tr>

                         <tr>
                             <td colspan="2">
                                
                             </td>
                             
                         </tr>

                     </table>

                    </div>

                </div>
            </td>
        </tr>


        <tr>
            <td>
                &nbsp;</td>
            <td align="center" valign="middle">
                &nbsp;

                <div id="dv2PayPalSite" runat="server" visible="false" style="background-color: ThreeDLightShadow">

                    <span class="FontWaiting"> Please wait while we Navigate you to <img alt="paypallogo" width="150" height="55" src="Images/ebImages/PayPalLogo1.jpg" />  webSite... </span>
                    

                </div>


            </td>
        </tr>


    </table>


</td>
</tr>

</table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

