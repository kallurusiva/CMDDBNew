<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgotPwd_Merchant.aspx.cs" Inherits="forgotPwd_Merchant" %>

<!DOCTYPE html>
<html lang="en" >
   <head>
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<title>

SMEBigData Digital Tool

</title>

<meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no' name='viewport' />


<!--     Fonts and icons     -->
<link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">

<!-- CSS Files -->
<link href="./Merchant/assets/css/mt1.min.css" rel="stylesheet" />

</head>
    <body class="login-page sidebar-collapse">
<div class="page-header header-filter" style="background-image: url(./Merchant/assets/img/bg7.jpg); background-size: cover; background-position: top center;">
  <div class="container">
    <div class="row">
      <div class="col-lg-4 col-md-6 ml-auto mr-auto">
        <div class="card card-login">
            <form class="form" method="POST"  runat="server">
              <div class="card-header card-header-info text-center">
                <h4 class="card-title">Forgot Password</h4>
                <strong>Merchant Membership Program (MMP)</strong>
              </div>
                
                <br/>
              <div class="card-body">


                <div class="input-group">
                  <div class="input-group-prepend">
                    <span class="input-group-text">
                        <i class="material-icons">person</i>
                    </span>
                  </div>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtLoginID"></asp:TextBox>
                </div>

              </div>
              <div class="footer text-center">
                  <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" Text="send Email" OnClick="btnSubmit_Click" />
                <br/><br/>
                <a href="Merchant.aspx">Back to Login</a>
                <br><br>

              </div>


            </form>
          </div>
      </div>
    </div>
  </div>


</div>

    </body>
</html>
