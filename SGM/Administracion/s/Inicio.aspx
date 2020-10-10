<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Administracion.s.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
    <li class="breadcrumb-item "><a>Administración</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div class="col-lg-12">
        <div class="row">
            <div class="col-sm-12 col-md-6 col-lg-4">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Control de asistencia</h3>

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
                                    <asp:Label runat="server" ID="lblPorcentaje" Text="83"></asp:Label><label class="font-weight-normal">%</label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>
                            <%--    <div class="col-sm-12 col-md-12 col-lg-3 float-right">
                      <div class="col-auto float-right">
                            <i class="fas fa-fw fa-tachometer-alt fa-4x text-black-50"></i>
                        </div>  
                  </div>--%>
                        </div>




                        <div class="progress">
                            <div class="progress-bar" runat="server" id="divprogress1" style="width: 80%">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="Personal/ControlAsist/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>


            <div class="col-sm-12 col-md-6 col-lg-4">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Almacén</h3>

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
                                   Total en almacén: <label class="font-weight-normal"></label>
                                    <br />
                                    $<asp:Label runat="server" ID="lblTotal" ></asp:Label>
                                </h3>

                            </div>


                        </div>




                        
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="Almacen/InventarioMaterial/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
