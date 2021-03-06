﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGM.Confirmacion.CensoSis.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Censo de sistemas de medición
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
                  <li class="breadcrumb-item "><a href="../../Inicio.aspx">SGM (Inicio)</a></li>
                      <li class="breadcrumb-item "><a href="../Inicio.aspx">Confirmación metrológica</a></li>

                     <li class="breadcrumb-item "><a> Censo de sistemas de medición</a></li>
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

                                                               <asp:LinkButton runat="server" CssClass="text-sm" PostBackUrl="~/s/Confirmacion/CensoSis/Crear.aspx"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>

                                        </div>
                                                                        <div class=" input-group col-sm-8 col-md-8 col-lg-4">

                                                                             <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
<asp:Button ID="btnBuscar" Text="Buscar" runat="server"  OnClick="Buscar"  CssClass="btn btn-default btn-sm" />
                                                                            </div>

                                        
                    <div class="container col-12">
                        <br />
         
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                CssClass=" table table-bordered table-striped  table-sm"
                                                    HeaderStyle-BackColor="#343a40"
                                                    HeaderStyle-CssClass=" text-white"
                                                    GridLines="Horizontal"
                                                    HeaderStyle-HorizontalAlign="Center"
                                   id="gridSistema"
                                    AutoGenerateColumns="false"
                                     EmptyDataText="Sin registro de sistemas de medición."
                                     PageSize="10"
                                     OnPageIndexChanging="gridSistema_PageIndexChanging"
                                     AllowPaging="true"
                                 DataKeyNames="Id_Sistema"
                                        OnRowCommand="gridSistema_RowCommand"

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
                                                <asp:LinkButton runat="server" ID="lnkNombre" Text='<%# Eval("Nombre") %>' CommandName="AgregarCom" ToolTip="Agregar componente"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Instalación" DataField="Instalacion" />
                                     
                                       
                                    
                                  
                                    </Columns>
                                            <PagerStyle HorizontalAlign ="Center" CssClass="" />
                                  
                                </asp:GridView>
                                                              <asp:Button runat="server" CssClass="btn btn-default" ID="btnRegresar" PostBackUrl="~/s/Confirmacion/Inicio.aspx" Text="Regresar" />

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

         
                  </script>  

</asp:Content>
