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
        public string Equipo { get; set; }

        public string Elasticidad { get; set; }
        public string Velocidad { get; set; }
        public string Id_Material { get; set; }


        public DataTable Mostrar(string txtSearch, int IdInstalacion)
        {

            //string query = "SELECT equi.Id_Equipo, equi.Nombre, CONVERT(varchar,CAST(pram.Elasticidad as money),1) 'Elasticidad',CONVERT(varchar, CAST(pram.Velocidad as money), 1) 'Velocidad',CONVERT(varchar, CAST(mat.NoPasada as money), 1) 'NoPasada' FROM Op_ParametrosOperacion pram LEFT JOIN Cat_Material mat on pram.Id_Material = mat.Id_Material LEFT JOIN Cat_Equipo equi on pram.Id_Equipo = equi.Id_equipo WHERE equi.Activado IS NULL AND equi.Id_instalacion = @IdInstalacion AND mat.Activado IS NULL";

            string query = "SELECT equi.Id_Equipo, equi.Nombre,CONVERT(varchar, CAST(s.Elasticidad as money), 1) 'Elasticidad', CONVERT(varchar, CAST(s.Velocidad as money), 1) 'Velocidad',CONVERT(varchar, CAST(mat.NoPasada as money), 1) 'NoPasada',CONVERT(nvarchar, r.Fecha, 105) 'Fecha',FORMAT(r.Fecha, 'hh:mm tt') 'Hora' FROM Cat_equipo equi LEFT JOIN(SELECT MAX(Fecha) 'Fecha', Id_Equipo FROM Op_ParametrosOperacion WHERE Activado IS NULL GROUP BY Id_Equipo) r on equi.Id_equipo = r.Id_Equipo LEFT JOIN(SELECT Id_Equipo, Fecha, Elasticidad, Velocidad, Bandas, Id_Material FROM Op_ParametrosOperacion) s on r.Fecha = s.Fecha AND r.Id_Equipo = s.Id_Equipo LEFT JOIN Cat_Material mat on s.Id_Material = mat.Id_Material WHERE equi.Activado IS NULL AND equi.Id_instalacion = @IdInstalacion AND mat.Activado IS NULL";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT equi.Id_Equipo, equi.Nombre,CONVERT(varchar, CAST(s.Elasticidad as money), 1) 'Elasticidad', CONVERT(varchar, CAST(s.Velocidad as money), 1) 'Velocidad',CONVERT(varchar, CAST(mat.NoPasada as money), 1) 'NoPasada',CONVERT(nvarchar, r.Fecha, 105) 'Fecha',FORMAT(r.Fecha, 'hh:mm tt') 'Hora' FROM Cat_equipo equi LEFT JOIN(SELECT MAX(Fecha) 'Fecha', Id_Equipo FROM Op_ParametrosOperacion WHERE Activado IS NULL GROUP BY Id_Equipo) r on equi.Id_equipo = r.Id_Equipo LEFT JOIN(SELECT Id_Equipo, Fecha, Elasticidad, Velocidad, Bandas, Id_Material FROM Op_ParametrosOperacion) s on r.Fecha = s.Fecha AND r.Id_Equipo = s.Id_Equipo LEFT JOIN Cat_Material mat on s.Id_Material = mat.Id_Material WHERE equi.Activado IS NULL AND equi.Id_instalacion = @IdInstalacion AND mat.Activado IS NULL AND equi.Nombre LIKE '%'+@txtSearch+'%'";
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

        public DataTable MostrarBitacora(string Fecha, int IdEquipo)
        {

            //string query = "SELECT equi.Id_Equipo, equi.Nombre, CONVERT(varchar,CAST(pram.Elasticidad as money),1) 'Elasticidad',CONVERT(varchar, CAST(pram.Velocidad as money), 1) 'Velocidad',CONVERT(varchar, CAST(mat.NoPasada as money), 1) 'NoPasada' FROM Op_ParametrosOperacion pram LEFT JOIN Cat_Material mat on pram.Id_Material = mat.Id_Material LEFT JOIN Cat_Equipo equi on pram.Id_Equipo = equi.Id_equipo WHERE equi.Activado IS NULL AND equi.Id_instalacion = @IdInstalacion AND mat.Activado IS NULL";

       
             string  query = "SELECT pram.Id_Parametro, CONVERT(varchar, CAST(pram.Elasticidad as money), 1) 'Elasticidad', CONVERT(varchar, CAST(pram.Velocidad as money), 1) 'Velocidad', CONVERT(varchar, CAST(mat.NoPasada as money), 1) 'NoPasada', CONVERT(nvarchar, pram.Fecha, 105) 'Fecha2', FORMAT(pram.Fecha, 'hh:mm tt') 'Hora', pram.Fecha FROM Op_ParametrosOperacion pram LEFT JOIN Cat_Material mat on pram.Id_Material = mat.Id_Material WHERE pram.Activado IS NULL AND pram.Id_Equipo = @IdEquipo AND CONVERT(NVARCHAR, CAST(pram.Fecha AS Date),105)=@Fecha ORDER BY pram.Fecha DESC";
            

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Fecha", Fecha);
            comm.Parameters.AddWithValue("@IdEquipo", IdEquipo);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarMaterial(int IdSuscripcion)
        {


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Material,Nombre+' | '+CONVERT(varchar,CAST(NoPasada as money),1) 'Nombre',NoPasada FROM Cat_Material WHERE Id_Suscripcion=@IdSuscripcion AND NoPasada IS NOT NULL AND Activado IS NULL AND Tipo='Insumo' ORDER BY Id_Material DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }


        public bool Insertar(int IdEquipo,string Elasticidad,string Velocidad,int IdMaterial, string FechaHora)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Op_ParametrosOperacion] (Id_Equipo,Elasticidad,Velocidad,Id_Material,Fecha) VALUES(@Id_Equipo,@Elasticidad,@Velocidad,@IdMaterial,CONVERT(datetime,@FechaHora,103))";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Equipo", IdEquipo);
            comm.Parameters.AddWithValue("@Elasticidad", Elasticidad);
            comm.Parameters.AddWithValue("@Velocidad", Velocidad);
            comm.Parameters.AddWithValue("@IdMaterial", IdMaterial);

            comm.Parameters.AddWithValue("@FechaHora", FechaHora);

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

        public bool Eliminar(int IdParametro)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_ParametrosOperacion SET Activado=1  WHERE Id_Parametro = @IdParametro";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdParametro", IdParametro);
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

        public void LeerDatosEquipo(int IdEquipo)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre FROM Cat_Equipo WHERE Id_Equipo=@IdEquipoo AND Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdEquipoo", IdEquipo);

            dr = comm.ExecuteReader();
            dr.Read();
            Equipo = dr["Nombre"].ToString();

            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}