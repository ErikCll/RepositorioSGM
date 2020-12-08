using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Operacion.Clase
{
    public class Bitacora
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }

        public DataTable Mostrar(string FechaInicio, int IdEquipo,string FechaActual)
        {
            //string query = "SELECT op.Id_Falla,CASE WHEN op.Id_TipoFalla=0 THEN 'Otra' ELSE falla.Nombre END 'TipoFalla',CASE WHEN op.Id_TipoFalla = 0 THEN op.descripcion ELSE falla.Descripcion END 'Descripcion', CONVERT(nvarchar, op.ini_averia, 105) +'   '+ FORMAT(op.ini_averia, 'hh:mm tt') 'Inicio', CONVERT(nvarchar, op.fin_averia, 105) +'   '+ FORMAT(op.fin_averia, 'hh:mm tt') 'Fin',CASE WHEN DATEDIFF(minute, op.ini_averia, op.fin_averia) IS NULL THEN '1010' ELSE DATEDIFF(minute, op.ini_averia, op.fin_averia) END,  CAST(DATEDIFF(minute, op.ini_averia,op.fin_averia) / 1440 AS VARCHAR(8))+'d,'+CAST(DATEDIFF(minute, op.ini_averia, op.fin_averia)% 1440 / 60 AS VARCHAR(8)) + 'h:' + FORMAT(DATEDIFF(minute, op.ini_averia, op.fin_averia) % 60, 'D2')+'m' 'Total' FROM Op_Fallas op LEFT JOIN Cat_Falla falla on op.Id_TipoFalla=falla.Id_Falla WHERE op.Id_Equipo = @IdEquipoo AND op.Activado IS NULL AND CASE WHEN DATEDIFF(minute, op.ini_averia, op.fin_averia) IS NULL THEN '1010' ELSE DATEDIFF(minute, op.ini_averia, op.fin_averia) END>2 ORDER BY op.Id_Falla DESC";
            string query = "SELECT op.Id_Falla,CASE WHEN op.Id_TipoFalla=0 THEN 'Otra' ELSE falla.Nombre END 'TipoFalla',CASE WHEN op.Id_TipoFalla = 0 THEN op.descripcion ELSE falla.Descripcion END 'Descripcion', CONVERT(nvarchar, op.ini_averia, 105) +'   '+ FORMAT(op.ini_averia, 'hh:mm tt') 'Inicio', CONVERT(nvarchar, op.fin_averia, 105) +'   '+ FORMAT(op.fin_averia, 'hh:mm tt') 'Fin',CASE WHEN DATEDIFF(minute, op.ini_averia, op.fin_averia) IS NULL THEN '1010' ELSE DATEDIFF(minute, op.ini_averia, op.fin_averia) END,  CAST(DATEDIFF(minute, op.ini_averia,op.fin_averia) / 1440 AS VARCHAR(8))+'d,'+CAST(DATEDIFF(minute, op.ini_averia, op.fin_averia)% 1440 / 60 AS VARCHAR(8)) + 'h:' + FORMAT(DATEDIFF(minute, op.ini_averia, op.fin_averia) % 60, 'D2')+'m' 'Total' FROM Op_Fallas op LEFT JOIN Cat_Falla falla on op.Id_TipoFalla=falla.Id_Falla WHERE op.Id_Equipo = @IdEquipoo AND op.Activado IS NULL AND CONVERT(NVARCHAR, CAST(op.ini_averia AS Date),105)=@FechaActual ORDER BY op.Id_Falla DESC";
            if (!String.IsNullOrEmpty(FechaInicio.Trim()))
            {
                query = "SELECT op.Id_Falla, CASE WHEN op.Id_TipoFalla=0 THEN 'Otra' ELSE falla.Nombre END 'TipoFalla',CASE WHEN op.Id_TipoFalla = 0 THEN op.descripcion ELSE falla.Descripcion END 'Descripcion', CONVERT(nvarchar, op.ini_averia, 105) +'   '+ FORMAT(op.ini_averia, 'hh:mm tt') 'Inicio', CONVERT(nvarchar, op.fin_averia, 105) +'   '+ FORMAT(op.fin_averia, 'hh:mm tt') 'Fin',CASE WHEN DATEDIFF(minute, op.ini_averia, op.fin_averia) IS NULL THEN '1010' ELSE DATEDIFF(minute, op.ini_averia, op.fin_averia) END, CAST(DATEDIFF(minute, op.ini_averia,op.fin_averia) / 1440 AS VARCHAR(8))+'d,'+CAST(DATEDIFF(minute, op.ini_averia, op.fin_averia)% 1440 / 60 AS VARCHAR(8)) + 'h:' + FORMAT(DATEDIFF(minute, op.ini_averia, op.fin_averia) % 60, 'D2')+'m' 'Total' FROM Op_Fallas op LEFT JOIN Cat_Falla falla on op.Id_TipoFalla=falla.Id_Falla WHERE op.Id_Equipo = @IdEquipoo AND op.Activado IS NULL AND CONVERT(NVARCHAR, CAST(op.ini_averia AS Date),105)=@FechaInicio  ORDER BY op.Id_Falla DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@FechaInicio", FechaInicio);
            comm.Parameters.AddWithValue("@IdEquipoo", IdEquipo);
            comm.Parameters.AddWithValue("@FechaActual", FechaActual);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarTipoFalla(int IdSuscripcion)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Falla,Nombre,Descripcion FROM Cat_Falla WHERE Id_Suscripcion=@IdSuscripcion AND Activado IS NULL ORDER BY Nombre";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public DataTable MostrarDescripcionFalla(int IdFalla)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Falla, Descripcion FROM Cat_Falla WHERE Id_Falla=@IdFallaa";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdFallaa", IdFalla);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdEquipo, string FechaHora,int IdTipoFalla,string Descripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Op_Fallas] (Id_Equipo,ini_averia,Id_TipoFalla,Descripcion) VALUES(@Id_Equipo,CONVERT(datetime,@FechaHora,103),@IdTipoFalla,@Descripcion)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Equipo", IdEquipo);
            comm.Parameters.AddWithValue("@FechaHora", FechaHora);
            comm.Parameters.AddWithValue("@IdTipoFalla", IdTipoFalla);
            comm.Parameters.AddWithValue("@Descripcion", Descripcion);

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

        public bool Editar(int IdFalla,int IdTipoFalla,string Descripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_Fallas SET Id_TipoFalla=@IdTipoFalla, Descripcion=@Descripcion WHERE Id_Falla=@IdFalla";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdFalla", IdFalla);
            comm.Parameters.AddWithValue("@IdTipoFalla", IdTipoFalla);
            comm.Parameters.AddWithValue("@Descripcion", Descripcion);




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

        public bool Eliminar(int IdBitacora)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_Fallas SET Activado=1  WHERE Id_Falla = @IdBitacora";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdBitacora", IdBitacora);
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

        public void LeerDatos(int IdEquipo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre FROM Cat_Equipo WHERE Id_Equipo=@IdEquipo AND Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEquipo", IdEquipo);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
   
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}