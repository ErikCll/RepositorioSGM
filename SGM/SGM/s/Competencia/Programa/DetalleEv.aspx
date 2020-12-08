<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleEv.aspx.cs" Inherits="SGM.Competencia.Programa.Ver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Detalle de evaluación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="Index.aspx">Programa de capacitación</a></li>
      <li class="breadcrumb-item active"><a href="Detalle.aspx">Programa de evaluaciones</a></li>
                  <li class="breadcrumb-item "><asp:LinkButton runat="server" OnClick="Regresar">Programar</asp:LinkButton></li>
              <li class="breadcrumb-item "><a>Detalle</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <div class="col-lg-12">
                  <div class="card" >
                      <div class="card-header">
                                                      <h4>Datos de la evaluación</h4>

                      </div>
                <div class="card-body">
                    <div class="row">
                      
                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Actividad:</label>
                                <asp:Label runat="server" CssClass="font-weight-bold" ID="lblActividad"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label class="font-weight-normal">Empleado:</label>
                                 <asp:Label runat="server" CssClass="font-weight-bold" ID="lblEmpleado"></asp:Label>
                            </div>
                       
                            <div class="form-group">
                                 <label class="font-weight-normal">Estatus:</label>
                                <asp:Label runat="server" ID="lblEstatus" CssClass=" font-weight-bold"></asp:Label>
                            </div>
                            </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Fecha de programación:</label>
                                <asp:Label runat="server" ID="lblFechaEvaluacion" CssClass=" font-weight-bold"></asp:Label>
                            </div>
                              <div class="form-group">
                                <label class="font-weight-normal">Fecha de realización:</label>
                                <asp:Label runat="server" ID="lblFechaRealizado" CssClass=" font-weight-bold"></asp:Label>
                            </div>
                              <div class="form-group">
                                <label class="font-weight-normal">Calificación:</label>
                                <asp:Label runat="server" ID="lblCalificacion" CssClass=" font-weight-bold"></asp:Label>
                            </div>
                            
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                        </div>
                      
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                               
                                <asp:Button runat="server" class="btn btn-default" Text="Regresar" OnClick="Regresar" ID="btnRegresar"/>
                            </div>
                        </div>
                        </div>
                    </div>
                      </div>
        </div>
       <script type="text/javascript">

              Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {



          });
                function DisableButton() {
             
                     document.getElementById("<%= btnRegresar.ClientID %>").disabled = true;
                document.getElementById("<%= btnRegresar.ClientID %>").value = "Cargando...";


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
            </script>  
</asp:Content>
