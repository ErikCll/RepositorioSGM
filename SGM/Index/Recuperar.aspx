<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recuperar.aspx.cs" Inherits="SAM.Recuperar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
       <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <title>SAM | Iniciar sesión</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <!-- Font Awesome -->
    <link href="../../plugins/fontawesome-free/css/all.min.css" rel="stylesheet" />
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"/>
  <!-- Tempusdominus Bbootstrap 4 -->
    <link href="../../plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
  <!-- Theme style -->
    <link href="../../dist/css/adminlte.min.css" rel="stylesheet" />

  <!-- overlayScrollbars -->
    <link href="../../plugins/overlayScrollbars/css/OverlayScrollbars.min.css" rel="stylesheet" />

  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet"/>

  <style>
      @media screen and (max-width: 600px) {
.ocultar-letras{
/*display:none;*/
font-size:20px;
}
  </style>
</head>

   
<body class="bg-gray-light">
    <form runat="server">
        <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>
        
         <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
           <asp:Literal ID="litControl" runat="server"></asp:Literal>

                <section class=" content-header">
                    <h1>Recuperar contraseña</h1>
                </section>
       

        <section class="content">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-5 col-md-5 col-lg-5">
                                            <h5 class="font-weight-bold">¿Olvidaste tu contraseña?</h5>
                     
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-5 col-md-5 col-lg-5">
                      <p class="text-justify">Ingresa la cuenta de correo con la que fuiste registrado, se enviará a tu correo electrónico tu contraseña. Si no recuerda su cuenta de correo, contacte al administrador.</p>
                        <input runat="server" type="email" placeholder="Correo electrónico" class="form-control" style="width:350px" id="txtCorreo" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12 col-md-4 col-lg-4">
                                                <asp:Button runat="server" id="btnEnviar" Text="Enviar" CssClass="btn btn-primary ml-1" ValidationGroup="btnEnviar" OnClick="btnEnviar_Click"/>

                                                <asp:Button runat="server" ID="btnRegresar" Text="Regresar" CssClass="btn btn-default" PostBackUrl="~/Login.aspx" />
<%--                                                                                     <a class="btn btn-default" href="#" onclick="history.back();">Regresar</a>  --%>



                    </div>
              
                </div>
                      <div class="row">
                        <div class="col-sm-12 col-md-4 col-lg-4">
                          <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCorreo" ValidationGroup="btnEnviar" ErrorMessage="Ingresar correo." ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                    </div>
            </div>
        </section>
              

            </ContentTemplate>
        </asp:UpdatePanel>
         
        
       
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

                    });
              
     function DisableButton() {
                document.getElementById("<%= btnEnviar.ClientID %>").disabled = true;
                    document.getElementById("<%= btnEnviar.ClientID %>").value = "Cargando...";
                      document.getElementById("<%= btnRegresar.ClientID %>").disabled = true;
                    document.getElementById("<%= btnRegresar.ClientID %>").value = "Cargando...";


  }
  window.onbeforeunload = DisableButton;

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
