using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appWeb03.Models
{
    public class Cliente
    {
        [Display(Name = "Id Cliente")] public string idcliente { set; get; }
        [Display(Name = "Nombre Cliente")] public string nombrecia { set; get; }
        [Display(Name = "Dirección")] public string direccion { set; get; }
        [Display(Name = "Pais")] public string nombrepais { set; get; }
        [Display(Name = "Teléfono")] public string telefono { set; get; }
    }
}