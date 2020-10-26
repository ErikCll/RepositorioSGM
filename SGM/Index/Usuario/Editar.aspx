<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="SAM.Usuario.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Editar Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="Index.aspx">Usuario</a></li>
                  <li class="breadcrumb-item "><a>Editar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-lg-12">
                <div class="card">
                    <div class="card-header">
                        <h4>Datos del usuario</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">

                            <div class="col-12 col-md-12 col-lg-4">
                                <div class="form-group">
                                    <label>Nombre:</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtNombre"
                                        ErrorMessage="Nombre requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-12 col-md-12 col-lg-4">
                                <div class="form-group">
                                    <label>Apellido paterno:</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidoPaterno" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtApellidoPaterno"
                                        ErrorMessage="Apellido paterno requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-12 col-md-12 col-lg-4">
                                <div class="form-group">
                                    <label>Apellido materno:</label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtApellidoMaterno" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>

                                </div>
                            </div>


                            <div class="col-12 col-md-12 col-lg-4">
                                <div class="form-group">
                                    <label>Correo electrónico:</label>
                                    <input class="form-control " id="txtCorreo" runat="server" maxlength="60" onkeypress="return AllowAlphabet(event)" type="email">

                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator55" ControlToValidate="txtCorreo"
                                        ErrorMessage="Correo electrónico requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                </div>
                            </div>



                            <div class="col-sm-12 col-md-12 col-lg-8">
                            </div>


                            <div class="col-sm-12 col-md-12 col-lg-6">
                                <div class="form-group">
                                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" ValidationGroup="btnGuardar" OnClick="btnGuardar_Click" />
<%--                                    <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" PostBackUrl="~/Usuario/Index.aspx" />--%>
                                                                        <a class="btn btn-default" href="Index.aspx">Regresar</a>

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
      <%--      document.getElementById("<%= btnRegresar.ClientID %>").disabled = true;
            document.getElementById("<%= btnRegresar.ClientID %>").value = "Cargando...";--%>


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
                || (keyEntry == 218) || (keyEntry >= 48 && keyEntry <= 57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64)
                return true;
            else {
                return false;
            }
        }
     </script>
</asp:Content>
