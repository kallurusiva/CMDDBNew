<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EbAd_PaymentList.aspx.cs" Inherits="Admin_EbAd_PaymentList" %>
<%@ Register src="EBLeftMenu_Profit.ascx" tagname="EBLeftMenu_Profit" tagprefix="uc1" %>
<%@ Register src="EBLeftMenu_SMSPayment.ascx" tagname="EBLeftMenu_SMSPayment" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_SMSPayment ID="EBLeftMenu_SMSPayment1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <form id="form1" runat="server">
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
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            &nbsp;</td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; My Payment History</td>
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
                            <div ><span style="color:Red"><u>Kindly Take Note :-</u></span>
                <br /><asp:Literal ID="LabelCreditNotice" runat="server" Text="1. Profit Sharing depends on Premium SMS Agreement signed.<br>
2. Payment will be issue only if Amount Profit Sharing above RM200. Admin Charges of RM 25 applies.<br>
3. Delivery Report on DN to confirm Success/Fail. Sometimes delay upto 1 month due to Telco Operator." />
     </div></td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
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
    AlternatingRowStyle-CssClass="rowalt" AllowPaging="true" PageSize="1000" onpageindexchanging="gridEbooks_PageIndexChanging"
    AllowSorting="true" ondatabound="gridEbooks_DataBound" OnSorting="gridEbooks_Sorting" >
    <Columns>        
    <asp:TemplateField HeaderText="Sno">
    <ItemTemplate><%#Eval("Row") + "."%></ItemTemplate>
    <ItemStyle Width="20px" HorizontalAlign="Left" VerticalAlign="Top"/>
    </asp:TemplateField> 
    <asp:TemplateField HeaderText="Request Payment" SortExpression="ReqAmount" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblDenom1" runat="server" Text='RM'/><asp:Label ID="Label" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ReqAmount", "{0:0.00}")  %>'/>
    </ItemTemplate>            
    <ItemStyle Width="130px" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Admin Charges" SortExpression="AdminCharges" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblDenom2" runat="server" Text='RM'/><asp:Label ID="Label" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AdminCharges", "{0:0.00}")  %>'/>
    </ItemTemplate>
    <ItemStyle Width="50px" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Date" SortExpression="TDate" HeaderStyle-HorizontalAlign="Left">        
    <ItemTemplate>
    <asp:Label ID="lblTDate" runat="server" Text='<% # DataBinder.Eval(Container.DataItem, "Tdate", "{0:MMM d, yyyy h:mm:ss tt}")%>'></asp:Label>
    </ItemTemplate>
    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField>   
    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="LabelStatus" runat="server" Text='<%#Bind("PaymentStatus") %>'/>
    </ItemTemplate>
    <ItemStyle Width="50px" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField>   
    <asp:TemplateField HeaderText="Issued Cheque No./Remarks" SortExpression="AdminCharges" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="Label" runat="server" Text='<%#Bind("Cheque") %>'/>
    </ItemTemplate>
    <ItemStyle Width="150px" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField> 
    <asp:TemplateField HeaderText="Payee Name" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblPayee" runat="server" Text='<%#Bind("Payee") %>'/>
    </ItemTemplate>
    <ItemStyle Width="80px" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblBank" runat="server" Text='<%#Bind("Bank") %>'/>
    </ItemTemplate>
    <ItemStyle Width="80px" HorizontalAlign="Left" VerticalAlign="Top" />
    </asp:TemplateField>  
    <asp:TemplateField HeaderText="Bank Account" HeaderStyle-HorizontalAlign="Left">    
    <ItemTemplate>
    <asp:Label ID="lblBankAcc" runat="server" Text='<%#Bind("BankAccount") %>'/>
    </ItemTemplate>
    <ItemStyle Width="80px" HorizontalAlign="Left" VerticalAlign="Top" />
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
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CphFooter" Runat="Server">
</asp:Content>


