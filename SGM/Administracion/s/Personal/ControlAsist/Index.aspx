<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Administracion.s.Personal.ControlAsist.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Control de asistencia
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">

     <asp:UpdatePanel runat="server" UpdateMode="Conditional">

        <ContentTemplate>
                                    <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-lg-12">
                <div class="row">

                    <div class="input-group col-sm-3 col-md-3 col-lg-3">
                          <div class="input-group btn">

                                  <asp:TextBox runat="server" ID="txtFecha" placeholder="dd-mm-yyyy" onkeydown="return false;" CssClass="form-control  form-control-sm"></asp:TextBox>
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnConsultar" Text="Consultar" runat="server" OnClick="btnConsultar_Click"/>
                            </div>
                    </div>
                          <div class="col-sm-5 col-md-5 col-lg-5"></div>
                             

                            <div class="input-group col-sm-4 col-md-4 col-lg-4 float-right">
                <div class="input-group btn">
                   <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server"  OnClick="Buscar"  CssClass="btn btn-default btn-sm" />
                </div>
            </div>
                    <div class="container col-12">
                        

                     

<%--                       <asp:LinkButton runat="server" CssClass="text-sm" PostBackUrl="~/s/Catalogo/Medidor/Crear.aspx"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>--%>
                  
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-striped table-sm border-light"
                                   GridLines="Vertical"
                                   id="gridAsistencia"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de asistencias."
                                     PageSize="10"
                                     OnPageIndexChanging="gridAsistencia_PageIndexChanging"
                                     AllowPaging="true"
                                     DataKeyNames="UserId"
                                     OnRowCommand="gridAsistencia_RowCommand"
                                    >
                                    <Columns>         
                                                                                <asp:BoundField HeaderText="No. Empleado" DataField="Badgenumber" />

                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" Text='<%# Eval("Name") %>' CommandName="Ver" ToolTip="Detalle"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:BoundField HeaderText="Fecha" DataField="Fecha" ItemStyle-HorizontalAlign="Center" />
                                         <asp:BoundField HeaderText="Entrada" DataField="Entrada" ItemStyle-HorizontalAlign="Center"  />
                                       <asp:BoundField HeaderText="Salida" DataField="Salida" ItemStyle-HorizontalAlign="Center"  />

                                    </Columns>
                                            <PagerStyle HorizontalAlign = "Center" CssClass="" />
                                </asp:GridView>
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



                $("#<%=txtFecha.ClientID%>").datepicker({
                        
                        dateFormat: 'dd-mm-yy',
                       maxDate: '+0D',
                     
                        changeMonth: true,
                        changeYear: true,
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo',
                            'Junio', 'Julio', 'Agosto', 'Septiembre',
                            'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr',
                            'May', 'Jun', 'Jul', 'Ago',
                            'Sep', 'Oct', 'Nov', 'Dic']
                  });
          });
               
                function DisableButton() {
                document.getElementById("<%= btnConsultar.ClientID %>").disabled = true;
                     document.getElementById("<%= btnConsultar.ClientID %>").value = "Cargando...";
             


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
