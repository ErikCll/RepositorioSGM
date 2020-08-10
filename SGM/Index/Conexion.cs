using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Index
{
    public class Conexion
    {
        private SqlConnection Conexionn = new SqlConnection("Server=tcp:jcol.database.windows.net,1433;Initial Catalog=orygon;Persist Security Info=False;User ID=jcol;Password=Sopenco21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");




        public SqlConnection AbrirConexion()
        {
            if (Conexionn.State == ConnectionState.Closed)
                Conexionn.Open();
            return Conexionn;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexionn.State == ConnectionState.Open)
                Conexionn.Close();
            return Conexionn;


        }
    }
}