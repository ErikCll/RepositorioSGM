<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="SGM.Competencia.CensoAct.CrearEv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Crear Evaluación (Paso 1)<br />
        <label class="font-weight-normal text small">Control de versión: </label> <asp:Label runat="server" ID="lblCodigo" CssClass=" font-weight-bold text small"></asp:Label><br />
    <label class=" font-weight-normal text small">Censo de actividad:</label> <asp:Label runat="server" ID="lblActividad" CssClass=" font-weight-bold text small"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="../Index.aspx">Censo de actividad</a></li>
                  <li class="breadcrumb-item active"><asp:LinkButton runat="server" onclick="Regresar">Control de versiones</asp:LinkButton></li>
                          <li class="breadcrumb-item"><a>Crear Evaluación</a></li>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
       <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="Update1" >
        <ContentTemplate>
                        <asp:Literal runat="server" ID="litControl"></asp:Literal>

            <div class="col-lg-12">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row" runat="server" id="rowCaptura" visible="false">
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

                         <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Calificación mínima:</label>

                                <input id="txtRange2"  runat="server" style="border:none;width:30px" value="5" readonly="readonly" />
                                    <%-- <input type="range" id="range" list="lista" max="10" min="0" step="1" onchange="updateTextInput(this.value);"/>
                                <asp:Label runat="server" ID="lblRange"></asp:Label>--%>
                             
                                <input type="range" name="rangeInput" min="0" max="10" step="1"   onchange="updateTextInput(this.value);" class="custom-range" />

                              
                            </div>
                        </div>
                     <div class="col-sm-12 col-md-4 col-lg-4"></div>
                     
                                        
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
                                <asp:Button runat="server" CssClass=" btn btn-default" ID="btnRegresar" Text="Regresar"  OnClick="Regresar"/>
                            </div>
                        </div>
                        </div>

                    <div class="row" runat="server" id="rowGrid" visible="false">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Datos de la evaluación</h4>
                        </div>
                    <div class="container col-12">
                     
                        <div class=" table-responsive">
                            <div style="overflow: auto; height: auto">
                                <asp:GridView ID="gridEvaluacion"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                    CssClass=" table table-striped table-sm"
                                    GridLines="Vertical"
                                    EmptyDataText="Sin registro de evaluación."
                                    DataKeyNames="Id_Evaluacion"
                                 OnRowCommand="gridEvaluacion_RowCommand"
                                 >
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="260px" ItemStyle-Width="260px" ControlStyle-Width="76px">
                                            <ItemTemplate>

                                               <asp:Button runat="server" Text="Ver" CssClass="btn btn-outline-primary" CommandName="Ver"/>

                                                <asp:Button runat="server" Text="Editar" CssClass="btn btn-outline-secondary" CommandName="Editar" />

                                                <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CantidadReactivos" HeaderText="Cantidad de reactivos"/>
                                        <asp:BoundField DataField="CalificacionMinima" HeaderText="Calificación mínima" />
                                        <asp:BoundField DataField="Estatus" HeaderText="Estatus" />


                                        

                                    </Columns>

                                </asp:GridView>

                            </div>

                        </div>
                    </div>
                            <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass=" btn btn-default" ID="btnRegresar2" Text="Regresar"  OnClick="Regresar"/>
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
                     document.getElementById("<%= btnRegresar2.ClientID %>").disabled = true;
                document.getElementById("<%= btnRegresar2.ClientID %>").value = "Cargando...";

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

       function updateTextInput(val) {
          document.getElementById("<%= txtRange2.ClientID %>").value=val; 
        }
            </script>  
</asp:Content>
