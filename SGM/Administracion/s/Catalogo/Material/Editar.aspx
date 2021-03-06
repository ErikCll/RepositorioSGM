﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Administracion.s.Catalogo.Material.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Editar material
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="Index.aspx">Material</a></li>
                  <li class="breadcrumb-item "><a>Editar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
       <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
                                                            <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-lg-12">
                  <div class="card" >
                      <div class="card-header">
                            <h4>Datos del material</h4>

                      </div>
                <div class="card-body">
                    <div class="row">
                       
                        <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Nombre:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre de material requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     
                              <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Código:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigo" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtCodigo"
                                    ErrorMessage="Código requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                          <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Número de parte:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtNumParte" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtNumParte"
                                    ErrorMessage="Número de parte requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        
                         <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Tipo de unidad:</label>
                                <asp:DropDownList runat="server" ID="ddl_TipoUnidad" CssClass="form-control" ></asp:DropDownList>
                                 <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ddl_TipoUnidad"
                                    ErrorMessage="Tipo de unidad requerido." ForeColor="Red" ValidationGroup="btnGuardar" InitialValue="[Seleccionar]"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-2">
                            <div class="form-group">
                                <label>Costo:</label>
                                 <asp:TextBox ID="txtCosto" runat="server" CssClass="form-control" onkeypress="return isDecimalNumber(event,this);" MaxLength="11" placeholder="$">
                </asp:TextBox>  
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtCosto"
                                    ErrorMessage="Costo requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-12"></div>
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
                                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" PostBackUrl="~/s/Catalogo/Material/Index.aspx" />
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
            </script>  
</asp:Content>
