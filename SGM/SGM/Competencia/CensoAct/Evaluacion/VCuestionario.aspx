<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VCuestionario.aspx.cs" Inherits="SGM.Competencia.CensoAct.VCuestionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Validar Cuestionario
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <style>
        .RBL label
{
    margin-left:3px;

        }

    </style>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
                        <div class="col-lg-12">
                <div class="row">
                    <ol class="col-12">
                                                     <asp:ListView runat="server" ID="lstPreguntas" OnItemDataBound="lstPreguntas_ItemDataBound">
                        <ItemTemplate>
                                                                <div class=" container col-8">
                       <div class=" col-sm-12 col-md-12 col-lg-12">
                  <div class="card shadow border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-12 col-md-12 col-lg-12">
                             <li>
              <label class=" font-weight-bold"><%# Eval("Pregunta") %></label>  <asp:LinkButton runat="server" CssClass="ion-edit" ToolTip="Editar" OnClick="Editar"></asp:LinkButton> <asp:LinkButton runat="server" CssClass="ion-android-delete text-red" ToolTip="Eliminar" OnClick="Eliminar"></asp:LinkButton>  
                                                                 <asp:Label runat="server" ID="lblIdPregunta" Text='<%# Eval("Id_Pregunta") %>'></asp:Label>
<asp:RadioButtonList runat="server" ID="radioList" DataTextField="Respuesta" DataValueField="Respuesta" TextAlign="Right" CssClass="RBL"> </asp:RadioButtonList>

                      </li>
                            
                        </div>
                     
                                   
                     
                        </div>
                    </div>
                      </div>
            </div>
                    </div>

                        </ItemTemplate>
                    </asp:ListView>

                    </ol>
                   
                
            
        <%--    <div class="col-sm-4 col-md-12 col-lg-4">
                  <div class="card shadow-none border-top border-primary" >
                <div class="card-body">
                    <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Lista de Preguntas</h4>
                        </div>

                        <ol id="ordered">
   <asp:ListView runat="server" ID="lstPreguntas" >
                            <ItemTemplate>
                                
                                <asp:Label runat="server" ID="lblIdPregunta" Text='<%# Eval("Id_Pregunta") %>'></asp:Label>
                           <li><asp:LinkButton runat="server" CssClass="ion-android-cancel text-red" OnClick="Eliminar"></asp:LinkButton> <label class=" font-weight-bold"><%# Eval("Pregunta") %></label> </li>  

                            </ItemTemplate>
                        </asp:ListView>
                        </ol>
                       
                     
                  
                     
                                        
                    
                        </div>
                    </div>
                      </div>
            </div>--%>

                </div>
             
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
