<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="SGM.Competencia.MatrizCatEmp.Agregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Agregar empleado<br />
        <label class="font-weight-normal text small">Categoría: </label> <asp:Label runat="server" ID="lblCategoría" CssClass=" font-weight-bold text small"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="Index.aspx">Matriz Categoría-Empleado</a></li>


      <li class="breadcrumb-item active"><a href="Detalle.aspx">Detalle</a></li>
                  <li class="breadcrumb-item "><a>Agregar</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
           <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
            <div class="col-lg-12">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                        
                           
                     
                        <div class="col-sm-12 col-md-12 col-lg-12"></div>
                        <div class="col-sm-6 col-md-6 col-lg-6">
                            <div class="form-group custom-control-inline">
                                                            <h4>Empleados:</h4>

                                                                 <input type="text" id="txtFiltro" class="form-control ml-1" placeholder="Búsqueda rápida" maxlength="20"  onkeyup="filtro(this)"/>

                            </div>                        </div>

                        <div class="col-sm-6 col-md-6 col-lg-6">
                              <div class="form-group float-right">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"/>
                                  <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-default" Text="Regresar" PostBackUrl="~/s/Competencia/MatrizCatEmp/Detalle.aspx" />
                            </div>
                        </div>
                                   <div class="table-responsive">
                                                                            <div style="overflow: auto; height: 400px">
                                                                            <asp:GridView ID="gridEmpleado" runat="server"
                                                            AutoGenerateColumns="false" 
                                                             CssClass=" table table-striped table-sm border-light" 
                                                             GridLines="Vertical"
                                                            EmptyDataText="Sin registro de empleados."
                                                            DataKeyNames="Id_Empleado"
                                                              OnRowDataBound="gridEmpleado_RowDataBound"  >                                                                     
                                                            <Columns>
                                                                
                                                                <asp:TemplateField HeaderStyle-Width="15px" HeaderText="Agregar" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="header-center">
                                                                    <HeaderTemplate>
                                                                       <asp:CheckBox runat="server" ID="checkall" CssClass="chkHeader"/>

                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>

                                                                        <asp:CheckBox runat="server" ID="chckAct"  Checked='<%#Eval("Id_registro") %>'    />

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField HeaderText="Empleado" DataField="Empleado" ItemStyle-Width="500px" />
                                                                  <asp:BoundField HeaderText="Instalación" DataField="Instalacion" />

                                                                <asp:TemplateField Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Id_Empleado") %>'></asp:Label>
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

             function filtro() {
            var txtKeyword = document.getElementById("txtFiltro");
            var tblGrid = document.getElementById('<%= gridEmpleado.ClientID %>');
            var rows = tblGrid.rows;
            var i = 0, row, cell;
            for (i = 1; i < rows.length; i++) {
                row = rows[i];
                var found = false;
                for (var j = 0; j < row.cells.length; j++) {
                    cell = row.cells[j];
                    if (cell.innerHTML.toUpperCase().indexOf(txtKeyword.value.toUpperCase()) >= 0) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    row.style['display'] = 'none';

                }
                else {
                    row.style.display = '';
                }
            }

            return false;

             }

             function SelectAll(id)
        {
            //get reference of GridView control
            var grid = document.getElementById("<%= gridEmpleado.ClientID %>");
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
                     </script>  

</asp:Content>
