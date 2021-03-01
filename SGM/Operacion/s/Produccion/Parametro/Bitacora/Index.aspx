<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Operacion.s.Produccion.Parametro.Bitacora.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        Bitácora de parámetros de producción

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="../Index.aspx">    Parámetros de Producción</a></li>
    <li class="breadcrumb-item "><a>Bitácora</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
      <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Literal ID="litControl" runat="server"></asp:Literal>
            <div class="col-lg-12">
                <div class="row">
                          <div class="col-sm-12 col-md-12 col-lg-12">

                         <div class="card ">
                             <div class="card-header">
                                  <label class="font-weight-normal text-lg">Equipo: </label>
    <asp:Label runat="server" ID="lblEquipo" CssClass=" font-weight-bold text-lg"></asp:Label>
                             </div>
                    <div class="card-body">

                            <div class="row">
                                                                           <div class="col-sm-4 col-md-4 col-lg-8">

                                                                                                       <asp:LinkButton runat="server" CssClass="text-sm"  OnClick="CrearBitacora"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>

                                                                               </div>

                                                                          <div class=" input-group col-sm-8 col-md-8 col-lg-4">

                                                                              <asp:TextBox runat="server" ID="txtFecha" placeholder="Fecha"  CssClass="form-control  form-control-sm"></asp:TextBox>
                                <asp:Button ID="btnBuscar" Text="Consultar" runat="server" OnClick="Buscar" CssClass="btn btn-primary btn-sm" />
                                                                              </div>
                                                    <div class="container col-12">
                    <br />
                        <div class=" table-responsive">
                            <div style="overflow: auto; height: auto">
                                <asp:GridView ID="gridBitacora"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                    CssClass=" table table-bordered table-striped table-sm "
                                     HeaderStyle-BackColor="#343a40"
                                     HeaderStyle-CssClass=" text-white"
                                    GridLines="Horizontal"
                                    EmptyDataText="Sin registro de bitácoras."
                                    PageSize="10"
                                    DataKeyNames="Id_Parametro"
                                    OnPageIndexChanging="gridBitacora_PageIndexChanging"
                                    AllowCustomPaging="false"
                                    AllowPaging="true"
                                     HeaderStyle-HorizontalAlign="Center"
                                    
                                     OnRowCommand="gridBitacora_RowCommand">
                                    
                                    <Columns>
                                          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="180px" ItemStyle-Width="180px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                           
<%--                                                 <asp:Button runat="server" Text="Editar" CssClass="btn btn-outline-secondary" CommandName="Editar" />--%>
                                               <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                         <asp:BoundField HeaderText="Elasticidad" DataField="Elasticidad" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Velocidad" DataField="Velocidad" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField HeaderText="No. Pasada" DataField="NoPasada" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField HeaderText="Fecha" DataField="Fecha2" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Hora" DataField="Hora" ItemStyle-HorizontalAlign="Center"/>
                                     

                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" CssClass="" />

                                </asp:GridView>
                                <asp:Button runat="server" CssClass="btn btn-default" Text="Regresar" ID="btnRegresar" PostBackUrl="~/s/Produccion/Parametro/Index.aspx" />

                            </div>

                        </div>
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
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {

               

            $("#<%=txtFecha.ClientID%>").datepicker({

                dateFormat: 'dd-mm-yy',
                maxDate: '+0D',

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
                document.getElementById("<%= btnBuscar.ClientID %>").disabled = true;
                     document.getElementById("<%= btnBuscar.ClientID %>").value = "Cargando...";
                     document.getElementById("<%=btnRegresar.ClientID%>").disabled = true;
                     document.getElementById("<%=btnRegresar.ClientID%>").value = "Cargando...";


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
                || (keyEntry == 218) || (keyEntry >= 48 && keyEntry <= 57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64)
                return true;
            else {
                return false;
            }
        }
            </script>
</asp:Content>
