<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SGL.s.Procedimiento.MatrizCatAct.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Detalle Matriz Categoría-Actividad
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="Index.aspx">Matriz Categoría-Actividad</a></li>
                  <li class="breadcrumb-item "><a>Detalle</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
      <asp:UpdatePanel runat="server" UpdateMode="Conditional">

        <ContentTemplate>

            <div class="col-lg-12">
                <div class="row">
                      <div class="col-sm-12 col-md-12 col-lg-12">

                        <div class="card ">
                            <div class="card-body">
                                   <div class="row">
                                        <div class="col-sm-4 col-md-4 col-lg-8">


                                </div>
                                                                       <div class=" input-group float-right col-sm-4 col-md-4 col-lg-4">
 <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server"  OnClick="Buscar"  CssClass="btn btn-default btn-sm" />
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
                                   id="gridCategoria"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de categorías."
                                     PageSize="10"
                                     OnPageIndexChanging="gridCategoria_PageIndexChanging"
                                     AllowPaging="true"
                                 DataKeyNames="Id_Categoria"
                                     OnRowCommand="gridCategoria_RowCommand"
                                     HeaderStyle-HorizontalAlign="Center"
                                    >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Categoría">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkNombre" Text='<%# Eval("Nombre") %>' CommandName="AgregarAct"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:BoundField HeaderText="Área" DataField="Area" />
                                    </Columns>
                                            <PagerStyle HorizontalAlign = "Center" CssClass="" />
                                </asp:GridView>
                                <asp:Button runat="server" ID="btnRegresar" Text="Regresar" CssClass="btn btn-default" PostBackUrl="~/s/Procedimiento/MatrizCatAct/Index.aspx" />

                            </div>
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
