<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Index.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Inicio
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mapeo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
     <style>
        .zoom {
 
  transition: transform .2s; /* Animation */

  margin: 0 auto;
}

.zoom:hover {
  transform: scale(0.9); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
}
    </style>
        <div class="col-lg-12">
        <br />
        <div class="row">
            <div class="col-sm-4 col-md-4 col-lg-4" runat="server" id="Panel1">
                <div   class="form-group">

                             <div class="card shadow zoom" style="border-left-color:#125886;border-left:solid steelblue">
  <asp:LinkButton runat="server" ID="linkEtapa1" PostBackUrl="http://localhost:10931/Inicio.aspx" class="card-body  ">
    <h4 class="card-title text-black">SGM</h4>
    <p class="card-text text-black"></p>
  </asp:LinkButton>
</div>
                </div>
   
            </div>
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="form-group">
  

                    </div>
   
            </div>
                <div class="col-sm-4 col-md-4 col-lg-4">
                    <div class="form-group">

  
                    </div>
  
            </div>
        </div>
    </div>

</asp:Content>
