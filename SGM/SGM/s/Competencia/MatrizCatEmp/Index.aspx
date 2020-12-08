<%@ Page Title="" Language="C#" MasterPageFile="~/s/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGM.Competencia.MatrizCatEmp.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        Matriz Categoría-Empleado

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
     <li class="breadcrumb-item active"><asp:LinkButton runat="server" OnClick="IrSAM">SAM</asp:LinkButton></li>
                  <li class="breadcrumb-item "><a href="../../Inicio.aspx">SGM (Inicio)</a></li>
                      <li class="breadcrumb-item "><a href="../Inicio.aspx">Competencia y formación</a></li>

                     <li class="breadcrumb-item "><a>  Matriz Categoría-Empleado</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
        <style>
    .VerticalHeaderText {
       writing-mode:vertical-rl;
    }
</style>
          <div class="col-lg-12">
                <div class="row">
                     <div class="col-sm-12 col-md-12 col-lg-12">

                <div class="card ">
                    <div class="card-body">
                        <div class="row">
                               <div class="col-sm-4 col-md-4 col-lg-8">
                    <a href="Detalle.aspx" class="float-left">Detalle Matriz Categoría-Empleado</a>


                            </div>
                                <div class="container col-12">

                   <br />
                        <div class=" table-responsive">
                            <div style="overflow:auto ;height:auto">
                                <asp:GridView runat="server" 
                                 CssClass=" table table-bordered table-striped table-sm"
                                   HeaderStyle-BackColor="#343a40"
                                     HeaderStyle-CssClass=" text-white"
                                            GridLines="Horizontal"
                                   id="gridMatriz"
                                     HeaderStyle-HorizontalAlign="Center"
                                    AutoGenerateColumns="true"
                                     EmptyDataText="Sin registros."
                               OnRowDataBound="gridMatriz_RowDataBound"
                                HeaderStyle-VerticalAlign="Middle"
                                    >
                             
                                </asp:GridView>
                              <asp:Button runat="server" CssClass="btn btn-default" ID="btnRegresar" PostBackUrl="~/s/Competencia/Inicio.aspx" Text="Regresar" />

                            </div>
                        </div>
                    </div>
                            </div>


                        </div>

                    </div>
                        </div>
                
                </div>
            </div>
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
