using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGL.Clase
{
    public class InstalacionActividad
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;


        public DataTable MostrarGeneral(int IdSuscripcion, int IdUsuario)
        {

            string query = "DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX) DECLARE @Id_Suscripcion as NVARCHAR(MAX) SET @Id_Suscripcion=@IdSuscripcion select @cols = STUFF((SELECT ',' + QUOTENAME(Nav.Nombre)  FROM Cat_Instalacion Nav JOIN(SELECT Id_Instalacion FROM Op_UsIns WHERE Id_Usuario=@IdUsuario) UsAct on Nav.Id_instalacion = UsAct.Id_Instalacion WHERE nav.Activado IS NULL AND nav.Id_Suscripcion = @IdSuscripcion  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'') set @query = 'SELECT Actividad,' + @cols + ' from (select actividad, Instalacion FROM(SELECT act.Nombre Actividad, cat.Nombre Instalacion FROM Op_Ins_Act catact LEFT JOIN Cat_Instalacion cat on catact.Id_Instalacion = cat.Id_Instalacion RIGHT JOIN Cat_Actividades act on catact.Id_Actividad = act.Id_Actividades WHERE act.Activado Is null AND cat.Activado IS NULL AND act.TipoSistema = 2 AND act.Id_Suscripcion=' + @Id_Suscripcion + ') as tabla) x pivot(MAX(Instalacion)  for Instalacion in (' + @cols + ') ) p 'execute(@query);";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarActividades(int IdInstalacion,int IdSuscripcion)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad', act.Nombre, CAST(CASE WHEN InsAct.Id_Actividad IS NULL THEN 0 else InsAct.Id_Actividad END as bit) 'Id_registro', CASE WHEN InsAct.Id_Actividad IS NULL THEN 0 else InsAct.Id_Actividad END 'Id_registro2' FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad, Id_Area FROM Op_Ins_Act WHERE Id_Instalacion = @IdInsstalacion) InsAct on act.Id_Actividades = InsAct.Id_Actividad WHERE act.Activado IS NULL AND act.TipoSistema = 3 AND act.Id_Suscripcion=@IdSuscripcionn ORDER BY Id_registro DESC, act.Id_Actividades DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInsstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@IdSuscripcionn", IdSuscripcion);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarArea(int IdInstalacion)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Area, Nombre FROM Cat_Area WHERE Activado IS NULL AND Id_Instalacion=@Id_Instalacionn ORDER BY Id_area DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Instalacionn", IdInstalacion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarInstalacion(int IdSuscripcion, int IdUsuario)
        {

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nav.Id_instalacion, Nav.Nombre  FROM Cat_Instalacion Nav JOIN(SELECT Id_Instalacion FROM Op_UsIns WHERE Id_Usuario=@IdUsuario) UsAct on Nav.Id_instalacion = UsAct.Id_Instalacion WHERE nav.Activado IS NULL AND nav.Id_Suscripcion = @IdSuscripcion ORDER BY nav.Id_instalacion DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdInstalacion, int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Op_Ins_Act] (Id_Instalacion,Id_Actividad) VALUES(@IdInstalacion,@Id_Actividad)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@Id_Actividad", IdActividad);
            int i = comm.ExecuteNonQuery();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }

        public bool Eliminar(int IdInstalacion, int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "DELETE FROM Op_Ins_Act WHERE Id_Instalacion=@IdInstaalacion AND Id_Actividad=@Id_Actividad";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IdInstaalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@Id_Actividad", IdActividad);
            int i = comm.ExecuteNonQuery();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }


    }

}



