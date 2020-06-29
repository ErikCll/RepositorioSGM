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



        public string Pregunta { get; set; }

        public string IdRespuesta { get; set; }
        public string R1 { get; set; }
        public string R2 { get; set; }
        public string R3 { get; set; }
        public string R4 { get; set; }

        public string Respuesta { get; set; }






        public DataTable MostrarPregunta (int IdEvaluacion)
        {

            string query = "SELECT Id_Pregunta,Pregunta,TipoPregunta FROM Ev_Pregunta WHERE Id_Evaluacion=@IdEvaluacion AND Activado IS NULL";
     

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEvaluacion", IdEvaluacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();

            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarRespuesta(int IdPregunta)
        {

            string query = "SELECT Id_Respuesta, Respuesta, EsRespuesta FROM Ev_Respuesta WHERE Id_Pregunta =@IdPregunta";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();

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
        public bool InsertarPregunta(int IdEvaluacion, string Pregunta, int TipoPregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            if (TipoPregunta == 1)
            {
                comm.CommandText = "INSERT INTO [Ev_Pregunta] (Id_Evaluacion,Pregunta,TipoPregunta) VALUES(@Id_Evaluacion,@Pregunta,1)";

            }
            else
            {
                comm.CommandText = "INSERT INTO [Ev_Pregunta] (Id_Evaluacion,Pregunta,TipoPregunta) VALUES(@Id_Evaluacion,@Pregunta,2)";

            }
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
        public bool InsertarRespuestaMultiple(int IdPregunta, string Respuesta,string EsRespuesta,int Orden)
        {
            comm.Connection = conexion.AbrirConexion();
            if (EsRespuesta == "1")
            {
                comm.CommandText = "INSERT INTO [Ev_Respuesta] (Id_Pregunta,Respuesta,EsRespuesta,Orden) VALUES(@IdPregunta,@Respuesta,1,@Orden)";

            }
            else
            {
                comm.CommandText = "INSERT INTO [Ev_Respuesta] (Id_Pregunta,Respuesta,EsRespuesta,Orden) VALUES(@IdPregunta,@Respuesta,0,@Orden)";
            }
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            comm.Parameters.AddWithValue("@Respuesta", Respuesta);
            comm.Parameters.AddWithValue("@Orden", Orden);

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

        public bool EliminarPregunta(int IdPregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Ev_Pregunta set Activado=1 WHERE Id_Pregunta=@IdPreguntaa";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPreguntaa", IdPregunta);
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

        public bool ModificarPregunta(int IdPregunta, string Pregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Ev_Pregunta SET Pregunta=@Pregunta WHERE Id_Pregunta=@IdPreguntaa";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPreguntaa", IdPregunta);
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

        public bool ModificarRespuesta(int IdRespuesta, string Respuesta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Ev_Respuesta SET Respuesta=@Respuesta WHERE Id_Respuesta=@IdRespuesta";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdRespuesta", IdRespuesta);
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

        public bool ModificarRespuestaToF(int IdRespuesta,int EsRespuesta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Ev_Respuesta SET EsRespuesta=@EsRespuesta  WHERE Id_Respuesta=@IdRespuesta";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdRespuesta", IdRespuesta);
            comm.Parameters.AddWithValue("@EsRespuesta", EsRespuesta);

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
            comm.CommandText = "SELECT TOP(1) Id_Pregunta FROM Ev_Pregunta WHERE Id_Evaluacion=@IdEvaluacionn ORDER BY Id_Pregunta DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEvaluacionn", IdEvaluacion);

            dr = comm.ExecuteReader();
            dr.Read();
            IdPregunta = dr["Id_Pregunta"].ToString();



            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void ObtenerPregunta(int IdPregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Pregunta FROM Ev_Pregunta WHERE Id_Pregunta=@IdPregunta";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            dr = comm.ExecuteReader();
            comm.Parameters.Clear();

            dr.Read();
            Pregunta = dr["Pregunta"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();

        }


        public void ObtenerR1(int IdPregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Respuesta,Respuesta FROM Ev_Respuesta WHERE Id_Pregunta=@IdPregunta AND Orden=1";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            dr = comm.ExecuteReader();
            comm.Parameters.Clear();
            dr.Read();
            IdRespuesta = dr["Id_Respuesta"].ToString();
            R1 = dr["Respuesta"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();

        }
        public void ObtenerR2(int IdPregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Respuesta,Respuesta FROM Ev_Respuesta WHERE Id_Pregunta=@IdPregunta AND Orden=2";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            dr = comm.ExecuteReader();
            comm.Parameters.Clear();

            dr.Read();
            IdRespuesta = dr["Id_Respuesta"].ToString();
            R2 = dr["Respuesta"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();

        }
        public void ObtenerR3(int IdPregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Respuesta,Respuesta FROM Ev_Respuesta WHERE Id_Pregunta=@IdPregunta AND Orden=3";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            dr = comm.ExecuteReader();
            comm.Parameters.Clear();

            dr.Read();
            IdRespuesta = dr["Id_Respuesta"].ToString();
            R3 = dr["Respuesta"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();

        }
        public void ObtenerR4(int IdPregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Respuesta,Respuesta FROM Ev_Respuesta WHERE Id_Pregunta=@IdPregunta AND Orden=4";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            dr = comm.ExecuteReader();
            comm.Parameters.Clear();

            dr.Read();
            IdRespuesta = dr["Id_Respuesta"].ToString();
            R4 = dr["Respuesta"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();

        }

        public void EsRespuesta(int IdPregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Respuesta FROM Ev_Respuesta WHERE Id_Pregunta=@IdPregunta AND EsRespuesta=1 ";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            dr = comm.ExecuteReader();
            comm.Parameters.Clear();

            dr.Read();
            Respuesta = dr["Respuesta"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();

        }

        public void IdVerdadero(int IdPregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Respuesta FROM Ev_Respuesta WHERE Id_Pregunta=@IdPregunta AND Respuesta='Verdadero'";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            dr = comm.ExecuteReader();
            comm.Parameters.Clear();

            dr.Read();
            IdRespuesta = dr["Id_Respuesta"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();

        }

        public void IdFalso(int IdPregunta)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Respuesta FROM Ev_Respuesta WHERE Id_Pregunta=@IdPregunta AND Respuesta='Falso'";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPregunta", IdPregunta);
            dr = comm.ExecuteReader();
            comm.Parameters.Clear();

            dr.Read();
            IdRespuesta = dr["Id_Respuesta"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();

        }
    }
}