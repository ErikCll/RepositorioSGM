using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Administracion.Clase
{
    public class InventarioMaterial
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        public SqlDataAdapter da;
        SqlDataReader dr;
        public string Material { get; set; }


        public DataTable Mostrar(string txtSearch, int IdSuscripcion)
        {

            string query = "SELECT mat.Id_Material,mat.Nombre,mat.Codigo,mat.NumParte,mat.Unidad,COUNT(inv.Id_Material) 'Cantidad', '$' + CONVERT(varchar,CAST(SUM(mat.Costo) as money),1)'Total' FROM Cat_Material mat JOIN Op_InventarioAlmacen inv on mat.Id_Material = inv.Id_Material WHERE inv.Activado IS NULL AND mat.Activado IS NULL AND mat.Id_Suscripcion = @IdSuscripcion GROUP BY mat.Id_Material,mat.Nombre,mat.Codigo,mat.NumParte,mat.Unidad ORDER BY mat.Id_Material DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT mat.Id_Material,mat.Nombre,mat.Codigo,mat.NumParte,mat.Unidad,COUNT(inv.Id_Material) 'Cantidad', '$' + CONVERT(varchar,CAST(SUM(mat.Costo) as money),1)'Total' FROM Cat_Material mat JOIN Op_InventarioAlmacen inv on mat.Id_Material = inv.Id_Material WHERE inv.Activado IS NULL AND mat.Activado IS NULL AND mat.Id_Suscripcion = @IdSuscripcion AND mat.Nombre LIKE '%' +@txtSearch+'%' GROUP BY mat.Id_Material,mat.Nombre,mat.Codigo,mat.NumParte,mat.Unidad ORDER BY mat.Id_Material DESC  ";
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

        public DataTable MostrarDetalle(int IdMaterial)
        {

            string query = "SELECT inv.Id_Inventario, CONVERT(NVARCHAR, inv.FechaIngreso, 105) 'FechaIngreso','$' + CONVERT(varchar, CAST(mat.Costo as money), 1)'Costo', CONVERT(varchar(max), inv.qrcode, 0) 'QRCode' FROM Cat_Material mat JOIN Op_InventarioAlmacen inv on mat.Id_Material = inv.Id_Material WHERE inv.Activado IS NULL AND inv.Id_Material = @IdSuscripcioon ORDER by inv.Id_Inventario DESC";
       

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcioon", IdMaterial);
            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Eliminar(int IdInventario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_InventarioAlmacen SET Activado=1  WHERE Id_Inventario = @Id_Inventario";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Inventario", IdInventario);
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
            comm.CommandText = " SELECT Nombre FROM Cat_Material WHERE Id_Material=@Id_Material";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Material", IdMaterial);

            dr = comm.ExecuteReader();
            dr.Read();
            Material = dr["Nombre"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}