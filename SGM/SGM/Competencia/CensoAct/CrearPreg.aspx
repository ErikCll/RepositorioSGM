﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CrearPreg.aspx.cs" Inherits="SGM.Competencia.CensoAct.CrearPreg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Crear cuestionario<br />
     <label class="font-weight-normal text small">Evaluacion: </label>
    <asp:Label runat="server" ID="lblEvaluacion" CssClass=" font-weight-bold text small"></asp:Label>
    <asp:Label runat="server" ID="lblIdEvaluacion"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
<asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <div class="col-lg-12">
                <div class="row">
                                   <div class=" col-sm-8 col-md-8 col-lg-8">
                  <div class="card shadow-none border-top border-dark" >
                <div class="card-body">
                    <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Agregar Pregunta:</h4>
                               <label runat="server" id="lblContador"></label>
                        </div>
                        <div class="col-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                      <textarea runat="server" CssClass="form-control" ID="txtPregunta" onkeypress="return AllowAlphabet(event)" MaxLength="250" style="width:400px;height:100px"></textarea>
                                  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtPregunta"
                                    ErrorMessage="Pregunta requerida." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     <div class="col-sm-12 col-md-8 col-lg-6"></div>
                        <div class="col-sm-4 col-md-4 col-lg-4">
                            <div class="form-group">
                                <label>Tipo de respuesta:</label>
                                <asp:DropDownList runat="server" ID="ddl_Tipo" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddl_Tipo_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-6 col-lg-6">

                        </div>
                               <div class="col-sm-6 col-md-6 col-lg-6" runat="server" id="divMultiple" >
                                 <div class="form-group">
                                     <label>Respuesta 1:</label>
                                     <asp:TextBox runat="server" CssClass="form-control" ID="txt1" BorderColor="Green"></asp:TextBox>
                                 </div>
                                    <div class="form-group">
                                     <label>Respuesta 2:</label>
                                     <asp:TextBox runat="server" CssClass="form-control" ID="txt2"></asp:TextBox>
                                 </div>
                                    <div class="form-group">
                                     <label>Respuesta 3:</label>
                                     <asp:TextBox runat="server" CssClass="form-control" ID="txt3"></asp:TextBox>
                                 </div>
                                    <div class="form-group">
                                     <label>Respuesta 4:</label>
                                     <asp:TextBox runat="server" CssClass="form-control" ID="txt4"></asp:TextBox>
                                 </div>
                        </div>
                                                    <div class="col-sm-6 col-md-6 col-lg-6" runat="server" id="DivTrue" visible="false">
                                                        <div class="form-group ">
                                                            <asp:CheckBox runat="server" id="chkTrue"/>
                                                            <asp:TextBox runat="server" CssClass="form-control" placeholder="Verdadero" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                          <div class="form-group ">
                                                            <asp:CheckBox runat="server" ID="chkFalse"/>
                                                            <asp:TextBox runat="server" CssClass="form-control" placeholder="Falso" ReadOnly="true"></asp:TextBox>
                                                        </div>
                                                     </div>
                                                                            <div class="col-sm-12 col-md-12 col-lg-12">

                        </div>                
                        <div class="col-sm-12 col-md-12 col-lg-6">
                            <div class="form-group">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar y continuar" ID="btnGuardar" OnClick="btnGuardar_Click"  ValidationGroup="btnGuardar"/>
<%--                                <asp:Button runat="server" CssClass=" btn btn-default" ID="btnRegresar" Text="Regresar"  OnClick="Regresar"/>--%>
                            </div>
                        </div>
                        </div>
                    </div>
                      </div>
            </div>
            <div class="col-sm-4 col-md-4 col-lg-4">
                  <div class="card shadow-none border-top border-primary" >
                <div class="card-body">
                    <div class="row">
                           <div class="col-sm-12 col-md-12 col-lg-12">
                            <h4>Lista de Preguntas</h4>
                        </div>

                        <ol id="ordered">
   <asp:ListView runat="server" ID="lstPreguntas">
                            <ItemTemplate>
                                
                               <li><label class=" font-weight-bold"><%# Eval("Pregunta") %></label></li>  
                            </ItemTemplate>
                        </asp:ListView>
                        </ol>
                     
                  
                     
                                        
                    
                        </div>
                    </div>
                      </div>
            </div>

                </div>
             
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
     <script type="text/javascript">

              Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {
                var chkTrue = $("#<%=chkTrue.ClientID%>");
                   
                var chkFalse = $("#<%=chkFalse.ClientID%>");
                     chkTrue.click(function () {
                       chkFalse.prop('checked', false);
             

                   });
                   chkFalse.click(function () {
                         if (chkFalse.prop('checked')==false) {
            
                         }
                         else {
                               chkTrue.prop('checked', false);

                          
                         }

                });

                $('#ordered li').each(function(i,el){
                 el.id = i+1;
              });

          });
           <%--     function DisableButton() {
                document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
                document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando...";


  }
  window.onbeforeunload = DisableButton;
                --%>

                function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
                 if (((keyEntry >= 65) && (keyEntry <= 90)) ||
                     ((keyEntry >= 97) && (keyEntry <= 122)) ||
                     (keyEntry == 46) || (keyEntry == 32) || keyEntry == 45 || (keyEntry == 32) || keyEntry == 45 || keyEntry == 63 || keyEntry == 33 || keyEntry == 168

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
