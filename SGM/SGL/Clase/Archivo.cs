using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGL.Clase
{
    public class Archivo
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        public SqlDataAdapter da;
        SqlDataReader dr;
        public string Fecha { get; set; }
        public string Estatus { get; set; }

        public DataTable Mostrar( int IdAcreditacion)
        {

            string query = "SELECT acre.Id_Acreditacion, acre.Numero 'No',acre.Referencia, CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha',sta2.Status,ISNULL(sta2.Id_status, 0) 'Id_status' FROM Op_Acreditacion acre LEFT JOIN(SELECT MAX(Fecha) 'Fecha', Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE acre.Id_Instalacion = @IdInstalacion AND acre.Activado IS NULL AND acre.Acreditador = 'EMA' ORDER BY sta2.Fecha DESC";
     

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacion", IdAcreditacion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }
    }
}