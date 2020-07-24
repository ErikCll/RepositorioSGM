<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreEvaluacion.aspx.cs" Inherits="SGM.Competencia.CensoAct.Evaluacion.PreEvaluacion" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>SGM</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <!-- Font Awesome -->
    <link href="../../../../plugins/fontawesome-free/css/all.min.css" rel="stylesheet" />
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Tempusdominus Bbootstrap 4 -->
    <link href="../../../../plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
  <!-- Theme style -->
    <link href="../../../dist/css/adminlte.min.css" rel="stylesheet" />

  <!-- overlayScrollbars -->
    <link href="../../../../plugins/overlayScrollbars/css/OverlayScrollbars.min.css" rel="stylesheet" />

  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet">
                  <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css">

     <style>
        .RBL label {
            margin-left: 3px;
        }
    </style>
</head>

<%--    hold-transition sidebar-mini layout-fixed--%>
<body  class=" bg-light " >
<form runat="server">
                            <asp:ScriptManager runat="server"></asp:ScriptManager>
    



  <!-- Content Wrapper. Contains page content -->
  <div >
    <!-- Content Header (Page header) -->
    <section class="content-header">

      <div class="container-fluid">
        <div class="row">
            <h1>              Ingreso a evaluación


</h1>
     
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">


    <asp:UpdatePanel runat="server" UpdateMode="Conditional">

        <ContentTemplate>

            <asp:Literal runat="server" ID="litControl"></asp:Literal>

            <div class="col-lg-12">
                <div class="row">
                
                    <div class="col-sm-3 col-md-3 col-lg-3">
                        <div class="form-group">
                            <label>Clave:</label>
                            <asp:TextBox runat="server" ID="txtClave" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClave" ForeColor="Red" ErrorMessage="Ingresar clave." ValidationGroup="btnIngresar"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                     <div class="col-sm-122 col-md-12 col-lg-12">
                        <div class="form-group">
                          <asp:Button runat="server" CssClass="btn btn-primary" Text="Ingresar" ID="btnIngresar" ValidationGroup="btnIngresar" OnClick="btnIngresar_Click"/>
                        </div>
                    </div>


                </div>

            </div>
            <telerik:RadWindow ID="RadWindow1" runat="server" Behaviors="Close,Resize,Maximize" Height="600px" Width="1200px" Modal="true" VisibleStatusbar="false" VisibleOnPageLoad="false" ></telerik:RadWindow>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->

  <!-- Control Sidebar -->

  <!-- /.control-sidebar -->

</form>
<!-- ./wrapper -->

<!-- jQuery -->
<script src="../../../../plugins/jquery/jquery.min.js"></script>
<!-- jQuery UI 1.11.4 -->
<script src="../../../../plugins/jquery-ui/jquery-ui.min.js"></script>
<!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
<script>
  $.widget.bridge('uibutton', $.ui.button)
</script>
<!-- Bootstrap 4 -->
<script src="../../../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>


<!-- overlayScrollbars -->
<script src="../../../../plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
<!-- AdminLTE App -->
<script src="../../../../dist/js/adminlte.js"></script>

<!-- AdminLTE for demo purposes -->
<script src="../../../../dist/js/demo.js"></script>
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
        <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script type="text/javascript">
          Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {





        });
        function DisableButton() {
          document.getElementById("<%= btnIngresar.ClientID %>").disabled = true;
                  document.getElementById("<%= btnIngresar.ClientID %>").value = "Cargando...";


        }
        window.onbeforeunload = DisableButton;

      function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
                 if (((keyEntry >= 65) && (keyEntry <= 90)) ||
                     ((keyEntry >= 97) && (keyEntry <= 122)) ||
                     (keyEntry == 46) || (keyEntry == 32) || keyEntry == 45 || (keyEntry == 32) || keyEntry == 45
                     || (keyEntry == 241) || keyEntry == 209
                     || (keyEntry == 225) || keyEntry == 233
                     || (keyEntry == 237) || keyEntry == 243
                     || (keyEntry == 243) || keyEntry == 250
                     || (keyEntry == 193) || keyEntry == 201
                     || (keyEntry == 205) || keyEntry == 211
                     || (keyEntry == 218) ||(keyEntry >=48 && keyEntry<=57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64) 
                return true;
            else {
                return false;
            }
        }

               function checkKeyCode(evt)
{

var evt = (evt) ? evt : ((event) ? event : null);
var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
if(event.keyCode==116)
{
evt.keyCode=0;
return false
}
}
document.onkeydown=checkKeyCode;
    </script>
    </body>
</html>
