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
        public string IdUsuario { get; set; }

        public string IdSuscripcion { get; set; }
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