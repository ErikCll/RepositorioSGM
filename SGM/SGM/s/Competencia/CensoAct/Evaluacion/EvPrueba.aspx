<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="EvPrueba.aspx.cs" Inherits="SGM.Competencia.CensoAct.Evaluacion.EvPrueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Evaluación de Prueba
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <style>
        .RBL label {
            margin-left: 3px;
        }
    </style>

    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick" Enabled="false"></asp:Timer>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">

        <ContentTemplate>

            <asp:Literal runat="server" ID="litControl"></asp:Literal>

            <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <asp:Button runat="server" CssClass="btn btn-danger" ID="btnTime" />
                        <%--                                                                    Date: <asp:Label Id="LabelDateTime" runat="server"></asp:Label>--%>
                    </div>

                    <div class="col-12">
                        <asp:ListView runat="server" ID="lstPreguntas" OnItemDataBound="lstPreguntas_ItemDataBound" OnPagePropertiesChanging="lstPreguntas_PagePropertiesChanging">

                            <ItemTemplate>
                                <div class=" container col-8">
                                    <div class=" col-sm-12 col-md-12 col-lg-12">
                                        <div class="card shadow border-top border-dark">
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-sm-12 col-md-12 col-lg-12">

                                                        <asp:Label runat="server" ID="lblContador" Text='<%# Eval("ORDEN") %>'></asp:Label>.

              <label class=" font-weight-bold"><%# Eval("Pregunta") %></label>
                                                        <asp:Label runat="server" ID="lblIdPregunta" Text='<%# Eval("Id_Pregunta") %>'></asp:Label>
                                                        <asp:Label runat="server" ID="lblTipoPregunta" Text='<%# Eval("TipoPregunta") %>'></asp:Label>
                                                        <asp:Label runat="server" ID="lblIdRespuesta"></asp:Label>


                                                        <asp:RadioButtonList runat="server" ID="radioList" DataTextField="Respuesta" DataValueField="Id_Respuesta" TextAlign="Right" CssClass="RBL"></asp:RadioButtonList>



                                                    </div>



                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:ListView>

                    </div>
                    <div class="container">
                        <div class="col-sm-12 col-md-12 col-lg-12">
                             <label class=" text-gray font-weight-normal">Total de preguntas: </label><asp:Label CssClass="ml-1" runat="server" ID="lblTotal"></asp:Label>
                            <div class="form-group float-right">
                               
                                 <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstPreguntas" PageSize="1">
                        <Fields>


                            <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ButtonType="Button" ShowLastPageButton="false" ShowFirstPageButton="false" ShowNextPageButton="true" ShowPreviousPageButton="false" />
                            <asp:NumericPagerField Visible="false"  />

                        </Fields>

                    </asp:DataPager>
                                <asp:Button runat="server" CssClass="btn btn-success" Text="Finalizar" ID="btnFinalizar" Visible="false" OnClick="btnFinalizar_Click" />
                                <asp:Label runat="server" ID="lblCal"></asp:Label>
                            </div>

                        </div>
                    </div>

                   


                </div>

            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {





        });
        function DisableButton() {
            document.getElementById("<%= btnFinalizar.ClientID %>").disabled = true;
                  document.getElementById("<%= btnFinalizar.ClientID %>").value = "Cargando...";


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
                || (keyEntry == 218) || (keyEntry >= 48 && keyEntry <= 57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64)
                return true;
            else {
                return false;
            }
        }
    </script>

</asp:Content>
