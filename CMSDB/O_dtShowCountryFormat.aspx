<%@ Page Language="C#" AutoEventWireup="true" CodeFile="O_dtShowCountryFormat.aspx.cs" Inherits="O_dtShowCountryFormat" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<html>

<head runat="server">
    <meta charset="utf-8">
    <title>E-book</title>
    <meta name="description" content="Premium eCommerce Template">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <link runat="server" rel="icon" type="image/png" href="assets/images/favicons/favicon.png">
    <link runat="server" rel="apple-touch-icon" sizes="57x57" href="assets/images/favicons/faviconx57.png">
    <link runat="server" rel="apple-touch-icon" sizes="72x72" href="assets/images/favicons/faviconx72.png">
    <link runat="server" href="http://fonts.googleapis.com/css?family=Hind:400,700,600,500,300%7CFira+Sans:400,700italic,500italic,400italic,300italic,700,500,300" rel="stylesheet" type="text/css">
    <link runat="server" id="tmpMasterPluginCSS" name="tmpMasterPluginCSS" rel="stylesheet" href="assets/css/Green/plugins.min.css" />
    <link runat="server" id="tmpMasterStyleCSS" name="tmpMasterStyleCSS" rel="stylesheet" href="assets/css/Green/style.css" />
  
</head>

<body>
    <form>
        <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>--%>
                                <div class="main" runat="server">

        <%--<div class="container-fluid" runat="server">
            <div class="row" runat="server">
                <div class="col-md-9 col-md-push-3" runat="server">
                    <div class="top-filter-container clearfix" runat="server" id="dvRepeaterPages">--%>
                        <div class="row" runat="server">
                    <div class="col-lg-12 col-md-12" runat="server">
                        <div class="mb40" runat="server"></div>
                        <div class="tab-carousel-container" role="tabpanel" runat="server">
                            
                            <div class="tab-content" runat="server">
                                
                                <div role="tabpanel" class="tab-pane active" id="tab-details" >
                                    <div class="product-details-section" runat="server">
                                        <div class="row row-lg" runat="server">
                                            <div class="col-md-12 text-left" runat="server">
                                                <%--<div runat="server" id="dvglobalpurchaseLink">
                                                <a href="elements-buttons.html#" class="btn btn-lg no-radius btn-border btn-custom btn-block" data-toggle="modal" data-target="#global-purchase">Global SMS Purchase  </a>
                                                    </div>--%>
                                                <div runat="server" id="dvGlobalPurchase">
                                                <%--<div id="global-purchase" class="modal fade no-padding" tabindex="-1" role="dialog" aria-labelledby="gridSystemModalLabel">--%>
                                                <%--<div id="global-purchase" class="modal fade no-padding" >--%>
                                                    <div class="modal-dialog-lg" role="document" runat="server">
                                                        <div class="modal-content" runat="server">
                                                            <div class="modal-header" runat="server">
                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                <h4 class="modal-title" id="gridSystemModalLabel">Global SMS Purchase </h4>
                                                            </div>
                                                            <div class="modal-body" runat="server">
                                                                <div class="row" runat="server">
                                                                    <div class="col-md-3" runat="server">
                                                                        <%--<img class="img-responsive" src="assets/images/products/index5/product2.jpg">--%>
                                                                        <asp:Image ID="pBookImage" CssClass="img-responsive" ImageUrl="" runat="server" />
                                                                    </div>
                                                                    <div class="col-md-9" runat="server">
                                                                        <div class="table-responsive" runat="server" id="dvProductAllCountries">
                                                                            <table class="table table-bordered product-list-table">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td><b>Product Code</b></td>
                                                                                        <td><asp:Literal ID="pBookID" runat="server" Text=""></asp:Literal></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>Product Name</b></td>
                                                                                        <td><asp:Literal ID="pBookName" runat="server" Text=""></asp:Literal></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>Category</b></td>
                                                                                        <td><asp:Literal ID="pBookCategory" runat="server" Text=""></asp:Literal></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>Date Created</b></td>
                                                                                        <td><asp:Literal ID="pBookDate" runat="server" Text=""></asp:Literal></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>Original Price</b></td>
                                                                                        <td><span class="text-custom4"><asp:Literal ID="pBookOrgPrice" runat="server" Text=""></asp:Literal></span></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>After Discount</b></td>
                                                                                        <td><span class="text-custom4"><asp:Literal ID="pBookDiscountPrice" runat="server" Text=""></asp:Literal></span></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td><b>Prepaid Price</b></td>
                                                                                        <td><asp:Literal ID="pBookPrepaidPrice" runat="server" Text=""></asp:Literal></td>
                                                                                    </tr>
                                                                                </tbody>

                                                                            </table>
                                                                        </div>
                                                                        <div class="mobile-purchase-global" runat="server" id="dvflgIndonesia">
                                                                            <p><i class="fa fa-mobile" aria-hidden="true"></i> INDONESIA Mobile Purchase Format</p>
                                                                            <div class="code-mobile-detail" runat="server" id="dvPBookFormat">

                                                                                <h3><asp:Literal ID="pPFormat" runat="server" Text=""></asp:Literal></h3>

                                                                                <h3><asp:Literal ID="pBookSendTo" runat="server" Text=""></asp:Literal></h3>
                                                                                <small><asp:Literal ID="pBookDFormat" runat="server" Text=""></asp:Literal></small>
                                                                            </div>
                                                                        </div>
                                                                        <div class="mobile-purchase-global" runat="server" id="dvPBookFormat1">
                                                                            <p><i class="fa fa-mobile" aria-hidden="true"></i> SINGAPORE SMS Purchase</p>
                                                                            <div class="code-mobile-detail" runat="server">

                                                                                <h3><asp:Literal ID="pPFormat1" runat="server" Text=""></asp:Literal></h3>

                                                                                <h3><asp:Literal ID="pBookSendTo1" runat="server" Text=""></asp:Literal></h3>
                                                                                <small><asp:Literal ID="pBookDFormat1" runat="server" Text=""></asp:Literal></small>
                                                                            </div>
                                                                        </div>
                                                                        <div class="mobile-purchase-global" runat="server" id="dvPBookFormat2">
                                                                            <p><i class="fa fa-mobile" aria-hidden="true"></i> Malaysia SMS Purchase</p>
                                                                            <div class="code-mobile-detail" runat="server">

                                                                                <h3><asp:Literal ID="pPFormat2" runat="server" Text=""></asp:Literal></h3>

                                                                                <h3><asp:Literal ID="pBookSendTo2" runat="server" Text=""></asp:Literal></h3>
                                                                                <small><asp:Literal ID="pBookDFormat2" runat="server" Text=""></asp:Literal></small>
                                                                            </div>
                                                                        </div>

                                                                        <div class="mobile-purchase-global" runat="server" id="dvPBookFormat3">
                                                                            <p><i class="fa fa-mobile" aria-hidden="true"></i> Thailand SMS Purchase</p>
                                                                            <div class="code-mobile-detail" runat="server">

                                                                                <h3><asp:Literal ID="pPFormat3" runat="server" Text=""></asp:Literal></h3>

                                                                                <h3><asp:Literal ID="pBookSendTo3" runat="server" Text=""></asp:Literal></h3>
                                                                                <small><asp:Literal ID="pBookDFormat3" runat="server" Text=""></asp:Literal></small>
                                                                            </div>
                                                                        </div>

                                                                        <div class="mobile-purchase-global" runat="server" id="dvPBookFormat4">
                                                                            <p><i class="fa fa-mobile" aria-hidden="true"></i> Philippines SMS Purchase</p>
                                                                            <div class="code-mobile-detail" runat="server">

                                                                                <h3><asp:Literal ID="pPFormat4" runat="server" Text=""></asp:Literal></h3>

                                                                                <h3><asp:Literal ID="pBookSendTo4" runat="server" Text=""></asp:Literal></h3>
                                                                                <small><asp:Literal ID="pBookDFormat4" runat="server" Text=""></asp:Literal></small>
                                                                            </div>
                                                                        </div>

                                                                        <div class="mobile-purchase-global" runat="server" id="dvPBookFormat5">
                                                                            <p><i class="fa fa-mobile" aria-hidden="true"></i> Vietnam SMS Purchase</p>
                                                                            <div class="code-mobile-detail" runat="server">

                                                                                <h3><asp:Literal ID="pPFormat5" runat="server" Text=""></asp:Literal></h3>

                                                                                <h3><asp:Literal ID="pBookSendTo5" runat="server" Text=""></asp:Literal></h3>
                                                                                <small><asp:Literal ID="pBookDFormat5" runat="server" Text=""></asp:Literal></small>
                                                                            </div>
                                                                        </div>

                                                                    </div>
                                                                </div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                <%--</div>--%>
                                                </div>
                                                
                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                       
                    </div>

                </div>
                    </div>
                <%--</div>
            </div>            
        </div>
        
    </div>--%>
</form>
</body>