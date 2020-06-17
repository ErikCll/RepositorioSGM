using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class ActividadControl
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string IdControl { get; set; }
        public string Codigo { get; set; }
        public string FechaEmision { get; set; }
        public string Meses { get; set; }



        public string Actividad { get; set; }


        public DataTable Mostrar(int IdActividad)
        {

            string query = "SELECT Id_Control,Codigo,CONVERT(nvarchar,FechaEmision, 105) 'FechaEmision',VigenciaMeses,CASE WHEN TieneVigencia=1 THEN '1' ELSE '' END 'Tienevigencia' FROM Cat_ActividadControl WHERE id_Actividad =@Id_Actividad AND Activado IS NULL ORDER BY FechaEmision DESC";


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
    }
}