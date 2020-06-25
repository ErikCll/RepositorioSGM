using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class Evaluacion
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Codigo { get; set; }
        public string IdEvaluacion { get; set; }
        public string IdPregunta { get; set; }


        public DataTable MostrarPregunta (int IdEvaluacion)
        {

            string query = "SELECT Pregunta FROM Ev_Pregunta WHERE Id_Evaluacion=@IdEvaluacion";
     

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEvaluacion", IdEvaluacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public bool Insertar(int IdControl, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Evaluacion] (Id_Control,Nombre) VALUES(@Id_Control,@Nombre)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Control", IdControl);
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
        public bool InsertarPregunta(int IdEvaluacion, string Pregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Ev_Pregunta] (Id_Evaluacion,Pregunta) VALUES(@Id_Evaluacion,@Pregunta)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Evaluacion", IdEvaluacion);
            comm.Parameters.AddWithValue("@Pregunta", Pregunta);
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
        public bool InsertarRespuestaMultiple(int IdPregunta, string Respuesta,string EsRespuesta)
        {
            comm.Connection = conexion.AbrirConexion();
            if (EsRespuesta == "1")
            {
                comm.CommandText = "INSERT INTO [Ev_Respuesta] (Id_Pregunta,Respuesta,EsRespuesta) VALUES(@IdPregunta,@Respuesta,1)";

            }
            else
            {
                comm.CommandText = "INSERT INTO [Ev_Respuesta] (Id_Pregunta,Respuesta,EsRespuesta) VALUES(@IdPregunta,@Respuesta,0)";
            }
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            comm.Parameters.AddWithValue("@Respuesta", Respuesta);
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

        public bool InsertarRespuestaVoF(int IdPregunta, string Respuesta, string EsRespuesta)
        {
            comm.Connection = conexion.AbrirConexion();
            if (EsRespuesta == "1")
            {
                comm.CommandText = "INSERT INTO [Ev_Respuesta] (Id_Pregunta,Respuesta,EsRespuesta) VALUES(@IdPregunta,@Respuesta,1)";

            }
            else
            {
                comm.CommandText = "INSERT INTO [Ev_Respuesta] (Id_Pregunta,Respuesta,EsRespuesta) VALUES(@IdPregunta,@Respuesta,0)";
            }
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            comm.Parameters.AddWithValue("@Respuesta", Respuesta);
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

        public void LeerDatosControl(int Id_Control)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Codigo FROM Cat_ActividadControl WHERE Id_Control=@Id_Control";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Control", Id_Control);

            dr = comm.ExecuteReader();
            dr.Read();
            Codigo = dr["Codigo"].ToString();



            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
        public void ObtenerIdEvaluacion(int IdControl)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP(1) Id_Evaluacion FROM Evaluacion WHERE Id_Control=@IdControl ORDER BY Id_Evaluacion DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdControl", IdControl);

            dr = comm.ExecuteReader();
            dr.Read();
            IdEvaluacion = dr["Id_Evaluacion"].ToString();



            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void ObtenerIdPregunta(int IdEvaluacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP(1) Id_Pregunta FROM Ev_Pregunta WHERE Id_Evaluacion=@IdEvaluacion ORDER BY Id_Pregunta DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEvaluacion", IdEvaluacion);

            dr = comm.ExecuteReader();
            dr.Read();
            IdPregunta = dr["Id_Pregunta"].ToString();



            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}