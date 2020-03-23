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
        public decimal Costo { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Costo = 0;
        }

        public Articulos(int articuloId, string descripcion, decimal costo)
        {
            ArticuloId = articuloId;
            Descripcion = descripcion;
            Costo = costo;
        }
    }
}
