using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WpfExample.Entidades;

namespace WpfExample.DAL
{
    public class Contexto: DbContext
    {

        public DbSet<Personas> Personas { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        //para usar SQLITE hay que modificar el XML del proyecto y poner lo siguiente debajo de "TargetFramework" 
        //<StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Data\Inventario.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios { UsuarioId = 1, Nombre = "Admin", Clave = "Admin" });
        }
    }


}
