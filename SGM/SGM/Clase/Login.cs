using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class Login
    {

        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }

        public bool AutenticarUsuario(string Usuario, string Contrasena)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Usuario us JOIN Suscripcion sus on us.Id_Suscripcion = sus.Id_Suscripcion WHERE Acceso = @Usuario AND Contrasena = @Contrasena COLLATE Latin1_General_CS_AS AND us.Activado IS NULL AND sus.Activado IS NULL";
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

        public bool ValidarSGM(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Usuario us JOIN Suscripcion sus on us.Id_Suscripcion = sus.Id_Suscripcion JOIN SuscripcionSistema susis on sus.Id_Suscripcion = susis.Id_Suscripcion JOIN Sistema sis on susis.Id_Sistema = sis.Id_Sistema WHERE us.Activado IS NULL AND sus.Activado IS NULL AND us.Acceso = @Usuario AND sis.Nombre = 'SGM'";
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