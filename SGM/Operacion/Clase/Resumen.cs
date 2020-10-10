using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Operacion.Clase
{
    public class Resumen
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader dr;
        public string PromedioHora { get; set; }

        public string Turno1 { get; set; }
        public string Turno2 { get; set; }

        public string Turno3 { get; set; }


        public DataTable MostrarHoras(int IdInstalacion, int Anio, int Mes)
        {

            string query = "SELECT CONVERT(NVARCHAR, t.Fecha,105) 'Fecha',CAST(AVG(t.T1) as DECIMAL(10,2))'Turno1',CAST(AVG(t.T2) as DECIMAL(10,2)) 'Turno2',CAST(AVG(t.T3) as DECIMAL(10,2))'Turno3' FROM(SELECT a.[Id_equipo] ,CASE WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END AS Fecha ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno1' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute,'00:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN DATEDIFF(minute,'23:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'07:00:00.0000000') ELSE NULL END END END END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T1' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno2' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN DATEDIFF(minute,'07:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'15:00:00.0000000') ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T2' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno3' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'23:00:00.0000000')  ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' THEN DATEDIFF(minute,'15:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T3' FROM[orygon].[dbo].[op_fallas] a INNER JOIN Cat_equipo b ON a.Id_equipo = b.Id_equipo INNER JOIN Cat_Turno c ON b.Id_instalacion = c.Id_instalacion WHERE b.Id_instalacion = @HIdInstalacion AND DATEDIFF(minute, ini_averia, fin_averia) > 2 and b.Activado IS NULL GROUP BY a.[Id_equipo] , CASE WHEN c.Nombre= 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END) t WHERE MONTH(t.Fecha) = @HMes AND YEAR(t.Fecha)= @HAnio GROUP BY t.Fecha ORDER BY t.Fecha DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@HIdInstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@HMes", Mes);
            comm.Parameters.AddWithValue("@HAnio", Anio);



            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();

            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarHorasPorEquipo(int IdEquipo, int Anio, int Mes)
        {

            string query = "SELECT CONVERT(NVARCHAR, t.Fecha,105) 'Fecha',CAST(AVG(t.T1) as DECIMAL(10,2))'Turno1',CAST(AVG(t.T2) as DECIMAL(10,2)) 'Turno2',CAST(AVG(t.T3) as DECIMAL(10,2))'Turno3' FROM(SELECT a.[Id_equipo] ,CASE WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END AS Fecha ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno1' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute,'00:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN DATEDIFF(minute,'23:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'07:00:00.0000000') ELSE NULL END END END END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T1' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno2' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN DATEDIFF(minute,'07:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'15:00:00.0000000') ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T2' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno3' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'23:00:00.0000000')  ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' THEN DATEDIFF(minute,'15:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T3' FROM[orygon].[dbo].[op_fallas] a INNER JOIN Cat_equipo b ON a.Id_equipo = b.Id_equipo INNER JOIN Cat_Turno c ON b.Id_instalacion = c.Id_instalacion WHERE b.Id_Equipo=@HIdEquipo AND DATEDIFF(minute, ini_averia, fin_averia) > 2 and b.Activado IS NULL GROUP BY a.[Id_equipo] , CASE WHEN c.Nombre= 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END) t WHERE MONTH(t.Fecha) = @HMes AND YEAR(t.Fecha)= @HAnio GROUP BY t.Fecha ORDER BY t.Fecha DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@HIdEquipo", IdEquipo);
            comm.Parameters.AddWithValue("@HMes", Mes);
            comm.Parameters.AddWithValue("@HAnio", Anio);



            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();

            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarDetalleHoras(int IdInstalacion,string Fecha)
        {

            string query = "SELECT t.Id_equipo, t.Nombre 'Equipo',CONVERT(NVARCHAR, t.Fecha,105) Fecha,t.T1 'Turno1',t.T2 'Turno2',t.T3 'Turno3' FROM (SELECT a.[Id_equipo],b.Nombre ,CASE WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END AS Fecha ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno1' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute,'00:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN DATEDIFF(minute,'23:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'07:00:00.0000000') ELSE NULL END END END END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T1' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno2' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN DATEDIFF(minute,'07:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'15:00:00.0000000') ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T2' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno3' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'23:00:00.0000000')  ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' THEN DATEDIFF(minute,'15:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T3' FROM[orygon].[dbo].[op_fallas] a INNER JOIN Cat_equipo b ON a.Id_equipo = b.Id_equipo INNER JOIN Cat_Turno c ON b.Id_instalacion = c.Id_instalacion WHERE b.Id_instalacion = @HIdInstalacion AND DATEDIFF(minute, ini_averia, fin_averia) > 2 and b.Activado IS NULL GROUP BY a.[Id_equipo] ,b.Nombre, CASE WHEN c.Nombre= 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END) t WHERE t.Fecha IS NOT NULL AND CONVERT(NVARCHAR, CAST(Fecha AS Date),105)= @HFecha ORDER BY t.Fecha DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@HFecha", Fecha);
            comm.Parameters.AddWithValue("@HIdInstalacion", IdInstalacion);





            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();

            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarGeneral(int IdInstalacion,int Anio,int Mes)
        {

            string query = "DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX) DECLARE @Id_Instalacion as NVARCHAR(MAX) set @Id_Instalacion = @IdInstalacion DECLARE @Mes as NVARCHAR(MAX) set @Mes =@Mess DECLARE @Anio as NVARCHAR(MAX) set @Anio = @Anioo select @cols = STUFF((SELECT ',' + QUOTENAME(turno.Nombre) FROM Cat_Turno turno JOIN Cat_Instalacion ins on turno.Id_instalacion = ins.Id_instalacion WHERE ins.Id_instalacion = @Id_Instalacion AND turno.Activado IS NULL FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'')  set @query = 'SELECT Fecha,' + @cols + ' from(select Fecha, ISNULL(MTS, 0) MTS, Turno FROM(SELECT tabla1.Fecha, tabla1.Turno, ISNULL(SUM(tabla1.MTS), 0) MTS FROM (SELECT prod.Id_Produccion, equi.Id_Equipo, equi.Nombre, CONVERT(NVARCHAR, prod.Fecha, 105) Fecha, turno.Id_Turno, turno.Nombre Turno, ROUND(ISNULL(LEAD(prod.Horometro) over(PARTITION BY equi.Id_Equipo order by prod.Fecha, prod.Id_Turno) - prod.Horometro, 0), 2)  PROD, ISNULL(ROUND(ISNULL(LEAD(prod.Horometro) over(PARTITION BY equi.Id_Equipo order by prod.Fecha, prod.Id_Turno) - prod.Horometro, 0) / turno.CapacidadOperativa * 100, 2), 0) EFIC, ISNULL(ROUND(equi.ProduccionHora * ISNULL(LEAD(prod.Horometro) over(PARTITION BY equi.Id_Equipo order by prod.Fecha, prod.Id_Turno) - prod.Horometro, 0), 2), 0) MTS FROM Op_Produccion prod JOIN Cat_Turno turno on prod.Id_Turno = turno.Id_Turno AND MONTH(prod.Fecha) = '+@Mes+' AND YEAR(prod.Fecha) = '+@Anio+' RIGHT JOIN Cat_Equipo equi on prod.Id_Equipo = equi.Id_Equipo WHERE equi.Activado IS NULL AND equi.Id_Instalacion = '+@Id_Instalacion+') tabla1 WHERE tabla1.Turno IS NOT NULL GROUP BY tabla1.Turno, tabla1.Fecha) as tabla) x pivot (SUM(MTS) for TURNO in (' + @cols + ') ) p ORDER BY Fecha DESC'execute(@query);";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@Mess", Mes);
            comm.Parameters.AddWithValue("@Anioo", Anio);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);

            conexion.CerrarConexion();
            return dt;

        }

        //public DataTable MostrarGeneral2(int IdInstalacion, int Anio, int Mes)
        //{

        //    string query = "DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX) DECLARE @Id_Instalacion as NVARCHAR(MAX) set @Id_Instalacion = @IdInstalacionnn DECLARE @Mes as NVARCHAR(MAX) set @Mes =@Meess DECLARE @Anio as NVARCHAR(MAX) set @Anio = @Annioo select @cols = STUFF((SELECT ',' + QUOTENAME(turno.Nombre) FROM Cat_Turno turno JOIN Cat_Instalacion ins on turno.Id_instalacion = ins.Id_instalacion WHERE ins.Id_instalacion = @Id_Instalacion AND turno.Activado IS NULL FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'')  set @query = 'SELECT Fecha,' + @cols + ' from(select Fecha, ISNULL(MTS, 0) MTS, Turno FROM(SELECT tabla1.Fecha, tabla1.Turno, ISNULL(SUM(tabla1.MTS), 0) MTS FROM (SELECT prod.Id_Produccion, equi.Id_Equipo, equi.Nombre, CONVERT(NVARCHAR, prod.Fecha, 105) Fecha, turno.Id_Turno, turno.Nombre Turno, ROUND(ISNULL(LEAD(prod.Horometro) over(PARTITION BY equi.Id_Equipo order by prod.Fecha, prod.Id_Turno) - prod.Horometro, 0), 2)  PROD, ISNULL(ROUND(ISNULL(LEAD(prod.Horometro) over(PARTITION BY equi.Id_Equipo order by prod.Fecha, prod.Id_Turno) - prod.Horometro, 0) / turno.CapacidadOperativa * 100, 2), 0) EFIC, ISNULL(ROUND(equi.ProduccionHora * ISNULL(LEAD(prod.Horometro) over(PARTITION BY equi.Id_Equipo order by prod.Fecha, prod.Id_Turno) - prod.Horometro, 0), 2), 0) MTS FROM Op_Produccion prod JOIN Cat_Turno turno on prod.Id_Turno = turno.Id_Turno AND MONTH(prod.Fecha) = '+@Mes+' AND YEAR(prod.Fecha) = '+@Anio+' RIGHT JOIN Cat_Equipo equi on prod.Id_Equipo = equi.Id_Equipo WHERE equi.Activado IS NULL AND equi.Id_Instalacion = '+@Id_Instalacion+') tabla1 WHERE tabla1.Turno IS NOT NULL GROUP BY tabla1.Turno, tabla1.Fecha) as tabla) x pivot (SUM(MTS) for TURNO in (' + @cols + ') ) p ORDER BY Fecha ASC'execute(@query);";


        //    comm.Connection = conexion.AbrirConexion();
        //    comm.CommandText = query;
        //    comm.CommandType = CommandType.Text;
        //    comm.Parameters.AddWithValue("@IdInstalacionnn", IdInstalacion);
        //    comm.Parameters.AddWithValue("@Meess", Mes);
        //    comm.Parameters.AddWithValue("@Annioo", Anio);



        //    da = new SqlDataAdapter(comm);
        //    dt = new DataTable();
        //    da.Fill(dt);
        //    conexion.CerrarConexion();
        //    return dt;

        //}

        public DataTable MostrarResumenDetalle(int IdInstalacion,string Fecha)
        {

            string query = "DECLARE @cols AS NVARCHAR(MAX),  @query AS NVARCHAR(MAX) DECLARE @Id_Instalacion as NVARCHAR(MAX) set @Id_Instalacion = @IddInstalacion DECLARE @Fecha as NVARCHAR(MAX) set @Fecha = @Fechaa select @cols = STUFF((SELECT ',' + QUOTENAME(turno.Nombre) FROM Cat_Turno turno JOIN Cat_Instalacion ins on turno.Id_instalacion = ins.Id_instalacion WHERE ins.Id_instalacion = @Id_Instalacion AND turno.Activado IS NULL FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'')  set @query = 'SELECT Nombre,Fecha,' + @cols + '  from(select Id_Equipo, Nombre,Fecha, Turno, MTS FROM(SELECT prod.Id_Produccion, equi.Id_Equipo, equi.Nombre, CONVERT(NVARCHAR, prod.Fecha, 105) Fecha, turno.Nombre Turno, ISNULL(ROUND(equi.ProduccionHora * ISNULL(LEAD(prod.Horometro) over(PARTITION BY equi.Id_Equipo order by prod.Fecha, prod.Id_Turno) - prod.Horometro, 0), 2), 0) MTS FROM Op_Produccion prod JOIN Cat_Turno turno on prod.Id_Turno = turno.Id_Turno AND CONVERT(NVARCHAR, CAST(prod.Fecha AS Date), 105) = '''+@Fecha+''' RIGHT JOIN Cat_Equipo equi on prod.Id_Equipo = equi.Id_Equipo WHERE equi.Activado IS NULL AND equi.Id_Instalacion = '+@Id_Instalacion+') as tabla) x pivot(SUM(MTS) for Turno in (' + @cols + ') ) p 'execute(@query);";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IddInstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@Fechaa", Fecha);


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarResumenMetro()
        {

            string query = "SELECT CONVERT(nvarchar, Fecha, 105) 'Fecha', Turno1, Turno2, Turno3,Total FROM Demo_Metro ORDER BY Fecha DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);

            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarResumenProd()
        {

            string query = "SELECT CONVERT(nvarchar, Fecha, 105) 'Fecha', Turno1, Turno2, Turno3,Total FROM Demo_ProduccionHora ORDER BY Fecha DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
         

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
       
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarResumenEfic()
        {

            string query = "SELECT CONVERT(NVARCHAR,Fecha,105) 'Fecha',Turno1,Turno2,Turno3,Total FROM Demo_Eficiencia ORDER BY Fecha DESC";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;


            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);

            conexion.CerrarConexion();
            return dt;

        }
        public DataTable MostrarMeses(int IdInstalacion)
        {

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT MONTH(prod.Fecha) 'Mes' FROM Op_Produccion prod JOIN Cat_Equipo equi on prod.Id_Equipo = equi.Id_Equipo JOIN Cat_Instalacion ins on equi.Id_Instalacion = ins.Id_Instalacion WHERE ins.Id_Instalacion = @IdInstalacion GROUP BY MONTH(prod.Fecha) ORDER BY MONTH(prod.Fecha) DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacion", IdInstalacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarAnios(int IdInstalacion)
        {

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT YEAR(prod.Fecha) 'Anio' FROM Op_Produccion prod JOIN Cat_Equipo equi on prod.Id_Equipo = equi.Id_Equipo JOIN Cat_Instalacion ins on equi.Id_Instalacion = ins.Id_Instalacion WHERE ins.Id_Instalacion = @IdInstalacionn GROUP BY YEAR(prod.Fecha) ORDER BY YEAR(prod.Fecha) DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacionn", IdInstalacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarEquipo(int IdInstalacion)
        {

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT Id_Equipo, Nombre FROM Cat_Equipo WHERE Id_instalacion = @EIdInstalacionn AND Activado IS NULL AND IP IS NOT NULL ORDER BY Id_equipo DESC";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@EIdInstalacionn", IdInstalacion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comm.Parameters.Clear();
            conexion.CerrarConexion();
            return dt;

        }

        public void LeerDatosHoras(int IdInstalacion,int Anio,int Mes)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT ISNULL(CAST(SUM(t3.Promedio)/ NULLIF((COUNT(t3.T1)+COUNT(t3.T2)+COUNT(t3.T3)),0) as DECIMAL(10,2)),0) Promedio FROM(SELECT ISNULL(CAST((ISNULL(AVG(t2.Turno1),0) + ISNULL(AVG(t2.Turno2),0) + ISNULL(AVG(t2.Turno3),0)) AS DECIMAL(10, 2)), 0) Promedio, AVG(t2.Turno1) T1, AVG(t2.Turno2) T2, AVG(t2.Turno3) T3 FROM(SELECT CONVERT(NVARCHAR, t.Fecha,105) 'Fecha',CAST(AVG(t.T1) as DECIMAL(10, 2))'Turno1', CAST(AVG(t.T2) as DECIMAL(10, 2)) 'Turno2',CAST(AVG(t.T3) as DECIMAL(10, 2))'Turno3' FROM(SELECT a.[Id_equipo] ,CASE WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END AS Fecha ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno1' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute,'00:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN DATEDIFF(minute,'23:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'07:00:00.0000000') ELSE NULL END END END END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T1' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno2' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN DATEDIFF(minute,'07:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'15:00:00.0000000') ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T2' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno3' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'23:00:00.0000000')  ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' THEN DATEDIFF(minute,'15:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T3' FROM[orygon].[dbo].[op_fallas] a INNER JOIN Cat_equipo b ON a.Id_equipo = b.Id_equipo INNER JOIN Cat_Turno c ON b.Id_instalacion = c.Id_instalacion WHERE b.Id_instalacion = @IHIdInstalacion AND DATEDIFF(minute, ini_averia, fin_averia) > 2 and b.Activado IS NULL GROUP BY a.[Id_equipo] , CASE WHEN c.Nombre= 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END) t WHERE MONTH(t.Fecha) = @IHMes AND YEAR(t.Fecha)= @IHAnio GROUP BY t.Fecha)t2)t3";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IHIdInstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@IHAnio", Anio);
            comm.Parameters.AddWithValue("@IHMes", Mes);


            dr = comm.ExecuteReader();
            dr.Read();
            PromedioHora = dr["Promedio"].ToString();
            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }
        public void LeerDatosHorasTurno(int IdInstalacion, int Anio, int Mes)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT ISNULL(CAST(AVG(t2.Turno1) as DECIMAL(10,2)),0) 'Turno1',ISNULL(CAST(AVG(t2.Turno2) as DECIMAL(10,2)),0) 'Turno2', ISNULL(CAST(AVG(t2.Turno3) as DECIMAL(10, 2)), 0) 'Turno3'  FROM(SELECT CONVERT(NVARCHAR, t.Fecha,105) 'Fecha',CAST(AVG(t.T1) as DECIMAL(10, 2))'Turno1', CAST(AVG(t.T2) as DECIMAL(10, 2)) 'Turno2',CAST(AVG(t.T3) as DECIMAL(10, 2))'Turno3' FROM(SELECT a.[Id_equipo] ,CASE WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END AS Fecha ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno1' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute,'00:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN DATEDIFF(minute,'23:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'07:00:00.0000000') ELSE NULL END END END END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T1' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno2' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN DATEDIFF(minute,'07:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'15:00:00.0000000') ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T2' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno3' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'23:00:00.0000000')  ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' THEN DATEDIFF(minute,'15:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T3' FROM[orygon].[dbo].[op_fallas] a INNER JOIN Cat_equipo b ON a.Id_equipo = b.Id_equipo INNER JOIN Cat_Turno c ON b.Id_instalacion = c.Id_instalacion WHERE b.Id_instalacion = @IHIdInstalacion AND DATEDIFF(minute, ini_averia, fin_averia) > 2 and b.Activado IS NULL GROUP BY a.[Id_equipo] , CASE WHEN c.Nombre= 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END) t WHERE MONTH(t.Fecha) = @IHMes AND YEAR(t.Fecha)= @IHAnio GROUP BY t.Fecha)t2";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IHIdInstalacion", IdInstalacion);
            comm.Parameters.AddWithValue("@IHAnio", Anio);
            comm.Parameters.AddWithValue("@IHMes", Mes);


            dr = comm.ExecuteReader();
            dr.Read();
            Turno1 = dr["Turno1"].ToString();
            Turno2 = dr["Turno2"].ToString();
            Turno3 = dr["Turno3"].ToString();

            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosHorasTurnoPorEquipo(int IdEquipo, int Anio, int Mes)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT ISNULL(CAST(AVG(t2.Turno1) as DECIMAL(10,2)),0) 'Turno1',ISNULL(CAST(AVG(t2.Turno2) as DECIMAL(10,2)),0) 'Turno2', ISNULL(CAST(AVG(t2.Turno3) as DECIMAL(10, 2)), 0) 'Turno3'  FROM(SELECT CONVERT(NVARCHAR, t.Fecha,105) 'Fecha',CAST(AVG(t.T1) as DECIMAL(10, 2))'Turno1', CAST(AVG(t.T2) as DECIMAL(10, 2)) 'Turno2',CAST(AVG(t.T3) as DECIMAL(10, 2))'Turno3' FROM(SELECT a.[Id_equipo] ,CASE WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1,fin_averia)) WHEN c.Nombre = 'Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre = 'Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)< 480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre = 'Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END AS Fecha ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno1' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN DATEDIFF(minute,'00:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN DATEDIFF(minute,'23:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'07:00:00.0000000') ELSE NULL END END END END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T1' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno2' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN DATEDIFF(minute,'07:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'15:00:00.0000000') ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T2' ,CAST(8-SUM(CASE WHEN c.Nombre= 'Turno3' THEN CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN DATEDIFF(minute, ini_averia, fin_averia) ELSE CASE WHEN CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000' THEN DATEDIFF(minute, CONVERT(Time(0),ini_averia),'23:00:00.0000000')  ELSE CASE WHEN CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000' THEN DATEDIFF(minute,'15:00:00.0000000', CONVERT(Time(0),fin_averia)) ELSE NULL END END END END)*1.0/60*1.0 AS DECIMAL(10,1)) AS 'T3' FROM[orygon].[dbo].[op_fallas] a INNER JOIN Cat_equipo b ON a.Id_equipo = b.Id_equipo INNER JOIN Cat_Turno c ON b.Id_instalacion = c.Id_instalacion WHERE b.Id_Equipo=@IHIdEquipo AND DATEDIFF(minute, ini_averia, fin_averia) > 2 and b.Activado IS NULL GROUP BY a.[Id_equipo] , CASE WHEN c.Nombre= 'Turno1' AND CONVERT(Time(0),ini_averia) >= inicio AND CONVERT(Time(0),fin_averia) < fin THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) > '23:00:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '07:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),fin_averia) >= '23:00:00.0000000' AND CONVERT(Time(0),fin_averia) <= '23:59:00.0000000' THEN CONVERT(date, DATEADD(day,1, fin_averia)) WHEN c.Nombre='Turno1' AND CONVERT(Time(0),ini_averia) >= '00:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '07:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0 THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),fin_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '15:00:00.0000000' THEN CONVERT(date, fin_averia) WHEN c.Nombre='Turno2' AND CONVERT(Time(0),ini_averia) >= '07:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '15:00:00.0000000' THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  AND DATEDIFF(minute, ini_averia, fin_averia)<480 AND DATEDIFF(day, ini_averia, fin_averia) = 0  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),ini_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),ini_averia) < '23:00:00.0000000'  THEN CONVERT(date, ini_averia) WHEN c.Nombre='Turno3' AND CONVERT(Time(0),fin_averia) >= '15:00:00.0000000' AND CONVERT(Time(0),fin_averia) < '23:00:00.0000000'  THEN CONVERT(date, fin_averia) END) t WHERE MONTH(t.Fecha) = @IHMes AND YEAR(t.Fecha)= @IHAnio GROUP BY t.Fecha)t2";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IHIdEquipo", IdEquipo);
            comm.Parameters.AddWithValue("@IHAnio", Anio);
            comm.Parameters.AddWithValue("@IHMes", Mes);


            dr = comm.ExecuteReader();
            dr.Read();
            Turno1 = dr["Turno1"].ToString();
            Turno2 = dr["Turno2"].ToString();
            Turno3 = dr["Turno3"].ToString();

            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }
    }

}