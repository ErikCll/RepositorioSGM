﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SASISOPA.s.ControlDoc.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    8. Control de Documentos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
       <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
           <li class="breadcrumb-item "><a href="../Inicio.aspx">SASISOPA (Inicio)</a></li>

    <li class="breadcrumb-item "><a>8. Control de Documentos</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
</asp:Content>