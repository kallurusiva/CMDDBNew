<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PgAdvertBM.aspx.cs" Inherits="PgAdvert" %>

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
        .style2
        {
            text-align: left;
        }
        .style3
        {
            text-align: left;
            font-weight: bold;
            text-decoration: underline;
        }
        .style4
        {
            text-decoration: underline;
        }
        .style5
        {
            font-weight: bold;
            text-align: left;
        }
        .style6
        {
            FONT-SIZE: 12px;
            font-weight: bold;
            COLOR: #ff9900;
            FONT-FAMILY: Century Gothic, Verdana, Arial, Helvetica, sans-serif;
            text-align: left;
        }
        .style7
        {
            height: 11px;
        }
        .style8
        {
            text-align: left;
            height: 11px;
        }
        .style9
        {
            text-decoration: underline;
            font-style: italic;
        }
        .style10
        {
            font-weight: bold;
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
                <asp:DropDownList ID="dpLanguage" CssClass="stdDropDown" runat="server" 
                    AutoPostBack="True" onselectedindexchanged="dpLanguage_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Language --</asp:ListItem> 
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
                <asp:Literal ID="ltrTitleHeader" Text="Selamat Datang ke Dunia SMS" runat="server"></asp:Literal>
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
                                        Nama</td>
                                    <td width="2%">
                                        :</td>
                                    <td width="80%">
                                        <asp:Label ID="lblName" CssClass="FormLabelText_Advert" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="FormLabel_Advert">
                                         No. Mobile</td>
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
                                        Laman Pautan Saya </td>
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
                                <asp:Literal ID="ltrProductHeader" Text="Produk kami: SMS Secretary" runat="server"></asp:Literal></div>
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
                                    <td align="left">
                                        <ol>
                                            <li>&nbsp;Kenalan Buku Alamat Tiada Limit </li>
                                            <li>&nbsp;Kumpulan Kategori Tiada Limit </li>
                                            <li>&nbsp;Liputan Antarabangsa </li>
                                            <li>&nbsp;Bahasa SMS Mulingual </li>
                                            <li>&nbsp;Personalise SMS </li>
                                            <li>&nbsp;Laporan SMS </li>
                                            <li>&nbsp;Penjadualan SMS </li>
                                            <li>&nbsp;SMS tak Luput </li>
                                            <li>&nbsp;Tiada Pembaharuan </li>
                                            <li>&nbsp;SMS Pukal </li>
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
                                        NOTE: Kami memberikan Sistem DENGAN PERCUMA SMS Percuma Kredit - Limited Time Only - Daftar Sekarang! Klik Disini!
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
                                <asp:Literal ID="ltrFreeSMSSystem" Text="Sistem SMS Percuma dan Trial Percuma (5 credits)" 
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
                        <td>&nbsp;
                            </td>
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
                        <td align="center" colspan="4" class="font_14SuccessBold MessagerBarCss">&nbsp;  Nota : Sistem SMS Percuma dengan spesifikasi biasa sekarang terbuka untuk Malaysia dan Singapura sahaja.</td>
            
         </tr>
                     <tr>
                        <td align="center">
                            
         <div id="divNOTFREE" style="display: none;">
       <table id="tblNOTfree" runat="server" border="0" cellpadding="0" cellspacing="0" width="90%">
 
         <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
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
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td class="style3">Langkah 1</td>
            <td class="style5">Langkah 1</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td class="style7"></td>
            <td class="style8">(Sila SMS)</td>
            <td class="style8">(Sila SMS)</td>
            <td class="style7"></td>
         </tr>
   
         <%--<tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>--%>
   
         <tr>
            <td>&nbsp;</td>
            <td align="left">
            <div id="Div1" class="PhoneBoxGrad" align="center">
            <b>1M&nbsp;&nbsp;REG</b>&nbsp;&nbsp;<asp:Literal ID="ltrMobileNo1" runat="server"></asp:Literal>&nbsp;&nbsp;NamaPenuhAnda&nbsp; 
            </div>
            </td>
            <td align="left">
            <div id="Div2" class="PhoneBoxGrad" align="center">
            <b>1S&nbsp;&nbsp;REG</b>&nbsp;&nbsp;<asp:Literal ID="ltrMobileNo2" runat="server"></asp:Literal>&nbsp;&nbsp;NamaPenuhAnda&nbsp; 
            </div>
            </td>
            
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td class="style2">HantarKe --&gt; <font class="font_12BlueBold">36553</font></td>
            <td class="style2">HantarKe --&gt;&nbsp; <font class="font_12BlueBold">+ 447624811654</font></td>
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
            <td class="style6"><i><b> Nota </b> :Anda akan menerima Login dan Password</i></td>
            <td class="style6"><i><b> Nota </b> :Anda akan menerima Login dan Password</i></td>
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
            <td class="style3">Langkah 2</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
         
            <tr>
            <td>&nbsp;</td>
            <td class="style2">(Sila SMS)</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
         
         <tr>
            <td>&nbsp;</td>
            <td align="left">
            <div id="Div3" class="PhoneBoxGrad" align="center">
            ON&nbsp;&nbsp;1MACC
            </div>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         <tr>
            <td>&nbsp;</td>
            <td class="style2">HantarKe --&gt; <font class="font_12BlueBold">36553</font></td>
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
            <td class="style6"><span class="style9"><u>Nota</u></span><i> : Perlu untuk melengkapi <b>LANGKAH 2</b> untuk login  
                </i>  </td>
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
            <td class="style6"><i>Mingguan 2-5 Akaun SMS Info dan Berita.
                <br />
                RM<b> 0.50</b>/ SMS Diterima.</i></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
         </tr>
   
         
   
         <tr>
            <td>&nbsp;</td>
            <td class="style6"><i>Untuk Batal SMS <b>Stop 1MACC</b> &nbsp;&nbsp;hantarke -&gt; 
                <span class="style10">36553</span></i></td>
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
            <td><%--<b>Nota</b> : Hanya untuk Telco Celcom / Digi / Maxis.--%></td>
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
           
      <%--           <tr>
                    <td>&nbsp;</td>
                    <td class="font_12BlueBold"  align="center">&nbsp;Ahli Pakej Free tidak akan mendapat "Sistem SMS Percuma". 
                    LANGKAH 2 sampai selesai.<br />
                        <br />
                        <span class="style6">Untuk melengkapi LANGKAH 2</span><br class="style6" />
                        <br />
                        Jenis<font class="font_14SuccessBold"> &#39;ON&nbsp; 1MACC&#39;</font> &nbsp; dan hantar ke 36553
                        
                        </td>
                    <td>&nbsp;</td>
                 </tr>--%>
                 
                  <tr id="tblFree_Tr_MAS" runat="server" visible="true">
                    <td>&nbsp;</td>
                    <td class="font_12BlueBold" align="center">&nbsp;Ahli Pakej Free tidak akan mendapat "Sistem SMS Percuma". 
                    LANGKAH 2 sampai selesai.<br />
                        <br />
                        <span class="style6">Untuk melengkapi LANGKAH 2</span><br class="style6" />
                        <br />
                        Jenis<font class="font_14SuccessBold"> &#39;ON&nbsp; 1MACC&#39;</font> &nbsp; dan hantar ke 36553</td>
                    <td>&nbsp;</td>
                 </tr>
                 
                 <tr id="tblFree_Tr_Sing" runat="server" visible="true">
                    <td>&nbsp;</td>
                    <td class="font_12BlueBold" align="center">&nbsp;Ahli Pakej Free anggota tidak dibenarkan untuk penaja atau memberikan FREE SMS SISTEM,
                       jika tidak ada LANCAR MA Dibeli. .<br />
                        <br />
                        Tolong minta sponsor untuk membeli  <span class="style6"><font class="font_14SuccessBold">'MA10 Guarantee Certificate'. </font></span><br/>
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
                                <asp:Literal ID="ltrUpgrade" Text="Mengapa Upgrade" 
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
                                        Mengapa Upgrade? </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <ol>
                                            <li>&nbsp;Pesanan Birthday Automatik - a) Kirim ke teman b) Alert Birthday Reminder Mesej boleh merangkumi "Promosi Perniagaan atau Tawaran Hadiah .</li>
                                            <li>&nbsp;Automatik Season Greeting & User Define Greeting - Fully Automated semua Salam Musim. </li>
                                            <li>&nbsp;Arahan Mobile Access - Mampu untuk mengakses SMS System dengan anda Mobile.</li>
                                             <ol type="a">
                                            <li>Tambah kenalan Via SMS</li>
                                            <li>Hantar SMS Kategori Via SMS</li>
                                            </ol>
                                            <li>&nbsp;Mampu untuk bergabung dengan kami Program Afiliasi - Untuk memberikan Sistem SMS Mampu Sponsor mudah ..!!</li>
                                            <li>&nbsp;Dapat menikmati Insentif Lebih Pendapatan.</li>
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
                                        NOTA: Untuk Upgrade - Hubungi Sponsor Anda Sekarang</td>
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
                                <asp:Literal ID="ltrSigProduct" Text="Produk Tanda Tangan Kami" 
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
                                        Manfaat Ciri-ciri Penuh Mobile Secretary </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <ol>
                                            <li>Membantu anda untuk menjadi orang bijaksana oleh
                                             <ol type="a">
                                            <li>Pesanan SMS automatik untuk Birthday Orang Penting.</li>
                                            <li>Pesanan SMS Automated Ucapan.</li>
                                            </ol>
                                            <li>Kenalan anda Sepenuhnya Backup jika mobile anda hilang / dicuri.</li>
                                            <li>Mengendalikan segala sesuatu termasuk menyimpan kenalan Via SMS - Mobile Access Via SMS.</li>
                                            <li>Berasaskan web dan Mobile Access - 24 / 7 Anytime Anywhere. </li>
                                            <li>Diperibadikan SMS Alamat anda dengan Nama Penerima. </li>
                                            <li>Unlimited Kategori dan Kenalan Alamat. </li>
                                            <li>Lifetime Licience - Tidak Kadaluwarsa SMS. </li>
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
                                        dan masih banyak lagi ... .. kita akan kita malar upgrade dari kami SMS Sistem.</td>
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
