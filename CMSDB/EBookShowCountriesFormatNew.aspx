<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EBookShowCountriesFormatNew.aspx.cs" Inherits="EBookShowCountriesFormatNew" %>

    <link href="App_Themes/Default/eBookPage.css" rel="stylesheet" />
   <link href="App_Themes/Default/EbHomePageStyles.css" rel="stylesheet" />


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

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
    border: 0px dotted #BAC0C7;
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
         .auto-style9 {
             width: 698px;
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

    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
            <tr>
                <td align="center">
                                 <%--Book Image Goes Here--%>
                                 <div id="dvBookImage" class="CssdvBookImage">
                                     <asp:Image ID="ImgEbook" runat="server" CssClass="bkImageCss" ImageUrl="" />
                    </div>
                </td>
                <td class="auto-style9">
                                 <%--Book Details Goes Here--%>
                                 <div id="dvBookDetails" class="CssdvBookDetails">
                                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                         <tr>
                                             <td class="auto-style1" width="100px">Product&nbsp;
                                                 <asp:Literal ID="Literal13" runat="server" Text="<%$ Resources:LangResources, Code %>"></asp:Literal>
                                                 :</td>
                                             <td class="auto-style2" width="150px">
                                                 <asp:Label ID="lblBookID" runat="server" Text=""></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style3">Product&nbsp;
                                                 <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:LangResources, Name %>"></asp:Literal>
                                                 :</td>
                                             <td class="auto-style4">
                                                 <asp:Label ID="lblBookName" runat="server" Text=""></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style5">
                                                 <asp:Literal ID="Literal5" runat="server" Text="<%$ Resources:LangResources, Category %>"></asp:Literal>
                                                 :</td>
                                             <td class="auto-style6">
                                                 <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style3">
                                                 <asp:Literal ID="Literal8" runat="server" Text="<%$ Resources:LangResources, Date %>"></asp:Literal>
                                                 &nbsp;
                                                 <asp:Literal ID="Literal9" runat="server" Text="<%$ Resources:LangResources, Created %>"></asp:Literal>
                                                 :</td>
                                             <td class="auto-style4">
                                                 <asp:Label ID="lblDateAdded" runat="server" Text=""></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style7">
                                                 <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:LangResources, OriginalPrice %>"></asp:Literal>
                                                 :</td>
                                             <td class="auto-style8">
                                                 <asp:Label ID="lbluCurrency1" runat="server" CssClass="fontCurrency"></asp:Label>
                                                 &nbsp;
                                                 <asp:Label ID="lblOrgPrice" runat="server" Text=""></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style5">
                                                 <asp:Literal ID="Literal7" runat="server" Text="<%$ Resources:LangResources, AfterDiscount %>"></asp:Literal>
                                                 :</td>
                                             <td class="auto-style6">
                                                 <asp:Label ID="lbluCurrency2" runat="server" CssClass="fontCurrency"></asp:Label>
                                                 &nbsp;
                                                 <asp:Label ID="lblAfterDiscount" runat="server" Text=""></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td class="auto-style5">
                                                 <asp:Literal ID="Literal3" runat="server" Text="Prepaid Price"></asp:Literal>
                                                 :</td>
                                             <td class="auto-style6">
                                                 <asp:Label ID="lblPrepaidDisp" runat="server" CssClass="fontCurrency"></asp:Label>
                                                 &nbsp;
                                                 <asp:Label ID="lblPrepaidValue" runat="server" Text=""></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td colspan="2">&nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">                                                 
                                                 <asp:Image runat="server" name="imgOne" ID="imgOne"/>
                                                 <asp:Label ID="Literal101" runat="server" CssClass="Purchase_header" Text=""></asp:Label>
                                                 <div id="dvBookPurchaseFormat" runat="server" class="CssdvBookPurchase" style="margin-left: 100px;" visible="false">
                                                     <table id="tblPurchase" runat="server" border="0">
                                                         <tr>
                                                             <td align="left" class="Purchase_headerB">
                                                                 <asp:Literal ID="Literal10" runat="server" Text=""></asp:Literal>
                                                                 &nbsp;-&nbsp;
                                                                 <asp:Literal ID="Literal11" runat="server" Text=""></asp:Literal>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                             <td class="Purchase_format">
                                                                 <asp:Label ID="lblPurFormat1" runat="server" Text=""></asp:Label>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                             <td align="right" class="Purchase_send">&nbsp;<asp:Literal ID="Literal12" runat="server" Text=""></asp:Literal>
                                                                 <br />                                                                 
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                             <td align="left">
                                                                 <asp:Label ID="lblPurchaseNote1" runat="server" CssClass="Purchase_header" Text=""></asp:Label>
                                                             </td>
                                                         </tr>
                                                     </table>                                                     
                                                 </div>
                                             </td>
                                         </tr>

                                         <tr>
                                             <td align="left" colspan="2">
                                                 <asp:Image runat="server" name="imgTwo" ID="imgTwo"/>
                                                 <asp:Label ID="Literal102" runat="server" CssClass="Purchase_header" Text=""></asp:Label>
                                                 <div id="dvBookPurchaseFormat1" runat="server" class="CssdvBookPurchase" style="margin-left: 100px;" visible="false">
                                                     <table id="tblPurchase1" runat="server" border="0">
                                                         <tr>
                                                             <td align="left" class="Purchase_headerB">
                                                                 <asp:Literal ID="Literal20" runat="server" Text=""></asp:Literal>
                                                                 &nbsp;-&nbsp;
                                                                 <asp:Literal ID="Literal21" runat="server" Text=""></asp:Literal>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                             <td class="Purchase_format">
                                                                 <asp:Label ID="lblPurFormat2" runat="server" Text=""></asp:Label>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                             <td align="right" class="Purchase_send">&nbsp;<asp:Literal ID="Literal22" runat="server" Text=""></asp:Literal>
                                                                 <br />                                                                 
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                             <td align="left">
                                                                 <asp:Label ID="lblPurchaseNote2" runat="server" CssClass="Purchase_header" Text=""></asp:Label>
                                                             </td>
                                                         </tr>
                                                     </table>                                                     
                                                 </div>
                                             </td>
                                         </tr>

                                         <tr>
                                             <td align="left" colspan="2">
                                                 <asp:Image runat="server" name="imgThree" ID="imgThree"/>
                                                 <asp:Label ID="Literal103" runat="server" CssClass="Purchase_header" Text=""></asp:Label>
                                                 <div id="dvBookPurchaseFormat2" runat="server" class="CssdvBookPurchase" style="margin-left: 100px;" visible="false">
                                                     <table id="Table1" runat="server" border="0">
                                                         <tr>
                                                             <td align="left" class="Purchase_headerB">
                                                                 <asp:Literal ID="Literal30" runat="server" Text=""></asp:Literal>
                                                                 &nbsp;-&nbsp;
                                                                 <asp:Literal ID="Literal31" runat="server" Text=""></asp:Literal>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                             <td class="Purchase_format">
                                                                 <asp:Label ID="lblPurFormat3" runat="server" Text=""></asp:Label>
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                             <td align="right" class="Purchase_send">&nbsp;<asp:Literal ID="Literal32" runat="server" Text=""></asp:Literal>
                                                                 <br />                                                                 
                                                             </td>
                                                         </tr>
                                                         <tr>
                                                             <td align="left">
                                                                 <asp:Label ID="lblPurchaseNote3" runat="server" CssClass="Purchase_header" Text=""></asp:Label>
                                                             </td>
                                                         </tr>
                                                     </table>                                                     
                                                 </div>
                                                 
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">
                                                 &nbsp;
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">
                                                 &nbsp;
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">
                                                 <asp:Label ID="Label5" runat="server" CssClass="fontTitle" Text="Coming Soon - Mobile Payment in those Countries."></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">
                                                 &nbsp;
                                             </td>
                                         </tr>                                        
                                         <tr>
                                             <td align="left" colspan="2">
                                                 <asp:Image runat="server" name="imgThree" ID="Image1" ImageUrl="~/Images/f_china.gif" Height="20px" Width="36px"/>
                                                 <asp:Label ID="Label201" runat="server" CssClass="Purchase_header" Text="China  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   Population &nbsp;&nbsp 1.5 Billion"></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">
                                                 <asp:Image runat="server" name="imgThree" ID="Image2" ImageUrl="~/Images/f_philippines.gif" Height="20px" Width="36px"/>
                                                 <asp:Label ID="Label1" runat="server" CssClass="Purchase_header" Text="Philippines  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   Population &nbsp;&nbsp; 100 Million"></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">
                                                 <asp:Image runat="server" name="imgThree" ID="Image3" ImageUrl="~/Images/f_thailand.gif" Height="20px" Width="36px"/>
                                                 <asp:Label ID="Label2" runat="server" CssClass="Purchase_header" Text="Thailand  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   Population &nbsp;&nbsp; 57 Million"></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">
                                                 <asp:Image runat="server" name="imgThree" ID="Image4" ImageUrl="~/Images/f_vietnam.gif" Height="20px" Width="36px"/>
                                                 <asp:Label ID="Label3" runat="server" CssClass="Purchase_header" Text="Vietnam  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   Population &nbsp;&nbsp; 90 Million"></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">
                                                 <asp:Image runat="server" name="imgThree" ID="Image5" ImageUrl="~/Images/f_australia.gif" Height="20px" Width="36px"/>
                                                 <asp:Label ID="Label4" runat="server" CssClass="Purchase_header" Text="Australia  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   Population &nbsp;&nbsp; 24 Million"></asp:Label>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">
                                                 &nbsp;
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="left" colspan="2">
                                                 &nbsp;
                                             </td>
                                         </tr>
                                     </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
