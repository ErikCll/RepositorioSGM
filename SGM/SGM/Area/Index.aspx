<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGM.Area.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Área
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
               <div class="col-lg-12">
                <div class="row">
                    <div class="container col-12">
                        
                       <asp:LinkButton runat="server" CssClass="text-sm" PostBackUrl="~/Area/Crear.aspx"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>
                          <div class="input-group float-right col-sm-4 col-md-4 col-lg-4">
                <div class="input-group btn">
                   <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server"  OnClick="Buscar"  CssClass="btn btn-default btn-sm" />
                </div>
            </div>
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-striped table-sm"
                                   GridLines="Vertical"
                                   id="gridArea"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de áreas."
                                     PageSize="10"
                                     OnPageIndexChanging="gridArea_PageIndexChanging"
                                     AllowPaging="true"
                                 DataKeyNames="Id_Area"
                                     OnRowCommand="gridArea_RowCommand"
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
                                        <asp:BoundField HeaderText="Código" DataField="Codigo" />
                                        <asp:BoundField HeaderText="Instalación" DataField="Instalacion" />
                                    </Columns>
                                            <PagerStyle HorizontalAlign = "Center" CssClass="" />
                                  
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
