<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_TestProfitShare.aspx.cs" Inherits="Admin_EbAd_TestProfitShare" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="EBLeftMenu_Profit.ascx" tagname="EBLeftMenu_Profit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.bgwhite { background-color:#fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_Profit ID="EBLeftMenu_Profit1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form1" runat="server">

<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
         </asp:ToolkitScriptManager>
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
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; My Profit Share</td>
                        <td width="30%" align="right"> 
                            &nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            &nbsp;</td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr style="height:30px;">
                        <td width="1%">
                            &nbsp;</td>
                        <td width="98%" align="left">
                            &nbsp; 
                                    
                            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="500" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/> Processing... Please wait... 
                             </div>
                            </ProgressTemplate>
                            
                            </asp:UpdateProgress>
                            
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                          <asp:GridView ID="gridEbooks" runat="server" AutoGenerateColumns="False" 
                                CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
    AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="50" onpageindexchanging="gridEbooks_PageIndexChanging"
    AllowSorting="true" ondatabound="gridEbooks_DataBound" onrowdatabound="gridEbooks_RowDataBound" 
                                OnSorting="gridEbooks_Sorting" onrowcreated="gridEbooks_RowCreated">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate><%#Eval("Row") + "."%></ItemTemplate>    
            <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>  
        <asp:TemplateField HeaderText="">            
            <ItemTemplate>
            <asp:Label ID="lblYear" runat="server" Text='<%# Eval("rptMonth") + "," + Eval("rptYear") %>' />
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblPrice" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Price", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top"  />
        </asp:TemplateField>        
        <asp:TemplateField HeaderText="Zero-Base">            
            <ItemTemplate>
            <asp:Label ID="lblMTZ" runat="server" Text='<%#Bind("MTZ") %>' /> 
            </ItemTemplate>
            <ItemStyle Width="10px" HorizontalAlign="Right" VerticalAlign="Top"  />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Success">            
            <ItemTemplate>
            <asp:Label ID="lblMTS" runat="server" Text='<%#Bind("MTS") %>' />            
            </ItemTemplate>
            <ItemStyle Width="10px" HorizontalAlign="Right" VerticalAlign="Top"  />
         </asp:TemplateField>
        <asp:TemplateField HeaderText="Fail">            
            <ItemTemplate>
            <asp:Label ID="lblMTF" runat="server" Text='<%#Bind("MTF") %>' />
            </ItemTemplate>
            <ItemStyle Width="10px" HorizontalAlign="Right" VerticalAlign="Top"  />
         </asp:TemplateField>
        <asp:TemplateField HeaderText="Total">            
            <ItemTemplate>
            <asp:Label ID="lblTotal" runat="server" Text='<%#Bind("MTT") %>' />            
            </ItemTemplate>
            <ItemStyle Width="10px" HorizontalAlign="Right" VerticalAlign="Top"  />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom1" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblPriceAmtS" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "amtS", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField> 
            <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom2" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblOprtShare" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "OprtShare", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>   
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom3" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblPriceAmtF" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "amtF", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom4" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblGrossProfit" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GrossProfit", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>   
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblShare" runat="server" Text='<%#Eval("ProfitPercent") + "%" %>' />            
            </ItemTemplate>     
            <ItemStyle Width="40px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom5" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblGrossProfitNet" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GrossProfitNet", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:LinkButton ID="LinkButtonR" runat="server" Text="View" OnCommand="CheckStatus"   CommandArgument='<%# Eval("rptMonth1") + "#" + Eval("rptYear")%>' ToolTip='<%# "View Report : " + Eval("rptMonth") + "," + Eval("rptYear")%>' />            
            </ItemTemplate>  
            <ItemStyle Width="40px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>       
     </Columns> 
    <PagerStyle CssClass="cssPager" />
    <PagerTemplate>
    <table border="0">
    <tr align="right">
    <td width="100px">      
     <asp:ImageButton Text="First" ToolTip="FIRST" CommandName="Page" OnCommand="BtnPaging" CommandArgument="F" runat="server"  ID="btnFirst" ImageUrl="~/Images/imgPg_First.gif" />
    <asp:ImageButton Text="Previous" ToolTip="PREVIOUS" CommandName="Page" OnCommand="BtnPaging" CommandArgument="P" runat="server" ID="btnPrevious" ImageUrl="~/Images/imgPg_Prev.gif"/>
    </td>        
    <td width="100px">
    Page&nbsp;<asp:DropDownList ID="PageNumberDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageNumberDropDownList_OnSelectedIndexChanged"  runat="server"/>&nbsp;of&nbsp;<asp:Label
        ID="PageCountLabel" runat="server" />
    </td>
    <td width="100px">
    <asp:ImageButton  Text="Next" ToolTip="NEXT" CommandName="Page" OnCommand="BtnPaging" CommandArgument="N" runat="server" ID="btnNext" ImageUrl="~/Images/imgPg_next.gif"/>
    <asp:ImageButton  Text="Last" ToolTip="LAST" CommandName="Page" OnCommand="BtnPaging" CommandArgument="L" runat="server" ID="btnLast" ImageUrl="~/Images/imgPg_last.gif" />
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
    </PagerTemplate>--%>
                            </asp:GridView>  
                            
                        
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                           <%-- <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                </table>
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
    <%--MODAL POPUP 1 AND GRIDVIEW--%>
    <asp:Button runat="server" ID="btnModalPopUp" style="display:none"/>
    <asp:ModalPopupExtender ID="ModalPopUpExtender1" runat="server" BackgroundCssClass="modalBackground" TargetControlID="btnModalPopUp" PopupControlID="pnlPopUp" PopupDragHandleControlID="PanelCategoryList"  OkControlID="ButtonClose"/>
    <asp:AnimationExtender ID="AnimationExtender1" runat="server"  TargetControlID="pnlPopUp">  
            <Animations>
              <OnLoad>
                 <Parallel AnimationTarget="pnlPopUp" Fps="10">
                    <FadeIn Duration=".1" Fps="10"/>
                  </Parallel>
               </OnLoad>
          </Animations>
    </asp:AnimationExtender>
    <asp:Panel ID="PanelCategoryList" runat="server">
    <asp:Panel runat="Server" ID="pnlPopUp" Width="70%" CssClass="bgwhite" ScrollBars="Horizontal">
    <table id="tablecategoryList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="backgroundWhite" style="border:2px solid #CCCCCC;padding:5px 5px 5px 5px;" >
    <tr>
    <td>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td align="right">
        <asp:Button ID="ButtonClose" runat="server" Text="Close" CssClass="buttonBlue"/>
    </td>
    </tr>
    <tr>
    <td class="FontBRowText1">
        <asp:Label ID="LabelIdentifier_CategoryInfo" runat="server" Text="shamala" CssClass=""/>
    </td>    
    </tr>
    </table>
    </td>
    </tr>   
    <tr>
    <td>    
    <div style="overflow-y:auto; height:100%">
    <asp:GridView ID="GridView2" runat="server" AllowSorting="false" 
            AllowPaging="false" AutoGenerateColumns="False" PageSize="50" 
            ondatabound="GridView2_DataBound" DataKeyNames="" CssClass ="mGrid" HeaderStyle-CssClass="rowheader" 
    AlternatingRowStyle-CssClass="rowalt" FooterStyle-CssClass="rowfooter"
            onrowcreated="GridView2_RowCreated" onrowdatabound="GridView2_RowDataBound" ShowFooter="true">
    <Columns>        
    <asp:TemplateField HeaderText="Sno" HeaderStyle-HorizontalAlign="Left">
    <ItemTemplate><%#Eval("Row") + "."%></ItemTemplate>    
    <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField> 
        <asp:TemplateField HeaderText="">            
            <ItemTemplate>
            <asp:Label ID="lblOperator" runat="server" Text='<%# Eval("Operator") %>' />
            </ItemTemplate>     
            <ItemStyle Width="70px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>            
            <asp:HiddenField ID="hdnMonth" runat="server" Value='<%#Bind("rptMonth1")%>'/>  
            <asp:HiddenField ID="hdnYear" runat="server" Value='<%#Bind("rptYear")%>'/>   
            <asp:Label ID="lblShare" runat="server" Text='<%#Bind("ProfitPercent") %>' />         
            </ItemTemplate>     
            <ItemStyle Width="40px" HorizontalAlign="Left" VerticalAlign="Top" />
        </asp:TemplateField>
         <asp:TemplateField>            
            <ItemTemplate>
                  <asp:Label ID="lblCharge" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Price", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top"  />
        </asp:TemplateField>        
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblPrice" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Price", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top"  />
        </asp:TemplateField>  
        
        <asp:TemplateField HeaderText="Zero-Base">            
            <ItemTemplate>
            <asp:Label ID="lblMTZ" runat="server" Text='<%#Bind("MTZ") %>' /> 
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"  />
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Success">            
            <ItemTemplate>
            <asp:Label ID="lblMTS" runat="server" Text='<%#Bind("MTS") %>' />            
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"  />
         </asp:TemplateField>
        <asp:TemplateField HeaderText="Fail">            
            <ItemTemplate>
            <asp:Label ID="lblMTF" runat="server" Text='<%#Bind("MTF") %>' />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"  />
         </asp:TemplateField>
        <asp:TemplateField HeaderText="Total">            
            <ItemTemplate>
            <asp:Label ID="lblTotal" runat="server" Text='<%#Bind("MTT") %>' />            
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"  />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom1" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblPriceAmtS" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "amtS", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField> 
            <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom2" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblOprtShare" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "OprtShare", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>   
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom3" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblPriceAmtF" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "amtF", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField>            
            <ItemTemplate>
            <asp:Label ID="lblDenom4" runat="server" Text='<%#Bind("Denomination") %>' />
            <asp:Label ID="lblGrossProfit" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "GrossProfit", "{0:0.00}")  %>' />            
            </ItemTemplate>     
            <ItemStyle Width="60px" HorizontalAlign="Right" VerticalAlign="Top" />
            <FooterTemplate>
                <asp:Label runat="server" ID="lblFooterZero" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterSuccess" Text=""></asp:Label>                
                <asp:Label runat="server" ID="lblFooterFailure" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterTotalAll" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterAmount1" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterAmount2" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterAmount3" Text=""></asp:Label>
                <asp:Label runat="server" ID="lblFooterAmount4" Text=""></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>        
    </Columns> 
    <PagerStyle CssClass="cssPager" />    
    </asp:GridView>
    </div>    
    </td>
    </tr>
     <%--<tr>
        <td class="headingSubTitle_201">
             <asp:Label ID="Label1" runat="server" Text="Kindly Take Note  :-"/>
        </td>           
     </tr>
     <tr><td>
            <asp:Label ID="Label2" runat="server" Text="<em>1. Profit Sharing depends on Premium SMS Agreement signed.</em>" CssClass="txtRedSmallFont_102" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="<em>2. Payment will be issue only if Amount Profit Sharing above RM100. Admin Charges of RM 15 applies.</em>" CssClass="txtRedSmallFont_102"/>
            <br />
            <asp:Label ID="Label4" runat="server" Text="<em>3. Delivery Report on DN to confirm Success/Fail. Sometimes delay upto 1 month due to Telco Operator.</em>" CssClass="txtRedSmallFont_102"/>      
     </td></tr>--%>   
    </table>
    </asp:Panel>
    </asp:Panel>          
  <%--END--%>
    
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>
