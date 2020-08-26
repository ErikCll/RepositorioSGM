using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Operacion.Clase
{
    public class Bitacora
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }

        public DataTable Mostrar(string FechaInicio, int IdEquipo)
        {

            string query = "SELECT Id_Falla, Descripcion, CONVERT(nvarchar, ini_averia, 105) 'FechaInicio', FORMAT(ini_averia, 'hh:mm tt') 'HoraInicio', CONVERT(nvarchar, fin_averia, 105) 'FechaFin', FORMAT(fin_averia, 'hh:mm tt') 'HoraFin' FROM Op_Fallas WHERE Id_Equipo = @IdEquipoo AND Activado IS NULL ORDER BY Id_Falla DESC";
            if (!String.IsNullOrEmpty(FechaInicio.Trim()))
            {
                query = "SELECT Id_Falla, Descripcion, CONVERT(nvarchar, ini_averia, 105) 'FechaInicio', FORMAT(ini_averia, 'hh:mm tt') 'HoraInicio', CONVERT(nvarchar, fin_averia, 105) 'FechaFin', FORMAT(fin_averia, 'hh:mm tt') 'HoraFin' FROM Op_Fallas WHERE Id_Equipo = @IdEquipoo AND Activado IS NULL AND CONVERT(NVARCHAR, CAST(ini_averia AS Date),105)=@FechaInicio ORDER BY Id_Falla DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            comm.Parameters.AddWithValue("@IdEquipoo", IdEquipo);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public bool Insertar(int IdEquipo, string FechaHora, string Descripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Op_Fallas] (Id_Equipo,ini_averia,Descripcion) VALUES(@Id_Equipo,CONVERT(datetime,@FechaHora,103),@Descripcion)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Equipo", IdEquipo);
            comm.Parameters.AddWithValue("@FechaHora", FechaHora);
            comm.Parameters.AddWithValue("@Descripcion", Descripcion);
            int i = comm.ExecuteNonQuery();
            comm.Parameters.Clear();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }

        public bool Eliminar(int IdBitacora)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_Fallas SET Activado=1  WHERE Id_Falla = @IdBitacora";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdBitacora", IdBitacora);
            int i = comm.ExecuteNonQuery();
            comm.Parameters.Clear();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }

        public void LeerDatos(int IdEquipo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre FROM Cat_Equipo WHERE Id_Equipo=@IdEquipo AND Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEquipo", IdEquipo);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
   
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}