<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doc.aspx.cs" Inherits="SASISOPA.s.ControlAct.Doc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>Documento</title>
  
    <link href="../../../../plugins/fontawesome-free/css/all.min.css" rel="stylesheet" />
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"/>
  <!-- Tempusdominus Bbootstrap 4 -->
    <link href="../../../../plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
  <!-- Theme style -->
    <link href="../../../dist/css/adminlte.min.css" rel="stylesheet" />

  <!-- overlayScrollbars -->
    <link href="../../../../plugins/overlayScrollbars/css/OverlayScrollbars.min.css" rel="stylesheet" />

  <!-- Google Font: Source Sans Pro -->
  <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet"/>
                  <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-12">
            <div class="row">
                      <div class="embed-responsive embed-responsive-1by1">
            
                <iframe class="embed-responsive-item" runat="server" id="frame" visible="true" frameBorder="0" style="border:0" ></iframe>
                    </div>
            </div>
        </div>
    </form>
  
</body>
</html>
