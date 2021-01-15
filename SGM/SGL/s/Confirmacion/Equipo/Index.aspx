<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGL.s.Confirmacion.Equipo.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
Censo de Equipos e Instrumentos.
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
                      <li class="breadcrumb-item "><a href="../../Inicio.aspx">SGL (Inicio)</a></li>
                      <li class="breadcrumb-item "><a href="../Inicio.aspx">Confirmación metrológica</a></li>

                     <li class="breadcrumb-item "><a>Censo de Equipos e Instrumentos.
</a></li>
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
                                                           <asp:LinkButton runat="server" CssClass="text-sm" PostBackUrl="~/s/Confirmacion/Equipo/Crear.aspx"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>

                                </div>
                                          <div class=" input-group col-sm-8 col-md-8 col-lg-4">
                   <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server"  OnClick="Buscar"  CssClass="btn btn-default btn-sm" />
            </div>
                    <div class="container col-12">
                        <br />
                
                        <div class=" table-responsive ">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table  table-bordered  table-striped table-sm  "
                                   id="gridEquipo"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de equipos."
                                     PageSize="10"
                                    GridLines="Horizontal"
                                      HeaderStyle-BackColor="#343a40"
                                     HeaderStyle-CssClass=" text-white"
                                     HeaderStyle-HorizontalAlign="Center"
                                    OnPageIndexChanging="gridEquipo_PageIndexChanging"
                                     AllowPaging="true"
                                 DataKeyNames="Id_Equipo"
                                     OnRowCommand="gridEquipo_RowCommand"
                                    >
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="260px" ItemStyle-Width="260px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                                     <asp:Button runat="server" Text="Ver" CssClass="btn btn-outline-primary" CommandName="Ver"/>
                                               <asp:Button runat="server" Text="Editar" CssClass="btn btn-outline-secondary" CommandName="Editar" />

                                               <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                        <asp:BoundField HeaderText="Marca" DataField="Marca" />
                                        <asp:BoundField HeaderText="Modelo" DataField="Modelo" />
                                        <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                                         <asp:BoundField HeaderText="No. Inventario" DataField="No_inventario" />
                                         <asp:BoundField HeaderText="Serie" DataField="Serie" />
                                         <asp:BoundField HeaderText="Prueba" DataField="Prueba" />
                                         <asp:BoundField HeaderText="Instalación" DataField="Instalacion" />
                                     
                                    </Columns>
                                            <PagerStyle HorizontalAlign = "Center"  />
                                </asp:GridView>
                                                                                              <asp:Button runat="server" CssClass="btn btn-default" ID="btnRegresar" PostBackUrl="~/s/Confirmacion/Inicio.aspx" Text="Regresar" />

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
</asp:Content>
