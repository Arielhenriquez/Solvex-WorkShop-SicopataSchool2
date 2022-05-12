using SegundaAsignacion.Model.Entities;
using SegundaAsignacion.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundaAsignacion.Services.GenericServices
{
    public class CrudService : ICrudService
    {
        private IRepository<Estudiantes> _repository;

        public CrudService(IRepository<Estudiantes> repository)
        {
            _repository = repository;
        }
        public IQueryable<Estudiantes> GetAllEstudiantes()
        {
            return _repository.GetAll();
        }

        public Estudiantes GetEstudiantes(int id)
        {
            return _repository.Get(id);
        }

        public void InsertEstudiantes(Estudiantes estudiantes)
        {
            _repository.Insert(estudiantes);
        }

        public void UpdateEstudiantes(Estudiantes estudiantes)
        {
            _repository.Update(estudiantes);
        }
        public void DeleteEstudiantes(int id)
        {
            Estudiantes estudiantes = GetEstudiantes(id);
            _repository.Remove(estudiantes);
            _repository.SaveChanges();
        }
    }
}
