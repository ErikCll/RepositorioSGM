﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SASISOPA.s.Competencia.CursoTaller.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Cursos y Talleres
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
                   <li class="breadcrumb-item "><a href="../../Inicio.aspx">SASISOPA (Inicio)</a></li>

                  <li class="breadcrumb-item "><a href="../Inicio.aspx">6. Competencia y Formación</a></li>
                     <li class="breadcrumb-item "><a>Cursos y Talleres</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
</asp:Content>
