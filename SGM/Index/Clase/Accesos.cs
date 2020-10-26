using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
{
    public class Accesos
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        // MENUS --->
        public bool ValidarCatalogo(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 10 AND sismenu.Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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

        public bool ValidarUsuario(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 15 AND sismenu.Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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
        
    //SUBMENUS --->

        public bool ValidarInstalacion(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 8";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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

        public bool ValidarArea(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 9";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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

        public bool ValidarCategoria(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 10";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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

        public bool ValidarEmpleado(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 11";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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

        public bool ValidarCliente(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 12";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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

        public bool ValidarMaterial(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 13";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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

        public bool ValidarEquipo(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 14";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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