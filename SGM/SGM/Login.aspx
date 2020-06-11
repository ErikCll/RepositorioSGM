﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SGM.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
       <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>SGM | Login</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <!-- Font Awesome -->
    <link href="../../plugins/fontawesome-free/css/all.min.css" rel="stylesheet" />
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Tempusdominus Bbootstrap 4 -->
    <link href="../../plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
  <!-- Theme style -->
    <link href="../../dist/css/adminlte.min.css" rel="stylesheet" />

  <!-- overlayScrollbars -->
    <link href="../../plugins/overlayScrollbars/css/OverlayScrollbars.min.css" rel="stylesheet" />

  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
</head>
<body class="bg-gray-light">
    <form runat="server">
           <asp:Literal ID="litControl" runat="server"></asp:Literal>
        <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>
        
                 <div class="container">

            <div class="row">

                <div class="col-md-12 min-vh-100 d-flex flex-column justify-content-center">
                    <div class="row">

                        <div class="col-lg-6 col-md-8 mx-auto">

                            <!-- form card login -->

                            <div class="card rounded shadow shadow-lg ">
                                <div class="card-header">
                                    <h3 class="mb-0">Iniciar sesión</h3>
                                </div>
                                <asp:Login runat="server" CssClass="col-12" ID="Login1">
                                    <LayoutTemplate>
                                        <div class="card-body">
                                            <div class="form-group">

                                                <label>Usuario</label>
                                                <div class="input-group">
                                                    <asp:TextBox runat="server" ID="UserName" MaxLength="20" class="form-control" onkeypress="return AllowAlphabet(event)"></asp:TextBox>

                                                    <span class="input-group-append bg-white border-left-0">
                                                        <span class="input-group-text bg-transparent">
                                                            <i class=" ion-android-person"></i>
                                                        </span>
                                                    </span>
                                                </div>
                                                                    <asp:RequiredFieldValidator ForeColor="red" ID="require" runat="server" ControlToValidate="UserName" ValidationGroup="LoginButton" ErrorMessage="Ingresar acceso" ></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="form-group">
                                                <label>Contraseña</label>  <asp:LinkButton runat="server">(recuperar contraseña)</asp:LinkButton>

                                                <div class="input-group">
                                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" class="form-control" onkeypress="return AllowAlphabet(event)" ClientIDMode="Static" MaxLength="15"></asp:TextBox>

                                                    <span class="input-group-append bg-white">
                                                        <span class="btn border border-left-0" onmousedown="mostrarContrasena()" onmouseup="NomostrarContrasena()"><i class=" icon  ion-eye"></i></span>
                                                    </span>
                                                </div>
                                                                  <asp:RequiredFieldValidator  ForeColor="red" ID="RequiredFieldValidator1" runat="server" ControlToValidate="Password" ValidationGroup="LoginButton" ErrorMessage="Ingresar contraseña"></asp:RequiredFieldValidator>

                                            </div>

                                            <div>
                                               <%-- <label class="custom-control ">
                                                    <span class="custom-control-description small text-dark">Remember me on this computer</span>
                                                </label>--%>
                                            </div>
                                            <asp:Button runat="server" class="btn btn-primary float-right my-2" ID="LoginButton" Text="Entrar" ValidationGroup="LoginButton" CommandName="Login" />


                                        </div>
                                    </LayoutTemplate>
                                </asp:Login>

                            </div>

                            <!--/card-block-->

                            <!-- /form card login -->

                        </div>


                    </div>
                    <!--/row-->

                </div>
                <!--/col-->
            </div>
            <!--/row-->
        </div>
        
       
        <!--/container-->

    </form>

 <!-- jQuery -->
<script src="../../plugins/jquery/jquery.min.js"></script>
<!-- jQuery UI 1.11.4 -->
<script src="../../plugins/jquery-ui/jquery-ui.min.js"></script>
<!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
<script>
  $.widget.bridge('uibutton', $.ui.button)
</script>
<!-- Bootstrap 4 -->
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>


<!-- overlayScrollbars -->
<script src="../../plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.js"></script>

<!-- AdminLTE for demo purposes -->
<script src="../../dist/js/demo.js"></script>
    <script type="text/javascript">
                     Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

               Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(){

       //$('.card').hover(
       //         function () {
       //             $(this).animate({
       //                 marginTop: "-=2%",

       //             }, 200);
       //         },
       //         function () {
       //             $(this).animate({
       //                 marginTop: "0%"
       //             }, 200);
       //         }

       //     );
       // });
                  
     
          function mostrarContrasena(){
      var tipo = document.getElementById("Password");
      if(tipo.type == "password"){
          tipo.type = "text";
      }
     
        }
         function NomostrarContrasena(){
      var tipo = document.getElementById("Password");
      if(tipo.type == "text"){
          tipo.type = "password";
      }
     
        }

            function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= 65) && (keyEntry <= 90)) ||
                ((keyEntry >= 97) && (keyEntry <= 122)) ||
                (keyEntry == 46) || (keyEntry == 46) || keyEntry == 45 || (keyEntry == 46) || keyEntry == 45
                || (keyEntry == 241) || keyEntry == 209
                || (keyEntry == 225) || keyEntry == 233
                || (keyEntry == 237) || keyEntry == 243
                || (keyEntry == 243) || keyEntry == 250
                || (keyEntry == 193) || keyEntry == 201
                || (keyEntry == 205) || keyEntry == 211
                || (keyEntry == 218) || (keyEntry >= 48 && keyEntry <= 57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64)
                return true;
            else {
                return false;
            }
        }

    </script>
</body>
</html>