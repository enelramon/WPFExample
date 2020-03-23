using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfExample.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            Clave = string.Empty;
        }

        public Usuarios(int usuarioId, string nombre, string clave)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Clave = clave;
        }
    }
}
