<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_Gallery_ListImages.aspx.cs" Inherits="SA_Gallery_ListImages" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register src="SA_SideMenu_Gallery.ascx" tagname="SA_SideMenu_Gallery" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SA_SideMenu_Gallery ID="SA_SideMenu_Gallery1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

 <script language="javascript" type="text/javascript">

        function fnDeleteImage(imgID) {
            //alert(imgID);
            if (confirm('Are you sure to Delete the Image')) {
                location.href = 'SA_Gallery_ListImages.aspx?ImgToDelete=' + imgID;
            }

        }

        function fnEditImage(imgID) {
            //alert(imgID);
            location.href = 'SA_Gallery_ListImages.aspx?ImgToEdit=' + imgID;

        }
    
    </script>
<form id="form2" runat="server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
              
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td>
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                 </asp:ToolkitScriptManager>
             <img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
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
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="ltrHeader" runat="server" 
                                Text=""></asp:Literal></td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
            
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    
                    
                <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="98%" runat="server">
                                        
                      <tr>
                      <td>
                        &nbsp; 
                      </td>
                      </tr>              
                      
                      <tr>
                      <td>
                      <%--  Search Section   --%> 
                     <table id="tblSearchSimple" align="center" cellpadding="0" cellspacing="2" class="stdtableBorder_Search">
                                <tr>
                                    <td style="width:10px;">&nbsp;</td>
                                    <td style="width:120px;" class="SearchLabelBold">By Industry</td>
                                    <td style="width:3px;">&nbsp;:&nbsp;</td>
                                    <td class="SearchLabel" style="width:150px;" align="left">
                                        <asp:DropDownList ID="ddlCategory" CssClass="stdDropDown1" runat="server" >
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:10px;"> &nbsp;</td>
                                    <%--<td style="width:120px;" class="SearchLabelBold">By Title</td>
                                    <td style="width:3px;">&nbsp;:&nbsp;</td>
                                    <td class="SearchLabel" align="left" style="width:150px;">
                                        <div id="dvSearchTextBox" style="display: block">
                                            <asp:TextBox ID="txtSearchValue" CssClass="stdTextField1" runat="server"></asp:TextBox>
                                        </div>
                                   </td>
                                    
                                    <td style="width:5px;"> &nbsp;</td>--%>
                                    <td align="left">
                                    <asp:Button ID="btnSearch" CssClass="stdbuttonAction" runat="server" Text="Search" onclick="btnSearch_Click" />
                                    &nbsp; 
                                        <asp:Button ID="btnReset" CssClass="stdbuttonAction" runat="server" 
                                            Text="Reset" onclick="btnReset_Click" />
                                    </td>
                                   <td style="width:200px;" align="right" nowrap="nowrap" class="FontBRowHelp"> &nbsp;Items per page 
                                        <asp:DropDownList ID="ddlItemPerPage" runat="server" AutoPostBack="True" 
                                            CssClass="stdDropDown" Height="20px" Width="45px" 
                                            onselectedindexchanged="ddlItemPerPage_SelectedIndexChanged">
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width:20px;"> </td>
                                </tr>
                                
                            </table>
                             
                     </td>
                      </tr>              
                       <tr>
                      <td>
                        &nbsp; 
                      </td>
                      </tr>  
                 
                    
                    
                      <tr>
                      <td align="center">
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtable_BdrBlue_BkgGrey" >
                        <tr>
                        <td>
                            <asp:DataList ID="DLImageGallery" runat="server" RepeatColumns="4" 
                                RepeatDirection="Horizontal" Width="100%" 
                                ondatabinding="DLImageGallery_DataBinding" 
                                onitemdatabound="DLImageGallery_ItemDataBound">
                                
                                
                                 <ItemTemplate>
                                     <asp:HiddenField ID="hidImgTitle" Value='<%# Eval("ImgTitle")%>' runat="server" />
                                     <asp:HiddenField ID="hidImgURL" Value='<%# Eval("ImageFilePath")%>' runat="server" />
                                     <asp:HiddenField ID="hidVidActive" Value='<%# Eval("Active")%>' runat="server" />
                                     
                                  <%--  <table cellpadding = "5px" cellspacing = "0" class="dlTable">
                                    <tr>
                                        <td>--%>
                                        <div id="dvgiImage" class="dvgiImages"> 
                                            <asp:Image ID="Image1" runat="server" CssClass="giImage" ImageUrl = '<%# Eval("ImageFilePath")%>' />
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
                                        <div id="dvgiImageInfo" class="dvgiImageInfoSA">
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
                                            <tr>
                                            <td>&nbsp;</td>
                                            <td align="left">
                                                <img src="../Images/image_edit.png" class="showCursor" alt='Edit Image' title='Edit Image' onclick='fnEditImage(<%# Eval("ImageID")%>)' />
                                                &nbsp; &nbsp;
                                                <img src="../Images/image_remove.png" class="showCursor" alt='Delete Image' title='Delete Image' onclick='fnDeleteImage(<%# Eval("ImageID")%>)' />
                                                 &nbsp; &nbsp;
                                                  <img src="../Images/image_NotActive.png" id="imgNotActive" runat="server" class="showCursor" alt='Image Not Displayed at Website' title='Image Not Displayed at Website' />
                                                  &nbsp; 
                                                  <asp:Label ID="lblIndustryText" runat="server" Text=""></asp:Label>
                                            </td></tr>
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
                        <tr>
                        <td align="center">
                        
                            <asp:Panel ID="PagerPanel" runat="server" CssClass="dvgiPager">
                                <table border="0">
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
                                          
                                 </tr>
                                 </table>
                            </asp:Panel>
                         
                        
                        </td>
                        </tr>
                        </table>
                      </td>
                      </tr>   
                      
                      
                    
                </table>
                
                  </ContentTemplate>
                    </asp:UpdatePanel>         
            </td>
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
                &nbsp;
            </td>
        </tr>
    </table>

    </form>
    
</asp:Content>

