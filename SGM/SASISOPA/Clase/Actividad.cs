using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SASISOPA.Clase
{
    public class Actividad
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
       
        public string Nombre { get; set; }
      


        public DataTable Mostrar(string txtSearch,int IdSuscripcion)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre, ISNULL(r.max_score, '0') 'Archivo',CONVERT(nvarchar, s.FechaEmision, 105) 'FechaEmision',ISNULL(s.VigenciaMeses, '0') 'VigenciaMeses',s.Codigo FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control WHERE act.Activado IS NULL AND act.TipoSistema = 2 AND act.Id_Suscripcion=@IdSuscripcion ORDER BY act.Id_Actividades DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre, ISNULL(r.max_score, '0') 'Archivo',CONVERT(nvarchar, s.FechaEmision, 105) 'FechaEmision',ISNULL(s.VigenciaMeses, '0') 'VigenciaMeses',s.Codigo FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control WHERE act.Activado IS NULL AND act.TipoSistema = 2 AND act.Id_Suscripcion=@IdSuscripcion AND act.Nombre LIKE '%' + @txtSearch + '%' ORDER BY act.Id_Actividades DESC";
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

        //public DataTable MostrarArea(int IdInstalacion)
        //{


        //    comm.Connection = conexion.AbrirConexion();
        //    comm.CommandText = "SELECT Id_Area, Nombre FROM Cat_Area WHERE Activado IS NULL AND Id_Instalacion=@Id_Instalacion ORDER BY Id_area DESC";
        //    comm.CommandType = CommandType.Text;
        //    comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);
        //    da = new SqlDataAdapter(comm);
        //    dt = new DataTable();
        //    da.Fill(dt);
        //    conexion.CerrarConexion();
        //    return dt;

        //}

        //public DataTable MostrarInstalacion()
        //{

        //    comm.Connection = conexion.AbrirConexion();
        //    comm.CommandText = "SELECT TOP(40) Id_Instalacion, Nombre FROM Cat_Instalacion WHERE Activado IS NULL ORDER BY Id_Instalacion DESC";
        //    comm.CommandType = CommandType.Text;
        //    da = new SqlDataAdapter(comm);
        //    dt = new DataTable();
        //    da.Fill(dt);
        //    conexion.CerrarConexion();
        //    return dt;
        //}

        public bool Insertar(int TipoSistema, string Nombre,int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Actividades] (Nombre,TipoSistema,Id_Suscripcion) VALUES(@Nombre,@TipoSistema,@IdSuscripcion)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@TipoSistema", TipoSistema);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);

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

        public bool Editar(int IdActividad, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Actividades SET Nombre = @Nombre WHERE Id_Actividades = @Id_Actividades";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividades", IdActividad);
            comm.Parameters.AddWithValue("@Nombre", Nombre);

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


        public bool Eliminar(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Actividades SET Activado=1  WHERE Id_Actividades = @Id_Actividades";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Actividades", IdActividad);
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
            Nombre = dr["Nombre"].ToString();
        
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}