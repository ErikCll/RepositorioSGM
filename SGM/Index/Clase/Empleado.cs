using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
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
        public string NoEmpleado { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }


        public DataTable Mostrar(string txtSearch,int IdInstalacion)
        {

            string query = "SELECT emp.NoEmpleado,emp.Id_empleado, emp.Nombre,emp.ApellidoPaterno, emp.ApellidoMaterno,CONVERT(nvarchar, emp.CreacionFecha, 105) CreacionFecha,emp.Sexo,ins.Nombre 'Instalacion' FROM Cat_Empleado emp JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion WHERE emp.Activado IS NULL AND ins.Id_Instalacion=@IdInstalacion ORDER BY emp.Id_empleado DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT emp.NoEmpleado,emp.Id_empleado, emp.Nombre,emp.ApellidoPaterno, emp.ApellidoMaterno,CONVERT(nvarchar, emp.CreacionFecha, 105) CreacionFecha,emp.Sexo,ins.Nombre 'Instalacion' FROM Cat_Empleado emp JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion WHERE emp.Activado IS NULL AND emp.Nombre LIKE '%'+@txtSearch+'%' AND ins.Id_Instalacion=@IdInstalacion ORDER BY emp.Id_empleado DESC";
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

        public DataTable MostrarInstalacion(int IdSuscripcion,int IdUsuario)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nav.Id_instalacion, Nav.Nombre  FROM Cat_Instalacion Nav  JOIN(SELECT Id_Instalacion FROM Op_UsIns WHERE Id_Usuario=@IdUsuario)UsAct on Nav.Id_instalacion = UsAct.Id_Instalacion WHERE nav.Activado IS NULL AND nav.Id_Suscripcion = @IdSuscripcionn ORDER BY nav.Id_instalacion DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcionn", IdSuscripcion);
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdInstalacion, string Nombre, string ApellidoPaterno,string ApellidoMaterno,string NoEmpleado,string FechaNacimiento,string Sexo,string Direccion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Empleado] (Id_Instalacion,Nombre,ApellidoPaterno,ApellidoMaterno,CreacionFecha,NoEmpleado,FechaNacimiento,Sexo,Direccion) VALUES(@Id_Instalacion,@Nombre,@ApellidoPaterno,@ApellidoMaterno,GETDATE(),@NoEmpleado,CONVERT(date,@FechaNacimiento,103),@Sexo,@Direccion)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
            comm.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
            comm.Parameters.AddWithValue("@NoEmpleado", NoEmpleado);
            comm.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            comm.Parameters.AddWithValue("@Sexo", Sexo);
            comm.Parameters.AddWithValue("@Direccion", Direccion);

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

        public bool Editar(int IdEmpleado, string Nombre, string ApellidoPaterno,string ApellidoMaterno, int IdInstalacion,string NoEmpleado,string FechaNacimiento,string Sexo,string Direccion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Empleado SET Nombre = @Nombre, ApellidoPaterno = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno,Id_Instalacion=@Id_Instalacion,NoEmpleado=@NoEmpleado,FechaNacimiento=CONVERT(date,@FechaNacimiento,103),Sexo=@Sexo,Direccion=@Direccion WHERE Id_Empleado = @Id_Empleado";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Empleado", IdEmpleado);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
            comm.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@NoEmpleado", NoEmpleado);
            comm.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            comm.Parameters.AddWithValue("@Sexo", Sexo);
            comm.Parameters.AddWithValue("@Direccion", Direccion);
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
            comm.CommandText = "SELECT emp.Id_Empleado, emp.Nombre,emp.ApellidoPaterno, emp.ApellidoMaterno,CONVERT(nvarchar,emp.CreacionFecha,105) CreacionFecha,ins.Id_Instalacion, ins.Nombre 'Instalacion',CONVERT(nvarchar,emp.FechaNacimiento,105) FechaNacimiento,emp.NoEmpleado,emp.Sexo,emp.Direccion FROM Cat_Empleado emp JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion WHERE emp.Id_empleado = @Id_Emplado";
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
            NoEmpleado = dr["NoEmpleado"].ToString();
            FechaNacimiento = dr["FechaNacimiento"].ToString();
            Sexo = dr["Sexo"].ToString();
            Direccion = dr["Direccion"].ToString();




            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}