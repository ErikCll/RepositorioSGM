﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="SGM.Competencia.CensoAct.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Crear Censo de actividad
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="Index.aspx">Censo de actividad</a></li>
                  <li class="breadcrumb-item "><a>Crear</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <div class="col-lg-12">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Datos del censo de actividad</h4>
                        </div>
                        <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Nombre:</label>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre de actividad requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     
                         <div class="col-sm-12 col-md-4 col-lg-4">
                          <label>Instalación:</label>
                             <asp:DropDownList runat="server" ID="ddl_Instalacion" DataTextField="Nombre" DataValueField="Id_Instalacion" CssClass="form-control" AutoPostBack="true"
                                 OnSelectedIndexChanged="ddl_Instalacion_SelectedIndexChanged" ></asp:DropDownList>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-4">
                              <div class="form-group">
                              
                                <label>Área:</label>
                                <asp:DropDownList CssClass="form-control "   runat="server" ID="ddl_Area" DataTextField="Nombre" DataValueField="Id_Area"></asp:DropDownList>
                                   <asp:RequiredFieldValidator runat="server" ID="reqArea" ControlToValidate="ddl_Area"
                                    ErrorMessage="Área requerida." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                                        
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
                                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" PostBackUrl="~/Competencia/CensoAct/Index.aspx" />
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
