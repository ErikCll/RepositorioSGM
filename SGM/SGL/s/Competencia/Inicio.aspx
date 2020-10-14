<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SGL.s.Competencia.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Competencia y Formación
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
           <li class="breadcrumb-item "><a href="../Inicio.aspx">SGL (Inicio)</a></li>

    <li class="breadcrumb-item "><a>Competencia y Formación</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
</asp:Content>
