using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using appWeb05.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace appWeb05.Controllers
{
    public class MantenimientoController : Controller
    {
        //======================================== Variables y Metodos ====================================

        //R : LISTADOS
        IEnumerable<Proveedor> cargarProveedores()
        {
            List<Proveedor> temporal = new List<Proveedor>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Cargar_Proveedores", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Proveedor()
                    {
                        IdProveedor = dr.GetInt32(0),
                        NomProveedor = dr.GetString(1)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

        IEnumerable<Insumos> listarInsumos()
        {
            List<Insumos> temporal = new List<Insumos>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spU_Listar_Insumos", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Insumos()
                    {
                        idInsumo = dr.GetInt32(0),
                        nomInsumo = dr.GetString(1),
                        NomProveedor = dr.GetString(2),
                        preUnitario = dr.GetDecimal(3),
                        stockUnitario = dr.GetInt16(4),
                        idProveedor = dr.GetInt32(5)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }


        //C : CREATE
        string agregarInsumos(Insumos reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Insertar_Insumos @idInsumo, @nomInsumo, " + 
                    "@IdProveedor, @preUnitario, @stockUnitario", cn);

                cmd.Parameters.AddWithValue("@idInsumo", reg.idInsumo);
                cmd.Parameters.AddWithValue("@nomInsumo", reg.nomInsumo);
                cmd.Parameters.AddWithValue("@IdProveedor", reg.idProveedor);
                cmd.Parameters.AddWithValue("@preUnitario", reg.preUnitario);
                cmd.Parameters.AddWithValue("@stockUnitario", reg.stockUnitario);

                int i = cmd.ExecuteNonQuery();

                cn.Close();
                mensaje = $"Se ha agregado {1} insumo";
            }
            return mensaje;
        }

        //U : UPDATE
        string actualizarInsumos(Insumos reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Alterar_Insumos @idInsumo, @nomInsumo, " +
                    "@IdProveedor, @preUnitario, @stockUnitario", cn);

                cmd.Parameters.AddWithValue("@idInsumo", reg.idInsumo);
                cmd.Parameters.AddWithValue("@nomInsumo", reg.nomInsumo);
                cmd.Parameters.AddWithValue("@IdProveedor", reg.idProveedor);
                cmd.Parameters.AddWithValue("@preUnitario", reg.preUnitario);
                cmd.Parameters.AddWithValue("@stockUnitario", reg.stockUnitario);

                int i = cmd.ExecuteNonQuery();

                cn.Close();
                mensaje = $"Se ha actualizar {1} insumo";
            }
            return mensaje;
        }

        //D : DETAILS - DELETE
        string eliminarInsumos(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Eliminar_Insumos @idInsumo", cn);

                cmd.Parameters.AddWithValue("@idInsumo", id);

                int i = cmd.ExecuteNonQuery();

                cn.Close();
                mensaje = $"Se ha eliminado {1} insumo";
            }
            return mensaje;
        }


        Insumos buscarInsumo(int id)
        {
            return listarInsumos().FirstOrDefault(x => x.idInsumo == id);
        }


        //======================================== Vistas ====================================
		
        public ActionResult ListarInsumos()
        {
            return View(listarInsumos());
        }


        //este es el Get CREATE
        public ActionResult Create()
        {
            ViewBag.proveedores = new SelectList(cargarProveedores(), "IdProveedor", "NomProveedor");
            return View(new Insumos());
        }

        //este es el POST CREATE
        [HttpPost]
        public ActionResult Create(Insumos reg)
        {
            ViewBag.mensaje = agregarInsumos(reg);
            ViewBag.proveedores = new SelectList(cargarProveedores(), "IdProveedor", "NomProveedor", reg.idProveedor);
            return View(reg);
        }


        //este es el Get EDIT
        public ActionResult Edit(int id)
        {
            Insumos reg = buscarInsumo(id);
            ViewBag.proveedores = new SelectList(cargarProveedores(), "IdProveedor", "NomProveedor");
            return View(reg);
        }

        //este es el POST EDIT
        [HttpPost]
        public ActionResult Edit(Insumos reg)
        {
            ViewBag.mensaje = actualizarInsumos(reg);
            ViewBag.proveedores = new SelectList(cargarProveedores(), "IdProveedor", "NomProveedor", reg.idProveedor);
            return View(reg);
        }

        // este es la vista de la opcion detalles
        public ActionResult Details(int ? id = null)
        {
            if (id == null) 
            {
                return RedirectToAction("ListarInsumos");
            }
            Insumos reg = listarInsumos().FirstOrDefault(x => x.idInsumo == id);
            return View(reg);
        }

        // este es el eliminar
        public ActionResult Delete(int? id = null)
        {
            if (id == null)
                return RedirectToAction("ListarInsumos");

            ViewBag.mensaje = eliminarInsumos(id.Value);
            return RedirectToAction("ListarInsumos");  
        }

    }
}