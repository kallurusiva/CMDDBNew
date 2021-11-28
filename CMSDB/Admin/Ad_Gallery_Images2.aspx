<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_Gallery_Images2.aspx.cs" Inherits="Ad_Gallery_Images2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<%@ Register src="LeftMenu_Gallery.ascx" tagname="LeftMenu_Gallery" tagprefix="uc1" %>


<%@ Register src="LeftMenu_WebSettings.ascx" tagname="LeftMenu_WebSettings" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:LeftMenu_WebSettings ID="LeftMenu_WebSettings1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">


    <script language="javascript" type="text/javascript">

    function fnCheckDomain() {


        var tmpURL = "http://www.namecheap.com/domain-name-search.asp";
        window.open(tmpURL, "winDomainCheck", "width=600px,height=550px,resizable=yes, scrollbars=yes,dependent=yes,left=150,top=150");


    }

        function switchViews(obj) {
            var div = document.getElementById(obj);


            if (div.style.display == "none") {
                div.style.display = "inline";
            }
            else {
                div.style.display = "none";
            }
        }


    
    
</script>
    <form id="form1" runat="server">
    <input type="hidden" value="ipadr" id="hdIpAddress" name="hdIpAddress" />
<table border="0" cellpadding="0" cellspacing="0" width="100%">
       
       
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td>
             <img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label>
                 <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                 </asp:ToolkitScriptManager>
                 </td>
             </tr>
             </table>
           </td>
        </tr>
        
        <tr>
            <td align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;<asp:Literal ID="LtrLogoSettingsHeader" runat="server" 
                                Text="Images Gallery"></asp:Literal></td>
                        
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
            
             
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    
                    
                <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="100%" runat="server">
                                        
                  <%--     <tr>
                      <td>
                        &nbsp; 
                      </td>
                      </tr>              
                      
                     <tr>
                      <td>
                        Search Section   --%> 
                    <%-- <table id="tblSearchSimple" align="center" cellpadding="0" cellspacing="2" class="stdtableBorder_Search">
                                <tr>
                                    <td style="width:10px;">&nbsp;</td>
                                 <td style="width:200px;" align="right" nowrap="nowrap" class="FontBRowHelp"> 
                                    </td>
                                    <td style="width:20px;"> &nbsp;</td>
                                </tr>
                                
                     </table>
                             
                     </td>
                      </tr> --%>             
                       <tr>
                      <td>
                        &nbsp;  <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="50" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/>Processing... Please wait...
                             </div>
                            </ProgressTemplate>
                            
                            </asp:UpdateProgress>
                      </td>
                      </tr>  
                 <tr>
                        <td align="center">
                        
                            <asp:Panel ID="PagerPanel" runat="server" CssClass="dvgiPager">
                                <table border="0" width="100%">
                                        <tr align="right">
                                           
                                         <td width="100px">      
                                            <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="FIRST" CommandArgument="First" OnClick="Paging_Click" runat="server"  ID="btnFirst" ImageUrl="~/Images/pgrFIRST.png" />
                                            <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="PREVIOUS" CommandArgument="Prev" OnClick="Paging_Click" runat="server" ID="btnPrevious" ImageUrl="~/Images/pgrPREVIOUS.png"/>
                                                    </td>
                                                    
                                            <td width="100px" class="font_12Normal">
                                                <font class="font_12Normal"> Total Images : </font> 
                                                <asp:Label ID="lblTotalImages" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td width="300px" class="font_12Normal">                                                
                                                Showing Page &nbsp;
                                                <asp:Label ID="PageStartLabel" Visible="false" runat="server" />
                                                <asp:DropDownList ID="PageNumberDropDownList" CssClass="stdDropDown" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;
                                                <asp:Label ID="PageCountLabel" runat="server" />
                                            </td>
                                              
                                        <td width="100px">
                                            <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="NEXT" CommandArgument="Next" OnClick="Paging_Click" runat="server" ID="btnNext" ImageUrl="~/Images/pgrNEXT.png"/>
                                            <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="LAST" CommandArgument="Last" OnClick="Paging_Click" runat="server" ID="btnLast" ImageUrl="~/Images/pgrLAST.png" />
                                          </td>
                                          
                                       <td width="200px">
                                       &nbsp;Items per page 
                                        <asp:DropDownList ID="ddlItemPerPage" runat="server" AutoPostBack="True" 
                                            CssClass="stdDropDown" Height="20px" Width="45px" 
                                            onselectedindexchanged="ddlItemPerPage_SelectedIndexChanged">
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                            <asp:ListItem>60</asp:ListItem>
                                        </asp:DropDownList>
                                       
                                       </td>
                                          
                                 </tr>
                                 </table>
                            </asp:Panel>
                         
                        
                        </td>
                        </tr>
                    
                    
                      <tr>
                      <td align="center">
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtable_BdrBlue_BkgGrey" >
                        <tr>
                        <td>
                            <asp:DataList ID="DLImageGallery" runat="server" RepeatColumns="3" 
                                RepeatDirection="Horizontal" Width="100%" 
                                ondatabinding="DLImageGallery_DataBinding" 
                                onitemdatabound="DLImageGallery_ItemDataBound">
                                
                                
                                 <ItemTemplate>
                                     <asp:HiddenField ID="hidImgTitle" Value='<%# Eval("ImgTitle")%>' runat="server" />
                                     <asp:HiddenField ID="hidImgURL" Value='<%# Eval("ImageFilePath")%>' runat="server" />
                                     
                                  <%--  <table cellpadding = "5px" cellspacing = "0" class="dlTable">
                                    <tr>
                                        <td>--%>
                                        <div id="dvgiImage" class="dvgiImages"> 
                                            <asp:Image ID="Image1" runat="server" CssClass="giImage" ImageUrl = '<%# Eval("ImageFilePath")%>'                                            />
                                            <br />
                                           
                                        </div>
                                    <%--    <div id="dvgiImageInfo" class="dvgiImageInfo">
                                            <div id="dvgiTable" class="giTable">
                                            <div id="dvgirow1" class="giRow">
                                                <div id="dvgiR1C1" class="giCol">Title:</div>
                                                <div id="dvgiRlC2" class="giCol"><asp:Label ID="lblImgTitle" CssClass="gilblFont" runat="server" Text=""></asp:Label></div>
                                            </div>
                                            <div id="dvgirow2" class="giRow">
                                                <div id="dvgiR2C1" class="giCol">URL :</div>
                                                <div id="dvgiR2C2" class="giCol"><asp:Label ID="lblImgURL" CssClass="giurlFont" runat="server" Text=""></asp:Label></div>
                                            </div>
                                        </div>--%>
                                        <div id="dvgiImageInfo" class="dvgiImageInfo">
                                        <table border="0" cellpadding="1" cellspacing="1">
                                            <tr>
                                            <td class="gilblFontHeader" align="left">Title : </td>
                                            <td align="left"><asp:Label ID="lblImgTitle" CssClass="gilblFont" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                            <td class="gilblFontHeader" align="left" valign="top">Url : </td>
                                            <td align="left"><%--<asp:Label ID="lblImgURL" CssClass="giurlFont" runat="server" Text=""></asp:Label>--%>
                                            &nbsp;<asp:TextBox ID="txtURLlink" TextMode="MultiLine" ToolTip="Copy and Paste the Image Link into your page source." CssClass="giTextURL" runat="server"></asp:TextBox>
                                            </td>
                                            </tr>
                                        </table>
                                        </div>
                                            <%-- <asp:Label ID="lblImgTitle" CssClass="gilblFont" runat="server" Text=""></asp:Label>
                                            <br />
                                            <asp:Label ID="lblImgURL" CssClass="giurlFont" runat="server" Text=""></asp:Label>--%>
                                        </div>
                                        
                                       <%-- </td>
                                    </tr>
                                    </table>--%>
                                    
                                </ItemTemplate>
                                
                            </asp:DataList>
                        
                        </td>
                        </tr>
                        
                        </table>
                      </td>
                      </tr>   
                      
                      
                    
                </table>
                
                  </ContentTemplate>
                    </asp:UpdatePanel>     
                
           </td></tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        </tr></table>
                            
                            
                            </td></tr></table>
    </form>
</asp:Content>

