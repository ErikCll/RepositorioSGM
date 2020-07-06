using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class SistemaComponente
    {

        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string Nombre { get; set; }
        public string Sistema { get; set; }


        public DataTable Mostrar(int IdSistema)
        {

            string query = "SELECT com.Id_Componente,com.Nombre FROM Cat_SistemaComponente com JOIN Cat_SistemaMed sis on com.Id_Sistema = sis.Id_Sistema WHERE com.Activado IS NULL AND sis.Id_Sistema=@Id_SIstema ORDER BY com.Id_Componente DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_SIstema", IdSistema);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdSistema, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_SistemaComponente] (Id_Sistema,Nombre) VALUES(@Id_Sistema,@Nombre)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Sistema", IdSistema);
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

        public bool Editar(int IdComponente, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_SistemaComponente SET Nombre = @Nombre WHERE Id_Componente = @IdComponente";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdComponente", IdComponente);
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

        public bool Eliminar(int IdComponente)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_SistemaComponente SET Activado=1  WHERE Id_Componente = @Id_Componente";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Componente", IdComponente);
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

        public void LeerDatosSistema(int IdSistema)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre FROM Cat_SistemaMed WHERE Id_Sistema=@IdSistema";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSistema", IdSistema);

            dr = comm.ExecuteReader();
            dr.Read();
            Sistema = dr["Nombre"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosComponente(int IdComponente)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre FROM Cat_SistemaComponente WHERE Id_Componente=@Id_Componente";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Componente", IdComponente);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();



            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }


    }
}