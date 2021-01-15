<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="VCuestionario.aspx.cs" Inherits="SASISOPA.s.ControlAct.CensoAct.Evaluacion.VCuestionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Validar Cuestionario (Paso 3)
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
       <li class="breadcrumb-item active"><asp:LinkButton runat="server" onclick="Regresa2">Evaluación</asp:LinkButton></li>
           <li class="breadcrumb-item active"><asp:LinkButton runat="server" onclick="Regresar">Paso 2</asp:LinkButton></li>
                          <li class="breadcrumb-item"><a>Paso 3</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <style>
        .RBL label
{
    margin-left:3px;
    display:inline;
        }

    </style>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
                        <div class="col-lg-12">
                <div class="row">
                    <ol class="col-sm-12 col-md-12 col-lg-12 ">
                                                     <asp:ListView runat="server" ID="lstPreguntas" OnItemDataBound="lstPreguntas_ItemDataBound">
                        <ItemTemplate>
                                                                <div class=" container col-8">
                       <div class=" col-sm-12 col-md-12 col-lg-12">
  
                  <div class="card" >
                <div class="card-body">
                             <li class="ml-1" >
                                  <asp:LinkButton runat="server" CssClass="ion-edit ml-1" ToolTip="Editar" OnClick="Editar"></asp:LinkButton> <asp:LinkButton runat="server" CssClass="ion-android-delete text-red ml-1" ToolTip="Eliminar" OnClick="Eliminar"></asp:LinkButton>    
                                   <span class="font-weight-bold "><%# Eval("Pregunta") %>  </span>  
                                                                 <asp:Label runat="server" ID="lblIdPregunta" Text='<%# Eval("Id_Pregunta") %>' Visible="false"></asp:Label>
                                                                 <asp:Label runat="server" ID="lblTipoPregunta" Text='<%# Eval("TipoPregunta") %>' Visible="false"></asp:Label>
             

<asp:RadioButtonList runat="server" ID="radioList" DataTextField="Respuesta" DataValueField="Respuesta" TextAlign="Right" CssClass="RBL mt-2" Enabled="false" CellPadding="4"> </asp:RadioButtonList>

                      </li>
                            
                     
                                   
                     
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
