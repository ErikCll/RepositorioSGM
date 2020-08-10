<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluacion.aspx.cs" Inherits="SGM.Competencia.CensoAct.Evaluacion.EvPrueba2" %>

<!DOCTYPE html>

<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Evaluación</title>
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
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1>              Evaluación
</h1>
              <h6 class="mt-1">Actividad: <asp:Label runat="server" ID="lblActividad" CssClass=" font-weight-bold"></asp:Label></h6>
              <h6>Empleado: <asp:Label runat="server" ID="lblEmpleado" CssClass=" font-weight-bold"></asp:Label></h6>
          </div>
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
                
<%--              <li class="breadcrumb-item active">Blank Page</li>--%>
            </ol>
          </div>
        </div>
      </div><!-- /.container-fluid -->
    </section>

    <!-- Main content -->
    <section class="content">

       <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" Enabled="false"></asp:Timer>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">

        <ContentTemplate>

            <asp:Literal runat="server" ID="litControl"></asp:Literal>

            <div class="col-lg-12">
                <div class="row" runat="server" id="RowEvaluacion">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <asp:Button runat="server" CssClass="btn btn-danger" ID="btnTime" Visible="false" />
                        <%--                                                                    Date: <asp:Label Id="LabelDateTime" runat="server"></asp:Label>--%>
                    </div>

                    <div class="col-12">
                        <asp:ListView runat="server" ID="lstPreguntas" OnItemDataBound="lstPreguntas_ItemDataBound" OnPagePropertiesChanging="lstPreguntas_PagePropertiesChanging">

                            <ItemTemplate>
                                <div class=" container col-8">
                                    <div class=" col-sm-12 col-md-12 col-lg-12">
                                        <div class="card shadow border-top border-dark">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-sm-12 col-md-12 col-lg-12">

                                                        <asp:Label runat="server" ID="lblContador" Text='<%# Eval("ORDEN") %>'></asp:Label>.

              <label class=" font-weight-bold"><%# Eval("Pregunta") %></label>
                                                        <asp:Label runat="server" ID="lblIdPregunta" Text='<%# Eval("Id_Pregunta") %>' Visible="false"></asp:Label>
                                                        <asp:Label runat="server" ID="lblTipoPregunta" Text='<%# Eval("TipoPregunta") %>' Visible="false"></asp:Label>
                                                        <asp:Label runat="server" ID="lblIdRespuesta" Visible="false"></asp:Label>


                                                        <asp:RadioButtonList runat="server" ID="radioList" DataTextField="Respuesta" DataValueField="Id_Respuesta" TextAlign="Right" CssClass="RBL"></asp:RadioButtonList>



                                                    </div>



                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:ListView>

                    </div>
                    <div class="container">
                        <div class="col-sm-12 col-md-12 col-lg-12">
                             <label class=" text-gray font-weight-normal">Total de preguntas: </label><asp:Label CssClass="ml-1" runat="server" ID="lblTotal"></asp:Label>
                            <div class="form-group float-right">
                               
                                 <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstPreguntas" PageSize="1">
                        <Fields>


                            <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ButtonType="Button" ShowLastPageButton="false" ShowFirstPageButton="false" ShowNextPageButton="true" ShowPreviousPageButton="false" NextPageText="Siguiente"/>
                            <asp:NumericPagerField Visible="false"  />
                            

                        </Fields>

                    </asp:DataPager>
                                <asp:Button runat="server" CssClass="btn btn-success" Text="Finalizar" ID="btnFinalizar" Visible="false" OnClick="btnFinalizar_Click" />
                                <asp:Label runat="server" ID="lblCal"></asp:Label>
                            </div>

                        </div>
                    </div>

                   


                </div>
                <div class="row" runat="server" id="RowCalificacion" visible="false">
                    <div class="col-sm-12 col-md-12 col-lg-12 text-center">
                        <div class=" custom-control-inline">
                            <label class="font-weight-normal">Calificación:</label>
                            <asp:Label runat="server" ID="lblCalificacion" CssClass=" font-weight-bold ml-1"></asp:Label>
                            <label class="font-weight-normal">/10</label>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
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
            document.getElementById("<%= btnFinalizar.ClientID %>").disabled = true;
                  document.getElementById("<%= btnFinalizar.ClientID %>").value = "Cargando...";


        }
        window.onbeforeunload = DisableButton;

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
