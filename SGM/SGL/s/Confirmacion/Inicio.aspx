<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SGL.s.Confirmacion.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
Confirmación metrológica

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
         <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
           <li class="breadcrumb-item "><a href="../Inicio.aspx">SGL (Inicio)</a></li>

    <li class="breadcrumb-item "><a>Confirmación metrológica</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div class="col-lg-12">
        <div class="row">
                 <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="configuracion" visible="true">
                <div class="card card-default shadow-sm">
                    <div class="card-header bg-gray">
                        <h3 class="card-title font-weight-bold ">Configuración del elemento</h3>

                        <div class="card-tools">
                                <i class="fas fa-cog"></i>
                        </div>
                    </div>
                    <div class="card-body " style="display: block;">
                        <div class="row">
                                                                                    <div class="col-sm-12 col-md-12 col-lg-12" runat="server" id="Div7" visible="true">
                                                                     <a href="Variable/Index.aspx" >Variables físicas (Magnitud) <i class="fas fa-arrow-circle-right"></i></a>

                     </div>     

                                                        <div class="col-sm-12 col-md-12 col-lg-12 mt-2" runat="server" id="lnkMedidor" visible="true">
                                                            
                        <a href="Medidor/Index.aspx" >Equipos e Instrumentos de Medición <i class="fas fa-arrow-circle-right"></i></a>
                                                            </div>

                                                                                                                                 <div class="col-sm-12 col-md-12 col-lg-12 mt-2" runat="server" id="Div8" visible="true">
                                                                     <a href="Criterio/Index.aspx" >Criterios de Aceptación <i class="fas fa-arrow-circle-right"></i></a>


</div>
                         
                        </div>



                   
                    </div>

             
                </div>

            </div>

                <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="medidor" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Equipos e Instrumentos de Medición </h3>

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
                        <a href="Medidor/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
                <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="Div1" visible="true">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Censo de Equipos e Instrumentos </h3>

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
                        <a href="Equipo/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
    <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="Div3" visible="true">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Verificaciones </h3>

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
                            <div class="progress-bar" runat="server" id="div4">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="Verificacion/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
    <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="Div5" visible="true">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Calibraciones </h3>

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
                            <div class="progress-bar" runat="server" id="div6">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="Calibracion/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

            </div>


        </div>
</asp:Content>
