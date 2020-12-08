using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
{
    public class Material
    {

        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        public SqlDataAdapter da;
        SqlDataReader dr;

        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string NumParte { get; set; }
        public string Costo { get; set; }
        public string TipoUnidad { get; set; }
        public string Tipo { get; set; }
        public string NoPasada { get; set; }



        public DataTable Mostrar(string txtSearch, int IdSuscripcion)
        {

            string query = "SELECT Id_Material,Nombre,Codigo,NumParte,'$' +CONVERT(varchar,CAST(costo as money),1) 'Costo',Unidad,Tipo,CONVERT(varchar,CAST(NoPasada as money),1) 'NoPasada' FROM Cat_Material WHERE Id_Suscripcion = @IdSuscripcion AND Activado IS NULL ORDER BY Id_Material DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT Id_Material,Nombre,Codigo,NumParte,'$' +CONVERT(varchar,CAST(costo as money),1) 'Costo',Unidad,Tipo,CONVERT(varchar,CAST(NoPasada as money),1) 'NoPasada' FROM Cat_Material WHERE Id_Suscripcion = @IdSuscripcion AND Activado IS NULL AND Nombre LIKE '%'+@txtSearch+'%' ORDER BY Id_Material DESC";
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

        public bool Insertar(string Nombre, string Codigo, string NumParte, int IdSuscripcion, string Costo, string TipoUnidad,string Tipo,string NoPasada)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Material] (Nombre,Codigo,NumParte,Id_Suscripcion,Costo,Unidad,Tipo,NoPasada) VALUES(@Nombre,@Codigo,@NumParte,@IdSuscripcion,@Costo,@Unidad,@Tipo,@NoPasada)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Codigo", Codigo);
            comm.Parameters.AddWithValue("@NumParte", NumParte);
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            comm.Parameters.AddWithValue("@Costo", Costo);

            comm.Parameters.AddWithValue("@Unidad", TipoUnidad);

            comm.Parameters.AddWithValue("@Tipo", Tipo);
            comm.Parameters.AddWithValue("@NoPasada", NoPasada);


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

        public bool Editar(int IdMaterial, string Nombre, string Codigo, string NumParte, string Costo, string TipoUnidad,string Tipo,string NoPasada)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Material SET Nombre = @Nombre, Codigo = @Codigo, NumParte = @NumParte, Costo=@Costo, Unidad=@TipoUnidad,Tipo=@Tipo,NoPasada=@NoPasada WHERE Id_Material = @Id_Material";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Material", IdMaterial);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@Codigo", Codigo);
            comm.Parameters.AddWithValue("@NumParte", NumParte);
            comm.Parameters.AddWithValue("@Costo", Costo);
            comm.Parameters.AddWithValue("@TipoUnidad", TipoUnidad);
            comm.Parameters.AddWithValue("@Tipo", Tipo);
            comm.Parameters.AddWithValue("@NoPasada", NoPasada);



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

        public bool Eliminar(int IdMaterial)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Material SET Activado=1  WHERE Id_Material = @Id_Material";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Material", IdMaterial);
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

        public void LeerDatos(int IdMaterial)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre,Codigo,NumParte,REPLACE(costo,',','.') 'Costo',Unidad,Tipo,REPLACE(NoPasada,',','.') 'NoPasada' FROM Cat_Material WHERE Id_Material=@Id_Material";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Material", IdMaterial);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            Codigo = dr["Codigo"].ToString();
            NumParte = dr["NumParte"].ToString();
            Costo = dr["Costo"].ToString();

            TipoUnidad = dr["Unidad"].ToString();
            Tipo = dr["tipo"].ToString();
            NoPasada = dr["NoPasada"].ToString();



            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }

    }
}