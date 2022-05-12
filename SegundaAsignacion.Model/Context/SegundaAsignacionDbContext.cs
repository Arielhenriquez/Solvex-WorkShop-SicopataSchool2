using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Model.Context
{
    public class SegundaAsignacionDbContext : DbContext
    {
        public SegundaAsignacionDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new EstudiantesMap());
            modelBuilder.ApplyConfiguration(new NotasMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
