using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace appWeb03.Models
{
    public class Producto
    {
        [Display(Name = "IdProducto")] public int idproducto {  get; set; }
        [Display(Name = "Nombre Producto")] public string nomproducto { get; set; }
        [Display(Name = "Nombre Categoria")] public string nombrecategoria { get; set; }
        [Display(Name = "Precio Unitario")] public decimal preciounidad { get; set; }
        [Display(Name = "Unidades Disponibles")] public Int16 UnidadesEnExistencia { get; set; }
        [Display(Name = "Sub Total")] public decimal total { get { return preciounidad * UnidadesEnExistencia;  } }

    }
}