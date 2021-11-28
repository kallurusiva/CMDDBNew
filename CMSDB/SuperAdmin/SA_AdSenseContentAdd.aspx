<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdminMaster.master" AutoEventWireup="true" CodeFile="SA_AdSenseContentAdd.aspx.cs" Inherits="SA_AdSenseContentAdd" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>


<%@ Register src="SA_SideMenu_MobiWebButtons.ascx" tagname="SA_SideMenu_MobiWebButtons" tagprefix="uc1" %>


<%@ Register src="SA_SideMenu_WebButtons.ascx" tagname="SA_SideMenu_WebButtons" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    <script type="text/javascript">
{
    // Special FCK Editor disable & control script.
   // var editorInstance = FCKeditorAPI.GetInstance('FCKeditor1');
    
    function FCKeditor_OnComplete(editorInstance) {
        // editorInstance.BasePath = "/UserControls/fckeditor/"; - Note the path is now supplied in the HTML. - alert(editorInstance.Name);
        if ((editorInstance.Name == "ReferralForm_ReferralFormReferral_ViewReferral_FCKEditorManagerNotesItem") || (editorInstance.Name == "ReferralForm_ReferralFormReferral_ViewReferral_FCKEditorNotesItem"))
        {
            // Diable toolbar.
            editorInstance.EditorDocument.body.disabled = true;
            // Diable buttons.
            editorInstance.EditorWindow.parent.FCK.ToolbarSet.Disable();
            editorInstance.EditorWindow.parent.document.getElementById("xExpanded").style.display = "none";
        }
    }

//    function RTFMandatoryValidate(source, args) {
//        var RTF = FCKeditorAPI.GetInstance('FCKeditor1');
//        if (RTF.EditorDocument.body.innerText.length == 0) {
//            args.IsValid = false;
//            RTF.EditorDocument.body.focus();
//            return;
//        }
//        args.IsValid = true;
//        return;
//    }
}
</script>

    <script src="../OtherUtils/ckeditor/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript" src="../OtherUtils/ckfinder/ckfinder.js"></script>

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
                            <asp:Literal ID="LtrAddNewButtonPage" runat="server" 
                                Text=""></asp:Literal></td>
                        <td width="5%"  align="right" valign="top">
                            <img src="../Images/table_top_Rightarc.gif" style="width: 10px; height: 20px" /></td>
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
           <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="98%" runat="server">
            <tr>
            <td>&nbsp;</td>
            </tr> 
            <tr><td>
                <asp:FormView ID="FvAdSenseCode" runat="server"
                 GridLines="Vertical" Width="100%" onmodechanging="FvAdSenseCode_ModeChanging" 
                    ondatabound="FvAdSenseCode_DataBound" oniteminserting="FvAdSenseCode_ItemInserting" onitemupdating="FvAdSenseCode_ItemUpdating" 
                >
               <ItemTemplate>
            
                <table cellpadding="0" cellspacing="3" id="tblPlan" width="98%" runat="server">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%">&nbsp;
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <div id="dvButtonNo" class="LogoBoxheadBlue">
                            &nbsp;<br /> &nbsp;&nbsp; &nbsp;
                            <asp:Label ID="lblButtonNoHeader" runat="server" CssClass="FontSubHeader"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                  
                            
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="BtnUpdate" runat="server" CommandName="Edit" 
                                CssClass="stdbuttonCRUD" Text=" EDIT " />
                             
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnBackToListing" runat="server" CssClass="stdbuttonCRUD" 
                                onclick="btnBackToListing_Click" Text="Back to Listing" />
                             
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <table class="style1" id="tblButtonInfo">
                                <tr>
                                    <td width="25%" class="tblFormLabel1">
                                        <font class="font_12Msg_Success">User Details </font>:- </td>
                                    <td width="75%" class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%" align="right">
                                        Full Name :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Mobile Number :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Domain details :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtDomainInfo" runat="server" 
                                            CssClass="stdTextField1_disabled" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        <font class="font_12Msg_Success">AdSense details </font>:- </td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;Adsense Login ID :</td>
                                    <td class="tblFormText1">
                                        <asp:Label ID="lblAdLoginID" Text='<%# Eval("AdSenseID")  %>' runat="server" CssClass="SearchLabelBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        AdSense Password:</td>
                                    <td class="tblFormText1">
                                        <asp:Label ID="lblAdPassword" Text='<%# Eval("AdSensePwd")  %>' runat="server" CssClass="SearchLabelBold"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        AdSense Code:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdCode" Text='<%# Eval("AdSenseCode")  %>' runat="server" CssClass="stdTextArea2" 
                                            TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                         &nbsp; 
                        </td>
                        <td>
                            &nbsp;
                            
                            </td>
                        
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        &nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                </table>
            
                </ItemTemplate>
                
                <EditItemTemplate>
                
                <table cellpadding="0" cellspacing="3" id="tblPlan" width="98%" runat="server">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%">&nbsp;
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                     
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <div id="dvButtonNo" class="LogoBoxheadBlue">
                            <br />&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblButtonNo" CssClass="FontSubHeader" runat="server"></asp:Label>
                            </div>
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                         <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                        &nbsp;&nbsp;
                        <asp:Button ID="BtnUpdate" CssClass="stdbuttonCRUD" CommandName="UPDATE" ToolTip="Edit My content" runat="server" Text="Update" />&nbsp; &nbsp;
                        <asp:Button ID="BtnCancel" CssClass="stdbuttonCRUD" CommandName="Cancel" runat="server" Text="Cancel" />
                      
                            </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <table class="style1" id="tblButtonInfo">
                                <tr>
                                    <td width="25%" class="tblFormLabel1">
                                        <font class="font_12Msg_Success">User Details </font>:- </td>
                                    <td width="75%" class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%" align="right">
                                        Full Name :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Mobile Number :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Domain details :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtDomainInfo" runat="server" 
                                            CssClass="stdTextField1_disabled" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        <font class="font_12Msg_Success">AdSense details </font>:- </td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;Adsense Login ID :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdsLoginID" runat="server" Text='<%# Eval("AdSenseID")  %>' CssClass="stdTextField1" 
                                            Width="350px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        AdSense Password:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdsPassword" runat="server" Text='<%# Eval("AdSensePwd")  %>' CssClass="stdTextField1" 
                                            Width="350px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        AdSense Code:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdCode" runat="server" Text='<%# Eval("AdSenseCode")  %>' CssClass="stdTextArea2" 
                                            TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        &nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                </table>
                
                </EditItemTemplate>
                
                <InsertItemTemplate>
                
                <table cellpadding="0" cellspacing="3" id="tblPlan" width="98%" runat="server">
                    <tr>
                        <td width="3%">
                            &nbsp;</td>
                        <td width="94%">&nbsp;
                            </td>
                        <td width="3%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2">
                            </td>
                        <td align="left" class="style2">
                              <div id="dvButtonNo" class="LogoBoxheadBlue">
                              <br />&nbsp;&nbsp; &nbsp;
                             <asp:Label ID="lblButtonNo" runat="server" CssClass="FontSubHeader"></asp:Label>
                             </div>
                             &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                        <td class="style2">
                            </td>
                        
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            <asp:Button ID="BtnSave" runat="server" CommandName="Insert" 
                                CssClass="stdbuttonCRUD" Text="SAVE" ValidationGroup="VgCheck"/>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                     <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                        
                        <table class="style1" id="tblButtonInfo">
                                <tr>
                                    <td width="25%" class="tblFormLabel1">
                                        <font class="font_12Msg_Success">User Details </font>:-</td>
                                    <td width="75%" class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%" align="right">
                                        Full Name :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Mobile Number :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="stdTextField1_disabled" 
                                            Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1" width="25%">
                                        Domain details :</td>
                                    <td class="tblFormText1" width="75%">
                                        <asp:TextBox ID="txtDomainInfo" runat="server" 
                                            CssClass="stdTextField1_disabled" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        <font class="font_12Msg_Success">AdSense details </font>:-</td>
                                    <td class="tblFormText1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        &nbsp;Adsense Login ID :</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdsLoginID" runat="server" CssClass="stdTextField1" 
                                            Width="350px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        AdSense Password:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdsPassword" runat="server" CssClass="stdTextField1" Width="350px" 
                                            ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tblFormLabel1">
                                        AdSense Code:</td>
                                    <td class="tblFormText1">
                                        <asp:TextBox ID="txtAdCode" runat="server" CssClass="stdTextArea2" 
                                            TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td>&nbsp;</td>
                    <td>
                       
                        &nbsp;
                        
                    </td>
                    <td>&nbsp;</td>
                    </tr>
                </table>
                
                </InsertItemTemplate>
                
             </asp:FormView>
             </td></tr>
             </table>
             
             
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            </tr>
        </table>
                
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

    </form>


 
</asp:Content>

