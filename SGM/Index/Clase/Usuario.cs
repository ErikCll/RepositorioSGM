using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
{
    public class Usuario
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string CreacionFecha { get; set; }


        public DataTable Mostrar(string txtSearch, int IdSuscripcion)
        {

            string query = "SELECT Id_Usuario,Nombre, ApellidoPaterno, ApellidoMaterno, Acceso FROM Usuario WHERE Id_Suscripcion = @IdSuscripcion AND Activado IS NULL ORDER BY Id_usuario DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT Id_Usuario,Nombre, ApellidoPaterno, ApellidoMaterno, Acceso FROM Usuario WHERE Id_Suscripcion = @IdSuscripcion AND Activado IS NULL AND Email LIKE '%'+@txtSearch+'%' ORDER BY Id_usuario DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public DataTable MostrarInstalacion(int IdUsuario, int IdSuscripcion)
        {

            string query = "SELECT Nav.Id_instalacion, Nav.Nombre 'Instalacion', Nav.Localizacion, CAST(CASE WHEN UsAct.Id_Instalacion IS NULL THEN 0 else UsAct.Id_Instalacion END as bit) 'Id_registro',CASE WHEN UsAct.Id_Instalacion IS NULL THEN 0 else UsAct.Id_Instalacion END 'Id_registro2' FROM Cat_Instalacion Nav LEFT JOIN(SELECT Id_Instalacion FROM Op_UsIns WHERE Id_Usuario = @IdUsuarioo) UsAct on Nav.Id_instalacion = UsAct.Id_Instalacion WHERE nav.Activado IS NULL AND nav.Id_Suscripcion = @IdSuscripcion ORDER BY Id_registro DESC, nav.Id_instalacion ASC";
          
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuarioo", IdUsuario);
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarAccesos(int IdUsuario, int IdMenu)
        {

            string query = "SELECT Nav.Id_SubMenu, Nav.Nombre 'Accesos', CAST(CASE WHEN ussubmenu.Id_SubMenu IS NULL THEN 0 else ussubmenu.Id_SubMenu END as bit) 'Id_registro', CASE WHEN ussubmenu.Id_SubMenu IS NULL THEN 0 else ussubmenu.Id_SubMenu END 'Id_registro2' FROM MenuSubMenu Nav LEFT JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuarioo) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu WHERE nav.Activado IS NULL AND nav.Id_Menu = @IdMenu ORDER BY Id_registro DESC, nav.Id_SubMenu ASC";

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuarioo", IdUsuario);
            comm.Parameters.AddWithValue("@IdMenu", IdMenu);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarSistema(int IdSuscripcion)
        {

            string query = "SELECT sis.Id_Sistema, sis.Nombre FROM Sistema sis JOIN SuscripcionSistema sus on sis.Id_Sistema = sus.Id_Sistema WHERE sus.Id_Suscripcion = @SisIdSuscripcion AND sis.Activado IS NULL ORDER BY sis.Id_Sistema DESC";

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@SisIdSuscripcion", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarMenu(int IdSuscripcion,int IdSistema)
        {

            string query = "SELECT sismenu.Id_Menu,sismenu.Nombre FROM SuscripcionMenu susmenu JOIN SistemaMenu sismenu on susmenu.Id_Menu = sismenu.Id_Menu WHERE sismenu.Id_Sistema = @IdSistema AND susmenu.Id_Suscripcion = @MenuIdSuscripcion AND sismenu.Activado IS NULL ORDER BY sismenu.Id_Menu ASC";

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@MenuIdSuscripcion", IdSuscripcion);
            comm.Parameters.AddWithValue("@IdSistema", IdSistema);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool InsertarInstalacion(int IdUsuario, int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Op_UsIns] (Id_Usuario,Id_Instalacion) VALUES(@IIdUsuario,@IIdInstalacion)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IIdUsuario", IdUsuario);
            comm.Parameters.AddWithValue("@IIdInstalacion", IdInstalacion);
            int i = comm.ExecuteNonQuery();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }

        public bool InsertarAcceso(int IdUsuario, int IdSubMenu)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [UsuarioSubMenu] (Id_Usuario,Id_SubMenu) VALUES(@IIdUsuario,@IId_SubMenu)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@IIdUsuario", IdUsuario);
            comm.Parameters.AddWithValue("@IId_SubMenu", IdSubMenu);
            int i = comm.ExecuteNonQuery();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }

        public bool EliminarAcceso(int IdUsuario, int IdSubMenu)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "DELETE FROM UsuarioSubMenu WHERE Id_Usuario=@DIdUsuario AND Id_SubMenu=@DIdSubMenu";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@DIdUsuario", IdUsuario);
            comm.Parameters.AddWithValue("@DIdSubMenu", IdSubMenu);
            int i = comm.ExecuteNonQuery();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }

        public bool EliminarInstalacion(int IdUsuario, int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "DELETE FROM Op_UsIns WHERE Id_Usuario=@DIdUsuario AND Id_Instalacion=@DIdInstalacion";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@DIdUsuario", IdUsuario);
            comm.Parameters.AddWithValue("@DIdInstalacion", IdInstalacion);
            int i = comm.ExecuteNonQuery();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }

        public bool Insertar(int IdSuscripcion, string Nombre, string ApellidoPaterno,string ApellidoMaterno,string Correo,string Contrasena)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Usuario] (Id_Suscripcion,Nombre,ApellidoPaterno,ApellidoMaterno,Acceso,Contrasena,CreacionFecha) VALUES(@Id_Suscripcion,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Correo,@Contrasena,DATEADD(HOUR,-5,GETDATE()))";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Suscripcion", IdSuscripcion);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
            comm.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
            comm.Parameters.AddWithValue("@Correo", Correo);
            comm.Parameters.AddWithValue("@Contrasena", Contrasena);

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

        public bool Editar(int IdUsuario, string Nombre, string ApellidoPaterno,string ApellidoMaterno,string Correo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Usuario SET Nombre = @Nombre, ApellidoPaterno = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno,Acceso=@Correo WHERE Id_Usuario = @Id_Usuario";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Usuario", IdUsuario);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
            comm.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
            comm.Parameters.AddWithValue("@Correo", Correo);


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

        public bool Eliminar(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Usuario SET Activado=1  WHERE Id_Usuario = @IdUsuario";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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

        public bool EditarContrasena(int IdUsuario,string Contrasena,string ContrasenaActual)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Usuario SET Contrasena=@Contrasenaa WHERE Id_Usuario = @IdUsuario AND Contrasena=@ContrasenaActual";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            comm.Parameters.AddWithValue("@Contrasenaa", Contrasena);
            comm.Parameters.AddWithValue("@ContrasenaActual", ContrasenaActual);


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

        public void LeerDatos(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre,ApellidoPaterno,ApellidoMaterno,ApellidoMaterno,Acceso,CONVERT(NVARCHAR,CreacionFecha,105) 'CreacionFecha' FROM Usuario WHERE Id_Usuario=@IdUsuario";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            ApellidoPaterno = dr["ApellidoPaterno"].ToString();
            ApellidoMaterno = dr["ApellidoMaterno"].ToString();
            Correo = dr["Acceso"].ToString();
            CreacionFecha = dr["CreacionFecha"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public bool ValidarCorreo(string Correo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Usuario WHERE Acceso=@Correo AND Activado IS NULL AND Id_Suscripcion IS NOT NULL";
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


        public bool ValidarContrasena(int IdUsuario,string Contrasena)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM Usuario WHERE Id_Usuario = @Id_Usuario  AND Contrasena = @Contrasena COLLATE Latin1_General_CS_AS AND Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Usuario", IdUsuario);
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
    }
}