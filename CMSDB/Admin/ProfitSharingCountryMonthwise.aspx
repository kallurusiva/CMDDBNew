<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="ProfitSharingCountryMonthwise.aspx.cs" Inherits="Admin_ProfitSharingCountryMonthwise" %>



<%@ Register src="../SuperAdmin/SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc2" %>



<%@ Register src="EBLeftMenu_SMSPayment.ascx" tagname="EBLeftMenu_SMSPayment" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_SMSPayment ID="EBLeftMenu_SMSPayment1" runat="server" />
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

    function SelectRow(cb_ID) {

        //Getting the ref. to GridView Control 
       <%-- var ObjgridViewCtlId = '<%=gridEmailList.ClientID%>';--%>

        //Getting ref. to GridView Row
        // ObjgridViewCtlId.rows


    }

</script>

<form id="form2" runat="server">



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
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                        <asp:Literal ID="ltrEmailListing" runat="server" 
                                Text="PremiumSMS - Profit Sharing"></asp:Literal>
                                </td>
                        <td width="30%">
                            
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
                            &nbsp;
                            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="50" runat="server">
                            <ProgressTemplate>
                            <div id="progress" runat="server" visible="true">
                                <img id="Img1" src="~/Images/Loader1.gif" runat="server"/>Processing... Please wait...
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
                        
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                             CssClass ="mGrid" HeaderStyle-CssClass="rowheader" AlternatingRowStyle-CssClass="rowalt" 
                             PageSize="20" onrowdatabound="GridView1_RowDataBound"
                             onsorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" onpageindexchanging="GridView1_PageIndexChanging"
                             OnDataBound ="GridView1_DataBound" ShowFooter="True" EnableModelValidation="True">
                             
    <Columns>        
      <asp:TemplateField HeaderText="SNO.">
           <ItemTemplate><%# Container.DataItemIndex + 1 + "."%></ItemTemplate>
           <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"/>
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Month/Year">        
            <ItemTemplate>
                <asp:Label ID="lblMonthYEar" runat="server" Text='<% # Bind("monthName")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
      </asp:TemplateField>

       <asp:TemplateField HeaderText="ShortCode">        
            <ItemTemplate>
                <asp:Label ID="lblshortcode" runat="server" Text='<% # Bind("shortcode")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
      </asp:TemplateField>

        <asp:TemplateField HeaderText="Keyword">        
            <ItemTemplate>
                <asp:Label ID="lblkeyword" runat="server" Text='<% # Bind("keyword")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
      </asp:TemplateField>

        <asp:TemplateField HeaderText="Country">        
            <ItemTemplate>
                <asp:Label ID="lblCountry" runat="server" Text='<% # Bind("CountryName")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
      </asp:TemplateField>

        <asp:TemplateField HeaderText="Telco">        
            <ItemTemplate>
                <asp:Label ID="lblTelco" runat="server" Text='<% # Bind("TelcoName")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
      </asp:TemplateField>

      <asp:TemplateField HeaderText="Premium Amount">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationP" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblPrice" runat="server" Text='<% # Bind("Price")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Success Transaction">        
            <ItemTemplate>
                <asp:Label ID="lblSuccess" runat="server" Text='<% # Bind("transactionsuccess")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle width="25px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>   
             
        <asp:TemplateField HeaderText="Failed Transaction">        
            <ItemTemplate>
                <asp:Label ID="lblFailed" runat="server" Text='<% # Bind("transactionfailed")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle  width="25px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Total Transaction">        
            <ItemTemplate>
                <asp:Label ID="lblTotal" runat="server" Text='<% # Bind("transactionTotal")%>'></asp:Label>
            </ItemTemplate>            
            <ItemStyle  width="25px" HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Success Amount">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationSuceess" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblSuccessAmt" runat="server" Text='<% # Bind("revenuesuccess")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>  

        <asp:TemplateField HeaderText="Failed Amount">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationFailed" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblFailedAmt" runat="server" Text='<% # Bind("revenuefailed")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Telco Share">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationTelco" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblTelco" runat="server" Text='<% # Bind("revenueTelco")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Operator Share">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationOperator" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblOperator" runat="server" Text='<% # Bind("revenueOperator")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Gross Profit">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationGross" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblGross" runat="server" Text='<% # Bind("GrossRevenue")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="your Share">        
            <ItemTemplate>
                <asp:Label ID="lblYShare" runat="server" Text='<% # Bind("myShare")%>'></asp:Label>
                <asp:Label ID="lblPack" runat="server" Text='<% # Bind("SponsorStatus")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Your Profit">        
            <ItemTemplate>
                <asp:Label ID="lblDenominationSS" runat="server" Text='<% # Bind("Denomination")%>'></asp:Label>
                <asp:Label ID="lblSponsorShare" runat="server" Text='<% # Bind("revenuewithdraw")%>'></asp:Label>
            </ItemTemplate>
            <ItemStyle  HorizontalAlign="Right" VerticalAlign="Top" />
        </asp:TemplateField>    
       
     </Columns>  
                             <PagerStyle CssClass="cssPager" />
                             
                             <PagerTemplate>
                                    <
                                </PagerTemplate>
                                
                             <HeaderStyle CssClass="rowheader" />
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
    
      </ContentTemplate>  
     
 
    <asp:HiddenField ID="hdnSno" runat="server" />
<asp:HiddenField ID="hdnMobile" runat="server" />   

    </form>
</asp:Content>



