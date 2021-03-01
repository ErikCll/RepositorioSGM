using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SASISOPA.Clase
{
    public class Accesos
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        // MENUS --->
        public bool ValidarPolitica(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 16 AND sismenu.Activado IS NULL";
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

        public bool ValidarRiesgo(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 17 AND sismenu.Activado IS NULL";
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

        public bool ValidarRequisito(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 33 AND sismenu.Activado IS NULL";
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

        public bool ValidarMeta(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 34 AND sismenu.Activado IS NULL";
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


        public bool ValidarFuncion(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 35 AND sismenu.Activado IS NULL";
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
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 36 AND sismenu.Activado IS NULL";
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

        public bool ValidarComunicacion(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 37 AND sismenu.Activado IS NULL";
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

        public bool ValidarControlDocumento(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 38 AND sismenu.Activado IS NULL";
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

        public bool ValidarPractica(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 39 AND sismenu.Activado IS NULL";
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

        public bool ValidarControlActividad(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 40 AND sismenu.Activado IS NULL";
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

        public bool ValidarIntegridad(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 41 AND sismenu.Activado IS NULL";
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

        public bool ValidarSeguridad(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 42 AND sismenu.Activado IS NULL";
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

        public bool ValidarRespuesta(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 43 AND sismenu.Activado IS NULL";
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

        public bool ValidarMonitoreo(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 44 AND sismenu.Activado IS NULL";
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

        public bool ValidarAuditoria(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 45 AND sismenu.Activado IS NULL";
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

        public bool ValidarInvestigacion(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 46 AND sismenu.Activado IS NULL";
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

        public bool ValidarRevision(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 47 AND sismenu.Activado IS NULL";
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

        public bool ValidarInforme(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 48 AND sismenu.Activado IS NULL";
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

        public bool Configuracion1(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 46";
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
        public bool Configuracion2(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 47";
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
        public bool Configuracion3(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 48";
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
        public bool Configuracion4(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 49";
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

        public bool Configuracion5(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 50";
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

        public bool Configuracion6(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 51";
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

        public bool Configuracion7(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 52";
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

        public bool Configuracion8(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 53";
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
        public bool Configuracion9(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 54";
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

        public bool Configuracion10(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 55";
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

        public bool Configuracion11(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 56";
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

        public bool Configuracion12(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 57";
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

        public bool Configuracion13(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 58";
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

        public bool Configuracion14(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 59";
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

        public bool Configuracion15(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 60";
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

        public bool Configuracion16(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 61";
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

        public bool Configuracion17(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 62";
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

        public bool Configuracion18(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 63";
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
        public bool ValidarControlVersion1(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 16";
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

        public bool ValidarProgramaEvaluacion1(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 17";
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

        public bool ValidarRegulador3(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 18";
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


        public bool ValidarDocumentoRegulador3(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 19";
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

        public bool ValidarRequisito3(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 20";
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

        public bool ValidarCategoriaActividad5(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 21";
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

        public bool ValidarCategoriaEmpleado5(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 22";
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

        public bool ValidarProgramaCapacitacion6(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 23";
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

        public bool ValidarResultadoEvaluacion6(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 24";
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

        public bool ValidarCensoActividad10(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 25";
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

        public bool ValidarInstalacionActividad10(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 26";
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

        public bool ValidarBitacoraIncidente16(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_SubMenu = 27";
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