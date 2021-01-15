<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="SASISOPA.s.RequisitoLegal.Requisito.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Editar Requisito
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
       <li class="breadcrumb-item active"><a href="Index.aspx">Requisito</a></li>
                  <li class="breadcrumb-item "><a>Editar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
                                                            <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-lg-12">
                  <div class="card" >
                      <div class="card-header">
                            <h4>Datos del documento regulador</h4>
                      </div>
                <div class="card-body">
                    <div class="row">
                      
                        <div class="col-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label>Nombre del Requisito:</label>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtNombre"
                                    ErrorMessage="Nombre requerido." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     
                      <div class="col-sm-12 col-md-12 col-lg-12"></div>
                    
      
                        <div class="col-sm-12 col-md-12 col-lg-12"></div>
                                  <div class="col-sm-8 col-md-3 col-lg-3" id="Div1" runat="server" visible="false">
                            <div class="form-group">
                                <label class="font-weight-bold">Vigencia Regulatoria:</label>
                                <asp:DropDownList runat="server" ID="ddl_Regulatoria" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-2 col-md-2 col-lg-2" id="Div2" runat="server" visible="false">
                            <div class="form-group">
                                <label class="font-weight-bold">Cantidad:</label>
                                   <asp:TextBox runat="server" ID="txtRegulatoria" CssClass="form-control" onkeypress="return soloNumeros(event)" MaxLength="2"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" ID="reqRegulatoria" ControlToValidate="txtRegulatoria"
                                    ErrorMessage="Cantidad requerida." ForeColor="Red" ValidationGroup="btnGuardar" Enabled="false"></asp:RequiredFieldValidator>
                            </div>

                        </div>

                            <div class="col-sm-8 col-md-3 col-lg-3" id="Div3" runat="server" visible="false">
                            <div class="form-group">
                                <label class="font-weight-bold">Vigencia Operativa:</label>
                                <asp:DropDownList runat="server" ID="ddl_Operativa" CssClass="form-control"></asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-sm-2 col-md-2 col-lg-2" id="Div4" runat="server" visible="false">
                            <div class="form-group">
                                <label class="font-weight-bold">Cantidad:</label>
                                  <asp:TextBox runat="server" ID="txtOperativa" CssClass="form-control" onkeypress="return soloNumeros(event)" MaxLength="2"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" ID="reqOperativa" ControlToValidate="txtOperativa"
                                    ErrorMessage="Cantidad requerida." ForeColor="Red" ValidationGroup="btnGuardar" Enabled="false"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                                        
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
                                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" PostBackUrl="~/s/RequisitoLegal/Requisito/Index.aspx" />
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
                     (keyEntry == 46) || (keyEntry == 32) || keyEntry == 45 || (keyEntry == 32) || keyEntry == 45 || keyEntry == 47
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

                                             function soloNumeros(e){
  var key = window.event ? e.which : e.keyCode;
  if (key < 48 || key > 57) {
    e.preventDefault();
  }
}
            </script>  
</asp:Content>
