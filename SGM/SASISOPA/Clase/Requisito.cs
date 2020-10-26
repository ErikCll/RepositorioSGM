using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SASISOPA.Clase
{
    public class Requisito
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;

        public string Nombre { get; set; }
        public string VigenciaOpe { get; set; }
        public string VigenciaReg { get; set; }
        public string TieneVigencia { get; set; }



        public DataTable Mostrar(string txtSearch, int IdSuscripcion)
        {

            string query = "SELECT req.Id_Requisito,req.Nombre,reg.Nombre 'Regulador',doc.Nombre'DocumentoRegulador',  CASE WHEN req.TieneVigencia = 1 THEN CONVERT(nvarchar, req.VigenciaReg) ELSE 'N/A' END 'VigenciaReg', CASE WHEN req.TieneVigencia = 1 THEN CONVERT(nvarchar, req.VigenciaOpe) ELSE 'N/A' END 'VigenciaOpe', CASE WHEN req.TieneVigencia = 1 THEN 'Si' ELSE 'No' END 'TieneVigencia' FROM Cat_Requisito req JOIN Cat_DocRegulador doc on req.Id_DocRegulador = doc.Id_DocRegulador JOIN Cat_Regulador reg on doc.Id_Regulador = reg.Id_Regulador WHERE req.Activado IS NULL AND reg.Id_Suscripcion = @IdSuscripcion ORDER BY req.Id_Requisito DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT req.Id_Requisito,req.Nombre,reg.Nombre 'Regulador',doc.Nombre'DocumentoRegulador',  CASE WHEN req.TieneVigencia = 1 THEN CONVERT(nvarchar, req.VigenciaReg) ELSE 'N/A' END 'VigenciaReg', CASE WHEN req.TieneVigencia = 1 THEN CONVERT(nvarchar, req.VigenciaOpe) ELSE 'N/A' END 'VigenciaOpe', CASE WHEN req.TieneVigencia = 1 THEN 'Si' ELSE 'No' END 'TieneVigencia' FROM Cat_Requisito req JOIN Cat_DocRegulador doc on req.Id_DocRegulador = doc.Id_DocRegulador JOIN Cat_Regulador reg on doc.Id_Regulador = reg.Id_Regulador WHERE req.Activado IS NULL AND reg.Id_Suscripcion = @IdSuscripcion AND reg.Nombre LIKE '%' + @txtSearch + '%' ORDER BY req.Id_Requisito DESC ";
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

        public DataTable MostrarRegulador(int IdSuscripcion)
        {

            string query = "SELECT Id_Regulador,Nombre FROM Cat_Regulador WHERE Activado IS NULL AND Id_Suscripcion=@IdSuscripcionn ORDER BY Id_Regulador DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcionn", IdSuscripcion);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarDocRegulador(int IdRegulador)
        {

            string query = "SELECT Id_DocRegulador,Nombre FROM Cat_DocRegulador WHERE Activado IS NULL AND Id_Regulador=@IdReguladorr ORDER BY Id_DocRegulador DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdReguladorr", IdRegulador);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public bool Insertar(string Nombre, int VigenciaReg,int VigenciaOpe,int TieneVigencia, int Id_DocRegulador)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT INTO [Cat_Requisito] (Nombre,VigenciaReg,VigenciaOpe,TieneVigencia,Id_DocRegulador) VALUES(@Nombre,@VigenciaRef,@VigenciaOpe,@Tienevigencia,@Id_DocRegulador)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@VigenciaRef", VigenciaReg);
            comm.Parameters.AddWithValue("@VigenciaOpe", VigenciaOpe);
            comm.Parameters.AddWithValue("@Tienevigencia", TieneVigencia);
            comm.Parameters.AddWithValue("@Id_DocRegulador", Id_DocRegulador);


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


        public bool Editar(int IdRequisito, string Nombre, int VigenciaReg,int VigenciaOpe)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Requisito SET Nombre = @Nombre, VigenciaOpe=@VigenciaOpe,VigenciaReg=@VigenciaReg WHERE Id_Requisito = @Id_Requisito";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Requisito", IdRequisito);
            comm.Parameters.AddWithValue("@Nombre", Nombre);
            comm.Parameters.AddWithValue("@VigenciaReg", VigenciaReg);
            comm.Parameters.AddWithValue("@VigenciaOpe", VigenciaOpe);


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

        public bool Eliminar(int IdRequisito)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Cat_Requisito SET Activado=1  WHERE Id_Requisito = @Id_Requisito";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Requisito", IdRequisito);
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

        public void LeerDatos(int IdRequisito)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Nombre,VigenciaReg,VigenciaOpe,TieneVigencia FROM Cat_Requisito WHERE Id_Requisito=@IdRequisito";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdRequisito", IdRequisito);

            dr = comm.ExecuteReader();
            dr.Read();
            Nombre = dr["Nombre"].ToString();
            VigenciaOpe = dr["VigenciaOpe"].ToString();
            VigenciaReg = dr["VigenciaReg"].ToString();
            TieneVigencia = dr["TieneVigencia"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}