using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class Master
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string IdSuscripcion { get; set; }
        public string Nombre { get; set; }

        public DataTable MostrarInstalacion(int IdSuscripcion)
        {

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL AND Id_Suscripcion=@IdSuscripcion ORDER BY Id_Instalacion DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public void LeerDatosUsuario(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT us.Id_Suscripcion,sus.Nombre FROM Usuario us JOIN Suscripcion sus on us.Id_Suscripcion = sus.Id_Suscripcion WHERE us.Acceso=@Usuario";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Usuario", Usuario);

            dr = comm.ExecuteReader();
            dr.Read();
            IdSuscripcion = dr["Id_Suscripcion"].ToString();
            Nombre = dr["Nombre"].ToString();


            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public bool ValidarCatalogo(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM UsuarioSistemaMenu sismenu JOIN SistemaMenu menu on sismenu.Id_Menu = menu.Id_Menu JOIN Sistema sis on menu.Id_Sistema = sis.Id_Sistema JOIN Usuario us on sismenu.Id_Usuario = us.Id_usuario WHERE us.Acceso =@Usuario AND menu.Id_Menu = 4 AND menu.Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Usuario", Usuario);
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

        public bool ValidarCompetencia(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM UsuarioSistemaMenu sismenu JOIN SistemaMenu menu on sismenu.Id_Menu = menu.Id_Menu JOIN Sistema sis on menu.Id_Sistema = sis.Id_Sistema JOIN Usuario us on sismenu.Id_Usuario = us.Id_usuario WHERE us.Acceso =@Usuario AND menu.Id_Menu = 5 AND menu.Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Usuario", Usuario);
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

        public bool ValidarConfirmacion(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM UsuarioSistemaMenu sismenu JOIN SistemaMenu menu on sismenu.Id_Menu = menu.Id_Menu JOIN Sistema sis on menu.Id_Sistema = sis.Id_Sistema JOIN Usuario us on sismenu.Id_Usuario = us.Id_usuario WHERE us.Acceso =@Usuario AND menu.Id_Menu = 6 AND menu.Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Usuario", Usuario);
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

        public bool ValidarIndicadores(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM UsuarioSistemaMenu sismenu JOIN SistemaMenu menu on sismenu.Id_Menu = menu.Id_Menu JOIN Sistema sis on menu.Id_Sistema = sis.Id_Sistema JOIN Usuario us on sismenu.Id_Usuario = us.Id_usuario WHERE us.Acceso =@Usuario AND menu.Id_Menu = 7 AND menu.Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Usuario", Usuario);
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
    }
}