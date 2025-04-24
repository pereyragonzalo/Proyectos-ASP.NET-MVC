using POOII_CL2_PEREYRA_GONZALO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POOII_CL2_PEREYRA_GONZALO.Controllers
{
    public class ConsultaController : Controller
    {
        // Listar tabla PRODUCTO
        IEnumerable<Producto> listarProducto()
        {
            List<Producto> temporal = new List<Producto>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar_Productos", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bool discontinued = dr.GetBoolean(6);
                    if (!discontinued)
                    {
                        temporal.Add(new Producto()
                        {
                            ProductID = dr.GetInt32(0),
                            ProductName = dr.GetString(1),
                            CategoryID = dr.GetInt32(2),
                            UnitPrice = dr.GetDecimal(3),
                            UnitsInStock = dr.GetInt16(4),
                            CategoryName = dr.GetString(5)
                        });
                    }                  
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

//==================================================================================================================
        //Listar tabla CATEGORIA
        IEnumerable<Categoria> listarCategoria()
        {
            List<Categoria> temporal = new List<Categoria>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar_Categorias", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Categoria()
                    {
                        CategoryID = dr.GetInt32(0),
                        CategoryName = dr.GetString(1)
                    });
                }
                dr.Close();
                cn.Close();
            }
            return temporal;
        }

//==================================================================================================================
        //Crear PRODUCTO
        string agregarProducto(Producto reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Agregar_Producto @ProductName, @CategoryID, " +
                    "@UnitPrice, @UnitsInStock", cn);

                cmd.Parameters.AddWithValue("@ProductName", reg.ProductName);
                cmd.Parameters.AddWithValue("@CategoryID", reg.CategoryID);
                cmd.Parameters.AddWithValue("@UnitPrice", reg.UnitPrice);
                cmd.Parameters.AddWithValue("@UnitsInStock", reg.UnitsInStock);

                int i = cmd.ExecuteNonQuery();

                cn.Close();
                mensaje = $"{1} Producto agregado satisfactoriamente";
            }
            return mensaje;
        }

//==================================================================================================================
        //Editar PRODUCTO
        string actualizarProducto(Producto reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Actualizar_Producto @ProductID, @ProductName, @CategoryID, " +
                     "@UnitPrice, @UnitsInStock", cn);

                cmd.Parameters.AddWithValue("@ProductID", reg.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", reg.ProductName);
                cmd.Parameters.AddWithValue("@CategoryID", reg.CategoryID);
                cmd.Parameters.AddWithValue("@UnitPrice", reg.UnitPrice);
                cmd.Parameters.AddWithValue("@UnitsInStock", reg.UnitsInStock);

                int i = cmd.ExecuteNonQuery();

                cn.Close();
                mensaje = $"{1} Producto actualizado satisfactoriamente";
            }
            return mensaje;
        }

//==================================================================================================================
        //DETALLE - ELIMINAR PRODUCTO
        string eliminarProducto(int id)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Eliminar_Producto @ProductID", cn);

                cmd.Parameters.AddWithValue("@ProductID", id);

                int i = cmd.ExecuteNonQuery();

                cn.Close();
                mensaje = $"Se ha eliminado {1} insumo";
            }
            return mensaje;
        }

//==================================================================================================================
        Producto buscarProducto(int id)
        {
            return listarProducto().FirstOrDefault(x => x.ProductID == id);
        }

//==================================================SOLO LAS VISTAS========================================
        public ActionResult IndexProductos()
        {
            return View(listarProducto());
        }

//-----------------------------------------------------------------------------------------------------------------

        //Get CREATE
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(listarCategoria(), "CategoryID", "CategoryName");
            return View(new Producto());
        }

        //POST CREATE
        [HttpPost]
        public ActionResult Create(Producto reg)
        {
            ViewBag.mensaje = agregarProducto(reg);
            ViewBag.categoria = new SelectList(listarCategoria(), "CategoryID", "CategoryName", reg.CategoryID);
            return View(reg);
        }

//-----------------------------------------------------------------------------------------------------------------

        //Get EDIT
        public ActionResult Edit(int id)
        {
            Producto reg = buscarProducto(id);
            ViewBag.categoria = new SelectList(listarCategoria(), "CategoryID", "CategoryName");
            return View(reg);
        }

        //POST EDIT
        [HttpPost]
        public ActionResult Edit(Producto reg)
        {
            ViewBag.mensaje = actualizarProducto(reg);
            ViewBag.categoria = new SelectList(listarCategoria(), "CategoryID", "CategoryName", reg.CategoryID);
            return View(reg);
        }

        //-----------------------------------------------------------------------------------------------------------------

        // esta es la vista de la opcion detalles
        public ActionResult Details(int? id = null)
        {
            if (id == null)
            {
                return RedirectToAction("IndexProductos");
            }
            Producto reg = listarProducto().FirstOrDefault(x => x.ProductID == id);
            return View(reg);
        }

        //-----------------------------------------------------------------------------------------------------------------

        // GET Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("IndexProductos");

            Producto reg = buscarProducto(id.Value);
            if (reg == null)
                return HttpNotFound();

            return View(reg);
        }

        //POS DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eliminarProducto(id);
            return RedirectToAction("IndexProductos");
        }

    }
}