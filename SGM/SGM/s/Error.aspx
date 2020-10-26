<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SGM.s.Error" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Error</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Font Awesome -->
    <link href="../../plugins/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Tempusdominus Bbootstrap 4 -->
    <link href="../../plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
    <!-- Theme style -->
    <link href="../../dist/css/adminlte.min.css" rel="stylesheet" />

    <!-- overlayScrollbars -->
    <link href="../../plugins/overlayScrollbars/css/OverlayScrollbars.min.css" rel="stylesheet" />

    <!-- Google Font: Source Sans Pro -->
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet" />

    <style>
        @media screen and (max-width: 600px) {
            .ocultar-letras {
                /*display:none;*/
                font-size: 20px;
            }
    </style>
</head>


<body class="bg-gray-light">
    <form runat="server">
        <asp:Literal ID="litControl" runat="server"></asp:Literal>
        <asp:ScriptManager runat="server" ID="scrScript"></asp:ScriptManager>

        <section class="content">

            <div class="col-lg-12">
                <div class="row">
                 <div class="col-sm-12 col-md-12 col-lg-12">

       <div class="error-page float-left">

                        <div class="error-content">
                            <h3><i class=" ion-android-warning text-red "></i>Error al momento de la ejecución.</h3>

                            <p>
                                Se notificó a los administradores sobre el error.
            Para regresar a inicio, presione
                                <asp:LinkButton runat="server" ID="btnRegresar" OnClick="btnRegresar_Click">aqui.</asp:LinkButton>
                            </p>


                        </div>
                    </div>
                 </div>

             
                </div>

            </div>


        </section>




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

        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {

        });

          

           

    </script>

</body>
</html>
