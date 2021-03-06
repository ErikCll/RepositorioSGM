﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="SGM.Confirmacion.CensoSis.Componente.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        Editar componente

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="../Index.aspx">Censo de sistema de medición</a></li>
                  <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="Regresar">Componente</asp:LinkButton></li>
                      <li class="breadcrumb-item"><a>Editar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
            <div class="col-lg-12">
                  <div class="card" >
                      <div class="card-header">
                                                      <h4>Datos del componente</h4>

                      </div>
                <div class="card-body">
                    <div class="row">
                        
                     
                     
                     <div class="col-sm-12 col-md-12 col-lg-4" id="Div1" runat="server" visible="false">
                            <div class="form-group">
                                <label class="font-weight-bold">Nombre:</label>

                                <asp:TextBox runat="server" class="form-control" id="txtNombre" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="reqNombre" ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre requerido." ForeColor="Red"  ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>


                            </div>
                        </div>
                          

       
                    
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" id="Div2" runat="server" visible="false">
                          
                            <div class="form-group">
                                <asp:Button class="btn btn-primary" id="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" OnClick="btnGuardar_Click"/>

                                <asp:Button runat="server" OnClick="Regresar" CssClass="btn btn-default" ID="Regresar1" Text="Regresar"/>


                            </div>
                        </div>
                       
                        <div class="col-sm-12 col-md-12 col-lg-4" id="Div3" runat="server" visible="false">
                            <div class="form-group">
                                <label class="font-weight-bold">Tipo de medidor:</label>

                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_Medidor" DataTextField="Nombre" DataValueField="Id_Medidor"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddl_Medidor"
                                    ErrorMessage="Tipo de medidor requerido." ForeColor="Red"  ValidationGroup="btnGuardar2" InitialValue="[Seleccionar]"></asp:RequiredFieldValidator>


                            </div>
                        </div>
                          

       
                    
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" id="Div4" runat="server" visible="false">
                          
                            <div class="form-group">
                                <asp:Button class="btn btn-primary" id="btnGuardar2" runat="server" Text="Guardar" ValidationGroup="btnGuardar2" OnClick="btnGuardar2_Click"/>

                                <asp:Button runat="server" OnClick="Regresar" CssClass="btn btn-default" ID="Regresar2" Text="Regresar" />


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
  
                             Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(){

                

              });

                 function DisableButton() {
                document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
                     document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando...";
                        document.getElementById("<%= btnGuardar2.ClientID %>").disabled = true;
                     document.getElementById("<%= btnGuardar2.ClientID %>").value = "Cargando...";
                        document.getElementById("<%= Regresar1.ClientID %>").disabled = true;
                     document.getElementById("<%= Regresar1.ClientID %>").value = "Cargando...";
                        document.getElementById("<%= Regresar2.ClientID %>").disabled = true;
                document.getElementById("<%=Regresar2.ClientID %>").value = "Cargando...";


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
