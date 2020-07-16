<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="SGM.Competencia.CensoAct.Evaluacion.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       Editar Evaluación
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="../Index.aspx">Censo de actividad</a></li>
                  <li class="breadcrumb-item active"><asp:LinkButton runat="server" onclick="Regresar">Control de versiones</asp:LinkButton></li>
    <li class="breadcrumb-item active"><asp:LinkButton runat="server" onclick="Regresar2">Evaluación</asp:LinkButton></li>
                          <li class="breadcrumb-item"><a>Editar</a></li>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
      <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Update1" >
        <ContentTemplate>
                        <asp:Literal runat="server" ID="litControl"></asp:Literal>

            <div class="col-lg-12">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Datos de la evaluación</h4>
                        </div>
                        <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Cantidad de reactivos:</label>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtCantidad" onkeypress="return soloNumeros(event)" MaxLength="3"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtCantidad"
                                    ErrorMessage="Cantidad de reactivos requerida." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     <div class="col-sm-12 col-md-8 col-lg-8"></div>
                     
                                        
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar"  OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
                                <asp:Button runat="server" CssClass=" btn btn-default" ID="btnRegresar" Text="Regresar"  OnClick="Regresar2"/>
                            </div>
                        </div>
                        </div>





                    </div>
                      </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        <script type="text/javascript">

              Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {



          });
                function DisableButton() {
                document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
                document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando...";
                        document.getElementById("<%= btnRegresar.ClientID %>").disabled = true;
                    document.getElementById("<%= btnRegresar.ClientID %>").value = "Cargando...";
            

  }
  window.onbeforeunload = DisableButton;
                                                           function soloNumeros(e){
  var key = window.event ? e.which : e.keyCode;
  if (key < 48 || key > 57) {
    e.preventDefault();
  }
}

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
