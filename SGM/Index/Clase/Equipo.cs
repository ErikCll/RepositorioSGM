using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
{
    public class Equipo
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string IdEquipo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string NoInventario { get; set; }
        public string Serie { get; set; }
        public string Prueba { get; set; }
        public string IdInstalacion { get; set; }


        public DataTable Mostrar(string txtSearch, int IdInstalacion)
        {

            string query = "SELECT equi.Id_Equipo,equi.Nombre,equi.Marca,equi.Modelo,equi.Tipo,equi.No_inventario,equi.Serie,equi.Prueba, ins.Nombre 'Instalacion' FROM Cat_Equipo equi JOIN Cat_Instalacion ins on equi.Id_instalacion=ins.Id_instalacion WHERE equi.Id_Instalacion = @IdInstalacion AND equi.Activado IS NULL ORDER BY equi.Id_equipo DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT equi.Id_Equipo,equi.Nombre,equi.Marca,equi.Modelo,equi.Tipo,equi.No_inventario,equi.Serie,equi.Prueba, ins.Nombre 'Instalacion' FROM Cat_Equipo equi JOIN Cat_Instalacion ins on equi.Id_instalacion=ins.Id_instalacion WHERE equi.Id_Instalacion = @IdInstalacion AND equi.Activado IS NULL AND equi.Nombre LIKE '%'+@txtSearch+'%' ORDER BY equi.Id_equipo";
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

        public DataTable MostrarInstalacion(int IdSuscripcion)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL AND Id_Suscripcion=@IdSuscripcion ORDER BY Id_Instalacion DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public bool Insertar(string Nombre, string Marca, string Modelo, string Tipo, string NoInventario, string Serie, string Prueba, int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Equipo] (Id_Instalacion,Nombre,Marca,Modelo,Tipo,No_inventario,Serie,Prueba) VALUES(@IdInstalacionn,@Nombre,@Marca,@Modelo,@Tipo,@NoInventario,@Serie,@Prueba)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacionn", IdInstalacion);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Marca", Modelo);

            comm.Parameters.AddWithValue("@Modelo", Marca);
            comm.Parameters.AddWithValue("@Tipo", Tipo);
            comm.Parameters.AddWithValue("@NoInventario", NoInventario);
            comm.Parameters.AddWithValue("@Serie", Serie);
            comm.Parameters.AddWithValue("@Prueba", Prueba);

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

        public bool Editar(int IdEquipo, string Nombre, string Marca, string Modelo, string Tipo, string NoInventario, string Serie, string Prueba, int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Equipo SET Nombre = @Nombre, Marca = @Marca, Modelo = @Modelo, Tipo=@Tipo, No_inventario=@NoInventario, Serie=@Serie, Prueba=@Prueba, Id_Instalacion=@Id_Instalacion WHERE Id_Equipo = @Id_Equipo";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Equipo", IdEquipo);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Marca", Marca);
            comm.Parameters.AddWithValue("@Modelo", Modelo);
            comm.Parameters.AddWithValue("@Tipo", Tipo);
            comm.Parameters.AddWithValue("@NoInventario", NoInventario);
            comm.Parameters.AddWithValue("@Serie", Serie);
            comm.Parameters.AddWithValue("@Prueba", Prueba);
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);


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


        public bool Eliminar(int IdEquipo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Equipo SET Activado=1  WHERE Id_Equipo = @Id_Equipoo";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Equipoo", IdEquipo);
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
            comm.CommandText = "SELECT Id_Instalacion,Nombre,Marca,Modelo,Tipo,No_inventario,Serie,Prueba FROM Cat_Equipo WHERE Id_equipo = @IdEquipoo";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEquipoo", IdEquipo);

            dr = comm.ExecuteReader();
            dr.Read();
            IdInstalacion = dr["Id_Instalacion"].ToString();
            Nombre = dr["Nombre"].ToString();
            Marca = dr["Marca"].ToString();
            Modelo = dr["Modelo"].ToString();
            Tipo = dr["Tipo"].ToString();
            NoInventario = dr["No_inventario"].ToString();
            Serie = dr["Serie"].ToString();
            Prueba = dr["Prueba"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}