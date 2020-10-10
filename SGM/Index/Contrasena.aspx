<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Contrasena.aspx.cs" Inherits="SAM.Contrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Cambiar contraseña
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <style>
        ul,
        li {
            margin: 0;
            padding: 0;
            list-style-type: none;
        }



        #pswd_info {
            position: absolute;
            /* IE Specific */
            padding: 10px;
            background: #fefefe;
            font-size: .875em;
            border-radius: 5px;
            box-shadow: 0 1px 3px #ccc;
            border: 1px solid #ddd;
        }

            #pswd_info h4 {
                margin: 0 0 10px 0;
                padding: 0;
                font-weight: normal;
            }

            #pswd_info::before {
                content: "\25B2";
                position: absolute;
                top: -12px;
                font-size: 14px;
                line-height: 14px;
                color: #ddd;
                text-shadow: none;
                display: block;
            }

        .invalid {
            line-height: 24px;
            color: #ec3f41;
        }

        .valid {
            line-height: 24px;
            color: #3a7d34;
        }

        #pswd_info {
            display: none;
        }
    </style>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
            <ContentTemplate>
                <asp:Literal ID="litControl" runat="server"></asp:Literal>

                        <div class="col-lg-12">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-lg-4">
                                <div class="form-group">
                                    <label>Contraseña actual:</label>
                                    <asp:TextBox runat="server" ID="txtActual" CssClass="form-control" TextMode="Password" MaxLength="16" onkeypress="return AllowAlphabet(event)"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtActual"
                                        ErrorMessage="Contraseña actual requerida." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>                     

                                </div>
                                                    </div>
                        
                                                <div class="col-sm-12 col-md-12 col-lg-4">

                                <div class="form-group">
                                    <label>Nueva contrseña:</label>
                                       <asp:TextBox class="form-control " ID="txtNueva" runat="server" TextMode="Password" MaxLength="16" onkeypress="return AllowAlphabet2(event)">
                   
                                    </asp:TextBox>
                                    <div id="pswd_info" class="dropdown-menu shadow " style="margin-top: -30px">
                                        <h4>La contraseña debería cumplir con los siguientes requerimientos:</h4>
                                        <ul>
                                            <li id="letter" class="invalid">Al menos <strong>una letra</strong>
                                            </li>
                                            <li id="capital" class="invalid">Al menos <strong>una letra mayúscula</strong>
                                            </li>
                                            <li id="number" class="invalid">Al menos <strong>un número</strong>
                                            </li>
                                            <li id="length" class="invalid">Mínimo <strong>8 carácteres</strong>
                                            </li>
                                        </ul>
                                    </div>
                                    <asp:RequiredFieldValidator ForeColor="red" runat="server" ControlToValidate="txtNueva" ValidationGroup="btnGuardar"  ErrorMessage="Contraseña requerida."></asp:RequiredFieldValidator>
                                </div>
                             </div>
                                                <div class="col-sm-12 col-md-12 col-lg-4">

                                <div class="form-group">
                                    <label class="font-weight-bold">Confirmar contraseña:</label>
                                    <asp:TextBox class="form-control " ID="txtConfirmar" runat="server" TextMode="Password" MaxLength="16" onkeypress="return AllowAlphabet2(event)">
                   
                                    </asp:TextBox>



                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtConfirmar"
                                        ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ValidationGroup="btnGuardar" ForeColor="Red" runat="server" ControlToCompare="txtNueva" ControlToValidate="txtConfirmar" ErrorMessage="No coinciden las contraseñas"></asp:CompareValidator>

                                </div>
                                                    </div>
                    </div>
                       
                        
                    
                    <div class="row">
                        <div class="col-sm-12 col-md-6">
                            <div class="form-group">

                                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" OnClick="btnGuardar_Click" />
<%--                                <asp:Button ID="btnCancelar" runat="server" class="btn btn-default" Text="Regresar"  />--%>
     <asp:Button class="btn btn-default" ID="btnRegresar" runat="server" Text="Regresar" PostBackUrl="~/Inicio.aspx"></asp:Button>  
<%--                                     <a class="btn btn-default" href="#" onClick="history.back();">Regresar</a>  --%>

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
                          var longitud = false,
                minuscula = false,
                numero = false,
                mayuscula = false;
            $("#<%=txtNueva.ClientID%>").keyup(function () {
                var pswd = $(this).val();
                if (pswd.length < 8) {
                    $('#length').removeClass('valid').addClass('invalid');
                    longitud = false;
                } else {
                    $('#length').removeClass('invalid').addClass('valid');
                    longitud = true;
                }

                //validate letter
                if (pswd.match(/[A-z]/)) {
                    $('#letter').removeClass('invalid').addClass('valid');
                    minuscula = true;
                } else {
                    $('#letter').removeClass('valid').addClass('invalid');
                    minuscula = false;
                }

                //validate capital letter
                if (pswd.match(/[A-Z]/)) {
                    $('#capital').removeClass('invalid').addClass('valid');
                    mayuscula = true;
                } else {
                    $('#capital').removeClass('valid').addClass('invalid');
                    mayuscula = false;
                }

                //validate number
                if (pswd.match(/\d/)) {
                    $('#number').removeClass('invalid').addClass('valid');
                    numero = true;
                } else {
                    $('#number').removeClass('valid').addClass('invalid');
                    numero = false;
                }
            }).focus(function () {
                $('#pswd_info').show();
            }).blur(function () {
                $('#pswd_info').hide();
            });
            $("#<%=txtNueva.ClientID%>").keyup(function () {
                if (longitud && minuscula && numero && mayuscula) {
                    $("#<%=btnGuardar.ClientID%>").removeAttr('disabled');

                           } else {
                               $("#<%=btnGuardar.ClientID%>").attr('disabled', 'disabled');
                }
            })


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
                (keyEntry == 46) || (keyEntry == 46) || keyEntry == 45 || (keyEntry == 46) || keyEntry == 45
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
  function mostrarContrasena(){
      var tipo = document.getElementById("<%=txtConfirmar.ClientID%>");

      if(tipo.type == "password"){
          tipo.type = "text";
      }
     
        }
         function NomostrarContrasena(){
          var tipo = document.getElementById("<%=txtConfirmar.ClientID%>");

      if(tipo.type == "text"){
          tipo.type = "password";
      }
     
            }

    
        </script>
</asp:Content>
