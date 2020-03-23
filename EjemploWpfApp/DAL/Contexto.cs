using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EjemploWpfApp.Entidades;

namespace EjemploWpfApp.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = LUISDAVIDSO\SQLEXPRESS; Database = PersonasDb; Trusted_Connection = True ");
        }
    }
}
