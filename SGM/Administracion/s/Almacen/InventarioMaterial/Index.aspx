<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Administracion.s.Almacen.InventarioMaterial.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Inventario de material
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
                  <li class="breadcrumb-item "><a href="../../Inicio.aspx">Administración</a></li>
                     <li class="breadcrumb-item "><a>Inventario de material</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
               <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">

                         <div class="card ">
                    <div class="card-body">
                        
                            <div class="row">
                                                                           <div class="col-sm-4 col-md-4 col-lg-8">


                                                                               </div>

                                                                          <div class=" input-group col-sm-8 col-md-8 col-lg-4">
                                                                                     <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server"  OnClick="Buscar"  CssClass="btn btn-default btn-sm" />
                                                                              </div>

                                    <div class="container col-12">
                        
<%--                       <asp:LinkButton runat="server" CssClass="text-sm" PostBackUrl="~/s/Confirmacion/CensoSis/Crear.aspx"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>--%>
              <br />
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-bordered table-striped table-sm"
                                   HeaderStyle-BackColor="#343a40"
                                     HeaderStyle-CssClass=" text-white"
                                    GridLines="Horizontal"
                                    id="gridMaterial"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de inventario."
                                     PageSize="10"
                                     OnPageIndexChanging="gridMaterial_PageIndexChanging"
                                     AllowPaging="true"
                                 DataKeyNames="Id_Material"
                                        OnRowCommand="gridMaterial_RowCommand"

                                    >
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" ItemStyle-Width="200px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                              <asp:Button runat="server" Text="Ver" CssClass="btn btn-outline-primary" CommandName="Ver"/>


                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                        <asp:BoundField HeaderText="Código" DataField="Codigo" />
                                        <asp:BoundField HeaderText="No. Parte" DataField="NumParte" />
                                        <asp:BoundField HeaderText="Tipo de Unidad" DataField="Unidad" />
                                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                                        <asp:BoundField HeaderText="Total" DataField="Total" />


                                     
                                       
                                    
                                  
                                    </Columns>
                                            <PagerStyle HorizontalAlign ="Center" CssClass="" />
                                  
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                                </div>


                        </div>

                             </div>


                        </div>
                
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
          <script type="text/javascript">
               Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
          function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

         
                  </script>  

</asp:Content>

