<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Ad_WP_SideImage.aspx.cs" Inherits="Ad_WP_SideImage" %>


<%@ Register src="SideMenu_PgSettings.ascx" tagname="SideMenu_PgSettings" tagprefix="uc1" %>

<%@ Register src="SideMenu_WebPictures.ascx" tagname="SideMenu_WebPictures" tagprefix="uc2" %>

<%@ Register src="SideMenu_WebBanners.ascx" tagname="SideMenu_WebBanners" tagprefix="uc3" %>

<%@ Register src="LeftMenu_WebSettings.ascx" tagname="LeftMenu_WebSettings" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc4:LeftMenu_WebSettings ID="LeftMenu_WebSettings1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script language="javascript" type="text/javascript">

    function SelectAll(chkdbox_id) {

        var objChkbox = document.getElementById(chkdbox_id);
        //alert(objChkbox.checked);

        var frm = document.forms[0];

        for (var i = 0; i < frm.elements.length; i++) {
            if (frm.elements[i].type == "checkbox") {
                frm.elements[i].checked = objChkbox.checked;
            }
        }
    }

 

</script>

<form id="BannerPageForm" runat="server" enctype="multipart/form-data">



<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    



    <table border="0" cellpadding="0" cellspacing="0" width="100%">
              
        <tr style="height:20px">
            <td align="center">
            <table cellpadding="0" cellspacing="0" class="MessagerBarCss" id="tblMessageBar" visible="false" runat="server">
             <tr>
             <td><img runat="server" id="MessageImage" src="../Images/inf_Error.gif" alt="MessageImage"/></td>
             <td align="left"><asp:Label ID="lblErrMessage" CssClass="font_12Msg_Error" runat="server" Text="Label"></asp:Label></td>
             </tr>
             </table>
           </td>
        </tr>
        <tr>
        <td align="center">
        <table cellpadding="0" cellspacing="0" width="96%" border="0" class="ContentBkg">
        <tr><td>
        <table border="0" cellpadding="0" cellspacing="2" width="100%" class="stdtableBorder_Search ContentBkg">
                                <tr height="35px">
                                    <td align="left" width="23%">
                                        <b><asp:Literal ID="LtrDispWebsite2" runat="server" Text="Display at Website"></asp:Literal></b>
                                    </td>
                                    <td width="2%">
                                        &nbsp;</td>
                                    <td align="left" width="75%">
                                        <asp:CheckBox ID="chkActive_WpImage" runat="server" />
                                        <font class="HelpInputCss">&nbsp; &nbsp; [if ticked, the uploaded image will be made as 
                                        default at your selected Website Template.] </font>
                                    </td>
                                </tr>
                                <tr height="35px">
                                    <td align="left" width="23%">
                                        <b>
                                        <asp:Literal ID="Literal4" runat="server" 
                                            Text="Upload Your Own  &lt;br&gt;Web  image"></asp:Literal></b>
                                    </td>
                                    <td width="2%">
                                        &nbsp;</td>
                                    <td align="left" width="75%">
                                        <asp:FileUpload ID="FU_Banner" runat="server" />
                                        &nbsp; &nbsp;
                                        <asp:Button ID="btnUpload_WpImages" runat="server" CssClass="stdButtonNormal" 
                                            onclick="btn_Banner_Logo0_Click" Text="Upload and Save Image" />
                                        &nbsp;
                                        <asp:Label ID="lblUpMessage" runat="server" CssClass="font_12Msg_Success"></asp:Label>
                                        <asp:RegularExpressionValidator ID="FileUploadValidator2" runat="server" 
                                            ControlToValidate="FU_Banner" Enabled="true" Display="Dynamic" 
                                            ErrorMessage="&lt;br/&gt;Only jpg or gif type images are allowed.  Please select another image." 
                                            ValidationExpression=".*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Ss][Ww][Ff])"></asp:RegularExpressionValidator>
                                      <%--  <asp:CustomValidator ID="CustomVdr_Banner" runat="server" 
                                            ControlToValidate="FU_Banner" Display="Dynamic" 
                                            ErrorMessage="<br/>Image size should not be greater than 70KB." 
                                            OnServerValidate="CustomVdr_Banner_ServerValidate"></asp:CustomValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td align="left" class="HelpInputCss">
                                        &nbsp;
                                        <asp:Literal ID="Literal5" runat="server" 
                                            
                                            
                                            Text="[ For better Page Settings and presentation, &lt;br&gt; please upload image with size &lt;= (width=175 &amp; height=425) image."></asp:Literal>
                                    </td>
                                </tr>
                            </table>
        </td></tr>
        </table>
        </td>
        </tr>
        
        <tr>
        <td>
        &nbsp;</td></tr>
        <tr>
            <td align="center">
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                        <asp:Literal ID="ltrHeading" runat="server" 
                                Text="Banner Settings"></asp:Literal>
                                &nbsp;- Side Banner</td>
                        <td width="30%">
                           <%-- <uc2:SelectLanguage ID="ucSelectLanguage" runat="server" />--%>
                            <asp:Button ID="btnSave" CssClass="stdbuttonAction" runat="server" Text="Save Side Banner Selection" 
                                onclick="btnSave_Click" />
                        </td>
                       
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%" align="left">
                            Filter by Industry : &nbsp;
                            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" 
                                CssClass="stdDropDownContent" 
                                onselectedindexchanged="ddlCategory_SelectedIndexChanged" Width="209px">
                            </asp:DropDownList>
                        </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td align="left" width="94%">
                            &nbsp;
                            <asp:HiddenField ID="hid_CurrBannerId" runat="server" />
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="50">
                                <ProgressTemplate>
                                    <div ID="progress" runat="server" visible="true">
                                        <img ID="Img1" runat="server" src="~/Images/Loader1.gif" />Processing... Please 
                                        wait...
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            <asp:GridView ID="gridWpImages" runat="server" AutoGenerateColumns="False" DataKeyNames="ImageID"
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                              AllowPaging="true" PageSize="4" onpageindexchanging="gridWpImages_PageIndexChanging"
                               OnSorting ="gridWpImages_Sorting" 
                               AllowSorting="true" onrowdeleting="gridWpImages_RowDeleting" 
                                OnDataBound="gridWpImages_DataBound" onrowdatabound="gridWpImages_RowDataBound"
                             >
                            <Columns>
                                                       
                            <asp:TemplateField HeaderText="Sl No">
                              <ItemTemplate>
                               <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1  %>'/>
                                  <asp:HiddenField ID="hidImageID" Value='<%#Bind("ImageID")%>' runat="server" />
                                  <asp:HiddenField ID="hidUserID" Value='<%#Bind("UserID")%>' runat="server" />
                                  <asp:HiddenField ID="hidImageActualName" Value='<%#Bind("ImgActualName")%>' runat="server" />
                                  <asp:HiddenField ID="hidImageName" Value='<%#Bind("ImgName")%>' runat="server" />
                                  <asp:HiddenField ID="hidFullImgPath" Value='<%#Bind("FullImgPath")%>' runat="server" />
                                  <asp:HiddenField ID="hidCategoryName" Value='<%#Bind("CategoryName")%>' runat="server" />
                                  
                              </ItemTemplate>
                              <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Select">
                              <ItemTemplate>
                               <%--<asp:Image ID="ImgBanner" ImageUrl='<%# Bind("FullImgPath")%>' Width="100" Height="100" runat="server" />--%>
                               <%--<input id="rdoBannerID" name="Grp_BannerID" value="<%#Eval("ImageID")%>" type="radio" runat="server" />--%>
                                <asp:Literal ID="ltrRDO_WpImage" Text="" runat="server"></asp:Literal>  
                              </ItemTemplate>
                              <ItemStyle Width="50px" HorizontalAlign="Center" Wrap="false" />
                             </asp:TemplateField>
                             
                            <asp:TemplateField HeaderText="Image ID<br/>(Industry)">
                              <ItemTemplate>
                               <%--<asp:Image ID="ImgBanner" ImageUrl='<%# Bind("FullImgPath")%>' Width="100" Height="100" runat="server" />--%>
                                <asp:Literal ID="ltrImageImgID" Text="" runat="server"></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="150px" HorizontalAlign="Left" Wrap="false" />
                             </asp:TemplateField>
                             
                            
                            <asp:TemplateField HeaderText="Side Image">
                              <ItemTemplate>
                               <%--<asp:Image ID="ImgBanner" ImageUrl='<%# Bind("FullImgPath")%>' Width="100" Height="100" runat="server" />--%>
                                <asp:Literal ID="ltrWpImage" runat="server"></asp:Literal>
                              </ItemTemplate>
                              <ItemStyle Width="150px" HorizontalAlign="Center" Wrap="false" />
                             </asp:TemplateField>
                                                          
                              <asp:TemplateField HeaderText="Functions">
                              <ItemTemplate>
                                  <%--<asp:ImageButton ID="ImgEdit" CommandName="EDIT" ToolTip="Edit Faq" runat="server" ImageUrl="~/Images/imgEdit2.gif" />--%>
                                  <asp:ImageButton ID="ImgDelete" CommandName="DELETE" ToolTip="Delete Banner" OnClientClick="return confirm('Please click OK to confirm deletion');" runat="server" ImageUrl="~/Images/imgDelete.gif" />
                              </ItemTemplate>
                               <ItemStyle Width="150px" HorizontalAlign="center"  />
                             </asp:TemplateField>
                            
                             
                             </Columns>
                             <PagerStyle CssClass="cssPager" />
                             
                             <PagerTemplate>
                                    <table border="0">
                                        <tr align="right">
                                           
                                         <td width="100px">      
                                            <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="Page" CommandArgument="First" runat="server"  ID="btnFirst" ImageUrl="~/Images/imgPg_First.gif" />
                                            <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="Page" CommandArgument="Prev" runat="server" ID="btnPrevious" ImageUrl="~/Images/imgPg_Prev.gif"/>
                                                    </td>
                                                    
                                            <td width="100px">
                                                Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;<asp:Label
                                                    ID="PageCountLabel" runat="server" />
                                            </td>
                                              
                                        <td width="100px">
                                            <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="Page" CommandArgument="Next" runat="server" ID="btnNext" ImageUrl="~/Images/imgPg_next.gif"/>
                                            <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="Page" CommandArgument="Last" runat="server" ID="btnLast" ImageUrl="~/Images/imgPg_last.gif" />
                                          </td>
                                       <td width="20px">&nbsp;</td>
                                       <td width="100px">
                                          <%-- <asp:Button ID="btnDeleteMultiple" runat="server" Text="Delete Selected"/>--%>
                                       </td>
                                          
                                 </tr>
                                    </table>
                                </PagerTemplate>
                                
                             <%--<PagerTemplate>
                                    <table border="0">
                                        <tr align="right">
                                           
                              <td>      
                                             <asp:Button CssClass="stdPagerButton" Text="First" CommandName="Page" CommandArgument="First" runat="server"
                                                ID="btnFirst" />
                                            <asp:Button CssClass="stdPagerButton" Text="Previous" CommandName="Page" CommandArgument="Prev" runat="server"
                                                ID="btnPrevious" />
                                                    </td>
                                                    
                                            <td>
                                                Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;<asp:Label
                                                    ID="PageCountLabel" runat="server" />
                                            </td>
                                              
                                        <td>
                                            <asp:Button CssClass="stdPagerButton" Text="Next" CommandName="Page" CommandArgument="Next" runat="server"
                                                ID="btnNext" />
                                            <asp:Button  CssClass="stdPagerButton" Text="Last" CommandName="Page" CommandArgument="Last" runat="server"
                                                ID="btnLast" />
                                          </td>
                                        </tr>
                                    </table>
                                </PagerTemplate>--%><HeaderStyle CssClass="rowheader" />
                                <AlternatingRowStyle CssClass="rowalt" />
                            </asp:GridView>
                            
                        
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                          <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
     
     </ContentTemplate>  

    </asp:UpdatePanel>
                
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
    

      
    

    </form>
</asp:Content>

