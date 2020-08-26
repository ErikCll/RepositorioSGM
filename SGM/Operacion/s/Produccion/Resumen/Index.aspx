<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Operacion.s.Produccion.Resumen.Index" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Resumen mensual
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
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
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <br />
                         <div class="card">
              <div class="card-header">
                <h5 class="card-title">Gráfica y resumen mensual de metros</h5>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse">
                    <i class="fas fa-minus"></i>
                  </button>
             
                </div>
              </div>
              <!-- /.card-header -->
              <div class="card-body" style="display: block;">
                <div class="row">
                      <div class="col-sm-12 col-md-12 col-lg-12">
                          
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
                  <div class="container col-12">
                      
                     
         <br />

                   
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-striped table-sm border-light"
                                   GridLines="Vertical"
                                   id="gridResumen"
                                    AutoGenerateColumns="true"
                                     EmptyDataText="Sin registros."
                                     OnRowDataBound="gridResumen_RowDataBound"
                                     OnRowCommand="gridResumen_RowCommand"
                                    
                                    >
                                    <Columns>
                                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                           

                                               <asp:Button runat="server" Text="Ver" CssClass="btn btn-outline-primary" CommandName="Ver"/>

                                            </ItemTemplate>
                                        </asp:TemplateField>
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
