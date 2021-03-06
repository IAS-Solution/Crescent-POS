<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Crescent_POS.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Crescent POS | Log in</title>

  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/adminlte.min.css">
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <!-- /.login-logo -->
  <div class="card card-outline card-primary">
    <div class="card-header text-center">
      <h1><b>Crescent POS</b></h1>
        <h2><b>Log In</b></h2>
    </div>
    <div class="card-body">
      <p class="login-box-msg">Sign in to start your session</p>

      <form runat="server">
        <div class="input-group mb-3">
          <%--<input type="email" class="form-control" placeholder="Email">--%>
            <asp:TextBox ID="txtUser" runat="server" TextMode="SingleLine" Class="form-control" placeholder="User Name"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          <%--<input type="password" id="txtPassword" class="form-control" placeholder="Password">--%>
            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Class="form-control" placeholder="Password"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-8">
            <div class="icheck-primary">
              <input type="checkbox" id="remember">
              <label for="remember">
                Remember Me
              </label>
            </div>
          </div>
          <!-- /.col -->
          <div class="col-4">
           <%-- <button type="submit" class="btn btn-primary btn-block" >Sign In</button>--%>
              <asp:Button ID="btnSignIn" runat="server" Class="btn btn-primary btn-block" Text="Sign In" OnClick="btnSignIn_Click"/>
          </div>
          <!-- /.col -->
        </div>
            
      </form>
       

      <%--<div class="social-auth-links text-center mt-2 mb-3">
        <a href="#" class="btn btn-block btn-primary">
          <i class="fab fa-facebook mr-2"></i> Sign in using Facebook
        </a>
        <a href="#" class="btn btn-block btn-danger">
          <i class="fab fa-google-plus mr-2"></i> Sign in using Google+
        </a>
      </div>--%>
      <!-- /.social-auth-links -->

     <%-- <p class="mb-1">
        <a href="forgot-password.html">I forgot my password</a>
      </p>--%>
      <%--<p class="mb-0">
        <a href="register.html" class="text-center">Register a new membership</a>
      </p>--%>
    </div>
    <!-- /.card-body -->
  </div>
     
  <!-- /.card -->
</div>
    <div class="alert alert-danger alert-dismissible" id="errorlogin" runat="server"  Visible="false" >
                  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                  <h5><i class="icon fas fa-ban"></i> Alert!</h5>
                 Incorrect User Name or Password!
                </div>
<!-- /.login-box -->

<!-- jQuery -->
<script src="../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
</body>
</html>

