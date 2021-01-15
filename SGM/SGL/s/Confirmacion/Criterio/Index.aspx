<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGL.s.Confirmacion.Criterio.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Criterios de Aceptación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
        <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
                  <li class="breadcrumb-item "><a href="../../Inicio.aspx">SGL (Inicio)</a></li>
                      <li class="breadcrumb-item "><a href="../Inicio.aspx">Confirmación metrológica</a></li>

                     <li class="breadcrumb-item "><a>Criterios de Aceptación</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
</asp:Content>
