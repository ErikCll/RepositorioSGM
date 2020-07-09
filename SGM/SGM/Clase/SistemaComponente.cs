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
        public string IdMedidor { get; set; }

        public string Sistema { get; set; }
        public string Tipo { get; set; }



        public DataTable Mostrar(int IdSistema)
        {

            string query = "SELECT com.Id_Componente,CASE WHEN com.Tipo=1 THEN med.Nombre ELSE com.Nombre END 'Nombre',CASE WHEN com.Tipo=1 THEN 'Medidor' ELSE 'Accesorio' END 'Tipo' FROM Cat_SistemaComponente com JOIN Cat_SistemaMed sis on com.Id_Sistema = sis.Id_Sistema LEFT JOIN Cat_Medidor med on com.Id_Medidor=med.Id_Medidor WHERE com.Activado IS NULL AND sis.Id_Sistema=@Id_SIstema ORDER BY com.Id_Componente DESC";


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

        public DataTable MostrarMedidor()
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Medidor,Nombre FROM Cat_Medidor WHERE Activado IS NULL ORDER BY Id_Medidor DESC";
            comm.CommandType = CommandType.Text;
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }
        public bool InsertarAccesorio(int IdSistema, string Nombre, int Tipo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_SistemaComponente] (Id_Sistema,Nombre,Tipo) VALUES(@Id_Sistema,@Nombre,@Tipo)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Sistema", IdSistema);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Tipo", Tipo);


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

        public bool InsertarMedidor(int IdSistema, int IdMedidor, int Tipo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_SistemaComponente] (Id_Sistema,Id_Medidor,Tipo) VALUES(@Id_Sistema,@IdMedidor,@Tipo)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Sistema", IdSistema);
            comm.Parameters.AddWithValue("@IdMedidor", IdMedidor);
            comm.Parameters.AddWithValue("@Tipo", Tipo);


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

        public bool EditarAccesorio(int IdComponente, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_SistemaComponente SET Nombre = @Nombre WHERE Id_Componente = @IdComponenteA";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdComponenteA", IdComponente);
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

        public bool EditarMedidor(int IdComponente, int IdMedidor)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_SistemaComponente SET Id_Medidor = @Id_Medidor WHERE Id_Componente = @IdComponenteM";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdComponenteM", IdComponente);
            comm.Parameters.AddWithValue("@Id_Medidor", IdMedidor);

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
            comm.CommandText = "SELECT ISNULL(Nombre,'') 'Nombre',ISNULL(Id_Medidor,'') 'Id_Medidor' FROM Cat_SistemaComponente WHERE Id_Componente=@Id_Componente";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Componente", IdComponente);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            IdMedidor = dr["Id_Medidor"].ToString();




            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }


        public void LeerTipo(int IdComponente)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Tipo FROM Cat_SistemaComponente WHERE Id_Componente=@IdComponente";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdComponente", IdComponente);

            dr = comm.ExecuteReader();
            dr.Read();
            Tipo = dr["Tipo"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}