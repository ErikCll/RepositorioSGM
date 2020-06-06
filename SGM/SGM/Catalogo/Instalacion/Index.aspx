<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGM.Catalogo.Instalacion.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Instalación        

</asp:Content>
<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="mapeo">
                  <li class=" breadcrumb-item"><a>Instalación</a></li>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">

        <ContentTemplate>
                                    <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-lg-12">
                <div class="row">
                    <div class="container col-12">
                        
                       <asp:LinkButton runat="server" CssClass="text-sm" PostBackUrl="~/Catalogo/Instalacion/Crear.aspx"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>
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
                                   id="gridInstalacion"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de instalaciones."
                                     PageSize="10"
                                     OnPageIndexChanging="gridInstalacion_PageIndexChanging"
                                     AllowPaging="true"
                                 DataKeyNames="Id_Instalacion"
                                     OnRowCommand="gridInstalacion_RowCommand"
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
                                        <asp:BoundField HeaderText="Localización" DataField="Localizacion" />
                                        <asp:BoundField HeaderText="Región" DataField="Region" />
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
