<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dtContctUs.aspx.cs" Inherits="O_dtContctUs" %>
<%@ Register Src="~/O_topBlue.ascx" TagPrefix="uc1" TagName="O_topBlue" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopMenu" runat="Server">
    <uc1:O_topBlue runat="server" ID="O_topBlue" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" runat="Server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

    <div class="main" runat="server">
        <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row row-lg">
                            <form action="#">
                                <div class="col-sm-6">
                                    <div class="form-group mb30 label-overlay">Select Country : <asp:DropDownList ID="DdlCountry" CssClass="stdDropDown1" runat="server"></asp:DropDownList></div>
                                    <div class="form-group mb30 label-overlay">
                                        <asp:Label ID="lblName" CssClass="fa fa-user" runat="server" Text="Name"></asp:Label>
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" Text=""></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  CssClass="fa fa-user"
                                          ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Please enter name" 
                                          ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group mb30 label-overlay">
                                        <asp:Label ID="lblContactNo" CssClass="fa fa-phone-square" runat="server" Text="Contact No."></asp:Label>
                                        <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                              ControlToValidate="txtContactNo" Display="Dynamic" 
                                              ErrorMessage="Please enter ContactNo" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group mb30 label-overlay">
                                        <asp:Label ID="lblEmail" CssClass="fa fa-envelope" runat="server" Text="Email"></asp:Label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                          ControlToValidate="txtEmail" Display="Dynamic" 
                                          ErrorMessage="Please enter email." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                      ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                      Display="Dynamic" runat="server" ErrorMessage="*  Enter a Valid Email" ValidationGroup="VgCheck" 
                                      SetFocusOnError="True"></asp:RegularExpressionValidator>
                                        </div>
                                    <div class="form-group mb30 label-overlay">
                                        <asp:Label ID="lblSubject" CssClass="fa fa-bookmark" runat="server" Text="Subject"></asp:Label>
                                        <asp:TextBox ID="txtSubject" CssClass="form-control" runat="server"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                              ControlToValidate="txtSubject" Display="Dynamic" 
                                              ErrorMessage="Please enter Subject" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                        </div>
                                </div>
                                <div class="col-sm-6">
                                <div class="form-group textarea-group mb30 label-overlay">
                                    <asp:Label ID="lblMessage" CssClass="fa fa-pencil" runat="server" Text="Message"></asp:Label>
                                    <asp:TextBox ID="txtMessage" 
                                      CssClass="form-control min-height" runat="server" TextMode="MultiLine"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                      ControlToValidate="txtMessage" Display="Dynamic" 
                                      ErrorMessage="Please enter Message." ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                    <%--<br />--%>
                                    <%--<asp:Button ID="btnSubmit"  CssClass="btn btn-custom  fright" runat="server" Text="POST COMMENT" OnClick="btnSubmit_Click"  ValidationGroup="VgCheck" />--%>
                                </div>
                                </div>
                                <div class="col-sm-6">
                                <div class="form-group mb30 label-overlay">
                                        <asp:Label ID="lblSecurity" CssClass="fa fa-pencil" runat="server" Text="Security code (Enter 12341234  or  12451245  or  12351235)"></asp:Label>
                                        <asp:TextBox ID="txtSecurity" CssClass="form-control" runat="server"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                              ControlToValidate="txtSecurity" Display="Dynamic" 
                                              ErrorMessage="Please enter Security code" ValidationGroup="VgCheck"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Button ID="Button1"  CssClass="btn btn-custom  fright" runat="server" Text="POST COMMENT" OnClick="btnSubmit_Click"  ValidationGroup="VgCheck" />
                                </div>
                            </form>
                        </div>
                        <div class="mb100 mb80-sm"></div>
                        <div class="contact-infos-wrapper">
                            <div class="row">
                                <div class="col-sm-4 contact-info-container">
                                    <div class="contact-info"><i class="icon contact-icon contact-pin"></i>
                                        <div class="contact-info-meta">
                                            <h3>our location</h3><address>
                                                <%--<asp:Literal ID="ltrCompanyName" Text="" runat="server"></asp:Literal>
                                                 <br />--%>
                                                 <%--<asp:Literal ID="LtrNickName" Text="" runat="server"></asp:Literal>
                                                 <br />--%>
                                                 <br />
                                                 <asp:Literal ID="LtrAddress" Text="" runat="server"></asp:Literal>
                                                 <br />
                                                 </address></div>
                                    </div>
                                </div>
                                <div class="col-sm-4 contact-info-container">
                                    <div class="contact-info"><i class="icon contact-icon contact-email"></i>
                                        <div class="contact-info-meta">
                                            <h3>Contact Details</h3>
                                            <ul>
                                                <asp:Literal ID="ltrCompName" Text="" runat="server"></asp:Literal>
                                                 <br />
                                                <li><span>Email:</span> <a href="mailto:#"><asp:Literal ID="ltrEmail" Text="" runat="server"></asp:Literal></a></li>
                                                <%--<li><span>Skype:</span> sconto_shop</li>--%>
                                            </ul><%--<a href="contact.html#" class="more-link">Read more</a>--%></div>
                                    </div>
                                </div>
                                <div class="col-sm-4 contact-info-container">
                                    <div class="contact-info"><i class="icon contact-icon contact-phone"></i>
                                        <div class="contact-info-meta">
                                            <h3>Contact Us</h3>
                                            <ul>
                                                <li><span>Phone:</span> <asp:Literal ID="ltrHomephone" Text="" runat="server"></asp:Literal></li>
                                                <li><span>Mobile:</span><asp:Literal ID="LtrHandPhone" Text="" runat="server"></asp:Literal></li>
                                                <li><span>Fax:</span><asp:Literal ID="ltrFaxNo" Text="" runat="server"></asp:Literal></li>
                                            </ul><%--<a href="contact.html#" class="more-link">Read more</a>--%></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="mb130 mb100-sm mb80-xs"></div>
            </div>
        </div>
                                                
</asp:Content>
