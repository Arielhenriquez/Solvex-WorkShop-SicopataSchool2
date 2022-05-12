using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Core.BaseEntity
{
    public class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
        public virtual string? Nombre { get; set; }
        public virtual bool Eliminado { get; set; }
        public virtual DateTime FechaCreada { get; set; }
    }
}
