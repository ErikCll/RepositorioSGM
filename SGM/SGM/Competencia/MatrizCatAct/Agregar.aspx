<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="SGM.Competencia.MatrizCatAct.Agregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Agregar censo de actividad<br />
        <label class="font-weight-normal text small">Categoría: </label> <asp:Label runat="server" ID="lblCategoría" CssClass=" font-weight-bold text small"></asp:Label>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
      <li class="breadcrumb-item active"><a href="Index.aspx">Matriz Categoría-Actividad</a></li>
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
                        
                           
                        <div class="col-sm-12 col-md-3 col-lg-3">
                            <div class="form-group">
                               <label>Área:</label>
                                <asp:DropDownList runat="server" ID="ddl_Area" DataTextField="Nombre" DataValueField="Id_Area" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_Area_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Censo de actividades:</h4>
                        </div>
                                   <div class="table-responsive">
                                                                            <div style="overflow: auto; height: 400px">
                                                                            <asp:GridView ID="gridActividad" runat="server"
                                                            AutoGenerateColumns="false" 
                                                             CssClass=" table table-striped table-sm"
                                                             GridLines="Vertical"
                                                            EmptyDataText="Sin registro de actividades."
                                                            DataKeyNames="Id_Actividad"
                                                              OnRowDataBound="gridActividad_RowDataBound"  >                                                                     
                                                            <Columns>
                                                                
                                                                <asp:TemplateField HeaderStyle-Width="15px" HeaderText="Agregar" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="header-center">
                                                                    <HeaderTemplate>
                                                                       <asp:CheckBox runat="server" ID="checkall" CssClass="chkHeader"/>

                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>

                                                                        <asp:CheckBox runat="server" ID="chckAct"  Checked='<%#Eval("Id_registro") %>'    />

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-Width="500px" />
                                                                  <asp:BoundField HeaderText="Área" DataField="Area" />

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
                                                                                     <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"/>
                                <a class="btn btn-default" href="Index.aspx">Regresar</a>
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

         function DisableButton() {
                document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
                document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando...";
  }
         window.onbeforeunload = DisableButton;

             function SelectAll(id)
        {
            //get reference of GridView control
            var grid = document.getElementById("<%= gridActividad.ClientID %>");
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
