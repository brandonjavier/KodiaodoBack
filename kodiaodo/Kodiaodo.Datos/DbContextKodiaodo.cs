using Kodiaodo.Datos.Mapping.Almacen;
using Kodiaodo.Entidades.Almacen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kodiaodo.Datos
{
    public class DbContextKodiaodo : DbContext
    {
        //exponiendo la coleccion Enfermedad en un objeto llamado Enfermedades
        public DbSet<Enfermedad> Enfermedades { get; set; }
        public DbContextKodiaodo(DbContextOptions<DbContextKodiaodo> options) : base(options)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EnfermedadMap());
        }
    }
}
