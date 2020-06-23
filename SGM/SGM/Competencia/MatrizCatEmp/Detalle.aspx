<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SGM.Competencia.MatrizCatEmp.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        Detalle Matriz Categoría-Empleado

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
         <li class="breadcrumb-item active"><a href="Index.aspx">Matriz Categoría-Empleado</a></li>
                  <li class="breadcrumb-item "><a>Detalle</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
          <asp:UpdatePanel runat="server" UpdateMode="Conditional">

        <ContentTemplate>

            <div class="col-lg-12">
                <div class="row">
                    <div class="container col-12">

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
                                   id="gridCategoria"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de categorías."
                                     PageSize="10"
                                     OnPageIndexChanging="gridCategoria_PageIndexChanging"
                                     AllowPaging="true"
                                 DataKeyNames="Id_Categoria"
                                     OnRowCommand="gridCategoria_RowCommand"
                                    >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Categoría">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkNombre" Text='<%# Eval("Nombre") %>' CommandName="AgregarAct"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:BoundField HeaderText="Área" DataField="Area" />
                                    </Columns>
                                            <PagerStyle HorizontalAlign = "Center" CssClass="" />
                                </asp:GridView>
                                                                <a class="btn btn-default" href="Index.aspx">Regresar</a>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
