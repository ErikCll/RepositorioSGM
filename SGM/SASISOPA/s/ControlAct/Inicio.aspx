<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SASISOPA.s.ControlAct.Inicio" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     10. Control de Actividades
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
        <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
           <li class="breadcrumb-item "><a href="../Inicio.aspx">SASISOPA (Inicio)</a></li>

    <li class="breadcrumb-item "><a>10. Control de Actividades</a></li>
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

            <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="censoactividad" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Censo de actividad</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                         <div style="overflow:auto ;width:auto" >
                                                   <telerik:RadHtmlChart runat="server" ID="graficaAct" Height="100" Skin="Silk" PlotArea-YAxis-Step="1" >
    <PlotArea>
        <Series>
            <telerik:ColumnSeries Name="Total" DataFieldY="Total" >
                <Appearance>
                    <FillStyle BackgroundColor="#5ab7de" />
                </Appearance>

                
                <LabelsAppearance Visible="true"></LabelsAppearance>
            </telerik:ColumnSeries>
            <telerik:ColumnSeries Name="Disponibles" DataFieldY="Disponibles"  >
                <Appearance>
                    <FillStyle BackgroundColor="#2d6b99" />
                </Appearance>
                                  <TooltipsAppearance Color="White" ></TooltipsAppearance>

         
                <LabelsAppearance Visible="true"></LabelsAppearance>
            </telerik:ColumnSeries>
            <telerik:ColumnSeries Name="Vigentes" DataFieldY="Vigentes" >
                <Appearance>
                    <FillStyle BackgroundColor="DarkGreen" />
                </Appearance>
                  <TooltipsAppearance Color="White"></TooltipsAppearance>
            
                <LabelsAppearance Visible="true" ></LabelsAppearance>
            </telerik:ColumnSeries>

                  <telerik:ColumnSeries Name="Con Evaluación" DataFieldY="Evaluacion" >
                <Appearance>
                    <FillStyle BackgroundColor="DarkCyan"/>
                </Appearance>
                  <TooltipsAppearance Color="White"></TooltipsAppearance>
            
                <LabelsAppearance Visible="true" ></LabelsAppearance>
            </telerik:ColumnSeries>
         
        </Series>
        <YAxis>
            <TitleAppearance Text="Actividades" Visible="false"  />
            
            <LabelsAppearance Visible="false" ></LabelsAppearance>
        </YAxis>
        <XAxis>
            <LabelsAppearance />
      
        </XAxis>
    </PlotArea>
   
    <Legend>
        <Appearance Position="Right" />
    </Legend>
</telerik:RadHtmlChart>   
                                </div>
                            </div>

                          
                        </div>



                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer mt-2">
                        <a href="CensoAct/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>


                        </div>
                </div>

            </div>

               <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="instalacionactividad" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Matriz Instalación-Actividad</h3>

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
                        <a href="MatrizInsAct/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>


            </div>

           </div>
</asp:Content>
