using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using appWeb04.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace appWeb04.Controllers
{
    public class NegociosController : Controller
    {
        //=====================variables, metodos y conexiones===============================

        IEnumerable<Pedido> listarPedidoAnio(int y)
        {
            List<Pedido> temporal = new List<Pedido>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Pedidos_Year @y", cn);
                cmd.Parameters.AddWithValue("@y", y);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Pedido()
                    {
                        idpedido = dr.GetInt32(0),
                        fechapedido = dr.GetDateTime(1),
                        nombrecia = dr.GetString(2),
                        dirdestinatario = dr.GetString(3),
                        ciudestinatario = dr.GetString(4)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Pedido> listarPedidoFechas(DateTime f1, DateTime f2)
        {
            List<Pedido> temporal = new List<Pedido>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Pedidos_Entre_Fechas @f1, @f2", cn);
                cmd.Parameters.AddWithValue("@f1", f1);
                cmd.Parameters.AddWithValue("@f2", f2);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Pedido()
                    {
                        idpedido = dr.GetInt32(0),
                        fechapedido = dr.GetDateTime(1),
                        nombrecia = dr.GetString(2),
                        dirdestinatario = dr.GetString(3),
                        ciudestinatario = dr.GetString(4)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Pedido> listarPedidos()
        {
            List<Pedido> temporal = new List<Pedido>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Pedidos_General", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Pedido()
                    {
                        idpedido = dr.GetInt32(0),
                        fechapedido = dr.GetDateTime(1),
                        nombrecia = dr.GetString(2),
                        dirdestinatario = dr.GetString(3),
                        ciudestinatario = dr.GetString(4),
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }


        //=========================vistas abajo========================
        public ActionResult ConsultaPedidoAnio(int y = 0)
        {
            return View(listarPedidoAnio(y));
        }

        public ActionResult ConsultaPedidoEntreFecha(DateTime? f1 = null, DateTime? f2 = null)
        {
            DateTime _f1 = f1 == null ? DateTime.Today : (DateTime)f1;
            DateTime _f2 = f2 == null ? DateTime.Today : (DateTime)f2;
            return View(listarPedidoFechas(_f1, _f2));
        }

        public ActionResult Paginacionpedidos(int p = 0)
        {
            int c = listarPedidos().Count(); //cuento la cantidad de registros
            int f = 25; // Mostrar 25 registros por pagina

            int npags;

            if (c % f == 0) {
                npags = c / f;
            } else {
                npags = c / f + 1;
            }

            ViewBag.p = p;
            ViewBag.npags = npags;

            return View(listarPedidos().Skip(f * p).Take(f));
         }

        public ActionResult PaginacionPedidosAnio(int p = 0, int y = 0)
        {
            IEnumerable<Pedido> temporal = listarPedidoAnio(y);

            int c = temporal.Count(); //cuento la cantidad de registros
            int f = 15; // Mostrar 25 registros por pagina 
            int npags = c % f == 0 ? c / f : c / f +1 ; //lo mismo que la condicion pero en ternario

            ViewBag.p = p;
            ViewBag.y = y;
            ViewBag.npags = npags;

            return View(temporal.Skip(f * p).Take(f));
        }
    }
}