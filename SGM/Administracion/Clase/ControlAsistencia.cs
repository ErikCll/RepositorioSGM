using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Administracion.Clase
{
    public class ControlAsistencia
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string Empleado { get; set; }

        public DataTable Mostrar(string txtSearch, string Fecha)
        {

            string query = "SELECT us.UserId,us.Name,us.Badgenumber, CONVERT(nvarchar, chck.checktime, 105) 'Fecha', MIN(FORMAT(chck.checktime,'hh:mm tt')) 'Entrada', MAX(FORMAT(chck.checktime,'hh:mm tt')) 'Salida' FROM checkinout chck JOIN UserInfo us on chck.UserId = us.UserId WHERE CONVERT(NVARCHAR, CAST(chck.checktime AS Date),105)= @Fecha GROUP BY us.UserId,us.Name,us.Badgenumber,CONVERT(nvarchar, chck.checktime, 105) ORDER BY us.Name DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT us.UserId,us.Name,us.Badgenumber, CONVERT(nvarchar, chck.checktime, 105) 'Fecha', MIN(FORMAT(chck.checktime,'hh:mm tt')) 'Entrada', MAX(FORMAT(chck.checktime,'hh:mm tt')) 'Salida' FROM checkinout chck JOIN UserInfo us on chck.UserId = us.UserId WHERE CONVERT(NVARCHAR, CAST(chck.checktime AS Date),105)= @Fecha and us.Name like '%' + @txtSearch + '%' OR (us.Badgenumber LIKE '%' + @txtSearch + '%' AND CONVERT(NVARCHAR, CAST(chck.checktime AS Date), 105) =@Fecha) GROUP BY us.UserId,us.Name,us.Badgenumber,CONVERT(nvarchar, chck.checktime, 105) ORDER BY us.Name DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            comm.Parameters.AddWithValue("@Fecha", Fecha);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public DataTable MostrarAsistenciaEmpleado(int IdUsuario,string FechaInicial, string FechaFinal)
        {

            string query = "SELECT us.UserId,us.Name,us.Badgenumber, CONVERT(NVARCHAR, CAST(chck.checktime AS Date), 105) 'Fecha', CAST(chck.checktime AS Date), MIN(FORMAT(chck.checktime, 'hh:mm tt')) 'Entrada', MAX(FORMAT(chck.checktime, 'hh:mm tt')) 'Salida' FROM checkinout chck JOIN UserInfo us on chck.UserId = us.UserId WHERE us.UserId = @IdUsuarioo AND CAST(chck.checktime AS Date) >= @FechaInicial AND CAST(chck.checktime AS Date) <= @FechaFinal GROUP BY us.UserId,us.Name,us.Badgenumber,CONVERT(NVARCHAR, CAST(chck.checktime AS Date), 105),CAST(chck.checktime AS Date) ORDER BY CAST(chck.checktime AS Date) ASC";
        
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuarioo", IdUsuario);

            comm.Parameters.AddWithValue("@FechaInicial", FechaInicial);
            comm.Parameters.AddWithValue("@FechaFinal", FechaFinal);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public void LeerDatosEmpleado(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Name FROM UserInfo WHERE UserId=@IdUsuario";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);

            dr = comm.ExecuteReader();
            dr.Read();
            Empleado = dr["Name"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}