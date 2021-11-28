<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPopUp.aspx.cs" Inherits="TestPopUp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript" language="javascript">
        function OpenMasWebReg() {

            window.open("Mas1UserWebRegistration.aspx", "Mas1Web", "location=no,menubar=0,width=600,height=800");
        
        
        }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" CombineScripts="false">
        </asp:ToolkitScriptManager>
        <br />
        <br />
        <br />
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
         TargetControlID="BtnShowPanel"
          PopupControlID = "PanelReg" CancelControlID="btnClose" DropShadow="true" 
        >
        </asp:ModalPopupExtender>
        
        <asp:Panel ID="PanelReg" runat="server">
        <asp:Button ID="btnOk" runat="server" Text="Ok" /> 
        <asp:Button ID="btnClose" runat="server" Text="Close Me" /> 
    
        </asp:Panel>
        
        <asp:Button ID="BtnShowPanel" runat="server" Text="Button" />
    </div>
    </form>
</body>
</html>
