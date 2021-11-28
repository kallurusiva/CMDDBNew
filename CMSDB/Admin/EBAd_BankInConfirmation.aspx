<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="EBAd_BankInConfirmation.aspx.cs" Inherits="EBAd_BankInConfirmation" %>

<%@ Register src="EBLeftMenu_FreeEbook.ascx" tagname="EBLeftMenu_FreeEbook" tagprefix="uc1" %>

<%@ Register src="EBLeftMenu_PayPalCC.ascx" tagname="EBLeftMenu_PayPalCC" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    <uc2:EBLeftMenu_PayPalCC ID="EBLeftMenu_PayPalCC1" runat="server" />
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">

    
     <style type="text/css">

         .CellPaddingRight { padding-right: 10px; 
         }

          .CellPaddingLeft { padding-left: 10px;
         }

         .FontColHeader {font: bold 12px "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #E432A3; padding-left: 5px; text-decoration: underline;}
         .FontColHead  {font: normal 11px "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #081363; padding-left: 5px;}
         .FontColText  {font: bold 11px "Trebuchet MS","Lucida Console", Arial, sans-serif; color: #3C4688; padding-left: 5px;}

         .auto-style1 {
             height: 25px;
         }



.BkfontTitle		{ FONT-SIZE: 14px; COLOR: #296692; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; font-weight: bold;}
.BkfontNote		    { FONT-SIZE: 10px; COLOR: #E75151; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; }
.BookBox {
     border: 1px dotted #D4DFAA;
    padding: 2px; 
  -webkit-border-radius: 5px;
    -moz-border-radius: 5px;
    border-radius: 5px;
    -webkit-box-shadow: 0 1px 2px rgba(0,0,0,0.3);
    -moz-box-shadow: 0 1px 2px rgba(0,0,0,0.3);
    box-shadow: 0 1px 2px rgba(0,0,0,0.3);
}

.BookImgCss {
    width: 55px; height: 80px;   padding: 5px; 
}

 .imgBankLogo {
      max-width: 150px;
      max-height: 70px;

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
                            &nbsp; EBooks: Purchase Payment Confirmation</td>
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
                        
                            
                        <table cellpadding="0" cellspacing="3" class="stdtableBorder_Main" width="100%">
                    <tr>
                        <td width="25%">
                            </td>
                        <td width="60%">
                            </td>
                        <td width="15%">
                            </td>
                        <td width="2%">
                            </td>
                    </tr>
                    <%--<tr>
                        <td>
                            &nbsp;</td>
                        <td >
                               <asp:Literal ID="Literal3" runat="server" 
                                Text="<%$ Resources:LangResources, Events %>"></asp:Literal>
                                &nbsp;
                                 <asp:Literal ID="Literal4" runat="server" 
                                Text="<%$ Resources:LangResources, Date %>"></asp:Literal></td>
                        <td >
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtEvtDate" CssClass="stdTextField1" runat="server"></asp:TextBox>
                            <a href="javascript:ShowCal('<%=txtEvtDate.ClientID%>');">
                            <asp:Image ID="ImgCal" runat="server" BorderStyle="None" 
                                ImageUrl="~/Images/cal.gif" /></a>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Transaction ID :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblTranId" runat="server" CssClass="font_14SuccessBold"></asp:Label>

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Purchased Items&nbsp; : </td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblItems" runat="server" CssClass="FontSubHeader"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Total Amount Due :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblAmountDue" runat="server" CssClass="font_14SuccessBold"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Total Amount Banked In :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblAmtPaid" runat="server" CssClass="BkfontTitle"></asp:Label>

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                        &nbsp;           

                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                          <span class="font_12Msg_Success">  Banked-In By </span></td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            FullName :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblFullName" runat="server" CssClass="font_Content"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Mobile No.:</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblMobileNo" runat="server" CssClass="font_Content"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Email ID :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblEmailId" runat="server" CssClass="font_Content"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                           <span class="font_12Msg_Success"> Banked-In TO </span></td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Bank Account No :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblBankActNo" runat="server" CssClass="font_Content"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Bank Name :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblBankName" runat="server" CssClass="font_Content"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Country :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblCountry" runat="server" CssClass="font_Content"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Date Time : </td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblDateTime" runat="server" CssClass="font_Content"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Bank-In Slip : </td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblBankInSlip" runat="server" CssClass="font_Content"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            Purchase Description :</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            <asp:Label ID="lblPurDescription" runat="server" CssClass="font_Content"></asp:Label>

                         </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            Remarks / Note : </td>
                        <td class="tblFormText1" align="left">
                            <asp:TextBox ID="txtRemarks" runat="server" Rows="6" CssClass="stdTextArea1" TextMode="MultiLine" Width="400px"></asp:TextBox>
                         </td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td class="tblFormText1" align="left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            &nbsp;</td>
                        <td class="tblFormText1" align="left" colspan="2">
                            <asp:Button ID="BtnUpdate" runat="server" ValidationGroup="vCheck" CssClass="stdbuttonAction" Text="Update Remarks Only" OnClick="BtnUpdate_Click"  />
                         &nbsp;&nbsp;
                            <asp:Button ID="BtnSendEmail" runat="server" ValidationGroup="vCheck" CssClass="small awesome blue" Text="Confirm and Send Books by Email" OnClick="BtnSendEmail_Click"  />
                         &nbsp;
                            <asp:Button ID="BtnCancel" runat="server" ValidationGroup="vCheck" CssClass="stdbuttonAction" Text="Cancel" OnClick="BtnCancel_Click"  />
                         </td>
                        
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                     <tr>
                        <td class="tblFormLabel1" >
                            </td>
                        <td class="tblFormText1" align="left">
                            </td>
                        <td class="tblFormText1" align="left">
                            </td>
                        <td class="auto-style1">
                            </td>
                    </tr>
                   
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
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
    
<asp:HiddenField ID="hdn_UId" runat="server" />
<asp:HiddenField ID="hdn_TranID" runat="server" />

</form>
</asp:Content>

