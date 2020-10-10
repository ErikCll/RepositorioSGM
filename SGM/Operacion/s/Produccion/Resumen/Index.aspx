<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Operacion.s.Produccion.Resumen.Index" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
Horas por Turno

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
      <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
                  <li class="breadcrumb-item "><a href="../../Inicio.aspx">Operación (Inicio)</a></li>
                      <li class="breadcrumb-item "><a href="../Inicio.aspx">Producción</a></li>

                     <li class="breadcrumb-item "><a>Horas por Turno</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
             <div class="col-lg-12">
                <div class="row">
                   
                    <div class="col-sm-12 col-md-6 col-lg-3">
                        <div class="fomr-group">
                            <label>Año:</label>
                            <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="true" DataTextField="Anio" DataValueField="Anio" ID="ddl_Anio" OnSelectedIndexChanged="ddl_Anio_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                     <div class="col-sm-12 col-md-6 col-lg-3">
                        <div class="fomr-group">
                            <label>Mes:</label>
                            <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="true" ID="ddl_Mes" OnSelectedIndexChanged="ddl_Mes_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                        <div class="col-sm-12 col-md-6 col-lg-3">
                        <div class="fomr-group">
                            <label>Equipo:</label>
                            <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="true" ID="ddl_Equipo" OnSelectedIndexChanged="ddl_Equipo_SelectedIndexChanged" DataValueField="Id_Equipo" DataTextField="Nombre"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-12 col-lg-12" runat="server" visible="false">
                        <br />
                         <div class="card">
              <div class="card-header">
                <h5 class="card-title font-weight-bold">Gráfica y resumen mensual de metros</h5>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse">
                    <i class="fas fa-minus"></i>
                  </button>
             
                </div>
              </div>
              <!-- /.card-header -->
              <div class="card-body" style="display: block;">
                <div class="row">

   


                      <div class="col-sm-12 col-md-12 col-lg-6">
                          
                            <div style="overflow:auto ;width:auto">
                                                     <telerik:RadHtmlChart runat="server" ID="LineChart" Height="550" Transitions="true" Skin="Silk">
            <Appearance>
                <FillStyle BackgroundColor="Transparent"></FillStyle>
            </Appearance>
            <ChartTitle Text=".">
                <Appearance Align="Center" BackgroundColor="Transparent" Position="Top">
                </Appearance>
            </ChartTitle>
            <Legend>
                <Appearance BackgroundColor="Transparent" Position="Bottom">
                </Appearance>
            </Legend>
            <PlotArea>
                <Appearance>
                    <FillStyle BackgroundColor="Transparent"></FillStyle>
                </Appearance>
                <XAxis AxisCrossingValue="0" Color="black" MajorTickType="Outside" MinorTickType="Outside"
                    Reversed="false" DataLabelsField="Fecha">
                 
                    <LabelsAppearance DataFormatString="{0}" RotationAngle="290" Skip="0" Step="1">
                    </LabelsAppearance>
                    <TitleAppearance Position="Center" RotationAngle="0" Text="Días">
                    </TitleAppearance>
                </XAxis>
                <YAxis AxisCrossingValue="0" Color="black" MajorTickSize="1" MajorTickType="Outside"
                    MaxValue="10000" MinorTickSize="1" MinorTickType="Outside" MinValue="0" Reversed="false"
                    Step="1000">
                    <LabelsAppearance RotationAngle="0" Skip="0" Step="1">
                    </LabelsAppearance>
                    <TitleAppearance Position="Center" RotationAngle="0" Text="Metros">
                    </TitleAppearance>
                </YAxis>
                <Series>
                    <telerik:LineSeries Name="Turno 1" DataFieldY="Turno1">
                        <Appearance>
                            <FillStyle BackgroundColor="#5ab7de"></FillStyle>
                        </Appearance>
                     
                        <LineAppearance Width="1" />
                        <MarkersAppearance MarkersType="Circle" BackgroundColor="White" Size="8" BorderColor="#5ab7de"
                            BorderWidth="2" ></MarkersAppearance>
                       
                    </telerik:LineSeries>
                    <telerik:LineSeries Name="Turno 2" DataFieldY="Turno2">
                        <Appearance>
                            <FillStyle BackgroundColor="#2d6b99"></FillStyle>
                        </Appearance>
                                             <TooltipsAppearance Color="White"></TooltipsAppearance>

                        <LineAppearance Width="1" />
                        <MarkersAppearance MarkersType="Circle" BackgroundColor="White" Size="8" BorderColor="#2d6b99"
                            BorderWidth="2"></MarkersAppearance>
                    
                    </telerik:LineSeries>

                      <telerik:LineSeries Name="Turno 3" DataFieldY="Turno3">
                        <Appearance>
                            <FillStyle BackgroundColor="DarkGreen"></FillStyle>
                           
                        </Appearance>
                            
                        <TooltipsAppearance Color="White" >
                         
                        </TooltipsAppearance>
                          
                        <MarkersAppearance MarkersType="Circle" BackgroundColor="White" Size="8" BorderColor="DarkGreen"
                            BorderWidth="2">
                            
                        </MarkersAppearance>
                    
                    </telerik:LineSeries>
                </Series>
            </PlotArea>
        </telerik:RadHtmlChart>

                                </div>

                        </div>
                  <!-- /.col -->
                  <div class="col-sm-12 col-md-12 col-lg-6">
                      
                     
         <br />

                                       <br />

                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-bordered table-striped table-sm "
                                  HeaderStyle-CssClass="bg-white"
                                    GridLines="Horizontal"                                   id="gridResumen"
                                    AutoGenerateColumns="true"
                                     EmptyDataText="Sin registros."
                                     OnRowDataBound="gridResumen_RowDataBound"
                                     HeaderStyle-HorizontalAlign="Center"
                                     RowStyle-HorizontalAlign="Center"

                                     OnRowCommand="gridResumen_RowCommand"
                                    >
                                    <Columns>
                                        
                                   
                                        <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                           

                                               <asp:Button runat="server" Text="Ver" CssClass="btn btn-outline-primary" CommandName="Ver"/>

                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                     
                                    </Columns>
                             
                                   
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                  <!-- /.col -->
                </div>
                <!-- /.row -->
              </div>
              <!-- ./card-body -->
             
              <!-- /.card-footer -->
            </div>
                    </div>
                   
                         <div class="col-sm-12 col-md-12 col-lg-12">
                        <br />
                         <div class="card">
              <div class="card-header">
                <h5 class="card-title font-weight-bold">Gráfica y resumen mensual de horas de producción</h5>

                <div class="card-tools">
                                          <a class="text-sm" href="Detalle.aspx">Detalle</a>

                  <button type="button" class="btn btn-tool" data-card-widget="collapse">
                    <i class="fas fa-minus"></i>
                  </button>
             
                </div>
              </div>
              <!-- /.card-header -->
              <div class="card-body" style="display: block;">
                <div class="row">
                                                 <div class="col-sm-12 col-md-6 col-lg-4" >
<div class="card card-default">
              <div class="card-header">
                <h3 class="card-title font-weight-bold">Turno 1</h3>

                <div class="card-tools">
                  
                </div>
              </div>
              <div class="card-body" style="display: block;">
                  <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                <h3><asp:Label runat="server" ID="lblTurno1"></asp:Label> <label class="font-weight-normal text-lg"> Horas</label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
</h3>
                     
                  </div>
                      <div class="col-sm-12 col-md-12 col-lg-12 mt-2">
                                         <div class="progress ">
                        <div class="progress-bar bg-green" runat="server" id="progresTurno1" >
                        </div>
              </div>  
                      </div>
              
                   
                  </div>
                  
          
  </div>
              <!-- /.card-body -->
  
            </div>
     
           </div>


                          <div class="col-sm-12 col-md-6 col-lg-4" >
<div class="card card-default">
              <div class="card-header">
                <h3 class="card-title font-weight-bold">Turno 2</h3>

                <div class="card-tools">
               
                </div>
              </div>
              <div class="card-body" style="display: block;">
                  <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                <h3><asp:Label runat="server" ID="lblTurno2"></asp:Label> <label class="font-weight-normal text-lg"> Horas</label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
</h3>
                     
                  </div>
                      <div class="col-sm-12 col-md-12 col-lg-12 mt-2">
                                         <div class="progress ">
                        <div class="progress-bar bg-green" runat="server" id="progresTurno2" >
                        </div>
              </div>  
                      </div>
              
                   
                  </div>
                  
          
  </div>
              <!-- /.card-body -->
  
            </div>
     
           </div>



                          <div class="col-sm-12 col-md-6 col-lg-4">
<div class="card card-default">
              <div class="card-header">
                <h3 class="card-title font-weight-bold">Turno 3</h3>

                <div class="card-tools">
               
                </div>
              </div>
              <div class="card-body" style="display: block;">
                  <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                <h3><asp:Label runat="server" ID="lblTurno3"></asp:Label> <label class="font-weight-normal text-lg"> Horas</label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
</h3>
                     
                  </div>
                      <div class="col-sm-12 col-md-12 col-lg-12 mt-2">
                                         <div class="progress ">
                        <div class="progress-bar bg-green" runat="server" id="progresTurno3" >
                        </div>
              </div>  
                      </div>
              
                   
                  </div>
                  
          
  </div>
              <!-- /.card-body -->
  
            </div>
     
           </div>
                      <div class="col-sm-12 col-md-12 col-lg-6">
                          
                            <div style="overflow:auto ;width:auto">
                                    <%--   <telerik:RadHtmlChart runat="server" ID="RadHtmlChart1" Height="550" Skin="Silk" PlotArea-XAxis-MinValue="0" PlotArea-YAxis-MaxValue="20" PlotArea-YAxis-Step="1">
    <PlotArea>
        <Series>
            <telerik:ColumnSeries Name="Turno 1" GroupName="Turno" >
                <Appearance>
                    <FillStyle BackgroundColor="#5ab7de" />
                </Appearance>

                <SeriesItems>
                                         <telerik:CategorySeriesItem Y="0" />
                    <telerik:CategorySeriesItem Y="4.85" />
                    <telerik:CategorySeriesItem Y="6.58" />
                                                                                <telerik:CategorySeriesItem Y="1.55" />

                </SeriesItems>
                <LabelsAppearance Visible="false"></LabelsAppearance>
            </telerik:ColumnSeries>
            <telerik:ColumnSeries Name="Turno 2" GroupName="Turno" >
                <Appearance>
                    <FillStyle BackgroundColor="#2d6b99" />
                </Appearance>
                                  <TooltipsAppearance Color="White"></TooltipsAppearance>

                <SeriesItems>
                    <telerik:CategorySeriesItem Y="0" />
                    <telerik:CategorySeriesItem Y="5.54" />
                    <telerik:CategorySeriesItem Y="4.54" />
                                                                                <telerik:CategorySeriesItem Y="4.13" />

                </SeriesItems>
                <LabelsAppearance Visible="false"></LabelsAppearance>
            </telerik:ColumnSeries>
            <telerik:ColumnSeries Name="Turno 3" GroupName="Turno" >
                <Appearance>
                    <FillStyle BackgroundColor="DarkGreen" />
                </Appearance>
                  <TooltipsAppearance Color="White"></TooltipsAppearance>
                <SeriesItems>
                    <telerik:CategorySeriesItem Y="0.6" />
                    <telerik:CategorySeriesItem Y="4.71" />
                    <telerik:CategorySeriesItem Y="5.11" />
                                                                                <telerik:CategorySeriesItem Y="0" />

                </SeriesItems>
                <LabelsAppearance Visible="false" ></LabelsAppearance>
            </telerik:ColumnSeries>

         
        </Series>
        <YAxis>
            <TitleAppearance Text="Horas" />
        </YAxis>
        <XAxis>
            <LabelsAppearance />
            <Items>
                                <telerik:AxisItem LabelText="12-08-2020	" />
                                <telerik:AxisItem LabelText="13-08-2020	" />
                                <telerik:AxisItem LabelText="14-08-2020	" />

                <telerik:AxisItem LabelText="15-08-2020	" />
            

            </Items>
        </XAxis>
    </PlotArea>
    <ChartTitle Text=".">
    </ChartTitle>
    <Legend>
        <Appearance Position="Bottom" />
    </Legend>
</telerik:RadHtmlChart> --%>          
                                   <telerik:RadHtmlChart runat="server" ID="GraficaHora" Height="550" Transitions="true" Skin="Silk"  >
            <Appearance>
                <FillStyle BackgroundColor="Transparent"></FillStyle>
            </Appearance>
            <ChartTitle Text=".">
                <Appearance Align="Center" BackgroundColor="Transparent" Position="Top">
                </Appearance>
            </ChartTitle>
            <Legend>
                <Appearance BackgroundColor="Transparent" Position="Bottom">
                </Appearance>
            </Legend>
            <PlotArea>
                <Appearance>
                    <FillStyle BackgroundColor="Transparent"></FillStyle>
                </Appearance>
                <XAxis AxisCrossingValue="0" Color="black" MajorTickType="Outside" MinorTickType="Outside"
                    Reversed="false" DataLabelsField="Fecha">
                 
                    <LabelsAppearance DataFormatString="{0}" RotationAngle="290" Skip="0" Step="1">
                    </LabelsAppearance>
                    <TitleAppearance Position="Center" RotationAngle="0" Text="Días">
                    </TitleAppearance>
                </XAxis>
                <YAxis AxisCrossingValue="0" Color="black" MajorTickSize="1" MajorTickType="Outside"
                    MaxValue="10" MinorTickSize="1" MinorTickType="Outside" MinValue="0" Reversed="false"
                    Step="2">
                    <LabelsAppearance RotationAngle="0" Skip="0" Step="1">
                    </LabelsAppearance>
                    <TitleAppearance Position="Center" RotationAngle="0" Text="Horas">
                    </TitleAppearance>
                </YAxis>
                <Series>
                    <telerik:LineSeries Name="Turno 1" DataFieldY="Turno1">
                        <Appearance>
                            <FillStyle BackgroundColor="#5ab7de"></FillStyle>
                        </Appearance>
                     <LabelsAppearance Visible="false"></LabelsAppearance>
                        <LineAppearance Width="2" />
                        <MarkersAppearance MarkersType="Circle" BackgroundColor="White" Size="8" BorderColor="#5ab7de"
                            BorderWidth="2" ></MarkersAppearance>
                       
                    </telerik:LineSeries>
                    <telerik:LineSeries Name="Turno 2" DataFieldY="Turno2">
                        <Appearance>
                            <FillStyle BackgroundColor="#2d6b99"></FillStyle>
                        </Appearance>
                                             <TooltipsAppearance Color="White"></TooltipsAppearance>
                         <LabelsAppearance Visible="false"></LabelsAppearance>
                        <LineAppearance Width="2" />
                        <MarkersAppearance MarkersType="Circle" BackgroundColor="White" Size="8" BorderColor="#2d6b99"
                            BorderWidth="2"></MarkersAppearance>
                    
                    </telerik:LineSeries>

                      <telerik:LineSeries Name="Turno 3" DataFieldY="Turno3">
                        <Appearance>
                            <FillStyle BackgroundColor="DarkGreen"></FillStyle>
                           
                        </Appearance>
                             <LabelsAppearance Visible="false"></LabelsAppearance>
                        <TooltipsAppearance Color="White" >
                         
                        </TooltipsAppearance>
                           <LineAppearance Width="2" />
                        <MarkersAppearance MarkersType="Circle" BackgroundColor="White" Size="8" BorderColor="DarkGreen"
                            BorderWidth="2">
                            
                        </MarkersAppearance>
                    
                    </telerik:LineSeries>
                </Series>
            </PlotArea>
        </telerik:RadHtmlChart>
                                </div>

                        </div>
                  <!-- /.col -->
                  <div class="col-sm-12 col-md-12 col-lg-6">
                      
                     
         <br />

                                       <br />

                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                    
                                    CssClass=" table table-bordered table-striped table-sm "
                                   HeaderStyle-BackColor="#343a40"
                                     HeaderStyle-CssClass=" text-white"
                                    GridLines="Horizontal"  
                                   id="gridHora"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registros."
                                   PageSize="10"
                                     AllowPaging="true"
                                     OnPageIndexChanging="gridHora_PageIndexChanging"
                                      HeaderStyle-HorizontalAlign="Center"
                                     RowStyle-HorizontalAlign="Center"
                                     OnRowDataBound="gridHora_RowDataBound"
                                    >
                                    <Columns>
                                      <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                                        <asp:BoundField HeaderText="Turno 1" DataField="Turno1" />
                                                                                <asp:BoundField HeaderText="Turno 2" DataField="Turno2" />

                                                                                <asp:BoundField HeaderText="Turno 3" DataField="Turno3" />
                                        <asp:TemplateField HeaderText="Promedio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPromedio"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" />
                             
                                </asp:GridView>

                            </div>

                        </div>
                    </div>
                  <!-- /.col -->
                                                                                    <asp:Button runat="server" CssClass="btn btn-default" Text="Regresar" ID="btnRegresar" PostBackUrl="~/s/Produccion/Inicio.aspx" />

                </div>
                <!-- /.row -->
              </div>
              <!-- ./card-body -->
             
              <!-- /.card-footer -->
            </div>
                    </div>
                   
                    <div class="col-sm-12 col-md-12 col-lg-12" runat="server" visible="false">
                        <br />
                         <div class="card">
              <div class="card-header">
                <h5 class="card-title font-weight-bold">Gráfica y resumen mensual de eficiencia</h5>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse">
                    <i class="fas fa-minus"></i>
                  </button>
             
                </div>
              </div>
              <!-- /.card-header -->
              <div class="card-body" style="display: block;">
                <div class="row">
                      <div class="col-sm-12 col-md-12 col-lg-6">
                          
                            <div style="overflow:auto ;width:auto">
                                       <telerik:RadHtmlChart runat="server" ID="RadHtmlChart2" Height="550" Skin="Silk" PlotArea-XAxis-MinValue="0" PlotArea-YAxis-MaxValue="100" PlotArea-YAxis-Step="10" PlotArea-YAxis-LabelsAppearance-DataFormatString="{0}%">
    <PlotArea>
        <Series>
            <telerik:ColumnSeries Name="Turno 1" >
                <Appearance>
                    <FillStyle BackgroundColor="#5ab7de" />
                </Appearance>

                <SeriesItems>
                                         <telerik:CategorySeriesItem Y="0" />
                    <telerik:CategorySeriesItem Y="60.63" />
                    <telerik:CategorySeriesItem Y="82.25" />
                                                                                <telerik:CategorySeriesItem Y="20.67" />

                </SeriesItems>
                <TooltipsAppearance  DataFormatString="{0}%"></TooltipsAppearance>
                <LabelsAppearance Visible="false"></LabelsAppearance>
            </telerik:ColumnSeries>
            <telerik:ColumnSeries Name="Turno 2"  >
                <Appearance>
                    <FillStyle BackgroundColor="#2d6b99" />
                </Appearance>
                                  <TooltipsAppearance Color="White"  DataFormatString="{0}%"></TooltipsAppearance>

                <SeriesItems>
                    <telerik:CategorySeriesItem Y="0" />
                    <telerik:CategorySeriesItem Y="72" />
                    <telerik:CategorySeriesItem Y="60.53" />
                                                                                <telerik:CategorySeriesItem Y="55.07" />

                </SeriesItems>
                <LabelsAppearance Visible="false"></LabelsAppearance>
            </telerik:ColumnSeries>
            <telerik:ColumnSeries Name="Turno 3" >
                <Appearance>
                    <FillStyle BackgroundColor="DarkGreen" />
                </Appearance>
                  <TooltipsAppearance Color="White" DataFormatString="{0}%"></TooltipsAppearance>
                <SeriesItems>
                    <telerik:CategorySeriesItem Y="60.13" />
                    <telerik:CategorySeriesItem Y="62.8" />
                    <telerik:CategorySeriesItem Y="68.13" />
                                                                                <telerik:CategorySeriesItem Y="0" />

                </SeriesItems>
                <LabelsAppearance Visible="false" ></LabelsAppearance>
            </telerik:ColumnSeries>

         
        </Series>
        <YAxis>
            <TitleAppearance Text="Eficiencia" />
        </YAxis>
        <XAxis>
            <LabelsAppearance />
            <Items>
                                <telerik:AxisItem LabelText="12-08-2020	" />
                                <telerik:AxisItem LabelText="13-08-2020	" />
                                <telerik:AxisItem LabelText="14-08-2020	" />

                <telerik:AxisItem LabelText="15-08-2020	" />
            

            </Items>
        </XAxis>
    </PlotArea>
    <ChartTitle Text=".">
    </ChartTitle>
    <Legend>
        <Appearance Position="Bottom" />
    </Legend>
</telerik:RadHtmlChart>           

                                </div>

                        </div>
                  <!-- /.col -->
                  <div class="col-sm-12 col-md-12 col-lg-6">
                      
                     
         <br />

                                       <br />

                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                   CssClass=" table table-bordered table-striped table-sm "
                                  HeaderStyle-CssClass="bg-white"
                                    GridLines="Horizontal"  
                                   id="gridEfic"
                                    AutoGenerateColumns="true"
                                     EmptyDataText="Sin registros."
                                    HeaderStyle-HorizontalAlign="Center"
                                     RowStyle-HorizontalAlign="Center"
                                    
                                    >
                                    <Columns>
                                        <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                           

                                               <asp:Button runat="server" Text="Ver" CssClass="btn btn-outline-primary" CommandName="Ver"/>

                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                             
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                  <!-- /.col -->
                </div>
                <!-- /.row -->
              </div>
              <!-- ./card-body -->
             
              <!-- /.card-footer -->
            </div>
                    </div>
                   
                
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
           <script type="text/javascript">

              Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {
               

          });
             
      
        
                function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
                 if (((keyEntry >= 65) && (keyEntry <= 90)) ||
                     ((keyEntry >= 97) && (keyEntry <= 122)) ||
                     (keyEntry == 46) || (keyEntry == 32) || keyEntry == 45 || (keyEntry == 32) || keyEntry == 45 || keyEntry == 63 || keyEntry == 33 || keyEntry == 168

                     || (keyEntry == 241) || keyEntry == 209
                     || (keyEntry == 225) || keyEntry == 233
                     || (keyEntry == 237) || keyEntry == 243
                     || (keyEntry == 243) || keyEntry == 250
                     || (keyEntry == 193) || keyEntry == 201
                     || (keyEntry == 205) || keyEntry == 211
                     || (keyEntry == 218) ||(keyEntry >=48 && keyEntry<=57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64) 
                return true;
            else {
                return false;
            }
        }
            </script>  
</asp:Content>
