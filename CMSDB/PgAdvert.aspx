<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PgAdvert.aspx.cs" Inherits="PgAdvert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Common/CommonStyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            text-align: left;
        }
        .style4
        {
            FONT-SIZE: 12px;
            font-weight: bold;
            COLOR: #ff9900;
            FONT-FAMILY: Century Gothic, Verdana, Arial, Helvetica, sans-serif;
            text-align: left;
        }
        .style5
        {
            FONT-SIZE: 12px;
            font-weight: bold;
            COLOR: #ff9900;
            FONT-FAMILY: Century Gothic, Verdana, Arial, Helvetica, sans-serif;
            text-align: left;
            font-style: italic;
        }
        .style6
        {
            text-decoration: underline;
        }
        </style>
        
        <script language="javascript" type="text/javascript">

            function OpentblFREE() {
                alert('Free');
                tblFREE.style.display = '';
                tblNOTfree.style.display = 'none';
                return false;

            }

            function OpentblNotFREE() {
                alert('NOT Free');
                tblNOTfree.style.display = '';
                tblFREE.style.display = 'none';
                return false;
            }

            function fnShowHideDiv(mView) {
                if (mView == 'FREE') {
                    document.getElementById('divFREE').style.display = 'block';
                    document.getElementById('divNOTFREE').style.display = 'none';
                }
                else {
                    document.getElementById('divNOTFREE').style.display = 'block';
                    document.getElementById('divFREE').style.display = 'none';
                }

            }
        
        </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <table cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td width="2%"><a name="top"></a>
                &nbsp;</td>
            <td width="96%" class="font_12BlueBold" align="right">
                Select Language&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="dpLanguage"  CssClass="stdDropDown" runat="server" 
                    onselectedindexchanged="dpLanguage_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem Value="0">-- language --</asp:ListItem>
                    <asp:ListItem Value="en">English</asp:ListItem>
                    <asp:ListItem Value="bm">Bahasa Melayu</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="2%">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="">
                <div class="cssfaq_head">
                <div class="cssfaq_headText"> 
                <asp:Literal ID="ltrTitleHeader" Text="Welcome to the World of SMS" runat="server"></asp:Literal>
                &nbsp;- Reconnecting People... Anytime Anywhere Everywhere</div>
                
            </td>
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
                <table class="stdtableBorder_AdvertHead" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="96%">
                            &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="18%" class="FormLabel_Advert">
                                        Name</td>
                                    <td width="2%">
                                        :</td>
                                    <td width="80%">
                                        <asp:Label ID="lblName" CssClass="FormLabelText_Advert" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="FormLabel_Advert">
                                        Mobile No</td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblMobileno" CssClass="FormLabelText_Advert" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="FormLabel_Advert">
                                        Status</td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblStatus" CssClass="FormLabelText_Advert" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                             <%--   <tr>
                                    <td  class="FormLabel_Advert">
                                        My Domain / My SubDomain</td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblDomain" CssClass="FormLabelText_Advert" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr height="40">
                                    <td  class="FormLabel_Advert">
                                        My Pagelink</td>
                                    <td>
                                        :</td>
                                    <td>
                                        <asp:Label ID="lblPageLink" CssClass="FormLabelText_Advert" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;</td>
                        
                        
                    </tr>
                    
                    
                    
                </table>
            </td>
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
            <td align="left">
                 <div align="left" id="divProducts"  class="divAdvertBox">
                 <div class="divAdvertBoxhead">
                            <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                            <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                            <div class="sideBoxheadText"> 
                                <asp:Literal ID="ltrProductHeader" Text="Our Product: SMS Secretary" runat="server"></asp:Literal></div>
                  </div>   
                  
        </div></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center">
                <table cellpadding="0" cellspacing="0" class="stdtableBorder_Advert" width="99%">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" width="90%">
                                <tr>
                                    <td class="font_14SuccessBold" align="left">
                                        Features </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" class="font_12BoldGrey">
                                        <ol>
                                            <li>&nbsp;Unlimited Contacts Address Book </li>
                                            <li>&nbsp;Unlimited Category Group </li>
                                            <li>&nbsp;Worldwide Coverage </li>
                                            <li>&nbsp;Multi Language SMS </li>
                                            <li>&nbsp;Personalised SMS </li>
                                            <li>&nbsp;SMS Reporting </li>
                                            <li>&nbsp;Schedule SMS </li>
                                            <li>&nbsp;No SMS Expiry </li>
                                            <li>&nbsp;No Renewal </li>
                                            <li>&nbsp;Bulk SMS </li>
                                        </ol>
                                    </td>
                                    <td>
                                        <img alt="Automated SMS" src="Images/AutomatedSMS.jpg" 
                                            style="width: 100px; height: 139px" /></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" class="font_11Msg_Success">
                                        NOTE: We give away Free SMS System with free credits -- Limited Time Only -- Register Now !! Click Here !!
                                    </td>
                                </tr>
                            </table>
                         </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                             <tr>
                        <td>
                            &nbsp;</td>
                            
                    </tr>
                    </tr>
                </table>
            </td>
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
            <td align="left">
                 <div align="left" id="divProducts0"  class="divAdvertBox">
                 <div class="divAdvertBoxhead">
                            <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                            <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                            <div class="sideBoxheadText"> 
                                <asp:Literal ID="ltrFreeSMSSystem" Text="Free SMS System and Free Trial (5 credits)" 
                                    runat="server"></asp:Literal></div>
                  </div>   
                  
        </div></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center">
                <table cellpadding="0" cellspacing="0" class="stdtableBorder_Advert font_12BoldGrey" width="99%">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="FormLabelText_Advert" align="center">
                            TO Sign Up:&nbsp;&nbsp; [ <a id="hypSignUp" runat="server" style="cursor:hand;" class="links_AdvertDomain">Click Here</a>]</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="font_14SuccessBold MessagerBarCss" align="center">
                            &nbsp;  Note: Free SMS System with basic features is now available for Malaysia and Singapore Only.</td>
                    </tr>
                    <tr>
                        <td class="font_14SuccessBold">
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td align="center">
                            
                          <div id="divNOTFREE" style="display: none;">
                             <table id="tblNOTfree" runat="server" border="0" cellpadding="0" cellspacing="0" width="90%">
         <tr class="font_14BoldGrey">
            <td>&nbsp;</td>
            <td>
                <img alt="mas" src="Images/flag_mas_small.jpg" 
                    style="width: 50px; height: 27px" />&nbsp;&nbsp; MALAYSIA</td>
            <td>
                <img alt="sing" src="Images/Flag_sing_small.jpg" 
                    style="width: 50px; height: 27px" />&nbsp;&nbsp;&nbsp; SINGAPORE</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td align="left" class="font_12BlueBold"><u>         <b>Nota</b></u> : Hanya untuk Telco Celcom / Digi / Maxis Mobile.
                                        
            
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;
            
            
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td class="style3"><b><u>STEP 1</u></b></td>
            <td class="style3"><b><u>STEP 1</u></b></td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td class="style3">(Please SMS)</td>
            <td class="style3">(Please SMS)</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td align="left"> 
            <div id="Div1" class="PhoneBoxGrad" align="center">
              <b>1M&nbsp;&nbsp;REG</b>&nbsp;&nbsp;<asp:Literal ID="ltrMobileNo1" runat="server"></asp:Literal>&nbsp;&nbsp;YourName&nbsp; 
            </div>      
            </td>
            <td align="left">
            <div id="dvph" class="PhoneBoxGrad" align="center">
            <b>1S&nbsp;&nbsp;REG</b>&nbsp;&nbsp;<asp:Literal ID="ltrMobileNo2" runat="server"></asp:Literal>&nbsp;&nbsp;YourName&nbsp; 
            </div>
            </td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td class="style3">Send to --&gt; <font class="font_12BlueBold">36553</font></td>
            <td class="style3">Send to --&gt;&nbsp; <font class="font_12BlueBold">+ 447624811654</font></td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td class="style4"><i><b><u>Note</u></b> : You will receive Login and Password</i></td>
            <td class="style4"><i><b><u>Note</u></b> : You will receive Login and Password</i></td>
            <td>&nbsp;</td>
         </tr>
   
            <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
         
            <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
         
            <tr>
            <td>&nbsp;</td>
            <td class="style3"><b><u>STEP 2</u></b></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
         
         <tr>
            <td>&nbsp;</td>
            <td class="style3">
                (Please SMS)</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td align="left">
            <div id="Div2" class="PhoneBoxGrad" align="center">
            ON&nbsp;&nbsp;1MACC
            </div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td class="style3">Send to --&gt; <font class="font_12BlueBold">36553</font></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td class="style4"><span class="style5"><u>Note</u></span><i> : Need to complete 
                <b>STEP 2</b> to login.</i></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td align="center" class="font_stdupdateMsg">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         
   
         <tr>
            <td>&nbsp;</td>
            <td class="style4"><i>Weekly 2-5 SMS Account Info and News.
                <br />
                RM<b> 0.50</b> / SMS Received.</i></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         
   
         <tr>
            <td>&nbsp;</td>
            <td class="style4"><i>To Cancel sms, <b>STOP 1&nbsp; MACC</b>&nbsp;&nbsp; send to -&gt; 
                <b>36553</b></i></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         
   
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
   </table>
                            </div>  
                            </td>
                    </tr>
                     <tr>
                        <td>
                           <div id="divFREE" style="display: none;"> 
                                                
                <table id="tblFREE" runat="server" border="0" cellpadding="0" cellspacing="0" width="90%">
                 <tr class="font_14BoldGrey">
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                 </tr>
           
                 <tr id="tblFree_Tr_MAS" runat="server" visible="true">
                    <td>&nbsp;</td>
                    <td class="font_12BlueBold" align="center">&nbsp;FREE members are not allowed to 
                        sponsor or give away FREE SMS SYSTEM,  until STEP 2 is completed.<br />
                        <br />
                        <span class="style6">To complete STEP 2</span><br class="style6" />
                        <br />
                        Type<font class="font_14SuccessBold"> &#39;ON&nbsp; 1MACC&#39;</font> &nbsp; and send to 36553</td>
                    <td>&nbsp;</td>
                 </tr>
                 
                 <tr id="tblFree_Tr_Sing" runat="server" visible="true">
                    <td>&nbsp;</td>
                    <td class="font_12BlueBold" align="center">&nbsp;FREE members are not allowed to 
                        sponsor or give away FREE SMS SYSTEM,  if no CURRENT MA Purchased.<br />
                        <br />
                        Please ask sponsor to purchase <span class="style6"><font class="font_14SuccessBold">'MA10 Guarantee Certificate'. </font></span><br/>
                        </td>
                    <td>&nbsp;</td>
                 </tr>
                 
                 
                 <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                 </tr>
                 
                            
                 <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                 </tr>
                 
                            
                            </table>
                            </div>  
                            </td>
                             <tr>
                        <td>
                            &nbsp;</td>
                            
                    </tr>
                    </tr>
                </table>
            </td>
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
            <td align="right">
                &nbsp;<a href="#top" class="links_TopLineRed"> Go TOP </a></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="left">
                 <div align="left" id="divProducts1"  class="divAdvertBox">
                 <div class="divAdvertBoxhead">
                            <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                            <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                            <div class="sideBoxheadText"> 
                                <asp:Literal ID="ltrAddtionalFeatures" Text="Addtional Features and Benefits for Upgrade" 
                                    runat="server"></asp:Literal></div>
                  </div>   
                  
        </div></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center">
                <table cellpadding="0" cellspacing="0" class="stdtableBorder_Advert" width="99%">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td  align="left" class="font_14SuccessBold">
                            &nbsp;&nbsp;&nbsp;Malaysia</td>
                    </tr>
                    <tr>
                        <td   align="left">
                            &nbsp;&nbsp;&nbsp;<img alt="Prd_mas" src="Images/Prd_Mas_features.gif" 
                                style="width: 600px; height: 426px" /></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td align="left" class="font_14SuccessBold">                           
                            
                            &nbsp;&nbsp;&nbsp;Singapore</td>
                    </tr>
                     <tr>
                        <td   align="left">
                            &nbsp;&nbsp;&nbsp;<img alt="Prd_Sing" src="Images/Prd_Sing_features.jpg" 
                                style="width: 713px; height: 379px" /></td>
                             <tr>
                        <td>
                            &nbsp;</td>
                            
                    </tr>
                    </tr>
                </table>
            </td>
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
            <td align="right">
                &nbsp;&nbsp;<a href="#top" class="links_TopLineRed"> Go TOP </a></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="left">
                 <div align="left" id="divProducts2"  class="divAdvertBox">
                 <div class="divAdvertBoxhead">
                            <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                            <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                            <div class="sideBoxheadText"> 
                                <asp:Literal ID="ltrUpgrade" Text="Why Upgrade" 
                                    runat="server"></asp:Literal></div>
                  </div>   
                  
        </div></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center">
                <table cellpadding="0" cellspacing="0" class="stdtableBorder_Advert" width="99%">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" width="90%">
                                <tr>
                                    <td class="font_14SuccessBold" align="left">
                                        Why Upgrade ? </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" class="font_12BoldGrey">
                                        <ol>
                                            <li>&nbsp;Automated Birthday Greeting – a) Send to Friends b) Birthday Reminder Alert 
                                                Message can include “Business Offer or Gift Offer “ .</li>
                                            <li>&nbsp;Automated Season Greeting &amp; User Define Greeting – Fully Automated all Season 
                                                Greetings. </li>
                                            <li>&nbsp;Mobile Instruction Access – Able to access your SMS System with your Mobile.</li>
                                             <ol type="a">
                                            <li>Add contact Via SMS</li>
                                            <li>Send Category SMS Via SMS</li>
                                            </ol>
                                            <li>&nbsp;Able to join our Affiliate Program – To give away FREE SMS System.&nbsp; Able 
                                                to Sponsor easily ..!!</li>
                                            <li>&nbsp;Able to enjoy More Incentives Income.</li>
                                        </ol>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" class="font_11Msg_Success">
                                        NOTE: To upgrade, Contact your Sponsor Now</td>
                                </tr>
                            </table>
                         </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                             <tr>
                        <td>
                            &nbsp;</td>
                            
                    </tr>
                    </tr>
                </table>
            </td>
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
            
            <td align="right">
                <a href="#top" class="links_TopLineRed"> Go TOP </a></td>
                <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="left">
                 <div align="left" id="divProducts3"  class="divAdvertBox">
                 <div class="divAdvertBoxhead">
                            <div class="sideBoxTLtarc"><img src="Images/table_top_Leftarc.gif" /></div>
                            <div class="sideBoxTRtarc"><img src="Images/table_top_Rightarc.gif" /></div>
                            <div class="sideBoxheadText"> 
                                <asp:Literal ID="ltrSigProduct" Text="Our Signature Product" 
                                    runat="server"></asp:Literal></div>
                  </div>   
                  
        </div></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center">
                <table cellpadding="0" cellspacing="0" class="stdtableBorder_Advert" width="99%">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" width="90%">
                                <tr>
                                    <td class="font_14SuccessBold" align="left">
                                        Benifits of Full
                                        Features of Mobile Secretary</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" class="font_12BoldGrey">
                                        <ol>
                                            <li>Helps you to become a thoughtful person by
                                             <ol type="a">
                                            <li>Automated Alert for Important Person Birthday.</li>
                                            <li>Automated Season Greeting.</li>
                                            </ol>
                                            <li>Fully Backup your Contacts in case you lost / stolen mobile.</li>
                                            <li>Control everything including storing of Contact Via SMS – Mobile Access Via SMS.</li>
                                            <li>&nbsp;WebBased and Mobile Access – 24/7 Anytime Anywhere. </li>
                                            <li>Personalised SMS Address your Recipient by Name </li>
                                            <li>Unlimited Category and Address Contacts </li>
                                            <li>LifeTime Licience – No SMS Expiry </li>
                                            <li>Multi-Languange – Unicode</li>
                                        </ol>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" class="font_11Msg_Success">
                                        and Much More.....&nbsp; we are constantly upgrading our SMS system.</td>
                                </tr>
                            </table>
                         </td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                             <tr>
                        <td>
                            &nbsp;</td>
                            
                    </tr>
                    </tr>
                </table>
            </td>
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
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
    </form>
</body>
</html>
