<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SASISOPA.s.Respuesta.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    13. Respuesta a Emergencias
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active">
        <asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
           <li class="breadcrumb-item "><a href="../Inicio.aspx">SASISOPA (Inicio)</a></li>

    <li class="breadcrumb-item "><a>13. Respuesta a Emergencias</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
        <div class="col-lg-12">
        <div class="row">
          <div class="col-sm-12 col-md-6 col-lg-4" runat="server" id="configuracion" visible="false">
                <div class="card card-default shadow-sm">
                    <div class="card-header bg-gray">
                        <h3 class="card-title font-weight-bold ">Configuración del elemento</h3>

                        <div class="card-tools">
                                <i class="fas fa-cog"></i>
                        </div>
                    </div>
                    <div class="card-body " style="display: block;">
                        <div class="row">               
                         
                        </div>
                        </div>

                    </div>
                          
                    </div>

             
                </div>

            </div>
</asp:Content>
