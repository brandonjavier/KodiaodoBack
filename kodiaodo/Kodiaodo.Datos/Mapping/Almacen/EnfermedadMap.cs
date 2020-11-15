using Kodiaodo.Entidades.Almacen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace Kodiaodo.Datos.Mapping.Almacen
{
    public class EnfermedadMap : IEntityTypeConfiguration<Enfermedad>
    {
        public void Configure(EntityTypeBuilder<Enfermedad> builder)
        {
            builder.ToTable("Enfermedad")
                .HasKey(e => e.idenfermedad);
            builder.Property(e => e.nombre)
                .HasMaxLength(50);
            builder.Property(e => e.descripcion)
                .HasMaxLength(250);
        }
    }
}
