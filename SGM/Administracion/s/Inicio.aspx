<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Administracion.s.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Administración
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
    <li class="breadcrumb-item "><a>Administración</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div class="col-lg-12">
        <div class="row">
                <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="catalogo" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Catálogo</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                   Material: <%--<label class="font-weight-normal"></label>
                                    <label class="font-weight-bold">$</label><asp:Label runat="server" ID="Label1" CssClass="font-weight-bold" ></asp:Label>--%>

                            </div>


                        </div>




                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="Almacen/InventarioMaterial/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            <%--</div>--%>
            <div class="col-sm-12 col-md-6 col-lg-4" runat="server" visible="false" id="personal">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Personal</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-8 col-md-8 col-lg-8">
                                  <label class="font-weight-normal">Control de asistencia:</label>  <asp:Label runat="server" ID="lblPorcentaje" Text="83" CssClass="font-weight-bold ml-1"></asp:Label><label class="font-weight-bold">%</label>

                            </div>
                            <%--    <div class="col-sm-12 col-md-12 col-lg-3 float-right">
                      <div class="col-auto float-right">
                            <i class="fas fa-fw fa-tachometer-alt fa-4x text-black-50"></i>
                        </div>  
                  </div>--%>

                              <div class="col-sm-4 col-md-4 col-lg-4 mt-1">
                                                                                <div class="progress">
                            <div class="progress-bar" runat="server" id="divprogress1" style="width: 80%">
                            </div>
                        </div>
                                                                              </div>
                        </div>



                                                                        
                      
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="Personal/ControlAsist/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>


            <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="almacen" visible="false">
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
                                   Inventario de material: <label class="font-weight-normal"></label>
                                    <label class="font-weight-bold">$</label><asp:Label runat="server" ID="lblTotal" CssClass="font-weight-bold" ></asp:Label>

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
