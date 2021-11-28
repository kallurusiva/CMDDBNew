<%@ Page Language="C#" MasterPageFile="~/UserEbookMaster.master" AutoEventWireup="true" CodeFile="eBooksViewCartPrepaid.aspx.cs" Inherits="eBooksViewCartPrepaid" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<%@ Register src="eBookBasketBar.ascx" tagname="eBookBasketBar" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

    <link href="App_Themes/Default/eBookPage.css" rel="stylesheet" />
   <link href="App_Themes/Default/EbHomePageStyles.css" rel="stylesheet" />


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

        <img id="imgLoader" src="Images/Loader1.gif" />
       <span class="FontWaiting">Please wait while we Add your selected Book to Cart... </span>

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
               

            </td>
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
            <td valign="top">
                <div id="dvRightContent" style="padding-left: 10px;" runat="server">


                    <asp:GridView ID="gridItems" runat="server" AllowPaging="true" AllowSorting="true" AlternatingRowStyle-CssClass="rowalt" AutoGenerateColumns="False" 
                        CssClass="mGrid" DataKeyNames="id" HeaderStyle-CssClass="rowheader" 
                        ondatabound="gridItems_DataBound" onpageindexchanging="gridItems_PageIndexChanging" 
                        onrowcancelingedit="gridItems_RowCancelingEdit" onrowdatabound="gridItems_RowDataBound" 
                        onrowdeleting="gridItems_RowDeleting" 
                        onrowediting="gridItems_RowEditing" OnRowUpdating="gridItems_RowUpdating"
                        PageSize="10" OnRowCreated="gridItems_RowCreated">
                        <Columns>
                            
                            <asp:TemplateField HeaderText="Sl No">
                                <ItemTemplate>
                                    <asp:Label ID="lblSlNo" runat="server" Text="<%# Container.DataItemIndex + 1  %>" />
                                    <asp:Literal ID="hdBookId" runat="server" Text='<%#Bind("id")%>' Visible="false"></asp:Literal>
                                    <asp:HiddenField ID="hdItemsCount" Value='<%#Bind("count")%>' runat="server" />
                                    <asp:HiddenField ID="hdTotalAmount" Value='<%#Bind("total")%>' runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="10px" />
                            </asp:TemplateField>

                           <%-- <asp:TemplateField HeaderText="Book Image">
                                <ItemTemplate>
                                    <asp:Image ID="lblImageFilePath" runat="server" Height="100" ImageUrl="~/Images/ebImages/3921.jpg" CssClass="ebImgCss" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="50px" />
                            </asp:TemplateField>--%>
                            

                            <asp:TemplateField HeaderText="Product ID / Product Name" SortExpression="BookID">
                                <ItemTemplate>
                                    <div style="vertical-align:bottom; position: relative;">
                                    <div id="dvBookImg" style="float:left; margin-left: 20px;">
                                    <asp:Image ID="ImgEbook" CssClass="cartBookBox CartBookImgCss" ImageUrl='<%# Eval("ImageURL")%>' runat="server" />
                                        </div>
                                    <div id="dvBookDetails" style="float:left; margin-left: 30px; margin-top: 10px; padding: 10px; vertical-align:text-bottom;">
                                    <asp:Label ID="lblBookID" runat="server" CssClass="fontCart" Text='<%# Bind("id")  %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblBookName" runat="server" CssClass="fontCart2" Text='<%# Bind("name")  %>'></asp:Label>
                                        </div>
                                        </div>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign ="Left" />
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Prepaid Price" SortExpression="Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrepaidPrice" runat="server" CssClass="fontViewCart" Text=''></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="CellPaddingRight" HorizontalAlign="Right" Width="100px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Price" SortExpression="Price">
                                <ItemTemplate>
                                    
                                     <asp:Label ID="Label1" runat="server" CssClass="fontCart" Text='<%# Bind("currency")  %>'></asp:Label>&nbsp;
                                    <asp:Label ID="lblPrice" runat="server" CssClass="fontViewCart" Text='<%# Bind("price", "{0:0.00}")  %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="CellPaddingRight" HorizontalAlign="Right" Width="100px" />
                            </asp:TemplateField>
                           
                         
                            <asp:TemplateField HeaderText="Remove from Cart">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgDelete" runat="server" CommandName="DELETE" ImageUrl="~/Images/ebImages/cart/shopping_cart_delete.png" CssClass="imgDelCart" OnClientClick="return confirm('Please click OK to confirm deletion');" ToolTip="Remove from Cart" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="cssPager" />
                        <PagerTemplate>
                            <table border="0">
                                <tr align="right">
                                    <td width="100px">
                                        <asp:ImageButton ID="btnFirst" runat="server" CommandArgument="First" CommandName="Page" ImageUrl="~/Images/imgPg_First.gif" Text="First" ToolTip="FIRST" />
                                        <asp:ImageButton ID="btnPrevious" runat="server" CommandArgument="Prev" CommandName="Page" ImageUrl="~/Images/imgPg_Prev.gif" Text="Previous" ToolTip="PREVIOUS" />
                                    </td>
                                    <td width="100px">Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged" />
                                        &nbsp;of&nbsp;<asp:Label ID="PageCountLabel" runat="server" />
                                    </td>
                                    <td width="100px">
                                        <asp:ImageButton ID="btnNext" runat="server" CommandArgument="Next" CommandName="Page" ImageUrl="~/Images/imgPg_next.gif" Text="Next" ToolTip="NEXT" />
                                        <asp:ImageButton ID="btnLast" runat="server" CommandArgument="Last" CommandName="Page" ImageUrl="~/Images/imgPg_last.gif" Text="Last" ToolTip="LAST" />
                                    </td>
                                    <td width="20px">&nbsp;</td>
                                    <td width="100px">
                                          <%-- <asp:Button ID="btnDeleteMultiple" runat="server" Text="Delete Selected"/>--%>
                                       </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                                
                             
                            </asp:GridView>


                </div>

                


            </td>
            <td valign="top">
                &nbsp;</td>
        </tr>


    <%-- <asp:TemplateField HeaderText="Book Image">
                                <ItemTemplate>
                                    <asp:Image ID="lblImageFilePath" runat="server" Height="100" ImageUrl="~/Images/ebImages/3921.jpg" CssClass="ebImgCss" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="50px" />
                            </asp:TemplateField>--%>


        <tr>
            <td valign="top">
                 
                &nbsp;</td>
            <td valign="top">

                

                        </td>
            <td valign="top">

                

                        &nbsp;</td>
        </tr>


        <tr>
            <td valign="top">
                 
                &nbsp;</td>
            <td valign="top">

                 <div id="dvContinueShopping" style="float:left; padding-left: 10px;" >

                     <asp:LinkButton ID="LnkBtnContinueShopping" runat="server" OnClick="LnkBtnContinueShopping_Click" Text="Registerd Prepaid User?" CssClass="hpBookPrice">
                    
                    </asp:LinkButton>
                    </div>


                

                <div id="dvCheckOutPayPal" style=" float:right; padding-right: 10px; ">
                </div>


                 <div id="dvDirectBankIn" runat="server" visible="false" style=" float:right; padding-right: 20px; ">
                </div>

                <div id="dvPrepaidPurchase" runat="server" visible="false" style=" float:right; padding-right: 20px; height: 50px; width: 200px;">
                    <asp:LinkButton ID="LnkPrepaidPurchase" runat="server" OnClick="LnkPrepaidPurchase_Click" Text="New Prepaid User?" CssClass="hpBookPrice">
                    
                        </asp:LinkButton>
                </div>&nbsp;&nbsp;&nbsp;&nbsp;

            </td>
            <td valign="top">

                 &nbsp;</td>
        </tr>


        <tr>
            <td valign="top">
                 
                &nbsp;</td>
            <td valign="top">
               <%-- <asp:LinkButton ID="LinkBuyerLogin" runat="server" CssClass="Links_MainMenu" PostBackUrl="~/eb_Buyer_Login.aspx">Customer Sign In</asp:LinkButton>--%>
            </td>
            <td valign="top">
                &nbsp;</td>
        </tr>


    </table>
        


</td>
</tr>

</table>
    <%-- <asp:Button ID="btnDeleteMultiple" runat="server" Text="Delete Selected"/>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
    <uc1:CopyRightsINFO ID="CopyRightsINFO1" runat="server" />
</asp:Content>

