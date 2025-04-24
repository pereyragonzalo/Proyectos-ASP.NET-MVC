using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POOII_CL2_PEREYRA_GONZALO.Models
{
    public class Categoria
    {
        [Display(Name = "Id categoria")] public int CategoryID { get; set; }
        [Display(Name = "Nombre categoria")] public string CategoryName { get; set; }
    }
}