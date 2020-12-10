using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGL.Clase
{
    public class Accesos
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        // MENUS --->
        public bool ValidarAcreditacion(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 12 AND sismenu.Activado IS NULL";
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

        public bool ValidarProcedimientoInstructivo(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 13 AND sismenu.Activado IS NULL";
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

        public bool ValidarCompetencia(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 14 AND sismenu.Activado IS NULL";
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

        public bool ValidarEma(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 3";
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
        public bool ValidarCre(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 40";
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

        public bool ValidarCensoActividad(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 4";
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

        public bool ValidarInstalacionActividad(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 5";
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

        public bool ValidarCategoriaActividad(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 6";
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

        public bool ValidarCategoriaEmpleado(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 7";
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

        public bool ValidarProgramaCapacitacion(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 28";
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

        public bool ValidarResultadoEvaluacion(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 29";
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