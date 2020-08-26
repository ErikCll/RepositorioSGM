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

        public DataTable MostrarGeneral2(int IdInstalacion, int Anio, int Mes)
        {

            string query = "DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX) DECLARE @Id_Instalacion as NVARCHAR(MAX) set @Id_Instalacion = @IdInstalacionn DECLARE @Mes as NVARCHAR(MAX) set @Mes =@Meess DECLARE @Anio as NVARCHAR(MAX) set @Anio = @Annioo select @cols = STUFF((SELECT ',' + QUOTENAME(turno.Nombre) FROM Cat_Turno turno JOIN Cat_Instalacion ins on turno.Id_instalacion = ins.Id_instalacion WHERE ins.Id_instalacion = @Id_Instalacion AND turno.Activado IS NULL FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'')  set @query = 'SELECT Fecha,' + @cols + ' from(select Fecha, ISNULL(MTS, 0) MTS, Turno FROM(SELECT tabla1.Fecha, tabla1.Turno, ISNULL(SUM(tabla1.MTS), 0) MTS FROM (SELECT prod.Id_Produccion, equi.Id_Equipo, equi.Nombre, CONVERT(NVARCHAR, prod.Fecha, 105) Fecha, turno.Id_Turno, turno.Nombre Turno, ROUND(ISNULL(LEAD(prod.Horometro) over(PARTITION BY equi.Id_Equipo order by prod.Fecha, prod.Id_Turno) - prod.Horometro, 0), 2)  PROD, ISNULL(ROUND(ISNULL(LEAD(prod.Horometro) over(PARTITION BY equi.Id_Equipo order by prod.Fecha, prod.Id_Turno) - prod.Horometro, 0) / turno.CapacidadOperativa * 100, 2), 0) EFIC, ISNULL(ROUND(equi.ProduccionHora * ISNULL(LEAD(prod.Horometro) over(PARTITION BY equi.Id_Equipo order by prod.Fecha, prod.Id_Turno) - prod.Horometro, 0), 2), 0) MTS FROM Op_Produccion prod JOIN Cat_Turno turno on prod.Id_Turno = turno.Id_Turno AND MONTH(prod.Fecha) = '+@Mes+' AND YEAR(prod.Fecha) = '+@Anio+' RIGHT JOIN Cat_Equipo equi on prod.Id_Equipo = equi.Id_Equipo WHERE equi.Activado IS NULL AND equi.Id_Instalacion = '+@Id_Instalacion+') tabla1 WHERE tabla1.Turno IS NOT NULL GROUP BY tabla1.Turno, tabla1.Fecha) as tabla) x pivot (SUM(MTS) for TURNO in (' + @cols + ') ) p ORDER BY Fecha ASC'execute(@query);";


            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdInstalacionn", IdInstalacion);
            comm.Parameters.AddWithValue("@Meess", Mes);
            comm.Parameters.AddWithValue("@Annioo", Anio);



            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

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


    }

}