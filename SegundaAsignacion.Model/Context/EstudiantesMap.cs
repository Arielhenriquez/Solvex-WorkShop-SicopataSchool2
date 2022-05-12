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
    public class EstudiantesMap : IEntityTypeConfiguration<Estudiantes>
    {
        public void Configure(EntityTypeBuilder<Estudiantes> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_idestudiante");

            builder.Property(x => x.Id).ValueGeneratedOnAdd()
                .HasColumnName("id")
                   .HasColumnType("INT");
            builder.Property(x => x.Correo)
                .HasColumnName("correo")
                   .HasColumnType("NVARCHAR(100)")
                   .IsRequired();
            builder.Property(x => x.Contraseña)
              .HasColumnName("contraseña")
                 .HasColumnType("NVARCHAR(50)")
                 .IsRequired();
            builder.Property(x => x.FechaCreada)
              .HasColumnName("fecha_creada")
                 .HasColumnType("datetime");
            builder.Property(x => x.Eliminado)
              .HasColumnName("eliminado")
                 .HasColumnType("bit");
        }
    }

}

