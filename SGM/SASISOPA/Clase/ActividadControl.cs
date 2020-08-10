using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SASISOPA.Clase
{
    public class ActividadControl
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string IdControl { get; set; }
        public string IdControl2 { get; set; }
        public string IdEvaluacion { get; set; }
        public string IdEvaluacion2 { get; set; }



        public string Codigo { get; set; }
        public string FechaEmision { get; set; }
        public string Meses { get; set; }



        public string Actividad { get; set; }


        public DataTable Mostrar(int IdActividad)
        {

            string query = "SELECT con.Id_Control,con.Codigo,CONVERT(nvarchar,con.FechaEmision, 105) 'FechaEmision',con.VigenciaMeses,CASE WHEN con.TieneVigencia = 1 THEN '1' ELSE '' END 'Tienevigencia',CASE WHEN ev.Id_Control IS NULL OR ev.Activado = 1 THEN 'No' ELSE 'Si' END 'TieneEvaluacion' FROM Cat_ActividadControl con LEFT JOIN Evaluacion ev on con.Id_Control = ev.Id_Control AND ev.Activado IS NULL WHERE con.id_Actividad =@Id_Actividad AND con.Activado IS NULL GROUP BY con.codigo,con.FechaEmision,con.VigenciaMeses,con.Id_Control,con.TieneVigencia,ev.Id_Control,ev.Activado ORDER BY CONVERT(datetime, con.FechaEmision, 105) DESC";


                //"SELECT Id_Control,Codigo,CONVERT(nvarchar,FechaEmision, 105) 'FechaEmision',VigenciaMeses,CASE WHEN TieneVigencia=1 THEN '1' ELSE '' END 'Tienevigencia' FROM Cat_ActividadControl WHERE id_Actividad =@Id_Actividad AND Activado IS NULL ORDER BY CONVERT(datetime,FechaEmision, 105) DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividad", IdActividad);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public bool Insertar(int IdActividad, string Codigo,string FechaEmision,int VigenciaMeses)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_ActividadControl] (Id_Actividad,Codigo,FechaCreacion,FechaEmision,VigenciaMeses,TieneVigencia) VALUES(@Id_Actividad,@Codigo,GETDATE(),CONVERT(date,@FechaEmision,103),@VigenciaMeses,1)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividad", IdActividad);
            comm.Parameters.AddWithValue("@Codigo", Codigo);
            comm.Parameters.AddWithValue("@FechaEmision", FechaEmision);
            comm.Parameters.AddWithValue("@VigenciaMeses", VigenciaMeses);
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

        public bool InsertarEvaluacion(int IdControl1, int IdControl2)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Evaluacion] (Id_Control, CantidadReactivos, Estatus, CalificacionMinima) SELECT @IdControll,CantidadReactivos,1,CalificacionMinima FROM Evaluacion WHERE Id_Control = @IdControl2 AND Estatus = 2 AND Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdControll", IdControl1);
            comm.Parameters.AddWithValue("@IdControl2", IdControl2);
      
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

        public bool InsertarPreguntasEvaluacion(int IdControl1, int IdControl2)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Evaluacion] (Id_Control, CantidadReactivos, Estatus, CalificacionMinima) SELECT @IdControll,CantidadReactivos,1,CalificacionMinima FROM Evaluacion WHERE Id_Control = @IdControl2 AND Estatus = 2 AND Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdControll", IdControl1);
            comm.Parameters.AddWithValue("@IdControl2", IdControl2);

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

        public bool InsertarSinVigencia(int IdActividad, string Codigo, string FechaEmision)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_ActividadControl] (Id_Actividad,Codigo,FechaCreacion,FechaEmision) VALUES(@Id_Actividad,@Codigo,GETDATE(),CONVERT(date,@FechaEmision,103))";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividad", IdActividad);
            comm.Parameters.AddWithValue("@Codigo", Codigo);
            comm.Parameters.AddWithValue("@FechaEmision", FechaEmision);
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
        public bool Editar(int IdControl, string Codigo,string FechaEmision,int VigenciaMeses)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_ActividadControl SET Codigo = @Codigo,FechaEmision=CONVERT(date,@FechaEmision,103),VigenciaMeses=@VigenciaMeses WHERE Id_Control = @IdControl";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdControl", IdControl);
            comm.Parameters.AddWithValue("@Codigo", Codigo);
            comm.Parameters.AddWithValue("@FechaEmision", FechaEmision);
            comm.Parameters.AddWithValue("@VigenciaMeses", VigenciaMeses);



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

        public bool EditarEvaluacion(int IdControl1,int IdControl2)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Evaluacion SET Id_Control=@IdControl1 WHERE Id_Control=@IdControl2";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdControl1", IdControl1);
            comm.Parameters.AddWithValue("@IdControl2", IdControl2);
          
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

        public bool EditarProgramaEvaluacion(int IdEvaluacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_ProgramaCapacitacion SET Activado=1 WHERE Id_Evaluacion=@IdEvaluacion";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEvaluacion", IdEvaluacion);

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

        public bool EditarSinVigencia(int IdControl, string Codigo, string FechaEmision)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_ActividadControl SET Codigo = @Codigo,FechaEmision=CONVERT(date,@FechaEmision,103) WHERE Id_Control = @IdControl";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdControl", IdControl);
            comm.Parameters.AddWithValue("@Codigo", Codigo);
            comm.Parameters.AddWithValue("@FechaEmision", FechaEmision);


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

        public bool Eliminar(int IdControl)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_ActividadControl SET Activado=1  WHERE Id_Control = @Id_Control";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Control", IdControl);
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
        public void LeerDatosActividad(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre FROM Cat_Actividades WHERE Id_Actividades=@Id_Actividades";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividades", IdActividad);

            dr = comm.ExecuteReader();
            dr.Read();
            Actividad = dr["Nombre"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerId(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP 1 Id_Control FROM Cat_ActividadControl WHERE Id_Actividad=@Id_Actividad ORDER BY Id_Control DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividad", IdActividad);

            dr = comm.ExecuteReader();
            dr.Read();
            IdControl = dr["Id_Control"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
        public void LeerDatosControl(int Id_Control)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Codigo,CONVERT(nvarchar,FechaEmision, 105) 'FechaEmision',ISNULL(VigenciaMeses/12,'0')'VigenciaMeses' FROM Cat_ActividadControl WHERE Id_Control=@Id_Control";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Control", Id_Control);

            dr = comm.ExecuteReader();
            dr.Read();
            Codigo = dr["Codigo"].ToString();
            FechaEmision = dr["FechaEmision"].ToString();
            Meses = dr["VigenciaMeses"].ToString();


            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void ObtenerIdControl(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT s.Id_Control,ev.Id_Evaluacion FROM Cat_Actividades act JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses, Activado FROM Cat_ActividadControl) s on r.max_score = s.Id_Control JOIN Evaluacion ev on s.Id_Control=ev.Id_Control WHERE act.Id_Actividades = @IddActividad AND ev.Activado IS NULL AND ev.Estatus=2";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IddActividad", IdActividad);

            dr = comm.ExecuteReader();
            dr.Read();
            IdControl2 = dr["Id_Control"].ToString();
            IdEvaluacion = dr["Id_Evaluacion"].ToString();



            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void ObtenerIdEvaluacion(int IdControl)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Evaluacion FROM Evaluacion WHERE Id_Control=@IidControl";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IidControl", IdControl);

            dr = comm.ExecuteReader();
            dr.Read();
            IdEvaluacion2 = dr["Id_Evaluacion"].ToString();



            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public bool ValidarExistenciaEvaluacion(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Cat_Actividades act JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses, Activado FROM Cat_ActividadControl) s on r.max_score = s.Id_Control JOIN Evaluacion ev on s.Id_Control = ev.Id_Control WHERE s.Activado IS NULL AND act.Id_Actividades = @IdAactividad AND ev.Activado IS NULL AND ev.Estatus = 2";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdAactividad", IdActividad);
            int i = (int)comm.ExecuteScalar();
            comm.Parameters.Clear();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }
    }
}