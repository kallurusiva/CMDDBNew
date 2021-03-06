<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_IncentivePlanListing.aspx.cs" Inherits="SuperAdmin_SA_IncentivePlanListing" %>

<%@ Register src="SA_SideMenu_IncenPlan.ascx" tagname="SA_SideMenu_IncenPlan" tagprefix="uc2" %>

<%@ Register src="SelectLanguage.ascx" tagname="SelectLanguage" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:SA_SideMenu_IncenPlan ID="SA_SideMenu_IncenPlan1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    

<form id="form2" runat="server">
    



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
        <td align="right">
                 <uc1:SelectLanguage ID="SelectLanguage1" runat="server" />
                            &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; 
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
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="90%" align="left" class="subHeaderFontGrad">
                            &nbsp;
                            <asp:Literal ID="LtrIncentivePlan" Text="" runat="server"></asp:Literal>
                        </td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="3" class="stdtableBorder_Only" width="100%">
                    <tr>
                        <td width="1%">
                            &nbsp;</td>
                        <td width="98%" align="right" class="font_12Msg_Success">
                            &nbsp; <%-- <textarea id="txtIncPlanContent" class="stdTextArea3_IC" runat="server"></textarea>--%>
                            </td>
                        <td width="1%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left" valign="top">
                           <%-- <textarea id="txtIncPlanContent" class="stdTextArea3_IC" runat="server"></textarea>--%>
                            <asp:Label ID="lblIncentivePlan" runat="server" Text=""></asp:Label>
                        </td>
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
                        <td align="left">
                            <asp:HiddenField ID="hidIncPlanID" runat="server" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Edit Incentive Plan" 
                                onclick="btnUpdate_Click" 
                               />
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
                &nbsp;</td>
        </tr>
    </table>
    


    </form>
</asp:Content>

