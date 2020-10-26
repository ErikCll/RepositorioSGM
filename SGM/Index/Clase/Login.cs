using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
{
    public class Login
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }
        public string Contrasena { get; set; }

        public string IdUsuario { get; set; }

        public string IdSuscripcion { get; set; }



        public bool AutenticarUsuario(string Usuario,string Contrasena)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Usuario us JOIN Suscripcion sus on us.Id_Suscripcion = sus.Id_Suscripcion WHERE Acceso = @Usuario COLLATE Latin1_General_CS_AS AND Contrasena = @Contrasena COLLATE Latin1_General_CS_AS AND us.Activado IS NULL AND sus.Activado IS NULL";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Usuario", Usuario);
            comm.Parameters.AddWithValue("@Contrasena", Contrasena);

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


        public DataTable MostrarImagen(int IdSuscripcion)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP(1) Id_Imagen,TipoImagen FROM Cat_Imagen WHERE Id_Suscripcion=@IdSuscripcioon AND Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcioon", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();

            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarImagen2(int IdSuscripcion)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Imagen,TipoImagen FROM Cat_Imagen WHERE Id_Suscripcion=@IdSuscripcioon AND Activado IS NULL ORDER BY Id_Imagen DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcioon", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();

            conexion.CerrarConexion();
            return dt;

        }

        public bool ValidarSGM(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE sismenu.Id_Sistema = 1 AND Nav.Activado IS NULL AND sismenu.Activado IS NULL";
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

        public bool ValidarSASISOPA(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE sismenu.Id_Sistema = 2 AND Nav.Activado IS NULL AND sismenu.Activado IS NULL";
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

        public bool ValidarOperacion(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE sismenu.Id_Sistema = 3 AND Nav.Activado IS NULL AND sismenu.Activado IS NULL";
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

        public bool ValidarMantenimiento(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE sismenu.Id_Sistema = 4 AND Nav.Activado IS NULL AND sismenu.Activado IS NULL";
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


        public bool ValidarSeguridadIndustrial(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE sismenu.Id_Sistema = 5 AND Nav.Activado IS NULL AND sismenu.Activado IS NULL";
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

        public bool ValidarAdministracion(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE sismenu.Id_Sistema = 6 AND Nav.Activado IS NULL AND sismenu.Activado IS NULL";
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


        public bool ValidarSGL(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE sismenu.Id_Sistema = 7 AND Nav.Activado IS NULL AND sismenu.Activado IS NULL";
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

        public bool ValidarSAM(int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Sistema sis JOIN SuscripcionSistema sus on sis.Id_Sistema = sus.Id_Sistema WHERE sus.Id_Suscripcion = @IdSuscripcion AND sis.Id_Sistema = 8 AND sis.Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
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

        public bool ValidarCorreo(string Correo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Usuario WHERE Acceso=@Correo AND Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Correo", Correo);
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

        public void LeerDatos(string Correo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT TOP 1 Contrasena FROM Usuario WHERE Acceso=@Correoo";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Correoo", Correo);

            dr = comm.ExecuteReader();
            dr.Read();
            Contrasena = dr["Contrasena"].ToString();
   
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosUsuario(string Correo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Usuario,Id_Suscripcion FROM Usuario WHERE Acceso=@Correoo";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Correoo", Correo);

            dr = comm.ExecuteReader();
            dr.Read();
            IdUsuario = dr["Id_Usuario"].ToString();
            IdSuscripcion = dr["Id_Suscripcion"].ToString();


            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}