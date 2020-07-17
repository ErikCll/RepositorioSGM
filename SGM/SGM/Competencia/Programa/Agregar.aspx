
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="SGM.Competencia.Programa.Agregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Programar evaluación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="Index.aspx">Programa de capacitación</a></li>
      <li class="breadcrumb-item active"><a href="Detalle.aspx">Programa de evaluaciones</a></li>
                  <li class="breadcrumb-item "><a>Programar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
            <div class="col-lg-12">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Datos de la programación</h4>
                        </div>
                     
                     
                        <div class="col-sm-12 col-md-12 col-lg-4">
                             <div class="form-group">
                                    <label class="font-weight-bold">Fecha de evaluación:</label>
                                        <asp:TextBox runat="server" ID="txtFecha" class="form-control ml-1 " placeholder="dd-mm-yyyy" onkeydown="return false;"></asp:TextBox>
                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtFecha"
                                    ErrorMessage="Fecha de evaluación requerida." ForeColor="Red"  ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                     
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFecha" ValidationGroup="btnGuardar" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                        ErrorMessage="Formato incorrecto de fecha." ForeColor="Red" ></asp:RegularExpressionValidator>
                                </div>
                           
                                  
                        </div>
                     <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Empleado:</label>
                     <asp:DropDownList CssClass="form-control "  runat="server" ID="ddl_Empleado" DataTextField="Empleado" DataValueField="Id_Empleado"></asp:DropDownList>
                                   <asp:RequiredFieldValidator runat="server" ID="reqEmpleado" ControlToValidate="ddl_Empleado"
                                    ErrorMessage="Empleado requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>


                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                          
                            <div class="form-group">
                                <asp:Button class="btn btn-primary" id="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" OnClick="btnGuardar_Click" />
                                
                                <asp:Button runat="server" PostBackUrl="~/Competencia/Programa/Detalle.aspx" CssClass="btn btn-default" ID="btnRegresar2" Text="Regresar" />

                            </div>
                        </div>
                       
                 
                        </div>

                         <div class="row" runat="server" >
                        
                    <div class="container col-12">
                     
                        <div class=" table-responsive">
                            <div style="overflow: auto; height: auto">
                                <asp:GridView ID="gridPrograma"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                    CssClass=" table table-striped table-sm"
                                    GridLines="Vertical"
                                    EmptyDataText="Sin registro de evaluaciones programadas."
                                    DataKeyNames="Id_Programa"
                                     OnRowDataBound="gridPrograma_RowDataBound"
                                     OnRowCommand="gridPrograma_RowCommand"
                         
                                 >
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="260px" ItemStyle-Width="260px" ControlStyle-Width="76px">
                                            <ItemTemplate>

                                               <asp:Button runat="server" Text="Ver" CssClass="btn btn-outline-primary" CommandName="Ver"/>

                                                <asp:Button runat="server" Text="Editar" CssClass="btn btn-outline-secondary" CommandName="Editar" ID="btnEditar" />

                                                <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Empleado" HeaderText="Empleado"/>
                                        <asp:BoundField DataField="FechaEvaluacion" HeaderText="Fecha de evaluación" />
                                         <asp:BoundField DataField="FechaRealizado" HeaderText="Fecha de realización" />
                                        <asp:BoundField DataField="Estatus" HeaderText="Estatus" /> 

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblEstatus" Text='<%# Eval("IntEstatus") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        

                                    </Columns>

                                </asp:GridView>

                            </div>

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
  
                             Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(){

            
               
                   $("#<%=txtFecha.ClientID%>").datepicker({
                        dateFormat: 'dd-mm-yy',
                       minDate:'+1D',
                     
                        changeMonth: true,
                        changeYear: true,
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo',
                            'Junio', 'Julio', 'Agosto', 'Septiembre',
                            'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr',
                            'May', 'Jun', 'Jul', 'Ago',
                            'Sep', 'Oct', 'Nov', 'Dic']
                  });

              });

                 function DisableButton() {
                document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
                     document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando...";
                     document.getElementById("<%=btnRegresar2.ClientID%>").disabled = true;
                     document.getElementById("<%=btnRegresar2.ClientID%>").value = "Cargando...";


  }
  window.onbeforeunload = DisableButton;

               

                                  function soloNumeros(e){
  var key = window.event ? e.which : e.keyCode;
  if (key < 48 || key > 57) {
    e.preventDefault();
  }
}
              </script>  
</asp:Content>
