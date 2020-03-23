using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WpfExample.Entidades;

namespace WpfExample.DAL
{
    public class Contexto: DbContext
    {

        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Personas> Personas { get; set; }

        //para usar SQLITE hay que modificar el XML del proyecto y poner lo siguiente debajo de "TargetFramework" 
        //<StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Data\Inventario.db");
        }

    }


}
