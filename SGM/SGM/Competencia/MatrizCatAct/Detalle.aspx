<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="SGM.Competencia.MatrizCatAct.Consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Detalle generla de Matriz Categoría-Actividad

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><a href="Index.aspx">Matriz Categoría-Actividad</a></li>
                  <li class="breadcrumb-item "><a>Detalle general </a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">

      <div class="col-lg-12">
                <div class="row">
                    <div class="container col-12">
                        
                   
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
                                <a class="btn btn-default" href="Index.aspx">Regresar</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
