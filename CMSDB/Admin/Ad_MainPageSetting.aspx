<%@ Page Language="C#"  MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_MainPageSetting.aspx.cs" Inherits="Admin_Ad_MainPageSetting" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<%@ Register src="LeftMenu_WebSettings.ascx" tagname="LeftMenu_WebSettings" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc1:LeftMenu_WebSettings ID="LeftMenu_WebSettings1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    
     <style type="text/css">

         .CellPaddingRight {
             padding-right: 10px;
         }

         .catExpand     { display: block;  }
         .catCollapse     { display: none;  }


         .ebFormText1 {
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
                            &nbsp; Domain Main Page Settings</td>
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
                        
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                   
                    <%--<tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            <div id="dvWelcomeHeader0" style="overflow:hidden; width:960px; min-height: 150px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                       
                        <td>
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal5" Text="Show or Hide Admin Products" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                            <tr>
                                <td width="250px" >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>

                             
                        
                             <tr>
                                <td>&nbsp;</td>
                                <td class="FontSubHeader">  Display Status at Website</td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">eBooks Catalog</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_Ebooks" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Feature Buy</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_FeatureBuy" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Best Seller</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_BestSeller" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">New Releases</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_NewReleases" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Value Buy</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_ValueBuy" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Free</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoADM_Free" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Selected="True" Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  
                                    <asp:Button ID="BtnSaveAdminShowHide" runat="server" CssClass="stdbuttonCRUD" Text="Save Admin Products Display Settings" OnClick="BtnSaveAdminShowHide_Click"/>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>
                        
                        </table>
                        
                        
                    
                    </td>
                    </tr>
                    
                                        
                      </table>
         
                            </div>
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>--%>
                   
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                        
                            
                            <div id="dvNotications" style="overflow:hidden; width:960px; min-height: 150px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal4" Text="Domain Main Page Settings" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                            <tr>
                                <td width="250px" >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>

                             <tr>
                                <td class="ebFormLabel1">Domain main Page Title</td>
                                <td class="ebFormText1">  
                                    <asp:TextBox ID="txtNotifyMobile1" runat="server" CssClass="stdTextField1" TextMode="MultiLine" Height="57px" Width="468px"></asp:TextBox>
                                    </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Domain Main Page Description</td>
                                <td class="ebFormText1">  
                                    <asp:TextBox ID="txtNotifyMobile2" runat="server" CssClass="stdTextField1" TextMode="MultiLine" Height="49px" Width="468px"></asp:TextBox>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Domain Main Page Keywords</td>
                                <td class="ebFormText1">  
                                    <asp:TextBox ID="txtNotifyMobile3" runat="server" CssClass="stdTextField1" TextMode="MultiLine" Height="54px" Width="465px"></asp:TextBox>
                                 </td>
                            </tr>
                        <%--<asp:TextBox ID="txtNotifyMobile4" runat="server" CssClass="stdTextField1" Height="56px" TextMode="MultiLine" Visible="false"></asp:TextBox>--%>
                             <tr>
                                <td class="ebFormLabel1">FaceBook Pixel</td>
                                <td class="ebFormText1" >  
                                    <asp:TextBox ID="txtNotifyMobile4" runat="server" CssClass="stdTextField1" Height="56px" TextMode="MultiLine" Width="465px"></asp:TextBox>
                                    </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">&nbsp;</td>
                                <td class="ebFormText1">  
                                    &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">&nbsp;</td>
                                <td class="ebFormText1">  
                                    &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td style="text-align: left" >  
                                    <asp:Button ID="BtnNotifications" runat="server" CssClass="stdbuttonCRUD" Text="Save Main Page Settings" OnClick="BtnNotifications_Click" />
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
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
                       <%-- <td>
                        
                            
                            <div id="dvNotications" style="overflow:hidden; width:960px; min-height: 150px;"  class="ebSummaryBox">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal4" Text="Notifications" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                        <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" width="90%" >
                            <tr>
                                <td width="250px" >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>

                             <tr>
                                <td><strong>&nbsp;SMS CC Copy&nbsp; for:</strong></td>
                                <td class="FontSubHeader">  &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">My Own Products</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoOwnBookNotify" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Admin Products</td>
                                <td class="ebFormText1">  
                                    <asp:RadioButtonList ID="rdoAdminBookNotify" runat="server" CellPadding="3" CellSpacing="2" RepeatDirection="Horizontal" CssClass="font_12Normal">
                                        <asp:ListItem Value="1">YES</asp:ListItem>
                                        <asp:ListItem Value="0">NO</asp:ListItem>
                                    </asp:RadioButtonList>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">Mobiles :</td>
                                <td class="ebFormText1">  
                                    1.
                                    <asp:TextBox ID="txtNotifyMobile1" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                    <br />
                                    2.
                                    <asp:TextBox ID="txtNotifyMobile2" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                    <br />
                                    3. <asp:TextBox ID="txtNotifyMobile3" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                    <br />
                                    4.
                                    <asp:TextBox ID="txtNotifyMobile4" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                    <br />
                                    5.
                                    <asp:TextBox ID="txtNotifyMobile5" runat="server" CssClass="stdTextField1"></asp:TextBox>
                                 </td>
                            </tr>
                        
                             <tr>
                                <td class="ebFormLabel1">&nbsp;</td>
                                <td class="ebFormText1">  
                                    &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  
                                    <asp:Button ID="BtnNotifications" runat="server" CssClass="stdbuttonCRUD" Text="Save Notification Settings" OnClick="BtnNotifications_Click" />
                                 </td>
                            </tr>
                        
                             <tr>
                                <td >&nbsp;</td>
                                <td >  &nbsp;</td>
                            </tr>
                        
                        </table>
                        
                        
                    
                    </td>
                    </tr>
                    
                                        
                      </table>
         
                            </div>
                           </td>--%>
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

