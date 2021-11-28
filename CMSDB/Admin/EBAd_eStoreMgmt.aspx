<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_eStoreMgmt.aspx.cs" Inherits="EBAd_eStoreMgmt" %>


<%@ Register src="EBLeftMenu_BestSeller.ascx" tagname="EBLeftMenu_BestSeller" tagprefix="uc2" %>



<%@ Register src="EBLeftMenu_Dashboard.ascx" tagname="EBLeftMenu_Dashboard" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:EBLeftMenu_Dashboard ID="EBLeftMenu_Dashboard1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    
     <style type="text/css">

         .CellPaddingRight {
             padding-right: 10px;
         }

         .catExpand     { display: block;  }
         .catCollapse     { display: none;  }


         .stdbuttonCRUD {
             text-align: left;
         }


         </style>



    <script language="javascript" type="text/javascript">

        function toggle(vCatTable, vCatTableInfo, vCatClicker) {

            var objCatTable = document.getElementById(vCatTable);
            var objCatTableInfo = document.getElementById(vCatTableInfo);

            var textMethod = document.getElementById(vCatClicker);

            if (objCatTable.style.display == "block") {
                objCatTable.style.display = "none";
                textMethod.innerHTML = "[ + Expand ]";
                objCatTableInfo.style.display = "block";
            }
            else {
                objCatTable.style.display = "block";
                textMethod.innerHTML = "[ - Collapse ]";
                objCatTableInfo.style.display = "none";
            }

        }

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

    // toggle state of the checkbox between selected and not selected! 
    function toggleCheckBoxes(gvId, chkdbox_id) {

       
        var checkboxes = getCheckBoxesFrom(document.getElementById(gvId));
        
        var objChkbox = document.getElementById(chkdbox_id);

        
        for (i = 0; i <= checkboxes.length - 1; i++) {

            // checkboxes[i].checked = isChecked;
            //alert(toCheck);
            checkboxes[i].checked = objChkbox.checked;
        }

    }


    // get all the checkboxes from the container control 
    function getCheckBoxesFrom(gv) {

        var checkboxesArray = new Array();
        var inputElements = gv.getElementsByTagName("input");

        if (inputElements.length == 0) null;

        for (i = 0; i <= inputElements.length - 1; i++) {

            if (isCheckBox(inputElements[i])) {

                checkboxesArray.push(inputElements[i]);
            }

        }

        return checkboxesArray;
    }


    // checks if the elements is a checkbox or not
    function isCheckBox(element) {
        return element.type == "checkbox";
    }


    function getParentByTagName(obj, tag) {
        var obj_parent = obj.parentNode;
        if (!obj_parent) return false;
        if (obj_parent.tagName.toLowerCase() == tag) return obj_parent;
        else return getParentByTagName(obj_parent, tag);
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
                            &nbsp; Estore : Maintainence</td>
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
                        
                            <div id="dvWelcomeHeader" style="overflow:hidden; width:960px; min-height: 150px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal3" Text="Welcome Back !!" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                            <tr>
                                <td width="250px" >&nbsp;</td>
                                <td colspan="2" >  &nbsp;</td>
                            </tr>

                            <tr>
                                <td width="150px" class="ebFormLabel1"><strong>My E-Store ID : </strong> </td>
                                <td class="ebFormText1" colspan="2">  &nbsp;   
                                    <asp:Label ID="lblEstoreID" CssClass="FontDbCount" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                             
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td colspan="2" >  &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td>&nbsp;</td>
                                <td class="FontSubHeader" colspan="2">  Display at Website</td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">My&nbsp; Categories :</td>
                                <td class="ebFormText1" colspan="2">  
                                    <asp:RadioButtonList ID="rdoUserCat" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Admin&nbsp; Categories&nbsp; :</td>
                                <td class="ebFormText1" colspan="2">  
                                    <asp:RadioButtonList ID="rdoAdminCat" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td colspan="2" >  &nbsp;</td>
                            </tr>
                        
                             <%--<tr>
                                <td class="ebFormLabel1">Accept SMS Payment :</td>
                                <td class="ebFormText1">  --%>
                                    <asp:RadioButtonList ID="rdoSMSpayment" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal" Visible="false">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                <%-- </td>
                            </tr>--%>

                            <%--<tr>
                                <td class="ebFormLabel1">Accept Prepaid Payment :</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoPrepaid" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>--%>
                        
                             <%--<tr>
                                <td class="ebFormLabel1">Accept Credit Card Payment :</td>
                                <td class="ebFormText1">  --%>
                                    <asp:RadioButtonList ID="rdoCreditCardPayment" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal" Visible="false">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 <%--</td>
                            </tr>--%>
                        
                             <tr runat="server" visible="false">
                                <td class="ebFormLabel1">Accept Direct Bank-In :</td>
                                <td class="ebFormText1" colspan="2">  
                                    <asp:RadioButtonList ID="rdoDirectBankIn" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal" Visible="false">
                                        <asp:ListItem Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0" Selected="True">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Default Currency</td>
                                <td class="ebFormText1" colspan="2">  
                                    <asp:RadioButtonList ID="rdoCurrency" runat="server" CellPadding="2" CellSpacing="2" RepeatColumns="4" RepeatDirection="Horizontal" CssClass="font_Content">
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td colspan="2" >  &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td ></td>
                                <td style="text-align: right" >  
                                    <asp:Button ID="BtnSaveSettings" runat="server" CssClass="stdbuttonCRUD" Text="Save Settings" OnClick="BtnSaveSettings_Click" />
                                    
                                 </td>
                                <td style="text-align: right" >  
                                    <asp:HyperLink runat="server" ID="hypCurrency" NavigateUrl="~/Admin/EBAd_CurrencyTable.aspx" style="color: #FF0000; font-weight: 700;">View Currency Exchange Rate Table </asp:HyperLink></td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td colspan="2" >  &nbsp;</td>
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

