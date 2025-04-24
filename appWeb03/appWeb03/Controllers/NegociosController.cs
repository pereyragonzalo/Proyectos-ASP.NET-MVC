using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//importar librerias y el modelo

using appWeb03.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace appWeb03.Controllers
{
    public class NegociosController : Controller
    {
        // ===================== Para crear variables, metodos,cadenade conexion ==============

        IEnumerable<Cliente> listarClientes() { 
            List<Cliente> temporal = new List<Cliente>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Listar_Clientes", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Cliente()
                    {
                        idcliente = dr.GetString(0),
                        nombrecia = dr.GetString(1),
                        direccion = dr.GetString(2),
                        nombrepais = dr.GetString(3),
                        telefono = dr.GetString(4)
                    });
                }
                dr.Close();
                cn.Close();
            }
                return temporal;
        }


        IEnumerable<Producto> listarProductos()
        {
            List<Producto> temporal = new List<Producto>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Listar_Productos", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Producto()
                    {
                        idproducto = dr.GetInt32(0),
                        nomproducto = dr.GetString(1),
                        nombrecategoria = dr.GetString(2),
                        preciounidad = dr.GetDecimal(3),
                        UnidadesEnExistencia = dr.GetInt16(4)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }


        // ================================= Para crear las vistas ============================

        public ActionResult ListarClientes()
        {
            return View(listarClientes());
        }


        public ActionResult ListarProductos()
        {
            return View(listarProductos());
        }

    }
}