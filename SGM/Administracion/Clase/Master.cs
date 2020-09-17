using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Administracion.Clase
{
    public class Master
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string IdSuscripcion { get; set; }
        public string IdInstalacion { get; set; }
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


        public void LeerDatosInstalacion(int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Instalacion FROM Cat_Instalacion WHERE Id_Suscripcion=@Id_Suscripcionn";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Suscripcionn", IdSuscripcion);

            dr = comm.ExecuteReader();
            dr.Read();
            IdInstalacion = dr["Id_Instalacion"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public bool ValidarCatalogo(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM UsuarioSistemaMenu sismenu JOIN SistemaMenu menu on sismenu.Id_Menu = menu.Id_Menu JOIN Sistema sis on menu.Id_Sistema = sis.Id_Sistema JOIN Usuario us on sismenu.Id_Usuario = us.Id_usuario WHERE us.Acceso =@Usuario AND menu.Id_Menu = 8 AND menu.Activado IS NULL";
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

        public bool ValidarPersonal(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM UsuarioSistemaMenu sismenu JOIN SistemaMenu menu on sismenu.Id_Menu = menu.Id_Menu JOIN Sistema sis on menu.Id_Sistema = sis.Id_Sistema JOIN Usuario us on sismenu.Id_Usuario = us.Id_usuario WHERE us.Acceso =@Usuario AND menu.Id_Menu = 9 AND menu.Activado IS NULL";
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

        public bool ValidarAlmacen(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM UsuarioSistemaMenu sismenu JOIN SistemaMenu menu on sismenu.Id_Menu = menu.Id_Menu JOIN Sistema sis on menu.Id_Sistema = sis.Id_Sistema JOIN Usuario us on sismenu.Id_Usuario = us.Id_usuario WHERE us.Acceso =@Usuario AND menu.Id_Menu = 11 AND menu.Activado IS NULL";
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