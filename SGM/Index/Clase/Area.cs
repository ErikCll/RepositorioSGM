﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
{
    public class Area
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string IdInstalacion { get; set; }
        public string Instalacion { get; set; }

        public DataTable Mostrar(string txtSearch,int IdSuscripcion)
        {

            string query = "SELECT area.Id_Area, area.Nombre,area.Codigo, ins.Nombre 'Instalacion' FROM Cat_Area area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE area.Activado IS NULL AND ins.Id_Suscripcion=@IdSuscripcion ORDER BY area.Id_instalacion DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT area.Id_Area, area.Nombre,area.Codigo, ins.Nombre 'Instalacion' FROM Cat_Area area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE area.Activado IS NULL AND area.Nombre LIKE '%'+@txtSearch+'%' AND ins.Id_Suscripcion = @IdSuscripcion ORDER BY area.Id_instalacion DESC";
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

        public DataTable MostrarInstalacion(int IdSuscripcion)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Instalacion,Nombre FROM Cat_Instalacion WHERE Activado IS NULL AND Id_Suscripcion=@IdSuscripcionn ORDER BY Id_Instalacion DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcionn", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdInstalacion, string Nombre, string Codigo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Area] (Id_Instalacion,Nombre,Codigo) VALUES(@Id_Instalacion,@Nombre,@Codigo)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Codigo", Codigo);
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

        public bool Editar(int IdArea, string Nombre, string Codigo, int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Area SET Nombre = @Nombre, Codigo = @Codigo, Id_Instalacion = @Id_Instalacion WHERE Id_Area = @Id_Area";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Area", IdArea);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Codigo", Codigo);
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);

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


        public bool Eliminar(int IdArea)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Area SET Activado=1  WHERE Id_Area = @Id_Area";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Area", IdArea);
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

        public void LeerDatos(int IdArea)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT area.Id_Area, area.Nombre, area.Codigo, ins.Id_Instalacion, ins.Nombre 'Instalacion' FROM Cat_Area area JOIN Cat_Instalacion ins on area.Id_instalacion = ins.Id_instalacion WHERE area.Id_area = @Id_Area";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Area", IdArea);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            Codigo = dr["Codigo"].ToString();
            IdInstalacion = dr["Id_Instalacion"].ToString();
            Instalacion = dr["Instalacion"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }



    }
}