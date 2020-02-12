using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EjemploWpfApp.Entidades
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Persona()
        {
            PersonaId = 0;
            Nombres = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;
        }

        public Persona(int personaId, string nombres, string telefono, string cedula, string direccion, DateTime fechaNacimiento)
        {
            PersonaId = personaId;
            Nombres = nombres;
            Telefono = telefono;
            Cedula = cedula;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
        }
    }
}
