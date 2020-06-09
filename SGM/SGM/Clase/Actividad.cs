﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGM.Clase
{
    public class Actividad
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string IdArea { get; set; }
        public string Area { get; set; }


        public DataTable Mostrar(string txtSearch)
        {

            string query = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre,act.Codigo,area.Nombre 'Area' FROM Cat_Actividades act JOIN Cat_Area area on act.Id_Area = area.Id_area WHERE act.Activado IS NULL ORDER BY act.Id_Actividades DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = " SELECT act.Id_Actividades 'Id_Actividad',act.Nombre,act.Codigo,area.Nombre 'Area' FROM Cat_Actividades act JOIN Cat_Area area on act.Id_Area = area.Id_area WHERE act.Activado IS NULL AND act.Nombre LIKE '%'+@txtSearch+'%' ORDER BY act.Id_Actividades DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            dr = comm.ExecuteReader();
            dt.Load(dr);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarArea()
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Area, Nombre FROM Cat_Area WHERE Activado IS NULL ORDER BY Id_area DESC";
            comm.CommandType = CommandType.Text;
            dr = comm.ExecuteReader();
            dt.Load(dr);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdArea, string Nombre, string Codigo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Actividades] (Id_Area,Nombre,Codigo) VALUES(@Id_Area,@Nombre,@Codigo)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Area", IdArea);
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

        public bool Editar(int IdActividad, string Nombre, string Codigo, int IdArea)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Actividades SET Nombre = @Nombre, Codigo = @Codigo, Id_Area = @Id_Area WHERE Id_Actividades = @Id_Actividades";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividades", IdArea);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Codigo", Codigo);
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


        public bool Eliminar(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Actividades SET Activado=1  WHERE Id_Actividades = @Id_Actividades";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Actividades", IdArea);
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

        public void LeerDatos(int IdActividad)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT act.Id_Actividades 'Id_Actividad',act.Nombre,act.Codigo,area.Id_area, area.Nombre 'Area' FROM Cat_Actividades act JOIN Cat_Area area on act.Id_Area = area.Id_area WHERE act.Id_Actvidades=@Id_Actividades";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Actividades", IdActividad);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            Codigo = dr["Codigo"].ToString();
            IdArea = dr["Id_Area"].ToString();
            Area = dr["Area"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}