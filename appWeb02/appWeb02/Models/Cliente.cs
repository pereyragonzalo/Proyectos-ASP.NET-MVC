using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//importar la libreria
using System.ComponentModel.DataAnnotations;

namespace appWeb02.Models
{
    public class Cliente
    {
        [Display(Name = "Id Cliente")] public String idcliente {  get; set; }
        [Display(Name = "Nombre Cliente")] public String nombre { get; set; }
        [Display(Name = "Direccion")] public String direccion { get; set; }
        [Display(Name = "Correo Electronico")] public String email { get; set; }
        [Display(Name = "Telefono")] public String fono { get; set; }
    }
}