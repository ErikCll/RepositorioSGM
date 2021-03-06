﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGM.Confirmacion.CensoSis.Componente.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      Componente<br />
    <label class="font-weight-normal text small">Censo de sistema de medición: </label>
    <asp:Label runat="server" ID="lblCensoSistema" CssClass=" font-weight-bold text small"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="../Index.aspx">Censo de sistema de medición</a></li>
    <li class="breadcrumb-item "><a>Componente</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
      <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Literal ID="litControl" runat="server"></asp:Literal>
                 <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">

                        <div class="card ">
                            <div class="card-body">

                                <div class="row">
                                    <div class="col-sm-4 col-md-4 col-lg-8">
                                                                <asp:LinkButton runat="server" CssClass="text-sm"  OnClick="CrearComponente"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>

                                        </div>
                                        <div class="container col-12">
                        <br />
                        <div class=" table-responsive">
                            <div style="overflow: auto; height: auto">
                                <asp:GridView ID="gridComponente"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                      CssClass=" table table-bordered table-striped  table-sm"
                                                    HeaderStyle-BackColor="#343a40"
                                                    HeaderStyle-CssClass=" text-white"
                                                    GridLines="Horizontal"
                                                    HeaderStyle-HorizontalAlign="Center"
                                    EmptyDataText="Sin registro de componentes."
                                    PageSize="10"
                                    DataKeyNames="Id_Componente"
                                    OnPageIndexChanging="gridComponente_PageIndexChanging"
                                    AllowCustomPaging="false"
                                    AllowPaging="true"
                                    OnRowCommand="gridComponente_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="260px" ItemStyle-Width="260px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                                <asp:Button runat="server" Text="Editar" CssClass="btn btn-outline-secondary" CommandName="Editar" />

                                                <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                        <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                                     

                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" CssClass="" />

                                </asp:GridView>
                                   <a class="btn btn-default" href="../Index.aspx">Regresar</a>

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
