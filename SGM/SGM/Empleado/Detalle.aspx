<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SGM.Empleado.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Detalle Empleado
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="Index.aspx">Empleado</a></li>
                  <li class="breadcrumb-item "><a>Detalle</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
        <div class="col-lg-12">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Nombre:</label>
                                <asp:Label runat="server" CssClass="font-weight-bold" ID="lblNombre"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label class="font-weight-normal">Apellido Paterno:</label>
                                 <asp:Label runat="server" CssClass="font-weight-bold" ID="lblApellidoPaterno"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label class="font-weight-normal">Apellido Materno:</label>
                                 <asp:Label runat="server" CssClass="font-weight-bold" ID="lblApellidoMaterno"></asp:Label>
                            </div>
                            <div class="form-group">
                                 <label class="font-weight-normal">Fecha de creación:</label>
                                <asp:Label runat="server" ID="lblCreacionFecha" CssClass=" font-weight-bold"></asp:Label>
                            </div>
                            </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Instalación:</label>
                                <asp:Label runat="server" ID="lblInstalacion" CssClass=" font-weight-bold"></asp:Label>
                            </div>

                            
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                        </div>
                      
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                               
                                <a class="btn btn-default" href="Index.aspx">Regresar</a>
                            </div>
                        </div>
                        </div>
                    </div>
                      </div>
        </div>
</asp:Content>
