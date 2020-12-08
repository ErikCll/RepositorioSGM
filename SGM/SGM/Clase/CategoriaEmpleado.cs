using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class CategoriaEmpleado
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }


        public DataTable Mostrar(string txtSearch, int IdInstalacion)
        {

            string query = "SELECT cat.Id_Categoria,cat.Nombre,area.Nombre 'Area' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE cat.Activado IS NULL AND ins.Id_instalacion =@IdInstalacion ORDER BY cat.Id_Categoria DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT cat.Id_Categoria,cat.Nombre,area.Nombre 'Area' FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE cat.Activado IS NULL AND ins.Id_instalacion =@IdInstalacion AND cat.Nombre LIKE '%'+@txtSearch+'%' ORDER BY cat.Id_Categoria DESC";
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

        public DataTable MostrarGeneral(int IdInstalacion)
        {

            string query = "DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX)  DECLARE	@Id_Instalacion as NVARCHAR(MAX) set @Id_Instalacion =@IdInstalacion select @cols = STUFF((SELECT ',' + QUOTENAME(cat.Nombre) FROM Cat_Categoria cat JOIN Cat_Area area on cat.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE ins.Id_instalacion =  @Id_Instalacion AND cat.Activado IS NULL FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'') set @query = 'SELECT Empleado,' + @cols + ' from (select Empleado, Categoria FROM(SELECT CONCAT(emp.Nombre,'' '',emp.ApellidoPaterno,'' '',emp.ApellidoMaterno)  Empleado, cat.Nombre Categoria FROM Op_Cat_Emp catemp LEFT JOIN Cat_Categoria cat on catemp.Id_Categoria = cat.Id_Categoria RIGHT JOIN Cat_Empleado emp on catemp.Id_Empleado = emp.Id_Empleado JOIN Cat_Instalacion ins on emp.Id_instalacion = ins.Id_instalacion WHERE emp.Activado Is null AND cat.Activado IS NULL AND ins.Id_instalacion ='+@Id_Instalacion+' ) as tabla) x pivot ( MAX(Categoria) for Categoria in (' + @cols + ') ) p 'execute(@query);";


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

        public DataTable MostrarEmpleado(int IdCategoria, int IdInstalacion)
        {

            string query = "SELECT emp.Id_Empleado , emp.Nombre+' '+emp.ApellidoPaterno+' '+emp.ApellidoMaterno Empleado, ins.Nombre 'Instalacion', CAST(CASE WHEN CatEmp.Id_Empleado IS NULL THEN 0 else CatEmp.Id_Empleado END as bit) 'Id_registro',CASE WHEN CatEmp.Id_Empleado IS NULL THEN 0 else CatEmp.Id_Empleado END 'Id_registro2' FROM Cat_Empleado emp LEFT JOIN(SELECT Id_Empleado FROM Op_Cat_Emp WHERE Id_Categoria =@Id_Categoria) CatEmp on emp.Id_Empleado = CatEmp.Id_Empleado JOIN Cat_Instalacion ins on emp.Id_Instalacion = ins.Id_Instalacion WHERE emp.Activado IS NULL AND ins.Id_Instalacion=@IdInstalacionn ORDER BY Id_registro DESC,emp.Id_Empleado DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Categoria", IdCategoria);
            comm.Parameters.AddWithValue("@IdInstalacionn", IdInstalacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdCategoria, int IdEmpleado)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Op_Cat_Emp] (Id_Categoria,Id_Empleado) VALUES(@IdCategoria,@IdEmpleado)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IdCategoria", IdCategoria);
            comm.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
            int i = comm.ExecuteNonQuery();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }

        public bool Eliminar(int IdCategoria, int IdEmpleado)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "DELETE FROM Op_Cat_Emp WHERE Id_Categoria=@IdCategoria AND Id_Empleado=@IdEmpleado";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IdCategoria", IdCategoria);
            comm.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
            int i = comm.ExecuteNonQuery();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }

        public void LeerDatos(int IdCategoria)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre FROM Cat_Categoria WHERE Id_Categoria=@Id_Categoria";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Categoria", IdCategoria);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            dr.Close();
            comm.Parameters.Clear();

            comm.Connection = conexion.CerrarConexion();



        }

    }


}