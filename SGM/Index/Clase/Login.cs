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

        public bool ValidarSGM(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Suscripcion sus JOIN Usuario us on sus.Id_Suscripcion = us.Id_Suscripcion JOIN UsuarioSistema ussis on us.Id_usuario = ussis.Id_Usuario JOIN Sistema sis on ussis.Id_Sistema = sis.Id_Sistema WHERE us.Activado IS NULL AND sus.Activado IS NULL AND us.Acceso = @Usuario AND sis.Nombre = 'SGM'";
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

        public bool ValidarSASISOPA(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Suscripcion sus JOIN Usuario us on sus.Id_Suscripcion = us.Id_Suscripcion JOIN UsuarioSistema ussis on us.Id_usuario = ussis.Id_Usuario JOIN Sistema sis on ussis.Id_Sistema = sis.Id_Sistema WHERE us.Activado IS NULL AND sus.Activado IS NULL AND us.Acceso = @Usuario AND sis.Nombre = 'SASISOPA'";
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

        public bool ValidarOperacion(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Suscripcion sus JOIN Usuario us on sus.Id_Suscripcion = us.Id_Suscripcion JOIN UsuarioSistema ussis on us.Id_usuario = ussis.Id_Usuario JOIN Sistema sis on ussis.Id_Sistema = sis.Id_Sistema WHERE us.Activado IS NULL AND sus.Activado IS NULL AND us.Acceso = @Usuario AND sis.Nombre = 'Operacion'";
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

        public bool ValidarMantenimiento(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Suscripcion sus JOIN Usuario us on sus.Id_Suscripcion = us.Id_Suscripcion JOIN UsuarioSistema ussis on us.Id_usuario = ussis.Id_Usuario JOIN Sistema sis on ussis.Id_Sistema = sis.Id_Sistema WHERE us.Activado IS NULL AND sus.Activado IS NULL AND us.Acceso = @Usuario AND sis.Nombre = 'Mantenimiento'";
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


        public bool ValidarSeguridadIndustrial(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Suscripcion sus JOIN Usuario us on sus.Id_Suscripcion = us.Id_Suscripcion JOIN UsuarioSistema ussis on us.Id_usuario = ussis.Id_Usuario JOIN Sistema sis on ussis.Id_Sistema = sis.Id_Sistema WHERE us.Activado IS NULL AND sus.Activado IS NULL AND us.Acceso = @Usuario AND sis.Nombre = 'Seguridad Industrial'";
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

        public bool ValidarAdministracion(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Suscripcion sus JOIN Usuario us on sus.Id_Suscripcion = us.Id_Suscripcion JOIN UsuarioSistema ussis on us.Id_usuario = ussis.Id_Usuario JOIN Sistema sis on ussis.Id_Sistema = sis.Id_Sistema WHERE us.Activado IS NULL AND sus.Activado IS NULL AND us.Acceso = @Usuario AND sis.Nombre = 'Administracion'";
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


        public bool ValidarSGL(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Suscripcion sus JOIN Usuario us on sus.Id_Suscripcion = us.Id_Suscripcion JOIN UsuarioSistema ussis on us.Id_usuario = ussis.Id_Usuario JOIN Sistema sis on ussis.Id_Sistema = sis.Id_Sistema WHERE us.Activado IS NULL AND sus.Activado IS NULL AND us.Acceso = @Usuario AND sis.Nombre = 'SGL'";
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

        public bool ValidarSAM(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Suscripcion sus JOIN Usuario us on sus.Id_Suscripcion = us.Id_Suscripcion JOIN UsuarioSistema ussis on us.Id_usuario = ussis.Id_Usuario JOIN Sistema sis on ussis.Id_Sistema = sis.Id_Sistema WHERE us.Activado IS NULL AND sus.Activado IS NULL AND us.Acceso = @Usuario AND sis.Nombre = 'SAM'";
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

    }
}