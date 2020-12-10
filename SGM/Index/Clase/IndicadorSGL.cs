using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace SAM.Clase
{
    public class IndicadorSGL
    {
        private Conexion conexion = new Conexion();
        SqlCommand comm = new SqlCommand();
        DataTable dt = new DataTable();
        public SqlDataAdapter da;
        SqlDataReader dr;
        public string TotalInstalacion { get; set; }
        public string TotalDisponible { get; set; }
        public string TotalDisponibleEMA { get; set; }
        public string TotalDisponibleCRE { get; set; }


        public bool ValidarAcreditacion(int IdUsuario)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) FROM MenuSubMenu Nav JOIN(SELECT Id_SubMenu FROM UsuarioSubMenu WHERE Id_Usuario = @IdUsuario) ussubmenu on Nav.Id_SubMenu = ussubmenu.Id_SubMenu JOIN SistemaMenu sismenu on nav.Id_Menu = sismenu.Id_Menu WHERE nav.Activado IS NULL AND nav.Id_Menu = 12 AND sismenu.Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdUsuario", IdUsuario);
            int i = (int)comm.ExecuteScalar();
            comm.Parameters.Clear();
            conexion.CerrarConexion();

            if (i > 0)
            {
                return true;
            }
            else
                return false;

        }

        public DataTable MostrarDetalleAcreditacionTodo(string txtSearch, int IdSuscripcion)
        {
            

            string query = "SELECT ins.Id_Instalacion, ins.Nombre,ins.Localizacion,acre.Numero 'No', acre.Referencia,CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha',sta2.Status, ISNULL(sta2.Id_status, 0) Id_status,acre.Acreditador FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcioon AND acre.Activado IS NULL ORDER BY sta2.Id_status DESC, ins.Id_Instalacion DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT ins.Id_Instalacion, ins.Nombre,ins.Localizacion,acre.Numero 'No', acre.Referencia,CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha',sta2.Status, ISNULL(sta2.Id_status, 0) Id_status,acre.Acreditador FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcioon AND acre.Activado IS NULL AND ins.Nombre LIKE '%'+@txtSearchh+'%'  ORDER BY sta2.Id_status DESC, ins.Id_Instalacion DESC";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearchh", txtSearch);
            comm.Parameters.AddWithValue("@IdSuscripcioon", IdSuscripcion);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public DataTable MostrarDetalleAcreditacion(string txtSearch, int IdSuscripcion,string Acreditador)
        {
            //string query = "SELECT ins.Id_Instalacion, ins.Nombre,ins.Localizacion,acre.Numero 'No', acre.Referencia,CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha',sta2.Status, ISNULL(sta2.Id_status, 0) Id_status,acre.Acreditador FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL ORDER BY sta2.Id_status DESC, ins.Id_Instalacion DESC";

            string query = "SELECT ins.Id_Instalacion, ins.Nombre,ins.Localizacion,acre.Numero 'No', acre.Referencia,CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha',sta2.Status, ISNULL(sta2.Id_status, 0) Id_status ,acre.Acreditador FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL AND acre.Acreditador = @Acreditador UNION ALL SELECT ins.Id_Instalacion, ins.Nombre, ins.Localizacion, acre.Numero 'No', acre.Referencia, CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha', sta2.Status, ISNULL(sta2.Id_status, 0) Id_status ,acre.Acreditador FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL AND acre.Acreditador IS NULL ORDER BY Id_status DESC";
            if (!String.IsNullOrEmpty(txtSearch.Trim()))
            {
                query = "SELECT ins.Id_Instalacion, ins.Nombre,ins.Localizacion,acre.Numero 'No', acre.Referencia,CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha',sta2.Status, ISNULL(sta2.Id_status, 0) Id_status ,acre.Acreditador FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL AND acre.Acreditador = @Acreditador AND ins.Nombre LIKE '%'+@txtSearch+'%' UNION ALL SELECT ins.Id_Instalacion, ins.Nombre, ins.Localizacion, acre.Numero 'No', acre.Referencia, CONVERT(NVARCHAR, sta2.Fecha, 105) 'Fecha', sta2.Status, ISNULL(sta2.Id_status, 0) Id_status ,acre.Acreditador FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion) sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL AND acre.Acreditador IS NULL AND ins.Nombre LIKE '%'+@txtSearch+'%' ORDER BY Id_status DESC ";
            }

            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@txtSearch", txtSearch);
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            comm.Parameters.AddWithValue("@Acreditador", Acreditador);

            da = new SqlDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            conexion.CerrarConexion();
            return dt;

        }

        public void LeerDatosTotalInstalacionAcreditacion(int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) 'Total' from Cat_Instalacion WHERE Id_Suscripcion=@IdSuscripcion AND Activado IS NULL";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            dr = comm.ExecuteReader();
            dr.Read();
            TotalInstalacion = dr["Total"].ToString();
            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosTotalDisponibleAcreditacion(int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) 'Disponible' FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion)  sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL AND sta2.Status in ('Inicio', 'Actualización')";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            dr = comm.ExecuteReader();
            dr.Read();
            TotalDisponible = dr["Disponible"].ToString();
            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosTotalDisponibleEMA(int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) 'Disponible' FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion)  sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL AND sta2.Status in ('Inicio', 'Actualización') AND acre.Acreditador='EMA'";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            dr = comm.ExecuteReader();
            dr.Read();
            TotalDisponibleEMA = dr["Disponible"].ToString();
            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }

        public void LeerDatosTotalDisponibleCRE(int IdSuscripcion)
        {
            comm.Connection = conexion.AbrirConexion();
            comm.CommandText = "SELECT COUNT(*) 'Disponible' FROM Cat_Instalacion ins LEFT JOIN Op_Acreditacion acre on ins.Id_instalacion = acre.Id_Instalacion LEFT JOIN(SELECT MAX(Fecha) 'Fecha',Id_acreditacion FROM Op_AcreditacionStatus WHERE Activado IS NULL GROUP BY Id_Acreditacion)  sta on acre.Id_Acreditacion = sta.Id_Acreditacion LEFT JOIN Op_AcreditacionStatus sta2 on sta.Id_Acreditacion = sta2.Id_Acreditacion and sta.Fecha = sta2.Fecha WHERE ins.Activado IS NULL AND Id_Suscripcion = @IdSuscripcion AND acre.Activado IS NULL AND sta2.Status in ('Inicio', 'Actualización') AND acre.Acreditador='CRE'";
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@IdSuscripcion", IdSuscripcion);
            dr = comm.ExecuteReader();
            dr.Read();
            TotalDisponibleCRE = dr["Disponible"].ToString();
            dr.Close();
            comm.Parameters.Clear();
            comm.Connection = conexion.CerrarConexion();



        }
    }
}