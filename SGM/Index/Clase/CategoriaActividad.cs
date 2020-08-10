using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Index.Clase
{
    public class CategoriaActividad
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }


        public DataTable Mostrar(string txtSearch,int IdInstalacion)
        {

            string query = "SELECT cat.Id_Categoria,cat.Nombre,area.Nombre 'Area' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE cat.Activado IS NULL AND ins.Id_instalacion =@IdInstalacion ORDER BY cat.Id_Categoria DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT cat.Id_Categoria,cat.Nombre,area.Nombre 'Area' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area WHERE cat.Activado IS NULL AND cat.Nombre LIKE '%'+@txtSearch+'%' ORDER BY cat.Id_Categoria DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }
        public DataTable MostrarGeneral(int IdInstalacion)
        {

            string query = "DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX)  DECLARE	@Id_Instalacion as NVARCHAR(MAX) set @Id_Instalacion =@IdInstalacion select @cols = STUFF((SELECT ',' + QUOTENAME(cat.Nombre) FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE ins.Id_instalacion =  @Id_Instalacion AND cat.Activado IS NULL FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'') set @query = 'SELECT Actividad,' + @cols + ' from (select actividad, Categoria FROM(SELECT act.Nombre Actividad, cat.Nombre Categoria FROM Op_Cat_Act catact LEFT JOIN Cat_Categoria cat on catact.Id_Categoria = cat.Id_Categoria RIGHT JOIN Cat_Actividades act on catact.Id_Actividad = act.Id_Actividades JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE act.Activado Is null AND cat.Activado IS NULL AND ins.Id_instalacion ='+@Id_Instalacion+' ) as tabla) x pivot ( MAX(Categoria) for Categoria in (' + @cols + ') ) p 'execute(@query);";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarActividades(int IdCategoria,int IdArea)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad', act.Nombre, area.Nombre 'Area', CAST(CASE WHEN CatAct.Id_Actividad IS NULL THEN 0 else CatAct.Id_Actividad END as bit) 'Id_registro',CASE WHEN CatAct.Id_Actividad IS NULL THEN 0 else CatAct.Id_Actividad END 'Id_registro2' FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad FROM Op_Cat_Act WHERE Id_Categoria =@Id_Categoria) CatAct on act.Id_Actividades = CatAct.Id_Actividad JOIN Cat_Area area on act.Id_Area = area.Id_Area WHERE act.Activado IS NULL AND area.Id_Area=@IdArea ORDER BY Id_registro DESC,act.Id_Actividades DESC";
       

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Categoria", IdCategoria);
            comm.Parameters.AddWithValue("@IdArea", IdArea);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }
        public DataTable MostrarTodasActividades(int IdCategoria)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad', act.Nombre, area.Nombre 'Area', CAST(CASE WHEN CatAct.Id_Actividad IS NULL THEN 0 else CatAct.Id_Actividad END as bit) 'Id_registro',CASE WHEN CatAct.Id_Actividad IS NULL THEN 0 else CatAct.Id_Actividad END 'Id_registro2' FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad FROM Op_Cat_Act WHERE Id_Categoria =@Id_Categoria) CatAct on act.Id_Actividades = CatAct.Id_Actividad JOIN Cat_Area area on act.Id_Area = area.Id_Area WHERE act.Activado IS NULL ORDER BY Id_registro DESC,act.Id_Actividades DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Categoria", IdCategoria);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarArea(int IdInstalacion)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Area, Nombre FROM Cat_Area WHERE Activado IS NULL AND Id_Instalacion=@Id_Instalacion ORDER BY Id_area DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdCategoria, int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Op_Cat_Act] (Id_Categoria,Id_Actividad) VALUES(@IdCategoria,@Id_Actividad)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IdCategoria", IdCategoria);
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

        public bool Eliminar(int IdCategoria, int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "DELETE FROM Op_Cat_Act WHERE Id_Categoria=@IdCategoria AND Id_Actividad=@Id_Actividad";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IdCategoria", IdCategoria);
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

        public void LeerDatos(int IdCategoria)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre FROM Cat_Categoria WHERE Id_Categoria=@Id_Categoria";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Categoria", IdCategoria);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            dr.Close();
            comm.Parameters.Clear();

            comm.Connection = conexion.CerrarConexion();



        }
    }
}