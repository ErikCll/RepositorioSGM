<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="SGM.Catalogo.Empleado.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Editar Empleado
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="Index.aspx">Empleado</a></li>
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
                        
                        <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Nombre:</label>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre de empleado requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Apellido Paterno:</label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidoPaterno"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtApellidoPaterno"
                                    ErrorMessage="Apellido Paterno requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Apellido Materno:</label>
                                 <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidoMaterno"></asp:TextBox>
                                  
                            </div>
                        </div>
                     
                         <div class="col-sm-12 col-md-4 col-lg-4">
                            <div class="form-group">
                              
                                <label>Instalación:</label>
                                <asp:DropDownList CssClass="form-control "   runat="server" ID="ddl_Instalacion" DataTextField="Nombre" DataValueField="Id_Instalacion"></asp:DropDownList>
                                   <asp:RequiredFieldValidator runat="server" ID="reqInstalacion" ControlToValidate="ddl_Instalacion"
                                    ErrorMessage="Instalación requerida." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">

                        </div>
                  
                          
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
                                <a class="btn btn-default">Limpiar</a>
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
