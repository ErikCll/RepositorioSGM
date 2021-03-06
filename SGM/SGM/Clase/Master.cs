﻿using System;
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
        public string IdUsuario { get; set; }

        public string IdSuscripcion { get; set; }
        public string Nombre { get; set; }
        public string IdInstalacion { get; set; }


        public DataTable MostrarInstalacion(int IdSuscripcion, int IdUsuario)
        {

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nav.Id_instalacion, Nav.Nombre  FROM Cat_Instalacion Nav JOIN(SELECT Id_Instalacion FROM Op_UsIns WHERE Id_Usuario=@IdUsuario) UsAct on Nav.Id_instalacion = UsAct.Id_Instalacion WHERE nav.Activado IS NULL AND nav.Id_Suscripcion = @IdSuscripcion ORDER BY nav.Id_instalacion DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();
            conexion.CerrarConexion();
            return dt;

        }

        public void LeerDatosUsuario(string Usuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT us.Id_Usuario, us.Id_Suscripcion,sus.Nombre FROM Usuario us JOIN Suscripcion sus on us.Id_Suscripcion = sus.Id_Suscripcion WHERE us.Acceso=@Usuario";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Usuario", Usuario);

            dr = comm.ExecuteReader();
            dr.Read();
            IdUsuario = dr["Id_Usuario"].ToString();

            IdSuscripcion = dr["Id_Suscripcion"].ToString();
            Nombre = dr["Nombre"].ToString();


            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosInstalacion(int IdSuscripcion, int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nav.Id_Instalacion  FROM Cat_Instalacion Nav JOIN(SELECT Id_Instalacion FROM Op_UsIns WHERE Id_Usuario=@LIdUsuario) UsAct on Nav.Id_instalacion = UsAct.Id_Instalacion WHERE nav.Activado IS NULL AND nav.Id_Suscripcion = @Id_Suscripcionn ORDER BY nav.Id_instalacion DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Suscripcionn", IdSuscripcion);
            comm.Parameters.AddWithValue("@LIdUsuario", IdUsuario);


            dr = comm.ExecuteReader();
            dr.Read();
            IdInstalacion = dr["Id_Instalacion"].ToString();

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