<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LFR_Paypal.aspx.cs" Inherits="LFR_Paypal" %>

 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
    <style type="text/css">  
        body  
        {  
            font-family: Arial;  
            font-size: 10pt;  
        }  
        .modalBackground  
        {  
            background-color: Black;  
            filter: alpha(opacity=60);  
            opacity: 0.6;  
        }  
        .modalPopup  
        {  
            background-color: #FFFFFF;  
            width: 500px;  
            border: 3px solid #0DA9D0;  
            padding: 0;  
        }  
        .modalPopup .header  
        {  
            background-color: #2FBDF1;  
            height: 30px;  
            color: White;  
            line-height: 30px;  
            text-align: center;  
            font-weight: bold;  
        }  
        .modalPopup .body  
        {  
            min-height: 50px;  
            padding:5px;  
            line-height: 30px;  
            text-align: center;  
            font-weight: bold;  
        }  
        .Input {  
    background-color: #2f8cf1; /* Green */  
    border: none;  
    color: white;  
    text-align: center;  
    text-decoration: none;  
    display: inline-block;  
    font-size: 16px;  
    margin: 4px 2px;  
    cursor: pointer;  
}  
  .button {  
        border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #ff6a00; /* Green */  
            color: white;  
            text-align: center;  
            text-decoration: none;  
            display: inline-block;  
            font-size: 16px;  
            margin: 4px 2px;  
            cursor: pointer;
            height: 24px;
        }  
  
.button1 {padding: 10px 24px;}  
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            color: #CC3300;
        }
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  

       
        <table class="auto-style1">
            <tr>
                <td rowspan="8" style="text-align: center">
                    <%--<asp:Label ID="LabelShowYouTubeVideo" runat="server">

                    </asp:Label>--%>
                    
                    <%--<video autoplay loop controls="controls" style="height: 273px; width: 490px; position: relative; top: 138px; left: 0px; ">
      <source src="~/images/video1.mp4" type="video/mp4" /></video>--%>

                     <video src="C:\\HostingSpaces\\admin\\www.1worldsms.com\\wwwroot\\Images\\video1.mp4" controls autoplay>HTML5 Video example</video> 

                </td>
                <td>
                    
                    <strong>Numerology Report</strong></td>
                <td class="auto-style2"><strong>A special offer of $5 for a limited period</strong></td>
            </tr>
            <tr>
                <td>
                    
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    
                    Price</td>
                <td>: USD 5.00</td>
            </tr>
            <tr>
                <td><asp:Label ID="lblFullName" runat="server" Text="Enter Full Name (*)"></asp:Label> </td>
                <td>: <asp:TextBox ID="txtcName" runat="server"></asp:TextBox>
                                                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="VgCheck" ControlToValidate="txtcName" CssClass="text-custom" ErrorMessage="Name cannot be Empty"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
    <asp:Label ID="lblDOB" runat="server" Text="Enter Date of Birth (*)"></asp:Label> </td>
                <td>: <asp:TextBox ID="txtDOB" runat="server" Text="01011973" MaxLength="8"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="VgCheck" ControlToValidate="txtDOB" CssClass="text-custom" ErrorMessage="DOB cannot be Empty"></asp:RequiredFieldValidator>&nbsp; 
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                                  ControlToValidate="txtDOB" ValidationExpression="\s*[0-9]{8,8}\s*" 
                                                  Display="Dynamic" runat="server" ErrorMessage=" Enter a Valid DOB(DDMMYYYY)" ValidationGroup="VgCheck" 
                                                  SetFocusOnError="True" CssClass="text-custom"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td>
    <asp:Label ID="lblEmail" runat="server" Text="Enter Email (*)"></asp:Label> </td>
                <td>: <asp:TextBox ID="txtcEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqValImage" ControlToValidate="txtcEmail" runat="server" ErrorMessage="Enter Email ID." ValidationGroup="VgCheck" Display="Dynamic" CssClass="text-custom"></asp:RequiredFieldValidator>

                                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                                  ControlToValidate="txtcEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                  Display="Dynamic" runat="server" ErrorMessage=" Enter a Valid Email" ValidationGroup="VgCheck" 
                                                  SetFocusOnError="True" CssClass="text-custom"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td>
    <asp:Label ID="lblMobile" runat="server" Text="Enter Mobile (*)"></asp:Label> </td>
                <td>: <asp:TextBox ID="txtcMobile" runat="server"></asp:TextBox> 
              &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtcMobile" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Mobile No. cannot be Empty"></asp:RequiredFieldValidator>
              &nbsp; 
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
                                                  ControlToValidate="txtcMobile" ValidationExpression="^[1-9][0-9]*$" 
                                                  Display="Dynamic" runat="server" ErrorMessage=" Enter a Valid Mobile without leading zero" ValidationGroup="VgCheck" 
                                                  SetFocusOnError="True" CssClass="text-custom"></asp:RegularExpressionValidator> </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2"><asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="button -blue center" Text="Purchase with PayPal" OnClick="BtnSubmit_Click" /></td>
            </tr>
        </table>
        <br /><br />
    
    </form>  
</body>  
</html>  