﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SASISOPA.s.Competencia.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    6. Competencia y Formación
        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
        <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
           <li class="breadcrumb-item "><a href="../Inicio.aspx">SASISOPA (Inicio)</a></li>

    <li class="breadcrumb-item "><a>6. Competencia y Formación</a></li>
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


                                                        <div class="col-sm-12 col-md-12 col-lg-12" runat="server" id="lnkCursoTaller" visible="true">
                                                            
                        <a href="CursoTaller/Index.aspx" >Cursos y Talleres <i class="fas fa-arrow-circle-right"></i></a>
                                                            </div>
                               <div class="col-sm-12 col-md-12 col-lg-12 mt-2" runat="server" id="lnkInstructor" visible="true">
                                                            
                        <a href="InstructorIn/Index.aspx" >Instructores internos <i class="fas fa-arrow-circle-right"></i></a>
                                                            </div>

 <div class="col-sm-12 col-md-12 col-lg-12 mt-2" runat="server" id="lnkMatrizCurIns" visible="true">
                                                            
                        <a href="MatrizCurIns/Index.aspx" >Matriz Curso-Instalación <i class="fas fa-arrow-circle-right"></i></a>
                                                            </div>
                         
                        </div>



                   
                    </div>

             
                </div>

            </div>

               <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="programacapacitacion" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Programa de Capacitación</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="lblPorcentajeCapacitacion"></asp:Label><label class="font-weight-normal"> % de Avance</label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>

                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <p>
                                    <asp:Label runat="server" ID="Label5"></asp:Label>
                                    

                                    <asp:Label runat="server" ID="Label6"></asp:Label></p>

                            </div>
                        </div>



                        <div class="progress">
                            <div class="progress-bar" runat="server" id="progressCapacitacion">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="Programa/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

               <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="resultadoevaluacion" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Resultados de evaluación</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <h3>
                                   Promedio general: <asp:Label runat="server" ID="lblPromedio"></asp:Label><label class="font-weight-normal"></label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>

                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <p>
                                    <asp:Label runat="server" ID="Label2"></asp:Label>
                                    

                                    <asp:Label runat="server" ID="Label3"></asp:Label></p>

                            </div>
                        </div>



                        <div class="progress">
                            <div class="progress-bar" runat="server" id="progressPromedio">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="ResultadoEv/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
        </div>


    </div>
</asp:Content>
