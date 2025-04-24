using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POOII_CL2_PEREYRA_GONZALO.Models
{
    public class Producto
    {
        [Display(Name = "Id producto")] public int ProductID { get; set; }
        [Display(Name = "Nombre")] public string ProductName { get; set; }
        [Display(Name = "Id Categoria")] public int CategoryID { get; set; }
        [Display(Name = "Precio")] public decimal UnitPrice { get; set; }
        [Display(Name = "Unidades disponibles")] public Int16 UnitsInStock { get; set; }
        [Display(Name = "Nombre categoria")] public string CategoryName { get; set; }
    }
}