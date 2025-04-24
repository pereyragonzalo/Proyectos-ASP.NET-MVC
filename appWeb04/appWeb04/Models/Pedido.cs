using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appWeb04.Models
{
    public class Pedido
    {
        [Display(Name = "id Pedido")] public int idpedido { set; get; }
        [Display(Name = "FechaPedido"),DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")] public DateTime fechapedido { set; get; }
        [Display(Name = "Nombre Cliente")] public string nombrecia { set; get; }
        [Display(Name = "Direccion")] public string dirdestinatario { set; get; }
        [Display(Name = "Ciudad")] public string ciudestinatario { set; get; }
    }
}