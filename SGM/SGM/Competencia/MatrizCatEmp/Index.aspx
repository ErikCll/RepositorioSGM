<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGM.Competencia.MatrizCatEmp.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        Matriz Categoría-Empleado

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
          <div class="col-lg-12">
                <div class="row">
                    <div class="container col-12">
                    <a href="Detalle.aspx" class="float-left">Detalle Matriz Categoría-Empleado
</a>

                   
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-striped table-sm"
                                   GridLines="Vertical"
                                   id="gridMatriz"
                                    AutoGenerateColumns="true"
                                     EmptyDataText="Sin registros."
                               OnRowDataBound="gridMatriz_RowDataBound"
                                HeaderStyle-VerticalAlign="Middle"
                                    >
                             
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

</asp:Content>
