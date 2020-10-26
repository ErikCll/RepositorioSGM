using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SASISOPA.Clase
{
    public class Regulador
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string Nombre { get; set; }
        public string NombreCorto { get; set; }

        public DataTable Mostrar(string txtSearch, int IdSuscripcion)
        {

            string query = "SELECT Id_Regulador,Nombre,Nombre_corto 'NombreCorto' FROM Cat_Regulador WHERE Id_Suscripcion= @IdSuscripcion AND Activado IS NULL ORDER BY Id_Regulador DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT Id_Regulador,Nombre,Nombre_corto 'NombreCorto' FROM Cat_Regulador WHERE Id_Suscripcion= @IdSuscripcion AND Activado IS NULL AND Nombre LIKE '%' + @txtSearch + '%'ORDER BY Id_Regulador DESC";
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


        public bool Insertar(int IdSuscripcion, string Nombre, string NombreCorto)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Regulador] (Nombre,Nombre_corto,Id_Suscripcion) VALUES(@Nombre,@NombreCorto,@IdSuscripcion)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@NombreCorto", NombreCorto);

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

        public bool Editar(int IdRegulador, string Nombre,string NombreCorto)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Regulador SET Nombre = @Nombre, Nombre_corto=@NombreCorto WHERE Id_Regulador = @Id_Regulador";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Regulador", IdRegulador);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@NombreCorto", NombreCorto);


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

        public bool Eliminar(int IdRegulador)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Regulador SET Activado=1  WHERE Id_Regulador = @Id_Regulador";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Regulador", IdRegulador);
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

        public void LeerDatos(int IdRegulador)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre,Nombre_corto 'NombreCorto' FROM Cat_Regulador WHERE Id_Regulador=@IdRegulador";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdRegulador", IdRegulador);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            NombreCorto = dr["NombreCorto"].ToString();


            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}