using SegundaAsignacion.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Model.Entities
{
    public class Notas : BaseEntity
    {
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
        public string? Imagen { get; set; }
    }
}
