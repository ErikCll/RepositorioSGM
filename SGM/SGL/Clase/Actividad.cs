using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGL.Clase
{
    public class Actividad
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
       
        public string Nombre { get; set; }
      


        public DataTable Mostrar(string txtSearch,int IdSuscripcion)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre, ISNULL(r.max_score, '0') 'Archivo',CONVERT(nvarchar, s.FechaEmision, 105) 'FechaEmision',ISNULL(s.VigenciaMeses, '0') 'VigenciaMeses',s.Codigo FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control WHERE act.Activado IS NULL AND act.TipoSistema = 3 AND act.Id_Suscripcion=@IdSuscripcion ORDER BY act.Id_Actividades DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre, ISNULL(r.max_score, '0') 'Archivo',CONVERT(nvarchar, s.FechaEmision, 105) 'FechaEmision',ISNULL(s.VigenciaMeses, '0') 'VigenciaMeses',s.Codigo FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control WHERE act.Activado IS NULL AND act.TipoSistema = 3 AND act.Id_Suscripcion=@IdSuscripcion AND act.Nombre LIKE '%' + @txtSearch + '%' ORDER BY act.Id_Actividades DESC";
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

        public DataTable MostrarGrafica(int IdInstalacion)
        {

            string query = "SELECT t1.Total,t2.Disponibles,t3.Vigentes,t4.Evaluacion FROM(SELECT COUNT(*) 'Total', '1' 'Id' FROM(SELECT InsAct.Id, act.Id_Actividades, act.Nombre, InsAct.Id_Instalacion FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades  WHERE InsAct.Id_Instalacion = @IdInstalacion AND act.Activado IS NULL AND act.TipoSistema = 2) act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control JOIN Cat_Instalacion ins on act.Id_instalacion = ins.Id_instalacion WHERE ins.Id_Instalacion = @IdInstalacion GROUP BY ins.Id_instalacion)t1 JOIN(SELECT COUNT(*) 'Disponibles', '1' 'Id' FROM(SELECT InsAct.Id, act.Id_Actividades, act.Nombre, InsAct.Id_Instalacion FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades WHERE InsAct.Id_Instalacion = @IdInstalacion AND act.Activado IS NULL AND act.TipoSistema = 2) act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control JOIN Cat_Instalacion ins on act.Id_instalacion = ins.Id_instalacion WHERE ins.Id_Instalacion = @IdInstalacion AND s.Id_Control IS NOT NULL GROUP BY ins.Id_instalacion)t2 on t1.Id = t2.Id JOIN(SELECT COUNT(*) 'Vigentes', '1' 'Id' FROM(SELECT InsAct.Id, act.Id_Actividades, act.Nombre, InsAct.Id_Instalacion FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades WHERE InsAct.Id_Instalacion = @IdInstalacion AND act.Activado IS NULL AND act.TipoSistema = 2) act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses, Activado FROM Cat_ActividadControl) s on r.max_score = s.Id_Control JOIN Cat_Instalacion ins on act.Id_instalacion = ins.Id_instalacion WHERE ins.Id_Instalacion = @IdInstalacion AND s.Id_Control IS NOT NULL AND CASE WHEN CONVERT(DATE, DATEADD(HOUR, -5, GETDATE())) < CONVERT(DATE, DATEADD(MONTH, ISNULL(s.VigenciaMeses, '0'), s.FechaEmision)) OR ISNULL(s.VigenciaMeses, '0') = 0 THEN 'Vigente' WHEN CONVERT(DATE, DATEADD(HOUR, -5, GETDATE())) >= CONVERT(DATE, DATEADD(MONTH, ISNULL(s.VigenciaMeses, '0'), s.FechaEmision)) THEN 'Vencido' END = 'Vigente' GROUP BY ins.Id_instalacion)t3 on t2.Id = t3.Id JOIN(SELECT COUNT(*) 'Evaluacion', '1' 'Id' FROM(SELECT InsAct.Id, act.Id_Actividades, act.Nombre, InsAct.Id_Instalacion FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades WHERE InsAct.Id_Instalacion = @IdInstalacion AND act.Activado IS NULL AND act.TipoSistema = 2) act JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control JOIN Evaluacion ev on s.Id_Control = ev.Id_Control AND ev.Activado IS NULL AND ev.Estatus = 2)t4 on t3.Id = t4.Id";

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public bool Insertar(int TipoSistema, string Nombre,int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Actividades] (Nombre,TipoSistema,Id_Suscripcion) VALUES(@Nombre,@TipoSistema,@IdSuscripcion)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@TipoSistema", TipoSistema);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);

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

        public bool Editar(int IdActividad, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Actividades SET Nombre = @Nombre WHERE Id_Actividades = @Id_Actividades";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividades", IdActividad);
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


        public bool Eliminar(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Actividades SET Activado=1  WHERE Id_Actividades = @Id_Actividades";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Actividades", IdActividad);
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

        public void LeerDatos(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre FROM Cat_Actividades WHERE Id_Actividades=@Id_Actividades";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividades", IdActividad);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
        
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}