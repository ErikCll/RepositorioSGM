<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Operacion.s.Infraestructura.Disponibilidad.Bitacora.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     Crear bitácora
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="../Index.aspx">Disponibilidad de equipos</a></li>
                  <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="Regresar">Bitácora</asp:LinkButton></li>
                      <li class="breadcrumb-item active"><a>Editar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
      <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
            <div class="col-lg-12">
                  <div class="card" >
                      <div class="card-header">
                                                      <h4>Datos de la bitácora</h4>

                      </div>
                <div class="card-body">
                    <div class="row">
                           
                            <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Tipo de falla:</label>
                                <asp:DropDownList CssClass="form-control"  runat="server" ID="ddl_TipoFalla" DataTextField="Nombre" DataValueField="Id_Falla" AutoPostBack="true" OnSelectedIndexChanged="ddl_TipoFalla_SelectedIndexChanged"></asp:DropDownList>
                                   <asp:RequiredFieldValidator runat="server" ID="reqTipoFalla" ControlToValidate="ddl_TipoFalla"
                                    ErrorMessage="Tipo de falla requerida." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>

                            </div>
                        </div>

                              <div class="col-sm-12 col-md-12 col-lg-4" runat="server" id="divInformacion">
                                      <asp:GridView ID="gridDescripcion"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                    CssClass=" table table-bordered table-striped table-sm "
                                     HeaderStyle-CssClass=" bg-white"
                                    GridLines="Horizontal"
                                    EmptyDataText="Sin registro de descripción."
                                    PageSize="10"
                                    DataKeyNames="Id_Falla"                                                              
                                     HeaderStyle-HorizontalAlign="Center">                                                                    
                                   <Columns>
                                      

                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                    
                                    </Columns>

                                </asp:GridView>
                              </div>
                    
                        


                       <div class="col-sm-12 col-md-12 col-lg-4" runat="server" id="divDescripcion" visible="false">
                            <div class="form-group">
                                <label class="font-weight-bold">Descripción:</label>


                                <textarea runat="server" class="form-control" onkeypress="return AllowAlphabet(event)"  maxlength="200" id="txtDesc"></textarea>
                                <asp:RequiredFieldValidator runat="server" ID="reqDescripcion" ControlToValidate="txtDesc"
                                    ErrorMessage="Descripción requerida." ForeColor="Red"  ValidationGroup="btnGuardar" Enabled="false"></asp:RequiredFieldValidator>


                            </div>
                        </div>

                        <div class="col-sm-12 col-md-12 col-lg-12"></div>
                           <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                          
                            <div class="form-group">
                                <asp:Button class="btn btn-primary" id="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" OnClick="btnGuardar_Click" />

                                <asp:Button runat="server" ID="btnRegresar2" CssClass="btn btn-default" Text="Regresar" OnClick="Regresar" />


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

                               
                     
          

              });

                 function DisableButton() {
                document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
                     document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando...";
                     document.getElementById("<%=btnRegresar2.ClientID%>").disabled = true;
                     document.getElementById("<%=btnRegresar2.ClientID%>").value = "Cargando...";


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

                                  function soloNumeros(e){
  var key = window.event ? e.which : e.keyCode;
  if (key < 48 || key > 57) {
    e.preventDefault();
  }
}
              </script>  


                      
</asp:Content>
