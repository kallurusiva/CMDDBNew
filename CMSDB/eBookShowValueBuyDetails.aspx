<%@ Page Title="" Language="C#" MasterPageFile="~/UserEbookMaster.master" AutoEventWireup="true" CodeFile="eBookShowValueBuyDetails.aspx.cs" Inherits="eBookShowValueBuyDetails" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<%@ Register src="eBookBasketBar.ascx" tagname="eBookBasketBar" tagprefix="uc2" %>
<%@ Register Src="~/ebLeftCategories.ascx" TagPrefix="uc1" TagName="ebLeftCategories" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

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
    width : 100%;
    height: 450px;
    margin: 2px;
    align-content: center;

    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;

}

  .cssdValueBuyBooks
{
    border: 1px dotted #BAC0C7;
    padding: 10px; 
    width : 100%;
    min-height: 450px; 
    margin: 5px;
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

.bkFormLabel   { background-color: #E8F0F1; border-bottom: solid 1pt #C9E9ED; font-variant: small-caps; color: #4E5163; font: bold 12px "Trebuchet MS","Lucida Console", Arial, sans-serif; height:35px; padding-left:10px; text-align:left;}
.bkFormText    { background-color: #F1F8F9; border-bottom: solid 1pt #C9E9ED; border-left: solid 1pt #C9E9ED;   font-size: 12px; color: #4E5163; height:35px; padding-left: 20px;}

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
    height: 51px;
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

      .VB_ebookShowBox_Main1
{
    border: 1px dotted #BAC0C7;
    padding: 10px; 
    height: 400px;
    margin: 2px;
       
    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;

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
                <uc2:eBookBasketBar ID="eBookBasketBar1" runat="server" />
            </td>
        </tr>
   
        
        <tr>
            <td valign="top">
                <uc1:ebLeftCategories runat="server" ID="ebLeftCategories" />
                <div id="dvLeftContent" class="ribbon" visible="false" style="width: 180px;" runat="server">
                   
                </div>
            </td>
            <td valign="top">
                <div id="dvRightContent" style="padding-left: 10px;" runat="server">

                    

                    <asp:Repeater ID="RepBooks" runat="server" OnItemDataBound="RepBooks_ItemDataBound">

                        <HeaderTemplate>
                           
                            <table border="0" cellpadding="0" cellspacing="0" width="96%" class="cssfaq">
                            
                        </HeaderTemplate>

                        <ItemTemplate>


                             <tr>

                                   <td> 
                                    <div id="dvEbDetails" class="VB_ebookShowBox_Main1 ebDetailsBox" runat="server">

                                      <table border="0" cellpadding="0" cellspacing="0">
                                          <tr>
                                              <td width="100px" class="bkFormLabel"> <asp:Literal ID="Literal1" Text="<%$ Resources:LangResources, eBook %>" runat="server"></asp:Literal>&nbsp;
                                                  <asp:Literal ID="Literal2" Text="<%$ Resources:LangResources, Code %>" runat="server"></asp:Literal>:</td>
                                              <td width="150px" class="bkFormText"> <asp:Label ID="lblBookID" runat="server" Text='<%# Eval("BookID")%>'></asp:Label>
                                                  <asp:HiddenField ID="hdnBookAllowSmsBuy" Value='<%# Eval("AllowSmsBuy")%>' runat="server" />
                                                  <asp:HiddenField ID="hdnBookAllowPayPalBuy" Value='<%# Eval("AllowPaypalBuy")%>' runat="server" />


                                              </td>
                                          </tr>

                                           <tr>
                                               <td class="bkFormLabel"><asp:Literal ID="Literal4" Text="<%$ Resources:LangResources, PackageName %>" runat="server"></asp:Literal>:</td>
                                              <td class="bkFormText"> <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("BookName")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                               <td class="bkFormLabel"><asp:Literal ID="Literal5" Text="<%$ Resources:LangResources, NumberofBooks %>" runat="server"></asp:Literal>:</td>
                                              <td class="bkFormText"> <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("BooksCount")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                               <td class="bkFormLabel"><asp:Literal ID="Literal8" Text="<%$ Resources:LangResources, Date %>" runat="server"></asp:Literal>&nbsp;
                                                  <asp:Literal ID="Literal9" Text="<%$ Resources:LangResources, Created %>" runat="server"></asp:Literal>:</td>
                                              <td class="bkFormText"> <asp:Label ID="lblDateAdded" runat="server" Text='<%# Eval("DateCreated","{0:MMMM d, yyyy}")%>'></asp:Label></td>
                                          </tr>

                                           <tr>
                                               <td class="bkFormLabel"><asp:Literal ID="Literal6" Text="<%$ Resources:LangResources, OriginalPrice %>" runat="server"></asp:Literal>:</td>
                                              <td class="bkFormText"> 
                                                   <asp:Label ID="lbluCurrency2" CssClass="fontCurrency"  runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                  <asp:Label ID="lblOrgPrice" runat="server" Text='<%# Eval("Price", "{0:0.00}")%>'></asp:Label></td>
                                          </tr>

                                            <tr>
                                             <td class="bkFormLabel"><asp:Literal ID="Literal7" Text="<%$ Resources:LangResources, AfterDiscount %>" runat="server"></asp:Literal>:</td>
                                              <td class="bkFormText">
                                                   <asp:Label ID="Label5" CssClass="fontCurrency"  runat="server" Text='<%# Eval("UserCurrency")%>'></asp:Label>
                                                  &nbsp;
                                                   <asp:Label ID="lblAfterDiscount" runat="server" Text='<%# Eval("DiscountedPrice", "{0:0.00}")%>'></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <td class="RowFormLabel"><asp:Literal ID="Literal15" Text="Prepaid Price" runat="server"></asp:Literal>:</td>
                                              <td class="RowFormText">
                                                  <asp:Label ID="lblPrepaidPrice" runat="server" Text='<%# Eval("PrepaidPrice")%>'></asp:Label></td>
                                          </tr>
                                          <tr>
                                              <td colspan="2" align="left" style="padding: 2px;">
                                                   <asp:LinkButton ID="lnkAddtoCart"  Visible="false" OnClientClick="skm_LockScreen('Please wait while we take you to PayPal Site...')"  OnCommand="lnkAddtoCart_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") %>' runat="server">                                                  
                                                   <img src="Images/ebImages/Add2Cart.png" />
                                                   </asp:LinkButton>

                                                  <asp:LinkButton ID="LnkPayPalBuy" Visible="false" OnCommand="LnkPayPalBuy_Command" CommandArgument='<%# Eval("BookID") + "#" + Eval("BookNAme") + "#" + Eval("DiscountedPrice", "{0:0.00}") %>' runat="server">                                                  
                                                <img src="Images/ebImages/PayPalCreditCardBuyButton.gif" />
                                                  </asp:LinkButton>
                                              </td>
                                          </tr>
                                      </table>
                                         
                                    </div>
                                </td>

                                <td align="center" colspan="2"> 
                                    <%-- Div to show Book Images--%>
                                    
                                    <div id="dvValueBuyBOOK" class="VB_ebookShowBox_Main1 ebValueBuyBOXCss" runat="server">
                                        <div id="dvHeaderVB" class="VB_BookHeader" runat="server">
                                            <asp:Label ID="Label4" runat="server" CssClass="VB_headFont2" Text='<%# Eval("BookID")%>'></asp:Label> :
                                            <asp:Label ID="lblHeader" runat="server" CssClass="VB_headFont1" Text='<%# Eval("BookName")%>'></asp:Label>

                                        </div>
                                        
                                            <div id="divVB1" class="VB_ebookShowBox2 VB_ebImageBox"  runat="server">
                                            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# Eval("BookID1","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">
                                                <asp:Image ID="ImgEbook1" CssClass="Vb_ebImgCss" ImageUrl='<%# Eval("ImageFileURL1")%>' runat="server" />
                                             </asp:HyperLink>
                                                <br /><asp:Label ID="lblBookName1" CssClass="VB_BookName" runat="server" Text='<%# Eval("BookName1")%>'></asp:Label>
                                            
                                        </div>

                                        <div id="divVB2" class="VB_ebookShowBox2 VB_ebImageBox"  runat="server">
                                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("BookID2","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">
                                            <asp:Image ID="ImgEbook2" CssClass="Vb_ebImgCss" ImageUrl='<%# Eval("ImageFileURL2")%>' runat="server" />
                                                </asp:HyperLink>
                                            <br /><asp:Label ID="lblBookName2" CssClass="VB_BookName" runat="server" Text='<%# Eval("BookName2")%>'></asp:Label>
                                                 
                                        </div>

                                        <div id="divVB3" class="VB_ebookShowBox2 VB_ebImageBox"  runat="server">
                                            <asp:HyperLink ID="HyperLink3" NavigateUrl='<%# Eval("BookID3","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">
                                            <asp:Image ID="ImgEbook3" CssClass="Vb_ebImgCss" ImageUrl='<%# Eval("ImageFileURL3")%>' runat="server" />
                                                </asp:HyperLink>
                                            <br /><asp:Label ID="Label1" CssClass="VB_BookName" runat="server" Text='<%# Eval("BookName3")%>'></asp:Label>
                                               
                                        </div>

                                        <div id="divVB4" class="VB_ebookShowBox2 VB_ebImageBox"  runat="server">
                                            <asp:HyperLink ID="HyperLink4" NavigateUrl='<%# Eval("BookID4","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">
                                            <asp:Image ID="ImgEbook4" CssClass="Vb_ebImgCss" ImageUrl='<%# Eval("ImageFileURL4")%>' runat="server" />
                                                </asp:HyperLink>
                                            <br /><asp:Label ID="Label2" CssClass="VB_BookName" runat="server" Text='<%# Eval("BookName4")%>'></asp:Label>
                                                
                                        </div>

                                        <div id="divVB5" class="VB_ebookShowBox2 VB_ebImageBox"  runat="server">
                                            <asp:HyperLink ID="HyperLink5" NavigateUrl='<%# Eval("BookID5","~/eBookShowDetails.aspx?qBookID={0}") %>' runat="server">
                                           <asp:Image ID="ImgEbook5" CssClass="Vb_ebImgCss" ImageUrl='<%# Eval("ImageFileURL5")%>' runat="server" />
                                                </asp:HyperLink>
                                            <br /><asp:Label ID="Label3" CssClass="VB_BookName" runat="server" Text='<%# Eval("BookName5")%>'></asp:Label>
                                               
                                        </div>

                                        <div id="DivPurchaseFooter" class="dvBookPurchaseCss" visible="false" runat="server">
                                            <table id="tblPurchase" runat="server" border="0">
                                                <tr>
                                                    <td align="left">                                                    
                                            <asp:Label ID="lblPurFormat" runat="server" CssClass="VB_Purchase_header" Text="Malaysia Mobile Purchase - SMS Purchase Format: " ></asp:Label> 
                                            &nbsp;&nbsp;&nbsp;<br />
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">  
                                            <asp:Label ID="lblPurchaseText" runat="server" CssClass="VB_Purchase_format" Text=""></asp:Label> 
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                            <asp:Label ID="lblPurchaseNote" runat="server" CssClass="Purchase_header" Text="SEND to 36247"></asp:Label> 
                                                </td>
                                                </tr>
                            </table>
                                        </div>
                                           
                                    </div>                                 
                                   
                                </td
                              
                            </tr>
                                            
                                      
                             <tr>
                      <td colspan="3">
                          &nbsp; 
                          </td>
                                 </tr>
                           
                              <%-- BOOK 1 --%>
                             
                      <tr id="trBook1" runat="server">
                      <td align="center"> 

                   
                    
                    <div id="dvBook1" class="VB1_ebookShowBox ebImageBox"  runat="server">
                     <asp:Image ID="ImgDescBook1" CssClass="ebImgCss" ImageUrl='<%# Eval("ImageFileURL1")%>' runat="server" />
                    </div>
                         </td>

                         <td colspan="2">

                    <div id="dvEbDescription" class="VB1_ebookShowBox VB1_ebDescriptionBox"  runat="server">
                        <div id="dvBookInfo" class="dvBookInfoCss" runat="server">
                        <asp:Label ID="lblDescription" CssClass="fontDescription" runat="server" Text='<%# Eval("BookDescp1").ToString().Replace("\n", "<br/>") %>'></asp:Label>
                        <br />
                        </div>
                     </div>
                        
                    </td>
                    </tr>
                   
                    <%-- BOOK 2 --%>
                    <tr id="trBook2" runat="server">
                    <td align="center"> 

                    <div id="dvBook2" class="VB1_ebookShowBox ebImageBox"  runat="server">
                     <asp:Image ID="ImgDescBook2" CssClass="ebImgCss" ImageUrl='<%# Eval("ImageFileURL2")%>' runat="server" />
                    </div>

                         </td>

                         <td colspan="2">

                    <div id="Div2" class="VB1_ebookShowBox VB1_ebDescriptionBox"  runat="server">
                        <div id="Div3" class="dvBookInfoCss" runat="server">
                        <asp:Label ID="Label7" CssClass="fontDescription" runat="server" Text='<%# Eval("BookDescp2").ToString().Replace("\n", "<br/>") %>'></asp:Label>
                        <br />
                        </div>
                     </div>

                    </td>
                    </tr>


                     <%-- BOOK 3 --%>
                    <tr id="trBook3" runat="server">
                    <td align="center"> 

                    <div id="Div1" class="VB1_ebookShowBox ebImageBox"  runat="server">
                     <asp:Image ID="ImgDescBook3" CssClass="ebImgCss" ImageUrl='<%# Eval("ImageFileURL3")%>' runat="server" />
                    </div>

                         </td>

                         <td colspan="2">

                    <div id="Div4" class="VB1_ebookShowBox VB1_ebDescriptionBox"  runat="server">
                        <div id="Div5" class="dvBookInfoCss" runat="server">
                        <asp:Label ID="Label8" CssClass="fontDescription" runat="server" Text='<%# Eval("BookDescp3").ToString().Replace("\n", "<br/>") %>'></asp:Label>
                        <br />
                        </div>
                     </div>

                    </td>
                    </tr>

                    <%-- BOOK 4 --%>
                    <tr id="trBook4" runat="server">
                    <td align="center"> 

                    <div id="Div6" class="VB1_ebookShowBox ebImageBox"  runat="server">
                     <asp:Image ID="ImgDescBook4" CssClass="ebImgCss" ImageUrl='<%# Eval("ImageFileURL4") %>' runat="server" />
                    </div>

                         </td>

                         <td colspan="2">

                    <div id="Div7" class="VB1_ebookShowBox VB1_ebDescriptionBox"  runat="server">
                        <div id="Div8" class="dvBookInfoCss" runat="server">
                        <asp:Label ID="Label9" CssClass="fontDescription" runat="server" Text='<%# Eval("BookDescp4").ToString().Replace("\n", "<br/>") %>'></asp:Label>
                        <br />
                        </div>
                     </div>

                    </td>
                    </tr>

                     <%-- BOOK 5 --%>
                    <tr id="trBook5" runat="server">
                    <td align="center"> 

                    <div id="Div9" class="VB1_ebookShowBox ebImageBox"  runat="server">
                     <asp:Image ID="ImgDescBook5" CssClass="ebImgCss" ImageUrl='<%# Eval("ImageFileURL5")%>' runat="server" />
                    </div>

                         </td>

                         <td colspan="2">

                    <div id="Div10" class="VB1_ebookShowBox VB1_ebDescriptionBox"  runat="server">
                        <div id="Div11" class="dvBookInfoCss" runat="server">
                        <asp:Label ID="Label10" CssClass="fontDescription" runat="server" Text='<%# Eval("BookDescp5").ToString().Replace("\n", "<br/>") %>'></asp:Label>
                        <br />
                        </div>
                     </div>

                    </td>
                    </tr>



                        </ItemTemplate>

                        <SeparatorTemplate>
                              <tr>
                                <td class="eSeparator" colspan="3">&nbsp; </td>
                              </tr>

                        </SeparatorTemplate>


                        <FooterTemplate>
                            <tr>
                            <td>&nbsp; </td>
                            <td>&nbsp; </td>
                            <td> &nbsp; </td>
                            </tr>
                            </table>

                        </FooterTemplate>

                    </asp:Repeater>

                   




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
<%--</form>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

