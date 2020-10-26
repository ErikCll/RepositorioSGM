<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SAM.Usuario.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Usuario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
               <div class="col-lg-12">
                <div class="row">
                     <div class="col-sm-12 col-md-12 col-lg-12">

                         <div class="card ">
                    <div class="card-body">

                            <div class="row">
                                                                          <div class="col-sm-4 col-md-4 col-lg-8">
                                                                    <asp:LinkButton runat="server" CssClass="text-sm" PostBackUrl="~/Usuario/Crear.aspx"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>

                                                                               </div>

                                                                          <div class=" input-group col-sm-8 col-md-8 col-lg-4">
                                                                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server"  OnClick="Buscar"  CssClass="btn btn-default btn-sm" />
                                                                              </div>

                                  <div class="container col-12">
                        
              <br />
                        <div class=" table-responsive ">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-bordered table-striped  table-sm"
                                    HeaderStyle-BackColor="#343a40"
                                     HeaderStyle-CssClass=" text-white"
                                    GridLines="Horizontal"
                                   id="gridUsuario"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de usuarios."
                                     PageSize="10"
                                     OnPageIndexChanging="gridUsuario_PageIndexChanging"
                                     AllowPaging="true"
                                 DataKeyNames="Id_Usuario"
                                     OnRowCommand="gridUsuario_RowCommand"
                                     HeaderStyle-HorizontalAlign="Center"
                                    
                                    >
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="260px" ItemStyle-Width="260px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                               <asp:Button runat="server" Text="Accesos" CssClass="btn btn-outline-primary" CommandName="Accesos"/>
                                               <asp:Button runat="server" Text="Editar" CssClass="btn btn-outline-secondary" CommandName="Editar" />

                                               <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Correo electrónico" >
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkCorreo" Text='<%# Eval("Acceso") %>' CommandName="AgregarInstalacion" ToolTip="Agregar instalación"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                        <asp:BoundField HeaderText="Apellido paterno" DataField="ApellidoPaterno" />
                                        <asp:BoundField HeaderText="Apellido materno" DataField="ApellidoMaterno" />
                                    </Columns>
                                            <PagerStyle HorizontalAlign = "Center" CssClass="" />
                                  
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
        </ContentTemplate>
    </asp:UpdatePanel>
       <script type="text/javascript">

              Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {



          });
                

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
