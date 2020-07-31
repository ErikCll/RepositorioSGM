<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Index.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"  >

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

div.responsive {
}

@media  (min-width: 600px) { // or whatever you are after
 div.responsive {
    display:none; // Hide BR tag for wider screens
  }
      
}
@media screen and (max-width: 650px) {
.ocultar-div{
display:none;
}
}

@media screen and (max-width: 650px) {
.quitarrow-div{
margin-top:200px;
}
}

.a:hover{
   background: rgba(76, 76, 76, 0.25);

}
    </style>
    
        <div class="col-lg-12 position-relative">
        <div class="row position-absolute" style="z-index:1">

          <!--Carousel Wrapper-->
<div id="carousel-example-2" class="carousel slide carousel-fade shadow" data-ride="carousel" >
  <!--Indicators-->
<%--  <ol class="carousel-indicators mb-5">
    <li data-target="#carousel-example-2" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-2" data-slide-to="1"></li>
    <li data-target="#carousel-example-2" data-slide-to="2"></li>
  </ol>--%>
  <!--/.Indicators-->
  <!--Slides-->
  <div class="carousel-inner" role="listbox" >
    <div class="carousel-item active ">
      <div class="view ">
        <img class="d-block w-100 img-fluid"  src="img/thumbnail_terminal .jpg"
          alt="First slide">
        <div class="mask rgba-black-light"></div>
      </div>
    
    </div>
    <div class="carousel-item">
      <!--Mask color-->
      <div class="view">
        <img class="d-block w-100 img-fluid" src="img/thumbnail_IMG_2285 (1).jpg"
          alt="Second slide">
        <div class="mask rgba-black-strong"></div>
      </div>
  
    </div>
    <div class="carousel-item">
      <!--Mask color-->
      <div class="view">
        <img class="d-block w-100 img-fluid" src="img/thumbnail_IMG_1507.jpg"
          alt="Third slide">
        <div class="mask rgba-black-slight"></div>
      </div>
   
    </div>
       
  </div>
  <!--/.Slides-->
  <!--Controls-->
  <a class="carousel-control-prev a" href="#carousel-example-2" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon a" aria-hidden="true"></span>
  </a>
  <a class="carousel-control-next a" href="#carousel-example-2" role="button" data-slide="next">
    <span class="carousel-control-next-icon a " aria-hidden="true"></span>
  </a>
  <!--/.Controls-->
</div>
<!--/.Carousel Wrapper-->

        </div>
     
            <div class=" ocultar-div" >
        <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                                <br />

                                <br />

                                <br />
                <br />

                <br />
                <br />
                <br />
            </div>
      






            <div class="row position-absolute quitarrow-div" style="z-index:2" >
                
            <div class="col-12 col-sm-6 col-md-4 mt-3">
           <asp:LinkButton runat="server" class="info-box shadow zoom">
              <span class="info-box-icon bg-info elevation-1"><i class="fas fa-tape"></i></span>

              <div class="info-box-content">
                <span class="info-box-text text-dark font-weight-bold">SGM</span>
                <span class="info-box-number text-black-50 text-sm">
                  Sistema de Gestión de las Mediciones<br />
                    <br />
                    <br />
                </span>
              </div>
              <!-- /.info-box-content -->
            </asp:LinkButton>
            <!-- /.info-box -->
          </div>

             <div class="col-12 col-sm-6 col-md-4 mt-3">
            <asp:LinkButton runat="server" class="info-box shadow zoom">
              <span class="info-box-icon bg-info elevation-1"><i class="fas fa-industry"></i></span>

              <div class="info-box-content">
                <span class="info-box-text text-dark font-weight-bold">SASISOPA</span>
                <span class="info-box-number text-black-50 text-sm">
                Sistema de Administración de Seguridad Industrial, Seguridad Operativa y Protección al Medio Ambiente
                </span>
              </div>
              <!-- /.info-box-content -->
            </asp:LinkButton>
            <!-- /.info-box -->
          </div>

              <div class="col-12 col-sm-6 col-md-4 mt-3">
            <asp:LinkButton runat="server" class="info-box shadow zoom" >
              <span class="info-box-icon bg-info elevation-1"><i class="fas fa-cogs"></i></span>

              <div class="info-box-content">
                <span class="info-box-text text-dark font-weight-bold">Operación</span>
                <span class="info-box-number text-black-50 text-sm">
                 <br />
                    <br />
                    <br />
                </span>
              </div>
              <!-- /.info-box-content -->
            </asp:LinkButton>
            <!-- /.info-box -->
          </div>

               <div class="col-12 col-sm-6 col-md-4 mt-3">
            <asp:LinkButton runat="server" class="info-box shadow zoom">
              <span class="info-box-icon bg-info elevation-1"><i class="fas fa-user-cog"></i></span>

              <div class="info-box-content">
                <span class="info-box-text text-dark font-weight-bold">Mantenimiento</span>
                <span class="info-box-number text-black-50 text-sm">
                 <br />
                    <br />
                    <br />
                </span>
              </div>
              <!-- /.info-box-content -->
            </asp:LinkButton>
            <!-- /.info-box -->
          </div>

                <div class="col-12 col-sm-6 col-md-4 mt-3">
            <asp:LinkButton runat="server" class="info-box shadow zoom">
              <span class="info-box-icon bg-info elevation-1"><i class="fas fa-hard-hat"></i></span>

              <div class="info-box-content">
                <span class="info-box-text text-dark font-weight-bold">Seguridad Industrial</span>
                <span class="info-box-number text-black-50 text-sm">
                 <br />
                    <br />
                    <br />
                </span>
              </div>
              <!-- /.info-box-content -->
            </asp:LinkButton>
            <!-- /.info-box -->
          </div>

                    <div class="col-12 col-sm-6 col-md-4 mt-3">
            <asp:LinkButton runat="server" class="info-box shadow zoom">
              <span class="info-box-icon bg-info elevation-1"><i class="fas fa-clipboard-check"></i></span>

              <div class="info-box-content">
                <span class="info-box-text text-dark font-weight-bold">Administración</span>
                <span class="info-box-number text-black-50 text-sm">
                 <br />
                    <br />
                    <br />
                </span>
              </div>
              <!-- /.info-box-content -->
            </asp:LinkButton>
            <!-- /.info-box -->
          </div>

            </div>
    </div>

</asp:Content>
