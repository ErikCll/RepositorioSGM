﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SGM.Catalogo.Categoria.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Detalle Categoría
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="Index.aspx">Categoría</a></li>
                  <li class="breadcrumb-item "><a>Detalle</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <div class="col-lg-12">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Datos de la categoría</h4>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Nombre:</label>
                                <asp:Label runat="server" CssClass="font-weight-bold" ID="lblNombre"></asp:Label>
                            </div>
                            </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-normal">Área:</label>
                                <asp:Label runat="server" ID="lblArea" CssClass=" font-weight-bold"></asp:Label>
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