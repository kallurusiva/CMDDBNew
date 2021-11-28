<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ad_Navigate2WebSites.aspx.cs" Inherits="Admin_Ad_Navigate2WebSites" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        
        
        .valError
        {
        	border : solid 1px red; font-size: 12px; padding:  5px 7px 5px 7px; color: Red;
        }
        .modalBackground
                {

                    background-color:#ffffdd;
                    filter:alpha(opacity=40);
                    opacity:0.5;
                    border-width:1px;
                    border-style:solid;
                    border-color:#CCCCCC;
                    padding:3px;
                    position:absolute;
                }
                .modalInsideBackground
                {
                    background-color:#efefef;
                    border: 2px solid #ccda35;
                    color : #333333;
                    padding: 20px 20px 20px 20px;
                    
                }
                
                .panelheightWidth {max-height:70%; max-width:70%;}

        .modalPopup
    {
        background-color: #FFFFFF;
        width: 50%;
        border: 3px solid #0DA9D0;
        border-radius: 12px;
        padding:0
      
    }
    .modalPopup .header
    {
        background-color: #2FBDF1;
        height: 30px;
        color: White;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
        border-top-left-radius: 6px;
        border-top-right-radius: 6px;
    }
    .modalPopup .body
    {
        min-height: 100px;
        line-height: 30px;
        text-align: center;
        font-weight: bold;

    }
    .modalPopup .footer
    {
        padding: 6px;
    }
    .modalPopup .yes, .modalPopup .no
    {
        height: 25px;
        color: White;
        line-height: 25px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
        border-radius: 4px;
    }
    .modalPopup .yes
    {
        background-color: #2FBDF1;
        border: 1px solid #0DA9D0;
    }
    .modalPopup .no
    {
        background-color: #9F9F9F;
        border: 1px solid #5C5C5C;
    }

    .fontDebug {
        font: bold 15px Arial; color: white; 
    }




    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hdDebug" runat="server" />
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Label ID="lblDebug" CssClass="fontDebug" runat="server" Text=""></asp:Label>
    </div>

           <%--MODAL POPUP ALTER LOGIN --%>
    <asp:Button runat="server" ID="btnModalPopUp" style="display:none"/>
    <asp:ModalPopupExtender ID="ModalPopUpExtender1" runat="server" BackgroundCssClass="modalBackground" TargetControlID="btnModalPopUp" PopupControlID="pnlPopUp" PopupDragHandleControlID="PanelList" RepositionMode="RepositionOnWindowResize" OkControlID="ButtonClose"/>
    <asp:AnimationExtender ID="AnimationExtender1" runat="server"  TargetControlID="pnlPopUp">  
            <Animations>
              <OnLoad>
                 <Parallel AnimationTarget="pnlPopUp" Fps="10">
                    <FadeIn Duration=".1" Fps="10"/>
                  </Parallel>
               </OnLoad>
          </Animations>
    </asp:AnimationExtender>

    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
    <div class="header">
        ALERT !!! 
    </div>
    <div class="body">
        <asp:Literal ID="LblNotice" runat="server">Your Account has already expired.</asp:Literal>
    </div>
    <div class="footer" align="right">
       <%-- <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="yes" />
        <asp:Button ID="btnNo" runat="server" Text="No" CssClass="no" />--%>
        <asp:Button ID="ButtonClose" runat="server" Text="Close" CssClass="yes"/>
    </div>
 </asp:Panel>

    </form>
</body>
</html>
