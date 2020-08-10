using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SASISOPA.Clase
{
    public class InstalacionActividad
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public DataTable MostrarGeneral()
        {

            string query = "DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX) select @cols = STUFF((SELECT ',' + QUOTENAME(Nombre) FROM Cat_Instalacion WHERE Activado IS NULL FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'') set @query = 'SELECT Actividad,' + @cols + ' from (select actividad, Instalacion FROM(SELECT act.Nombre Actividad, cat.Nombre Instalacion FROM Op_Ins_Act catact LEFT JOIN Cat_Instalacion cat on catact.Id_Instalacion = cat.Id_Instalacion RIGHT JOIN Cat_Actividades act on catact.Id_Actividad = act.Id_Actividades WHERE act.Activado Is null AND cat.Activado IS NULL AND act.TipoSistema = 2) as tabla) x pivot(MAX(Instalacion)  for Instalacion in (' + @cols + ') ) p 'execute(@query);";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarActividades(int IdArea)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad', act.Nombre, CAST(CASE WHEN InsAct.Id_Actividad IS NULL THEN 0 else InsAct.Id_Actividad END as bit) 'Id_registro', CASE WHEN InsAct.Id_Actividad IS NULL THEN 0 else InsAct.Id_Actividad END 'Id_registro2' FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad, Id_Area FROM Op_Ins_Act WHERE Id_area = @IdArea) InsAct on act.Id_Actividades = InsAct.Id_Actividad WHERE act.Activado IS NULL AND act.TipoSistema = 2 ORDER BY Id_registro DESC, act.Id_Actividades DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdArea", IdArea);

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

        public DataTable MostrarInstalacion()
        {

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP(40) Id_Instalacion, Nombre FROM Cat_Instalacion WHERE Activado IS NULL ORDER BY Id_Instalacion DESC";
            comm.CommandType = CommandType.Text;
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;
        }


        public bool Insertar(int IdInstalacion,int IdArea, int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Op_Ins_Act] (Id_Instalacion,Id_Area,Id_Actividad) VALUES(@IdInstalacion,@IdAreaa,@Id_Actividad)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@IdAreaa", IdArea);
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

        public bool Eliminar(int IdArea, int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "DELETE FROM Op_Ins_Act WHERE Id_Area=@IdAreea AND Id_Actividad=@Id_Actividad";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IdAreea", IdArea);
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



