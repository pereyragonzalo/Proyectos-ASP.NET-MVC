using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using appWeb02.Models;

namespace appWeb02.Controllers
{
    public class ConsultasController : Controller
    {

        public List<Cliente> clientes = new List<Cliente>()
        {
             new Cliente(){idcliente="CL001", nombre="CIBERTEC", direccion="LIMA", email="informes@cibertec.edu.pe", fono="4517239"},
             new Cliente(){idcliente="CL002", nombre="UPC", direccion="LIMA", email="informes@upc.edu.pe", fono="6787239"},
             new Cliente(){idcliente="CL003", nombre="UPN", direccion="LIMA", email="informes@upn.edu.pe", fono="4528939"},
             new Cliente(){idcliente="CL004", nombre="UNMSMS", direccion="LIMA", email="informes@unmsms.edu.pe", fono="4111239"},
             new Cliente(){idcliente="CL005", nombre="LAURET", direccion="LIMA", email="informes@lauret.edu.pe", fono="4137239"}
        };


        //================debajo los metodos para las vistas===============================
        public ActionResult Index()
        {
            return View(clientes);
        }

        public ActionResult Buscar(string nombre = "")
        {
            if (string.IsNullOrEmpty(nombre)) {
                return View(clientes);
            }
            else {
                return View(clientes.Where(c => c.nombre.StartsWith(nombre)));
            }
        }
    }
}