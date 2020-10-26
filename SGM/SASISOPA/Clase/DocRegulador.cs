using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SASISOPA.Clase
{
    public class DocRegulador
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string Nombre { get; set; }
        public string IdRegulador { get; set; }

        public DataTable Mostrar(string txtSearch, int IdSuscripcion)
        {

            string query = "SELECT doc.Id_DocRegulador, doc.Nombre, reg.Nombre 'Regulador' FROM Cat_Regulador reg JOIN Cat_DocRegulador doc on reg.Id_Regulador = doc.Id_Regulador WHERE doc.Activado IS NULL AND reg.Id_Suscripcion =@IdSuscripcion ORDER BY doc.Id_DocRegulador DESC ";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT doc.Id_DocRegulador, doc.Nombre, reg.Nombre 'Regulador' FROM Cat_Regulador reg JOIN Cat_DocRegulador doc on reg.Id_Regulador = doc.Id_Regulador WHERE doc.Activado IS NULL AND reg.Id_Suscripcion =@IdSuscripcion AND doc.Nombre LIKE '%' + @txtSearch + '%' ORDER BY doc.Id_DocRegulador DESC ";
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

        public DataTable MostrarRegulador(int IdSuscripcion)
        {

            string query = "SELECT Id_Regulador,Nombre FROM Cat_Regulador WHERE Activado IS NULL AND Id_Suscripcion=@IdSuscripcionn ORDER BY Id_Regulador DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcionn", IdSuscripcion);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdRegulador, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_DocRegulador] (Nombre,Id_Regulador) VALUES(@Nombre,@IdRegulador)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdRegulador", IdRegulador);
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
        public bool Editar(int IdDocRegulador, string Nombre,int IdRegulador)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_DocRegulador SET Nombre = @Nombre, Id_Regulador=@IdRegulador WHERE Id_DocRegulador = @Id_DocRegulador";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_DocRegulador", IdDocRegulador);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@IdRegulador", IdRegulador);


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

        public bool Eliminar(int IdDocRegulador)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_DocRegulador SET Activado=1  WHERE Id_DocRegulador = @Id_DocRegulador";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_DocRegulador", IdDocRegulador);
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

        public void LeerDatos(int IdDocRegulador)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT doc.Nombre, reg.Id_Regulador FROM Cat_Regulador reg JOIN Cat_DocRegulador doc on reg.Id_Regulador = doc.Id_Regulador WHERE doc.Id_DocRegulador=@IdDocRegulador";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdDocRegulador", IdDocRegulador);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            IdRegulador = dr["Id_Regulador"].ToString();


            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}