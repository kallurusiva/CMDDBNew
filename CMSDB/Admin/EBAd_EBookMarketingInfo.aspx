<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_EBookMarketingInfo.aspx.cs" Inherits="Admin_EBAd_EBookMarketingInfo" %>
<%@ Register src="EBLeftMenu_BestSeller.ascx" tagname="EBLeftMenu_BestSeller" tagprefix="uc2" %>
<%@ Register src="EBLeftMenu_Marketing.ascx" tagname="EBLeftMenu_Franchise" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_Franchise ID="EBLeftMenu_Franchise1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    
     <style type="text/css">

         .CellPaddingRight { padding-right: 10px; 
         }


     </style>

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
<form id="form2" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
<ContentTemplate>--%>


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
                            &nbsp; EBook Marketing: Information</td>
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
                            
                          </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            <div id="dvWelcomeHeader" style="overflow:hidden; width:820px; min-height: 150px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal3" Text="Information" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                            <tr>
                                <td width="150px" >&nbsp;</td>
                            </tr>

                            <tr>
                                <td class="ebFormText1">  &nbsp;   
                                    <asp:Label runat="server" ID="lblInfo"></asp:Label></asp:Label>
                                </td>
                            </tr>
                        
                        </table>
                        
                        
                    
                    </td>
                    </tr>
                    
                                        
                      </table>
         
        </div>
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
    
<%--      </ContentTemplate>  


    </asp:UpdatePanel>--%>
    
    </form>
</asp:Content>

