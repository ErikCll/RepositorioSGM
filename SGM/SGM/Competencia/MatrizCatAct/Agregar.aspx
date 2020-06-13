﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="SGM.Competencia.MatrizCatAct.Agregar" %>
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
                           <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Censo de actividad:</h4>
                        </div>
                                   <div class="table-responsive">
                                                                            <div style="overflow: auto; height: 400px">
                                                                            <asp:GridView ID="gridActividad" runat="server"
                                                            AutoGenerateColumns="false" 
                                                             CssClass=" table table-striped table-sm"
                                                             GridLines="Vertical"
                                                            EmptyDataText="Sin registro de actividades."
                                                            DataKeyNames="Id_Actividad"
                                                                    >                                                                     
                                                            <Columns>
                                                                
                                                                <asp:TemplateField HeaderStyle-Width="15px" HeaderText="Agregar" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="header-center">
                                                                   <%-- <HeaderTemplate>
                                                                       <asp:CheckBox runat="server" ID="checkall" CssClass="chkHeader"/>

                                                                    </HeaderTemplate>--%>
                                                                    <ItemTemplate>

                                                                        <asp:CheckBox runat="server" ID="chckAct"  Checked='<%#Eval("Id_registro") %>'    />

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:BoundField HeaderText="Nombre" DataField="Nombre"  />
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

</div>

                                                        </div>
                     
                       
                              
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>