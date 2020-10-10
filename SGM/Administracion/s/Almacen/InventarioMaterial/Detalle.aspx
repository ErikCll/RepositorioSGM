<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Administracion.s.Almacen.InventarioMaterial.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Detalle de inventario<br />
    <label class="font-weight-normal text small">Material: </label>
    <asp:Label runat="server" ID="lblMaterial" CssClass=" font-weight-bold text small"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="Index.aspx">Inventario de material</a></li>
                  <li class="breadcrumb-item "><a>Detalle</a></li>
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

                                                                              </div>

                                 <div class="container col-12">
                        
                 <br />
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-bordered table-striped table-sm"
                                   id="gridInventario"
                                    HeaderStyle-BackColor="#343a40"
                                     HeaderStyle-CssClass=" text-white"
                                    GridLines="Horizontal"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de inventario."
                                     PageSize="10"
                                     OnPageIndexChanging="gridInventario_PageIndexChanging"
                                     AllowPaging="true"
                                 DataKeyNames="Id_Inventario"
                                 OnRowDataBound="gridInventario_RowDataBound"
                                     OnRowCommand="gridInventario_RowCommand"

                                    >
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" ItemStyle-Width="200px" ControlStyle-Width="76px">
                                            <ItemTemplate>

                                               <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                   <asp:BoundField HeaderText="Fecha de ingreso" DataField="FechaIngreso" />
                                        <asp:BoundField HeaderText="Costo" DataField="Costo" />
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="QR" HeaderStyle-CssClass="text-center">
                                            <ItemTemplate>
                                         <asp:Image runat="server" ID="imageBarCode"  />
                                                <asp:Label runat="server" ID="lblCode" Text='<%# Eval("QRCode") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                       
                                    
                                  
                                    </Columns>
                                            <PagerStyle HorizontalAlign ="Center" CssClass="" />
                                  
                                </asp:GridView>
                                <asp:Button runat="server" CssClass="btn btn-default" ID="btnRegresar" Text="Regresar" PostBackUrl="~/s/Almacen/InventarioMaterial/Index.aspx" />
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
                 Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {



          });
         function DisableButton() {
              
                     document.getElementById("<%= btnRegresar.ClientID %>").disabled = true;
                document.getElementById("<%= btnRegresar.ClientID %>").value = "Cargando...";


  }
  window.onbeforeunload = DisableButton;
                
                  </script>  

</asp:Content>

