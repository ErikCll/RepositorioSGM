using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGL.Clase
{
    public class Archivo
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        public SqlDataAdapter da;
        SqlDataReader dr;
        public string IdStatus { get; set; }

        public string Fecha { get; set; }
        public string Estatus { get; set; }
        public string NoAcreditacion { get; set; }


        public DataTable Mostrar(int IdAcreditacion)
        {

            string query = "SELECT Id_Status, CONVERT(NVARCHAR, Fecha, 105) 'FechaStatus', status 'Estatus' FROM Op_AcreditacionStatus WHERE Id_Acreditacion = @IdAcreditacion AND Activado IS NULL ORDER BY Fecha DESC";
     

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdAcreditacion", IdAcreditacion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdAcreditacion, string Fecha, string Estatus)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT [Op_AcreditacionStatus] (Id_Acreditacion,Fecha,Status) VALUES(@IdAcreditacionn,CONVERT(datetime,@Fecha,103),@Status)";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdAcreditacionn", IdAcreditacion);
            comm.Parameters.AddWithValue("@Fecha", Fecha);
            comm.Parameters.AddWithValue("@Status", Estatus);

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

        public bool Eliminar(int IdStatus)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_AcreditacionStatus SET Activado=1  WHERE Id_Status = @Id_Status";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Status", IdStatus);
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

        public void LeerDatos(int IdStatus)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT CONVERT(NVARCHAR,Fecha,105) 'Fecha',Status 'Estatus' FROM Op_AcreditacionStatus WHERE Id_Status=@IdStatus";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdStatus", IdStatus);

            dr = comm.ExecuteReader();
            dr.Read();
            Fecha = dr["Fecha"].ToString();
            Estatus = dr["Status"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosAcreditacion(int IdAcreditacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Numero FROM Op_Acreditacion WHERE Id_Acreditacion=@IddAcreditacion";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IddAcreditacion", IdAcreditacion);

            dr = comm.ExecuteReader();
            dr.Read();
            NoAcreditacion = dr["Numero"].ToString();
           
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerId(int IdAcreditacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP 1 Id_Status FROM Op_AcreditacionStatus WHERE Id_Acreditacion=@Id_Acreditacionn ORDER BY Id_Status DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Acreditacionn", IdAcreditacion);

            dr = comm.ExecuteReader();
            dr.Read();
            IdStatus = dr["Id_Status"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}