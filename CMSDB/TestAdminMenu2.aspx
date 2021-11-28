<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestAdminMenu2.aspx.cs" Inherits="TestAdminMenu2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link href="App_Themes/Default/DefaultStyleSheet.css" rel="stylesheet" type="text/css" />
 
 
 <style type="text/css">
 #headercontent{
     width: 100%;
     height: 160px;
     margin: 0;
     border-width: 0 0 0 0;
 }
 

a {text-decoration:none;}
.top ul.nav {
    height:30px;
    border-top:5px solid #468b17;
    background: #a6c47b; /* Old browsers */
    background: -moz-linear-gradient(top, #a6c47b 1%, #468b17 100%); /* FF3.6+ */
    background: -webkit-gradient(linear, left top, left bottom, color-stop(1%,#a6c47b), color-stop(100%,#468b17)); /* Chrome,Safari4+ */
    background: -webkit-linear-gradient(top, #a6c47b 1%,#468b17 100%); /* Chrome10+,Safari5.1+ */
    background: -o-linear-gradient(top, #a6c47b 1%,#468b17 100%); /* Opera 11.10+ */
    background: -ms-linear-gradient(top, #a6c47b 1%,#468b17 100%); /* IE10+ */
    background: linear-gradient(top, #a6c47b 1%,#468b17 100%); /* W3C */
    filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#a6c47b', endColorstr='#468b17',GradientType=0 ); /* IE6-8 */
    box-shadow:-2px 2px 5px rgba(0,0,0,0.7);
    float:left; width: 100%;
    
    
}
.top ul.nav li {list-style:none;float:left;text-align:center; border-right: solid 1px #B3B3B3;}
.top ul.nav li a {
    color:#fff;
    font-size:0.8em;
    padding:5px 15px;
    display:block;
    height:20px;
    border-right:1px solid rgba(70,139,23,0.5);
    font-family:"Lucida Grande", "Lucida Sans Unicode", Verdana, Arial, Helvetica, sans-serif;font-size:1em;
}
.top ul.nav li a:hover {
    color:#fff;
    float:left;
    background: #468b17; /* Old browsers */
    background: -moz-linear-gradient(top, #468b17 0%, #173000 99%); /* FF3.6+ */
    background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#468b17), color-stop(99%,#173000)); /* Chrome,Safari4+ */
    background: -webkit-linear-gradient(top, #468b17 0%,#173000 99%); /* Chrome10+,Safari5.1+ */
    background: -o-linear-gradient(top, #468b17 0%,#173000 99%); /* Opera 11.10+ */
    background: -ms-linear-gradient(top, #468b17 0%,#173000 99%); /* IE10+ */
    background: linear-gradient(top, #468b17 0%,#173000 99%); /* W3C */
    filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#468b17', endColorstr='#173000',GradientType=0 ); /* IE6-8 */
    font-family:"Lucida Grande", "Lucida Sans Unicode", Verdana, Arial, Helvetica, sans-serif;font-size:1em;
}

 
 
 </style>
</head>

<body>
    
    <div id="headercontent">
    
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%; border: dashed 1px blue;">
    <tr class="TopFrameBkg_Grad"  style="height:4px;">
    <td colspan="3" class="TopFrameBkg" align="right">
      <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
         <td align="left" width="200px">&nbsp;</td>
         <td align="left" width="250px" class="font_12Normal">
          
          </td>
            <td class="TopFrameBkg" align="right"  width="450px" nowrap="nowrap" >
            
            <div id="dvtraining"  style="float: left;">
                <img src="../Images/training.png" id="ctl00_img1" alt="Clogin" />
                <a id="ctl00_HyperLink7" class="Links_AdminMainMenu2" href="http://webportaltraining.1mybusiness.com" target="_blank">TRAINING</a>
                &nbsp;&nbsp;|&nbsp;
            </div>
            
               
               
              
              <div id="ctl00_dvMobileWeb" style="float:left;">
                <img src="../Images/smart_phone.png" id="ctl00_img2" alt="mphone" />
                <a id="ctl00_HypMobileWeb" class="Links_AdminMainMenu2" href="Mobile/Ad_MobileHome3.aspx">MobileWEB</a>
                   
              </div>
                    
            </td>
        </tr>
        </table>
    
    </td>    
 
    </tr>
    <tr style="height:40px;">
      
    <td colspan="3" class="TopFrameBkg_Grad">
    
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border: solid 1px red;">
        <tr>
        <td align="left" width="300px"><font class="AdminFont">Administrator Panel</font></td>
        <td align="left" width="300px">
            
            </td>
        <td>&nbsp;</td>
        </tr>
        </table>
    </td>  
   
    </tr>

    
    <tr>
    
    <td align="left" nowrap="nowrap" colspan="3"  style="background: #a6c47b;">
        <div id="ctl00_topmenu98" class="top" nowrap="nowrap">
            
        <ul class="nav">
            <li>
                <a id="ctl00_HyperLink1" href="Ad_Welcome.aspx">Home</a>
            </li>
            <li>
                <a id="ctl00_HyperLink2" href="MyAccount.aspx">Contact Us</a>    
            </li> 
             <li>
               <a id="ctl00_HyperLinkAbtUs" href="Ad_AboutUsPageCreate.aspx">About Us</a>        
            </li>
             <li>
               <a id="ctl00_HyperLinkWp" href="Ad_WelComePageSettings.aspx">Welcome Page</a>        
            </li>
           
            <li>
               <a id="ctl00_HyperLink10" href="Ad_EmailListing.aspx">Email</a>        
            </li>
             <li>
               <a id="ctl00_HyperLink12" href="Ad_LanguageSet.aspx">Language</a>        
            </li>
            
             <li>
               <a id="ctl00_HyperLink4" href="Ad_AnchorDomainsList.aspx">Domain</a>        
            </li>
            <li>
               <a id="ctl00_HypWebTemplate" href="Ad_TemplateSet.aspx">Web Template</a>        
            </li>
            <li>
               <a id="ctl00_HyperLink6" href="MyHomePageSettings.aspx">WebSettings</a>        
            </li>
             <li>
               <a id="ctl00_HyperLinkBnr" href="Ad_BannerSettings.aspx">Banner</a>        
            </li>
             <li>
               <a id="ctl00_HyperLink5" href="Ad_LogoSettings.aspx">Logo</a>        
            </li>
             <li>
                <a id="ctl00_HyperLink3" href="Ad_SystemNewsListing.aspx">System News</a>        
            </li>
            
            <li>
             <a id="ctl00_HyperLink9" href="../MemberLogout.aspx">Logout</a>        
             </li>
        </ul>
        </div>
    
    </td>  
    
    </tr>
    
      <tr>
   
    <td nowrap="nowrap" colspan="3">
        <div id="ctl00_Div1" class="top" nowrap="nowrap">
        <ul class="nav">
          
            <li>
               <a id="ctl00_HyperLink22" href="ProductListing.aspx">Products</a>        
            </li>
            
            <li>
                <a id="ctl00_HyperLink15" href="Ad_NewsHome.aspx">News</a>        
            </li>
            <li>
                <a id="ctl00_HyperLink16" href="Ad_EventHome.aspx">Event</a>        
            </li>
            
                       
            <li>
               <a id="ctl00_HyperLink17" href="Ad_FaqHome.aspx">Faq</a>        
            </li>
                       <li>
               <a id="ctl00_HyperLink21" href="Ad_TestimonialHome.aspx">Testimonial</a>        
            </li>
         
           
             <li>
               <a id="ctl00_HypMenuBtn1" href="Ad_OwnButtonCreate.aspx">MyButton1</a>        
            </li>
            <li>
               <a id="ctl00_HypMenuBtn2" href="Ad_OwnButtonCreate2.aspx">MyButton2</a>        
            </li>
             <li>
               <a id="ctl00_HypMenuBtn3" href="Ad_OwnButtonCreate3.aspx">MyButton3</a>        
            </li>
            <li>
               <a id="ctl00_HypMenuBtn4" href="Ad_OwnButtonCreate4.aspx">MyButton4</a>        
            </li>
            <li>
               <a id="ctl00_HypMenuBtn5" href="Ad_OwnButtonCreate5.aspx">MyButton5</a>        
            </li>
             <li>
               <a id="ctl00_HypMenuBtn6" href="Ad_OwnButtonCreates.aspx?MyButtonNo=6">MyButton6</a>        
            </li>
             <li>
               <a id="ctl00_HypMenuBtn7" href="Ad_OwnButtonCreates.aspx?MyButtonNo=7">MyButton7</a>        
            </li>
             <li>
               <a id="ctl00_HypMenuBtn8" href="Ad_OwnButtonCreates.aspx?MyButtonNo=8">MyButton8</a>        
            </li>

        </ul>
        
        </div>
    
    </td>  
    
    </tr>
    
    
    </table>
  
  </div>

</body>
</html>
