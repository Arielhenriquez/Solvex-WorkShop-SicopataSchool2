using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SegundaAsignacion.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Model.Context
{
    public class NotasMap : IEntityTypeConfiguration<Notas>
    {
        public void Configure(EntityTypeBuilder<Notas> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_idNotas");

            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("id")
                   .HasColumnType("INT");
            builder.Property(x => x.Titulo)
                .HasColumnName("Titulo")
                   .HasColumnType("NVARCHAR(100)")
                   .IsRequired();

            builder.Property(x => x.Descripcion)
              .HasColumnName("Descripcion")
                 .HasColumnType("NVARCHAR(50)")
                 .IsRequired();

            builder.Property(x => x.Nombre)
           .HasColumnName("Nombre")
              .HasColumnType("NVARCHAR(50)")
              .IsRequired();

            builder.Property(x => x.Estado)
              .HasColumnName("Estado")
                 .HasColumnType("bit");

            builder.Property(x => x.Eliminado)
              .HasColumnName("Eliminado")
                 .HasColumnType("bit");

            builder.Property(x => x.Imagen)
             .HasColumnName("Imagen")
               .HasColumnType("NVARCHAR(50)")
               .IsRequired();

            builder.Property(x => x.FechaCreada)
              .HasColumnName("fecha_creada")
                 .HasColumnType("datetime");


         
        }
    }
}
