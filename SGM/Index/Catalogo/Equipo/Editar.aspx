<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="SAM.Catalogo.Equipo.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Editar Equipo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="Index.aspx">Equipo</a></li>
                  <li class="breadcrumb-item "><a>Editar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Literal ID="litControl" runat="server"></asp:Literal>
            <div class="col-lg-12">
                  <div class="card" >
                      <div class="card-header">
                            <h4>Datos del equipo</h4>
                      </div>
                <div class="card-body">
                    <div class="row">
                         
                        <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Nombre:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre de equipo requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Marca:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtMarca" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                              <%--    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtMarca"
                                    ErrorMessage="Marca requerida." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>


                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Modelo:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtModelo" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                              <%--    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtModelo"
                                    ErrorMessage="Modelo requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>

                        
                         <div class="col-sm-12 col-md-4 col-lg-4">
                            <div class="form-group">
                              
                                <label>Tipo:</label>
                                <asp:DropDownList CssClass="form-control "  runat="server" ID="ddl_Tipo" ></asp:DropDownList>
                                   <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddl_Tipo"
                                    ErrorMessage="Tipo requerido." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>

                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>No. Inventario:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtNoInventario" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                               <%--   <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtNoInventario"
                                    ErrorMessage="No. Inventario requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                     
                         <div class="col-sm-12 col-md-4 col-lg-4">
                            <div class="form-group">
                              
                                     <label>Serie:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtSerie" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                               <%--   <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="txtSerie"
                                    ErrorMessage="Serie requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>

                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Prueba:</label>
                                          <asp:TextBox runat="server" CssClass="form-control" ID="txtPrueba" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                              <%--    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtPrueba"
                                    ErrorMessage="Prueba requerida." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>

                           <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Instalación:</label>
                         <asp:DropDownList CssClass="form-control "   runat="server" ID="ddl_Instalacion" DataTextField="Nombre" DataValueField="Id_Instalacion"></asp:DropDownList>
                                   <asp:RequiredFieldValidator runat="server" ID="reqInstalacion" ControlToValidate="ddl_Instalacion"
                                    ErrorMessage="Instalación requerida." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-8">

                        </div>
                  
                         
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
                                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" PostBackUrl="~/Catalogo/Equipo/Index.aspx" />
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
                document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
                    document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando...";
                     document.getElementById("<%= btnRegresar.ClientID %>").disabled = true;
                document.getElementById("<%= btnRegresar.ClientID %>").value = "Cargando...";


  }
  window.onbeforeunload = DisableButton;
                

                function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
                 if (((keyEntry >= 65) && (keyEntry <= 90)) ||
                     ((keyEntry >= 97) && (keyEntry <= 122)) ||
                     (keyEntry == 46) || (keyEntry == 32) || keyEntry == 45 || (keyEntry == 32) || keyEntry == 45
                     || (keyEntry == 241) || keyEntry == 209
                     || (keyEntry == 225) || keyEntry == 233
                     || (keyEntry == 237) || keyEntry == 243
                     || (keyEntry == 243) || keyEntry == 250
                     || (keyEntry == 193) || keyEntry == 201
                     || (keyEntry == 205) || keyEntry == 211
                     || (keyEntry == 218) ||(keyEntry >=48 && keyEntry<=57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64) 
                return true;
            else {
                return false;
            }
        }
            </script> 
</asp:Content>
