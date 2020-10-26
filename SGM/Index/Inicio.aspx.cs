using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM
{
    public partial class Inicio : System.Web.UI.Page
    {
       
        Clase.Login login = new Clase.Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
              
                    (this.Master as SAM.Site1).OcultarDrop = false;
                    (this.Master as SAM.Site1).OcultarLabel = false;
                ListaImagen();
                ListaImagen2();
                int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario.ToString());

                if (login.ValidarSGM(IdUsuario))
                {
                    SitioSGM.Visible = true;
                }
                if (login.ValidarSASISOPA(IdUsuario))
                {
                    SitioSASISOPA.Visible = true;
                }
                if (login.ValidarOperacion(IdUsuario))
                {
                    SitioOperacion.Visible = true;
                }

                if (login.ValidarMantenimiento(IdUsuario))
                {
                    SitioMantenimiento.Visible = true;

                }

                if (login.ValidarSeguridadIndustrial(IdUsuario))
                {
                    SitioSeguridad.Visible = true;
                }

                if (login.ValidarAdministracion(IdUsuario))
                {
                    SitioAdministracion.Visible = true;
                }

                if (login.ValidarSGL(IdUsuario))
                {
                    SitioSGL.Visible = true;
                }
            }

        }

        public void ListaImagen()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion.ToString());

            listaImg.DataSource = (login.MostrarImagen(IdSuscripcion));
            listaImg.DataBind();

        }

        public void ListaImagen2()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion.ToString());

            list2.DataSource = (login.MostrarImagen2(IdSuscripcion));
            list2.DataBind();

        }

        protected void listaImg_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label TipoImagen = (Label)e.Item.FindControl("TipoImagen");

                Label IdImagen = (Label)e.Item.FindControl("IdImagen");

                Image img = (Image)e.Item.FindControl("img");


                if (TipoImagen.Text == ".jpg")
                {
                    img.ImageUrl = "https://er2020.blob.core.windows.net/samimg/" + IdImagen.Text + ".jpg";

                }
                if (TipoImagen.Text == ".JPG")
                {
                    img.ImageUrl = "https://er2020.blob.core.windows.net/samimg/" + IdImagen.Text + ".JPG";

                }
                if (TipoImagen.Text == ".png")
                {
                    img.ImageUrl = "https://er2020.blob.core.windows.net/samimg/" + IdImagen.Text + ".png";

                }
                if (TipoImagen.Text == ".PNG")
                {
                    img.ImageUrl = "https://er2020.blob.core.windows.net/samimg/" + IdImagen.Text + ".PNG";

                }






            }


            //int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion.ToString());


            //if (e.Item.ItemType == ListViewItemType.DataItem)
            //{

            //    ListView childMenu = (ListView)e.Item.FindControl("Div1");

            //    if (valDiv == 1)
            //    {
            //        childMenu.Attributes.Add("class", "carousel-item active");
            //        valDiv = 0;

            //    }
            //    childMenu.Attributes.Add("class", "carousel-item");

            //    childMenu.DataSource=(login.MostrarImagen(IdSuscripcion));
            //    childMenu.DataBind();

            //    foreach (var item2 in childMenu.Items)
            //    {
            //        Label IdImagen = (Label)item2.FindControl("IdImagen");

            //        System.Web.UI.HtmlControls.HtmlImage img = (System.Web.UI.HtmlControls.HtmlImage)item2.FindControl("img");


            //        img.Src = "https://er2020.blob.core.windows.net/samimg/" + IdImagen.Text + ".jpg";
            //    }
            //}


        }

        protected void list2_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Label IdImagen = (Label)e.Item.FindControl("IdImagen");
                Label TipoImagen = (Label)e.Item.FindControl("TipoImagen");


                Image img = (Image)e.Item.FindControl("img");



                if (TipoImagen.Text == ".jpg")
                {
                    img.ImageUrl = "https://er2020.blob.core.windows.net/samimg/" + IdImagen.Text + ".jpg";

                }
                if (TipoImagen.Text == ".JPG")
                {
                    img.ImageUrl = "https://er2020.blob.core.windows.net/samimg/" + IdImagen.Text + ".JPG";

                }
                if (TipoImagen.Text == ".png")
                {
                    img.ImageUrl = "https://er2020.blob.core.windows.net/samimg/" + IdImagen.Text + ".png";

                }
                if (TipoImagen.Text == ".PNG")
                {
                    img.ImageUrl = "https://er2020.blob.core.windows.net/samimg/" + IdImagen.Text + ".PNG";

                }




            }
        }
    }
}