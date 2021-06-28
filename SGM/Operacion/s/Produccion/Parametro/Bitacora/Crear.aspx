<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="Operacion.s.Produccion.Parametro.Bitacora.Crear" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Crear bitácora de parametros de producción
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
      <li class="breadcrumb-item active"><a href="../Index.aspx">Parámetros de Producción</a></li>
                  <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="Regresar">Bitácora</asp:LinkButton></li>
                      <li class="breadcrumb-item active"><a>Crear</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
      <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Literal ID="litControl" runat="server"></asp:Literal>
            <div class="col-lg-12">
                  <div class="card" >
                      <div class="card-header">
                            <h4>Datos de la bitácora</h4>
                      </div>
                <div class="card-body">
                    <div class="row">
                         
                        <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Elasticidad:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtElasticidad" onkeypress="return isDecimalNumber(event,this);" MaxLength="10"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtElasticidad"
                                    ErrorMessage="Elasticidad requerida." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Velocidad:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtVelocidad" onkeypress="return isDecimalNumber(event,this);" MaxLength="10"></asp:TextBox>
                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtVelocidad"
                                    ErrorMessage="Velocidad requerida." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>


                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>No. Pasada:</label>
                         <asp:DropDownList CssClass="form-control "   runat="server" ID="ddl_NoPasada" DataTextField="Nombre" DataValueField="Id_Material"></asp:DropDownList>
                                   <asp:RequiredFieldValidator runat="server" ID="reqInstalacion" ControlToValidate="ddl_NoPasada"
                                    ErrorMessage="No. Pasada requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="col-sm-12 col-md-12 col-lg-4">
                                    <div class="form-group">
                                    <label class="font-weight-bold">Fecha:</label>
                                        <asp:TextBox runat="server" ID="txtFecha" class="form-control ml-1 " placeholder="dd-mm-yyyy" onkeydown="return false;"></asp:TextBox>

                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtFecha"

                                    ErrorMessage="Fecha requerida." ForeColor="Red"  ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                     
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFecha" ValidationGroup="btnGuardar" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                        ErrorMessage="Formato incorrecto de fecha." ForeColor="Red" ></asp:RegularExpressionValidator>
                                </div>
                              </div>

                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>No. Bandas:</label>
                               <asp:TextBox runat="server" CssClass="form-control" ID="txtBanda" onkeypress="return soloNumeros(event)" MaxLength="10"></asp:TextBox>
                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtBanda"
                                    ErrorMessage="No. Bandas requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Hora:</label>
                                <br />
                                   <telerik:RadTimePicker ID="txtHora" runat="server" TimeView-HeaderText="." DateInput-CssClass="form-control" Width="85px" 
                                   Culture="English (United States)"    DateInput-BorderColor="LightGray" Height="35px" DateInput-Font-Size="14px" ShowPopupOnFocus="true" TimePopupButton-Visible="false" TimeView-BorderStyle="None" ></telerik:RadTimePicker>
                                <br />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtHora"
                                    ErrorMessage="Hora requerida." ForeColor="Red"  ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                         
                        <div class="col-sm-12 col-md-12 col-lg-12">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"   ValidationGroup="btnGuardar"/>
                                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" OnClick="Regresar"/>
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
                document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
                    document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando...";
                     document.getElementById("<%= btnRegresar.ClientID %>").disabled = true;
                document.getElementById("<%= btnRegresar.ClientID %>").value = "Cargando...";


  }
  window.onbeforeunload = DisableButton;
                                      var count = 0;
        function isDecimalNumber(evt, c) {            
            var charCode = (evt.which) ? evt.which : event.keyCode;
            var dot1 = c.value.indexOf('.');
            var dot2 = c.value.lastIndexOf('.');
            if (c.value > 99999 && dot1 == -1 && charCode!=46) {
                return false;
            }
            if (dot1!= -1 && c.value.length - dot1 > 2) {
                return false;
            }
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            else if (charCode == 46 && (dot1 == dot2) && dot1 != -1 && dot2 != -1)
                return false;
            return true;
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

                                                    function soloNumeros(e){
  var key = window.event ? e.which : e.keyCode;
  if (key < 48 || key > 57) {
    e.preventDefault();
  }
}
            </script> 
</asp:Content>
