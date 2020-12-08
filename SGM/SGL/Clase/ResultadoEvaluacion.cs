using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGL.Clase
{
    public class ResultadoEvaluacion
    {

        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader dr;

        public string Promedio { get; set; }
        public string Empleado { get; set; }

        public DataTable Mostrar(string txtSearch, int IdInstalacion)
        {

            string query = "SELECT emp.Id_empleado, CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) 'Empleado', ins.Nombre 'Instalacion', CAST(AVG(op.Calificacion) as DECIMAL(10, 2)) 'Promedio' FROM Op_ProgramaCapacitacion op JOIN Cat_Empleado emp on op.Id_Empleado = emp.Id_empleado JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion WHERE op.Activado IS NULL AND op.Calificacion IS NOT NULL AND emp.Id_instalacion = @IdInstalacion GROUP BY emp.Id_empleado, CONCAT(emp.Nombre, ' ', emp.ApellidoPaterno, ' ', emp.ApellidoMaterno),ins.Nombre ORDER BY CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) ASC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT emp.Id_empleado, CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) 'Empleado', ins.Nombre 'Instalacion', CAST(AVG(op.Calificacion) as DECIMAL(10, 2)) 'Promedio' FROM Op_ProgramaCapacitacion op JOIN Cat_Empleado emp on op.Id_Empleado = emp.Id_empleado JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion WHERE op.Activado IS NULL AND op.Calificacion IS NOT NULL AND emp.Id_instalacion = @IdInstalacion AND CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) LIKE '%'+@txtSearch+'%' GROUP BY emp.Id_empleado, CONCAT(emp.Nombre, ' ', emp.ApellidoPaterno, ' ', emp.ApellidoMaterno),ins.Nombre ORDER BY CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) ASC ";
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

        public DataTable MostrarDetalle(int IdEmpleado)
        {

            string query = "SELECT emp.Id_empleado, act.Nombre 'Actividad',cont.Codigo 'Version',CONVERT(nvarchar, op.FechaEvaluacion, 105) 'FechaEvaluacion', CONVERT(nvarchar, op.FechaRealizado, 105) 'FechaRealizado', op.Calificacion FROM Op_ProgramaCapacitacion op JOIN Cat_Empleado emp on op.Id_Empleado = emp.Id_empleado JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion JOIN Evaluacion ev on op.Id_Evaluacion = ev.Id_Evaluacion JOIN Cat_ActividadControl cont on ev.Id_Control = cont.Id_Control JOIN Cat_Actividades act on cont.Id_Actividad = act.Id_Actividades WHERE op.Activado IS NULL AND op.Calificacion IS NOT NULL AND emp.Id_Empleado = @IdEmpleado ORDER BY CONVERT(nvarchar, op.FechaEvaluacion, 105) ASC";
         
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public void LeerDatosEmpleado(int IdEmpleado)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT CONCAT(Nombre,' ',ApellidoPaterno,' ',ApellidoMaterno) 'Empleado' FROM Cat_Empleado WHERE Id_Empleado=@Id_Empleado";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Empleado", IdEmpleado);

            dr = comm.ExecuteReader();
            dr.Read();
            Empleado = dr["Empleado"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosPromedio(int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT  ISNULL(CAST(AVG(t.Promedio) AS DECIMAL(10,2)),0) 'Promedio' FROM(SELECT emp.Id_empleado, CONCAT(emp.Nombre,' ',emp.ApellidoPaterno,' ',emp.ApellidoMaterno) 'Empleado', ins.Nombre 'Instalacion', CAST(AVG(op.Calificacion) as DECIMAL(10, 2)) 'Promedio' FROM Op_ProgramaCapacitacion op JOIN Cat_Empleado emp on op.Id_Empleado = emp.Id_empleado JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion WHERE op.Activado IS NULL AND op.Calificacion IS NOT NULL AND emp.Id_instalacion = @IdInstalacion GROUP BY emp.Id_empleado, CONCAT(emp.Nombre, ' ', emp.ApellidoPaterno, ' ', emp.ApellidoMaterno),ins.Nombre)t";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);

            dr = comm.ExecuteReader();
            dr.Read();
            Promedio = dr["Promedio"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}