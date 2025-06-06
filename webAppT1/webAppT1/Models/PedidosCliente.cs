﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webAppT1.Models
{
    public class PedidosCliente
    {
        [Display(Name = "Nombre")] public string company_name { get; set; }
        [Display(Name = "Codigo")] public int order_id { get; set; }
        [Display(Name = "Fecha"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] public DateTime order_date { get; set; }
        [Display(Name = "Transporte")] public float? freight { get; set; }
        [Display(Name = "Direccion")] public string ship_address { get; set; }
        [Display(Name = "Ciudad")] public string ship_city { get; set; }
        [Display(Name = "Codigo Empleado")] public int employee_id { get; set; }
    }
}