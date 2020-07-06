<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VCuestionario.aspx.cs" Inherits="SGM.Competencia.CensoAct.VCuestionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Validar Cuestionario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <style>
        .RBL label
{
    margin-left:3px;

        }

    </style>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
                        <div class="col-lg-12">
                <div class="row">
                    <ol class="col-12">
                                                     <asp:ListView runat="server" ID="lstPreguntas" OnItemDataBound="lstPreguntas_ItemDataBound">
                        <ItemTemplate>
                                                                <div class=" container col-8">
                       <div class=" col-sm-12 col-md-12 col-lg-12">
                  <div class="card shadow border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-lg-12">
                             <li>
              <label class=" font-weight-bold"><%# Eval("Pregunta") %></label>  <asp:LinkButton runat="server" CssClass="ion-edit" ToolTip="Editar" OnClick="Editar"></asp:LinkButton> <asp:LinkButton runat="server" CssClass="ion-android-delete text-red" ToolTip="Eliminar" OnClick="Eliminar"></asp:LinkButton>  
                                                                 <asp:Label runat="server" ID="lblIdPregunta" Text='<%# Eval("Id_Pregunta") %>'></asp:Label>
                                                                 <asp:Label runat="server" ID="lblTipoPregunta" Text='<%# Eval("TipoPregunta") %>'></asp:Label>

<asp:RadioButtonList runat="server" ID="radioList" DataTextField="Respuesta" DataValueField="Respuesta" TextAlign="Right" CssClass="RBL" Enabled="false"> </asp:RadioButtonList>

                      </li>
                            
                        </div>
                     
                                   
                     
                        </div>
                    </div>
                      </div>
            </div>
                    </div>

                        </ItemTemplate>
                    </asp:ListView>

                    </ol>
                    <div class="container">
                                 <div class="col-sm-12 col-md-12 col-lg-12">
                       <div class="form-group float-right">
                                <asp:Button runat="server" CssClass="btn btn-success" Text="Finalizar" ID="btnFinalizar" Visible="false" OnClick="Finalizar" />
                       <asp:Button runat="server" CssClass="btn btn-default" Text="Regresar" OnClick="Regresar" ID="btnRegresar" />
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
                document.getElementById("<%= btnFinalizar.ClientID %>").disabled = true;
                document.getElementById("<%= btnFinalizar.ClientID %>").value = "Cargando...";
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
