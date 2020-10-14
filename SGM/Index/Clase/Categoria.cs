using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SAM.Clase
{
    public class Categoria
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader dr;
        public string Nombre { get; set; }
        public string IdInstalacion { get; set; }
        public string Instalacion { get; set; }
        public string IdArea { get; set; }
        public string Area { get; set; }


        public DataTable Mostrar(string txtSearch,int IdInstalacion)
        {

            string query = "SELECT cat.Id_Categoria,cat.Nombre,area.Nombre 'Area',ins.Nombre 'Instalacion' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE cat.Activado IS NULL AND ins.Id_Instalacion=@IdInstalacion ORDER BY cat.Id_Categoria DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT cat.Id_Categoria,cat.Nombre,area.Nombre 'Area',ins.Nombre 'Instalacion' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE cat.Activado IS NULL AND cat.Nombre LIKE '%'+@txtSearch+'%' AND ins.Id_Instalacion=@IdInstalacion ORDER BY cat.Id_Categoria DESC";
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

        public DataTable MostrarInstalacion(int IdSuscripcion,string Correo)
        {

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nav.Id_instalacion, Nav.Nombre  FROM Cat_Instalacion Nav  JOIN(SELECT Id_Instalacion FROM Op_UsIns op JOIN Usuario us on op.Id_Usuario = us.Id_usuario WHERE us.Acceso = @Correo)UsAct on Nav.Id_instalacion = UsAct.Id_Instalacion WHERE nav.Activado IS NULL AND nav.Id_Suscripcion = @IdSuscripcionn ORDER BY nav.Id_instalacion DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcionn", IdSuscripcion);
            comm.Parameters.AddWithValue("@Correo", Correo);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;
        }

        public bool Insertar(int IdArea, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Categoria] (Id_Area,Nombre) VALUES(@Id_Area,@Nombre)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Area", IdArea);
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

        public bool Editar(int IdCategoria, string Nombre, int IdArea)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Categoria SET Nombre = @Nombre, Id_Area = @Id_Area WHERE Id_Categoria = @Id_Categoria";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Categoria", IdCategoria);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Id_Area", IdArea);

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

        public bool Eliminar(int IdArea)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Categoria SET Activado=1  WHERE Id_Categoria = @Id_Categoria";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Categoria", IdArea);
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


        public void LeerDatos(int IdCategoria)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT cat.Id_Categoria,cat.Nombre,area.Id_area, area.Nombre 'Area',ins.Id_Instalacion,ins.Nombre 'Instalacion' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area=area.Id_area JOIN Cat_Instalacion ins on area.Id_Instalacion=ins.Id_Instalacion WHERE cat.Id_Categoria=@Id_Categoria";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Categoria", IdCategoria);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            IdInstalacion = dr["Id_Instalacion"].ToString();
            Instalacion = dr["Instalacion"].ToString();
            IdArea = dr["Id_Area"].ToString();
            Area = dr["Area"].ToString();
            //dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }


}