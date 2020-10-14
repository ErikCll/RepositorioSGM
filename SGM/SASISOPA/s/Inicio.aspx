<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SASISOPA.s.Inicio" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
    <li class="breadcrumb-item "><a>SASISOPA</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <div class="col-lg-12">
        <div class="row">

                        <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">1. Política</h3>
                          <i class="fas fa-university  fa-2x text-black-50 float-right"></i>
                    </div>
                 <div class="card-body" style="display: block;">
                        <div class="row">

                            <div class="col-sm-8 col-md-8 col-lg-8">


                                   <label class=" text-sm font-weight-normal">Difusión: </label><asp:Label runat="server" ID="Label5" CssClass="text-sm ml-1 text-bold"></asp:Label>
                       
  

                                                               
<%--<br />
                                    <label class="text-sm">Promedio: </label><asp:Label runat="server" ID="lblPromedio" Text="87.50%" CssClass="text-sm"></asp:Label>--%>
                                                                                       
                            </div>  
                            <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar"  id="Div1" runat="server"></div></div> 
                            </div>

                        
                         
                           
                                                        <div class="col-sm-8 col-md-8 col-lg-8">

 <label class="text-sm font-weight-normal">Evaluación: </label><asp:Label runat="server" ID="Label9" CssClass="text-sm ml-1 text-bold"></asp:Label>

</div>
                                <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar" id="Div2" runat="server"></div></div> 
                            </div>
                           <%--    <div class="col-sm-6 col-md-6 col-lg-6">
                                                 <i class="fas fa-graduation-cap fa-4x text-black-50 float-right"></i>
                                       </div>         --%>       
                           
                                    




                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Politica/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>


              <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">2. Riesgos</h3>
                         <i class="fas fa-exclamation-triangle  fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label1"></asp:Label><label class="font-weight-normal">  </label>
                                   
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Riesgo/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>


               <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">3. Requisitos Legales</h3>
                        <i class="fas fa-balance-scale fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label2"></asp:Label><label class="font-weight-normal">  </label>
                                    
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="RequisitoLegal/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>



                  <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">4. Metas, Objetivos e Indicadores</h3>
                        <i class="fas fa-chart-line fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label3"></asp:Label><label class="font-weight-normal">  </label>
                                    
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="MetaObjetivo/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

                   <div class="col-sm-12 col-md-6 col-lg-4 " runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">5. Funciones, Responsabilidad</h3>
                         <i class="fas fa-user-check fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label4"></asp:Label><label class="font-weight-normal">  </label>
                                   
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="FuncionRes/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

              <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold mt-1">6. Competencia y Formación   </h3>
                <i class="fas fa-graduation-cap fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">

                            <div class="col-sm-8 col-md-8 col-lg-8">


                                   <label class=" text-sm font-weight-normal">Programa de capacitación: </label><asp:Label runat="server" ID="lblAvanceCapacitacion6" CssClass="text-sm ml-1 text-bold"></asp:Label>
                       
  

                                                               
<%--<br />
                                    <label class="text-sm">Promedio: </label><asp:Label runat="server" ID="lblPromedio" Text="87.50%" CssClass="text-sm"></asp:Label>--%>
                                                                                       
                            </div>  
                            <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar" style="width:75%" id="progressCapacitacion6" runat="server"></div></div> 
                            </div>

                        
                         
                           
                                                        <div class="col-sm-8 col-md-8 col-lg-8">

 <label class="text-sm font-weight-normal">Resultados de evaluación: </label><asp:Label runat="server" ID="lblPromedioResultado6" CssClass="text-sm ml-1 text-bold"></asp:Label>

</div>
                                <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar" style="width:75%" id="progressPromedioResultado6" runat="server"></div></div> 
                            </div>
                           <%--    <div class="col-sm-6 col-md-6 col-lg-6">
                                                 <i class="fas fa-graduation-cap fa-4x text-black-50 float-right"></i>
                                       </div>         --%>       
                           
                                    




                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Competencia/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>


              <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">7. Comunicación</h3>
                        <i class="fas fa-bullhorn fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label6"></asp:Label><label class="font-weight-normal">  </label>
                                    
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Comunicacion/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>


               <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm ">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">8. Control de Documentos</h3>
                         <i class="far fa-file-alt fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label7"></asp:Label><label class="font-weight-normal">  </label>
                                   
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="ControlDoc/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>


               <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm ">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">9. Mejores Prácticas</h3>
                         <i class="fas fa-check-square fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label8"></asp:Label><label class="font-weight-normal">  </label>
                                   
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="MPractica/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

              <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">10. Control de Actividades</h3>
                        <i class="fas fa-calendar-check fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <label class="text-sm font-weight-normal">Censo de actividad</label>
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
                    <div class="card-footer">
                        <a href="ControlAct/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

            <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">11. Integridad Mecánica</h3>
                         <i class="fas fa-wrench fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label10"></asp:Label><label class="font-weight-normal">  </label>
                                   
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="IntegridadMec/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

            <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">12. Seguridad para Contratistas</h3>
                        <i class="fas fa-user-shield fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label11"></asp:Label><label class="font-weight-normal">  </label>
                                    
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Seguridad/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

              <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">13. Respuesta a Emergencias</h3>
                         <i class="fas fa-ambulance fa-2x text-black-50 float-right"></i>
                    </div>
                  <div class="card-body" style="display: block;">
                        <div class="row">

                            <div class="col-sm-8 col-md-8 col-lg-8">


                                   <label class=" text-sm font-weight-normal">Programa de simulacros: </label><asp:Label runat="server" ID="Label12" CssClass="text-sm ml-1 text-bold"></asp:Label>
                       
  

                                                               
<%--<br />
                                    <label class="text-sm">Promedio: </label><asp:Label runat="server" ID="lblPromedio" Text="87.50%" CssClass="text-sm"></asp:Label>--%>
                                                                                       
                            </div>  
                            <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar"  id="Div3" runat="server"></div></div> 
                            </div>

                        
                         
                           
                                                        <div class="col-sm-8 col-md-8 col-lg-8">

 <label class="text-sm font-weight-normal">Plan de Emergencias: </label><asp:Label runat="server" ID="Label18" CssClass="text-sm ml-1 text-bold"></asp:Label>

</div>
                                <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar" id="Div4" runat="server"></div></div> 
                            </div>
                           <%--    <div class="col-sm-6 col-md-6 col-lg-6">
                                                 <i class="fas fa-graduation-cap fa-4x text-black-50 float-right"></i>
                                       </div>         --%>       
                           
                                    




                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Respuesta/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

              <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">14. Monitoreo, Verificación</h3>
                        <i class="fas fa-desktop fa-2x text-black-50 float-right"></i>
                    </div>
                  <div class="card-body" style="display: block;">
                        <div class="row">

                            <div class="col-sm-8 col-md-8 col-lg-8">


                                   <label class=" text-sm font-weight-normal">Programa  Reuniones: </label><asp:Label runat="server" ID="Label13" CssClass="text-sm ml-1 text-bold"></asp:Label>
                       
  

                                                               
<%--<br />
                                    <label class="text-sm">Promedio: </label><asp:Label runat="server" ID="lblPromedio" Text="87.50%" CssClass="text-sm"></asp:Label>--%>
                                                                                       
                            </div>  
                            <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar"  id="Div5" runat="server"></div></div> 
                            </div>

                        
                         
                           
                                                        <div class="col-sm-8 col-md-8 col-lg-8">

 <label class="text-sm font-weight-normal">Atención de acuerdos: </label><asp:Label runat="server" ID="Label19" CssClass="text-sm ml-1 text-bold"></asp:Label>

</div>
                                <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar" id="Div6" runat="server"></div></div> 
                            </div>
                           <%--    <div class="col-sm-6 col-md-6 col-lg-6">
                                                 <i class="fas fa-graduation-cap fa-4x text-black-50 float-right"></i>
                                       </div>         --%>       
                           
                                    




                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Monitoreo/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

             <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm ">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">15. Auditoría</h3>
                        <i class="fas fa-search fa-2x text-black-50 float-right"></i>
                    </div>
                  <div class="card-body" style="display: block;">
                        <div class="row">

                            <div class="col-sm-8 col-md-8 col-lg-8">


                                   <label class=" text-sm font-weight-normal">Programa Auditorías: </label><asp:Label runat="server" ID="Label14" CssClass="text-sm ml-1 text-bold"></asp:Label>
                       
  

                                                               
<%--<br />
                                    <label class="text-sm">Promedio: </label><asp:Label runat="server" ID="lblPromedio" Text="87.50%" CssClass="text-sm"></asp:Label>--%>
                                                                                       
                            </div>  
                            <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar"  id="Div7" runat="server"></div></div> 
                            </div>

                        
                         
                           
                                                        <div class="col-sm-8 col-md-8 col-lg-8">

 <label class="text-sm font-weight-normal">Atención de hallazgos: </label><asp:Label runat="server" ID="Label20" CssClass="text-sm ml-1 text-bold"></asp:Label>

</div>
                                <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar" id="Div8" runat="server"></div></div> 
                            </div>
                           <%--    <div class="col-sm-6 col-md-6 col-lg-6">
                                                 <i class="fas fa-graduation-cap fa-4x text-black-50 float-right"></i>
                                       </div>         --%>       
                           
                                    




                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Auditoria/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

             <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">16. Investigación de Incidentes</h3>
                        <i class="fas fa-book-reader fa-2x text-black-50 float-right"></i>
                    </div>
                  <div class="card-body" style="display: block;">
                        <div class="row">

                            <div class="col-sm-8 col-md-8 col-lg-8">


                                   <label class=" text-sm font-weight-normal">Incidentes: </label><asp:Label runat="server" ID="Label15" CssClass="text-sm ml-1 text-bold"></asp:Label>
                       
  

                                                               
<%--<br />
                                    <label class="text-sm">Promedio: </label><asp:Label runat="server" ID="lblPromedio" Text="87.50%" CssClass="text-sm"></asp:Label>--%>
                                                                                       
                            </div>  
                            <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar"  id="Div9" runat="server"></div></div> 
                            </div>

                        
                         
                           
                                                        <div class="col-sm-8 col-md-8 col-lg-8">

 <label class="text-sm font-weight-normal">Difusión incidentes: </label><asp:Label runat="server" ID="Label21" CssClass="text-sm ml-1 text-bold"></asp:Label>

</div>
                                <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar" id="Div10" runat="server"></div></div> 
                            </div>

                                             
                                                        <div class="col-sm-8 col-md-8 col-lg-8">

 <label class="text-sm font-weight-normal">Elaboración de ACR: </label><asp:Label runat="server" ID="Label22" CssClass="text-sm ml-1 text-bold"></asp:Label>

</div>
                                <div class="col-sm-4 col-md-4 col-lg-4 mt-1">

                                  <div class="progress"><div class="progress-bar" id="Div11" runat="server"></div></div> 
                            </div>
                           <%--    <div class="col-sm-6 col-md-6 col-lg-6">
                                                 <i class="fas fa-graduation-cap fa-4x text-black-50 float-right"></i>
                                       </div>         --%>       
                           
                                    




                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Investigacion/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

              <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">17. Revisión de resultados</h3>
                        <i class="fas fa-clipboard-list fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label16"></asp:Label><label class="font-weight-normal">  </label>
                                    
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Revision/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

              <div class="col-sm-12 col-md-6 col-lg-4" runat="server">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">18. Informe de Desempeño</h3>
                         <i class="fas fa-file-signature fa-2x text-black-50 float-right"></i>
                    </div>
                    <div class="card-body" style="display: block;">
                        <div class="row">
                            <div class="col-sm-12 col-md-6 col-lg-12">
                                <h3>
                                    <asp:Label runat="server" ID="Label17"></asp:Label><label class="font-weight-normal">  </label>
                                   
                                </h3>

                            </div>

                        </div>

                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Informe/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>

            
    
        </div>


    </div>

</asp:Content>
