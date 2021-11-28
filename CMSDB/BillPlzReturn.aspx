<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillPlzReturn.aspx.cs" Inherits="BillPlzReturn" %>

    <link href="App_Themes/Default/eBookPage.css" rel="stylesheet" />
    <link href="App_Themes/Default/EbHomePageStyles.css" rel="stylesheet" />

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
    width : 600px;
    height: 300px;
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
.BkfontDescription		{ FONT-SIZE: 14px; COLOR: #296692; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; text-align: justify; letter-spacing: 0.05em; text-align-last: center; word-spacing: 0.05em;
                          
}


.BkFontBHeader          {color: #687367; font-style:italic; font: bold 110%/100% "Trebuchet MS","Lucida Console", Arial, sans-serif; 
                        margin: 30px 0 50px; vertical-align:middle; background-color:#AFD4CF; line-height: 30px; padding-left: 5px;
                         -webkit-border-radius: 6px;                         
						 -moz-border-radius: 6px;						 
						 border-radius: 6px;
					     }

.bkFormLabel   { background-color: #A7E8BA; border-bottom: solid 1pt #71CC91; font-variant: small-caps; color: #000000; font: bold 14px  "Exo","Trebuchet MS","Lucida Console", Arial, sans-serif; height:35px; padding-left:10px; text-align:left;}
.bkFormText    { background-color: #C3F3D1; border-bottom: solid 1pt #71CC91; border-left: solid 1pt #C9E9ED; font: normal 14px "Exo","Trebuchet MS","Lucida Console", Arial; color: #000000; height:35px; padding-left: 20px;}

.bkFormText1Help {background-color: #CCAB71; border-bottom: solid 1pt #D4DFAA; border-left: solid 1pt #D4DFAA;   font-size: 10px; color: #5C80A8; height:35px; padding-left: 20px; vertical-align: bottom;}


.links_URL			{color: #FD79E9; letter-spacing: 1px; font-variant:small-caps; font: bold 14px "Exo" "Trebuchet MS",sans-serif; padding-top: 5px;	TEXT-DECORATION: none; cursor: pointer;}
A.links_URL:hover		{color: #F0615A; letter-spacing: 1px; font-variant:small-caps; font: bold 15px "Trebuchet MS",sans-serif; padding-top: 5px;	TEXT-DECORATION: underline}


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
    width: 936px;
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


         .auto-style2 {
             text-decoration: underline;
         }
         .auto-style3 {
             text-decoration: underline;
             font-weight: normal;
         }


     </style>

   
    <form id="frmTest" runat="server">
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
                 
                <div id="dvLeftContent" class="" style="width: 180px;" runat="server">
                   
                </div>
            </td>
            <td valign="top">
                <div id="dvRightContent" style="padding-left: 10px;" runat="server">

                    <div id="dvEbHeader" class="ebHeaderBox" runat="server">
                      &nbsp;&nbsp;&nbsp; <asp:Label ID="lblHeader" CssClass="eb_head" runat="server" Text=""></asp:Label>
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
                                              <td class="bkFormLabel">Items Code:</td>
                                              <td class="bkFormText"> <asp:Label ID="lblBookID" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Items Name:</td>
                                              <td class="bkFormText"> <asp:Label ID="lblBookName" runat="server" Text=""></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Transaction ID:</td>
                                              <td class="bkFormText"> 
                                                  <asp:Label ID="lblTxDetails" runat="server"></asp:Label></td>
                                          </tr>

                                           <tr>
                                              <td class="bkFormLabel">Charges : </td>
                                              <td class="bkFormText"> 
                                                  <asp:Label ID="lblPytMade" runat="server"></asp:Label></td>
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
                                                   
                                                   <div id="dvSuccess" class="dvPayPalSuccess">

                                                      <span class="fontEBName">
                                                        The BillPlz payment for the eBook was done.  
                                                        <br />
                                                          An Email has been Sent along with the book attached to your registered Email ID once payment Confirmed. 
                                                       </span>


                                                   </div>


                                                    </td>
                                           </tr>
                                          

                                          
                                      </table>

                                     
                                 </div>


                                 


                             </td>
                         </tr>

                         <tr>
                             <td colspan="2" class="PriceFont">
                                
                                 NOTE:&nbsp; Please make note of the <span class="auto-style3"><strong>Transaction ID</strong></span> and the <span class="auto-style2">Items Code</span> for any kind of payment releated queries. </td>
                             
                         </tr>

                         <tr>
                             <td colspan="2" align="center">
                                <div id="dvNav2WebSite" class="dvBookPurchase_ComingCss" style="margin-left: 420px;">

                                 <asp:linkbutton runat="server" ID="lnkToWebsite" CssClass="links_URL" OnClick="lnkToWebsite_Click" >
                                 Click here to go back to the Website.</asp:linkbutton>
                                                        <br />
                                     <%--<asp:linkbutton runat="server" ID="lnkReport" CssClass="links_URL" >
                                 Click here to view/download report.</asp:linkbutton>--%>
                                 
                                </div>
                                 
     </td>
                             
                         </tr>

                         <tr>
                             <td colspan="2">
                                
                                 &nbsp;</td>
                             
                         </tr>

                     </table>

                    </div>

                </div>
            </td>
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
        
        </form>


