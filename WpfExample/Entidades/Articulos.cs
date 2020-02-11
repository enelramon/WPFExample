using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfExample.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public decimal Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal Ganancia { get; set; }
        public decimal Precio { get; set; }
    }
}
