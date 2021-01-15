<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="SGL.s.Procedimiento.MatrizInsAct.Agregar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Agregar censo de actividad a instalación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="Index.aspx">Matriz Instalación-Actividad</a></li>
    <li class="breadcrumb-item "><a>Agregar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">

                        <div class="card ">
                            <div class="card-body">
                                <div class="row">

                                    <div class="col-sm-12 col-md-3 col-lg-3">
                                        <div class="form-group">
                                            <label>Instalación:</label>
                                            <asp:DropDownList runat="server" ID="ddl_Instalacion" DataTextField="Nombre" DataValueField="Id_Instalacion" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_Instalacion_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="col-sm-12 col-md-12 col-lg-12"></div>
                                    <div class="col-sm-6 col-md-6 col-lg-6">
                                        <h4>Censo de actividades:</h4>
                                    </div>
                                    <div class="col-sm-6 col-md-6 col-lg-6">
                                        <div class="form-group float-right">
                                            <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" Visible="false" />
                                            <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" PostBackUrl="~/s/Procedimiento/MatrizInsAct/Index.aspx" />
                                        </div>
                                    </div>
                                    <div class="table-responsive">
                                        <div style="overflow: auto; height: 400px">
                                            <asp:GridView ID="gridActividad" runat="server"
                                                AutoGenerateColumns="false"
                                                CssClass="  table table-bordered table-striped table-sm"
                                                EmptyDataText="Sin registro de actividades."
                                                DataKeyNames="Id_Actividad"
                                                HeaderStyle-BackColor="#343a40"
                                                HeaderStyle-CssClass=" text-white"
                                                GridLines="Horizontal"
                                                OnRowDataBound="gridActividad_RowDataBound">
                                                <Columns>

                                                    <asp:TemplateField HeaderStyle-Width="5px" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox runat="server" ID="checkall" CssClass="chkHeader" />

                                                        </HeaderTemplate>
                                                        <ItemTemplate>

                                                            <asp:CheckBox runat="server" ID="chckAct" Checked='<%#Eval("Id_registro") %>' />

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                                         <asp:TemplateField HeaderText="Archivo" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblArchivo" Text='<%# Eval("Archivo") %>' Visible="false" ></asp:Label>
                                                <asp:HyperLink runat="server"  ID="lnkArchivo" Target="_blank" ImageUrl="~/dist/img/pdficon.svg" ImageHeight="17px" ImageWidth="17px" ></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Id_Actividad") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Id_registro2") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>



                                            </asp:GridView>


                                        </div>

                                    </div>

                                </div>


                            </div>








                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGuardar" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

        function DisableButton() {
            document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
             document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando...";
             document.getElementById("<%= btnRegresar.ClientID %>").disabled = true;
             document.getElementById("<%= btnRegresar.ClientID %>").value = "Cargando...";
        }
        window.onbeforeunload = DisableButton;

        function SelectAll(id) {
            //get reference of GridView control
            var grid = document.getElementById("<%= gridActividad.ClientID %>");
            //variable to contain the cell of the grid
            var cell;

            if (grid.rows.length > 0) {
                //loop starts from 1. rows[0] points to the header.
                for (i = 1; i < grid.rows.length; i++) {
                    //get the reference of first column
                    cell = grid.rows[i].cells[0];

                    //loop according to the number of childNodes in the cell
                    for (j = 0; j < cell.childNodes.length; j++) {
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type == "checkbox") {
                            //assign the status of the Select All checkbox to the cell 
                            //checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }
    </script>
</asp:Content>
