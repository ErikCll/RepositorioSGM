using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class Actividad
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
       
        public string Nombre { get; set; }
        public string IdInstalacion { get; set; }
        public string Instalacion { get; set; }
        public string IdArea { get; set; }
        public string Area { get; set; }


        public DataTable Mostrar(string txtSearch)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre,area.Nombre 'Area',ins.Nombre 'Instalacion', ISNULL(r.max_score, '0') 'Archivo',CONVERT(nvarchar,s.FechaEmision, 105) 'FechaEmision',ISNULL(s.VigenciaMeses,'0') 'VigenciaMeses',s.Codigo FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control,FechaEmision,Codigo,VigenciaMeses FROM Cat_ActividadControl) s on r.max_score=s.Id_Control JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE act.Activado IS NULL ORDER BY act.Id_Actividades DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre,area.Nombre 'Area',ins.Nombre 'Instalacion', ISNULL(r.max_score, '0') 'Archivo',CONVERT(nvarchar,s.FechaEmision, 105) 'FechaEmision',ISNULL(s.VigenciaMeses,'0') 'VigenciaMeses',s.Codigo FROM Cat_Actividades act LEFT JOIN(SELECT Id_Actividad, MAX(Id_Control) max_score FROM Cat_ActividadControl WHERE Activado IS NULL GROUP BY Id_Actividad) r on act.Id_Actividades = r.Id_Actividad LEFT JOIN(SELECT Id_Control,FechaEmision,Codigo,VigenciaMeses FROM Cat_ActividadControl) s on r.max_score=s.Id_Control JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE act.Activado IS NULL AND ct.Nombre LIKE '%' + @txtSearch + '%' ORDER BY act.Id_Actividades DESC";
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

        public DataTable MostrarArea(int IdInstalacion)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Area, Nombre FROM Cat_Area WHERE Activado IS NULL AND Id_Instalacion=@Id_Instalacion ORDER BY Id_area DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarInstalacion()
        {

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP(40) Id_Instalacion, Nombre FROM Cat_Instalacion WHERE Activado IS NULL ORDER BY Id_Instalacion DESC";
            comm.CommandType = CommandType.Text;
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;
        }

        public bool Insertar(int IdArea, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Actividades] (Id_Area,Nombre) VALUES(@Id_Area,@Nombre)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Area", IdArea);
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

        public bool Editar(int IdActividad, string Nombre, int IdArea)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Actividades SET Nombre = @Nombre, Id_Area = @Id_Area WHERE Id_Actividades = @Id_Actividades";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividades", IdActividad);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Id_Area", IdArea);

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
            comm.CommandText = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre,area.Id_area, area.Nombre 'Area',ins.Id_instalacion,ins.Nombre 'Instalacion' FROM Cat_Actividades act JOIN Cat_Area area on act.Id_Area = area.Id_area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE act.Id_Actividades=@Id_Actividades";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividades", IdActividad);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            IdInstalacion = dr["Id_Instalacion"].ToString();
            Instalacion = dr["Instalacion"].ToString();
            IdArea = dr["Id_Area"].ToString();
            Area = dr["Area"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}