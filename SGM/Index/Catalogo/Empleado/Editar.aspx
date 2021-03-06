﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="SAM.Catalogo.Empleado.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Editar Empleado
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="Index.aspx">Empleado</a></li>
                  <li class="breadcrumb-item "><a>Editar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
      <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
              <asp:Literal ID="litControl" runat="server"></asp:Literal>
            <div class="col-lg-12">
                  <div class="card" >
                      <div class=" card-header">
                         <h4>Datos del empleado</h4>

                      </div>
                <div class="card-body">
                    <div class="row">
                        
       
      <div class="col-12 col-md-12 col-lg-4">
                                <div class="form-group">
                                <label>No. Empleado:</label>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNoEmpleado" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtNoEmpleado"
                                    ErrorMessage="No. de empleado requerido." ForeColor="Red" ValidationGroup="btnGuardar" Enabled="false"></asp:RequiredFieldValidator>
                            </div>
                             <div class="form-group">
                              
                                <label>Instalación:</label>
                                <asp:DropDownList CssClass="form-control "   runat="server" ID="ddl_Instalacion" DataTextField="Nombre" DataValueField="Id_Instalacion"></asp:DropDownList>
                                   <asp:RequiredFieldValidator runat="server" ID="reqInstalacion" ControlToValidate="ddl_Instalacion"
                                    ErrorMessage="Instalación requerida." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                                       <div class="form-group">
                                <label>Dirección:</label>
                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtDireccion" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                  
                            </div>
                       
                         
                        </div>
                     
                         <div class="col-sm-12 col-md-4 col-lg-4">
                                  <div class="form-group">
                                <label>Nombre:</label>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre de empleado requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Apellido Paterno:</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidoPaterno" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtApellidoPaterno"
                                    ErrorMessage="Apellido Paterno requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                                <div class="form-group">
                                <label>Apellido Materno:</label>
                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidoMaterno" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                  
                            </div>
                            
                      
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                                      <div class="form-group">
                              
                                <label>Sexo:</label>
                                <asp:DropDownList CssClass="form-control "   runat="server" ID="ddl_Sexo"></asp:DropDownList>
                                   <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ddl_Sexo"
                                    ErrorMessage="Sexo requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                                    <div class="form-group">
                                    <label class="font-weight-bold">Fecha de nacimiento:</label>
                                        <asp:TextBox runat="server" ID="txtFecha" class="form-control ml-1 " placeholder="dd-mm-yyyy" onkeydown="return false;"></asp:TextBox>
                                      <%--   <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtFecha"
                                    ErrorMessage="Fecha de nacimiento requerida." ForeColor="Red"  ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>--%>
                                     
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFecha" ValidationGroup="btnGuardar" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                        ErrorMessage="Formato incorrecto de fecha." ForeColor="Red" ></asp:RegularExpressionValidator>
                                </div>
                       
                                 
                        </div>
                  
                          
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
                                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" PostBackUrl="~/Catalogo/Empleado/Index.aspx"/>
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
