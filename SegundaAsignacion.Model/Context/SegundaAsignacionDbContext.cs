using Microsoft.EntityFrameworkCore;
using SegundaAsignacion.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Model.Context
{
    public class SegundaAsignacionDbContext : DbContext
    {
        public DbSet<Notas> Notas { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public SegundaAsignacionDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new EstudiantesMap());
            //modelBuilder.ApplyConfiguration(new NotasMap());
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Notas>();
        }

    }
}
