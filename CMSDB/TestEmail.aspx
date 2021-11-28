<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestEmail.aspx.cs" Inherits="TestEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <style type="text/css">
        .SearchLabelBold        {height:25px; FONT-SIZE: 12px; COLOR: #221F0B; padding-left:10px; border-bottom: 1px solid #DEDBCA;  FONT-FAMILY: Arial, Helvetica, sans-serif; font-weight:bold;}
        .SearchLabel            {height:25px; FONT-SIZE: 12px; COLOR: #44412F; padding-left:2px; border-bottom: 1px solid #DEDBCA;  FONT-FAMILY: Arial, Helvetica, sans-serif;}
        .stdtableBorder_Search		{ background-color:#F7F9E5; BORDER-BOTTOM: #b8e0fb 1px solid; BORDER-TOP: #b8e0fb 1px solid; width:98%;
                              		   FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: "Lucida Console", Arial,Verdana, Helvetica, sans-serif;}
        .font_12BlueBold	{ FONT-SIZE: 12px;  font-weight:bold; COLOR: #2291A1; height:25px; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
        .subHeaderFontGrad  	{font: bold 120%/100% "Trebuchet MS","Lucida Console", Arial, sans-serif;	position: relative;	margin: 30px 0 50px; vertical-align:middle;	color: #687367; font-style:italic;}
        .stdtableBorder_Main		{ background-color:#FAFCFA; border: #CDF2D6 1px solid; FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;}
        .bkgNewsBoxOren		    {background-color:#F3D651;}
        .bkgFooter		    {background-color:#FAFCFA;
                  		     filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FAFCFA', endColorstr='#FFFFFF'); /* for IE */
                            background: -webkit-gradient(linear, left top, left bottom, from(#FAFCFA), to(#FFFFFF)); /* for webkit browsers */
                            background: -moz-linear-gradient(top,  #FAFCFA,  #FFFFFF); /* for firefox 3.6+ */ 
                  		     }
        
        
        .sideBoxContent 
 {FONT-SIZE: 8pt; color:#8E897C; text-align:justify; padding: 8px 8px 8px 8px; font-family: Tahoma, Arial, Verdana, Lucida Bright; height: 150px; overflow:hidden;
  background: #ECECEC; /* for non-css3 browsers */
    filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#ECECEC', endColorstr='#FFFFFF'); /* for IE */
background: -webkit-gradient(linear, left top, left bottom, from(#ECECEC), to(#FFFFFF)); /* for webkit browsers */
background: -moz-linear-gradient(top,  #ECECEC,  #FFFFFF); /* for firefox 3.6+ */ }


        .font_12Normal		{ FONT-SIZE: 12px; COLOR: #03C0C6; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif}
        </style>
</head>
<body>
    
    <%--Registration Email section --%>
    <div>
        <table cellpadding="0" cellspacing="0" align="center" width="80%" class="stdtableBorder_Main">
            <tr class="bkgNewsBoxOren subHeaderFontGrad">
                <td class="style2" style="height: 40px;" align="center">1worldSMS.com&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Dear <font class='font_12BlueBold'>Samvoon </font>,</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Greetings from 1worldsms.com</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    You have recently registered <b>www.help.1worldsms.com</b> using this email address.<br />
&nbsp;we are delighted to have 
                    you as a registered user. </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class='font_12Normal'>
                    Please find your login information below.</td>
            </tr>
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" width="80%" class="stdtableBorder_Search" >
                        <tr>
                            <td width="40%" class="SearchLabelBold">
                                Admin Login</td>
                            <td width="60%" align="left" class="SearchLabel">
                                Pencil</td>
                        </tr>
                        <tr>
                            <td  class="SearchLabelBold">
                                Admin Password</td>
                            <td align="left" class="SearchLabel">
                                pen123</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td  class="SearchLabelBold">
                                Registered Mobile</td>
                            <td align="left" class="SearchLabel">
                                6012356489</td>
                        </tr>
                        <tr>
                            <td class="SearchLabelBold">
                                Registered Name
                            </td>
                            <td align="left" class="SearchLabel">
                                Sri<b> </b>Hari<b> </b>Moota</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Click here to open your registered website :&nbsp; <a href="#">DomainName.website.com</a></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Regards,</td>
            </tr>
            <tr>
                <td>
                    Support Team, </td>
            </tr>
            <tr>
                <td>
                    1WorldSMS.com&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <b>NOTE</b>:&nbsp; This is a system generated email. Please do not reply this email.</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    
    
    
    
    <table cellpadding="0" cellspacing="0" width="600px" class="stdtableBorder_Main">
        <tr height="0px">
            <td width='3%'>
                </td>
            <td width='94%'>
                </td>
            <td width='3%'>
                </td>
        </tr>
        <tr>
            <td colspan='3' style="background-image: url(Images/Mail/header1_green.jpg); background-repeat: no-repeat; height: 100px;">
            
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Hi</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Greetings from 1SMSBusiness.com</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Thank you,<br />
                Support Team @ 1SMSBusiness.com</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class='bkgFooter' height='50px'>
        <td>
                &nbsp;</td>
            <td align="right"  valign="middle">
                &nbsp; All Copyrights Reserved @2010
                </td>
                <td>
                &nbsp;</td>
        </tr>
    </table>


    <br />

    <br />

    <br />




    
    
    
    
</body>
</html>
