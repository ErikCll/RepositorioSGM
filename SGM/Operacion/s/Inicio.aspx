<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Operacion.s.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
       <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
                  <li class="breadcrumb-item "><a>Operación</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
   <div class="col-lg-12">
       <div class="row">
           <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="infraestructura" visible="false">
<div class="card card-default shadow-sm">
              <div class="card-header">
                <h3 class="card-title font-weight-bold">Disponibilidad de equipos</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i>
                  </button>
                </div>
              </div>
              <div class="card-body" style="display: block;">
                  <div class="row">
                           <div class="col-sm-12 col-md-6 col-lg-12">
                <h3><asp:Label runat="server" ID="lblPorcentaje"></asp:Label><label class="font-weight-normal">%</label><i class="fas fa-fw fa-tachometer-alt fa-2x text-black-50 float-right"></i>
</h3>
                              
                  </div>
                     <%--    <div class="col-sm-12 col-md-12 col-lg-3 float-right">
                      <div class="col-auto float-right">
                            <i class="fas fa-fw fa-tachometer-alt fa-4x text-black-50"></i>
                        </div>  
                  </div>--%>

                      <div class="col-sm-12 col-md-12 col-lg-12">
                                        <p><asp:Label runat="server" ID="lblOperando"></asp:Label> de <asp:Label runat="server"  ID="lblTotal"></asp:Label></p>

                      </div>
                  </div>
             

               
         
           <div class="progress">
                        <div class="progress-bar" runat="server" id="divprogress1">
                        </div>
              </div>
  </div>
            
    <!-- /.card-body -->
     <div class="card-footer mt-2">
                      <a href="Infraestructura/Disponibilidad/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

    </div>
            </div>
     
           </div>
                <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="produccion" visible="false">
<div class="card card-default shadow-sm">
              <div class="card-header">
                <h3 class="card-title font-weight-bold">Resumen mensual</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i>
                  </button>
                </div>
              </div>
              <div class="card-body" style="display: block;">
                  <div class="row">
                           <div class="col-sm-12 col-md-6 col-lg-6">
                <h3><asp:Label runat="server" ID="lblHoras"></asp:Label> <label class="font-weight-normal text-lg"> Horas</label>
</h3>
                     
                  </div>
                      <div class="col-sm-12 col-md-6 col-lg-6 mt-2">
                                         <div class="progress ">
                        <div class="progress-bar bg-green" runat="server" id="progresHora" >
                        </div>
              </div>  
                      </div>
               
                    <%--          <div class="col-sm-12 col-md-6 col-lg-6">
                <h3><asp:Label runat="server" ID="Label2" Text="74%"></asp:Label> <label class="font-weight-normal text-lg"> Eficiencia</label>
</h3>
                            
                  </div>--%>
                                            <%--<div class="col-sm-12 col-md-6 col-lg-6 mt-2">
                                                      <div class="progress">
                        <div class="progress-bar bg-gradient-blue" runat="server" id="div2" style="width:74%">
                        </div>
              </div> 
                                                </div>
                  --%>




             <%--               <div class="col-sm-12 col-md-6 col-lg-6">
                <h3><asp:Label runat="server" ID="Label3" Text="7657.85"></asp:Label> <label class="font-weight-normal text-lg"> Metros</label>
</h3>
                            
                  </div>--%>
                 <%--                                                 <div class="col-sm-12 col-md-6 col-lg-6 mt-2">
     <div class="progress">
                        <div class="progress-bar bg-yellow" runat="server" id="div3" style="width:70%">
                        </div>
              </div> 
</div>--%>
                   
                  </div>
             

               
         
          
  </div>
              <!-- /.card-body -->
     <div class="card-footer">
                      <a href="Produccion/Resumen/Index.aspx" class="float-right">Más información <i class="fas fa-arrow-circle-right"></i></a>

    </div>
            </div>
     
           </div>
       </div>
   </div>
</asp:Content>
