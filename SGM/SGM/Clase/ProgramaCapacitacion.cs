using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SGM.Clase
{
    public class ProgramaCapacitacion
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string FechaEvaluacion { get; set; }

        public DataTable MostrarGeneral(string txtSearch, int IdInstalacion,int Anio)
        {

            string query = "SELECT act.Id_Actividades,act.Nombre,ctr.Codigo, CASE WHEN act.Id_Actividades IS NOT NULL THEN 'P' END 'Pendiente/Realizado', SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 1 AND prog.Estatus = 1 AND prog.Activado IS NULL  THEN 1 ELSE 0 END) AS Ene, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 2 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Feb, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 3 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Mar, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 4 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Abr,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 5 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS May, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 6 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jun, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 7 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jul,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 8 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Ago, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 9 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Sep, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 10 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Oct, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 11 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Nov, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 12 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Dic, SUM(CASE WHEN prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Total, FORMAT( CAST(SUM(CASE WHEN prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE null END) as DECIMAL(9, 2)) / CAST(SUM(CASE WHEN prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE null END) AS DECIMAL(9, 2)), 'P')  AS Avance FROM Op_ProgramaCapacitacion prog JOIN Evaluacion ev on prog.Id_Evaluacion = ev.Id_Evaluacion JOIN Cat_ActividadControl ctr on ev.Id_Control = ctr.Id_Control RIGHT JOIN Cat_Actividades act on ctr.Id_Actividad = act.Id_Actividades JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE act.Activado IS NULL AND ctr.Activado IS NULL AND ev.Activado IS NULL and ins.Id_instalacion = @IdInstalacion AND YEAR(prog.FechaEvaluacion)= @Anio GROUP BY act.Id_Actividades,act.Nombre,ctr.Codigo UNION SELECT act.Id_Actividades, act.Nombre,ctr.Codigo,CASE WHEN act.Id_Actividades IS NOT NULL THEN 'R' END 'Pendiente/Realizado', SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 1 AND prog.Estatus = 2 AND prog.Activado IS NULL  THEN 1 ELSE 0 END) AS Ene, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 2 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Feb,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 3 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Mar, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 4 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Abr,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 5 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS May, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 6 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jun, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 7 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jul, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 8 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Ago, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 9 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Sep, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 10 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Oct, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 11 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Nov, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 12 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Dic, SUM(CASE WHEN prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Total, FORMAT( CAST(SUM(CASE WHEN prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE null END) as DECIMAL(9, 2)) / CAST(SUM(CASE WHEN prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE null END) AS DECIMAL(9, 2)), 'P') AS Avance FROM Op_ProgramaCapacitacion prog JOIN Evaluacion ev on prog.Id_Evaluacion = ev.Id_Evaluacion JOIN Cat_ActividadControl ctr on ev.Id_Control = ctr.Id_Control RIGHT JOIN Cat_Actividades act on ctr.Id_Actividad = act.Id_Actividades JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE act.Activado IS NULL AND ev.Activado IS NULL AND ctr.Activado IS NULL AND ins.Id_instalacion = @IdInstalacion AND YEAR(prog.FechaEvaluacion)=@Anio GROUP BY act.Id_Actividades,act.Nombre,ctr.Codigo ORDER BY act.Id_Actividades DESC ";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT act.Id_Actividades,act.Nombre, CASE WHEN act.Id_Actividades IS NOT NULL THEN 'P' END 'Pendiente/Realizado', SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 1 AND prog.Estatus = 1 AND prog.Activado IS NULL  THEN 1 ELSE 0 END) AS Ene, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 2 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Feb, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 3 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Mar, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 4 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Abr,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 5 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS May, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 6 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jun, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 7 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jul,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 8 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Ago, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 9 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Sep, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 10 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Oct, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 11 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Nov, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 12 AND prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Dic, SUM(CASE WHEN prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Total, FORMAT( CAST(SUM(CASE WHEN prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE null END) as DECIMAL(9, 2)) / CAST(SUM(CASE WHEN prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE null END) AS DECIMAL(9, 2)), 'P')  AS Avance FROM Op_ProgramaCapacitacion prog JOIN Evaluacion ev on prog.Id_Evaluacion = ev.Id_Evaluacion JOIN Cat_ActividadControl ctr on ev.Id_Control = ctr.Id_Control RIGHT JOIN Cat_Actividades act on ctr.Id_Actividad = act.Id_Actividades JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE act.Activado IS NULL AND ev.Activado IS NULL and ins.Id_instalacion = @IdInstalacion AND YEAR(prog.FechaEvaluacion)= @Anio GROUP BY act.Id_Actividades,act.Nombre UNION SELECT act.Id_Actividades, act.Nombre,CASE WHEN act.Id_Actividades IS NOT NULL THEN 'R' END 'Pendiente/Realizado', SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 1 AND prog.Estatus = 2 AND prog.Activado IS NULL  THEN 1 ELSE 0 END) AS Ene, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 2 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Feb,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 3 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Mar, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 4 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Abr,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 5 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS May, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 6 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jun, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 7 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jul, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 8 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Ago, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 9 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Sep, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 10 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Oct, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 11 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Nov, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 12 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Dic, SUM(CASE WHEN prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Total, FORMAT( CAST(SUM(CASE WHEN prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE null END) as DECIMAL(9, 2)) / CAST(SUM(CASE WHEN prog.Estatus = 1 AND prog.Activado IS NULL THEN 1 ELSE null END) AS DECIMAL(9, 2)), 'P') AS Avance FROM Op_ProgramaCapacitacion prog JOIN Evaluacion ev on prog.Id_Evaluacion = ev.Id_Evaluacion JOIN Cat_ActividadControl ctr on ev.Id_Control = ctr.Id_Control RIGHT JOIN Cat_Actividades act on ctr.Id_Actividad = act.Id_Actividades JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE act.Activado IS NULL AND ev.Activado IS NULL AND ctr.Activado IS NULL AND ins.Id_instalacion = @IdInstalacion AND YEAR(prog.FechaEvaluacion)=@Anio GROUP BY act.Id_Actividades,act.Nombre ORDER BY act.Id_Actividades DESC ";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@Anio", Anio);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable Mostrar(string txtSearch, int IdInstalacion)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre,s.Codigo,ins.Nombre 'Instalacion',s.Id_Control,ev.Id_Evaluacion FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion LEFT JOIN Evaluacion ev on s.Id_Control = ev.Id_Control AND ev.Activado IS NULL AND ev.Estatus = 2 WHERE act.Activado IS NULL AND ins.Id_Instalacion = @IdInstalacion ORDER BY act.Id_Actividades DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre,s.Codigo,ins.Nombre 'Instalacion',s.Id_Control,ev.Id_Evaluacion FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion LEFT JOIN Evaluacion ev on s.Id_Control = ev.Id_Control AND ev.Activado IS NULL AND ev.Estatus = 2 WHERE act.Activado IS NULL AND ins.Id_Instalacion = @IdInstalacion AND act.Nombre LIKE '%'+@txtSearch+'%' ORDER BY act.Id_Actividades DESC";
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

        public DataTable MostrarEvaluaciones( int Id_Evaluacion, string txtSearch)
        {

            string query = "SELECT Id_Programa,CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) 'Empleado', CONVERT(nvarchar, prog.FechaEvaluacion, 105) 'FechaEvaluacion', CONVERT(nvarchar, prog.FechaRealizado, 105) 'FechaRealizado', CASE WHEN prog.Estatus = 1 THEN 'Pendiente de realizar' ELSE 'Realizado' END 'Estatus',prog.Estatus 'IntEstatus' FROM Op_ProgramaCapacitacion prog JOIN Cat_Empleado emp on prog.Id_Empleado = emp.Id_empleado WHERE prog.Id_Evaluacion = @Id_Evaluacion AND prog.Activado IS NULL ORDER BY prog.Id_Programa DESC";

            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT Id_Programa,CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) 'Empleado', CONVERT(nvarchar, prog.FechaEvaluacion, 105) 'FechaEvaluacion', CONVERT(nvarchar, prog.FechaRealizado, 105) 'FechaRealizado', CASE WHEN prog.Estatus = 1 THEN 'Pendiente de realizar' ELSE 'Realizado' END 'Estatus',prog.Estatus 'IntEstatus' FROM Op_ProgramaCapacitacion prog JOIN Cat_Empleado emp on prog.Id_Empleado = emp.Id_empleado WHERE prog.Id_Evaluacion = @Id_Evaluacion AND prog.Activado IS NULL AND CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) LIKE '%'+@txtSearch+'%'  ORDER BY prog.Id_Programa DESC";
            }
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            comm.Parameters.AddWithValue("@Id_Evaluacion", Id_Evaluacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public DataTable MostrarEmpleado(int IdActividad)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT emp.Id_Empleado,CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) 'Empleado' ,catact.Id_Actividad FROM Op_Cat_Act catact JOIN Op_Cat_Emp catemp on catact.Id_Categoria = catemp.Id_Categoria AND catact.Id_Actividad = @IdActividad JOIN Cat_Empleado emp on catemp.Id_Empleado = emp.Id_empleado WHERE emp.Activado IS NULL GROUP BY emp.Id_Empleado,CONCAT(emp.Nombre, ' ', emp.ApellidoPaterno, ' ', emp.ApellidoMaterno) ,catact.Id_Actividad ORDER BY emp.Id_empleado DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdActividad", IdActividad);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarAnios()
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT YEAR(FechaEvaluacion) 'Anio' FROM Op_ProgramaCapacitacion WHERE Activado IS NULL GROUP BY YEAR(FechaEvaluacion) ORDER BY YEAR(FechaEvaluacion) DESC";
            comm.CommandType = CommandType.Text;

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int Id_Evaluacion, int IdEmpleado, string FechaEvaluacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Op_ProgramaCapacitacion] (Id_Evaluacion,Id_Empleado,Estatus,FechaEvaluacion) VALUES(@IdEvidencia,@IdEmpleado,1,CONVERT(date,@FechaEvaluacion,103))";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEvidencia", Id_Evaluacion);
            comm.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
            comm.Parameters.AddWithValue("@FechaEvaluacion", FechaEvaluacion);
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

        public bool Editar(int IdPrograma,string FechaEvaluacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_ProgramaCapacitacion SET FechaEvaluacion =CONVERT(date,@FechaEvaluacion,103)  WHERE Id_Programa = @Id_Programa";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Programa", IdPrograma);
            comm.Parameters.AddWithValue("@FechaEvaluacion", FechaEvaluacion);
       


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


        public bool Eliminar(int IdPrograma)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_ProgramaCapacitacion SET Activado=1  WHERE Id_Programa = @IdPrograma";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdPrograma", IdPrograma);
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

        public void LeerDatos(int IdPrograma)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT CONVERT(nvarchar,FechaEvaluacion, 105) 'FechaEvaluacion' FROM Op_ProgramaCapacitacion WHERE Id_Programa =@IdPrograma ";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPrograma", IdPrograma);
            dr = comm.ExecuteReader();
            dr.Read();
            FechaEvaluacion = dr["FechaEvaluacion"].ToString();
        
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}