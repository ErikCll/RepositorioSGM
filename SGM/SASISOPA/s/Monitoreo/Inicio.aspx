﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SASISOPA.s.Monitoreo.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    14. Monitoreo, Verificación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
           <li class="breadcrumb-item "><a href="../Inicio.aspx">SASISOPA (Inicio)</a></li>

    <li class="breadcrumb-item "><a>14. Monitoreo, Verificación</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
        <div class="col-lg-12">
        <div class="row">
                 <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="configuracion" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header bg-gray">
                        <h3 class="card-title font-weight-bold ">Configuración del elemento</h3>

                        <div class="card-tools">
                                <i class="fas fa-cog"></i>
                        </div>
                    </div>
                    <div class="card-body " style="display: block;">
                        <div class="row">               
                         
                        </div>
                        </div>

                    </div>
                          
                    </div>
                  <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="Div1" visible="true">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Reuniones y acuerdos</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label1"></asp:Label><label class="font-weight-normal">  </label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>

                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <p>
                                    <asp:Label runat="server" ID="Label2"></asp:Label>
                                    

                                    <asp:Label runat="server" ID="Label3"></asp:Label></p>

                            </div>
                        </div>



                        <div class="progress">
                            <div class="progress-bar" runat="server" id="div2">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="#" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
            </div>

           </div>
</asp:Content>
