<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SASISOPA.s.RequisitoLegal.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    3. Requisitos Legales
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
       <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
           <li class="breadcrumb-item "><a href="../Inicio.aspx">SASISOPA (Inicio)</a></li>

    <li class="breadcrumb-item "><a>3. Requisitos Legales</a></li>
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
                                                        <div class="col-sm-12 col-md-12 col-lg-12" runat="server" id="lnkRegulador" visible="true">
                                                            
                        <a href="Regulador/Index.aspx" >Regulador <i class="fas fa-arrow-circle-right"></i></a>
                                                            </div>

                                                        <div class="col-sm-12 col-md-12 col-lg-12 mt-2" runat="server" id="lnkDocRegulador" visible="true">
                                                                                                                    <a href="DocRegulador/Index.aspx" >Documento Regulador <i class="fas fa-arrow-circle-right"></i></a><br />

                                                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12 mt-2" runat="server" id="lnkRequisito" visible="true">
                                
                        <a href="Requisito/Index.aspx" >Requisito <i class="fas fa-arrow-circle-right"></i></a>

                            </div>
                             <div class="col-sm-12 col-md-12 col-lg-12 mt-2" runat="server" id="Div1" visible="true">
                                                            
                        <a href="MatrizReqIns/Index.aspx" >Matriz Requisitos-Instalación  <i class="fas fa-arrow-circle-right"></i></a>
                                                            </div>
                        </div>



                   
                    </div>

             
                </div>

            </div>
            
               <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="controlrequisito" visible="true">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Control de Requisitos</h3>

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
                                    <asp:Label runat="server" ID="Label10"></asp:Label><label class="font-weight-normal">  </label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>

                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <p>
                                    <asp:Label runat="server" ID="Label11"></asp:Label>
                                    

                                    <asp:Label runat="server" ID="Label12"></asp:Label></p>

                            </div>
                        </div>



                        <div class="progress">
                            <div class="progress-bar" runat="server" id="div3">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="#" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

                  <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="regulador" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Regulador</h3>

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
                        <a href="Regulador/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
                      <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="documentoregulador" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Documento Regulador</h3>

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
                                    <asp:Label runat="server" ID="Label4"></asp:Label><label class="font-weight-normal">  </label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>

                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <p>
                                    <asp:Label runat="server" ID="Label5"></asp:Label>
                                    

                                    <asp:Label runat="server" ID="Label6"></asp:Label></p>

                            </div>
                        </div>



                        <div class="progress">
                            <div class="progress-bar" runat="server" id="div4">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="DocRegulador/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
                       <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="requisito" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Requisito</h3>

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
                                    <asp:Label runat="server" ID="Label7"></asp:Label><label class="font-weight-normal">  </label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>

                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <p>
                                    <asp:Label runat="server" ID="Label8"></asp:Label>
                                    

                                    <asp:Label runat="server" ID="Label9"></asp:Label></p>

                            </div>
                        </div>



                        <div class="progress">
                            <div class="progress-bar" runat="server" id="div6">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="Requisito/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
            </div>

           </div>
</asp:Content>
