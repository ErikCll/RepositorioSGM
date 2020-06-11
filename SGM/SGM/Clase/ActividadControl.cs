using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class ActividadControl
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string IdControl { get; set; }
        public string Codigo { get; set; }
        public string Actividad { get; set; }


        public DataTable Mostrar(int IdActividad)
        {

            string query = "SELECT Id_Control,Codigo,CONVERT(nvarchar,FechaCreacion, 105) 'FechaCreacion' FROM Cat_ActividadControl WHERE id_Actividad = @Id_Actividad AND Activado IS NULL ORDER BY Id_Control DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividad", IdActividad);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public bool Insertar(int IdActividad, string Codigo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_ActividadControl] (Id_Actividad,Codigo,FechaCreacion) VALUES(@Id_Actividad,@Codigo,GETDATE())";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividad", IdActividad);
            comm.Parameters.AddWithValue("@Codigo", Codigo);
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

        public void LeerDatos(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre FROM Cat_Actividades WHERE Id_Actividades=@Id_Actividades";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividades", IdActividad);

            dr = comm.ExecuteReader();
            dr.Read();
            Actividad = dr["Nombre"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerId(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP 1 Id_Control FROM Cat_ActividadControl WHERE Id_Actividad=@Id_Control ORDER BY Id_Control DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Control", IdActividad);

            dr = comm.ExecuteReader();
            dr.Read();
            IdControl = dr["Id_Control"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}