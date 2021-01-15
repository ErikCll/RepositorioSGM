using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SASISOPA.Clase
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

            string query = "SELECT cat.Id_Categoria,cat.Nombre,area.Nombre 'Area',act.TotalAct,ISNULL(t1.TotalActCat, 0)'TotalActCat' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion JOIN(SELECT Id_Instalacion,COUNT(*) 'TotalAct' FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades WHERE act.Activado IS NULL AND act.TipoSistema = 2 GROUP BY InsAct.Id_Instalacion) act on ins.Id_instalacion = act.Id_Instalacion LEFT JOIN(SELECT Id_Categoria, COUNT(*) 'TotalActCat',Id_Instalacion FROM Op_Cat_Act WHERE Id_Instalacion = @IdInstalacion GROUP BY Id_Categoria,Id_Instalacion) t1 on cat.Id_Categoria = t1.Id_Categoria WHERE cat.Activado IS NULL AND ins.Id_instalacion =@IdInstalacion ORDER BY cat.Id_Categoria DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT cat.Id_Categoria,cat.Nombre,area.Nombre 'Area',act.TotalAct,ISNULL(t1.TotalActCat, 0)'TotalActCat' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion JOIN(SELECT Id_Instalacion,COUNT(*) 'TotalAct' FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades WHERE act.Activado IS NULL AND act.TipoSistema = 2 GROUP BY InsAct.Id_Instalacion) act on ins.Id_instalacion = act.Id_Instalacion LEFT JOIN(SELECT Id_Categoria, COUNT(*) 'TotalActCat',Id_Instalacion FROM Op_Cat_Act WHERE Id_Instalacion = @IdInstalacion GROUP BY Id_Categoria,Id_Instalacion) t1 on cat.Id_Categoria = t1.Id_Categoria  WHERE cat.Activado IS NULL AND ins.Id_instalacion =@IdInstalacion  AND cat.Nombre LIKE '%'+@txtSearch+'%' ORDER BY cat.Id_Categoria DESC";
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
        public DataTable MostrarGeneral(int IdInstalacion,int IdSuscripcion)
        {

            //string query = "DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX) DECLARE @Id_Instalacion as NVARCHAR(MAX)set @Id_Instalacion = @IdInstalacion DECLARE @Id_Suscripcion as NVARCHAR(MAX)set @Id_Suscripcion = @IdSuscripcion select @cols = STUFF((SELECT ',' + QUOTENAME(cat.Nombre) FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE ins.Id_instalacion = @Id_Instalacion AND cat.Activado IS NULL AND ins.Id_Suscripcion=@IdSuscripcion FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'') set @query = 'SELECT Actividad,ISNULL(ar,''0'') Archivo,' + @cols + ' from (select actividad, Categoria,ar FROM(SELECT act.nombre Actividad, cat.Nombre Categoria,r.max_score ar  FROM Op_Cat_Act catact LEFT JOIN Cat_Categoria cat on catact.Id_Categoria = cat.Id_Categoria RIGHT JOIN(SELECT InsAct.Id, act.Nombre,act.Id_Actividades FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades WHERE InsAct.Id_Instalacion = '+@Id_Instalacion+' AND act.Activado IS NULL AND act.TipoSistema = 2 AND act.Id_Suscripcion='+@Id_Suscripcion+') act on catact.Id_Actividad = act.Id LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad WHERE cat.Activado IS NULL) as tabla) x pivot (MAX(Categoria) for Categoria in (' + @cols + ') ) p 'execute(@query);";

            string query = "DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX) DECLARE @Id_Instalacion as NVARCHAR(MAX)set @Id_Instalacion = @IdInstalacion DECLARE @Id_Suscripcion as NVARCHAR(MAX)set @Id_Suscripcion = @IdSuscripcion select @cols = STUFF((SELECT ',' + QUOTENAME(cat.Nombre) FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE ins.Id_instalacion = @Id_Instalacion AND cat.Activado IS NULL AND ins.Id_Suscripcion=@IdSuscripcion FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'') set @query = 'SELECT Actividad,ISNULL(ar,''0'') Archivo,' + @cols + ' from (select actividad, Categoria,ar FROM(SELECT act.nombre Actividad, cat.Nombre Categoria,r.max_score ar  FROM Op_Cat_Act catact LEFT JOIN Cat_Categoria cat on catact.Id_Categoria = cat.Id_Categoria RIGHT JOIN(SELECT InsAct.Id, act.Nombre,act.Id_Actividades,InsAct.Id_Instalacion FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades WHERE InsAct.Id_Instalacion = '+@Id_Instalacion+' AND act.Activado IS NULL AND act.TipoSistema = 2 AND act.Id_Suscripcion='+@Id_Suscripcion+') act on catact.Id_Actividad = act.Id_Actividades AND catact.id_instalacion=act.Id_Instalacion LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad WHERE cat.Activado IS NULL) as tabla) x pivot (MAX(Categoria) for Categoria in (' + @cols + ') ) p 'execute(@query);";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarActividades(int IdCategoria,int IdInstalacion)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad', act.Nombre,ins.Nombre 'Instalacion', CAST(CASE WHEN CatAct.Id_Actividad IS NULL THEN 0 else CatAct.Id_Actividad END as bit) 'Id_registro',  CASE WHEN CatAct.Id_Actividad IS NULL THEN 0 else CatAct.Id_Actividad END 'Id_registro2' FROM (SELECT InsAct.Id, act.Id_Actividades, act.Nombre,InsAct.Id_Instalacion FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades WHERE InsAct.Id_Instalacion = @IdInstalacioon AND act.Activado IS NULL AND act.TipoSistema = 2) act LEFT JOIN(SELECT Id_Actividad FROM Op_Cat_Act WHERE Id_Categoria = @Id_Categoria) CatAct on act.Id_Actividades = CatAct.Id_Actividad JOIN Cat_Instalacion ins on act.Id_Instalacion=ins.Id_instalacion ORDER BY Id_registro DESC";
       

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Categoria", IdCategoria);
            comm.Parameters.AddWithValue("@IdInstalacioon", IdInstalacion);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }
        public DataTable MostrarTodasActividades(int IdCategoria,int IdInstalacion)
        {

            string query = "SELECT act.Id 'Id_Actividad', act.Nombre, area.Nombre 'Area', CAST(CASE WHEN CatAct.Id_Actividad IS NULL THEN 0 else CatAct.Id_Actividad END as bit) 'Id_registro', CASE WHEN CatAct.Id_Actividad IS NULL THEN 0 else CatAct.Id_Actividad END 'Id_registro2' FROM(SELECT InsAct.Id, act.Id_Actividades, act.Nombre, area.Id_Area, area.Nombre 'Area' FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades JOIN Cat_Area area on InsAct.Id_Area = area.Id_area WHERE InsAct.Id_Instalacion = @Id_Instalacionn AND act.Activado IS NULL AND act.TipoSistema = 2) act LEFT JOIN(SELECT Id_Actividad FROM Op_Cat_Act WHERE Id_Categoria = @Id_Categoria) CatAct on act.Id = CatAct.Id_Actividad JOIN Cat_Area area on act.Id_Area = area.Id_Area ORDER BY Id_registro DESC, act.Id_Area DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Categoria", IdCategoria);
            comm.Parameters.AddWithValue("@Id_Instalacionn", IdInstalacion);


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

        public bool Insertar(int IdCategoria, int IdActividad,int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Op_Cat_Act] (Id_Categoria,Id_Actividad,Id_Instalacion) VALUES(@IdCategoria,@Id_Actividad,@IdInstalacion)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IdCategoria", IdCategoria);
            comm.Parameters.AddWithValue("@Id_Actividad", IdActividad);
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);

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