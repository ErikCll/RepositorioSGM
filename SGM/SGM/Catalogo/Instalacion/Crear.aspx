<%@ Page Title="" Language="C#" MasterPageFile="/Site1.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="SGM.Catalogo.Instalacion.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Crear Instalación
</asp:Content>
<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="mapeo">
                  <li class="breadcrumb-item active"><a href="Index.aspx">Instalación</a></li>
                  <li class="breadcrumb-item "><a>Crear</a></li>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <div class="col-lg-12">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                        
                        <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Nombre:</label>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre de instalación requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     
                         <div class="col-sm-12 col-md-4 col-lg-4">
                            <div class="form-group">
                              
                                <label>Región:</label>
                                <asp:DropDownList CssClass="form-control "   runat="server" ID="ddl_Region" DataTextField="Nombre" DataValueField="Id_Region"></asp:DropDownList>
                                   <asp:RequiredFieldValidator runat="server" ID="reqRegion" ControlToValidate="ddl_Region"
                                    ErrorMessage="Región requerida." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">

                        </div>
                  
                            <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Localización:</label>
                             <asp:TextBox runat="server" CssClass="form-control" ID="txtLocalizacion"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtLocalizacion"
                                    ErrorMessage="Localización requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-8"></div>
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
