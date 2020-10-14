<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="SAM.Usuario.Agregar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Agregar Instalación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="Index.aspx">Usuario</a></li>
    <li class="breadcrumb-item "><a>Agregar Instalación</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    
            <asp:Literal ID="litControl" runat="server"></asp:Literal>

            <div class="col-lg-12">
                <div class="row">
                                             <div class="col-sm-12 col-md-12 col-lg-12">
                                                      <div class="card">
                    <div class="card-header">
                        <h4>Datos del usuario</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">

                            <div class="col-12 col-md-12 col-lg-4">
                                <div class="form-group">
                                    <label class="font-weight-normal">Nombre:</label>
                                    <asp:Label runat="server" ID="lblNombre" CssClass=" font-weight-bold"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label class="font-weight-normal">Apellido Paterno:</label>
                                    <asp:Label runat="server" ID="lblApellidoPaterno" CssClass="font-weight-bold"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label class="font-weight-normal">Apellido Materno:</label>
                                    <asp:Label runat="server" ID="lblApellidoMaterno" CssClass="font-weight-bold"></asp:Label>

                                </div>
                            </div>


                            <div class="col-12 col-md-12 col-lg-4">
                                <div class="form-group">
                                    <label class="font-weight-normal">Correo electrónico:</label>
                                    <asp:Label runat="server" ID="lblCorreo" CssClass="font-weight-bold"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label class="font-weight-normal">Fecha de creación:</label>
                                    <asp:Label runat="server" ID="lblFecha" CssClass="font-weight-bold"></asp:Label>
                                </div>
                            </div>



                            <div class="col-sm-12 col-md-12 col-lg-8">
                            </div>

                            <div class="col-sm-12 col-md-12 col-lg-12 dropdown-divider">
                            </div>
                            <div class="col-sm-6 col-md-6 col-lg-6">
                                <h4>Instalaciones:</h4>
                            </div>
                              <div class="col-sm-6 col-md-6 col-lg-6">
                                <div class="form-group float-right">
                                    <asp:Button runat="server" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" Text="Guardar" />
                                    <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" PostBackUrl="~/Usuario/Index.aspx" />
                                </div>
                            </div>
                            <div class="col-sm-12 col-md-12 col-lg-12">
                                <div class="table-responsive">
                                    <div style="overflow: auto; height: 400px">
                                        <asp:GridView ID="gridUsuarioInstalacion" runat="server"
                                             AutoGenerateColumns="false"
                                            CssClass=" table table-bordered table-striped table-sm"
                                            HeaderStyle-BackColor="#343a40"
                                            HeaderStyle-CssClass=" text-white"
                                            GridLines="Horizontal"
                                            EmptyDataText="Sin registro de instalaciones."
                                            DataKeyNames="Id_Instalacion"
                                            HeaderStyle-HorizontalAlign="Center"
                                             OnRowDataBound="gridUsuarioInstalacion_RowDataBound"
                                             >
                                            
                                            <Columns>

                                                <asp:TemplateField HeaderStyle-Width="15px" HeaderText="Agregar" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="header-center">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox runat="server" ID="checkall" CssClass="chkHeader" />

                                                    </HeaderTemplate>
                                                    <ItemTemplate>

                                                        <asp:CheckBox runat="server" ID="chckIns" Checked='<%#Eval("Id_registro") %>' />

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="Instalación" DataField="Instalacion"  />
                                                <asp:BoundField HeaderText="Localización" DataField="Localizacion" />

                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdInstalacion" runat="server" Text='<%#Eval("Id_Instalacion") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                         <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRegistro" runat="server" Text='<%#Eval("Id_registro2") %>'></asp:Label>
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
               
            </div>
        
    <script type="text/javascript">

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {



        });
        function DisableButton() {
            document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
            document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando..."
            document.getElementById("<%= btnRegresar.ClientID %>").disabled = true;
            document.getElementById("<%= btnRegresar.ClientID %>").value = "Cargando...";


        }
        window.onbeforeunload = DisableButton;
               function SelectAll(id)
        {
            //get reference of GridView control
            var grid = document.getElementById("<%= gridUsuarioInstalacion.ClientID %>");
            //variable to contain the cell of the grid
            var cell;
            
            if (grid.rows.length > 0)
            {
                //loop starts from 1. rows[0] points to the header.
                for (i=1; i<grid.rows.length; i++)
                {
                    //get the reference of first column
                    cell = grid.rows[i].cells[0];
                    
                    //loop according to the number of childNodes in the cell
                    for (j=0; j<cell.childNodes.length; j++)
                    {           
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type =="checkbox")
                        {
                        //assign the status of the Select All checkbox to the cell 
                        //checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }

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
                || (keyEntry == 218) || (keyEntry >= 48 && keyEntry <= 57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64)
                return true;
            else {
                return false;
            }
        }
     </script>
</asp:Content>
