﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SGM.s.Competencia.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Competencia y formación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
      <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
           <li class="breadcrumb-item "><a href="../Inicio.aspx">SGM (Inicio)</a></li>

    <li class="breadcrumb-item "><a>Competencia y formación</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <div class="col-lg-12">
        <div class="row">
                <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="censoact" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold"> Censo de actividad </h3>

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
                                    <asp:Label runat="server" ID="lblPorcentaje"></asp:Label><label class="font-weight-normal">  </label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>


                            <div class="col-sm-12 col-md-12 col-lg-12">
                            <%--    <p>
                                    <asp:Label runat="server" ID="lblOperando"></asp:Label>
                                    de
                                    <asp:Label runat="server" ID="lblTotal"></asp:Label></p>--%>

                            </div>
                        </div>


                        <div class="progress">
                            <div class="progress-bar" runat="server" id="divprogress1">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="CensoAct/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
              <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="categoriaactividad" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Matriz Categoría-Actividad</h3>

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
                            <%--    <p>
                                    <asp:Label runat="server" ID="lblOperando"></asp:Label>
                                    de
                                    <asp:Label runat="server" ID="lblTotal"></asp:Label></p>--%>

                            </div>
                        </div>


                        <div class="progress">
                            <div class="progress-bar" runat="server" id="div2">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="MatrizCatAct/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

              <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="categoriaempleado" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Matriz Categoría-Empleado</h3>

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
                                    <asp:Label runat="server" ID="Label2"></asp:Label><label class="font-weight-normal">  </label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>


                            <div class="col-sm-12 col-md-12 col-lg-12">
                            <%--    <p>
                                    <asp:Label runat="server" ID="lblOperando"></asp:Label>
                                    de
                                    <asp:Label runat="server" ID="lblTotal"></asp:Label></p>--%>

                            </div>
                        </div>


                        <div class="progress">
                            <div class="progress-bar" runat="server" id="div3">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="MatrizCatEmp/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
                <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="programacapacitacion" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Programa de capacitación</h3>

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
                                    <asp:Label runat="server" ID="Label3"></asp:Label><label class="font-weight-normal">  </label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>


                            <div class="col-sm-12 col-md-12 col-lg-12">
                            <%--    <p>
                                    <asp:Label runat="server" ID="lblOperando"></asp:Label>
                                    de
                                    <asp:Label runat="server" ID="lblTotal"></asp:Label></p>--%>

                            </div>
                        </div>


                        <div class="progress">
                            <div class="progress-bar" runat="server" id="div4">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="Programa/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
            </div>


        </div>
</asp:Content>
