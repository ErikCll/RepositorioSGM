using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SASISOPA.Clase
{
    public class ProgramaCapacitacion
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;


        public string Id_Programa { get; set; }

        public string Id_Evaluacion { get; set; }
        public string Id_Empleado { get; set; }

        public string Empleado { get; set; }
        public string Actividad { get; set; }
        public string FechaEvaluacion { get; set; }
        public string FechaRealizado { get; set; }
        public string Calificacion { get; set; }
        public string Estatus { get; set; }

        public DataTable MostrarGeneral(int IdInstalacion,int Anio)
        {

            string query = "SELECT act.Id_Actividades,act.Nombre,s.Codigo, CASE WHEN act.Id_Actividades IS NOT NULL THEN 'P' END 'Pendiente/Realizado', SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 1 AND prog.Activado IS NULL  THEN 1 ELSE 0 END) AS Ene, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Feb, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 3 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Mar, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 4 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Abr,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 5 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS May, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 6 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jun, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 7 AND  prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jul,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 8 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Ago, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 9 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Sep, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 10 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Oct, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 11 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Nov, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 12 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Dic, SUM(CASE WHEN prog.FechaEvaluacion IS NOT NULL AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Total, FORMAT( CAST(SUM(CASE WHEN prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE null END) as DECIMAL(9, 2)) / CAST(SUM(CASE WHEN prog.FechaEvaluacion IS NOT NULL AND prog.Activado IS NULL THEN 1 ELSE null END) AS DECIMAL(9, 2)), 'P')  AS Avance FROM Op_ProgramaCapacitacion prog JOIN Evaluacion ev on prog.Id_Evaluacion = ev.Id_Evaluacion JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) ctr on ev.Id_Control = ctr.max_score JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses, Activado FROM Cat_ActividadControl) s on ctr.max_score = s.Id_Control RIGHT JOIN Cat_Actividades act on ctr.Id_Actividad = act.Id_Actividades JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE act.Activado IS NULL AND s.Activado IS NULL AND ev.Activado IS NULL and ins.Id_instalacion = @IdInstalacion AND YEAR(prog.FechaEvaluacion)= @Anio GROUP BY act.Id_Actividades,act.Nombre,s.Codigo UNION SELECT act.Id_Actividades, act.Nombre,s.Codigo,CASE WHEN act.Id_Actividades IS NOT NULL THEN 'R' END 'Pendiente/Realizado', SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 1 AND prog.Estatus = 2 AND prog.Activado IS NULL  THEN 1 ELSE 0 END) AS Ene, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 2 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Feb,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 3 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Mar, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 4 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Abr,SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 5 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS May, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 6 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jun, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 7 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Jul, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 8 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Ago, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 9 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Sep, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 10 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Oct, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 11 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Nov, SUM(CASE WHEN MONTH(prog.FechaEvaluacion) = 12 AND prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Dic, SUM(CASE WHEN prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE 0 END) AS Total, FORMAT( CAST(SUM(CASE WHEN prog.Estatus = 2 AND prog.Activado IS NULL THEN 1 ELSE null END) as DECIMAL(9, 2)) / CAST(SUM(CASE WHEN prog.FechaEvaluacion IS NOT NULL AND prog.Activado IS NULL THEN 1 ELSE null END) AS DECIMAL(9, 2)), 'P') AS Avance FROM Op_ProgramaCapacitacion prog JOIN Evaluacion ev on prog.Id_Evaluacion = ev.Id_Evaluacion JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) ctr on ev.Id_Control = ctr.max_score JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses, Activado FROM Cat_ActividadControl) s on ctr.max_score = s.Id_Control RIGHT JOIN Cat_Actividades act on ctr.Id_Actividad = act.Id_Actividades JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE act.Activado IS NULL AND ev.Activado IS NULL AND s.Activado IS NULL AND ins.Id_instalacion = @IdInstalacion AND YEAR(prog.FechaEvaluacion)=@Anio GROUP BY act.Id_Actividades,act.Nombre,s.Codigo ORDER BY act.Id_Actividades DESC ";
 

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
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

            string query = "SELECT act.Id 'Id_Actividad', act.Nombre,s.Codigo,act.Area,ins.Nombre 'Instalacion', s.Id_Control,ev.Id_Evaluacion FROM(SELECT InsAct.Id, act.Id_Actividades, act.Nombre, area.Id_area, area.Nombre AS Area FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades JOIN Cat_Area area on InsAct.Id_Area = area.Id_area WHERE InsAct.Id_Instalacion = @IdInstalacion AND act.Activado IS NULL AND act.TipoSistema = 2) act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion LEFT JOIN Evaluacion ev on s.Id_Control = ev.Id_Control AND ev.Activado IS NULL AND ev.Estatus = 2 WHERE ins.Id_Instalacion = @IdInstalacion ORDER BY act.Id DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT act.Id 'Id_Actividad', act.Nombre,s.Codigo,act.Area 'Área',ins.Nombre 'Instalacion', s.Id_Control,ev.Id_Evaluacion FROM(SELECT InsAct.Id, act.Id_Actividades, act.Nombre, area.Id_area, area.Nombre AS Area FROM Op_Ins_Act InsAct JOIN Cat_Actividades act on InsAct.Id_Actividad = act.Id_Actividades JOIN Cat_Area area on InsAct.Id_Area = area.Id_area WHERE InsAct.Id_Instalacion = @IdInstalacion AND act.Activado IS NULL AND act.TipoSistema = 2) act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control, FechaEmision, Codigo, VigenciaMeses FROM Cat_ActividadControl) s on r.max_score = s.Id_Control JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion LEFT JOIN Evaluacion ev on s.Id_Control = ev.Id_Control AND ev.Activado IS NULL AND ev.Estatus = 2 WHERE ins.Id_Instalacion = @IdInstalacion AND  act.Nombre LIKE '%'+@txtSearch+'%' ORDER BY act.Id DESC";
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

            string query = "SELECT Id_Programa,CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) 'Empleado', CONVERT(nvarchar, prog.FechaEvaluacion, 105) 'FechaEvaluacion', CONVERT(nvarchar, prog.FechaRealizado, 105) 'FechaRealizado',REPLACE(prog.Calificacion,',','.') 'Calificacion',prog.Calificacion 'Calificacion2', CASE WHEN prog.Estatus = 1 THEN 'Pendiente de realizar' ELSE 'Realizado' END 'Estatus',prog.Estatus 'IntEstatus',Clave,ev.CalificacionMinima FROM Op_ProgramaCapacitacion prog JOIN Cat_Empleado emp on prog.Id_Empleado = emp.Id_empleado JOIN Evaluacion ev on prog.Id_Evaluacion=ev.Id_Evaluacion WHERE prog.Id_Evaluacion = @Id_Evaluacion AND prog.Activado IS NULL ORDER BY prog.FechaEvaluacion DESC";

            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT Id_Programa,CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) 'Empleado', CONVERT(nvarchar, prog.FechaEvaluacion, 105) 'FechaEvaluacion', CONVERT(nvarchar, prog.FechaRealizado, 105) 'FechaRealizado',REPLACE(prog.Calificacion,',','.') 'Calificacion', prog.Calificacion 'Calificacion2', CASE WHEN prog.Estatus = 1 THEN 'Pendiente de realizar' ELSE 'Realizado' END 'Estatus',prog.Estatus 'IntEstatus',Clave,ev.CalificacionMinima FROM Op_ProgramaCapacitacion prog JOIN Cat_Empleado emp on prog.Id_Empleado = emp.Id_empleado JOIN Evaluacion ev on prog.Id_Evaluacion=ev.Id_Evaluacion WHERE prog.Id_Evaluacion = @Id_Evaluacion AND prog.Activado IS NULL AND CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) LIKE '%'+@txtSearch+'%'  ORDER BY prog.FechaEvaluacion DESC";
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

        public bool EditarPrograma(int IdPrograma,string Clave)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_ProgramaCapacitacion SET Clave =@Clave  WHERE Id_Programa = @Id_Programa";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Programa", IdPrograma);
            comm.Parameters.AddWithValue("@Clave", Clave);



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

        public bool EditarIngreso(int IdPrograma)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_ProgramaCapacitacion SET EsIngresado =1  WHERE Id_Programa = @Id_Programa";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Programa", IdPrograma);
     



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

        public bool EditarProgramaEv(int IdPrograma,decimal Calificacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_ProgramaCapacitacion SET Estatus =2, FechaRealizado=GETDATE(),Calificacion=@Calificacion  WHERE Id_Programa = @Id_Programa";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Programa", IdPrograma);
            comm.Parameters.AddWithValue("@Calificacion", Calificacion);





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

        public bool EliminarValidacion(int IdPrograma)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_ProgramaCapacitacion SET Activado=1  WHERE Id_Programa = @IdPrograama";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdPrograama", IdPrograma);
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

        public bool ValidarClave(string Clave)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Op_ProgramaCapacitacion WHERE Clave = @Clave COLLATE Latin1_General_CS_AS AND Estatus=1 AND Activado IS NULL AND EsIngresado IS NULL";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Clave", Clave);
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

        public bool ValidarRealizado(int IdPrograma)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Op_ProgramaCapacitacion WHERE Id_programa=@IdProograma AND Estatus=1";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdProograma", IdPrograma);
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

        public void ObtenerIdPrograma(int IdEvaluacion,int IdEmpleado)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP(1) Id_Programa FROM Op_ProgramaCapacitacion WHERE Id_Evaluacion=@IdEvaluacion AND Id_Empleado=@IdEmpleado ORDER BY Id_Programa DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEvaluacion", IdEvaluacion);
            comm.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
            dr = comm.ExecuteReader();
            dr.Read();
            Id_Programa = dr["Id_Programa"].ToString();



            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosPrograma(int IdPrograma)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Empleado,Id_Evaluacion,CONVERT(nvarchar,FechaEvaluacion, 105) 'FechaEvaluacion' FROM Op_ProgramaCapacitacion WHERE Id_Programa=@IdPrograma";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPrograma", IdPrograma);
        

            dr = comm.ExecuteReader();
            dr.Read();
            Id_Empleado = dr["Id_Empleado"].ToString();
            Id_Evaluacion = dr["Id_Evaluacion"].ToString();
            FechaEvaluacion = dr["FechaEvaluacion"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosProgramaEmpleado(int IdPrograma)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT  CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) 'Empleado',act.Nombre 'Actividad' FROM Cat_Empleado emp JOIN Op_ProgramaCapacitacion prog on emp.Id_Empleado = prog.Id_Empleado JOIN Evaluacion ev on prog.Id_Evaluacion = ev.Id_Evaluacion JOIN Cat_ActividadControl ctr on ev.Id_Control = ctr.Id_Control JOIN Cat_Actividades act on ctr.Id_Actividad = act.Id_Actividades WHERE prog.Id_Programa=@IdPrograma";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdPrograma", IdPrograma);

            dr = comm.ExecuteReader();
            dr.Read();
            Empleado = dr["Empleado"].ToString();
            Actividad = dr["Actividad"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosProgramaEvaluacion(int IdPrograma)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Programa, CONCAT(emp.Nombre, ' ', emp.ApellidoPaterno, ' ', emp.ApellidoMaterno) 'Empleado', CONVERT(nvarchar, prog.FechaEvaluacion, 105) 'FechaEvaluacion', CONVERT(nvarchar, prog.FechaRealizado, 105) 'FechaRealizado', REPLACE(prog.Calificacion, ',', '.') 'Calificacion',  CASE WHEN prog.Estatus = 1 THEN 'Pendiente de realizar' ELSE 'Realizado' END 'Estatus',act.Nombre 'Actividad' FROM Op_ProgramaCapacitacion prog JOIN Cat_Empleado emp on prog.Id_Empleado = emp.Id_empleado JOIN Evaluacion ev on prog.Id_Evaluacion = ev.Id_evaluacion JOIN Cat_ActividadControl ctr on ev.Id_Control = ctr.Id_Control JOIN Cat_Actividades act on ctr.Id_Actividad = act.Id_Actividades WHERE prog.Id_programa = @IdProgramaa";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdProgramaa", IdPrograma);

            dr = comm.ExecuteReader();
            dr.Read();
            Empleado = dr["Empleado"].ToString();
            FechaEvaluacion= dr["FechaEvaluacion"].ToString();
            FechaRealizado= dr["FechaRealizado"].ToString();
            Calificacion= dr["Calificacion"].ToString();
            Estatus= dr["Estatus"].ToString();
            Actividad = dr["Actividad"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}