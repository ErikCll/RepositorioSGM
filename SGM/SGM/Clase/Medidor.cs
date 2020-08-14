using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class Medidor
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }
        public string VariableMedir { get; set; }
        public string PeriodoCalibracion { get; set; }
        public string PeriodoVerificacion { get; set; }



        public DataTable Mostrar(string txtSearch, int IdSuscripcion)
        {

            string query = "SELECT Id_Medidor,Nombre, VariableMedir, PeriodoCalibracion, PeriodoVerificacion FROM Cat_Medidor WHERE Activado IS NULL AND Id_Suscripcion=@IdSuscripcion ORDER BY Id_Medidor DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT Id_Medidor,Nombre, VariableMedir, PeriodoCalibracion, PeriodoVerificacion FROM Cat_Medidor WHERE Activado IS NULL AND Id_Suscripcion=@IdSuscripcion AND Nombre LIKE '%'+@txtSearch+'%' ORDER BY Id_Medidor DESC ";
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

        public bool Insertar(string Nombre, string Variable, int PeriodoCalibracion, int PeriodoVerificacion,int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Medidor] (Nombre,VariableMedir,PeriodoCalibracion,PeriodoVerificacion,Id_Suscripcion) VALUES(@Nombre,@VariableMedir,@PeriodoCalibracion,@PeriodoVerificacion,@IdSuscripcionn)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@VariableMedir", Variable);
            comm.Parameters.AddWithValue("@PeriodoCalibracion", PeriodoCalibracion);
            comm.Parameters.AddWithValue("@PeriodoVerificacion", PeriodoVerificacion);
            comm.Parameters.AddWithValue("@IdSuscripcionn", IdSuscripcion);


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

        public bool Editar(int IdMedidor, string Nombre, string Variable, int PeriodoCalibracion, int PeriodoVerificacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Medidor SET Nombre = @Nombre, VariableMedir = @VariableMedir, PeriodoCalibracion = @PeriodoCalibracion, PeriodoVerificacion= @PeriodoVerificacion  WHERE Id_Medidor = @IdMedidor";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdMedidor", IdMedidor);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@VariableMedir", Variable);
            comm.Parameters.AddWithValue("@PeriodoCalibracion", PeriodoCalibracion);
            comm.Parameters.AddWithValue("@PeriodoVerificacion", PeriodoVerificacion);


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

        public bool Eliminar(int IdMedidor)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Medidor SET Activado=1  WHERE Id_Medidor = @IdMedidor";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdMedidor", IdMedidor);
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

        public void LeerDatos(int IdMedidor)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre,VariableMedir,PeriodoCalibracion,PeriodoVerificacion FROM Cat_Medidor WHERE Id_Medidor =@IdMedidor ";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdMedidor", IdMedidor);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            VariableMedir = dr["VariableMedir"].ToString();
            PeriodoCalibracion = dr["PeriodoCalibracion"].ToString();
            PeriodoVerificacion = dr["PeriodoVerificacion"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }


    }
}