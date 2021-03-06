﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class SistemaMed
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }
        public string IdInstalacion { get; set; }


        public DataTable Mostrar(string txtSearch, int IdInstalacion)
        {

            string query = "SELECT sis.Id_Sistema,sis.Nombre,ins.Nombre 'Instalacion' FROM Cat_SistemaMed sis JOIN Cat_Instalacion ins on sis.Id_Instalacion = ins.Id_instalacion WHERE sis.Activado IS NULL AND ins.Id_Instalacion =@IdInstalacion ORDER BY sis.Id_Sistema DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT sis.Id_Sistema,sis.Nombre,ins.Nombre 'Instalacion' FROM Cat_SistemaMed sis JOIN Cat_Instalacion ins on sis.Id_Instalacion = ins.Id_instalacion WHERE sis.Activado IS NULL AND ins.Id_Instalacion =@IdInstalacion AND sis.Nombre LIKE '%' + @txtSearch + '%' ORDER BY sis.Id_Sistema DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarInstalacion(int IdSuscripcion)
        {

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Instalacion, Nombre FROM Cat_Instalacion WHERE Activado IS NULL AND Id_Suscripcion=@IdSuscripcion ORDER BY Id_Instalacion DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;
        }


        public bool Insertar(int IdInstalacion, string Nombre)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_SistemaMed] (Id_Instalacion,Nombre) VALUES(@Id_Instalacion,@Nombre)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
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


        public bool Editar(int IdSistema, string Nombre, int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_SistemaMed SET Nombre = @Nombre, Id_Instalacion = @IdInstalacion WHERE Id_Sistema = @IdSistema";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSistema", IdSistema);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);

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

        public bool Eliminar(int IdSistema)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_SistemaMed SET Activado=1  WHERE Id_Sistema = @Id_Sistema";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Sistema", IdSistema);
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

        public void LeerDatos(int IdSistema)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT sis.Id_Sistema,sis.Nombre,ins.Id_Instalacion FROM Cat_SistemaMed sis JOIN Cat_Instalacion ins on sis.Id_Instalacion = ins.Id_instalacion WHERE sis.Id_Sistema = @Id_Sistema";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Sistema", IdSistema);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            IdInstalacion = dr["Id_Instalacion"].ToString();
   
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}