using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using webAppT1.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace webAppT1.Controllers
{
    public class ConsultaController : Controller
    {
        IEnumerable<PedidosCliente> listarRegistro(String y)
        {
            List<PedidosCliente> temporal = new List<PedidosCliente>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_Consulta_pedidos_Cliente @y", cn);
                cmd.Parameters.AddWithValue("@y", y);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new PedidosCliente()
                    {
                        company_name = dr.IsDBNull(0) ? "" : dr.GetString(0),
                        order_id = dr.IsDBNull(1) ? 0 : dr.GetInt16(1),
                        order_date = dr.IsDBNull(2) ? DateTime.MinValue : dr.GetDateTime(2),
                        freight = dr.IsDBNull(3) ? 0 : dr.GetFloat(3),
                        ship_address = dr.IsDBNull(4) ? "" : dr.GetString(4),
                        ship_city = dr.IsDBNull(5) ? "" : dr.GetString(5)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }
//===========================================================================================================================
        IEnumerable<PedidosEmpleado> listarPedidoFechas(DateTime fec1, DateTime fec2)
        {
            List<PedidosEmpleado> temporal = new List<PedidosEmpleado>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_Consulta_Pedidos_Fechas @fec1, @fec2", cn);
                cmd.Parameters.AddWithValue("@fec1", fec1);
                cmd.Parameters.AddWithValue("@fec2", fec2);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new PedidosEmpleado()
                    {
                        order_id = dr.IsDBNull(0) ? 0 : dr.GetInt16(0),
                        order_date = dr.IsDBNull(1) ? DateTime.MinValue : dr.GetDateTime(1),
                        last_name = dr.IsDBNull(2) ? "" : dr.GetString(2),
                        first_name = dr.IsDBNull(3) ? "" : dr.GetString(3),
                        freight = dr.IsDBNull(4) ? 0 : dr.GetFloat(4),
                        ship_address = dr.IsDBNull(5) ? "" : dr.GetString(5),
                        ship_city = dr.IsDBNull(6) ? "" : dr.GetString(6)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }
//===========================================================================================================================

        IEnumerable<PedidosCliente> listarPedidoFechasAnio(int @idemp, int @y)
        {
            List<PedidosCliente> temporal = new List<PedidosCliente>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_Consulta_Pedidos_Anio_Empleado @idemp, @y", cn);
                cmd.Parameters.AddWithValue("@idemp", @idemp);
                cmd.Parameters.AddWithValue("@y", @y);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new PedidosCliente()
                    {
                        order_id = dr.IsDBNull(0) ? 0 : dr.GetInt16(0),
                        order_date = dr.IsDBNull(1) ? DateTime.MinValue : dr.GetDateTime(1),
                        employee_id = dr.IsDBNull(2) ? 0 : dr.GetInt16(2),
                        company_name = dr.IsDBNull(3) ? "" : dr.GetString(3),
                        freight = dr.IsDBNull(4) ? 0 : dr.GetFloat(4),
                        ship_address = dr.IsDBNull(5) ? "" : dr.GetString(5),
                        ship_city = dr.IsDBNull(6) ? "" : dr.GetString(6)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }
//===========================================================================================================================


        public ActionResult consultaPedido1(String y="")
        {
            return View(listarRegistro(y));
        }
//============================================================================================
        public ActionResult consultaPedido2(DateTime? fec1 = null, DateTime? fec2 = null)
        {
            DateTime _fec1 = fec1 == null ? DateTime.Today : (DateTime)fec1;
            DateTime _fec2 = fec2 == null ? DateTime.Today : (DateTime)fec2;
            return View(listarPedidoFechas(_fec1, _fec2));
        }
//============================================================================================
        public ActionResult consultaPedido3(int idemp=0, int y=0)
        {
            return View(listarPedidoFechasAnio(idemp, y));
        }

    }
}