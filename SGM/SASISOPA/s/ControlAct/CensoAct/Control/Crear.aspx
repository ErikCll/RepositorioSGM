﻿<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="SASISOPA.s.ControlAct.CensoAct.Control.Crear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Crear control de versión
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
        <li class="breadcrumb-item active"><a href="../Index.aspx">Censo de actividad</a></li>
                  <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="Regresar">Control de versiones</asp:LinkButton></li>
                      <li class="breadcrumb-item active"><a>Crear</a></li>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">

     <asp:UpdatePanel runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Literal runat="server" ID="litControl"></asp:Literal>
            <div class="col-lg-12">
                  <div class="card" >
                      <div class="card-header">

                            <h4>Datos de la versión</h4>
                      </div>
                <div class="card-body">
                    <div class="row">
                          
                     
                     
                        <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Archivo:</label>
                               
                              <asp:FileUpload runat="server" ID="File1" />
                          

                            </div>
                               <asp:RequiredFieldValidator runat="server" ID="reqFile" ControlToValidate="File1"
                                    ErrorMessage="Debe seleccionar un archivo PDF." ForeColor="Red" ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="" ForeColor="Red"
                                                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.pdf)$" ControlToValidate="File1" ValidationGroup="btnGuardar">
                                                    </asp:RegularExpressionValidator>
                                  
                        </div>
                                             <div class="col-sm-12 col-md-12 col-lg-12">

                                                 </div>
                     <div class="col-sm-12 col-md-12 col-lg-4">
                            <div class="form-group">
                                <label class="font-weight-bold">Código:</label>

                                <asp:TextBox runat="server" class="form-control" id="txtCodigo" onkeypress="return AllowAlphabet(event)" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="reqCodigo" ControlToValidate="txtCodigo"
                                    ErrorMessage="Código requerido." ForeColor="Red"  ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>


                            </div>
                            <div class="col-sm-12 col-md-2"></div>
                        </div>
                              <div class="col-sm-12 col-md-12 col-lg-4">
                                    <div class="form-group">
                                    <label class="font-weight-bold">Fecha de emisión:</label>
                                        <asp:TextBox runat="server" ID="txtFecha" class="form-control ml-1 " placeholder="dd-mm-yyyy" onkeydown="return false;"></asp:TextBox>
                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtFecha"
                                    ErrorMessage="Fecha de emisión requerida." ForeColor="Red"  ValidationGroup="btnGuardar"></asp:RequiredFieldValidator>
                                     
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFecha" ValidationGroup="btnGuardar" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\-(0[1-9]|1[0-2])\-((19|20)\d\d))$"
                                        ErrorMessage="Formato incorrecto de fecha." ForeColor="Red" ></asp:RegularExpressionValidator>
                                </div>
                              </div>
                           <div class="col-sm-12 col-md-5 col-lg-5">
                <div class="form-group">
                    <label class="font-weight-bold">Sin vigencia:</label>
                    <asp:CheckBox runat="server" ID="checkSin"   />
                      <label class="font-weight-bold ml-1">Con vigencia:</label>
                    <asp:CheckBox runat="server" ID="checkCon" />
                </div>
                                 <div class="form-group" id="Div1" runat="server">
                                <label class="font-weight-bold">Cantidad de años:</label>
                                <asp:TextBox runat="server" ID="txtCantidad" MaxLength="2" CssClass="form-control" onkeypress="return soloNumeros(event)" Width="200px"></asp:TextBox>
                            </div>
            </div>

                       
                    
                        <div class="col-sm-12 col-md-12 col-lg-12"></div>


                                   <div class="col-sm-12 col-md-12 col-lg-12" id="Div2" runat="server" visible="false">
                <div class="form-group">
                    <label>Usar evaluación de la versión anterior:</label>
                    <label class="font-weight-bold">Si</label>
                    <asp:CheckBox runat="server" ID="chckSi"   />
                     <label class="font-weight-bold ml-1">No</label>
                    <asp:CheckBox runat="server" ID="chckNo"   />
                </div>
            </div>
        
                        <div class="col-sm-8 col-md-8 col-lg-8"></div>
               
                         
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                          
                            <div class="form-group">
                                <asp:Button class="btn btn-primary" id="btnGuardar" runat="server" Text="Guardar" ValidationGroup="btnGuardar" OnClick="btnGuardar_Click"/>

                                <asp:Button runat="server" ID="btnRegresar2" CssClass="btn btn-default" Text="Regresar" OnClick="Regresar" />


                            </div>
                        </div>
                       
                 
                        </div>
                    </div>
                      </div>
            </div>
        </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="btnGuardar" />
         </Triggers>
    </asp:UpdatePanel>
   
          <script type="text/javascript">
                 Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }
  
                             Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function(){

                                    var divP = $("#<%=Div1.ClientID%>");
                       divP.hide();
  var checkSin = $("#<%=checkSin.ClientID%>");
                   
                                 var checkCon = $("#<%=checkCon.ClientID%>");
                                   var chckSi = $("#<%=chckSi.ClientID%>");
                    var chckNo = $("#<%=chckNo.ClientID%>");

                    checkSin.click(function () {
                        if (checkSin.prop('checked') == false) {
                            checkCon.prop('checked', true);

                                                  divP.show();
                        }
                        else {
                                                        checkCon.prop('checked', false);
                               divP.hide();


                        }
                     
             

                   });
                     checkCon.click(function () {
                         if (checkCon.prop('checked') == false) {
                                  checkSin.prop('checked', true);

                               divP.hide();
            
                         }
                         else {
                               checkSin.prop('checked', false);

                      divP.show();
                          
                         }

                                 });


                                    chckSi.click(function () {
                        if (chckSi.prop('checked') == false) {
                            chckNo.prop('checked', true);

                        }
                        else {
                                                        chckNo.prop('checked', false);


                        }
                     
             

                   });
                     chckNo.click(function () {
                         if (chckNo.prop('checked') == false) {
                                  chckSi.prop('checked', true);

            
                         }
                         else {
                               chckSi.prop('checked', false);

                          
                         }

                   });
               
                   $("#<%=txtFecha.ClientID%>").datepicker({
                        dateFormat: 'dd-mm-yy',
                       maxDate: '+0D',
                     
                        changeMonth: true,
                        changeYear: true,
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo',
                            'Junio', 'Julio', 'Agosto', 'Septiembre',
                            'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr',
                            'May', 'Jun', 'Jul', 'Ago',
                            'Sep', 'Oct', 'Nov', 'Dic']
                  });

              });

                 function DisableButton() {
                document.getElementById("<%= btnGuardar.ClientID %>").disabled = true;
                     document.getElementById("<%= btnGuardar.ClientID %>").value = "Cargando...";
                     document.getElementById("<%=btnRegresar2.ClientID%>").disabled = true;
                     document.getElementById("<%=btnRegresar2.ClientID%>").value = "Cargando...";


  }
  window.onbeforeunload = DisableButton;

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

                                  function soloNumeros(e){
  var key = window.event ? e.which : e.keyCode;
  if (key < 48 || key > 57) {
    e.preventDefault();
  }
}
              </script>  

</asp:Content>
