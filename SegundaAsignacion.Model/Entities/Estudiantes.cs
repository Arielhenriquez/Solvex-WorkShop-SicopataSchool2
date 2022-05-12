using SegundaAsignacion.Core.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Model.Entities
{
    public class Estudiantes : BaseEntity
    {
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
    }
}
