using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Core.BaseEntityDto
{
    public class BaseEntityDto : IBaseEntityDto
    {
        public string? CreadoPor { get; set; }
        public DateTime FechaCreada { get; set; }
    }
}
