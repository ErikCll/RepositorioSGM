<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SGL.s.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
Sistema de Gestión para Laboratorios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
      <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
    <li class="breadcrumb-item "><a>SGL</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
       <div class="col-lg-12">
       <div class="row">

                <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="acreditacion" visible="false">
<div class="card card-default shadow-sm">
              <div class="card-header">
                <h3 class="card-title font-weight-bold">Acreditaciones</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i>
                  </button>
                </div>
              </div>
              <div class="card-body" style="display: block;">
                  <div class="row">
           <%--                <div class="col-sm-12 col-md-6 col-lg-12">
                <h3><asp:Label runat="server" ID="lblPorcentaje"></asp:Label><label class="font-weight-normal">   </label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
</h3>
                              
                  </div>--%>
        
                      <div class="col-sm-12 col-md-12 col-lg-12">
<%--                                        <p><asp:Label runat="server" ID="lblOperando"></asp:Label> de <asp:Label runat="server"  ID="lblTotal"></asp:Label></p>--%>

                      </div>

                                    <div class="container col-12">
                                                                       <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">

                                   <asp:GridView runat="server" 
                                 CssClass=" table table-bordered table-striped table-sm"
                                  
                                   id="gridAcreditacion"
                                     HeaderStyle-BackColor="#343a40"
                                     HeaderStyle-CssClass=" text-white"
                                            GridLines="Horizontal"
                                    AutoGenerateColumns="false"
                                     HeaderStyle-HorizontalAlign="Center"
                                     EmptyDataText="Sin registro de acreditaciones."
                                 DataKeyNames="Id_Acreditacion"
                                     OnRowDataBound="gridAcreditacion_RowDataBound"
                                    >
                                    <Columns>
                                     <asp:BoundField HeaderText="Acreditador" DataField="Acreditador" ItemStyle-HorizontalAlign="Center" />
     
                                 <asp:BoundField HeaderText="Fecha" DataField="Fecha" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Estatus" DataField="Status" ItemStyle-HorizontalAlign="Center"/>
                                     
                                           <asp:TemplateField HeaderText="Archivo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblArchivo" Text='<%# Eval("Id_status") %>' Visible="false" ></asp:Label>
                                                <asp:HyperLink runat="server" ID="lnkArchivo" Target="_blank" ImageUrl="~/dist/img/pdficon.svg" ImageHeight="17px" ImageWidth="17px" ></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                  
                                </asp:GridView>
                                </div>

                                                                           </div>

                                                                 </div>
                  </div>
             

               
         
       
  </div>
            
    <!-- /.card-body -->
     <div class="card-footer mt-2">
                      <a href="Acreditacion/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

    </div>
            </div>
     
           </div>

                    <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="procedimientoinstructivo" visible="false">
<div class="card card-default shadow-sm">
              <div class="card-header">
                <h3 class="card-title font-weight-bold">Procedimientos e Instructivos</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i>
                  </button>
                </div>
              </div>
              <div class="card-body" style="display: block;">
                  <div class="row">
                           <div class="col-sm-12 col-md-6 col-lg-12">
                <h3><asp:Label runat="server" ID="Label1"></asp:Label><label class="font-weight-normal">   </label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
</h3>
                              
                  </div>
        
                      <div class="col-sm-12 col-md-12 col-lg-12">
<%--                                        <p><asp:Label runat="server" ID="lblOperando"></asp:Label> de <asp:Label runat="server"  ID="lblTotal"></asp:Label></p>--%>

                      </div>
                  </div>
             

               
         
           <div class="progress">
                        <div class="progress-bar" runat="server" id="div2">
                        </div>
              </div>
  </div>
            
    <!-- /.card-body -->
     <div class="card-footer mt-2">
                      <a href="Procedimiento/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

    </div>
            </div>
     
           </div>

                    <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="competencia" visible="false">
<div class="card card-default shadow-sm">
              <div class="card-header">
                <h3 class="card-title font-weight-bold">Competencia y Formación</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i>
                  </button>
                </div>
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
     <div class="card-footer mt-2">
                      <a href="Competencia/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

    </div>
            </div>
     
           </div>

                 <div class="col-sm-12 col-md-6 col-lg-4" id="confirmacion" runat="server" visible="true">
                <div class="card card-default shadow-sm">
                    <div class="card-header">
                        <h3 class="card-title font-weight-bold">Confirmación metrológica</h3>
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
                                    <asp:Label runat="server" ID="Label2"></asp:Label><label class="font-weight-normal">   </label>
                                    <i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
                                </h3>

                            </div>

                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <%--                                        <p><asp:Label runat="server" ID="lblOperando"></asp:Label> de <asp:Label runat="server"  ID="lblTotal"></asp:Label></p>--%>
                            </div>
                        </div>




                        <div class="progress">
                            <div class="progress-bar" runat="server" id="div3">
                            </div>
                        </div>
                    </div>

                    <!-- /.card-body -->
                    <div class="card-footer">
                        <a href="Confirmacion/Inicio.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

                    </div>
                </div>

            </div>
           </div>



           </div>
</asp:Content>
