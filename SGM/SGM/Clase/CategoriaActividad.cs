using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class CategoriaActividad
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }


        public DataTable Mostrar(string txtSearch)
        {

            string query = "SELECT cat.Id_Categoria,cat.Nombre,area.Nombre 'Area' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area WHERE cat.Activado IS NULL ORDER BY cat.Id_Categoria DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT cat.Id_Categoria,cat.Nombre,area.Nombre 'Area' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area WHERE cat.Activado IS NULL AND cat.Nombre LIKE '%'+@txtSearch+'%' ORDER BY cat.Id_Categoria DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarActividades(int IdCategoria)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad', act.Nombre, area.Nombre 'Area', CAST(CASE WHEN CatAct.Id_Actividad IS NULL THEN 0 else CatAct.Id_Actividad END as bit) 'Id_registro',CASE WHEN CatAct.Id_Actividad IS NULL THEN 0 else CatAct.Id_Actividad END 'Id_registro2' FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad FROM Op_Cat_Act WHERE Id_Categoria =@Id_Categoria) CatAct on act.Id_Actividades = CatAct.Id_Actividad JOIN Cat_Area area on act.Id_Area = area.Id_Area JOIN Cat_Categoria cat on act.Id_Area = cat.Id_Area WHERE act.Activado IS NULL ORDER BY Id_registro DESC,act.Id_Actividades DESC";
       

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