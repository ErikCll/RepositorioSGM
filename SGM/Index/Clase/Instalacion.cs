﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
{
  
    public class Instalacion
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        public SqlDataAdapter da;
        SqlDataReader dr;
        //private string nombre;
        //public string Nombre { set { nombre = value; } get { return nombre; } }
        public string Nombre { get; set; }
        public string Localizacion { get; set; }
        public string IdRegion { get; set; }
        public string Region { get; set; }

        public DataTable Mostrar(string txtSearch,int IdSuscripcion)
        {

            string query= "SELECT ins.Id_Instalacion,ins.Nombre,ins.Localizacion,reg.Nombre 'Region'FROM Cat_Instalacion ins JOIN Cat_Region reg on ins.Id_region = reg.Id_region WHERE ins.Activado IS NULL AND Id_Suscripcion=@IdSuscripcion ORDER BY ins.Id_instalacion DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim())){
                query = "SELECT ins.Id_Instalacion,ins.Nombre,ins.Localizacion,reg.Nombre 'Region'FROM Cat_Instalacion ins JOIN Cat_Region reg on ins.Id_region = reg.Id_region WHERE ins.Activado IS NULL AND Id_Suscripcion=@IdSuscripcion AND ins.Nombre LIKE '%'+@txtSearch+'%'  ORDER BY ins.Id_instalacion DESC";
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

        public DataTable MostrarRegion()
        {

           
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Region,Nombre FROM Cat_Region WHERE Activado IS NULL";
            comm.CommandType = CommandType.Text;
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(int IdRegion,string Nombre,string Localizacion,int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Instalacion] (Id_Region,Nombre,Localizacion,Id_Suscripcion) VALUES(@Id_Region,@Nombre,@Localizacion,@IdSuscripcion)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Region", IdRegion);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Localizacion", Localizacion);
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            int i=comm.ExecuteNonQuery();
            comm.Parameters.Clear();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;


            }
            else
                return false;


        }

        public bool Editar(int IdInstalacion, string Nombre, string Localizacion, int IdRegion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Instalacion SET Nombre = @Nombre, Localizacion = @Localizacion, Id_Region = @Id_Region WHERE Id_Instalacion = @Id_Instalacion";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Localizacion", Localizacion);
            comm.Parameters.AddWithValue("@Id_Region", IdRegion);

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


        public bool Eliminar(int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Instalacion SET Activado=1  WHERE Id_Instalacion = @Id_Instalacion";
            comm.CommandType = CommandType.Text;

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

        public void LeerDatos(int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT ins.Id_Instalacion,ins.Nombre,ins.Localizacion,reg.Id_Region,reg.Nombre 'Region' FROM Cat_Instalacion ins JOIN Cat_Region reg on ins.Id_region = reg.Id_region WHERE ins.Id_Instalacion=@Id_Instalacion";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Instalacion", IdInstalacion);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            Localizacion = dr["Localizacion"].ToString();
            IdRegion = dr["Id_Region"].ToString();
            Region = dr["Region"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();

            

        }



    }
}