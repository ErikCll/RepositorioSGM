using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
{
    public class Cliente
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }
        public string IdInstalacion { get; set; }


        public DataTable Mostrar(string txtSearch, int IdInstalacion)
        {

            string query = "SELECT cli.Id_Cliente, cli.Nombre,ins.Nombre 'Instalacion' FROM Cat_Cliente cli JOIN Cat_Instalacion ins on cli.Id_Instalacion = ins.Id_instalacion WHERE cli.Activado IS NULL AND ins.Id_Instalacion=@IdInstalacion ORDER BY cli.Id_Cliente DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT cli.Id_Cliente, cli.Nombre,ins.Nombre 'Instalacion' FROM Cat_Cliente cli JOIN Cat_Instalacion ins on cli.Id_Instalacion = ins.Id_instalacion WHERE cli.Activado IS NULL AND ins.Id_Instalacion=@IdInstalacion AND Nombre LIKE '%'+@txtSearch+'%' ORDER BY cli.Id_Cliente DESC";
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

        public bool Insertar(int IdInstalacion, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Cliente] (Id_Instalacion,Nombre) VALUES(@Id_Instalacion,@Nombre)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);
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

        public bool Editar(int IdCliente, string Nombre, int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Cliente SET Nombre = @Nombre,  Id_Instalacion = @Id_Instalacion WHERE Id_Cliente = @Id_Cliente";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Cliente", IdCliente);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
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

        public bool Eliminar(int IdCliente)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Cliente SET Activado=1  WHERE Id_Cliente = @Id_Cliente";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Cliente", IdCliente);
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

        public void LeerDatos(int IdCliente)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT cli.Nombre,ins.Nombre 'Instalacion',ins.Id_Instalacion FROM Cat_Cliente cli JOIN Cat_Instalacion ins on cli.Id_Instalacion=ins.Id_instalacion WHERE cli.Id_Cliente=@IdCliente";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdCliente", IdCliente);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            IdInstalacion = dr["Id_Instalacion"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}