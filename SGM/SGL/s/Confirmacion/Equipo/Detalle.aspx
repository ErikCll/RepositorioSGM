﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SGL.s.Confirmacion.Equipo.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        Detalle Censo de Equipo o Instrumento
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    
       <li class="breadcrumb-item active"><a href="Index.aspx">Censo de Equipos e Instrumentos</a></li>
                  <li class="breadcrumb-item "><a>Detalle</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Literal ID="litControl" runat="server"></asp:Literal>
            <div class="col-lg-12">
                  <div class="card" >
                      <div class="card-header">
                            <h4>Datos del censo de equipo o instrumento</h4>
                      </div>
                <div class="card-body">
                    <div class="row">
                         
                        <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Nombre:</label>
                                         <asp:Label runat="server" CssClass="font-weight-bold" ID="lblNombre"></asp:Label>
                            </div>
                        </div>

                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Marca:</label>
                                         <asp:Label runat="server" CssClass="font-weight-bold" ID="lblMarca"></asp:Label>
                            </div>
                        </div>


                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Modelo:</label>
                                         <asp:Label runat="server" CssClass="font-weight-bold" ID="lblModelo"></asp:Label>
                            </div>
                        </div>

                        
                         <div class="col-sm-12 col-md-4 col-lg-4">
                            <div class="form-group">
                              
                                <label class="font-weight-normal">Tipo:</label>
                               <asp:Label runat="server" CssClass="font-weight-bold" ID="lblTipo"></asp:Label>
                            </div>
                        </div>

                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">No. Inventario:</label>
                                         <asp:Label runat="server" CssClass="font-weight-bold" ID="lblNoInventario"></asp:Label>
                            </div>
                        </div>
                     
                         <div class="col-sm-12 col-md-4 col-lg-4">
                            <div class="form-group">
                              
                                     <label class="font-weight-normal">Serie:</label>
                                      <asp:Label runat="server" CssClass="font-weight-bold" ID="lblSerie"></asp:Label>
                            </div>
                        </div>

                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Prueba:</label>
                                          <asp:Label runat="server" CssClass="font-weight-bold" ID="lblPrueba"></asp:Label>
                            </div>
                        </div>

                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Instalación:</label>
                        <asp:Label runat="server" CssClass="font-weight-bold" ID="lblInstalacion"></asp:Label>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-8">

                        </div>
                  
                         
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" PostBackUrl="~/s/Confirmacion/Equipo/Index.aspx" />
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
