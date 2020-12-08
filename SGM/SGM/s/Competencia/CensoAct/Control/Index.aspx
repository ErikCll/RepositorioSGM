<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGM.Competencia.CensoAct.Control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Control de versiones<br />
    <label class="font-weight-normal text small">Censo de actividad: </label>
    <asp:Label runat="server" ID="lblCensoAct" CssClass=" font-weight-bold text small"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
    <li class="breadcrumb-item active"><a href="../Index.aspx">Censo de actividad</a></li>
    <li class="breadcrumb-item "><a>Control de versiones</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Literal ID="litControl" runat="server"></asp:Literal>
           <div class="col-lg-12">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">

                        <div class="card ">
                            <div class="card-body">

                                <div class="row">

                                                                        <div class="col-sm-4 col-md-4 col-lg-8">

                                                                                                    <asp:LinkButton runat="server" CssClass="text-sm"  OnClick="CrearVersion"><span class=" ion-plus" ></span>Agregar</asp:LinkButton>

                                                                            </div>
                                                                        <div class=" input-group col-sm-8 col-md-8 col-lg-4">

                                                                            </div>
                                     <div class="container col-12">
                        <br />
                        <div class=" table-responsive">
                            <div style="overflow: auto; height: auto">
                                <asp:GridView ID="gridControl"
                                    runat="server"
                                    AutoGenerateColumns="false"
                                    CssClass=" table table-bordered table-striped  table-sm"
                                                    HeaderStyle-BackColor="#343a40"
                                                    HeaderStyle-CssClass=" text-white"
                                                    GridLines="Horizontal"
                                                    HeaderStyle-HorizontalAlign="Center"
                                    EmptyDataText="Sin registro de control de veriones."
                                    PageSize="10"
                                    DataKeyNames="Id_Control"
                                    OnPageIndexChanging="gridControl_PageIndexChanging"
                                    AllowCustomPaging="false"
                                    AllowPaging="true"
                                    OnRowDataBound="gridControl_RowDataBound"
                                    OnRowCommand="gridControl_RowCommand">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="260px" ItemStyle-Width="260px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                                <asp:Button runat="server" Text="Editar" CssClass="btn btn-outline-secondary" CommandName="Editar" />

                                                <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                        <asp:TemplateField HeaderText="Fecha de emisión" ItemStyle-HorizontalAlign="Center" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblFechaEmision" Text='<%# Eval("FechaEmision") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de vigencia" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblFechaVigencia"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblMeses" Text='<%# Eval("VigenciaMeses") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblTieneVigencia" Text='<%# Eval("TieneVigencia")%>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                     <asp:TemplateField HeaderText="Estatus de la vigencia" ItemStyle-HorizontalAlign="Center">
                                   <ItemTemplate>
                                          
                                        <i class=" ion-record text-green" runat="server" id="Vigente" visible="false"></i>
                                           <i class=" ion-record text-red" runat="server" id="Vencido" visible="false"></i>

                                   </ItemTemplate>
                               </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Archivo" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="lnk" ImageUrl="~/dist/img/pdficon.svg" ImageHeight="17px" ImageWidth="17px" Target="_blank"></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tiene Evaluación" ItemStyle-HorizontalAlign="Center" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server"  Text='<%# Eval("TieneEvaluacion")%>' ID="lblTieneEvaluacion"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Tiene Evaluación" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                           <asp:LinkButton runat="server" ID="lnkNombre" Text='<%# Eval("TieneEvaluacion") %>' CommandName="AgregarEv" ToolTip="Evaluación"></asp:LinkButton>

                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <PagerStyle HorizontalAlign="Center" CssClass="" />

                                </asp:GridView>
                                   <a class="btn btn-default" href="../Index.aspx">Regresar</a>

                            </div>

                        </div>
                    </div>
                                    </div>


                                </div>


                            </div>


                        </div>

                    
                   
                </div>
            </div>

            <%--   <ul class="nav nav-tabs ml-1">
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
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="" ForeColor="Red"
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
                                <a class="btn btn-default" href="Index.aspx">Regresar</a>


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
                     <asp:GridView ID="GridView1"
                    runat="server"
                    AutoGenerateColumns="false" 
                     CssClass=" table table-striped table-sm"
                                   GridLines="Vertical"
                    EmptyDataText="Sin registro de control de veriones."
                 PageSize="10"
                    DataKeyNames="Id_Control" 
                          OnPageIndexChanging="gridControl_PageIndexChanging"
                         AllowCustomPaging="false"
                          AllowPaging="true"
                          OnRowDataBound="gridControl_RowDataBound"
                         OnRowCommand="gridControl_RowCommand"
                     >
                    <Columns>
                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="260px" ItemStyle-Width="260px" ControlStyle-Width="76px">
                                            <ItemTemplate>
                                               <asp:Button runat="server" Text="Editar" CssClass="btn btn-outline-secondary" CommandName="Editar" />

                                               <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" CommandName="Eliminar" OnClientClick="javascript:if(!confirm('¿Desea borrar el registro?'))return false" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
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
            --%>
        </ContentTemplate>
      
    </asp:UpdatePanel>
              <script type="text/javascript">

              Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {



          });
                

                function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
                 if (((keyEntry >= 65) && (keyEntry <= 90)) ||
                     ((keyEntry >= 97) && (keyEntry <= 122)) ||
                     (keyEntry == 46) || (keyEntry == 32) || keyEntry == 45 || (keyEntry == 32) || keyEntry == 45
                     || (keyEntry == 241) || keyEntry == 209
                     || (keyEntry == 225) || keyEntry == 233
                     || (keyEntry == 237) || keyEntry == 243
                     || (keyEntry == 243) || keyEntry == 250
                     || (keyEntry == 193) || keyEntry == 201
                     || (keyEntry == 205) || keyEntry == 211
                     || (keyEntry == 218) ||(keyEntry >=48 && keyEntry<=57) || (keyEntry == 40) || keyEntry == 41 || keyEntry == 44 || keyEntry == 95 || keyEntry == 64) 
                return true;
            else {
                return false;
            }
        }
            </script>  
  
</asp:Content>
