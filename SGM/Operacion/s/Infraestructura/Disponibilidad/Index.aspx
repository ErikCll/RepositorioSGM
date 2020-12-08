<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Operacion.s.Infraestructura.Disponibilidad.Index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Disponibilidad de equipos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
       <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
                  <li class="breadcrumb-item "><a href="../../Inicio.aspx">Operación (Inicio)</a></li>
                      <li class="breadcrumb-item "><a href="../Inicio.aspx">Infraestructura</a></li>

                     <li class="breadcrumb-item "><a>Disponibilidad de equipos</a></li>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
        <style>
          .zoom {
            transition: transform .2s; /* Animation */
            margin: 0 auto;
        }

            .zoom:hover {
                transform: scale(0.9); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
            }
    </style>
  <asp:UpdatePanel runat="server" UpdateMode="Conditional">

        <ContentTemplate>

            <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-12 col-md-6 col-lg-8"></div>
                    <div class= "input-group float-right col-sm-12 col-md-6 col-lg-4 float-right">
                              <div class="input-group btn">
                   <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="Buscar"  CssClass="btn btn-default btn-sm" />
                </div>
                    </div>
                 <div class="col-sm-12 col-md-12 col-lg-12"></div>
                  <asp:ListView runat="server" ID="listEquipos" OnItemCommand="listEquipos_ItemCommand" OnItemDataBound="listEquipos_ItemDataBound">
                      <ItemTemplate>
              
                        
                          <div class="col-12 col-sm-6 col-md-4 mt-3">
      
                              <asp:Label runat="server" Text='<%#Eval("Id_Equipo")%>' ID="lblIdEquipo" Visible="false"></asp:Label>
                               <asp:Label runat="server" Text='<%#Eval("Estatus")%>' ID="lblEstatus" Visible="false"></asp:Label>

                <asp:LinkButton runat="server" class="info-box shadow zoom h-100 " CommandName="Ver" >
              <span class="info-box-icon bg-gray elevation-1"><i class="fas fa-hdd"></i></span>

              <div class="info-box-content">
<%--                <label class="info-box-text text-dark font-weight-bold"><%#Eval("Nombre")%></label>--%>

                  <asp:Label Text='<%#Eval("Nombre")%>' runat="server" class=" text-dark font-weight-bold"></asp:Label>
                  <div runat="server" id="operando" visible="false">
                                          <label class="info-box-number text-sm text-green " runat="server"> <span class=" fas fa-cog text-sm text-green"></span> Operando</label>   
                      <br />
                   
                  </div>
                  <div runat="server" id="fallando" visible="false">
                      <div class="custom-control-inline">
                    <label class="info-box-number text-sm text-red" runat="server"> <span class=" fas fa-exclamation-triangle text-sm text-red"></span> Falla</label>   
                          <label class="text-sm text-dark font-weight-normal ml-1"> (Tipo:</label><label class="text-sm font-weight-bold text-dark ml-1"><%#Eval("TipoFalla")%></label> <label class="text-sm text-dark font-weight-normal">) </label>

                      </div>
                  


                      <br />
                  <label class="text-dark font-weight-normal text-sm">Fecha:</label><asp:Label runat="server" ID="lblFecha" class="font-weight-bold text-dark text-sm" Text='<%#Eval("Fecha")%>'></asp:Label>
                                 <label class="text-dark font-weight-normal text-sm">, Hora:</label><label class="font-weight-bold text-dark text-sm"><%#Eval("Hora")%></label>
                                                                                           <label class="text-dark font-weight-normal text-sm ">Fuera de operación:</label><label class="font-weight-bold text-dark text-sm ml-1"> <%#Eval("Transcurrido")%></label>

                  </div>
             


              </div>
              <!-- /.info-box-content -->
                </asp:LinkButton>
                <!-- /.info-box -->
            </div>
                      </ItemTemplate>
                    
                  </asp:ListView>

                    <div class="col-sm-12 col-md-12 col-lg-12 mt-1">
                                                                            <asp:Button runat="server" CssClass="btn btn-default mt-2" Text="Regresar" ID="btnRegresar" PostBackUrl="~/s/Infraestructura/Inicio.aspx" />

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
               
           
         
            </script>  
</asp:Content>
