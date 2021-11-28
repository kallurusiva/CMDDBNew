<%@ Page Title="" Language="C#" MasterPageFile="~/UserEbookMaster.master" AutoEventWireup="true" CodeFile="eb_Buyer_Login.aspx.cs" Inherits="eb_Buyer_Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="CopyRightsINFO.ascx" tagname="CopyRightsINFO" tagprefix="uc1" %>

<%@ Register src="eBookBasketBar.ascx" tagname="eBookBasketBar" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">

    <link href="App_Themes/Default/eBookPage.css" rel="stylesheet" />
   <link href="App_Themes/Default/EbHomePageStyles.css" rel="stylesheet" />
    <link href="App_Themes/Buyer_Styles.css" rel="stylesheet" />


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

            <td width="100px"  >
               

                &nbsp;</td>
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
              <br />
              

              


                <br />
            </td>
            <td valign="top">
                  <%--start login--%>
                    <div id="dvLogin">

                        <table id="login" width="600px;">
                             <tr>
                                 <td>&nbsp;</td> 
                                 <td><h2>Customer Sign In</h2></td> 
                                 <td>&nbsp;</td> 

                            </tr>


                            <tr>
                                 <td>&nbsp;</td> 
                                 <td align="center">
                                     <table class="tblinLogin" width="90%">
                                          <tr>
                                             <td>&nbsp;</td> 
                                             <td class="loginfont12">Email :</td> 
                                             <td>&nbsp;</td> 

                                        </tr>

                              <tr>
                                 <td>&nbsp;</td> 
                                 <td>
                                     <asp:TextBox ID="txtEmailID" CssClass="loginTxtBox1" Width="250" runat="server"></asp:TextBox></td> 
                                 <td>&nbsp;</td> 

                            </tr>

                             <tr>
                                 <td>&nbsp;</td> 
                                 <td>&nbsp;</td> 
                                 <td>&nbsp;</td> 

                            </tr>


                             <tr>
                                 <td>&nbsp;</td> 
                                 <td class="loginfont12">Password :</td> 
                                 <td>&nbsp;</td> 

                            </tr>

                             <tr>
                                 <td>&nbsp;</td> 
                                 <td>
                                     <asp:TextBox ID="txtPassword" CssClass="loginTxtBox1" Width="250" runat="server"></asp:TextBox></td> 
                                 <td>&nbsp;</td> 

                            </tr>


                              <tr>
                                 <td>&nbsp;</td> 
                                 <td>&nbsp;</td> 
                                 <td>&nbsp;</td> 

                            </tr>


                             <tr>
                                 <td>&nbsp;</td> 
                                 <td>
                                     <asp:Button ID="BtnSignin" CssClass="loginbtn" runat="server" Text="Sign In" OnClick="BtnSignin_Click" /></td> 
                                 <td>&nbsp;</td> 

                            </tr>

                              <tr>
                                 <td>&nbsp;</td> 
                                 <td>&nbsp;</td> 
                                 <td>&nbsp;</td> 

                            </tr>
                                     </table>
                                 </td> 
                                 <td>&nbsp;</td> 

                            </tr>

                           


                        </table>


                    </div>
                


                <!-- end login --></td>
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

                    </div>


                

                <div id="dvCheckOutPayPal" style=" float:right; padding-right: 10px; ">
                </div>


                 <div id="dvDirectBankIn" runat="server" visible="false" style=" float:right; padding-right: 20px; ">
                </div>

            </td>
            <td valign="top">

                 &nbsp;</td>
        </tr>


        <tr>
            <td valign="top">
                &nbsp;</td>
            <td valign="top">
                &nbsp;</td>
            <td valign="top">
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

