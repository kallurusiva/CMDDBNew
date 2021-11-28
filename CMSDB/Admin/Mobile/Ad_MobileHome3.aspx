<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Mobile/AdminMasterDIYMB.master" AutoEventWireup="true" CodeFile="Ad_MobileHome3.aspx.cs" Inherits="Admin_Ad_MobileHome3" %>

<%@ Register src="Ad_Mobi_Menu.ascx" tagname="Ad_Mobi_Menu" tagprefix="uc1" %>

<%@ Register TagPrefix="cc1" Namespace="ComboImg" Assembly="ComboImg" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


<style type="text/css">
.panelheight {max-height:90%;}
.links_FuncLinks			{COLOR: #3E8AD6; FONT-FAMILY: "Trebuchet MS", Arial, Helvetica, sans-serif; FONT-SIZE: 9pt; FONT-WEIGHT: bold; TEXT-DECORATION: none}
A.links_FuncLinks:hover 	{COLOR: #1F1F1F; FONT-FAMILY: "Trebuchet MS", Arial, Helvetica, sans-serif; FONT-SIZE: 9pt; FONT-WEIGHT: bold; TEXT-DECORATION: underline}

.std_TitleRedLarge{font-family:Verdana;font-size:14px;color:#FD3601;font-weight:bold;text-decoration:none;
    text-align: left;
}
.bgTheme2{background-color:#ccda35}

.std_TitleGreenLarge{font-family:Verdana;font-size:14px;color:#0D44F4;font-weight:bold;text-decoration:none;
    text-align: left;
}
        .style2
        {
            height: 15px;
        }
                
        
        .txtBlackBLarge{font-family:Arial;font-size:16px;font-weight:bold;color:#000;text-decoration:none;}
.txtBlackSmall{font-family:Arial;font-size:11px;color:#000;text-decoration:none;}
.txtBlackMedium{font-family:Arial;font-size:12px;color:#000;text-decoration:none;}
.txtBlackBMedium{font-family:Arial;font-size:12px;font-weight:bold;color:#000;text-decoration:none;}

.modalBackground
{
    background-color:#ffffdd;
    filter:alpha(opacity=40);
    opacity:0.5;
    border-width:1px;
    border-style:solid;
    border-color:#CCCCCC;
    padding:3px;
    position:absolute;
}
.modalInsideBackground
{
    background-color:#efefef;
    border: 2px solid #ccda35;
    color : #333333;
    padding: 20px 20px 20px 20px;
    
}

.btSubmitSmall{
    font-family:Arial;font-size:11px;font-weight:bold;color:#000;text-decoration:none;
    height: 22px;
}
    </style>
    

    <style type="text/css">
        .style1
        {
            text-align: left;
        }
    </style> 
    <link href="dd.css" rel="stylesheet" type="text/css" />

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form2" runat="server">

       <asp:ToolkitScriptManager ID="ToolkitScriptManager1" CombineScripts="false" runat="server">
    </asp:ToolkitScriptManager>


<script src="jquery-1.2.2.pack.js" type="text/javascript"></script>
<style type="text/css">

div.htmltooltip{
position: absolute; /*leave this and next 3 values alone*/
z-index: 500;
left: -500px;
top: -500px;
background: #FFFFFF;
border: 10px solid #F2EDED;
color: #8B8787;
padding: 3px;
width: 350px; /*width of tooltip*/
}

    .style2
    {
        height: 20px;
    }

    </style>

<script src="htmltooltip.js" type="text/javascript"></script>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
       
       
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../../Images/inf_Error.gif" 
                     alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
             <div id="dvTrialPeriodAlert" runat="server" visible="false" class="TPAlert">
                <asp:Label ID="lblTrialPeriodText" CssClass="TPAlertFont" runat="server" Text=""></asp:Label>
             </div>
           </td>
        </tr>
        <tr>
            <td align="center">
            
             
             
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;<asp:Literal ID="ltrMobileSettings" runat="server"></asp:Literal></td>
                       
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr style="height:20px;">
                        <td width="3%">&nbsp;</td>
                        <td width="35%">&nbsp;</td>
                        <td width="5%">&nbsp;</td>
                        <td width="30%">&nbsp;</td>
                        <td width="15%">&nbsp;</td>
                        <td width="2%">&nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td class="style2"></td>
                        <td  class="style2">
                        
                            <asp:CheckBox ID="chkMobileDetection" runat="server"/>
                            <asp:Label ID="lblMwHeader" CssClass="font_14SuccessBold" runat="server" 
                                Text="SET OFF Mobile Website Detection "></asp:Label></td>
                        
                        <td colspan="3" align="left" class="style2" nowrap>
                            <asp:Label ID="Label1" CssClass="FontBRowHelp" runat="server" Text="[ When 'ticked', the system would skip Mobile Website detection on SmartPhones or HandHeld devices and would directly navigate to Full Web Site. ]"></asp:Label>
                        </td>
                        
                        <td class="style2"></td>
                    </tr>
                    
                
                    
                    <tr style="height:20px;">
                        <td width="3%">&nbsp;</td>
                        <td width="35%">&nbsp;</td>
                        <td width="5%">&nbsp;</td>
                        <td width="30%">&nbsp;</td>
                        <td width="15%">&nbsp;</td>
                        <td width="2%">&nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td valign="top">
                        
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                        <table id="tblSettings" cellpadding="0" cellspacing="0" width="100%" class="stdtable_BdrBlue_BkgGrey">
                        <tr>
                            <td align="left" class="FontBHeader">Templates</td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowTextBkg" >
                                &nbsp;Select Templates for the Mobile Website.</td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowText" >
                                <asp:DropDownList ID="ddlTemplates" CssClass="stdDropDown2" runat="server" 
                                    AutoPostBack="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                       
                        
                        <tr>
                            <td style="height:10px;" class="style1 FontBRowTextBkg ddlimg"  >
                                </td>
                        </tr>
                       
                        
                        <tr>
                            <td align="left" class="FontBHeader">Title Rows</td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowTextBkg">Enter Title Row 1</td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1  FontBRowText">
                                <asp:TextBox ID="txtTitle1" runat="server" CssClass="stdTextField" MaxLength="25" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowTextBkg">Enter Title Row2</td>
                        </tr>
                       
                        
                        <tr>
                            <td class="style1 FontBRowText">
                                <asp:TextBox ID="txtTitle2" CssClass="stdTextField" Width="400px" MaxLength="25" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                       
                        
                        <tr>
                            <td style="height:10px;" class="style1 FontBRowTextBkg">
                                </td>
                        </tr>
                       
                        
                        <tr>
                            <td align="left" class="FontBHeader">Buttons</td>
                        </tr>
                        
                        <tr>
                            <td style="border-bottom: solid 1px #86B6B0;" class="FontBRowTextBkg" align="right" >
                                &nbsp;Select buttons to show/Hide.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                                <img src="../../Images/Mobile/preview.png" /> preview&nbsp;
                                <%--<img src="../../Images/Mobile/edit.png" /> edit--%></td>
                                
                        </tr>
                        <tr>
                        <td class="style1">
                                <div id="divbuttomHTML" runat="server">
                                
                                </div>
                            
                        </td>
                        </tr>
                       
                
                        <tr>
                        <td class="style1">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr height="0">
                            <td width="70%"></td>
                            <td width="10%"></td>
                            </tr>
                           
                            <tr class="chkboxRowBkg">
                            <td class="FontBRowText1">
                            <a href="#" rel="htmltooltip">
                             <asp:Image ID="ImgPw_AboutUs" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" runat="server" /></a>
                             &nbsp; <asp:CheckBox ID="chkAboutUs" Text="<%$ Resources:LangResources, AboutUs %>"  runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp; 
                                <%--<asp:HyperLink ID="HyperLink23" ImageUrl="~/Images/Mobile/edit.png" ToolTip="Click to edit About Us Content" CssClass="imgChkBoxEdit" NavigateUrl="~/Admin/Ad_AboutUsPageListing.aspx" runat="server"></asp:HyperLink>--%>
                                </td>
                             
                            </tr>
                           
                            <tr class="chkboxRowBkg">
                            <td class="FontBRowTextBkg" style='padding-left: 40px;' colspan="2">&nbsp;My Mobile Buttons</td>
                            </tr>
                           
                           
                                <tr class="chkboxRowBkg">
                                    <td class="FontBRowText3">
                                    <a href="#" rel="htmltooltip"><asp:Image ID="Image2" runat="server" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" /></a>
                                        &nbsp;
                                        <asp:CheckBox ID="chkOwnMobileBtn1" runat="server" Text="Own Mobile Button 1" />
                                    </td>
                                    <td align="center" class="FontBRowText1">
                                        &nbsp;
                                        <%--<asp:HyperLink ID="HyperLink1" CssClass="imgChkBoxEdit" ImageUrl="~/Images/Mobile/edit.png" ToolTip="Click to edit Mobile Web Button Content" NavigateUrl="~/Admin/Mobile/Ad_MobileOwnButtonCreate.aspx?bt=1" runat="server"></asp:HyperLink>--%>
                                    </td>
                                </tr>
                           
                           
                            <tr class="chkboxRowBkg">
                            <td class="FontBRowText3">
                            <a href="#" rel="htmltooltip"><asp:Image ID="Image6" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" runat="server" /></a>
                            &nbsp; <asp:CheckBox ID="chkOwnMobileBtn2" Text="Own Mobile Button 2" runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp; <%--<asp:HyperLink ID="HyperLink2" CssClass="imgChkBoxEdit" ToolTip="Click to edit Mobile Web Button Content" ImageUrl="~/Images/Mobile/edit.png" NavigateUrl="~/Admin/Mobile/Ad_MobileOwnButtonCreate.aspx?bt=2" runat="server"></asp:HyperLink>--%></td>
                            </tr>
                           
                           
                            <tr class="chkboxRowBkg">
                            <td class="FontBRowText3"> <a href="#" rel="htmltooltip"><asp:Image ID="Image8" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" runat="server" /></a>
                            &nbsp; <asp:CheckBox ID="chkOwnMobileBtn3" Text="Own Mobile Button 3" runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp; <%--<asp:HyperLink ID="HyperLink3" CssClass="imgChkBoxEdit" ToolTip="Click to edit Mobile Web Button Content" ImageUrl="~/Images/Mobile/edit.png" NavigateUrl="~/Admin/Mobile/Ad_MobileOwnButtonCreate.aspx?bt=3" runat="server"></asp:HyperLink>--%></td>
                            </tr>
                           
                           
                            <tr class="chkboxRowBkg">
                            <td class="FontBRowText3"> <a href="#" rel="htmltooltip"><asp:Image ID="Image3" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" runat="server" /></a>
                            &nbsp; <asp:CheckBox ID="chkOwnMobileBtn4" Text="Own Mobile Button 4" runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp; <%--<asp:HyperLink ID="HyperLink3" CssClass="imgChkBoxEdit" ToolTip="Click to edit Mobile Web Button Content" ImageUrl="~/Images/Mobile/edit.png" NavigateUrl="~/Admin/Mobile/Ad_MobileOwnButtonCreate.aspx?bt=3" runat="server"></asp:HyperLink>--%></td>
                            </tr>
                            
                            
                             <tr class="chkboxRowBkg">
                            <td class="FontBRowText3"> <a href="#" rel="htmltooltip"><asp:Image ID="Image4" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" runat="server" /></a>
                            &nbsp; <asp:CheckBox ID="chkOwnMobileBtn5" Text="Own Mobile Button 5" runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp; <%--<asp:HyperLink ID="HyperLink3" CssClass="imgChkBoxEdit" ToolTip="Click to edit Mobile Web Button Content" ImageUrl="~/Images/Mobile/edit.png" NavigateUrl="~/Admin/Mobile/Ad_MobileOwnButtonCreate.aspx?bt=3" runat="server"></asp:HyperLink>--%></td>
                            </tr>
                            
                            
                             <tr class="chkboxRowBkg">
                            <td class="FontBRowText3"> <a href="#" rel="htmltooltip"><asp:Image ID="Image5" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" runat="server" /></a>
                            &nbsp; <asp:CheckBox ID="chkOwnMobileBtn6" Text="Own Mobile Button 6" runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp; <%--<asp:HyperLink ID="HyperLink3" CssClass="imgChkBoxEdit" ToolTip="Click to edit Mobile Web Button Content" ImageUrl="~/Images/Mobile/edit.png" NavigateUrl="~/Admin/Mobile/Ad_MobileOwnButtonCreate.aspx?bt=3" runat="server"></asp:HyperLink>--%></td>
                            </tr>
                           
                           
                            <tr class="chkboxRowBkg">
                            <td class="FontBRowText1"><a href="#" rel="htmltooltip"><asp:Image ID="Image10" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" runat="server" /></a>
                            &nbsp; <asp:CheckBox ID="chkNews"  Text="<%$ Resources:LangResources, News %>" runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp; <%--<asp:HyperLink ID="HyperLink4" CssClass="imgChkBoxEdit" ToolTip="Click to edit News Content" ImageUrl="~/Images/Mobile/edit.png" NavigateUrl="~/Admin/NewsListing.aspx" runat="server"></asp:HyperLink>--%></td>
                            </tr>
                           
                           
                            <tr class="chkboxRowBkg">
                            <td class="FontBRowText1"> <a href="#" rel="htmltooltip"><asp:Image ID="Image12" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" runat="server" /></a>
                            &nbsp; <asp:CheckBox ID="chkEvents"  Text="<%$ Resources:LangResources, Events %>" runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp;  <%--<asp:HyperLink ID="HyperLink5" CssClass="imgChkBoxEdit" ToolTip="Click to edit Events Content" ImageUrl="~/Images/Mobile/edit.png" NavigateUrl="~/Admin/EventsListing.aspx" runat="server"></asp:HyperLink>--%></td>
                            </tr>
                           
                           
                           <%-- <tr class="chkboxRowBkg">
                            <td class="FontBRowText1"> <a href="#" rel="htmltooltip"><asp:Image ID="Image1" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" runat="server" /></a>
                            &nbsp; <asp:CheckBox ID="chkFreeSMS"  Text="Free SMS" runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp;  <%--<asp:HyperLink ID="HyperLink5" CssClass="imgChkBoxEdit" ToolTip="Click to edit Events Content" ImageUrl="~/Images/Mobile/edit.png" NavigateUrl="~/Admin/EventsListing.aspx" runat="server"></asp:HyperLink>--%></td>
                            </tr>
                            <caption>
                                
                                <tr class="chkboxRowBkg">
                                    <td class="FontBRowText1"><a href="#" rel="htmltooltip">
                                        <asp:Image ID="Image14" runat="server" CssClass="imgChkBoxPreview" ImageUrl="~/Images/Mobile/Preview.png" />
                                        </a>&nbsp;
                                        <asp:CheckBox ID="chkContactUs" runat="server" Text="<%$ Resources:LangResources, ContactUs %>" />
                                    </td>
                                    <td align="center" class="FontBRowText1">&nbsp; <%--<asp:HyperLink ID="HyperLink6" CssClass="imgChkBoxEdit"  ToolTip="Click to edit Contact Us Details" ImageUrl="~/Images/Mobile/edit.png" NavigateUrl="~/Admin/MyAccount.aspx" runat="server"></asp:HyperLink>--%></td>
                                </tr>
                                <tr class="chkboxRowBkg">
                                    <td class="FontBRowText1">&nbsp;
                                        <asp:CheckBox ID="chkLocationMap" runat="server" Text="<%$ Resources:LangResources, LocationMap %>" />
                                    </td>
                                    <td align="center" class="FontBRowText1">&nbsp; <%--<asp:Image ID="Image15" CssClass="imgChkBoxEdit" ImageUrl="~/Images/Mobile/edit.png" runat="server" />--%></td>
                                </tr>
                                <tr class="chkboxRowBkg">
                                    <td class="FontBRowTextBkg" colspan="2" style="padding-left: 40px;">&nbsp;Social Media Buttons</td>
                                </tr>
                                <tr class="chkboxRowBkg">
                                    <td class="FontBRowText4">&nbsp;
                                        <asp:CheckBox ID="chkFacebook" runat="server" Text="FaceBook" />
                                    </td>
                                    <td align="center" class="FontBRowText1">&nbsp; <%--<asp:HyperLink ID="HyperLink8" CssClass="imgChkBoxEdit" ImageUrl="~/Images/Mobile/edit.png" ToolTip="Click to edit Facebook ID details" NavigateUrl="~/Admin/MyAccount.aspx" runat="server"></asp:HyperLink>--%></td>
                                </tr>
                                <tr class="chkboxRowBkg">
                                    <td class="FontBRowText4">&nbsp;
                                        <asp:CheckBox ID="chkTwitter" runat="server" Text="Twitter" />
                                    </td>
                                    <td align="center" class="FontBRowText1">&nbsp; <%--<asp:HyperLink ID="HyperLink7" CssClass="imgChkBoxEdit" ToolTip="Click to edit Twitter ID details" ImageUrl="~/Images/Mobile/edit.png" NavigateUrl="~/Admin/MyAccount.aspx" runat="server"></asp:HyperLink>--%></td>
                                </tr>
                                <%-- <tr class="chkboxRowBkg">
                            <td class="FontBRowText1">&nbsp; <asp:CheckBox ID="chkLoginSMS"  Text="SMS Login" runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp; </td>
                            </tr>
                            
                            <tr class="chkboxRowBkg">
                            <td class="FontBRowText1">&nbsp; <asp:CheckBox ID="chkLoginPartner"  Text="Partner Login" runat="server" /></td>
                            <td  class="FontBRowText1"  align="center">&nbsp; </td>
                            </tr>--%>
                                <tr class="chkboxRowBkg">
                                    <td class="FontBRowText1">&nbsp;
                                        <asp:CheckBox ID="chkFullWebsite" runat="server" Text="Full Website" />
                                    </td>
                                    <td align="center" class="FontBRowText1">&nbsp; </td>
                                </tr>
                            </caption>
                            
                           
                            
                           
                            </table>
                            </td>
                        </tr>
                       
                        
                         
                      
                        
                        </table>
                             </ContentTemplate>
                </asp:UpdatePanel>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td valign="top" align="center" style="background-image: url(../../Images/Mobile/Templates/mbPreview.png); background-repeat: no-repeat;">
                             <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="50">
                                <ProgressTemplate>
                                    <div ID="progress" style="padding-top: 120px; padding-left: 50px; float:left;" runat="server" visible="true">
                                        <img ID="Img1" runat="server" src="~/Images/Loader1.gif" />Loading Mobile Website Preview...
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            
                         <div id="dvFrame" style="padding-top: 90px; padding-left:34px; min-height: 660px;" align="left">
                         <iframe id="mobileIframe" width="320px" height="570px" frameborder="0" runat="server"></iframe>
                         </div>
                         
                        </td>
                        <td valign="top" align="center" style="padding-top: 30px;">
                        <br />
                        
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                           <asp:Button ID="btnSave" CssClass="stdbuttonCRUD" runat="server" Text="SAVE Mobile Page Settings and Preview" 
                                onclick="btnSave_Click1" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td align="left" class="FontNote">
                            NOTE:&nbsp; Preview shown above may differ slightly based on the mobile being used.
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                   </table>
                 
            </td></tr></table>
            
      

           
                
            </td></tr><tr>
            <td>
                &nbsp;
  <div>
        <asp:Button ID="ButtonHidden" runat="server" Text="Button" style="display:none" />
        <asp:ModalPopupExtender ID="HiddenField1_ModalPopupExtender" runat="server" TargetControlID="ButtonHidden" PopupControlID="panelBoard" CancelControlID="BtnClose" BackgroundCssClass="modalBackground"/>
           <asp:AnimationExtender ID="AnimationExtender1" runat="server"  TargetControlID="panelBoard">
            <Animations>
              <OnLoad>
                 <Parallel AnimationTarget="panelBoard" Fps="30">
                    <FadeIn Duration=".5" Fps="20" />
                  </Parallel>
               </OnLoad>
          </Animations>
           </asp:AnimationExtender>
        <asp:Panel ID="panelBoard"  runat="server" CssClass="modalInsideBackground panelheight" Width="900px"> 
        <%-- <div><asp:Button ID="BtnSubmit1" runat="server" Text="Close" CssClass="btSubmitSmall" />
          <div style="height:5px;"></div>
        </div>--%>
        <div class="bgTheme2" style="height:28px;line-height:27px">
        <asp:Label ID="Label2" runat="server" Text="&nbsp;Mobile Web" CssClass="txtBlackBLarge"/>
        <div style="float:right;"><asp:Button ID="BtnClose" runat="server" Text="Close" CssClass="btSubmitSmall" />
           </div>
        </div>
        <br />
        <div style="border:1px solid #ccda35;padding:3px 3px 3px 3px ; background-color:#FFF; overflow: scroll; max-height:90%;">
        
        <table border="0" cellpadding="0" width="100%">
        <tr><td>&nbsp;</td></tr>
        <tr><td class="font_12Msg_Error">&nbsp; Your MobileWeb 6 month Trial period is over.</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td class="font_12Normal">&nbsp;&nbsp;&nbsp; To continue using Mobile Web, Please purchase else a Full Website will be shown instead of MobileWebsite on Smart Phones.</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td class="FontSubHeader">&nbsp; To Purchase: </td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td class="font_12Msg_Success">&nbsp;1W&nbsp; BuyMobileWeb&nbsp; Password&nbsp; MobileNo&nbsp; CoachMobileNo</td></tr>
        
            <tr>
                <td class="font_12Normal">
                    &nbsp;&nbsp;&nbsp; and &nbsp;&nbsp; send to --&gt; +447860034140
                   </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        
        </table>
        <asp:Label ID="lblPanelTitle" runat="server" Text="" CssClass="txtBlackBMedium"/>
        <br />
        <br />
        <asp:Label ID="lblPanelContent" runat="server" Text="" CssClass="txtBlackMedium"/>        
        </div>
        <div style="height:5px;"></div>
        <div><asp:Button ID="BtnClose1" runat="server" Text="Close" CssClass="btSubmitSmall" />
        </div>
        
        
        </asp:Panel>
       </div>
                </td></tr><tr>
            <td>
            &nbsp;
           </td>
        </tr>
    </table>
    
<div id="dvAbtUs" class="htmltooltip" runat="server"></div>
<div id="dvMb1" class="htmltooltip" runat="server"></div>
<div id="dvMb2" class="htmltooltip" runat="server"></div>
<div id="dvMb3" class="htmltooltip" runat="server"></div>
<div id="dvMb4" class="htmltooltip" runat="server"></div>
<div id="dvMb5" class="htmltooltip" runat="server"></div>
<div id="dvMb6" class="htmltooltip" runat="server"></div>

<div id="dvNews" class="htmltooltip" runat="server"></div>
<div id="dvEvents" class="htmltooltip" runat="server"></div>
<div id="dvContactUs" class="htmltooltip" runat="server"></div>

    </form>

</asp:Content>

