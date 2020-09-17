<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Operacion.s.Produccion.Resumen.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Detalle horas de producción
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="Index.aspx">Resumen mensual</a></li>
    <li class="breadcrumb-item "><a>Detalle</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
  <asp:UpdatePanel runat="server" UpdateMode="Conditional">

        <ContentTemplate>
                                    <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-lg-12">
                <div class="row">
                     <div class="col-sm-12 col-md-12 col-lg-12">

                         <div class="card ">
                    <div class="card-body">

                            <div class="row">
                                  <div class="input-group col-sm-3 col-md-3 col-lg-3">

                                  <asp:TextBox runat="server" ID="txtFecha" placeholder="dd-mm-yyyy" onkeydown="return false;" CssClass="form-control  form-control-sm"></asp:TextBox>
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnConsultar" Text="Consultar" runat="server" OnClick="Buscar"/>


                    </div>

                                <div class="col-sm-5 col-md-5 col-lg-5"></div>
                                    <div class="input-group col-sm-4 col-md-4 col-lg-4 float-right">
              
            </div>


                                 <div class="container col-12">
                        
                                     <br />
                     

<%--                       <asp:LinkButton runat="server" CssClass="text-sm" PostBackUrl="~/s/Catalogo/Medidor/Crear.aspx"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>--%>
                  
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-bordered table-striped table-sm"
                               HeaderStyle-CssClass="bg-white"
                                    GridLines="Horizontal"                                  
                                    id="gridHora"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registros."
                                     PageSize="10"
                                     OnPageIndexChanging="gridHora_PageIndexChanging"
                                     AllowPaging="true"
                                     DataKeyNames="Id_Equipo"
                                     HeaderStyle-HorizontalAlign="Center"
                                    >
                                    <Columns>         
                                                    <asp:BoundField HeaderText="Equipo" DataField="Equipo"/>  
                                                     <asp:BoundField HeaderText="Fecha" DataField="Fecha" ItemStyle-HorizontalAlign="Center"  />
                                        <asp:BoundField HeaderText="Turno 1" DataField="Turno1" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Turno 2" DataField="Turno2" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Turno 3" DataField="Turno3" ItemStyle-HorizontalAlign="Center" />
                                        

                                    </Columns>
                                            <PagerStyle HorizontalAlign = "Center" CssClass="" />
                                </asp:GridView>
                                                                <asp:Button runat="server" CssClass="btn btn-default" Text="Regresar" ID="btnRegresar" PostBackUrl="~/s/Produccion/Resumen/Index.aspx" />

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
                document.getElementById("<%= btnConsultar.ClientID %>").disabled = true;
                     document.getElementById("<%= btnConsultar.ClientID %>").value = "Cargando...";
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
