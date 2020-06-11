using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class Empleado
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();

        SqlDataReader dr;
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CreacionFecha { get; set; }
        public string IdInstalacion { get; set; }
        public string Instalacion { get; set; }

        public DataTable Mostrar(string txtSearch)
        {

            string query = "SELECT emp.Id_empleado, emp.Nombre,emp.ApellidoPaterno, emp.ApellidoMaterno,CONVERT(nvarchar, emp.CreacionFecha, 105) CreacionFecha,ins.Nombre 'Instalacion' FROM Cat_Empleado emp JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion WHERE emp.Activado IS NULL ORDER BY emp.Id_empleado DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT emp.Id_empleado, emp.Nombre,emp.ApellidoPaterno, emp.ApellidoMaterno,CONVERT(nvarchar, emp.CreacionFecha, 105) CreacionFecha,ins.Nombre 'Instalacion' FROM Cat_Empleado emp JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion WHERE emp.Activado IS NULL AND emp.Nombre LIKE '%'+@txtSearch+'%' OR emp.ApellidoPaterno LIKE '%'+@txtSearch+'%' ORDER BY emp.Id_empleado DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarInstalacion()
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP(40) Id_Instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL ORDER BY Id_Instalacion DESC";
            comm.CommandType = CommandType.Text;
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdInstalacion, string Nombre, string ApellidoPaterno,string ApellidoMaterno)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Empleado] (Id_Instalacion,Nombre,ApellidoPaterno,ApellidoMaterno,CreacionFecha) VALUES(@Id_Instalacion,@Nombre,@ApellidoPaterno,@ApellidoMaterno,GETDATE())";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
            comm.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
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

        public bool Editar(int IdEmpleado, string Nombre, string ApellidoPaterno,string ApellidoMaterno, int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Empleado SET Nombre = @Nombre, ApellidoPaterno = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno,Id_Instalacion=@Id_Instalacion WHERE Id_Empleado = @Id_Empleado";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Empleado", IdEmpleado);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
            comm.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);

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


        public bool Eliminar(int IdEmpleado)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Empleado SET Activado=1  WHERE Id_Empleado = @Id_Empleado";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Empleado", IdEmpleado);
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

        public void LeerDatos(int IdEmpleado)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT emp.Id_Empleado, emp.Nombre,emp.ApellidoPaterno, emp.ApellidoMaterno,CONVERT(nvarchar,emp.CreacionFecha,105) CreacionFecha,ins.Id_Instalacion, ins.Nombre 'Instalacion' FROM Cat_Empleado emp JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion WHERE emp.Id_empleado = @Id_Emplado";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Emplado", IdEmpleado);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            ApellidoPaterno = dr["ApellidoPaterno"].ToString();
            ApellidoMaterno = dr["ApellidoMaterno"].ToString();
            CreacionFecha = dr["CreacionFecha"].ToString();
            IdInstalacion = dr["Id_Instalacion"].ToString();
            Instalacion = dr["Instalacion"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}