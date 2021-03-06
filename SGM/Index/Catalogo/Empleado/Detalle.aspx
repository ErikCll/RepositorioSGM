﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SAM.Catalogo.Empleado.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Detalle Empleado
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="Index.aspx">Empleado</a></li>
                  <li class="breadcrumb-item "><a>Detalle</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
        <div class="col-lg-12">
                  <div class="card"  >
                      <div class="card-header">
                            <h4>Datos del empleado</h4>
                      </div>
                <div class="card-body">

                    <div class="row">
                      
                        <div class="col-sm-12 col-md-12 col-lg-4">
                                <div class="form-group">
                                <label class="font-weight-normal">No. Empleado:</label>
                                <asp:Label runat="server" CssClass="font-weight-bold" ID="lblNoEmpleado"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="font-weight-normal">Nombre:</label>
                                <asp:Label runat="server" CssClass="font-weight-bold" ID="lblNombre"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label class="font-weight-normal">Apellido Paterno:</label>
                                 <asp:Label runat="server" CssClass="font-weight-bold" ID="lblApellidoPaterno"></asp:Label>
                            </div>
                         
                       
                            </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                               <div class="form-group">
                                <label class="font-weight-normal">Apellido Materno:</label>
                                 <asp:Label runat="server" CssClass="font-weight-bold" ID="lblApellidoMaterno"></asp:Label>
                            </div>
                               <div class="form-group">
                                <label class="font-weight-normal">Sexo:</label>
                                 <asp:Label runat="server" CssClass="font-weight-bold" ID="lblSexo"></asp:Label>
                            </div>
                              <div class="form-group">
                                <label class="font-weight-normal">Fecha de nacimiento:</label>
                                 <asp:Label runat="server" CssClass="font-weight-bold" ID="lblFechaNacimiento"></asp:Label>
                            </div>

                            
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                                  <div class="form-group">
                                <label class="font-weight-normal">Dirección:</label>
                                <asp:Label runat="server" ID="lblDireccion" CssClass=" font-weight-bold"></asp:Label>
                            </div>
                                <div class="form-group">
                                <label class="font-weight-normal">Instalación:</label>
                                <asp:Label runat="server" ID="lblInstalacion" CssClass=" font-weight-bold"></asp:Label>
                            </div>

                                 <div class="form-group">
                                 <label class="font-weight-normal">Fecha de creación:</label>
                                <asp:Label runat="server" ID="lblCreacionFecha" CssClass=" font-weight-bold"></asp:Label>
                            </div>
                        </div>
                      
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                               
                                <asp:Button runat="server" class="btn btn-default" Text="Regresar" PostBackUrl="~/Catalogo/Empleado/Index.aspx" ID="btnRegresar"/>
                            </div>
                        </div>
                        </div>
                    </div>
                      </div>
        </div>
       <script type="text/javascript">

              Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {



          });
                function DisableButton() {
             
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
