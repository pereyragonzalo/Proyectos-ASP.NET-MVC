using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appWeb05.Models
{
    public class Insumos
    {
        [Display(Name ="Id Insumo"), Required] public int idInsumo { get; set; }
        [Display(Name = "Nombre Insumo"), Required] public string nomInsumo { get; set; }
        [Display(Name = "Nombre Proveedor"), Required] public string NomProveedor { get; set; }
        [Display(Name = "Id Proveedor")] public int idProveedor { get; set; }
        [Display(Name = "Precio"), Required] public decimal preUnitario { get; set; }
        [Display(Name = "Stock"), Required] public Int16 stockUnitario { get; set; }

    }
}