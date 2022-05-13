using SegundaAsignacion.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Services.GenericServices
{
    public interface ICrudEstudiantes
    {
        IQueryable<Estudiantes> GetAllEstudiantes();
        Estudiantes GetEstudiantes(int id);
        void InsertEstudiantes(Estudiantes estudiantes);
        void UpdateEstudiantes(Estudiantes estudiantes);
        void DeleteEstudiantes(int id);
    }
}
