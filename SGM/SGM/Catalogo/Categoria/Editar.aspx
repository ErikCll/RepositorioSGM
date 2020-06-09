<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="SGM.Catalogo.Categoria.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Editar Categoría
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
        <li class="breadcrumb-item active"><a href="Index.aspx">Categoría</a></li>
                  <li class="breadcrumb-item "><a>Editar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
                          <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-lg-12">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Datos de la categoría</h4>
                        </div>
                        <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Nombre:</label>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre de categoría requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     
                         <div class="col-sm-12 col-md-4 col-lg-4">
                            <div class="form-group">
                              
                                <label>Área:</label>
                                <asp:DropDownList CssClass="form-control "   runat="server" ID="ddl_Area" DataTextField="Nombre" DataValueField="Id_Area"></asp:DropDownList>
                                   <asp:RequiredFieldValidator runat="server" ID="reqArea" ControlToValidate="ddl_Area"
                                    ErrorMessage="Área requerida." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">

                        </div>
                  
                  
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
                                <a class="btn btn-default" href="Index.aspx">Regresar</a>
                            </div>
                        </div>
                        </div>
                    </div>
                      </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
