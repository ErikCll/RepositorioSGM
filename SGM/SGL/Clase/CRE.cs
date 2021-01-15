using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SGL.Clase
{
    public class CRE
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        public SqlDataAdapter da;
        SqlDataReader dr;
        public string No { get; set; }
        public string Referencia { get; set; }
        public string IdInstalacion { get; set; }

        public DataTable Mostrar(string txtSearch, int IdInstalacion)
        {

            string query = "SELECT acre.Id_Acreditacion, acre.Numero 'No', acre.Referencia,CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha', sta2.Status,ISNULL(sta2.Id_status, 0) 'Id_status' FROM Op_Acreditacion acre LEFT JOIN(SELECT MAX(Fecha) 'Fecha', Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE acre.Id_Instalacion = @IdInstalacion AND acre.Activado IS NULL AND acre.Acreditador = 'CRE' ORDER BY acre.Id_Acreditacion DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT acre.Id_Acreditacion, acre.Numero 'No', acre.Referencia,CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha', sta2.Status,ISNULL(sta2.Id_status, 0) 'Id_status' FROM Op_Acreditacion acre LEFT JOIN(SELECT MAX(Fecha) 'Fecha', Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE acre.Id_Instalacion = @IdInstalacion AND acre.Activado IS NULL AND acre.Acreditador = 'CRE' AND acre.Numero LIKE '%'+@txtSearch+'%' ORDER BY acre.Id_Acreditacion DESC";
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

        public DataTable MostrarCreEma(int IdInstalacion)
        {

            string query = "SELECT acre.Id_Acreditacion,acre.Acreditador, CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha', sta2.Status,ISNULL(sta2.Id_status, 0) 'Id_status' FROM Op_Acreditacion acre JOIN(SELECT MAX(Fecha) 'Fecha', Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE acre.Id_Instalacion = @IdInstalacionn AND acre.Activado IS NULL AND acre.Acreditador = 'EMA' AND sta2.Fecha = (SELECT MAX(Fecha) FROM Op_AcreditacionStatus WHERE id_status = sta2.Id_Status)  UNION ALL SELECT acre.Id_Acreditacion,acre.Acreditador, CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha', sta2.Status,ISNULL(sta2.Id_status, 0) 'Id_status' FROM Op_Acreditacion acre JOIN(SELECT MAX(Fecha) 'Fecha', Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE acre.Id_Instalacion = @IdInstalacionn AND acre.Activado IS NULL AND acre.Acreditador = 'CRE' AND sta2.Fecha = (SELECT MAX(Fecha) FROM Op_AcreditacionStatus WHERE id_status = sta2.Id_Status) ";



            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacionn", IdInstalacion);
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

        public bool Insertar(int IdInstalacion, string No, string Referencia)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "INSERT [Op_Acreditacion] (Id_Instalacion,Numero,Referencia,Acreditador) VALUES(@IdInstalacion,@No,@Referencia,'CRE')";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@No", No);
            comm.Parameters.AddWithValue("@Referencia", Referencia);

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

        public bool Editar(int IdAcreditacion, string No, string Referencia, int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_Acreditacion SET Numero = @No, Referencia = @Referencia, Id_Instalacion = @Id_Instalacion WHERE Id_Acreditacion = @Id_Acreditacion";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Acreditacion", IdAcreditacion);
            comm.Parameters.AddWithValue("@No", No);
            comm.Parameters.AddWithValue("@Referencia", Referencia);
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


        public bool Eliminar(int IdAcreditacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "UPDATE Op_Acreditacion SET Activado=1  WHERE Id_Acreditacion = @Id_Acreditacion";
            comm.CommandType = CommandType.Text;

            comm.Parameters.AddWithValue("@Id_Acreditacion", IdAcreditacion);
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

        public void LeerDatos(int IdAcreditacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Numero,Referencia,Id_Instalacion FROM Op_Acreditacion WHERE Id_Acreditacion=@Id_Acreditacion";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@Id_Acreditacion", IdAcreditacion);

            dr = comm.ExecuteReader();
            dr.Read();
            No = dr["Numero"].ToString();
            Referencia = dr["Referencia"].ToString();
            IdInstalacion = dr["Id_Instalacion"].ToString();
            dr.Close();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}