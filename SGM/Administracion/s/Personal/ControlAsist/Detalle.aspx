<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Administracion.s.Personal.ControlAsist.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      Detalle control de asistencia<br />
    <label class="font-weight-normal text small">Empleado: </label>
    <asp:Label runat="server" ID="lblEmpleado" CssClass=" font-weight-bold text small"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="Index.aspx">Control de asistencia</a></li>
                  <li class="breadcrumb-item "><a>Detalle</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <asp:UpdatePanel runat="server" UpdateMode="Conditional">

        <ContentTemplate>
                                    <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-lg-12">
                <div class="row">

                    <div class="col-sm-3 col-md-3 col-lg-3">
                         <div class="form-inline">
                             <label >Fecha inicial:</label>
                             <asp:TextBox runat="server" CssClass="form-control form-control-sm ml-1" ID="txtFechaInicial"  placeholder="dd-mm-yyyy" onkeydown="return false;"></asp:TextBox>
                             <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFechaInicial" ValidationGroup="btnConsultar"
                                 ErrorMessage="Ingresar fecha inicial." ForeColor="Red" ></asp:RequiredFieldValidator>

                         </div>
                    </div>
                             
                         <div class="col-sm-3 col-md-3 col-lg-3">
                         <div class="form-inline">
                             <label>Fecha final:</label>
                             <asp:TextBox runat="server" CssClass="form-control form-control-sm ml-1" ID="txtFechaFinal"  placeholder="dd-mm-yyyy" onkeydown="return false;"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFechaFinal" ValidationGroup="btnConsultar"
                                 ErrorMessage="Ingresar fecha final." ForeColor="Red" ></asp:RequiredFieldValidator>
                         </div>
                    </div>
               
                    <div class="col-sm-2 col-md-2 col-lg-2">
                    </div>
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="form-group">
                       <asp:Button  runat="server" CssClass="btn btn-primary" Text="Consultar" ID="btnConsultar" ValidationGroup="btnConsultar" OnClick="btnConsultar_Click" />
                            <asp:Button runat="server" Text="Regresar" ID="btnRegresar" PostBackUrl="~/s/Personal/ControlAsist/Index.aspx" CssClass="btn btn-default" />
                        </div>
                    </div>
                    <div class="container col-12">
                        

                     

<%--                       <asp:LinkButton runat="server" CssClass="text-sm" PostBackUrl="~/s/Catalogo/Medidor/Crear.aspx"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>--%>
                  
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-striped table-sm border-light"
                                   GridLines="Vertical"
                                   id="gridAsistenciaEmpleado"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de asistencias."
                                     PageSize="10"
                                     OnPageIndexChanging="gridAsistenciaEmpleado_PageIndexChanging"
                                     AllowPaging="true"
                                     DataKeyNames="UserId"
                                    >
                                    <Columns>         
                                                                           
                                         <asp:BoundField HeaderText="Fecha" DataField="Fecha" ItemStyle-HorizontalAlign="Center" />
                                         <asp:BoundField HeaderText="Entrada" DataField="Entrada" ItemStyle-HorizontalAlign="Center"  />
                                       <asp:BoundField HeaderText="Salida" DataField="Salida" ItemStyle-HorizontalAlign="Center"  />

                                    </Columns>
                                            <PagerStyle HorizontalAlign = "Center" CssClass="" />
                                </asp:GridView>
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



               $("#<%=txtFechaInicial.ClientID%>").datepicker({
                        
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

                       $("#<%=txtFechaFinal.ClientID%>").datepicker({
                        
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
