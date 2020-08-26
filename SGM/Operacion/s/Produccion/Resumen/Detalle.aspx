<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Operacion.s.Produccion.Resumen.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Detalle del resumen mensual
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
                    <div class="container col-12">
                        <div class="input-group float-right col-sm-4 col-md-4 col-lg-4">
                            <div class="input-group btn">
                                <asp:TextBox runat="server" ID="txtFecha" placeholder="Fecha de inicio"  CssClass="form-control  form-control-sm"></asp:TextBox>
                                <asp:Button ID="btnBuscar" Text="Consultar" runat="server" OnClick="Buscar" CssClass="btn btn-primary btn-sm" />
                            </div>
                        </div>
                        <div class=" table-responsive">
                            <div style="overflow: auto; height: auto">
                                <asp:GridView ID="gridResumen"
                                    runat="server"
                                    AutoGenerateColumns="true"
                                    CssClass=" table table-striped table-sm border-light"
                                    GridLines="Vertical"
                                    EmptyDataText="Sin registros."
                                    PageSize="10"
                                    OnPageIndexChanging="gridResumen_PageIndexChanging"
                                    AllowCustomPaging="false"
                                    AllowPaging="true"
                                     OnRowDataBound="gridResumen_RowDataBound">
                                   
                                  
                                    <PagerStyle HorizontalAlign="Center" CssClass="" />

                                </asp:GridView>
                                <asp:Button runat="server" CssClass="btn btn-default" Text="Regresar" ID="btnRegresar" PostBackUrl="~/s/Produccion/Resumen/Index.aspx" />


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
