<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ControlEditar.aspx.cs" Inherits="SGM.Competencia.CensoAct.ControlEditar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Editar control de versión
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
      <li class="breadcrumb-item active"><a href="Index.aspx">Censo de actividad</a></li>
                  <li class="breadcrumb-item active"><asp:LinkButton runat="server" onclick="Regresar">Control de versiones</asp:LinkButton></li>
                      <li class="breadcrumb-item"><a>Editar</a></li>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
      <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
                                                <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-lg-12">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                          <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Datos del control de versión</h4>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Código:</label>

                                <asp:TextBox runat="server" class="form-control" id="txtCodigo"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="reqCodigo" ControlToValidate="txtCodigo"
                                    ErrorMessage="Código requerido." ForeColor="Red"  ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>


                            </div>
                        </div>

                       
                        <div class="col-sm-12 col-md-12 col-lg-4">
                       
                        </div>

                                                <div class="col-sm-12 col-md-12 col-lg-4"></div>

               
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                          
                            <div class="form-group">
                                <asp:Button class="btn btn-primary" id="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" OnClick="btnGuardar_Click"/>
                                <asp:Button runat="server" CssClass=" btn btn-default" ID="btnRegresar" Text="Regresar"  OnClick="Regresar"/>


                            </div>
                        </div>
                    </div>
                      </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
