<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditarCuestionario.aspx.cs" Inherits="SGM.Competencia.CensoAct.Evaluacion.EditarCuestionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Editar Cuestionario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
            <div class="col-lg-12">
                <div class="row">
                                   <div class=" col-sm-8 col-md-12 col-lg-8">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Pregunta:</h4>
                               <label runat="server" id="lblContador"></label>
                        </div>
                        <div class="col-8 col-md-8 col-lg-8">
                            <div class="form-group">
                                      <textarea runat="server" CssClass="form-control form-control-lg" ID="txtPregunta" onkeypress="return AllowAlphabet(event)" MaxLength="250" style="height:100px;width:330px"></textarea>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtPregunta"
                                    ErrorMessage="Pregunta requerida." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     <div class="col-sm-4 col-md-4 col-lg-4"></div>
                           <div class="col-sm-4 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label>Respuesta:</label>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-6 col-lg-6">

                        </div>
                               <div class="col-sm-6 col-md-6 col-lg-6" runat="server" id="divMultiple" >
                                 <div class="form-group">
                                     <label>Respuesta 1:</label>
                                     <asp:TextBox runat="server" CssClass="form-control" ID="txt1" BorderColor="Green" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                     <asp:Label runat="server" ID="IdR1"></asp:Label>
                                 </div>
                                    <div class="form-group">
                                     <label>Respuesta 2:</label>
                                     <asp:TextBox runat="server" CssClass="form-control" ID="txt2" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                      <asp:Label runat="server" ID="IdR2"></asp:Label>
 
                                 </div>
                                    <div class="form-group">
                                     <label>Respuesta 3:</label>
                                     <asp:TextBox runat="server" CssClass="form-control" ID="txt3" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                         <asp:Label runat="server" ID="IdR3"></asp:Label>
                                 </div>
                                    <div class="form-group">
                                     <label>Respuesta 4:</label>
                                     <asp:TextBox runat="server" CssClass="form-control" ID="txt4" onkeypress="return AllowAlphabet(event)" MaxLength="200"></asp:TextBox>
                                         <asp:Label runat="server" ID="IdR4"></asp:Label>
                                 </div>
                        </div>
                                                      <div class="col-sm-6 col-md-6 col-lg-6" runat="server" id="DivTrue" visible="false">
                                                        <div class="form-group ">
                                                            <asp:CheckBox runat="server" id="chkTrue"/>
                                                            <asp:Label CssClass=" font-weight-bold" runat="server" ID="lblVerdadero" Text="Verdadero"></asp:Label>
                                                            <asp:Label runat="server" ID="IdTrue"></asp:Label>
                                                        </div>
                                                          <div class="form-group ">
                                                            <asp:CheckBox runat="server" ID="chkFalse"/>
                                                        <asp:Label CssClass=" font-weight-bold" runat="server" ID="lblFalso" Text="Falso"></asp:Label>
                                                                 <asp:Label runat="server" ID="IdFalse"></asp:Label>


                                                        </div>
                                                     </div>
                                                                            <div class="col-sm-12 col-md-12 col-lg-12">

                        </div>                
                        <div class="col-sm-12 col-md-12 col-lg-12">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar cambios" ID="btnGuardar" OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
                        <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" OnClick="Regresar" />
                            </div>
                        </div>
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
                var chkTrue = $("#<%=chkTrue.ClientID%>");
                   
                var chkFalse = $("#<%=chkFalse.ClientID%>");
                     chkTrue.click(function () {
                       chkFalse.prop('checked', false);
             

                   });
                   chkFalse.click(function () {
                         if (chkFalse.prop('checked')==false) {
            
                         }
                         else {
                               chkTrue.prop('checked', false);

                          
                         }

                });

                $('#ordered li').each(function(i,el){
                 el.id = i+1;
              });

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
                     (keyEntry == 46) || (keyEntry == 32) || keyEntry == 45 || (keyEntry == 32) || keyEntry == 45 || keyEntry == 63 || keyEntry == 33 || keyEntry == 168

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
