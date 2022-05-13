using SegundaAsignacion.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Services.GenericServices
{
    public interface ICrudNotas
    {
        IQueryable<Notas> GetAllNotas();
        Notas GetNotas(int id);
        void InsertNotas(Notas notas);
        void UpdateNotas(Notas notas);
        void DeleteNotas(int id);
    }
}
