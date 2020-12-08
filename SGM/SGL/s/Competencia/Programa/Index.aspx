<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGL.s.Competencia.Programa.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Programa de capacitación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
                   <li class="breadcrumb-item "><a href="../../Inicio.aspx">SGL (Inicio)</a></li>

                  <li class="breadcrumb-item "><a href="../Inicio.aspx">Competencia y Formación</a></li>
                     <li class="breadcrumb-item "><a>Programa de capacitación</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
        <div class="col-lg-12">
                <div class="row">

                    <div class="col-sm-12 col-md-12 col-lg-12">

                <div class="card ">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                 <a href="Detalle.aspx" class="float-left">Programar evaluaciones</a>

                            </div>
                            <br />
                            <br />
                               <div class="col-sm-3 col-md-3 col-lg-3 ">
                            <div class="form-group">
                                 <label>Año:</label>
                        <asp:DropDownList runat="server" ID="ddl_Anio" DataTextField="Anio" DataValueField="Anio" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_Anio_SelectedIndexChanged"></asp:DropDownList>
                   
                            </div>
                        </div>
                             
                                 <div class="container col-12">
                   
                        <br />
                     
                       
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-bordered table-striped table-sm"
                                   HeaderStyle-BackColor="#343a40"
                                     HeaderStyle-CssClass=" text-white"
                                            GridLines="Horizontal"
                                   id="gridMatriz"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registros."
                                HeaderStyle-VerticalAlign="Middle"
                                     HeaderStyle-HorizontalAlign="Center"
                                     DataKeyNames="Id"
                                 OnRowDataBound="gridMatriz_RowDataBound"
                                 
                                                         >
                                    <Columns>
                                        <asp:BoundField DataField="Nombre" HeaderText="Actividad" />
                                        <asp:BoundField DataField="Codigo" HeaderText="Versión" />
                                        <asp:BoundField DataField="Pendiente/Realizado" HeaderText="Programado/Realizado"  ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="Ene" HeaderText="Ene" />
                                        <asp:BoundField DataField="Feb" HeaderText="Feb" />
                                        <asp:BoundField DataField="Mar" HeaderText="Mar" />
                                        <asp:BoundField DataField="Abr" HeaderText="Abr" />
                                        <asp:BoundField DataField="May" HeaderText="May" />
                                        <asp:BoundField DataField="Jun" HeaderText="Jun" />
                                        <asp:BoundField DataField="Jul" HeaderText="Jul" />
                                        <asp:BoundField DataField="Ago" HeaderText="Ago" />
                                        <asp:BoundField DataField="Sep" HeaderText="Sep" />
                                        <asp:BoundField DataField="Oct" HeaderText="Oct" />
                                        <asp:BoundField DataField="Nov" HeaderText="Nov" />
                                        <asp:BoundField DataField="Dic" HeaderText="Dic" />
                                        <asp:BoundField DataField="Total" HeaderText="Total" />
                                        <asp:BoundField DataField="Avance" HeaderText="Avance" />
                                    </Columns>
                             
                                </asp:GridView>
                                 <asp:Button runat="server" CssClass="btn btn-default" ID="btnRegresar" PostBackUrl="~/s/Competencia/Inicio.aspx" Text="Regresar" />
                            </div>
                        </div>
                    </div>
                            </div>

                        </div>

                    </div>

                        </div>
               
                </div>
            </div>
     <script type="text/javascript">

              Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {



          });
               function DisableButton() {
              
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
