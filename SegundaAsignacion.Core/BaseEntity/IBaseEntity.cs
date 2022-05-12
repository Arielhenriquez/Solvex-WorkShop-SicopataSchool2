using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Core.BaseEntity
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool Eliminado { get; set; }
        DateTime FechaCreada { get; set; }
    }
}
