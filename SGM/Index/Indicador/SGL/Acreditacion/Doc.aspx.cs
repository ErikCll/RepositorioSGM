using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Index.Indicador.SGL.Acreditacion
{
    public partial class Doc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            string Id = decodedString;
            frame.Src = "https://er2020.blob.core.windows.net/sgl/Acreditacion/" + Id.ToString() + ".pdf";

        }
    }
}