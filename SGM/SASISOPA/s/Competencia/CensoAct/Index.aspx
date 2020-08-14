﻿    <%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SASISOPA.Competencia.CensoAct.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Censo de actividad 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
      <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
               <div class="col-lg-12">
                <div class="row">
                    <div class="container col-12">
                        
                       <asp:LinkButton runat="server" CssClass="text-sm" PostBackUrl="~/s/Competencia/CensoAct/Crear.aspx"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>
                          <div class="input-group float-right col-sm-4 col-md-4 col-lg-4">
                <div class="input-group btn">
                   <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server"  OnClick="Buscar"  CssClass="btn btn-default btn-sm" />
                </div>
            </div>
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-striped table-sm border-light"
                                   GridLines="Vertical"
                                   id="gridActividad"
                                    
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de actividades."
                                     PageSize="10"
                                     OnPageIndexChanging="gridActividad_PageIndexChanging"
                                     AllowPaging="true"
                                 DataKeyNames="Id_Actividad"
                                     OnRowCommand="gridActividad_RowCommand"
                                     OnRowDataBound="gridActividad_RowDataBound"
                                    >
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="260px" ItemStyle-Width="260px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                               <asp:Button runat="server" Text="Editar" CssClass="btn btn-outline-secondary" CommandName="Editar" />

                                               <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkNombre" Text='<%# Eval("Nombre") %>' CommandName="AgregarVer" ToolTip="Agregar Control de Versión"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                 
                                     
                                         <asp:BoundField HeaderText="Código" DataField="Codigo" />
                                            <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblFechaEmision" Text='<%# Eval("FechaEmision") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de vigencia" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblFechaVigencia"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblMeses" Text='<%# Eval("VigenciaMeses") %>'></asp:Label>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Estatus de la vigencia" ItemStyle-HorizontalAlign="Center">
                                   <ItemTemplate>
                                          
                                        <i class=" ion-record text-green" runat="server" id="Vigente" visible="false"></i>
                                           <i class=" ion-record text-red" runat="server" id="Vencido" visible="false"></i>

                                   </ItemTemplate>
                               </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Archivo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblArchivo" Text='<%# Eval("Archivo") %>' Visible="false" ></asp:Label>
                                                <asp:HyperLink runat="server" CssClass="ion-android-document" ID="lnkArchivo" Target="_blank" ></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                            <PagerStyle HorizontalAlign ="Center" CssClass="" />
                                  
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