using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Operacion.Clase
{
    public class Parametro
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string IdEquipo { get; set; }
        public string Elasticidad { get; set; }
        public string Velocidad { get; set; }
        public string Id_Material { get; set; }


        public DataTable Mostrar(string txtSearch, int IdInstalacion)
        {

            string query = "SELECT equi.Id_Equipo, equi.Nombre, CONVERT(varchar,CAST(pram.Elasticidad as money),1) 'Elasticidad',CONVERT(varchar, CAST(pram.Velocidad as money), 1) 'Velocidad',CONVERT(varchar, CAST(mat.NoPasada as money), 1) 'NoPasada' FROM Op_ParametrosOperacion pram LEFT JOIN Cat_Material mat on pram.Id_Material = mat.Id_Material LEFT JOIN Cat_Equipo equi on pram.Id_Equipo = equi.Id_equipo WHERE equi.Activado IS NULL AND equi.Id_instalacion = @IdInstalacion AND mat.Activado IS NULL";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT equi.Id_Equipo, equi.Nombre,CONVERT(varchar,CAST(pram.Elasticidad as money),1) 'Elasticidad', CONVERT(varchar, CAST(pram.Velocidad as money), 1) 'Velocidad', CONVERT(varchar, CAST(mat.NoPasada as money), 1) 'NoPasada' FROM Op_ParametrosOperacion pram LEFT JOIN Cat_Material mat on pram.Id_Material = mat.Id_Material LEFT JOIN Cat_Equipo equi on pram.Id_Equipo = equi.Id_equipo WHERE equi.Activado IS NULL AND equi.Id_instalacion = @IdInstalacion AND mat.Activado IS NULL AND equi.Nombre LIKE '%'+@txtSearch+'%'";
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


        public DataTable MostrarMaterial(int IdSuscripcion)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Material,Nombre+' | '+CONVERT(varchar,CAST(NoPasada as money),1) 'Nombre',NoPasada FROM Cat_Material WHERE Id_Suscripcion=@IdSuscripcion AND NoPasada IS NOT NULL AND Activado IS NULL ORDER BY Id_Material DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Editar(int IdEquipo, string Elasticidad, string Velocidad, int IdMaterial)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_ParametrosOperacion SET Elasticidad = @Elasticidad, Velocidad = @Velocidad, Id_Material = @IdMaterial WHERE Id_Equipo = @Id_Equipo";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Equipo", IdEquipo);
            comm.Parameters.AddWithValue("@Elasticidad", Elasticidad);
            comm.Parameters.AddWithValue("@Velocidad", Velocidad);
            comm.Parameters.AddWithValue("@IdMaterial", IdMaterial);



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

        public void LeerDatos(int IdEquipo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT CONVERT(varchar,CAST(Elasticidad as money),1) 'Elasticidad',CONVERT(varchar, CAST(Velocidad as money), 1) 'Velocidad', Id_Material FROM Op_ParametrosOperacion WHERE Id_Equipo = @IdEquipoo";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEquipoo", IdEquipo);

            dr = comm.ExecuteReader();
            dr.Read();
            Elasticidad = dr["Elasticidad"].ToString();
            Velocidad = dr["Velocidad"].ToString();
            Id_Material = dr["Id_Material"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }


    }
}