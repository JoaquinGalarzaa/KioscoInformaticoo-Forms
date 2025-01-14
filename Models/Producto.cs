﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoInformaticoo.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public decimal Precio { get; set; } = decimal.Zero;//igual a 0 ()
    }
}
