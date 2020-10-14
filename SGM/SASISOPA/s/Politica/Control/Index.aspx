<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SASISOPA.s.Politica.Control.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Control de Versiones
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
                   <li class="breadcrumb-item "><a href="../../Inicio.aspx">SASISOPA (Inicio)</a></li>

    <li class="breadcrumb-item "><a href="../Inicio.aspx">1. Política</a></li>
    <li class="breadcrumb-item "><a>Control de Versiones</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
</asp:Content>
