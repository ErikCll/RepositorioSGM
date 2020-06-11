<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="SGM.Competencia.CensoAct.Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Control de versiones<br />
    <label class="font-weight-normal text small">Censo de actividad: </label> <asp:Label runat="server" ID="lblCensoAct" CssClass=" font-weight-bold text small"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
      <li class="breadcrumb-item active"><a href="Index.aspx">Censo de actividad</a></li>
                  <li class="breadcrumb-item "><a>Control de versiones</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
                                    <asp:Literal ID="litControl" runat="server"></asp:Literal>
             <ul class="nav nav-tabs ml-1">
      <li class="nav-item" runat="server" id="itemCaptura">
        <a data-toggle="tab" class="nav-link active" href="#<%= captura.ClientID %>">Carga</a>
      </li>
      <li class="nav-item" runat="server" id="itemConsulta">
        <a data-toggle="tab" class="nav-link" href="#<%= consulta.ClientID %>">Consulta</a>
      </li>
   
    </ul>
            <div class="col-lg-12">
                    <div class="tab-content">
                        <div class="tab-pane active" id="captura" runat="server" >
         <div class="card shadow-none border-top border-dark" >
                <div class="card-body" id="DivInsertar" runat="server" >
                    <div class="row">

                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Archivo:</label>
                               
                              <asp:FileUpload runat="server" ID="File1" />
                          

                            </div>
                               <asp:RequiredFieldValidator runat="server" ID="reqFile" ControlToValidate="File1"
                                    ErrorMessage="Debe seleccionar un archivo PDF." ForeColor="Red" ValidationGroup="btnGuardar" Enabled="false"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo PDF." ForeColor="Red"
                                                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.pdf)$" ControlToValidate="File1" ValidationGroup="btnGuardar">
                                                    </asp:RegularExpressionValidator>
                                  
                        </div>

                       
                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Código:</label>

                                <asp:TextBox runat="server" class="form-control" id="txtCodigo"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="reqCodigo" ControlToValidate="txtCodigo"
                                    ErrorMessage="Código requerido." ForeColor="Red"  ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>


                            </div>
                            <div class="col-sm-12 col-md-2"></div>
                        </div>

                                                <div class="col-sm-12 col-md-12 col-lg-4"></div>

               
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                          
                            <div class="form-group">
                                <asp:Button class="btn btn-primary" id="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" OnClick="btnGuardar_Click"/>
                                <a id="btn_ClearButton" class="btn btn-default" role="button">Limpiar</a>
                                        <a id="btnCerrar" class="btn btn-default " runat="server">Cerrar</a>

                            </div>
                        </div>

                    </div>


                </div>


            </div>
                      
          
                      
                    </div>
             <div class="tab-pane" id="consulta" runat="server" >
              
                      <asp:UpdatePanel runat="server" UpdateMode="Conditional"><ContentTemplate>
                                                              <asp:Literal ID="litControl2" runat="server"></asp:Literal>

         <div class="card shadow-none border-top border-dark" >
                <div class="card-body" >
                    <div class="row">
                        <asp:TextBox ID="txtSearch" runat="server" Visible="false"></asp:TextBox>
                         <div class="container col-12 ">
        <div class="table-reponsive">
            <div style="overflow: auto; height: auto">
                     <asp:GridView ID="gridControl"
                    runat="server"
                    AutoGenerateColumns="false" 
                     CssClass=" table table-striped table-sm"
                                   GridLines="Vertical"
                    EmptyDataText="Sin registro de control de veriones"
                 PageSize="10"
                    DataKeyNames="Id_Control" 
                          OnPageIndexChanging="gridControl_PageIndexChanging"
                         AllowCustomPaging="false"
                          AllowPaging="true"
                          OnRowDataBound="gridControl_RowDataBound"
                     >
                    <Columns>

                         <asp:BoundField HeaderText="Código"  DataField="Codigo"/>
                        <asp:BoundField HeaderText="Fecha de creación" DataField="FechaCreacion" />
                    <asp:TemplateField HeaderText="Archivo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate >
                            <asp:HyperLink runat="server" ID="lnk" CssClass="ion-android-document" Target="_blank"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                          

                    </Columns>
                                        <PagerStyle HorizontalAlign = "Center" CssClass="" />

                </asp:GridView>
                </div>
            </div>
                             </div>
                    
                  

                    </div>


                </div>


            </div>                 

                                                                               </ContentTemplate>

                      </asp:UpdatePanel>
               
             </div>
                        </div>
                    </div>
                  
              
        </ContentTemplate>
               <Triggers>
                   <asp:PostBackTrigger ControlID="btnGuardar" />
   </Triggers>
    </asp:UpdatePanel>

</asp:Content>
