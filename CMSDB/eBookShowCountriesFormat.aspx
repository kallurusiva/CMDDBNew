<%@ Page Language="C#" MasterPageFile="~/UserEbookBlank.master" AutoEventWireup="true" CodeFile="eBookShowCountriesFormat.aspx.cs" Inherits="eBookShowCountriesFormat" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

    <link href="App_Themes/Default/eBookPage.css" rel="stylesheet" />
   <link href="App_Themes/Default/EbHomePageStyles.css" rel="stylesheet" />

     <style type="text/css">

 .CssdvBookImage 
{
    border: 1px dotted #BAC0C7;
    padding: 10px; 
    width : 350px;
    height: 450px;
    margin: 2px;
    align-content: center;

    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;

}

 .bkImageCss {
    max-width: 300px;
    max-height: 450px;
}


  .CssdvBookDetails
{
    border: 1px dotted #BAC0C7;
    padding: 10px; 
    width : 600px;
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


.BkfontTitle		    { FONT-SIZE: 14px; COLOR: #296692; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; font-weight: bold;}
.BkfontDescription		{ FONT-SIZE: 14px; COLOR: #296692; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; text-align: justify; letter-spacing: 0.05em; text-align-last:  left; word-spacing: 0.05em;
                          
}


.BkFontBHeader          {color: #687367; font-style:italic; font: bold 110%/100% "Trebuchet MS","Lucida Console", Arial, sans-serif; 
                        margin: 30px 0 50px; vertical-align: middle; background-color:#AFD4CF; line-height: 30px; padding-left: 5px;
                         -webkit-border-radius: 6px;                         
						 -moz-border-radius: 6px;						 
						 border-radius: 6px;
					     }

.bkFormLabel   { background-color: #E8F0F1; border-bottom: solid 1pt #C9E9ED; font-variant: small-caps; color: #4E5163; font: bold 14px "Trebuchet MS","Lucida Console", Arial, sans-serif; height:35px; padding-left:10px; text-align:left;}
.bkFormText    { background-color: #F1F8F9; border-bottom: solid 1pt #C9E9ED; border-left: solid 1pt #C9E9ED;   font-size: 14px; color: #4E5163; height:35px; padding-left: 20px;}

.bkFormText1Help {background-color: #EEEFEB; border-bottom: solid 1pt #D4DFAA; border-left: solid 1pt #D4DFAA;   font-size: 10px; color: #5C80A8; height:35px; padding-left: 20px; vertical-align: bottom;}



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
    height: 140px;
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
    height: 140px;
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
         position: fixed; 
         z-index: 999; 
        top: 50%;
        left: 50%;
       -webkit-transform: translate(-50%, -50%);
    transform: translate(-50%, -50%);


     padding-top: 50%; 

         width: 105%; 
         height: 105%; 
         background-color: #ccc; 
         text-align: center; 
        
         filter: alpha(opacity=75); 
         opacity: 0.75; 

      } 
         .auto-style1 {
             background-color: #E8F0F1;
             border-bottom: solid 1pt #C9E9ED;
             font-variant: small-caps;
             color: #4E5163;
             height: 28px;
             padding-left: 10px;
             text-align: left;
             font-variant: normal;
             font-style: normal;
             font-weight: bold;
             font-size: 14px;
             line-height: normal;
             font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
         }
         .auto-style2 {
             background-color: #F1F8F9;
             border-bottom: solid 1pt #C9E9ED;
             border-left: solid 1pt #C9E9ED;
             font-size: 14px;
             color: #4E5163;
             height: 28px;
             padding-left: 20px;
         }
         .auto-style3 {
             background-color: #E8F0F1;
             border-bottom: solid 1pt #C9E9ED;
             font-variant: small-caps;
             color: #4E5163;
             height: 27px;
             padding-left: 10px;
             text-align: left;
             font-variant: normal;
             font-style: normal;
             font-weight: bold;
             font-size: 14px;
             line-height: normal;
             font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
         }
         .auto-style4 {
             background-color: #F1F8F9;
             border-bottom: solid 1pt #C9E9ED;
             border-left: solid 1pt #C9E9ED;
             font-size: 14px;
             color: #4E5163;
             height: 27px;
             padding-left: 20px;
         }
         .auto-style5 {
             background-color: #E8F0F1;
             border-bottom: solid 1pt #C9E9ED;
             font-variant: small-caps;
             color: #4E5163;
             height: 25px;
             padding-left: 10px;
             text-align: left;
             font-variant: normal;
             font-style: normal;
             font-weight: bold;
             font-size: 14px;
             line-height: normal;
             font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
         }
         .auto-style6 {
             background-color: #F1F8F9;
             border-bottom: solid 1pt #C9E9ED;
             border-left: solid 1pt #C9E9ED;
             font-size: 14px;
             color: #4E5163;
             height: 25px;
             padding-left: 20px;
         }
         .auto-style7 {
             background-color: #E8F0F1;
             border-bottom: solid 1pt #C9E9ED;
             font-variant: small-caps;
             color: #4E5163;
             height: 26px;
             padding-left: 10px;
             text-align: left;
             font-variant: normal;
             font-style: normal;
             font-weight: bold;
             font-size: 14px;
             line-height: normal;
             font-family: "Trebuchet MS", "Lucida Console", Arial, sans-serif;
         }
         .auto-style8 {
             background-color: #F1F8F9;
             border-bottom: solid 1pt #C9E9ED;
             border-left: solid 1pt #C9E9ED;
             font-size: 14px;
             color: #4E5163;
             height: 26px;
             padding-left: 20px;
         }
   </style> 

    <script type="text/javascript">
        function skm_LockScreen(str, vCurrendID) {
            //alert('showing');
            var lock = document.getElementById('skm_LockPane');
            if (lock)
                lock.className = 'LockOn';

            // lock.innerHTML = str;
        }
   </script> 
 <div id="skm_LockPane" class="LockOff">

       <img id="imgLoader" src="Images/Loader1.gif" />
       <span class="FontWaiting">Please wait while we add your selected Book to Cart... </span>

   </div> 

    <%--<form id="frmTest" runat="server">--%>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>

            <td width="150px"></td>
            <td align="right" >
                &nbsp;</td>
        </tr>
   
        
        <tr>
            <td valign="top">
                
               
            </td>
            <td valign="top">
                <div id="dvRightContent" style="padding-left: 10px;" runat="server">

                    <div id="dvEbHeader" class="ebHeaderBox" runat="server">
                       <asp:Label ID="lblHeader" CssClass="eb_head" runat="server" Text=""></asp:Label>
                   </div>

                    <div id="dvBookContainer">

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

                                       <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                          <tr>
                                              <td width="100px" class="auto-style1"> Product&nbsp;
                                                  <asp:Literal ID="Literal13" Text="<%$ Resources:LangResources, Code %>" runat="server"></asp:Literal>:</td>

                                              <td width="150px" class="auto-style2"> <asp:Label ID="lblBookID" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="auto-style3">Product&nbsp;
                                                  <asp:Literal ID="Literal4" Text="<%$ Resources:LangResources, Name %>" runat="server"></asp:Literal>:</td>
                                              <td class="auto-style4"> <asp:Label ID="lblBookName" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                               <td class="auto-style5"><asp:Literal ID="Literal5" Text="<%$ Resources:LangResources, Category %>" runat="server"></asp:Literal>:</td>
                                              <td class="auto-style6"> <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="auto-style3"><asp:Literal ID="Literal8" Text="<%$ Resources:LangResources, Date %>" runat="server"></asp:Literal>&nbsp;
                                                  <asp:Literal ID="Literal9" Text="<%$ Resources:LangResources, Created %>" runat="server"></asp:Literal>:</td>
                                              <td class="auto-style4"> <asp:Label ID="lblDateAdded" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="auto-style7"><asp:Literal ID="Literal6" Text="<%$ Resources:LangResources, OriginalPrice %>" runat="server"></asp:Literal>:</td>
                                              <td class="auto-style8">
                                                  
                                                   <asp:Label ID="lbluCurrency1" CssClass="fontCurrency"  runat="server"></asp:Label>
                                                  &nbsp;
                                                   <asp:Label ID="lblOrgPrice" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                            <tr>
                                             <td class="auto-style5"><asp:Literal ID="Literal7" Text="<%$ Resources:LangResources, AfterDiscount %>" runat="server"></asp:Literal>:</td>
                                              <td class="auto-style6"> 
                                                  <asp:Label ID="lbluCurrency2" CssClass="fontCurrency"  runat="server"></asp:Label>
                                                  &nbsp;
                                                  <asp:Label ID="lblAfterDiscount" runat="server" Text=""></asp:Label></td>
                                          </tr>
                                           <tr>
                                             <td class="auto-style5"><asp:Literal ID="Literal3" Text="Prepaid Price" runat="server"></asp:Literal>:</td>
                                              <td class="auto-style6"> 
                                                  <asp:Label ID="lblPrepaidDisp" CssClass="fontCurrency"  runat="server"></asp:Label>
                                                  &nbsp;
                                                  <asp:Label ID="lblPrepaidValue" runat="server" Text=""></asp:Label></td>
                                          </tr>
                                          
                                             <tr>
                                               <td colspan="2">&nbsp;</td>
                                           </tr>
                                           <tr>
                                               <td colspan="2" align="left">

                                          <div id="dvBookPurchaseFormat" class="CssdvBookPurchase" style="margin-left: 100px;" runat="server" visible="false">

                                            <table id="tblPurchase" runat="server" border="0">
                                                 <tr><td align="left" class="Purchase_headerB"><asp:Literal ID="Literal10" Text="<%$ Resources:LangResources, MalaysiaMobilePurchase %>" runat="server"></asp:Literal>&nbsp;-&nbsp;
                                                    <asp:Literal ID="Literal11" Text="<%$ Resources:LangResources, SMSPurchaseFormat %>" runat="server"></asp:Literal> </td></tr>
                                                <tr><td class="Purchase_format">  
                                                        <asp:Label ID="lblPurFormat" runat="server" Text=""></asp:Label>
                                                    </td></tr>
                                                 <tr><td align="right" class="Purchase_send">&nbsp;<asp:Literal ID="Literal12" Text="<%$ Resources:LangResources, SendTo %>" runat="server"></asp:Literal> 
                                                     <br> </br>
                                                     <br></br> </td></tr>
                                                <tr><td align="left">
                                                    <asp:Label ID="lblPurchaseNote" CssClass="Purchase_header" runat="server" Text=""></asp:Label> </td></tr>
                                            </table>

                                             <table id="tblFreeEbooksPurchase" runat="server" border="0" visible="false">
                                                <tr><td align="left" class="Purchase_headerB">SMS Purchase Format</td></tr>
                                                <tr><td class="Purchase_format">  
                                                        &nbsp;</td></tr>
                                               </table>

                                              <table id="tblComingSoon" runat="server" border="0" visible="false">
                                                <tr><td align="left" class="Purchase_header">&nbsp;</td></tr>
                                                <tr><td align="right" class="Purchase_send">&nbsp;</td></tr>
                                                <tr><td align="left">
                                                
                                                </td></tr>
                                            </table>

                                          </div>

                                               </td>
                                           </tr>

                                           </table>

                                     

                                 </div>


                                 


                             </td>
                         </tr>

                        

                     </table>

                    </div>

                </div>
            </td>
        </tr>


      <%--  <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>--%>


    </table>


</td>
</tr>

</table>
<%--</form>--%>
</asp:Content>


