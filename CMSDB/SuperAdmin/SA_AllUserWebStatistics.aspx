<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_AllUserWebStatistics.aspx.cs" Inherits="SuperAdmin_SA_AllUserWebStatistics" %>

<%@ Register src="SA_SideMenu_Users.ascx" tagname="SA_SideMenu_Users" tagprefix="uc1" %>

<%@ Register src="MyBarChart.ascx" tagname="MyBarChart" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">

    <uc1:SA_SideMenu_Users ID="SA_SideMenu_Users1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

<form id="form2" runat="server">

    <table border="0" cellpadding="0" cellspacing="0" width="99%">
        
       
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
    <table cellpadding="0" cellspacing="0" border="0" width="99%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="100%" class="tblSubHeader">
                  <tr>
                        <td width="5%" align="left" valign="top">
                            <img alt="tl" src="../Images/table_top_Leftarc.gif" 
                                style="width: 10px; height: 20px" /></td>
                        <td width="60%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            <asp:Literal ID="ltrAllUserWebStats" runat="server" Text="Web Statistics"></asp:Literal></td>
                            <td width="30%" align="right">&nbsp;</td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td></tr>
                            </table>
             </td>
         </tr>
                   
           <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="1%">&nbsp;</td>
                        <td width="500px">&nbsp;</td>
                        <td width="1%">&nbsp;</td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left" class="Section_headtext">&nbsp;Month - Wise</td>
                    <td>&nbsp;</td>
                    
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left">
                        <uc2:MyBarChart ID="MyBarChart1" UserWidth="500" runat="server" />
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
                    <td align="left" class="Section_headtext">&nbsp;</td>
                    <td>&nbsp;</td>
                    
                    </tr>
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left" class="Section_headtext">&nbsp;Day - Wise</td>
                    <td>&nbsp;</td>
                    
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left">
                        <uc2:MyBarChart ID="MyBarChart_Day" UserWidth="500" runat="server" />
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
                    
                     <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
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
                &nbsp;</td></tr><tr>
            <td>
                &nbsp;</td>
                </tr>
                </table>
                
                
             
                
</form>

</asp:Content>

