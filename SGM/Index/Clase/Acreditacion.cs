using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
{
    public class Acreditacion
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        public SqlDataAdapter da;
        SqlDataReader dr;
        public string TotalInstalacion { get; set; }
        public string TotalDisponible { get; set; }



        public DataTable Mostrar(string txtSearch, int IdSuscripcion)
        {

            string query = "SELECT ins.Id_Instalacion, ins.Nombre,ins.Localizacion,acre.Numero 'No', acre.Referencia,CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha',sta2.Status, ISNULL(sta2.Id_status, 0) Id_status FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL ORDER BY sta2.Id_status DESC, ins.Id_Instalacion DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT ins.Id_Instalacion, ins.Nombre,ins.Localizacion,acre.Numero 'No', acre.Referencia,CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha',sta2.Status, ISNULL(sta2.Id_status, 0) Id_status FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL AND ins.Nombre LIKE '%'+@txtSearch+'%' ORDER BY sta2.Id_status DESC, ins.Id_Instalacion DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public void LeerDatosTotalInstalacion(int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) 'Total' from Cat_Instalacion WHERE Id_Suscripcion=@IdSuscripcion AND Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            dr = comm.ExecuteReader();
            dr.Read();
            TotalInstalacion = dr["Total"].ToString();
            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosTotalDisponible(int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) 'Disponible' FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion)  sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL AND sta2.Status in ('Inicio', 'Actualización')";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            dr = comm.ExecuteReader();
            dr.Read();
            TotalDisponible = dr["Disponible"].ToString();
            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}