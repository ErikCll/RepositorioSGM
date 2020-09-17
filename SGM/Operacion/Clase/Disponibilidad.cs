using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Operacion.Clase
{
    public class Disponibilidad
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string TotalEquipos { get; set; }
        public string TotalEquiposOperando { get; set; }



        public DataTable MostrarEquipos(string txtSearch,int IdIntalacion)
        {



            string query = "SELECT equi.Id_Equipo,equi.Nombre,equi.Id_Instalacion, bitc.maxId, CONVERT(nvarchar,bitc2.ini_averia, 105) 'Fecha', CASE WHEN bitc.maxId IS NULL OR bitc2.fin_averia IS NOT NULL THEN 'Operando' ELSE 'Falla' END 'Estatus', FORMAT(bitc2.ini_averia, 'hh:mm tt') 'Hora', CAST(DATEDIFF(minute, ini_averia, DATEADD(HH, -5, GETDATE())) / 1440 AS VARCHAR(8))+'d,'+CAST(DATEDIFF(minute, ini_averia, DATEADD(HH, -5, GETDATE()))% 1440 / 60 AS VARCHAR(8)) + 'h:' + FORMAT(DATEDIFF(minute, ini_averia, DATEADD(HH, -5, GETDATE())) % 60, 'D2')+'m' 'Transcurrido' FROM Cat_Equipo equi LEFT JOIN(SELECT Id_Equipo, MAX(Id_Falla) maxId FROM Op_Fallas WHERE Activado IS NULL AND CASE WHEN DATEDIFF(minute, ini_averia, fin_averia) IS NULL THEN '1010' ELSE DATEDIFF(minute, ini_averia, fin_averia) END>2 GROUP BY Id_Equipo) bitc on equi.Id_Equipo = bitc.Id_Equipo LEFT JOIN(SELECT Id_Falla, Id_Equipo, ini_averia, fin_averia FROM Op_Fallas) bitc2 on bitc.maxId = bitc2.Id_Falla WHERE equi.Id_Instalacion = @IdInstalacion AND equi.Activado IS NULL ORDER BY Estatus ASC, equi.Id_Equipo DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT equi.Id_Equipo,equi.Nombre,equi.Id_Instalacion, bitc.maxId, CONVERT(nvarchar,bitc2.ini_averia, 105) 'Fecha', CASE WHEN bitc.maxId IS NULL OR bitc2.fin_averia IS NOT NULL THEN 'Operando' ELSE 'Falla' END 'Estatus', FORMAT(bitc2.ini_averia, 'hh:mm tt') 'Hora', CAST(DATEDIFF(minute, ini_averia, DATEADD(HH, -5, GETDATE())) / 1440 AS VARCHAR(8))+'d,'+CAST(DATEDIFF(minute, ini_averia, DATEADD(HH, -5, GETDATE()))% 1440 / 60 AS VARCHAR(8)) + 'h:' + FORMAT(DATEDIFF(minute, ini_averia, DATEADD(HH, -5, GETDATE())) % 60, 'D2')+'m' 'Transcurrido' FROM Cat_Equipo equi LEFT JOIN(SELECT Id_Equipo, MAX(Id_Falla) maxId FROM Op_Fallas WHERE Activado IS NULL AND CASE WHEN DATEDIFF(minute, ini_averia, fin_averia) IS NULL THEN '1010' ELSE DATEDIFF(minute, ini_averia, fin_averia) END>2 GROUP BY Id_Equipo) bitc on equi.Id_Equipo = bitc.Id_Equipo LEFT JOIN(SELECT Id_Falla, Id_Equipo, ini_averia, fin_averia FROM Op_Fallas) bitc2 on bitc.maxId = bitc2.Id_Falla WHERE equi.Id_Instalacion = @IdInstalacion AND equi.Activado IS NULL AND equi.Nombre LIKE '%' + @txtSearch + '%' ORDER BY Estatus ASC, equi.Id_Equipo DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacion", IdIntalacion);
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public void LeerDatosTotalEquipos(int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) 'Total' FROM Cat_Equipo WHERE Activado IS NULL AND Id_Instalacion = @IdInstalacionn";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacionn", IdInstalacion);
            dr = comm.ExecuteReader();
            dr.Read();
            TotalEquipos = dr["Total"].ToString();
            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosTotalOperando(int IdInstalacion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) 'Operando' FROM Cat_Equipo equi LEFT JOIN(SELECT Id_Equipo, MAX(Id_Falla) maxId FROM Op_Fallas WHERE Activado IS NULL GROUP BY Id_Equipo) bitc on equi.Id_Equipo = bitc.Id_Equipo LEFT JOIN(SELECT Id_Falla, fin_averia FROM Op_Fallas) bitc2 on bitc.maxId = bitc2.Id_Falla WHERE equi.Id_Instalacion = @IdInstalacionn AND equi.Activado IS NULL AND (bitc.maxId IS NULL OR bitc2.fin_averia IS NOT NULL)";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacionn", IdInstalacion);
            dr = comm.ExecuteReader();
            dr.Read();
            TotalEquiposOperando = dr["Operando"].ToString();
            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}